using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Answer.API.DTO
{
    public class AnswerOutput
    {
        public Guid Id { get; set; }
        public int IdQuestion { get; set; }
        public string Content { get; set; }
        public bool IsRight { get; set; }

        public static implicit operator AnswerOutput(Data.Models.Answer input) 
        {
            var result = new AnswerOutput();
            result.Id = input.Id;
            result.IdQuestion = input.IdQuestion;
            result.Content = input.Content;
            result.IsRight = input.IsRight;

            return result;
        }
    }
}
