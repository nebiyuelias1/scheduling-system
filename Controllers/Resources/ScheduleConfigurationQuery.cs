using SchedulingSystem.Extensions;

namespace SchedulingSystem.Controllers.Resources
{
    public class ScheduleConfigurationQuery : IQueryObject
    {
        public int SectionId { get; set; }
        public bool OnlyClassType { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}