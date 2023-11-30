using EventBusRabbitMq;
using EventBusRabbitMq.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Post.API.Services;
using Services.Common.UserAccessor;

namespace Post.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var result = await _postService.GetPosts();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(IEnumerable<IFormFile> files)
        {
            var postId = _postService.AddPost(files);

            return Ok(postId);
            //return Ok(new[] { new { id = Guid.NewGuid(), Comment = new { Name = "Nikita", Content = "What a nice pic!", DT = DateTimeOffset.UtcNow }, Likes = 10, Views = 128 } });
        }
    }
}
