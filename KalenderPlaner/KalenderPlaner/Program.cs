using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm;

namespace KalenderPlaner
{
    class Program
    {
        public static ConsoleColor DefaultColor = ConsoleColor.Gray;

        public static List<Member> FinalTestMember = new List<Member>();
        public static JsonConverter _converter = new JsonConverter();

        public static OutputRegulator OR = new OutputRegulator(new DateTime(2015, 1, 1), new DateTime(2015, 3, 31));

        static void Main(string[] args)
        {
            Console.Title = "Kalenderplaner";
            string jsonPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            jsonPath = jsonPath + "\\bin\\Debug\\document.json";
            string jsonFile = File.ReadAllText(jsonPath);

            //InputManager.Parse(test);

            //Console.WriteLine(InputManager.Data + "a");

            _converter.Import(jsonFile);

            //TestMember
                //Resources
            //Resource space10 = new Resource("Volumen10");
            //Resource space50 = new Resource("Volumen50");
            //Resource thomas = new Resource("Dozent: Thomas");
            //Resource bhatty = new Resource("Dozent: Bhatty");
            //Resource computer = new Resource("Hat Computer");

            //    //Member
            //FinalTestMember.Add(new Member("Raum01", new List<Resource> {space10}, new List<Resource>(),new List<DateTime>(), 10));
            //FinalTestMember.Add(new Member("Raum02", new List<Resource> { space50 }, new List<Resource>(), new List<DateTime>(), 8));
            //FinalTestMember.Add(new Member("KursA", new List<Resource>(), new List<Resource> { space10, bhatty }, new List<DateTime>()));
            //FinalTestMember.Add(new Member("KursB", new List<Resource>(), new List<Resource> { space50, thomas, computer }, new List<DateTime>()));
            //FinalTestMember.Add(new Member("Bhatty", new List<Resource> { bhatty }, new List<Resource>(), new List<DateTime>()));
            //FinalTestMember.Add(new Member("Thomas", new List<Resource> { thomas }, new List<Resource>(), new List<DateTime>()));

            //    //Set Data
            //FinalTestMember[0].Dates.AddRange(new List<DateTime>
            //{
            //    new DateTime(2015, 1, 1), 
            //    new DateTime(2015, 1, 4), 
            //    new DateTime(2015, 1, 8), 
            //    new DateTime(2015, 1, 12), 
            //    new DateTime(2015, 1, 16),
            //    new DateTime(2015, 1, 20),
            //    new DateTime(2015, 1, 24),
            //    new DateTime(2015, 1, 28),
            //    new DateTime(2015, 2, 2),
            //    new DateTime(2015, 2, 6)
            //});

            //FinalTestMember[1].Dates.AddRange(new List<DateTime>
            //{
            //    new DateTime(2015, 1, 3), 
            //    new DateTime(2015, 1, 6), 
            //    new DateTime(2015, 1, 10), 
            //    new DateTime(2015, 1, 14), 
            //    new DateTime(2015, 1, 18),
            //    new DateTime(2015, 1, 22),
            //    new DateTime(2015, 1, 26),
            //    new DateTime(2015, 1, 30)
            //});

            //FinalTestMember[2].Dates.AddRange(new List<DateTime>
            //{
            //    new DateTime(2015, 1, 1), 
            //    new DateTime(2015, 1, 4), 
            //    new DateTime(2015, 1, 8), 
            //    new DateTime(2015, 1, 12), 
            //    new DateTime(2015, 1, 16),
            //    new DateTime(2015, 1, 20),
            //    new DateTime(2015, 1, 24),
            //    new DateTime(2015, 1, 28),
            //    new DateTime(2015, 2, 2),
            //    new DateTime(2015, 2, 6)
            //});

            //FinalTestMember[3].Dates.AddRange(new List<DateTime>
            //{
            //    new DateTime(2015, 1, 3), 
            //    new DateTime(2015, 1, 6), 
            //    new DateTime(2015, 1, 10), 
            //    new DateTime(2015, 1, 14), 
            //    new DateTime(2015, 1, 18),
            //    new DateTime(2015, 1, 22),
            //    new DateTime(2015, 1, 26),
            //    new DateTime(2015, 1, 30)
            //});

            //FinalTestMember[4].Dates.AddRange(new List<DateTime>
            //{
            //    new DateTime(2015, 1, 1), 
            //    new DateTime(2015, 1, 4), 
            //    new DateTime(2015, 1, 8), 
            //    new DateTime(2015, 1, 12), 
            //    new DateTime(2015, 1, 16),
            //    new DateTime(2015, 1, 20),
            //    new DateTime(2015, 1, 24),
            //    new DateTime(2015, 1, 28),
            //    new DateTime(2015, 2, 2),
            //    new DateTime(2015, 2, 6)
            //});

            //FinalTestMember[5].Dates.AddRange(new List<DateTime>
            //{
            //    new DateTime(2015, 1, 3), 
            //    new DateTime(2015, 1, 6), 
            //    new DateTime(2015, 1, 10), 
            //    new DateTime(2015, 1, 14), 
            //    new DateTime(2015, 1, 18),
            //    new DateTime(2015, 1, 22),
            //    new DateTime(2015, 1, 26),
            //    new DateTime(2015, 1, 30)
            //});
            //// --- END TEST MEMBER CREATION ---

            OR.WriteConsoleSchedule(_converter.Import(jsonFile).MemberList);

            Console.ReadKey(true);
        }
    }
}
