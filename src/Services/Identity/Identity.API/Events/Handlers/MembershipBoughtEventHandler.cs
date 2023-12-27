using EventBusRabbitMq.Events;
using Identity.API.Events.Models;
using Identity.API.Services.Login;
using Identity.Data;
using System.ComponentModel.Design;

namespace Identity.API.Events.Handlers
{
    public class MembershipBoughtEventHandler : IEventHandler<MembershipBoughtEvent>
    {
        private readonly IAuthService _authService;
        public MembershipBoughtEventHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<bool> Handle(MembershipBoughtEvent @event)
        {
            await _authService.AddToTole("IsMember", @event.UserId);

            return true;
        }
    }
}
