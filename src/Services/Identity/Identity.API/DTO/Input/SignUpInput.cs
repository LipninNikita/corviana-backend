using Identity.API.Data.Models;

namespace Identity.API.DTO.Input
{
    public class SignUpInput
    {
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }

        public static implicit operator ApplicationUser(SignUpInput model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
                LastName = model.SecondName,
                Name = model.FirstName
            };
            return user;
        }
    }
}
