namespace Test.API.DTO
{
    public class TestArrOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuestionIds { get; set; }
        public bool IsFree { get; set; }

        public static implicit operator TestArrOutput(Data.Models.Test inpuit)
        {
            var result = new TestArrOutput();
            result.Id = inpuit.Id;
            result.Name = inpuit.Name;
            result.QuestionIds = inpuit.QuestionIds;
            result.IsFree = inpuit.IsFree;

            return result;
        }
    }
}
