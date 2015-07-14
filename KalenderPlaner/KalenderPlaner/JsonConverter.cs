using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KalenderPlaner
{

    [Serializable]
    public class StringToDateConvertException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public StringToDateConvertException()
        {
        }

        public StringToDateConvertException(string message)
            : base(message)
        {
        }

        public StringToDateConvertException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected StringToDateConvertException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }


    class JsonConverter
    {
        public List<Timespan> OnceSpans = new List<Timespan>();
        public List<Timespan> PermSpans = new List<Timespan>();


        //convertiert string in Jason und andersrum
        public JsonConverter()
        {
        }



        public RawInput Import(string jsonfile)
        {
            RawInput lists = JsonConvert.DeserializeObject<RawInput>(jsonfile);
            return lists;
        }

        public int CurrentYearGet(RawInput lists)
        {
            return lists.CurrentYear;
        }

        public List<Resource> ResourcesGet(RawInput lists)
        {
            return lists.Resources;
        }

        public List<TimeConditions> UnavailableDatesGet(RawInput lists)
        {
            return lists.UnavailableDates;
        }

        public List<Member> MembersGet(RawInput lists)
        {
            return lists.MemberList;
        }


        // Time-Converter
        public void SaveTimeCondition(string conditions)
        {
            string[] tempCond = conditions.Split(',');
            if (tempCond.Length <= 1 || tempCond.Length > 5)
                throw new StringToDateConvertException();

            switch (tempCond[0].ToLower())
            {
                case "once":
                    SaveOnceCondition(tempCond);
                    break;
                case "perm":
                    SavePermCondition(tempCond);
                    break;
                default:
                    throw new StringToDateConvertException();
                    break;
            }
        }


        private void SaveOnceCondition(string[] condition)
        {
            int min1, min2, hour1, hour2, day1, day2, month1, month2, year1, year2;

            switch (condition.Length)
            {
                case 5:
                    // Read Minutes and Hours
                    min1 = ReadMinutes(ParseDate(condition[1])[0]);
                    min2 = ReadMinutes(ParseDate(condition[1])[1]);
                    hour1 = ReadHours(ParseDate(condition[1])[0]);
                    hour2 = ReadHours(ParseDate(condition[1])[1]);
                    // Read Day
                    day1 = ReadDayOrYear(ParseDate(condition[2])[0]);
                    day2 = ReadDayOrYear(ParseDate(condition[2])[1]);
                    // Read Month
                    month1 = ReadMonth(ParseDate(condition[3])[0]);
                    month2 = ReadMonth(ParseDate(condition[3])[1]);
                    // Read Year
                    year1 = ReadDayOrYear(ParseDate(condition[4])[0]);
                    year2 = ReadDayOrYear(ParseDate(condition[4])[1]);

                    OnceSpans.Add(new Timespan(new DateTime(year1, month1, day1, hour1, min1, 0), new DateTime(year2, month2, day2, hour2, min2, 59)));
                    break;
                case 4:
                    // Read Day
                    day1 = ReadDayOrYear(ParseDate(condition[1])[0]);
                    day2 = ReadDayOrYear(ParseDate(condition[1])[1]);
                    // Read Month
                    month1 = ReadMonth(ParseDate(condition[2])[0]);
                    month2 = ReadMonth(ParseDate(condition[2])[1]);
                    // Read Year
                    year1 = ReadDayOrYear(ParseDate(condition[3])[0]);
                    year2 = ReadDayOrYear(ParseDate(condition[3])[1]);

                    OnceSpans.Add(new Timespan(new DateTime(year1, month1, day1, 1, 0, 0), new DateTime(year2, month2, day2, 24, 0, 0)));
                    break;
                case 3:
                    // Read Month
                    month1 = ReadMonth(ParseDate(condition[1])[0]);
                    month2 = ReadMonth(ParseDate(condition[1])[1]);
                    // Read Year
                    year1 = ReadDayOrYear(ParseDate(condition[2])[0]);
                    year2 = ReadDayOrYear(ParseDate(condition[2])[1]);

                    OnceSpans.Add(new Timespan(new DateTime(year1, month1, 1), new DateTime(year2, month2, 29))); // Last-Month does not match
                    break;
                case 2:
                    // Read Year
                    year1 = ReadDayOrYear(ParseDate(condition[1])[0]);
                    year2 = ReadDayOrYear(ParseDate(condition[1])[1]);

                    OnceSpans.Add(new Timespan(new DateTime(year1, 1, 1), new DateTime(year2, 12, 29))); // Last-Month does not match
                    break;
                default:
                    throw new StringToDateConvertException();
            }
        }

        private void SavePermCondition(string[] condition)
        {
            int min1, min2, hour1, hour2, day1, day2, month1, month2, year1, year2;

            for (int i = 0; i < condition.Length; i++)
            {
                condition[i] = IfEntryIsHashtag(condition[i]);
            }

            switch (condition.Length)
            {
                case 5:
                    // Read Minutes and Hours
                    min1 = ReadMinutes(ParseDate(condition[1])[0]);
                    min2 = ReadMinutes(ParseDate(condition[1])[1]);
                    hour1 = ReadHours(ParseDate(condition[1])[0]);
                    hour2 = ReadHours(ParseDate(condition[1])[1]);
                    // Read Day
                    day1 = ReadDayOrYear(ParseDate(condition[2])[0]);
                    day2 = ReadDayOrYear(ParseDate(condition[2])[1]);
                    // Read Month
                    month1 = ReadMonth(ParseDate(condition[3])[0]);
                    month2 = ReadMonth(ParseDate(condition[3])[1]);
                    // Read Year
                    year1 = ReadDayOrYear(ParseDate(condition[4])[0]);
                    year2 = ReadDayOrYear(ParseDate(condition[4])[1]);

                    OnceSpans.Add(new Timespan(new DateTime(year1, month1, day1, hour1, min1, 0), new DateTime(year2, month2, day2, hour2, min2, 59)));
                    break;
                case 4:
                    // Read Day
                    day1 = ReadDayOrYear(ParseDate(condition[1])[0]);
                    day2 = ReadDayOrYear(ParseDate(condition[1])[1]);
                    // Read Month
                    month1 = ReadMonth(ParseDate(condition[2])[0]);
                    month2 = ReadMonth(ParseDate(condition[2])[1]);
                    // Read Year
                    year1 = ReadDayOrYear(ParseDate(condition[3])[0]);
                    year2 = ReadDayOrYear(ParseDate(condition[3])[1]);

                    OnceSpans.Add(new Timespan(new DateTime(year1, month1, day1, 1, 0, 0), new DateTime(year2, month2, day2, 24, 0, 0)));
                    break;
                case 3:
                    // Read Month
                    month1 = ReadMonth(ParseDate(condition[1])[0]);
                    month2 = ReadMonth(ParseDate(condition[1])[1]);
                    // Read Year
                    year1 = ReadDayOrYear(ParseDate(condition[2])[0]);
                    year2 = ReadDayOrYear(ParseDate(condition[2])[1]);

                    OnceSpans.Add(new Timespan(new DateTime(year1, month1, 1), new DateTime(year2, month2, 29))); // Last-Month does not match
                    break;
                case 2:
                    // Read Year
                    year1 = ReadDayOrYear(ParseDate(condition[1])[0]);
                    year2 = ReadDayOrYear(ParseDate(condition[1])[1]);

                    OnceSpans.Add(new Timespan(new DateTime(year1, 1, 1), new DateTime(year2, 12, 29))); // Last-Month does not match
                    break;
                default:
                    throw new StringToDateConvertException();
            }
        }


        private int ReadMinutes(string s)
        {
            string[] temp = s.Split(':');
            if (temp.Length != 2)
                throw new StringToDateConvertException();
            return Convert.ToInt32(temp[1].Trim());
        }

        private int ReadHours(string s)
        {
            string[] temp = s.Split(':');
            if (temp.Length != 2)
                throw new StringToDateConvertException();
            return Convert.ToInt32(temp[0].Trim());
        }

        private int ReadMonth(string s)
        {
            switch (s.ToLower())
            {
                case "january":
                case "jan":
                    return 1;

                case "february":
                case "feb":
                    return 2;

                case "march":
                case "mar":
                    return 3;

                case "april":
                case "apr":
                    return 4;

                case "may":
                    return 5;

                case "june":
                    return 6;

                case "july":
                    return 7;

                case "august":
                case "aug":
                    return 8;

                case "september":
                case "sept":
                    return 9;

                case "october":
                case "oct":
                    return 10;

                case "november":
                case "nov":
                    return 11;

                case "december":
                case "dec":
                    return 12;

                default:
                    throw new StringToDateConvertException();
            }
        }

        private int ReadDayOrYear(string s)
        {
            return Convert.ToInt32(s.Trim());
        }


        private string[] ParseDate(string s)
        {
            string[] parsedString = new string[2];
            string[] tempString = s.Split('-');
            parsedString[0] = tempString[0];
            if (tempString.Length == 2)
            {
                parsedString[1] = tempString[1];
            }
            else
            {
                parsedString[1] = tempString[0];
            }

            for (int i = 0; i < parsedString.Length; i++)
            {
                parsedString[i] = parsedString[i].Trim();
            }

            if (parsedString.Length > 2)
                throw new StringToDateConvertException();

            return parsedString;
        }
        // -----

        private string IfEntryIsHashtag(string text)
        {
            if (text.Trim() == "#")
                return "0";
            return text;
        }




    }


}
