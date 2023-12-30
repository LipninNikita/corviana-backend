using EventBusRabbitMq;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quest.BackgroundTasks.Events.Handlers;
using Quest.BackgroundTasks.Events.Models;
using Quests.BackgroundTasks;

class Program
{
    static async Task Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
                   .ConfigureServices(async (context, services) =>
                   {
                       GlobalConfiguration.Configuration.UseMemoryStorage();

                       services.AddEventBus(context.Configuration["RabbitMQ"]);

                       var provider = services.BuildServiceProvider();
                       var bus = provider.GetRequiredService<IEventBus>();
                       bus.Subscribe<UserCreatedEvent, UserCreatedEventHandler>();
                   })
                   .Build();

        await host.RunAsync();
    }
}