using EventBusRabbitMq.Events;

namespace Quest.API.Events.Models
{
    public class QuestionCompeletedEvent : Event
    {
        public int QuestionId { get; set; }
        public int Level { get; set; }
        public string UserId { get; set; }
    }
}
