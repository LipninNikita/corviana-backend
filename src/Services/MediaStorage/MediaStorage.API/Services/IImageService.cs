namespace MediaStorage.API.Services
{
    public interface IImageService
    {
        public Task UploadFile(IFormFile file, string PostId);
        public Task UploadFile(string file, string PostId);
        public Task<IEnumerable<string>> GetImages(string PostId);
    }
}
