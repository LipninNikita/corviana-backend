using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Statistic.API.Data.Models
{
    public class QuestionStatistic
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int QuestionId { get; set; }
        public string? UserId { get; set; }
        public bool IsRightAnswered { get; set; }
        public DateTimeOffset DtCreated { get; set; } = DateTimeOffset.UtcNow;
    }
}
