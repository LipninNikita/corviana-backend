using Identity.API.Data.Models;

namespace Identity.API.DTO.Input
{
    public class SignUpInput
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }

        public static implicit operator ApplicationUser(SignUpInput model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
                LastName = model.LastName,
                Name = model.Name,
                Username = model.Username,
            };
            return user;
        }
    }
}
