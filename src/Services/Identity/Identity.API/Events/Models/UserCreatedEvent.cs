using EventBusRabbitMq.Events;

namespace Identity.API.Events.Models
{
    public class UserCreatedEvent : Event
    {
        public string UserId { get; set; }
    }
}
