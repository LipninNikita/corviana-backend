namespace EventBusRabbitMq.Events
{
    public interface IEventHandler<in TEvent>
            where TEvent : Event
    {
        Task<bool> Handle(TEvent @event);
    }
}
