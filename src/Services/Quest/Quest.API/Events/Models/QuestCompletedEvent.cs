using EventBusRabbitMq.Events;

namespace Quest.API.Events.Models
{
    public class QuestCompletedEvent : Event
    {
        public string UserId { get; set; }
        public string QuestId { get; set; }
        public int Level { get; set; }
    }
}
