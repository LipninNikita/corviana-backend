using Microsoft.EntityFrameworkCore;
using PostComments.API.Data;
using PostComments.API.Data.Models;
using PostComments.API.DTO;
using Services.Common.UserAccessor;

namespace PostComments.API.Services
{
    public class PostCommentService : IPostCommentService
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;

        public PostCommentService(AppDbContext dbContext, IUserAccessor userAccessor)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
        }

        public async Task<Guid> AddPostComment(AddPostComment input)
        {
            PostComment model = input;
            model.UserId = _userAccessor.GetUserId();

            _dbContext.Add(model);
            await _dbContext.SaveChangesAsync();

            return model.Id;
        }

        public async Task<IEnumerable<PostCommentList>> GetPostComments(string postId)
        {
            var comments = await _dbContext.PostComments.Where(x => x.PostId == postId).ToListAsync();
            return comments.Select(x => (PostCommentList)x);
        }
    }
}
