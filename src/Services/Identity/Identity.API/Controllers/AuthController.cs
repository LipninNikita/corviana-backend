using Identity.API.DTO.Input;
using Identity.API.Services.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Identity.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _loginService;

        public AuthController(IAuthService loginService)
        {
            _loginService = loginService;
        }
        /// <summary>
        /// Handle postback from username/password login
        /// </summary>
        [HttpPost]
        [Route(nameof(SignIn))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInInput signInInputModel)
        {
            var result = await _loginService.SignInAsync(signInInputModel);

            return Ok(result);
        }

        /// <summary>
        /// Handle postback from username/password login
        /// </summary>
        [HttpPost]
        [Route(nameof(SignUp))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [AllowAnonymous]
        public async Task<IdentityResult> SignUp(SignUpInput signUpInputModel)
        {
            var result = await _loginService.SignUpAsync(signUpInputModel);

            return result;
        }
    }
}
