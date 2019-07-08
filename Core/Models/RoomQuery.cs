using SchedulingSystem.Extensions;

namespace SchedulingSystem.Core.Models
{
    public class RoomQuery : IQueryObject
    {
        public int? TypeId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}