using Membership.API.DTO;

namespace Membership.API.Services
{
    public interface IMembershipService
    {
        public Task<RegisterOutput> Buy(AddMembership input);
        public Task IsPayed(string orderId);
        public Task<MemberInfo> GetMembershipInfo();
    }
}
