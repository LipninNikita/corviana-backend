using EventBusRabbitMq.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.BackgroundTasks.Events.Models
{
    public class MembershipOverdueEvent : Event
    {
        public string UserId { get; set; }
    }
}
