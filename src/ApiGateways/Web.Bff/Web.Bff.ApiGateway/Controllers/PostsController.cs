using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Bff.ApiGateway.Controllers
{
    [Route("api/v1/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public PostsController()
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPosts(int page, int rows)
        {
            return Ok(new[] { new { id = Guid.NewGuid(), Comment = new { Name = "Nikita", Content = "What a nice pic!", DT = DateTimeOffset.UtcNow }, Likes = 10, Views = 128 } });
        }
    }
}
