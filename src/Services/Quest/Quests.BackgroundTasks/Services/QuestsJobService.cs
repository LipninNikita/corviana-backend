using EventBusRabbitMq.Events;
using Quartz;
using Quest.BackgroundTasks.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest.BackgroundTasks.Services
{
    public class QuestsJobService : IQuestsJobService
    {
        private readonly IScheduler _scheduler;

        public QuestsJobService(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public async Task<bool> AddJob(Guid QuestId, DateTime dtEnd)
        {
            IJobDetail job = JobBuilder.Create<QuestOverdueJob>()
             .WithIdentity(nameof(QuestOverdueJob)+ Guid.NewGuid(), "CheckMembership")
             .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(nameof(QuestOverdueJob) + "Trigger" + Guid.NewGuid(), "CheckMembership")
                .StartAt(dtEnd)
                .UsingJobData("questId", QuestId)
            .Build();

            await _scheduler.ScheduleJob(job, trigger);

            return true;
        }
    }
}
