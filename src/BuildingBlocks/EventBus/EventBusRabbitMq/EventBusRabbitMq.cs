using EventBusRabbitMq.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EventBusRabbitMq
{
    //TODO: Use MassTransit instead
    public class EventBusRabbitMq : IEventBus
    {
        private readonly IModel _channel;
        private readonly ILogger<EventBusRabbitMq> _logger;
        private readonly IServiceProvider _serviceProvider;

        public EventBusRabbitMq(IModel channel, ILogger<EventBusRabbitMq> logger, IServiceProvider serviceProvider)
        {
            _channel = channel;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : Event
        {
            var exchangeName = typeof(TEvent).Name;
            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);

            _logger.LogInformation($"Event {exchangeName} published");

            _channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);
            _channel.BasicPublish(exchangeName, "", null, body);
        }

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>
        {
            var exchangeName = typeof(TEvent).Name;
            var queueName = $"{exchangeName}.{typeof(TEventHandler).Name}";

            _channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);
            _channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queueName, exchangeName, "");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var @event = JsonConvert.DeserializeObject<TEvent>(message);

                    _logger.LogInformation($"Event {exchangeName} received at {queueName}");

                    var handler = ActivatorUtilities.GetServiceOrCreateInstance<TEventHandler>(_serviceProvider);
                    var result = await handler.Handle(@event);

                    if (result)
                        _logger.LogInformation($"Event {exchangeName} successfully consumed");
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Event {exchangeName} failed with an error: {ex.Message}");
                    throw;
                }
            };

            _channel.BasicConsume(queueName, autoAck: true, consumer: consumer);
        }
    }
}