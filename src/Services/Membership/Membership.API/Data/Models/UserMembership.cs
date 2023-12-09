using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.API.Data.Models
{
    public class UserMembership
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public bool IsValid { get; set; }
        public DateTimeOffset DtStart { get; set; }
    }
}
