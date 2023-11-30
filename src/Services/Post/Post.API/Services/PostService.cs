using EventBusRabbitMq;
using EventBusRabbitMq.Models;
using Post.API.Data;
using Post.API.Data.Models;
using Post.API.DTO;
using Services.Common.UserAccessor;
using System.Data.Entity;

namespace Post.API.Services
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _dbContext;
        private readonly IEventBus _bus;
        private readonly IUserAccessor _userAccessor;

        public PostService(IEventBus bus, AppDbContext context, IUserAccessor userAccessor)
        {
            _bus = bus;
            _dbContext = context;
            _userAccessor = userAccessor;
        }

        public async Task<Guid> AddPost(IEnumerable<IFormFile> files)
        {
            var userId = _userAccessor.GetUserId();

            var post = new Data.Models.Post();
            post.UserId = userId;
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();

            var images = new List<string>();
            foreach (var file in files)
            {
                await using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                var image = Convert.ToBase64String(stream.ToArray());

                images.Add(image);
            }

            var @event = new PostCreatedEvent();
            @event.Images = images;
            @event.UserId = userId;
            @event.PostId = post.Id.ToString();
            _bus.Publish(@event);

            return post.Id;
        }

        public async Task<IEnumerable<PostList>> GetPosts()
        {
            var entities = await _dbContext.Posts.ToArrayAsync();
            var posts = entities.Select(x => (PostList)x);
            return posts;
        }
    }
}
