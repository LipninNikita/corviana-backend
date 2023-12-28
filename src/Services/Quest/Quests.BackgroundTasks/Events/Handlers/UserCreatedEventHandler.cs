using EventBusRabbitMq;
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
        private readonly IEventBus _bus;
        public UserCreatedEventHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(UserCreatedEvent @event)
        {
            var weekly = Extensions.Extension.GenerateRandomQuest(0, 0);
            _bus.Publish(new QuestCreatedEvent(Guid.NewGuid(), weekly.Name, weekly.TimesToFinish, @event.UserId, weekly.Level, weekly.QuestLifeTime, weekly.QuestType, weekly.DtCreated));

            var daily1 = Extensions.Extension.GenerateRandomQuest(1, 0);
            _bus.Publish(new QuestCreatedEvent(Guid.NewGuid(), daily1.Name, daily1.TimesToFinish, @event.UserId, daily1.Level, daily1.QuestLifeTime, daily1.QuestType, daily1.DtCreated));
           
            var daily2 = Extensions.Extension.GenerateRandomQuest(2, 0);
            _bus.Publish(new QuestCreatedEvent(Guid.NewGuid(), daily2.Name, daily2.TimesToFinish, @event.UserId, daily2.Level, daily2.QuestLifeTime, daily2.QuestType, daily2.DtCreated));
           
            var daily3 = Extensions.Extension.GenerateRandomQuest(3, 0);
            _bus.Publish(new QuestCreatedEvent(Guid.NewGuid(), daily3.Name, daily3.TimesToFinish, @event.UserId, daily3.Level, daily3.QuestLifeTime, daily3.QuestType, daily3.DtCreated));

            return Task.FromResult(true);
        }
    }
}
