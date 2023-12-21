using Answer.API.Data;
using Answer.API.Events.Models;
using Answer.API.Services;
using EventBusRabbitMq.Events;

namespace Answer.API.Events.Handler
{
    public class TestEventHandler : IEventHandler<TestEvent>
    {
        private readonly IAnswerService _service;
        private readonly AppDbContext _appDbContext;
        public TestEventHandler(IAnswerService service, AppDbContext appDbContext)
        {
            _service = service;
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(TestEvent @event)
        {
            var model = new DTO.AddAnswer() { Annotation = "aaa", Content = "aaaa", IdQuestion = 1, IsRight = false };
            var result = await _service.Add(model);
            await Console.Out.WriteLineAsync("Added via service");
            await _appDbContext.Answers.AddAsync(model);
            await Console.Out.WriteLineAsync("Added via dbContext");
            return true;
        }
    }
}
