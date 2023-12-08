using Answer.API.Events.Models;

namespace Answer.API.DTO
{
    public class AddAnswer
    {
        public int IdQuestion { get; set; }
        public string Content { get; set; }
        public bool IsRight { get; set; }

        public static implicit operator Data.Models.Answer(AddAnswer input)
        {
            var result = new Data.Models.Answer();
            result.Content = input.Content;
            result.IsRight = input.IsRight;
            result.IdQuestion = input.IdQuestion;

            return result;
        }
    }
}
