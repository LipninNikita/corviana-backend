using EventBusRabbitMq.Events;
using Membership.API.Data;
using Membership.API.Events.Models;
using Microsoft.EntityFrameworkCore;

namespace Membership.API.Events.Handler
{
    public class MembershipOverdueEventHandler : IEventHandler<MembershipOverdueEvent>
    {
        private readonly AppDbContext _dbContext;

        public MembershipOverdueEventHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(MembershipOverdueEvent @event)
        {
            var membership = await _dbContext.UserMemberships.SingleOrDefaultAsync(x => x.UserId ==  @event.UserId);
            membership.IsValid = false;
            await _dbContext.SaveChangesAsync();
        }
    }
}
