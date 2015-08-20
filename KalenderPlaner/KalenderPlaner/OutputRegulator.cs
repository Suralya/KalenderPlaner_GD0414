using System;
using System.Collections.Generic;

namespace KalenderPlaner
{
    class OutputRegulator
    {
        public DateTime StartTime, EndTime;
        public List<DateTime> AllDays = new List<DateTime>();

        public OutputRegulator(DateTime start, DateTime end)
        {
            StartTime = start;
            EndTime = end;

            DateTime tempDateTime = StartTime;
            while (tempDateTime != EndTime)
            {
                AllDays.Add(tempDateTime);
                tempDateTime = tempDateTime.AddDays(1);
            }
        }
    }
}