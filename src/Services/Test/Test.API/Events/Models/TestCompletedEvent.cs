using EventBusRabbitMq.Events;

namespace Test.API.Events.Models
{
    public class TestCompletedEvent : Event
    {
        public int TestId { get; set; }
        public string QuestionIds { get; set; }
        public string UserId { get; set; }
    }
}
