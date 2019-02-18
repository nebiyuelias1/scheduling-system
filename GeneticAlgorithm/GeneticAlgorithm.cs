using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICollection<Schedule> Population { get; set; }
        private readonly IFitnessCalculator fitnessCalculator;
        private Types types;

        public GeneticAlgorithm(IGeneticAlgorithmHelper helper, IUnitOfWork unitOfWork, IFitnessCalculator fitnessCalculator)
        {
            this.fitnessCalculator = fitnessCalculator;
            this.helper = helper;
            this.unitOfWork = unitOfWork;
            Population = new Collection<Schedule>();
        }

        public async Task<Schedule> GenerateScheduleForSection(int sectionId)
        {
            this.types = await unitOfWork.Types.GetTypes();

            var currentSemester = await unitOfWork.AcademicSemesters
                                    .GetCurrentAcademicSemester();

            var section = await unitOfWork
                                .Sections
                                .GetSectionWithCourseOfferings(sectionId, currentSemester.Id);

            Population = await InitializePopulation(section);

            return FindBestSchedule();
        }

        private Schedule FindBestSchedule()
        {
            while (true)
            {
                var matingPool = NaturalSelection();
                CreateNextGeneration(matingPool.ToList());

                if (Population.Any(p => p.Fitness >= 0.5))
                {
                    break;
                }
            }

            return Population.OrderByDescending(s => s.Fitness).FirstOrDefault();
        }

        private void CreateNextGeneration(List<Schedule> matingPool)
        {
            Random rand = new Random();
            var population = new Collection<Schedule>();

            for (int i = 0; i < Configurations.POPULATION_SIZE; i++)
            {
                int a = rand.Next(matingPool.Count);
                int b = rand.Next(matingPool.Count);

                var parentA = matingPool[a];
                var parentB = matingPool[b];

                Schedule child = null;

                if (rand.NextDouble() <= Configurations.CROSSOVER_RATE)
                {
                    child = parentA.Crossover(parentB);
                }
                else if (parentA.Fitness > parentB.Fitness)
                {
                    child = parentA;
                }
                else if (parentA.Fitness <= parentB.Fitness)
                {
                    child = parentB;
                }


                if (rand.NextDouble() <= Configurations.MUTATION_RATE)
                {
                    child.Mutate();
                }

                population.Add(child);
            }
            Population = population;
        }

        private ICollection<Schedule> NaturalSelection()
        {
            List<Schedule> matingPool = new List<Schedule>();
            
            foreach (var item in Population)
            {
                item.Fitness = fitnessCalculator.CalculateFitness(item, item.Section.CourseOfferings, types);
            }

            var fitnessSum = Population.Sum(p => p.Fitness);

            foreach (var item in Population)
            {
                var normalizedFitness = (item.Fitness * 100 / fitnessSum) * Configurations.POPULATION_SIZE;

                for (int i = 0; i < normalizedFitness; i++)
                {
                    matingPool.Add(item);
                }
            }
            return matingPool;
        }

        private async Task<ICollection<Schedule>> InitializePopulation(Section section)
        {
            ICollection<Schedule> population = new Collection<Schedule>();

            var scheduleConfiguration = await helper.GetScheduleConfiguration(section);

            for (int i = 0; i < Configurations.POPULATION_SIZE; i++)
            {
                var schedule = helper.InitializeScheduleForSection(section, scheduleConfiguration, types);
                population.Add(schedule);
            }

            return population;
        }
    }
}