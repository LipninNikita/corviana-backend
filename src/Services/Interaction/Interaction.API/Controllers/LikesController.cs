using Interaction.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interaction.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet]
        [Route("/{postId}/Amount")]
        public async Task<IActionResult> GetLikesAmountByPostId([FromRoute] string postId)
        {
            var result = await _likeService.GetLikesAmount(postId);
            return Ok(result);
        }
    }
}
