using EventBusRabbitMq.Events;

namespace Quest.BackgroundTasks.Events.Models
{
    public class QuestCreatedEvent : Event
    {
        public Guid QuestId { get; set; }
        public DateTimeOffset DtEnd { get; set; }
    }
}
