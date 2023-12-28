using EventBusRabbitMq.Events;
using Quartz;
using Quest.BackgroundTasks.Events.Models;
using Quest.BackgroundTasks.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest.BackgroundTasks.Events.Handlers
{
    public class QuestCreatedEventHandler : IEventHandler<QuestCreatedEvent>
    {
        private readonly IScheduler _scheduler;
        public QuestCreatedEventHandler(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public async Task<bool> Handle(QuestCreatedEvent @event)
        {
            IJobDetail job = JobBuilder.Create<QuestOverdueJob>()
                .WithIdentity(nameof(@event) + "Job" + Guid.NewGuid(), "CheckMembership")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(nameof(@event) + "Trigger" + Guid.NewGuid(), "CheckMembership")
                .StartAt(@event.DtEnd)
                .UsingJobData("questId", @event.QuestId)
            .Build();

            await _scheduler.ScheduleJob(job, trigger);

            return true;
        }
    }
}
