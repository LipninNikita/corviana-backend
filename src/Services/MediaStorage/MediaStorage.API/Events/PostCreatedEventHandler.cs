using EventBusRabbitMq.Events;
using EventBusRabbitMq.Models;
using MediaStorage.API.Services;

namespace MediaStorage.API.Events
{
    public class PostCreatedEventHandler : IEventHandler<PostCreatedEvent>
    {
        private readonly IImageService _imageService;

        public PostCreatedEventHandler(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task Handle(PostCreatedEvent @event)
        {
            foreach(var image in @event.Images)
            {
                await _imageService.UploadFile(image, @event.PostId);
            }
            return;
        }
    }
}
