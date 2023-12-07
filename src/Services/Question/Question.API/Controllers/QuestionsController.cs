﻿using Microsoft.AspNetCore.Authorization;
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
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var result = await _questionService.GetById(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetRandom([FromQuery] QuestionTypeEnum? type, [FromQuery] QuestionLvlEnum? lvl)
        {
            var result = await _questionService.GetRandom(type, lvl);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddQuestion input)
        {
            var result = await _questionService.Add(input);

            return Ok(result);
        }

    }
}