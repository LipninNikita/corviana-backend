using EventBusRabbitMq.Events;

namespace Quest.BackgroundTasks.Events.Models
{
    public class UserCreatedEvent : Event
    {
        public string UserId { get; set; }
    }
}
