using Question.API.Data.Models;

namespace Question.API.DTO
{
    public class QuestionOutput
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public QuestionLvlEnum Level { get; set; }
        public QuestionTypeEnum Type { get; set; }

        public static implicit operator QuestionOutput(Data.Models.Question input)
        {
            var result = new QuestionOutput();
            result.Id = input.Id;
            result.Content = input.Content;
            result.Level = input.Level;
            result.Type = input.Type;

            return result;
        }
    }
}
