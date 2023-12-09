using EventBusRabbitMq;
using Membership.API.Data;
using Membership.API.DTO;
using Membership.API.Events.Models;
using Microsoft.EntityFrameworkCore;
using Sberbank.NetCore;
using Services.Common.UserAccessor;

namespace Membership.API.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly SberbankClient _sber;
        private readonly IEventBus _bus;
        private readonly AppDbContext _dbContext;
        public MembershipService(IUserAccessor userAccessor, SberbankClient sber, IEventBus bus, AppDbContext dbContext)
        {
            _userAccessor = userAccessor;
            _sber = sber;
            _bus = bus;
            _dbContext = dbContext;
        }

        public async Task<RegisterOutput> Buy(AddMembership input)
        {
            var result = await _sber.RegisterOrderAsync(input);

            return result;
        }

        public async Task<MemberInfo> GetMembershipInfo()
        {
            if (!_userAccessor.IsMember())
                throw new BadHttpRequestException("Not a mbmer");

            var membership = await _dbContext.UserMemberships.Where(x => x.UserId == _userAccessor.GetUserId()).FirstOrDefaultAsync();
            return new MemberInfo() { DtStart = membership.DtStart, DtEnd = membership.DtStart.AddMonths(1) };
        }

        public async Task IsPayed(string orderId)
        {
            var result = _sber.GetOrderStatusAsync(orderId);
            if(result.IsCompleted)
            {
                _bus.Publish(new MembershipBoughtEvent() { UserId = _userAccessor.GetUserId(), DtEnd = DateTimeOffset.UtcNow.AddMonths(1) });
            }

            await _dbContext.UserMemberships.AddAsync(new Data.Models.UserMembership() { IsValid = true , DtStart = DateTimeOffset.UtcNow, UserId = _userAccessor.GetUserId()});
            await _dbContext.SaveChangesAsync();
        }
    }
}
