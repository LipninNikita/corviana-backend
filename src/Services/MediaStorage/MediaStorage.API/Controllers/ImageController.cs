using MediaStorage.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediaStorage.API.Controllers
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
        public async Task<IActionResult> GetImages(string postId)
        {
            var result = await _imageService.GetImages(postId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImages(IFormFile file, string postId)
        {
            await _imageService.UploadFile(file, postId);
            return Ok();
        }
    }
}
