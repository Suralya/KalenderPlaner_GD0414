using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm;
using BackpackProblem;

namespace KalenderPlaner
{
    class Program
    {
        //Evolution Stats:
        private const double CrossoverProbability = 0.8;
        private const double MutationProbability = 0.1;
        private const int PopulationSize = 100;
        private const int GenerationCount = 500;

        private static JsonConverter _jc = new JsonConverter(); 
        public static ConsoleColor DefaultColor = ConsoleColor.Gray;

        static void Main(string[] args)
        {
            //ShowEvolutionaryAlgorithm
            RunBackProblemTest(new MainAlgorithm<int>(CrossoverProbability, MutationProbability, PopulationSize,
                GenerationCount, ExtractItemsFromInt32Value.Sort, FitnessFunction.CalculateFitness,
                Breeding.Crossover, Breeding.Mutation));


            Console.WriteLine("Project started!");
            Console.Title = "Kalenderplaner";

            /* string temp="";
            if(InputManager.Parse(args))
            temp = String.Join(",", _jc.ResourcesGet(_jc.Import(InputManager.Data)));
            Console.WriteLine(_jc.CurrentYearGet(_jc.Import(InputManager.Data)));

            Console.WriteLine(temp);
            */

            // Testing: Time-Converter //TODO Fix error: You just can run the methode with a full time-string
            Console.WriteLine(Environment.NewLine);
            string tempString = "once, 08:00 - 11:00, 11 - 2, march, 2016 - 2019"; 
            _jc.SaveTimeCondition(tempString);
            Console.WriteLine("Eingabe: " + Environment.NewLine + tempString + Environment.NewLine);
            Console.WriteLine("Ausgabe: ");
            Console.WriteLine(_jc.OnceSpans[0].ToString());
            // -----

            Console.ReadKey(true);
        }

        private static void RunBackProblemTest(MainAlgorithm<int> a)
        {
            BackpackDemo.GenerateRandomItems();
            Genome<int> Result = a.Evolve(BackpackDemo.GenerateRandomSolutions(PopulationSize));

            Console.WriteLine("Picked Items:");
            Console.WriteLine();

            foreach (Item t in Result.ItemsPicked)
            {
                Console.WriteLine(t.Name + "  " + "\t" + " (Worth:" + t.Worth + ") " +
                                  "\t" + "(Weight:" + t.Weight + ")");
            }

            Console.WriteLine();
            Console.WriteLine("MaxWeight: " + FitnessFunction.MaxValue);
            Console.WriteLine("Current Weight: " + Result.ItemsPicked.Sum(t => t.Weight));
            Console.WriteLine("Current Worth: " + Result.ItemsPicked.Sum(t => t.Worth));
            Console.WriteLine();
            Console.WriteLine("Weight of all Items: " + ExtractItemsFromInt32Value.Selection.Sum(t => t.Weight));
            Console.WriteLine("Worth of all Items: " + ExtractItemsFromInt32Value.Selection.Sum(t => t.Worth));
            Console.WriteLine();
        }
    }
}
