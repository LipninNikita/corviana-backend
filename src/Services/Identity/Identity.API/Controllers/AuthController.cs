﻿using Identity.API.DTO.Input;
using Identity.API.Services.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        [Route(nameof(SignIn))]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInInput signInInputModel)
        {
            var result = await _loginService.SignInAsync(signInInputModel);

            return Ok(result);
        }

        [HttpPost]
        [Route(nameof(SignUp))]
        [AllowAnonymous]
        public async Task<IdentityResult> SignUp(SignUpInput signUpInputModel)
        {
            var result = await _loginService.SignUpAsync(signUpInputModel);

            return result;
        }

        [HttpPost]
        [Route(nameof(AddRole))]
        public async Task<IActionResult> AddRole([FromQuery]string roleName)
        {
            await _loginService.AddRole(roleName);
            return Ok();
        }

        [HttpPost]
        [Route(nameof(AddToRole))]
        public async Task<IActionResult> AddToRole([FromQuery]string roleName, string userId)
        {
            await _loginService.AddToTole(roleName, userId);

            return Ok();
        }
    }
}
