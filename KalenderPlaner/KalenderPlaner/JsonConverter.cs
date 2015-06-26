using System;
using System.Collections.Generic;
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


        public void SaveTimeCondition(string conditions)
        {
            string[] tempCond = conditions.Split(',');
            if (tempCond.Length <= 1)
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
            for (int i = 1; i < condition.Length; i++)
            {
                switch (condition.Length)
                {
                    case 5:

                    case 4:

                    case 3:

                    case 2:

                    default:
                        throw new StringToDateConvertException();
                        break;
                }
            }
        }

        private void SavePermCondition(string[] condition)
        {
            throw new NotImplementedException();
        }
    }
}
