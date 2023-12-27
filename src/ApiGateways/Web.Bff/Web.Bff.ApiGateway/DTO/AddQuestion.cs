namespace Web.Bff.ApiGateway.DTO
{
    public class AddQuestion
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Level { get; set; }
        public int Type { get; set; }
        public bool IsFree { get; set; }
        public string Hint { get; set; }

        public IEnumerable<AddAnswer> Answers { get; set; }
    }
}
