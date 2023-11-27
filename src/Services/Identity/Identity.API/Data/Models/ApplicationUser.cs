using Microsoft.AspNetCore.Identity;

namespace Identity.API.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
