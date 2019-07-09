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

        public static IQueryable<Course> ApplyCourseFiltering(this IQueryable<Course> query, CourseQuery queryObj)
        {
            if (queryObj.DepartmentId.HasValue)
                query = query.Where(c => c.Curriculum.DepartmentId == queryObj.DepartmentId);

            return query;
        }

        public static IQueryable<Section> ApplySectionFilter(this IQueryable<Section> query, SectionQuery queryObj)
        {
            if (queryObj.DepartmentId.HasValue)
                query = query.Where(s => s.Curriculum.DepartmentId == queryObj.DepartmentId);

            if (!queryObj.IncludeInactive)
                query = query.Where(s => s.IsActive);
                
            return query;
        }

        public static IQueryable<Room> ApplyRoomFilter(this IQueryable<Room> query, RoomQuery queryObj)
        {
            if (queryObj.TypeId.HasValue)
                query = query
                        .Where(r => r.Types.Select(t => t.TypeId).Contains(queryObj.TypeId.Value));

            if (queryObj.LabTypeId.HasValue)
                query = query
                        .Where(r => r.Types.Select(t => t.LabTypeId).Contains(queryObj.LabTypeId.Value));

            return query;
        }
    }
}