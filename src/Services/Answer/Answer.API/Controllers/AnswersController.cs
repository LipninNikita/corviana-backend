using Answer.API.Events.Models;
using Answer.API.Services;
using EventBusRabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Answer.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly IEventBus _bus;

        public AnswersController(IAnswerService answerService, IEventBus bus)
        {
            _answerService = answerService;
            _bus = bus;
        }

        [HttpGet]
        [Route("{ids}")]
        public async Task<IActionResult> Get([FromRoute]string ids) 
        {
            var result = await _answerService.GetByIds(ids);
            return Ok(result);
        }

        [HttpGet]
        [Route("Check")]
        public async Task<IActionResult> Check(int QuestionId)
        {
            var result = await _answerService.CheckQuestion(QuestionId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Test()
        {
            _bus.Publish(new TestEvent() { Message = "Hail world!" });
            return Ok();
        }
    }
}
