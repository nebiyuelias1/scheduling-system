namespace SchedulingSystem.Controllers.Resources
{
    public class DepartmentResource
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int CollegeId { get; set; }
        
        public DeptHeadResource DepartmentHead { get; set; }
    }
}