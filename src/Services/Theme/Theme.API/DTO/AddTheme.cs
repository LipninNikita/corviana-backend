namespace Theme.API.DTO
{
    public class AddTheme
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public static implicit operator Data.Models.Theme(AddTheme input)
        {
            var result = new Data.Models.Theme();
            result.Name = input.Name;
            result.Content = input.Content;

            return result;
        }
    }
}
