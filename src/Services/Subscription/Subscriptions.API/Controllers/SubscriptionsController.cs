using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Subscriptions.API.Services;

namespace Subscriptions.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionsController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _subscriptionService.GetUserSubscriptions();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string SubscribeTo)
        {
            var result = await _subscriptionService.Subscribe(SubscribeTo);
            return Ok(result);
        }
    }
}
