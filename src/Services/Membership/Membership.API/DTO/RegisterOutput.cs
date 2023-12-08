using Sberbank.NetCore.Responses;

namespace Membership.API.DTO
{
    public class RegisterOutput
    {
        public string OrderId { get; set; }
        public string FormUrl { get; set; }

        public static implicit operator RegisterOutput(RegisterOrderResponse input)
        {
            var result = new RegisterOutput();
            result.OrderId = input.OrderId;
            result.FormUrl = input.FormUrl;

            return result;
        }
    }
}
