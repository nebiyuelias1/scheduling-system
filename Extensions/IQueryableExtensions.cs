using System.Linq;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<Instructor> ApplyFiltering(this IQueryable<Instructor> query, InstructorQuery queryObj)
        {
            if (queryObj.DepartmentId.HasValue)
                query = query.Where(i => i.User.DepartmentId == queryObj.DepartmentId);

            if (queryObj.OnlyActive)
                query = query.Where(i => i.IsActive);

            return query;
        }
    }
}