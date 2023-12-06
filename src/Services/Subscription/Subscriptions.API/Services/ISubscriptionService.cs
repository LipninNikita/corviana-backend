namespace Subscriptions.API.Services
{
    public interface ISubscriptionService
    {
        public Task<IEnumerable<string>> GetUserSubscriptions();
        public Task<bool> Subscribe(string subscribeToId);
    }
}
