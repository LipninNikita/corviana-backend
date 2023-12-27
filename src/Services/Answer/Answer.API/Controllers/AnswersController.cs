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

        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet]
        [Route("/GetAnswersByQuestionId/{id}")]
        public async Task<IActionResult> Get([FromRoute]int id) 
        {
            var result = await _answerService.GetByQuestionId(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("/CheckAnswersByQuestionId/{id}")]
        public async Task<IActionResult> Check(int QuestionId)
        {
            var result = await _answerService.Answer(QuestionId);

            return Ok(result);
        }
    }
}
