using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KalenderPlaner
{
    [Serializable]
    public class InvalidDateException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InvalidDateException()
        {
        }

        public InvalidDateException(string message)
            : base(message)
        {
        }

        public InvalidDateException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected InvalidDateException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }

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

        public DateTime FirstDateTime;
        public DateTime SecondDateTime;

        public static DateTime StartTime, EndTime;
        public string Content;

        private RawInput lists;

        //convertiert string in Jason und andersrum
        public JsonConverter()
        {
        }

        public RawInput Import(string jsonfile)
        {
            lists = JsonConvert.DeserializeObject<RawInput>(jsonfile);
            return lists;
        }

        public void SetGlobalTimes(RawInput lists)
        {
            StartTime = StringToDateTime(lists.StartTime);
            EndTime = StringToDateTime(lists.EndTime);
        }

        public List<Resource> ResourcesGet(RawInput lists)
        {
            return lists.Resources;
        }

        public List<TimeConditions> UnavailableDatesGet(RawInput lists)
        {
            return lists.UnavailableDates;
        }

        public List<Member> MembersGet(RawInput lists) //TODO IMPLEMENT!
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

                    OnceSpans.Add(new Timespan(WriteDateString(min1, hour1, day1, month1, year1), WriteDateString(min2, hour2, day2, month2, year2)));
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

                    OnceSpans.Add(new Timespan(WriteDateString(0, 0, day1, month1, year1), WriteDateString(0, 0, day2, month2, year2)));
                    break;
                case 3:
                    // Read Month
                    month1 = ReadMonth(ParseDate(condition[1])[0]);
                    month2 = ReadMonth(ParseDate(condition[1])[1]);
                    // Read Year
                    year1 = ReadDayOrYear(ParseDate(condition[2])[0]);
                    year2 = ReadDayOrYear(ParseDate(condition[2])[1]);

                    OnceSpans.Add(new Timespan(WriteDateString(0, 0, 0, month1, year1), WriteDateString(0, 0, 0, month2, year2))); // Last-Month does not match
                    break;
                case 2:
                    // Read Year
                    year1 = ReadDayOrYear(ParseDate(condition[1])[0]);
                    year2 = ReadDayOrYear(ParseDate(condition[1])[1]);

                    OnceSpans.Add(new Timespan(WriteDateString(0, 0, 0, 0, year1), WriteDateString(0, 0, 0, 0, year2))); // Last-Month does not match
                    break;
                default:
                    throw new StringToDateConvertException();
            }
        }

        private void SavePermCondition(string[] condition)
        {

            int min1, min2, hour1, hour2, day1, day2, month1, month2, year1, year2;

            // Read Minutes and Hours
            min1 = ReadMinutes(IfEntryIsHashtag(ParseDate(condition[1])[0]));
            min2 = ReadMinutes(IfEntryIsHashtag(ParseDate(condition[1])[1]));
            hour1 = ReadHours(IfEntryIsHashtag(ParseDate(condition[1])[0]));
            hour2 = ReadHours(IfEntryIsHashtag(ParseDate(condition[1])[1]));
            // Read Day
            day1 = ReadDayOrYear(IfEntryIsHashtag(ParseDate(condition[2])[0]));
            day2 = ReadDayOrYear(IfEntryIsHashtag(ParseDate(condition[2])[1]));
            // Read Month
            month1 = ReadMonth(IfEntryIsHashtag(ParseDate(condition[3])[0]));
            month2 = ReadMonth(IfEntryIsHashtag(ParseDate(condition[3])[1]));
            // Read Year
            year1 = ReadDayOrYear(IfEntryIsHashtag(ParseDate(condition[4])[0]));
            year2 = ReadDayOrYear(IfEntryIsHashtag(ParseDate(condition[4])[1]));

            //TO DO DEBUG int -35
            if (year1 != 0 && month1 == 0 && day1 == 0 && hour1 == 0 && min1 == 0 ||
                year1 != 0 && month1 != 0 && day1 == 0 && hour1 == 0 && min1 == 0 ||
                year1 != 0 && month1 != 0 && day1 != 0 && hour1 == 0 && min1 == 0 ||
                year1 != 0 && month1 != 0 && day1 != 0 && hour1 != 0 && min1 != 0)
            {
                throw new InvalidDateException();
            }
            PermSpans.Add(new Timespan(WriteDateString(min1, hour1, day1, month1, year1), WriteDateString(min2, hour2, day2, month2, year2)));
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
            return text.Replace('#', '0');
        }

        public string WriteDateString(int min, int hour, int day, int month, int year)
        {
            return string.Format("{0}:{1}, {2}, {3}, {4}", hour != 0 ? hour : '#', min != 0 ? min : '#', day != 0 ? day : '#', month != 0 ? month : '#', year != 0 ? year : '#');
        }


        public int WriteDateTime(List<List<string>> UnavailableDates)
        {
            for (int i = 0; i < UnavailableDates.Count; i++)
            {
                switch (UnavailableDates.Count)
                {
                    case 1:
                        if (UnavailableDates[i][0].Contains("-") == true)
                        {
                            OneDay(UnavailableDates[i][0]);
                            return 1;
                        }
                        else
                        {
                            GlobalDay(UnavailableDates[i][0]);
                            return 4;
                        }
                        break;
                    case 2:
                        TimeSpan(UnavailableDates[i][0], UnavailableDates[i][1]);
                        return 2;
                        break;
                    case 3:
                        TimeSpanDay(UnavailableDates[i][0], UnavailableDates[i][1], UnavailableDates[i][2]);
                        return 3;
                        break;
                    default:
                        throw new Exception();
                        break;
                }
            }
            return 0;
        }

        private void OneDay(string Date)
        {
            FirstDateTime = StringToDateTime(Date);
        }

        private void TimeSpan(string DateFrom, string DateTo)
        {
            FirstDateTime = StringToDateTime(DateFrom);
            SecondDateTime = StringToDateTime(DateTo);
        }

        private void TimeSpanDay(string DateFrom, string DateTo, string Condition)
        {
            FirstDateTime = StringToDateTime(DateFrom);
            SecondDateTime = StringToDateTime(DateTo);
            Content = Condition;
        }

        private void GlobalDay(string Condition)
        {
            Content = Condition;
        }


        public static DateTime StringToDateTime(string Date)
        {
            string time = "";
            int year = 0001;
            int month = 01;
            int day = 01;

            for (int i = 0; i < Date.Length; i++)
            {
                switch (i)
                {
                    case 4:
                        year = Convert.ToInt32(time);
                        time = "";
                        break;
                    case 7:
                        month = Convert.ToInt32(time);
                        time = "";
                        break;
                    default:
                        time += Date[i];
                        break;
                }
            }
            day = Convert.ToInt32(time);
            time = "";

            return new DateTime(year, month, day);
        }
    }
}
