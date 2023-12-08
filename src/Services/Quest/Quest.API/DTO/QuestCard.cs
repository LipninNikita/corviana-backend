using Quest.API.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Quest.API.DTO
{
    public class QuestCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TimesToFinish { get; set; }
        public string IdUser { get; set; }
        public bool IsFinished { get; set; }
        public QuestLifeTime QuestLifeTime { get; set; }
        public QuestType QuestType { get; set; }
        public DateTimeOffset DtEnd { get; set; }

        public static implicit operator QuestCard(Data.Models.Quest input)
        {
            var result = new QuestCard();
            result.Id = input.Id;
            result.Name = input.Name;
            result.TimesToFinish = input.TimesToFinish;
            result.IdUser = input.IdUser;
            result.IsFinished = input.IsFinished;
            result.QuestLifeTime = input.QuestLifeTime;
            result.QuestType = input.QuestType;
            result.DtEnd = input.DtCreated.AddDays(1).Date;

            return result;
        }
    }
}
