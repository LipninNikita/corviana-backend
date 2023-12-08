using EventBusRabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly QuestionsGrpcServiceClient _client;

        public QuestionsController(IEventBus bus, QuestionsGrpcServiceClient client)
        {
            _bus = bus;
            _client = client;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddQuestion input)
        {
            var result = await _client.AddQuestionAsync(new AddQuestionRequest() { Content = input.Content, Lvl = input.Level, Type = input.Type});

            _bus.Publish(new QuestionCreatedEvent() { Answers = input.Answers.Select(x => new Answer() { Content = x.Content, IsRight = x.IsRight}), QuestionId = result.Id });
            
            return Ok(result.Id);
        }
    }
}
