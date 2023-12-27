using EventBusRabbitMq.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest.API.Events.Models
{
    public class QuestOverdueEvent : Event
    {
        public Guid QuestId { get; set; }
    }
}
