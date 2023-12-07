using EventBusRabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Common.UserAccessor;

namespace Web.Bff.ApiGateway.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IEventBus _bus;
        private readonly IUserAccessor _userAccessor;

        public PostsController(IEventBus bus, IUserAccessor userAccessor)
        {
            _bus = bus;
            _userAccessor = userAccessor;
        }


    }
}
