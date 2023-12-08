using Sberbank.NetCore.Integration.Implementation.Payment;
using Sberbank.NetCore.Tools;

namespace Membership.API.DTO
{
    public class AddMembership
    {
        public int Amount { get; set; }
        public string ReturnUrl { get; set; }
        public string FailUrl { get; set; }

        public static implicit operator RegisterPaymentParameters(AddMembership input)
        {
            var result = new RegisterPaymentParameters();
            result.Amount = new Price(input.Amount);
            result.ReturnUrl = input.ReturnUrl;
            result.FailUrl = input.FailUrl;

            return result;
        }
    }
}
