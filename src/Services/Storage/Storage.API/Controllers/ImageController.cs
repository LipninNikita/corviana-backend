using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.API.Services;

namespace Storage.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetImages(Guid postId)
        {
            var result = await _imageService.GetImages(postId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImages(IFormFile file, Guid postId)
        {
            await _imageService.UploadFile(file, postId);
            return Ok();
        }
    }
}
