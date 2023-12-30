using EventBusRabbitMq.Events;

namespace EventBusRabbitMq
{
    public interface IEventBus
    {
        Task Publish<TEvent>(TEvent @event)
            where TEvent : Event;

        void Subscribe<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>;
    }
}
