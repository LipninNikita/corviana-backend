using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Answer.API.Data.Models
{
    public class Answer
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int IdQuestion { get; set; }
        public string Content { get; set; }
        public bool IsRight { get; set; }
    }
}
