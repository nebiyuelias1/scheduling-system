using System;
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
        private readonly IScheduleHelper helper;
        public ICollection<Schedule> Population { get; set; }

        public GeneticAlgorithmHelper(IScheduleHelper helper)
        {
            this.helper = helper;
            Population = new Collection<Schedule>();
        }

        public async void InitializePopulation(Section section)
        {
            ICollection<Schedule> population = new Collection<Schedule>();

            for (int i = 0; i < Configurations.POPULATION_SIZE; i++)
            {
                population.Add(await helper.InitializeScheduleForSection(section));
            }
            Population = population;
        }

        public ICollection<Schedule> NaturalSelection()
        {
            List<Schedule> matingPool = new List<Schedule>();
            var fitnessSum = Population.Sum(p => p.Fitness);  

            foreach (var item in Population)
            {
                var normalizedFitness = (item.Fitness*100 / fitnessSum) * Configurations.POPULATION_SIZE;

                for (int i = 0; i < normalizedFitness; i++)
                {
                    matingPool.Add(item); 
                }
            }
            return matingPool; 
        }

        public void CreateNextGeneration(IList<Schedule> matingPool)
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
                else if ( parentA.Fitness < parentB.Fitness)
                {
                    child = parentB;
                }


                if (rand.NextDouble() <= Configurations.MUTATION_RATE)
                {
                    child.Mutate();
                }
                child.CalculateFitness(child.Section.CourseOfferings);
                
                population.Add(child);
            }
            Population = population; 
        }

        public Schedule FindBestSchedule()
        {
            throw new NotImplementedException();
        }
    }
}