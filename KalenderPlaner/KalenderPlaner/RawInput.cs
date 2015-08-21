using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KalenderPlaner
{
    [Serializable]
    public class RawInput
    {
        public string StartTime, EndTime;
        public List<Resource> Resources;
        public int Length;
        public string[] UnavailableDatesStrings;

        [JsonIgnore]
        public List<DateTime> UnavailableDates;
        public List<Member> MemberList;

        public RawInput()
        {
            Resources = new List<Resource>();
            UnavailableDatesStrings = new string[Length];
            MemberList = new List<Member>();

            UnavailableDates = new List<DateTime>();
        }
    }
}
