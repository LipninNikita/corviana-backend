using EventBusRabbitMq.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest.BackgroundTasks.Events.Models
{
    public class QuestCreatedEvent : Event
    {
        public Guid QuestId { get; set; }
        public string Name { get; set; }
        public int TimesToFinish { get; set; } = 0;
        public string IdUser { get; set; }
        public int Level { get; set; }
        public int QuestLifeTime { get; set; }
        public int QuestType { get; set; }
        public DateTimeOffset DtCreated { get; set; } = DateTimeOffset.UtcNow;

        public QuestCreatedEvent(Guid questId, string name, int timesToFinish, string idUser, int level, int questLifeTime, int questType, DateTimeOffset dtCreated)
        {
            QuestId = questId;
            Name = name;
            TimesToFinish = timesToFinish;
            IdUser = idUser;
            Level = level;
            QuestLifeTime = questLifeTime;
            QuestType = questType;
            DtCreated = dtCreated;
        }
    }
}
