using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    class Program
    {
        private static JsonConverter _jc = new JsonConverter(); 
        public static ConsoleColor DefaultColor = ConsoleColor.Gray;

        static void Main(string[] args)
        {
            Console.WriteLine("Project started!");
            Console.Title = "Kalenderplaner";

            string temp="";
            if(InputManager.Parse(args))
            temp = String.Join(",", _jc.ResourcesGet(_jc.Import(InputManager.Data)));

            Console.WriteLine(temp);
            
            Console.ReadKey(true);
        }
    }
}
