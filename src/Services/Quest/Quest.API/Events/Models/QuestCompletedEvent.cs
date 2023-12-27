using EventBusRabbitMq.Events;

namespace Quest.API.Events.Models
{
    public class QuestCompletedEvent : Event
    {
        public string UserId { get; set; }
        public Guid QuestId { get; set; }
        public int Level { get; set; }
    }
}
