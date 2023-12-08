using Identity.API.Data.Models;
using Identity.API.DTO.Input;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.API.Services.Login
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor accessor, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = accessor;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task AddRole(string Name)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole { Name = Name });
        }

        public async Task AddToTole(string Name, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, Name);
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
                    new Claim(ClaimTypes.Email, user.Email),
                };

                var roles = await _userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

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
