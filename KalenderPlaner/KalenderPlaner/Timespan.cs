using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    class Timespan
    {
        public DateTime StartTime;
        public DateTime EndTime;

        public Timespan(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public Timespan(DateTime startTime) : this(startTime, startTime) { }

        public override string ToString()
        {
            return string.Format("Von: {0:00}:{1:00} am {2:00}.{3:00}.{4}/ Bis: {5:00}:{6:00} am {7:00}.{8:00}.{9}", StartTime.Hour, StartTime.Minute, StartTime.Day,
                StartTime.Month, StartTime.Year, EndTime.Hour, EndTime.Minute, EndTime.Day,
                EndTime.Month, EndTime.Year);
        }
    }
}
