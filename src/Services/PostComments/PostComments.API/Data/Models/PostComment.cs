using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostComments.API.Data.Models
{
    public class PostComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string PostId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; } = DateTimeOffset.UtcNow;
    }
}
