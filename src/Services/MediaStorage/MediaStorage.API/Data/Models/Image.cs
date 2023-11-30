using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaStorage.API.Data.Models
{
    public class Image
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string PostId { get; set; }
        public string Content { get; set; }
    }
}
