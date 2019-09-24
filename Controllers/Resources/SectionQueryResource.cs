namespace SchedulingSystem.Controllers.Resources
{
    public class SectionQueryResource
    {
        public int? DepartmentId { get; set; }
        public bool IncludeInactive { get; set; }
        public bool IncludeSchedule { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}