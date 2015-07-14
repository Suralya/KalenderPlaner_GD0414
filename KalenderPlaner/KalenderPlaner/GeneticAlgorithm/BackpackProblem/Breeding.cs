using System;
using GeneticAlgorithm;

namespace BackpackProblem
{
    internal static class Breeding
    {
        private static readonly Random Rnd = new Random();

        private static int _crossPoint;
        private static int _mutatePoint;
        private static int _child1;
        private static int _child2;

        public static int[] Crossover(Genome<int> parent1, Genome<int> parent2)
        {
            _crossPoint = Rnd.Next(1, 32);

            int temp = (1 << _crossPoint) - 1;
            _child1 = parent1.Parameter & temp;
            _child2 = parent2.Parameter & temp;

            temp = Int32.MaxValue - temp;
            _child1 = _child1 | (parent2.Parameter & temp);
            _child2 = _child2 | (parent1.Parameter & temp);

            var crossedGenomes = new int[2];
            crossedGenomes[0] = _child1;
            crossedGenomes[1] = _child2;
            return crossedGenomes;
        }

        public static int Mutation(Genome<int> genom)
        {
            _mutatePoint = Rnd.Next(0, 31);
            int temp = (1 << _mutatePoint);
            _child1 = genom.Parameter ^ temp;
            return _child1;
        }
    }
}