namespace SchedulingSystem.Controllers.Resources
{
    public class CourseOfferingQueryResource
    {
        public int? DepartmentId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}