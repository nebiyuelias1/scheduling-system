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
        private readonly IUnitOfWork unitOfWork;

        public GeneticAlgorithm(IGeneticAlgorithmHelper helper, IUnitOfWork unitOfWork)
        {
            this.helper = helper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Schedule> GenerateScheduleForSection(int sectionId)
        {
            var currentSemester = await unitOfWork.AcademicSemesters
                                    .GetCurrentAcademicSemester();

            var section = await unitOfWork
                                .Sections
                                .GetSectionWithCourseOfferings(sectionId, currentSemester.Id);
            
            helper.InitializePopulation(section);
            var matingPool = helper.NaturalSelection().ToList();
            helper.CreateNextGeneration(matingPool);

            return null;
        }
    }
}