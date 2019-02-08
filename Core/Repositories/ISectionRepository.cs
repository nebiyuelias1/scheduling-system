using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface ISectionRepository : IRepository<Section>
    {
        Task<Section> GetSectionWithCourseOfferings(int sectionId, int semesterId);
    }
}