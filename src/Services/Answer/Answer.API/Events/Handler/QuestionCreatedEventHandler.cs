using Answer.API.DTO;
using Answer.API.Events.Models;
using Answer.API.Services;
using EventBusRabbitMq.Events;

namespace Answer.API.Events.Handler
{
    public class QuestionCreatedEventHandler : IEventHandler<QuestionCreatedEvent>
    {
        private readonly IAnswerService _answerService;

        public QuestionCreatedEventHandler(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        public async Task<bool> Handle(QuestionCreatedEvent @event)
        {
            foreach (var answer in @event.Answers)
            {
                await _answerService.Add(new AddAnswer() { Content = answer.Content, IdQuestion = @event.QuestionId, IsRight = answer.IsRight });
            }

            return true;
        }
    }
}
