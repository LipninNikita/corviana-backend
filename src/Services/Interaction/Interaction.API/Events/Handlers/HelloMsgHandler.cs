using EventBusRabbitMq.Events;
using Interaction.API.Data;
using Interaction.API.Events.Models;
using Microsoft.EntityFrameworkCore;

namespace Interaction.API.Events.Handlers
{
    public class HelloMsgHandler : IEventHandler<HelloMsg>
    {
        private readonly AppDbContext _appDbContext;

        public HelloMsgHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Handle(HelloMsg @event)
        {
            var result = await _appDbContext.LikeInteractions.ToArrayAsync();
            Console.WriteLine(@event.msg);
        }
    }
}
