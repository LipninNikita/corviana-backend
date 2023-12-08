using Quest.API.Data.Models;

namespace Quest.API.DTO
{
    public class AddQuest
    {
        public string Name { get; set; }
        public int HardLevel { get; set; }
        public int TimesToFinish { get; set; }
        public QuestLifeTime QuestLifeTime { get; set; }
        public QuestType QuestType { get; set; }
        public DateTimeOffset DtCreated { get; set; } = DateTimeOffset.Now;

        public static implicit operator Data.Models.Quest(AddQuest input)
        {
            var result = new Data.Models.Quest();
            result.Name = input.Name;
            result.TimesToFinish = input.TimesToFinish;
            result.QuestLifeTime = input.QuestLifeTime;
            result.QuestType = input.QuestType;
            result.DtCreated = input.DtCreated;

            return result;
        }
    }
}
