using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostComments.API.DTO;
using PostComments.API.Services;

namespace PostComments.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class PostCommentsController : ControllerBase
    {
        private readonly IPostCommentService _postCommentService;

        public PostCommentsController(IPostCommentService postCommentService)
        {
            _postCommentService = postCommentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string postId)
        {
            var result = await _postCommentService.GetPostComments(postId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPostComment input)
        {
            var result = await _postCommentService.AddPostComment(input);
            return Ok(result);
        }
    }
}
