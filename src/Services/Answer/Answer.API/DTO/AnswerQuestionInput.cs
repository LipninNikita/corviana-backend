namespace Answer.API.DTO
{
    public class AnswerQuestionInput
    {
        public int QuestionId { get; set; }
        public IEnumerable<Guid> SelectedAnswers { get; set; }
    }
}
