using System;
using System.Collections.Generic;
using System.Linq;
using KalenderPlaner;

namespace GeneticAlgorithm
{
    internal class MainAlgorithm<T>
    {
        public delegate T[] Crossover(Genome<T> parent1, Genome<T> parent2);

        public delegate void FirstGeneration(Genome<T> genom);

        public delegate void FitnessValue(Genome<T> genom);

        public delegate void GenerateRandomItems();

        public delegate List<Genome<T>> GenerateRandomSolutions(int populationSize);

        public delegate T Mutation(Genome<T> genom);

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

        private T[] _crossedGenomes = new T[2];
        private Genome<T> _crossoverPartner;

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


        // Constructor ohne FirstGeneration-Delegate!!!
        public MainAlgorithm(double crossoverProbability, double mutationProbability, int populationSize,
    int generationCount, FitnessValue fitnessValue, Crossover crossover,
    Mutation mutation)
        {
            CrossoverProbability = crossoverProbability;
            MutationProbability = mutationProbability;
            PopulationSize = populationSize;
            GenerationCount = generationCount;
            _fitnessValue = fitnessValue;
            _crossover = crossover;
            _mutation = mutation;
        }

        public Genome<T> Evolve(List<Genome<T>> items)
        {
            Solutions.AddRange(items);

            for (int i = 0; i < GenerationCount; i++)
            {
                for (int k = 0; k < PopulationSize; k++)
                {
                    _firstGeneration.Invoke(Solutions[k]);
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
                                if (_crossoverPartner == null)
                                {
                                    _crossoverPartner = Solutions[m];
                                }
                                else
                                {
                                    _crossedGenomes = _crossover.Invoke(_crossoverPartner, Solutions[m]);

                                    NextGeneration.Add(new Genome<T>(_crossedGenomes[0]));
                                    NextGeneration.Add(new Genome<T>(_crossedGenomes[1]));
                                    _crossoverPartner = null;
                                }
                            }

                            if (rnd.NextDouble() <= MutationProbability)
                            {
                                NextGeneration.Add(new Genome<T>(_mutation.Invoke(Solutions[m])));
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