using Services.Common.UserAccessor;
using Subscriptions.API.Data;
using Subscriptions.API.Data.Models;
using System.Data.Entity;

namespace Subscriptions.API.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;

        public SubscriptionService(AppDbContext dbContext, IUserAccessor userAccessor = null)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
        }

        public async Task<IEnumerable<string>> GetUserSubscriptions()
        {
            var userId = _userAccessor.GetUserId();

            var subscriptions = await _dbContext.Subscriptions.Where(x => x.UserId == userId).ToListAsync();

            return subscriptions.Select(x => x.SubscribedTo);
        }

        public async Task<bool> Subscribe(string subscribeToId)
        {
            var userId = _userAccessor.GetUserId();

            var subscription = new Subscription();
            subscription.UserId = userId;
            subscription.SubscribedTo = subscribeToId;

            await _dbContext.Subscriptions.AddAsync(subscription);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
