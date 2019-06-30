using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;
using SchedulingSystem.Extensions;

namespace SchedulingSystem.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(SchedulingDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Course>> GetCoursesForCurrentSemester(int year, int semester, int curriculumId)
        {
            return await SchedulingDbContext.Courses
                                .Where(c => c.DeliveryYear == year && 
                                c.DeliverySemester == semester &&
                                c.CurriculumId == curriculumId)
                                .ToListAsync();
        }

        public async Task<QueryResult<Course>> GetCourses(CourseQuery queryObj)
        {
            var result = new QueryResult<Course>();
            var query = SchedulingDbContext.Courses
                        .Include(c => c.Curriculum)
                        .AsQueryable();

            query = query.ApplyCourseFiltering(queryObj);

            result.TotalItems = await query.CountAsync();
            result.Items = await query.ToListAsync();

            return result;
        }
    }
}