using EventBusRabbitMq.Events;
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

        public EventBusRabbitMq(IModel channel)
        {
            _channel = channel;
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
            var exchangeName = typeof(TEvent).Name;
            var queueName = $"{exchangeName}.{typeof(TEventHandler).Name}";

            _channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);
            _channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queueName, exchangeName, "");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var @event = JsonConvert.DeserializeObject<TEvent>(message);
                var handler = Activator.CreateInstance<TEventHandler>(); 
                handler.Handle(@event);
            };

            _channel.BasicConsume(queueName, autoAck: true, consumer: consumer);
        }
    }
}