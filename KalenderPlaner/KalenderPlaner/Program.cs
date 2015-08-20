using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm;

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
        private static RawInput rawInput;
        public static ConsoleColor DefaultColor = ConsoleColor.Gray;


        static void Main(string[] args)
        {
            Console.WriteLine("Project started!");
            Console.Title = "Kalenderplaner";

            var core = new Core(CrossoverProbability, MutationProbability, PopulationSize, GenerationCount, _jc, rawInput);

            // Auskommentieren, dann läufts!
            Genome<Member> bestResult = core.Generate(); // TODO Bisher wird nur ein einzelnes Member zurückgegeben, noch keine List<Member> - FIX SOON!
            Console.WriteLine("Fitnesswert des besten Genoms: " + bestResult.Fitness);

            /* string temp="";
            if(InputManager.Parse(args))
            temp = String.Join(",", _jc.ResourcesGet(_jc.Import(InputManager.Data)));
            Console.WriteLine(_jc.CurrentYearGet(_jc.Import(InputManager.Data)));

            Console.WriteLine(temp);
            */

            // Testing: Time-Converter //TODO Fix error: You just can run the methode with a full time-string
            Console.WriteLine(Environment.NewLine);
            string tempString = "perm, #:#,1, march, #"; 
            _jc.SaveTimeCondition(tempString);
            Console.WriteLine("Eingabe: " + Environment.NewLine + tempString + Environment.NewLine);
            Console.WriteLine("Ausgabe: ");
            Console.WriteLine(_jc.PermSpans[0].ToString());
            // -----

            Console.ReadKey(true);
        }
    }
}
