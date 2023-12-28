using Quest.BackgroundTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest.BackgroundTasks.Extensions
{
    public static class Extension
    {
        private static readonly List<string> HotQuestNames = new() { "You better hurry" };
        private static readonly List<string> DailyQuestNames = new() { "It’s gonna be a long day" };
        private static readonly List<string> WeeklyQuestNames = new() { "Plenty of time, but will you make it?" };

        public static QuestData GenerateRandomQuest(int LifeTime, int Type)
        {
            var level = new Random().Next(0, 1);
            var quest = new QuestData();
            quest.QuestLifeTime = LifeTime;
            quest.QuestType = Type;
            quest.Level = level;
            quest.TimesToFinish = new Random().Next(1 * (level + 1), 4 * (level + 1));

            var rnd = new Random();
            var randomName = "";
            if (Type == 0)
            {
                randomName = WeeklyQuestNames[rnd.Next(0, HotQuestNames.Count() - 1)];
                quest.Name = randomName;
            }
            else if (Type == 1)
            {
                randomName = DailyQuestNames[rnd.Next(0, HotQuestNames.Count() - 1)];
                quest.Name = randomName;
            }
            else if (Type == 2)
            {
                randomName = HotQuestNames[rnd.Next(0, HotQuestNames.Count() - 1)];
                quest.Name = randomName;
            }

            return quest;
        }
    }
}
