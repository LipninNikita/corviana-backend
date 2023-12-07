using Question.API.Data.Models;

namespace Question.API.DTO
{
    public class UpdateQuestion
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public QuestionLvlEnum Level { get; set; }
        public QuestionTypeEnum Type { get; set; }

        public static implicit operator Data.Models.Question(UpdateQuestion input)
        {
            var result = new Data.Models.Question();
            result.Id = input.Id;
            result.Content = input.Content;
            result.Level = input.Level;
            result.Type = input.Type;

            return result;
        }
    }
}
