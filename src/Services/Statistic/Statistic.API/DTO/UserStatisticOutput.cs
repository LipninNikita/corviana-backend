using Statistic.API.Data.Models;

namespace Statistic.API.DTO
{
    public class UserStatisticOutput
    {
        public string UserId { get; set; }
        public int TotalAnswersToday { get; set; }
        public DateTimeOffset Date { get; set; }

        public static implicit operator UserStatisticOutput(QuestionStatistic input)
        {
            var result = new UserStatisticOutput();
            result.UserId = input.UserId;
            result.Date = input.DtCreated.Date;

            return result;
        }
    }
}
