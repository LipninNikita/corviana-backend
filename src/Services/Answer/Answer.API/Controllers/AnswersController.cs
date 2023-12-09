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
        public async Task<IActionResult> Get([FromBody]string ids) 
        {
            var result = _answerService.GetByIds(ids);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Check(int QuestionId)
        {
            var result = await _answerService.CheckQuestion(QuestionId);

            return Ok(result);
        }
    }
}
