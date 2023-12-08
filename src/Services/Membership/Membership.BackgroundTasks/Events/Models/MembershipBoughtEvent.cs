using EventBusRabbitMq.Events;

namespace Membership.API.Events.Models
{
    public class MembershipBoughtEvent : Event
    {
        public required string UserId { get; set; }
        public required DateTimeOffset DtEnd { get;set;}
    }
}
