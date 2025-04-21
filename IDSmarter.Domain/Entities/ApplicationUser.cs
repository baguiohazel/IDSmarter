using Microsoft.AspNetCore.Identity;

namespace IDSmarter.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; } 
    }
}
