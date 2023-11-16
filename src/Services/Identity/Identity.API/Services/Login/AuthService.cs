using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Identity.API.DTO.Input;
using Identity.API.Data.Models;
using StackExchange.Redis;

namespace Identity.API.Services.Login
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = accessor;
            _configuration = configuration;
        }

        public async Task<bool> SignInAsync(SignInInput signInInputModel)
        {
            var user = await _userManager.FindByEmailAsync(signInInputModel.Email);
            if (user != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:SigningKey"]));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var expirationTimeStamp = DateTime.Now.AddMinutes(30);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email),
                };

                var tokenOptions = new JwtSecurityToken(
                    issuer: _configuration["Auth:Issuer"],
                    claims: claims,
                    expires: expirationTimeStamp,
                    signingCredentials: signingCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                _httpContextAccessor.HttpContext.Response.Headers.Add("Token", tokenString);
                return true;
            }

            throw new UnauthorizedAccessException();
        }

        public async Task<IdentityResult> SignUpAsync(SignUpInput signUpInputModel)
        {
            ApplicationUser user = signUpInputModel;
            return await _userManager.CreateAsync(user, signUpInputModel.Password);
        }
    }
}
