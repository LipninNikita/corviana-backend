using Identity.API.Data.Models;

namespace Identity.API.DTO.Output
{
    public class UserDetails
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public static implicit operator UserDetails(ApplicationUser input)
        {
            var user = new UserDetails()
            {
                Id = input.Id,
                Username = input.Username,
                Name = input.Name,
                LastName = input.LastName,
            };
            return user;
        }
    }
}
