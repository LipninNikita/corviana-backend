﻿using EventBusRabbitMq;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest.BackgroundTasks
{
    public class CheckQuestOverdueJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var schedulerContext = context.Scheduler.Context;
            var bus = (IEventBus)schedulerContext.Get("bus");

            bus.Publish(new CheckQuestOverdueEvent() { UserId = context.JobDetail.JobDataMap.GetString("userId") });
        }
    }
}
