using Answer.API.Services;
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
    }
}
