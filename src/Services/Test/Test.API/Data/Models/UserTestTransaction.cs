using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.API.Data.Models
{
    public class UserTestTransaction
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public int TestId { get; set; }
        public bool IsFinished { get; set; }
    }
}
