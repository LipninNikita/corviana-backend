using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Point.API.Services;

namespace Point.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly IPointTransactionService _pointTransactionService;

        public PointsController(IPointTransactionService pointTransactionService)
        {
            _pointTransactionService = pointTransactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaderboard()
        {
            var result = await _pointTransactionService.GetLeaderboard();

            return Ok(result);
        }

        [HttpGet]
        [Route("User")]
        public async Task<IActionResult> GetCurrentUserPlace()
        {
            var result = await _pointTransactionService.GetUserPlace();

            return Ok(result);
        }
    }
}
