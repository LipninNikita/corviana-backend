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

            await _dbContext.UserMemberships.AddAsync(new Data.Models.UserMembership() { OrderId = result.OrderId, IsValid = false, DtStart = DateTimeOffset.UtcNow, UserId = _userAccessor.GetUserId() });
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<MemberInfo> GetMembershipInfo()
        {
            if (!_userAccessor.IsMember())
                throw new BadHttpRequestException("Not a mbmer");

            var membership = await _dbContext.UserMemberships.Where(x => x.UserId == _userAccessor.GetUserId()).FirstOrDefaultAsync();
            return new MemberInfo() { DtStart = membership.DtStart, DtEnd = membership.DtStart.AddMonths(1) };
        }

        public async Task IsPayed()
        {
            var userId = _userAccessor.GetUserId();
            var membership = await _dbContext.UserMemberships.FirstOrDefaultAsync(x => x.UserId == userId);
            var result = _sber.GetOrderStatusAsync(membership.OrderId);
            if (result.IsCompleted)
            {
                _bus.Publish(new MembershipBoughtEvent() { UserId = userId, DtEnd = DateTimeOffset.UtcNow.AddMonths(1) });
                membership.IsValid = true;
                membership.DtStart = DateTimeOffset.UtcNow;
            }

            _dbContext.UserMemberships.Update(membership);
            await _dbContext.SaveChangesAsync();
        }
    }
}
