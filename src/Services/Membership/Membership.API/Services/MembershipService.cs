using EventBusRabbitMq;
using Membership.API.DTO;
using Membership.API.Events.Models;
using Sberbank.NetCore;
using Services.Common.UserAccessor;

namespace Membership.API.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly SberbankClient _sber;
        private readonly IEventBus _bus;
        public MembershipService(IUserAccessor userAccessor, SberbankClient sber, IEventBus bus)
        {
            _userAccessor = userAccessor;
            _sber = sber;
            _bus = bus;
        }

        public async Task<string> Buy(AddMembership input)
        {
            var result = await _sber.RegisterOrderAsync(input);

            return result.OrderId;
        }

        public Task IsPayed(string orderId)
        {
            var result = _sber.GetOrderStatusAsync(orderId);
            if(result.IsCompleted)
            {
                _bus.Publish(new MembershipBoughtEvent() { UserId = _userAccessor.GetUserId(), DtEnd = DateTimeOffset.UtcNow.AddMonths(1) });
            }

            return Task.CompletedTask;
        }
    }
}
