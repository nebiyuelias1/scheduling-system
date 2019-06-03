using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class InstructorResource
    {
        public int Id { get; set; }
        public DepartmentResource Department { get; set; }
        public int DepartmentId { get; set; }
        public AppUserResource User { get; set; }
        public string UserId { get; set; }
    }
}