using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quest.API.Data.Models
{
    public class Quest
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TimesToFinish {  get; set; }
        public string IdUser { get; set; }
        public bool IsFinished { get; set; }
        public QuestLifeTime QuestLifeTime { get; set; }
        public QuestType QuestType { get; set; }
        public DateTimeOffset DtCreated { get; set; } = DateTimeOffset.UtcNow;
    }
}
