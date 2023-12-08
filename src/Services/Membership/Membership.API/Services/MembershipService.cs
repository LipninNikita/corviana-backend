using Membership.API.DTO;
using Sberbank.NetCore;
using Services.Common.UserAccessor;

namespace Membership.API.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly SberbankClient _sber;

        public MembershipService(IUserAccessor userAccessor, SberbankClient sber)
        {
            _userAccessor = userAccessor;
            _sber = sber;
        }

        public async Task<string> Buy(AddMembership input)
        {
            var result = await _sber.RegisterOrderAsync(input);

            return result.OrderId;
        }

        public Task IsPayed(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
