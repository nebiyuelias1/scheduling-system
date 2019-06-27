using SchedulingSystem.Extensions;

namespace SchedulingSystem.Core.Models
{
    public class SectionQuery : IQueryObject
    {
        public int? DepartmentId { get; set; }
        public bool IncludeInactive { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}