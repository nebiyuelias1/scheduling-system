using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class CourseOfferingRepository : Repository<CourseOffering>, ICourseOfferingRepository
    {
        public CourseOfferingRepository(DbContext context) : base(context)
        {
        }

        public bool DoesCourseOfferingExist(int currentSemesterId, int courseId, int sectionId)
        {
            return SchedulingDbContext.CourseOfferings.Any(co =>
                                                co.AcademicSemesterId == currentSemesterId &&
                                                co.CourseId == courseId &&
                                                co.SectionId == sectionId);
        }

        public Task<CourseOffering> GetCourseOffering(int id)
        {
            return SchedulingDbContext.CourseOfferings
                .Include(c => c.Course)
                .Include(c => c.Section)
                .Include(c => c.Instructors)
                    .ThenInclude(i => i.Instructor)
                        .ThenInclude(t => t.User)
                            .ThenInclude(u => u.Contact)
                .Include(c => c.Instructors)
                    .ThenInclude(i => i.Type)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CourseOffering>> GetCourseOfferingsWithRelatedData(int currentSemesterId)
        {
            return await SchedulingDbContext.CourseOfferings
                                    .Include(co => co.Instructors)
                                        .ThenInclude(i => i.Instructor)
                                    .Include(co => co.Instructors)
                                        .ThenInclude(i => i.Type)
                                    .Include(co => co.Course)
                                    .Include(co => co.Section)
                                    .Where(co => co.AcademicSemesterId == currentSemesterId)
                                    .ToListAsync();
        }
    }
}