using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class InstructorAssignmentRepository : Repository<InstructorAssignment>, IInstructorAssignmentRepository
    {
        public InstructorAssignmentRepository(DbContext context) : base(context)
        {
        }

        public async Task<InstructorAssignment> GetInstructorAssignment(int courseOfferingId, int instructorId, int typeId)
        {
            return await SchedulingDbContext.CourseOfferingInstructorAssignments
                            .Include(co => co.CourseOffering)
                            .Include(co => co.Instructor)
                            .Include(co => co.Type)
                            .SingleAsync(co => co.CourseOfferingId == courseOfferingId &&
                            co.InstructorId == instructorId &&
                            co.TypeId == typeId);
        }
    }
}