namespace Test.API.DTO
{
    public class AddTest
    {
        public string Name { get; set; }
        public IEnumerable<string> Questions { get; set; }

        public static implicit operator Data.Models.Test(AddTest input)
        {
            var result = new Data.Models.Test();
            result.Name = input.Name;
            result.QuestionIds = string.Join(";", input.Questions);

            return result;
        }
    }
}
