using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    class Timespan
    {
        public string StartTime;
        public string EndTime;

        public Timespan(string startTime, string endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public Timespan(string startTime) : this(startTime, startTime) { }

        public override string ToString()
        {
            return string.Format("Von: " + StartTime + " Bis: " + EndTime);
        }
    }
}
