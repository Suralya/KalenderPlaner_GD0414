using System;
using System.Collections.Generic;
using System.Linq;

namespace KalenderPlaner
{
    class OutputRegulator
    {
        public DateTime StartTime, EndTime;
        public List<DateTime> AllDays = new List<DateTime>();

        public OutputRegulator(DateTime start, DateTime end)
        {
            StartTime = start; //TODO Read from JSon-Converter (static)
            EndTime = end; //TODO Read from JSon-Converter (static)

            DateTime tempDateTime = StartTime;
            while (tempDateTime != EndTime)
            {
                AllDays.Add(tempDateTime);
                tempDateTime = tempDateTime.AddDays(1);
            }
        }

        public void WriteConsoleSchedule(List<Member> outputMembers)
        {
            foreach (DateTime date in AllDays)
            {
                Console.Write("{0:00}. {1:00}. {2:0000}", date.Day, date.Month, date.Year);
                List<Member> tempMember = outputMembers.Where(i => i.Datas.Any(j => j == date)).ToList();
                WriteColored("   " + String.Join(", ", tempMember.Select(i => i.Name)), ConsoleColor.Yellow);
                Console.WriteLine();
            }
        }

        private void WriteColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = Program.DefaultColor;
        }
    }
}