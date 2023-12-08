namespace Answer.API.DTO
{
    public class AnswerOutput
    {
        public Guid Id { get; set; }
        public int IdQuestion { get; set; }
        public string Content { get; set; }
        public bool IsRight { get; set; }
    }
}
