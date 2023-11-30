using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Post.API.Data.Models
{
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset DateTimeUpdated { get; set; } = DateTimeOffset.UtcNow;
        public string UserId { get; set; }
    }
}
