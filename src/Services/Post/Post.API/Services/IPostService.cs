using Post.API.DTO;

namespace Post.API.Services
{
    public interface IPostService
    {
        public Task<IEnumerable<PostList>> GetPosts();
        public Task<Guid> AddPost(IEnumerable<IFormFile> files);
    }
}
