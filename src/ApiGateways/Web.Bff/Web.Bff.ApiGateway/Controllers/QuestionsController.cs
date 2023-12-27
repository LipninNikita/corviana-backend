using EventBusRabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Questions.API.Grpc.Services;
using Web.Bff.ApiGateway.DTO;
using Web.Bff.ApiGateway.Events.Models;
using Web.Bff.ApiGateway.Services;

namespace Web.Bff.ApiGateway.Controller
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IEventBus _bus;
        private readonly QuestionsGrpcService.QuestionsGrpcServiceClient _client;

        public QuestionsController(IEventBus bus, QuestionsGrpcService.QuestionsGrpcServiceClient client)
        {
            _bus = bus;
            _client = client;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddQuestion input)
        {
            var result = await _client.AddQuestionAsync(new AddQuestionRequest() { Title = input.Title, Content = input.Content, Lvl = input.Level, Type = input.Type, IsFree = input.IsFree, Hint = input.Hint});

            _bus.Publish(new QuestionCreatedEvent() { Answers = input.Answers.Select(x => new Answer() { Content = x.Content, IsRight = x.IsRight}), QuestionId = result.Id });
            
            return Ok(result.Id);
        }
    }
}
