using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class SaveInstructorResource
    {
        public int DepartmentId { get; set; }
        public string UserId { get; set; }
    }
}