using EventBusRabbitMq.Events;

namespace Membership.API.Events.Models
{
    public class MembershipOverdue : Event
    {
        public string UserId { get; set; }
    }
}
