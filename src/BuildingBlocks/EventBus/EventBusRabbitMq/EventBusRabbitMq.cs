using EventBusRabbitMq.Events;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EventBusRabbitMq
{
    //TODO: Use MassTransit instead
    //Subscribe should be register before building app
    public class EventBusRabbitMq : IEventBus
    {
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceCollection _services;

        public EventBusRabbitMq(IModel channel, IServiceProvider serviceProvider, IServiceCollection services)
        {
            _channel = channel;
            _serviceProvider = serviceProvider;
            _services = services;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : Event
        {
            var exchangeName = typeof(TEvent).Name;
            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);
            _channel.BasicPublish(exchangeName, "", null, body);
        }

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>
        {
            _services.AddTransient(typeof(IEventHandler<>), typeof(TEventHandler));

            var exchangeName = typeof(TEvent).Name;
            var queueName = $"{exchangeName}.{typeof(TEventHandler).Name}";

            _channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);
            _channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queueName, exchangeName, "");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var @event = JsonConvert.DeserializeObject<TEvent>(message);

                using var scope = _serviceProvider.CreateScope();
                var handler = (TEventHandler)scope.ServiceProvider.GetRequiredService(typeof(TEventHandler));
                await handler.Handle(@event);
                scope.Dispose();
            };

            _channel.BasicConsume(queueName, autoAck: true, consumer: consumer);
        }
    }
}