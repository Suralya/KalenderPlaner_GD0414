using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    class Timespan
    {
        public DateTime StarTime;
        public DateTime EndTime;

        public Timespan(DateTime starTime, DateTime endTime)
        {
            StarTime = starTime;
            EndTime = endTime;
        }

        public Timespan(DateTime starTime) : this(starTime, starTime) { }

        public override string ToString()
        {
            return string.Format("Von: {0:00}:{1:00} am {2:00}.{3:00}.{4}/ Bis: {5:00}:{6:00} am {7:00}.{8:00}.{9}", StarTime.Hour, StarTime.Minute, StarTime.Day,
                StarTime.Month, StarTime.Year, EndTime.Hour, EndTime.Minute, EndTime.Day,
                EndTime.Month, EndTime.Year);
        }
    }
}
