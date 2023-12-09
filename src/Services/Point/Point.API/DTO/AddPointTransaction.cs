namespace Point.API.DTO
{
    public class AddPointTransaction
    {
        public string UserId { get; set; }
        public int Amount { get; set; }

        public static implicit operator Data.Models.PointTransaction(AddPointTransaction input)
        {
            var result = new Data.Models.PointTransaction();
            result.UserId = input.UserId;
            result.Amount = input.Amount;

            return result;
        }
    }
}
