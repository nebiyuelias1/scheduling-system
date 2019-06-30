using System.Collections.Generic;
using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<QueryResult<Course>> GetCourses(CourseQuery filter);
        Task<IEnumerable<Course>> GetCoursesForCurrentSemester(int year, int semester, int curriculumId);
    }
}