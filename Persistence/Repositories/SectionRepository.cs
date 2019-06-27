using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;
using SchedulingSystem.Extensions;

namespace SchedulingSystem.Persistence.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(DbContext context) : base(context)
        {
        }

        public async Task<QueryResult<Section>> GetSections(SectionQuery queryObj)
        {
            var result = new QueryResult<Section>();
            
            var query = SchedulingDbContext.Sections
                            .Include(s => s.Curriculum)
                                .ThenInclude(s => s.Department)
                            .Include(s => s.Program)
                            .Include(s => s.AdmissionLevel)
                            .AsQueryable();
            
            query = query.ApplySectionFilter(queryObj);

            result.TotalItems = await query.CountAsync();
            result.Items = await query.ToListAsync();
            
            return result;
        }

        public async Task<Section> GetSectionWithAssignedRooms(int sectionId)
        {
            return await SchedulingDbContext.Sections
                            .Include(s => s.Curriculum)
                                .ThenInclude(c => c.Department)
                            .Include(s => s.Program)
                            .Include(s => s.AdmissionLevel)
                            .Include(s => s.RoomAssignments)
                                .ThenInclude(r => r.Room)
                            .Include(s => s.RoomAssignments)
                                .ThenInclude(r => r.Type)
                            .SingleOrDefaultAsync(s => s.Id == sectionId);
        }

        public async Task<Section> GetSectionWithBuilding(int sectionId)
        {
            return await SchedulingDbContext.Sections
                        .Include(s => s.Curriculum)
                            .ThenInclude(c => c.Department)
                        .Include(s => s.Program)
                        .Include(s => s.AdmissionLevel)
                        .Include(s => s.RoomAssignments)
                            .ThenInclude(r => r.Room)
                                .ThenInclude(r => r.Building)
                        .Include(s => s.RoomAssignments)
                            .ThenInclude(r => r.Type)
                        .SingleOrDefaultAsync(s => s.Id == sectionId);
        }

        public async Task<Section> GetSectionWithCourseOfferings(int sectionId, int semesterId)
        {
            return await SchedulingDbContext.Sections
                            .Include(s => s.Curriculum)
                                .ThenInclude(c => c.Department)
                            .Include(s => s.CourseOfferings)
                                .ThenInclude(c => c.Course)
                            .Include(s => s.CourseOfferings)
                                .ThenInclude(c => c.Instructors)
                                    .ThenInclude(i => i.Instructor)
                            .Include(s => s.CourseOfferings)
                                .ThenInclude(c => c.Instructors)
                                    .ThenInclude(i => i.Type)
                            .Include(s => s.RoomAssignments)
                                .ThenInclude(r => r.Room)
                            .Include(s => s.RoomAssignments)
                                .ThenInclude(r => r.Type)
                            .SingleOrDefaultAsync(s => s.Id == sectionId && s.CourseOfferings.Select(c => c.AcademicSemesterId).Contains(semesterId));
        }
    }
}