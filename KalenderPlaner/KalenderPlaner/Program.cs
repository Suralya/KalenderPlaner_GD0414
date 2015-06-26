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
    }
}
