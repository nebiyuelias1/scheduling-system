using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class AcademicSemesterRepository : Repository<AcademicSemester>, IAcademicSemesterRepository
    {
        public AcademicSemesterRepository(DbContext context) : base(context)
        {
        }

        public async Task<AcademicSemester> GetCurrentAcademicSemester()
        {
            return await SchedulingDbContext.AcademicSemesters
                    .Include(a => a.AcademicYear)
                    .SingleOrDefaultAsync(a => a.IsCurrentSemester);
        }
    }
}