using Question.API.Data.Models;

namespace Question.API.DTO
{
    public class AddQuestion
    {
        public string Content { get; set; }
        public QuestionLvlEnum Level { get; set; }
        public QuestionTypeEnum Type { get; set; }
        public bool IsFree { get; set; }

        public static implicit operator Data.Models.Question(AddQuestion input)
        {
            var result = new Data.Models.Question();
            result.Content = input.Content;
            result.Level = input.Level;
            result.Type = input.Type;
            result.IsFree = input.IsFree;

            return result;
        }
    }
}
