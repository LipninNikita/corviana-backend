using EventBusRabbitMq;
using Membership.API.Events.Models;
using Membership.BackgroundTasks;
using Membership.BackgroundTasks.Events.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;

class Program
{
    static async Task Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
                   .ConfigureServices(async (context, services) =>
                   {                           
                       ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
                       IScheduler scheduler = await schedulerFactory.GetScheduler();

                       services.AddSingleton(scheduler);

                       await scheduler.Start();

                       var provider = services.BuildServiceProvider();
                       var bus = provider.GetRequiredService<IEventBus>();
                       scheduler.Context.Put("bus", bus);

                       services.AddTransient<MembershipBoughtEventHandler>();
                       bus.Subscribe<MembershipBoughtEvent, MembershipBoughtEventHandler>();
                   })
                   .Build();

        await host.RunAsync();
    }
}