using PostComments.API.DTO;

namespace PostComments.API.Services
{
    public interface IPostCommentService
    {
        public Task<IEnumerable<PostCommentList>> GetPostComments(string postId);
        public Task<Guid> AddPostComment(AddPostComment input);
    }
}
