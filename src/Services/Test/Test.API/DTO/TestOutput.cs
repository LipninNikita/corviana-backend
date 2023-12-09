namespace Test.API.DTO
{
    public class TestOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuestionIds { get; set; }

        public static implicit operator TestOutput(Data.Models.Test inpuit)
        {
            var result = new TestOutput();
            result.Id = inpuit.Id;
            result.Name = inpuit.Name;
            result.QuestionIds = inpuit.QuestionIds;

            return result;
        }
    }
}
