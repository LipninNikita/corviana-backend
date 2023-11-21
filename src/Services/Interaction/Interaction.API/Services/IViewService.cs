namespace Interaction.API.Services
{
    public interface IViewService
    {
        public Task AddViewInteraction(string postId, string userId);
        public Task<int> GetViewsAmount(string PostId);
    }
}
