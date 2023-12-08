namespace Theme.API.DTO
{
    public class UpdateTheme
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Content { get; set; }

        public static implicit operator Data.Models.Theme(UpdateTheme input)
        {
            var result = new Data.Models.Theme();
            result.Id = input.Id;
            result.Name = input.Name;
            result.Content = input.Content;

            return result;
        }
    }
}
