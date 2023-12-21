using Answer.API.Data;
using Answer.API.Events.Models;
using Answer.API.Services;
using EventBusRabbitMq.Events;

namespace Answer.API.Events.Handler
{
    public class TestEventHandler : IEventHandler<TestEvent>
    {
        private readonly IAnswerService _service;
        public TestEventHandler(IAnswerService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(TestEvent @event)
        {
            var result = await _service.Add(new DTO.AddAnswer() { Annotation = "aaa", Content = "aaaa", IdQuestion = 1, IsRight = false });
            await Console.Out.WriteLineAsync(@event.Message + result);
            return true;
        }
    }
}
