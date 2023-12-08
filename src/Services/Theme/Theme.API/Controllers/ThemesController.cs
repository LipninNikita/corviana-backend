using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Theme.API.DTO;
using Theme.API.Services;

namespace Theme.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        private readonly IThemeService _themeService;

        public ThemesController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _themeService.GetThemes();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _themeService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTheme input)
        {
            var result = await _themeService.Add(input);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTheme input)
        {
            var result = _themeService.Update(input);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] int id)
        {
            await _themeService.Remove(id);

            return Ok();
        }
    }
}
