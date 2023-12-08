using EventBusRabbitMq;
using Membership.BackgroundTasks.Events.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.BackgroundTasks
{
    public class CheckMembershipOverdueJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var schedulerContext = context.Scheduler.Context;
            var bus = (IEventBus)schedulerContext.Get("bus");

            bus.Publish(new MembershipOverdueEvent() { UserId = context.JobDetail.JobDataMap.GetString("userId") });
        }
    }
}
