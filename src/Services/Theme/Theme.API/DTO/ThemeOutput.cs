namespace Theme.API.DTO
{
    public class ThemeOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public static implicit operator ThemeOutput(Data.Models.Theme input)
        {
            var result = new ThemeOutput();
            result.Id = input.Id;
            result.Name = input.Name;
            result.Content = input.Content;

            return result;
        }
    }
}
