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
        private static readonly List<string> HotQuestNames = new() { "Race Against Your Phone Battery", "Panic at the Last-Minute Shopping Spree", "Mission: FOMO Edition", "The Fast and the Curious Cats on TikTok", "Express Lane Adventure", "Turbo Boost Quest", "Swift Swag Sprint", "Rush Hour Rush", "Hasty Hilariousness", "Urgent Unicorn Selfie Safari" };
        private static readonly List<string> DailyQuestNames = new() { "The Never-Ending Snapchat Streak", "The Perpetual Pizza Party", "Daily Dose of Drama", "Endless Emoji Endeavor", "Eternal TikTok Challenge", "Quirky Quest for the Ultimate Meme", "Unceasing Upside-down Challenge", "Infinite Instagram Story", "Constant Fortnite Conundrum", "The Legendary Late-night Taco Run" };
        private static readonly List<string> WeeklyQuestNames = new() { "The Extended Netflix Binge", "Seven-day Sleepover", "The Prolonged Procrastination Party", "The Long-haul Twitch Stream", "Sustained Social Media Shenanigans", "Protracted Video Game Marathon", "Drawn-out DIY TikTok Projects", "Week-long Wacky YouTube Challenges", "The Never-ending Group Chat Banter", "The Lengthy Lollygagging LAN Party" };

        public static QuestData GenerateRandomQuest(int LifeTime, int Type)
        {
            var level = new Random().Next(0, 1);
            var quest = new QuestData();
            quest.QuestLifeTime = LifeTime;
            quest.QuestType = Type;
            quest.Level = level;
            quest.TimesToFinish = new Random().Next(1 * (level + 1), 4 * (level + 1));

            if (Type == 0)
                quest.Name = GetRandomName(WeeklyQuestNames);
            else if (Type == 1)
                quest.Name = GetRandomName(DailyQuestNames);
            else if (Type == 2)
                quest.Name = GetRandomName(HotQuestNames);

            return quest;
        }

        private static string GetRandomName(List<string> arr)
        {
            var rnd = new Random();
            return arr[rnd.Next(0, arr.Count() - 1)];
        }
    }
}
