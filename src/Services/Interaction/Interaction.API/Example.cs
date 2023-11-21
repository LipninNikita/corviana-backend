namespace Interaction.API
{
    public interface IExample
    {
        public ExampleOutput ExampleMethod(Example input);
    }
    public class Example
    {
        public int Value1 { get; set; }
        public string Value2 { get; set; }
        public bool Value3 { get; set; }
    }
    public class ExampleOutput
    {
        public string Value1 { get; set; }
        public int Value2 { get; set; }

        public static explicit operator ExampleOutput(Example input)
        {
            var output = new ExampleOutput()
            {
                Value1 = input.Value1.ToString(),
                Value2 = int.Parse(input.Value2),
            };
            return output;
        }
    }
    public class ExampleService : IExample
    {
        public ExampleOutput ExampleMethod(Example input)
        {
            return (ExampleOutput)input;
        }
    }
}
