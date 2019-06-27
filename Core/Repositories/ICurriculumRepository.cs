using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface ICurriculumRepository : IRepository<Curriculum>
    {
        Task<QueryResult<Curriculum>> GetCurriculums(CurriculumQuery filter);
    }
}