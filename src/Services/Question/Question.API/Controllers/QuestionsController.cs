using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Question.API.Data.Models;
using Question.API.DTO;
using Question.API.Services;

namespace Question.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        [Route("Answer")]
        public async Task<IActionResult> Answer([FromBody]int QuestionId, [FromBody]bool IsSuccess)
        {
            await _questionService.AnswerQuestion(QuestionId, IsSuccess);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _questionService.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute]string id)
        {
            var result = await _questionService.GetByIds(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("Random")]
        public async Task<IActionResult> GetRandom([FromQuery] QuestionTypeEnum? type, [FromQuery] QuestionLvlEnum? lvl)
        {
            var result = await _questionService.GetRandom(type, lvl);

            return Ok(result);
        }
    }
}
