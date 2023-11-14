using Identity.API.Data.Models;
using Identity.API.DTO.Input;

namespace Identity.API.DTO.Output
{
    public class UserDetails
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public static implicit operator UserDetails(ApplicationUser input)
        {
            var user = new UserDetails()
            {
                Id = input.Id,
                Email = input.Email,
                Name = input.Name,
                LastName = input.LastName,
            };
            return user;
        }
    }
}
