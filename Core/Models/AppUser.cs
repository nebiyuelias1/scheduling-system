using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SchedulingSystem.Core.Models
{
    public class AppUser : IdentityUser
    {
        public Contact Contact { get; set; }
        public int? ContactId { get; set; }
    }
}