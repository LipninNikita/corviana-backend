using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest.BackgroundTasks.Models
{
    public class QuestData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TimesToFinish { get; set; } = 0;
        public string IdUser { get; set; }
        public int Level { get; set; }
        public int QuestLifeTime { get; set; }
        public int QuestType { get; set; }
        public DateTimeOffset DtCreated { get; set; } = DateTimeOffset.UtcNow;
    }
}
