using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Question.API.Data.Models
{
    public class Question
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public QuestionLvlEnum Level { get; set; }
        public QuestionTypeEnum Type { get; set; }
        public bool IsFree { get; set; } = false;
        public string Hint { get; set; }
    }
}
