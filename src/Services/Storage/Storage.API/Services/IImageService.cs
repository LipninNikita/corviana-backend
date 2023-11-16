﻿using Microsoft.AspNetCore.Http;

namespace Storage.API.Services
{
    public interface IImageService
    {
        public Task UploadFile(IFormFile file, Guid PostId);
        public Task<IEnumerable<string>> GetImages(Guid PostId);
    }
}