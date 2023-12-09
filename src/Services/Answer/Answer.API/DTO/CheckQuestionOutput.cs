namespace Answer.API.DTO
{
    public class CheckQuestionOutput
    {
        public int IdQuestion { get; set; }
        public IEnumerable<Guid>? RightAnswers { get; set; }
        public IEnumerable<Guid>? WrongAnswers { get; set; }
        public string Annotation { get; set; }
    }
}
