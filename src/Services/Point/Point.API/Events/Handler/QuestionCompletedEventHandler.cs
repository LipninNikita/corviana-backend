using EventBusRabbitMq.Events;
using Point.API.Events.Models;

namespace Point.API.Events.Handler
{
    public class QuestionCompletedEventHandler : IEventHandler<QuestionCompletedEvent>
    {
        public Task Handle(QuestionCompletedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
