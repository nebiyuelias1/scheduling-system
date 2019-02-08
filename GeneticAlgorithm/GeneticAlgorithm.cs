using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.GeneticAlgorithm
{
    public class GeneticAlgorithm : IGeneticAlgorithm
    {
        private readonly IGeneticAlgorithmHelper helper;
        private readonly SchedulingDbContext context;

        public GeneticAlgorithm(IGeneticAlgorithmHelper helper, SchedulingDbContext context)
        {
            this.helper = helper;
            this.context = context;
        }

        public async Task<Schedule> GenerateScheduleForSection(int sectionId)
        {
            var currentSemester = await context.AcademicSemesters
                                    .Include(a => a.AcademicYear)
                                    .SingleOrDefaultAsync(a => a.IsCurrentSemester);

            var section = await helper.GetSectionWithCourseOfferings(sectionId, currentSemester.Id);
            
            helper.InitializePopulation(section);
            var matingPool = helper.NaturalSelection().ToList();
            helper.CreateNextGeneration(matingPool);

            return null;
        }
    }
}