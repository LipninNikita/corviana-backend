namespace Interaction.API.Services
{
    public interface ILikeService
    {
        public Task AddLikeInteraction(string postId, string userId);
        public Task RemoveLikeInteraction(string postId, string userId);
        public Task<int> GetLikesAmount(string PostId);
    }
}
