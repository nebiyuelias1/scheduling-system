using System.Collections.Generic;
using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface ICourseOfferingRepository : IRepository<CourseOffering>
    {
        Task<QueryResult<CourseOffering>> GetCourseOfferingsWithRelatedData(CourseOfferingQuery queryObj);
        bool DoesCourseOfferingExist(int currentSemesterId, int courseId, int sectionId);
        Task<CourseOffering> GetCourseOffering(int id);
    }
}