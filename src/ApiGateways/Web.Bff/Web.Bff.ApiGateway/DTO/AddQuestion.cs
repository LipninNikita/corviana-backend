namespace Web.Bff.ApiGateway.DTO
{
    public class AddQuestion
    {
        public string Content { get; set; }
        public int Level { get; set; }
        public int Type { get; set; }
        public IEnumerable<AddAnswer> Answers { get; set; }
    }
}
