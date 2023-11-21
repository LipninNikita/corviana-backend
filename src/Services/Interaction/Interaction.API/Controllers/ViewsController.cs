using EventBusRabbitMq;
using Interaction.API.Events.Models;
using Interaction.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Common.UserAccessor;

namespace Interaction.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class ViewsController : ControllerBase
    {
        private readonly IViewService _viewService;
        private readonly IUserAccessor _userAccessor;

        public ViewsController(IViewService viewService, IUserAccessor userAccessor)
        {
            _viewService = viewService;
            _userAccessor = userAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> LikePost([FromRoute] string postId)
        {
            var userId = _userAccessor.GetUserId();
            await _viewService.AddViewInteraction(postId, userId);
            return Ok();
        }
    }
}
