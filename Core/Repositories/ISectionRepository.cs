using System.Collections.Generic;
using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface ISectionRepository : IRepository<Section>
    {
        Task<Section> GetSectionWithCourseOfferings(int sectionId, int semesterId);
        Task<Section> GetSectionWithAssignedRooms(int sectionId);
        Task<QueryResult<Section>> GetSections(SectionQuery query);
        Task<Section> GetSectionWithBuilding(int sectionId);
    }
}