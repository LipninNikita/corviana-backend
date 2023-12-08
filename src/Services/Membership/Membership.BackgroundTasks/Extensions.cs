using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Polly.Retry;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Polly;
using EventBusRabbitMq;

namespace Membership.BackgroundTasks
{
    public static class Extensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, string connString)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://" + connString);

            var policy = RetryPolicy.Handle<SocketException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(10, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            policy.Execute(() =>
            {
                var conn = factory.CreateConnection();
                IModel channel = conn.CreateModel();
                services.AddSingleton(channel);

                services.AddTransient<IEventBus, EventBusRabbitMq.EventBusRabbitMq>();
            });

            return services;
        }
    }
}
