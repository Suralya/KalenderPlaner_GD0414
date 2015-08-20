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
        public static ConsoleColor DefaultColor = ConsoleColor.Gray;

        public static OutputRegulator OR = new OutputRegulator(new DateTime(2015, 8, 20), new DateTime(2015, 10, 1));

        static void Main(string[] args)
        {
            Console.Title = "Kalenderplaner";

            foreach (DateTime date in OR.AllDays)
            {
                Console.WriteLine("{0:00}. {1:00}. {2:0000}", date.Day, date.Month, date.Year);
            }  
            Console.ReadKey(true);
        }
    }
}
