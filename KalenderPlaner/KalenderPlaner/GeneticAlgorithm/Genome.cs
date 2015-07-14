using System.Collections.Generic;
using BackpackProblem;

namespace GeneticAlgorithm
{
    internal class Genome<T>
    {
        public float Fitness;
        public List<Item> ItemsPicked = new List<Item>();

        public T Parameter;

        public Genome(T parameter)
        {
            Parameter = parameter;
            Fitness = 0;
        }
    }
}