using System.Linq;
using GeneticAlgorithm;
using KalenderPlaner;

// die derzeizige Fitnessfunktion erlaubt eine Übertretung des Maximalgewichts von bis zu 10%


namespace BackpackProblem
{
    internal static class FitnessFunction
    {
        public static int MaxValue;

        public static void CalculateFitness(Genome<int> genom)
        {
            if (genom.ItemsPicked.Sum(t => t.Weight) >= MaxValue * 1.1f)
            {
                genom.Fitness = 0;
                return;
            }

            genom.Fitness += genom.ItemsPicked.Sum(t => t.Worth);

            float x = genom.ItemsPicked.Sum(t => t.Weight) - MaxValue;
            genom.Fitness += (-((0.5f * x * x) + (5 * x)));

            if (genom.Fitness < 1)
            {
                genom.Fitness = 1;
            }
        }
    }
}