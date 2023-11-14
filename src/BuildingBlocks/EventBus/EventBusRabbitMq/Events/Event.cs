namespace EventBusRabbitMq.Events
{
    public abstract class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateOccurred { get; set; } = DateTime.UtcNow;
    }
}
