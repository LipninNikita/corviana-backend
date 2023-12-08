using Identity.API.Data.Models;

namespace Identity.API.DTO.Output
{
    public class UsersInfo
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }

        public static implicit operator UsersInfo(ApplicationUser input)
        {
            var user = new UsersInfo()
            {
                Id = input.Id,
                Username = input.Username,
                FullName = $"{input.Name} {input.LastName}",
            };
            return user;
        }
    }
}
