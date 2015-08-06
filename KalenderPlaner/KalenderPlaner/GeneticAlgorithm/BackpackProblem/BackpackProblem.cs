using System;
using System.Linq;
using System.Collections.Generic;
using GeneticAlgorithm;
using KalenderPlaner;

namespace BackpackProblem
{
    static class BackpackDemo
    {
        public static List<string> ListOfNames = new List<string>();
        public static int NumberOfNames = 1000;

        static readonly Random Rnd = new Random();

        public static List<Genome<int>> GenerateRandomSolutions(int populationSize)
        {
            var temp = new List<Genome<int>>();
            for (int i = 0; i < populationSize; i++)
            {
                temp.Add(new Genome<int>(Rnd.Next(1, Int32.MaxValue))); //TODO
            }
            return temp;
        }

        public static void GenerateRandomItems()
        {
            for (int i = 0; i < NumberOfNames; i++)
            {
                ListOfNames.Add("Item_" + Rnd.Next(1, NumberOfNames));
            }

            for (int i = 0; i < 32; i++)
            {
                ExtractItemsFromInt32Value.Selection.Add(new Item(Rnd.Next(1, 51), Rnd.Next(0, 101), ListOfNames[Rnd.Next(0, NumberOfNames - 1)]));
            }
            FitnessFunction.MaxValue = (ExtractItemsFromInt32Value.Selection.Sum(t => t.Weight) / 3);
        }
    }

}
