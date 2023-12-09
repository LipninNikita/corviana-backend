using Identity.API.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Common.UserAccessor;

namespace Identity.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserAccessor _userAccessor;

        public UsersController(IUserService userService, IUserAccessor userAccessor)
        {
            _userService = userService;
            _userAccessor = userAccessor;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var result = await _userService.GetUserById(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var context = this.HttpContext;
            var result = await _userService.GetUsers();

            return Ok(result);
        }

        [HttpGet]
        [Route("UserId")]
        public IActionResult GetUserId()
        {
            var result = _userAccessor.GetUserId();

            return Ok(result);
        }
    }
}
