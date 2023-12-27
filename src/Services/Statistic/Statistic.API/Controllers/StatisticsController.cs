using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Statistic.API.Services;

namespace Statistic.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet, Route("UserStatistics/{userId}")]
        public async Task<IActionResult> GetUserStatistic([FromQuery] DateTime dtStart, [FromQuery] DateTime dtEnd, [FromRoute] string userId)
        {
            var result = await _statisticService.GetUserStatistics(dtStart, dtEnd, userId);

            return Ok(result);
        }

        [HttpGet, Route("QuestionStatistics/{id}")]
        public async Task<IActionResult> GetQuestionStatistic(int id)
        {
            var result = await _statisticService.GetQuestionStatistics(id);

            return Ok(result);
        }
    }
}
