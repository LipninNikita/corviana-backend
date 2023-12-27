namespace Answer.API.DTO
{
    public class AnswerQuestionOutput
    {
        public int QuestionId { get; set; }
        public IEnumerable<Guid>? RightAnswers { get; set; }
        public IEnumerable<Guid>? WrongAnswers { get; set; }
        public bool IsSuccess {  get; set; }
    }
}
