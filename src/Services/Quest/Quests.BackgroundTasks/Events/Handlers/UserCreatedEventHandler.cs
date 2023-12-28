using EventBusRabbitMq.Events;
using Quest.BackgroundTasks.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest.BackgroundTasks.Events.Handlers
{
    public class UserCreatedEventHandler : IEventHandler<UserCreatedEvent>
    {
        public Task<bool> Handle(UserCreatedEvent @event)
        {
            var weekly = Extensions.Extension.GenerateRandomQuest(0, 0);

            var daily1 = Extensions.Extension.GenerateRandomQuest(1, 0);
            var daily2 = Extensions.Extension.GenerateRandomQuest(1, 0);
            var daily3 = Extensions.Extension.GenerateRandomQuest(1, 0);

            return true;
        }
    }
}
