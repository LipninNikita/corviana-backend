using Identity.API.Data.Models;

namespace Identity.API.DTO.Output
{
    public class UsersInfo
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public static implicit operator UsersInfo(ApplicationUser input)
        {
            var user = new UsersInfo()
            {
                Id = input.Id,
                Email = input.Email,
                FullName = $"{input.Name} {input.LastName}",
            };
            return user;
        }
    }
}
