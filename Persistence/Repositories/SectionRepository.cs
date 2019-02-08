using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(DbContext context) : base(context)
        {
        }

        public async Task<Section> GetSectionWithCourseOfferings(int sectionId, int semesterId)
        {
            return await SchedulingDbContext.Sections
                            .Include(s => s.Department)
                            .Include(s => s.CourseOfferings)
                                .ThenInclude(c => c.Course)
                            .SingleOrDefaultAsync(s => s.Id == sectionId && s.CourseOfferings.Select(c => c.AcademicSemesterId).Contains(semesterId));
        }
    }
}