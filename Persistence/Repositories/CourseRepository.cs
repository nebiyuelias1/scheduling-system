using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(SchedulingDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Course>> GetCoursesWithCurriculum()
        {
            return await SchedulingDbContext.Courses
                        .Include(c => c.Curriculum)
                        .ToListAsync();
        }
    }
}