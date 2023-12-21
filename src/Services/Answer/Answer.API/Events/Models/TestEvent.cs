using EventBusRabbitMq.Events;

namespace Answer.API.Events.Models
{
    public class TestEvent : Event
    {
        public string Message { get; set; }
    }
}
