using System;
using System.Collections.Generic;
using System.Linq;
using KalenderPlaner;

namespace GeneticAlgorithm
{
    internal class MainAlgorithm<T>
    {
        public delegate Genome<T>[] Crossover(Genome<T> parent1, Genome<T> parent2);

        public delegate List<Genome<T>> FirstGeneration(int population);

        public delegate void FitnessValue(Genome<T> genom);

        public delegate void GenerateRandomItems();

        public delegate List<Genome<T>> GenerateRandomSolutions(int populationSize);

        public delegate Genome<T> Mutation(Genome<T> genom);

        private readonly List<Genome<T>> NextGeneration = new List<Genome<T>>();
        private readonly List<Genome<T>> Solutions = new List<Genome<T>>();
        private readonly Crossover _crossover;
        private readonly FirstGeneration _firstGeneration;
        private readonly FitnessValue _fitnessValue;
        private readonly Mutation _mutation;
        private readonly Random rnd = new Random();

        public double CrossoverProbability;
        public int GenerationCount;
        public double MutationProbability;
        public int PopulationSize;

        private Genome<T> _bestFitness;

        private Genome<T>[] _crossedGenomes = new Genome<T>[2];
        private Genome<T> _crossoverPartner = new Genome<T>();

        public MainAlgorithm(double crossoverProbability, double mutationProbability, int populationSize,
            int generationCount, FirstGeneration firstGeneration, FitnessValue fitnessValue, Crossover crossover,
            Mutation mutation)
        {
            CrossoverProbability = crossoverProbability;
            MutationProbability = mutationProbability;
            PopulationSize = populationSize;
            GenerationCount = generationCount;
            _firstGeneration = firstGeneration;
            _fitnessValue = fitnessValue;
            _crossover = crossover;
            _mutation = mutation;
        }

        public Genome<T> Evolve()
        {
            List<Genome<T> > temp = _firstGeneration.Invoke(PopulationSize);
            Solutions.AddRange(temp);

            for (int i = 0; i < GenerationCount; i++)
            {
                for (int k = 0; k < PopulationSize; k++)
                {
                    _fitnessValue.Invoke(Solutions[k]);
                }

                Solutions.OrderByDescending(t => t.Fitness);

                double minimalFitness = Solutions.Where(x => !x.Fitness.Equals(0)).Sum(t => t.Fitness) / PopulationSize -
                                        Solutions.Count(x => !x.Fitness.Equals(0));

                while (NextGeneration.Count < PopulationSize)
                {
                    for (int m = 0; m < Solutions.Count; m++)
                    {
                        if (NextGeneration.Count < PopulationSize)
                        {
                            if (Solutions[m].Fitness >= minimalFitness && rnd.NextDouble() <= CrossoverProbability)
                            {
                                if (_crossoverPartner.Parameter == null)
                                {
                                    _crossoverPartner = Solutions[m];
                                }
                                else
                                {
                                    _crossedGenomes = _crossover.Invoke(_crossoverPartner, Solutions[m]);

                                    NextGeneration.Add(_crossedGenomes[0]);
                                    NextGeneration.Add(_crossedGenomes[1]);

                                    _crossoverPartner = new Genome<T>();
                                }
                            }

                            if (rnd.NextDouble() <= MutationProbability)
                            {
                                NextGeneration.Add(_mutation.Invoke(Solutions[m]));
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                while (NextGeneration.Count > PopulationSize)
                {
                    NextGeneration.RemoveAt(NextGeneration.Count - 1);
                }

                if (_bestFitness != null)
                {
                    if (_bestFitness.Fitness <= Solutions[0].Fitness)
                    {
                        _bestFitness = Solutions[0];
                    }
                }
                else
                {
                    _bestFitness = Solutions[0];
                }

                Solutions.RemoveAll(t => t.Parameter != null);
                Solutions.AddRange(NextGeneration);
                NextGeneration.RemoveAll(t => t.Parameter != null);
            }
            return _bestFitness;
        }
    }
}