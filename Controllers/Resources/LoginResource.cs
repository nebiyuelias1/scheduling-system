using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class LoginResource
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}