using EventBusRabbitMq.Events;
using Quest.BackgroundTasks.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest.BackgroundTasks.Events.Handlers
{
    public class QuestCreatedEventHandler : IEventHandler<QuestCreatedEvent>
    {
        public Task Handle(QuestCreatedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
