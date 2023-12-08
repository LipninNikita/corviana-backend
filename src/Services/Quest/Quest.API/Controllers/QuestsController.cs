using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quest.API.DTO;
using Quest.API.Services;

namespace Quest.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class QuestsController : ControllerBase
    {
        private readonly IQuestService _questService;

        public QuestsController(IQuestService questService)
        {
            _questService = questService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _questService.GetById(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("/Users/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            var result = await _questService.GetByUserId(userId);

            return Ok(result);
        }
    }
}
