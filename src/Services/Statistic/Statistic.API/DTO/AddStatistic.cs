namespace Statistic.API.DTO
{
    public class AddStatistic
    {
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public bool IsRightAnswered { get; set; }
    }
}
