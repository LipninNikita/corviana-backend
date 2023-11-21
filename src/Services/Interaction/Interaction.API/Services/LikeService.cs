using Interaction.API.Data;
using Interaction.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Interaction.API.Services
{
    public class LikeService : ILikeService
    {
        private readonly AppDbContext _dbContext;

        public LikeService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddLikeInteraction(string postId, string userId)
        {
            var result = new LikeInteraction() { PostId = postId, UserId = userId };
            _dbContext.LikeInteractions.Add(result);
            await _dbContext.SaveChangesAsync();
            return;
        }

        public async Task<int> GetLikesAmount(string PostId)
        {
            var result = await _dbContext.LikeInteractions.Where(x => x.PostId == PostId).CountAsync();
            return result;
        }

        public async Task RemoveLikeInteraction(string postId, string userId)
        {
            var result = await _dbContext.LikeInteractions.Where(x => x.PostId == postId).Where(x => x.UserId == userId).ExecuteDeleteAsync();
            return;
        }
    }
}
