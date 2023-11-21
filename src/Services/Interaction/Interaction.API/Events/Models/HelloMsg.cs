using EventBusRabbitMq.Events;

namespace Interaction.API.Events.Models
{
    public class HelloMsg : Event
    {
        public string msg = "Hello, nigga";
    }
}
