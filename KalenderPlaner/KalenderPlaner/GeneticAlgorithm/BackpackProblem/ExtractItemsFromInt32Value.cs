using System.Collections.Generic;
using GeneticAlgorithm;

namespace BackpackProblem
{
    internal static class ExtractItemsFromInt32Value
    {
        public static List<Item> Selection = new List<Item>();

        public static void Sort(Genome<int> genom)
        {
            int temp = genom.Parameter;

            for (int i = 0; i < 31; i++)
            {
                int check = temp & 1 << i;
                if (check == (1 << i))
                {
                    genom.ItemsPicked.Add(Selection[i]);
                }
            }
        }
    }
}