using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    class Program
    {

        public static ConsoleColor DefaultColor = ConsoleColor.Gray;

        static void Main(string[] args)
        {
            Console.WriteLine("Project started!");
            Console.Title = "Kalenderplaner";

            if (InputManager.Parse(args))
            {
                Console.WriteLine("Memberdaten eingelesen.");
                Console.WriteLine();
                Console.WriteLine("Inhalt:");
                Console.WriteLine(InputManager.Data);
            }
            else
            {
                Console.WriteLine("Fehler beim Einlesen der Member-Daten!");
            }

            
            Console.ReadKey(true);
        }
    }
}
