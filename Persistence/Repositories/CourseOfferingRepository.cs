using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;
using SchedulingSystem.Extensions;

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
                .Include(co => co.Rooms)
                    .ThenInclude(r => r.Room)
                .Include(co => co.Rooms)
                    .ThenInclude(r => r.Type)
                .Include(co => co.Rooms)
                    .ThenInclude(r => r.LabType)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<QueryResult<CourseOffering>> GetCourseOfferingsWithRelatedData(CourseOfferingQuery queryObj)
        {
            var result = new QueryResult<CourseOffering>();

            var query = SchedulingDbContext.CourseOfferings
                            .Include(co => co.Instructors)
                                .ThenInclude(i => i.Instructor)
                            .Include(co => co.Instructors)
                                .ThenInclude(i => i.Type)
                            .Include(co => co.Course)
                            .Include(co => co.Section)
                                .ThenInclude(s => s.Curriculum)
                            .Include(co => co.Rooms)
                                .ThenInclude(r => r.Type)
                            .Include(co => co.Rooms)
                                .ThenInclude(r => r.LabType)
                            .Include(co => co.Section)
                            .AsQueryable();

            query = query.ApplyCourseOfferingFilter(queryObj);

            result.Items = await query.ToListAsync();
            result.TotalItems = await query.CountAsync();
            
            return result;
        }
    }
}