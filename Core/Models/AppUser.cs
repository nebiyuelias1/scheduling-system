using Microsoft.AspNetCore.Identity;

namespace SchedulingSystem.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
    }
}