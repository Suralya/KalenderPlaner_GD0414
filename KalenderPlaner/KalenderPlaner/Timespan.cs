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
    }
}
