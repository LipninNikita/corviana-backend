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

        [HttpGet]
        public async Task<IActionResult> GetUserStatistic()
        {
            var result = await _statisticService.GetUserStatistic();

            return Ok(result);
        }
    }
}
