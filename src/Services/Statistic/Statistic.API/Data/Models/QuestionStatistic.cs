using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Statistic.API.Data.Models
{
    public class QuestionStatistic
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int AnswerId { get; set; }
        public string UserId { get; set; }
        public string AnsweredRight { get; set; }
    }
}
