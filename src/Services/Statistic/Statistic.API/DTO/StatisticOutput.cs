namespace Statistic.API.DTO
{
    public class StatisticOutput
    {
        public string UserId { get; set; }
        public int TotalAnswersToday { get; set; }
        public DateTimeOffset Date { get; set; }

        public static implicit operator StatisticOutput(Data.Models.UserStatistic input)
        {
            var result = new StatisticOutput();
            result.UserId = input.UserId;
            result.Date = input.DtCreated;

            return result;
        }
    }
}
