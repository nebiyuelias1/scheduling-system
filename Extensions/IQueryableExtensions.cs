using System.Linq;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<Instructor> ApplyFiltering(this IQueryable<Instructor> query, InstructorQuery queryObj)
        {
            if (queryObj.DepartmentId.HasValue)
                query = query.Where(i => i.User.Contact.DepartmentId == queryObj.DepartmentId);

            if (queryObj.CollegeId.HasValue) 
                query = query.Where(i => i.User.Contact.Department.CollegeId == queryObj.CollegeId);
                
            if (queryObj.OnlyActive)
                query = query.Where(i => i.IsActive);

            return query;
        }

        public static IQueryable<Curriculum> ApplyCurriculumFiltering(this IQueryable<Curriculum> query, CurriculumQuery queryObj)
        {
            if (queryObj.DepartmentId.HasValue)
                query = query.Where(c => c.DepartmentId == queryObj.DepartmentId);

            return query;
        }
    }
}