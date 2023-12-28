namespace Answer.API.DTO
{
    public class UpdateAnswer
    {
        public Guid Id { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public bool IsRight { get; set; }

        public static implicit operator Data.Models.Answer(UpdateAnswer input)
        {
            var result = new Data.Models.Answer();
            result.Id = input.Id;
            result.Content = input.Content;
            result.IsRight = input.IsRight;
            result.QuestionId = input.QuestionId;

            return result;
        }
    }
}
