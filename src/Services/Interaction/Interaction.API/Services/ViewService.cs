using Interaction.API.Data;
using Interaction.API.Data.Models;
using System.Data.Entity;

namespace Interaction.API.Services
{
    public class ViewService : IViewService
    {
        private readonly AppDbContext _dbContext;

        public ViewService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddViewInteraction(string postId, string userId)
        {
            var result = new ViewInteraction() { PostId = postId, UserId = userId };
            await _dbContext.ViewInteractions.AddAsync(result);
            await _dbContext.SaveChangesAsync();
            return;
        }

        public async Task<int> GetViewsAmount(string PostId)
        {
            var result = await _dbContext.ViewInteractions.Where(x => x.PostId == PostId).CountAsync();
            return result;
        }
    }
}
