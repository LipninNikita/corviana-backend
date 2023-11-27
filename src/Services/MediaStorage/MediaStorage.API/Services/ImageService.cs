using MediaStorage.API.Data;
using Microsoft.EntityFrameworkCore;

namespace MediaStorage.API.Services
{
    public class ImageService : IImageService
    {
        private readonly AppDbContext _dbContext;

        public ImageService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> GetImages(Guid PostId)
        {
            var entities = await _dbContext.Images.Where(x => x.PostId == PostId).ToListAsync();
            return entities.Select(x => x.Content);
        }

        public async Task UploadFile(IFormFile file, Guid PostId)
        {
            await using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var content = Convert.ToBase64String(stream.ToArray());
            await _dbContext.Images.AddAsync(new Data.Models.Image() { Content = content, PostId = PostId });
            await _dbContext.SaveChangesAsync();
        }
    }
}
