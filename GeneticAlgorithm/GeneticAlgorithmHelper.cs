using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.GeneticAlgorithm
{
    public class GeneticAlgorithmHelper : IGeneticAlgorithmHelper
    {
        private readonly SchedulingDbContext context;
        private readonly IScheduleHelper helper;

        public GeneticAlgorithmHelper(SchedulingDbContext context, IScheduleHelper helper)
        {
            this.context = context;
            this.helper = helper;
        }
        public async Task<Section> GetSectionWithCourseOfferings(int sectionId, int semesterId)
        {
            return await context.Sections
                    .Include(s => s.Department)
                    .Include(s => s.CourseOfferings)
                        .ThenInclude(c => c.Course)
                    .SingleOrDefaultAsync(s => s.Id == sectionId && s.CourseOfferings.Select(c => c.AcademicSemesterId).Contains(semesterId));
        }

        public async void InitializePopulation(Section section)
        {
            ICollection<Schedule> population = new Collection<Schedule>();

            for (int i = 0; i < Configurations.POPULATION_SIZE; i++)
            {
                population.Add(await helper.InitializeScheduleForSection(section));
            }
        }
    }
}