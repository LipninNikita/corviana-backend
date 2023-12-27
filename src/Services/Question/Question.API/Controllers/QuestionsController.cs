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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _questionService.GetAll();

            return Ok(result);
        }

        [HttpGet, Route("/{id}/Hint")]
        public async Task<IActionResult> GetHint([FromRoute]int id)
        {
            var result = await _questionService.GetHintByQuestionId(id);

            return Ok(result);
        }
    }
}
