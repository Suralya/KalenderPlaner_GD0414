using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    class ScheduleCalendar
    {

        //einlesen des Kalenderjahres vom User zum erstellen eines Kalenders
        //public int CurrentYear

        //Erstellen eines Kalenders mithilfe der Eingabe
        //DateTime myDT = new DateTime(CurrentYear, 1, 1, new GregorianCalendar());

        // Uses the default calendar of the InvariantCulture.
        //Calendar myCal = CultureInfo.InvariantCulture.Calendar;

        //Infos auf https://msdn.microsoft.com/de-de/library/system.globalization.calendar(v=vs.110).aspx (Calendar) 
        //und https://msdn.microsoft.com/de-de/library/system.datetime(v=vs.110).aspx (DateTime)

        //FRAGE: Membern werden DateTimes zugewiesen oder den DateTimes die Member?

        public int CurrentYear;

        public DateTime ScheduleDay; 
        public Calendar Schedule = CultureInfo.InvariantCulture.Calendar;

        public ScheduleCalendar()
        {
           ScheduleDay = new DateTime(CurrentYear, 1, 1, new GregorianCalendar());
        }
    }
}
