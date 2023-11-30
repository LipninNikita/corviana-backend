using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Net.Sockets;

namespace EventBusRabbitMq
{
    public static class EventBusDependencyInjection
    {
        public static WebApplicationBuilder AddEventBus(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetValue<string>("RabbitMQ");

            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://" + connectionString);

            var policy = RetryPolicy.Handle<SocketException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(10, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            policy.Execute(() =>
            {
                var conn = factory.CreateConnection();
                IModel channel = conn.CreateModel();
                builder.Services.AddSingleton(channel);

                builder.Services.AddTransient<IEventBus, EventBusRabbitMq>();
            });

            return builder;
        }
    }
}
