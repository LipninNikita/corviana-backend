using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interaction.API.Data.Models
{
    public class LikeInteraction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string PostId { get; set; }
        public string UserId { get; set; }
    }
}
