using Answer.API.Events.Models;

namespace Answer.API.DTO
{
    public class AddAnswer
    {
        public required int IdQuestion { get; set; }
        public required string Content { get; set; }
        public required bool IsRight { get; set; }

        public static implicit operator Data.Models.Answer(AddAnswer input)
        {
            var result = new Data.Models.Answer();
            result.Content = input.Content;
            result.IsRight = input.IsRight;
            result.QuestionId = input.IdQuestion;

            return result;
        }
    }
}
