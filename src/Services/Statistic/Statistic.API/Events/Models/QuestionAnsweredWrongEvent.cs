using EventBusRabbitMq.Events;

namespace Statistic.API.Events.Models
{
    public class QuestionAnsweredWrongEvent : Event
    {
        public int QuestionId { get; set; }
        public string UserId { get; set; }
    }
}
