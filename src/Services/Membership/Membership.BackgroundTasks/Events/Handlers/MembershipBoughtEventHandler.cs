using EventBusRabbitMq.Events;
using Membership.API.Events.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.BackgroundTasks.Events.Handlers
{
    internal class MembershipBoughtEventHandler : IEventHandler<MembershipBoughtEvent>
    {
        private readonly IScheduler _scheduler;
        public MembershipBoughtEventHandler(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public async Task<bool> Handle(MembershipBoughtEvent @event)
        {
            IJobDetail job = JobBuilder.Create<CheckMembershipOverdueJob>()
                     .WithIdentity(nameof(@event) + "Job" + Guid.NewGuid(), "CheckMembership")
                     .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(nameof(@event) + "Trigger" + Guid.NewGuid(), "CheckMembership")
                .StartAt(@event.DtEnd)
                .UsingJobData("userId", @event.UserId)
                .Build();

            await _scheduler.ScheduleJob(job, trigger);

            return true;
        }
    }
}
