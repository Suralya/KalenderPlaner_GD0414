using System.Collections.Generic;
using GeneticAlgorithm;

namespace KalenderPlaner
{
    class Core
    {
        private double _crossoverProbability = 0.8;
        private double _mutationProbability = 0.1;
        private int _populationSize = 100;
        private int _generationCount = 500;

        public Core(double crossoverProbability, double mutationProbability, int populationSize, int generationCount)
        {
            _crossoverProbability = crossoverProbability;
            _mutationProbability = mutationProbability;
            _populationSize = populationSize;
            _generationCount = generationCount;
        }

        public List<Member> Selection;


        // Jeder Member sucht sich einen wieteren Member etc-( solange bis alle demands an Member gestillt sind ?)- dann sucht sich der Member Zeiten

        //Evolutionärer Algorythmus!!
        //viele Raumwechsle-schlecht// 2member direkt hinterinander-schlecht   .etc

        //Rückgabe einer Liste 


        public Genome<Member> Generate()
        {
            var algorithm = new MainAlgorithm<Member>(_crossoverProbability, _mutationProbability, _populationSize,
                _generationCount, FitnessFunction.CalculateFitness, Breeding.Crossover, Breeding.Mutation);

            var temp = GenerateSolutions(Selection);

            return algorithm.Evolve(new List<Genome<Member>>());
        }

        public List<Genome<List<Member>>> GenerateSolutions(List<Member> members)
        {
            var firstGeneration = new List<Genome<List<Member>>>();
            for (int i = 0; i < _populationSize; i++)
            {
                firstGeneration.Add(new Genome<List<Member>>()); //TODO zufälliges Genom
            }
            return firstGeneration;
        }

        //TODO Mehrere Selections auf die Zeitspanne verteilen

    }
}
