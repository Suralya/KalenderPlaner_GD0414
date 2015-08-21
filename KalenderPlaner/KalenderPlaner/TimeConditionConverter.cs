using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;

namespace KalenderPlaner
{
    [Serializable]
    public class IllegalInputException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public IllegalInputException()
        {
        }

        public IllegalInputException(string message) : base(message)
        {
        }

        public IllegalInputException(string message, Exception inner) : base(message, inner)
        {
        }

        protected IllegalInputException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    class TimeConditionConverter
    {
        private JsonConverter _jc;

        public TimeConditionConverter(JsonConverter jc)
        {
            _jc = jc;

        }

        public List<DateTime> AddDays(List<List<string>> input) // TODO Input-Type ändern???
        {
            switch (_jc.WriteDateTime(input))
            {
                case 1:
                    return AddSingleDay(_jc.FirstDateTime);
                case 2:
                    return AddTimespan(_jc.FirstDateTime, _jc.SecondDateTime);
                case 3:
                    return AddDaysInSpan(_jc.FirstDateTime, _jc.SecondDateTime, _jc.Content);
                case 4:
                    return AddDaysinGlobalSpan(_jc.Content);
                default:
                    throw new IllegalInputException();
            }
        }

        private List<DateTime> AddTimespan(DateTime spanfrom, DateTime spanto)
        {
            // adding timespan to list
            List<DateTime> temp = new List<DateTime>();
            DateTime tempday = spanfrom;


            while (tempday != spanto.AddDays(1))
            {
                temp.Add(tempday);
                tempday = tempday.AddDays(1);
            }

            return temp;
        }

        private List<DateTime> AddSingleDay(DateTime date)
        {
            // adding time to list
            List<DateTime> temp = new List<DateTime>();
            temp.Add(date);


            return temp;
        }

        private List<DateTime> AddDaysInSpan(DateTime kalanderfrom, DateTime kalenderto, string condition)
        {
            //Month/weekday - adding to list
            List<DateTime> temp = new List<DateTime>();
            Calendar calandersource = CultureInfo.InvariantCulture.Calendar;
            DateTime tempday = kalanderfrom;
            int monthtemp = 0;

            switch (condition)
            {
                case ("January"):
                    {
                        monthtemp = 1;
                        break;
                    }
                case ("February"):
                    {
                        monthtemp = 2;
                        break;
                    }
                case ("March"):
                    {
                        monthtemp = 3;
                        break;
                    }
                case ("April"):
                    {
                        monthtemp = 4;
                        break;
                    }
                case ("May"):
                    {
                        monthtemp = 5;
                        break;
                    }
                case ("June"):
                    {
                        monthtemp = 6;
                        break;
                    }
                case ("July"):
                    {
                        monthtemp = 7;
                        break;
                    }
                case ("August"):
                    {
                        monthtemp = 8;
                        break;
                    }
                case ("September"):
                    {
                        monthtemp = 9;
                        break;
                    }
                case ("October"):
                    {
                        monthtemp = 10;
                        break;
                    }
                case ("November"):
                    {
                        monthtemp = 11;
                        break;
                    }
                case ("December"):
                    {
                        monthtemp = 12;
                        break;
                    }


                case ("Monday"):
                    {
                        break;
                    }
                case ("Tuesday"):
                    {
                        break;
                    }
                case ("Wendsday"):
                    {
                        break;
                    }
                case ("Thursday"):
                    {
                        break;
                    }
                case ("Friday"):
                    {
                        break;
                    }
                case ("Saturday"):
                    {
                        break;
                    }
                case ("Sunday"):
                    {
                        break;
                    }

                default:
                    throw new IllegalInputException();
            }


            while (tempday != kalenderto.AddDays(1))
            {
                if (calandersource.GetDayOfWeek(tempday).ToString().Equals(condition) || calandersource.GetMonth(tempday) == monthtemp)
                    temp.Add(tempday);

                tempday = tempday.AddDays(1);
            }


            return temp;
        }

        private List<DateTime> AddDaysinGlobalSpan(string condition)
        {
            return AddDaysInSpan(JsonConverter.StartTime, JsonConverter.EndTime, condition);
        }



    }
}