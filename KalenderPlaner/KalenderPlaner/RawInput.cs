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
        public List<string> UnavailableDatesStrings;

        [JsonIgnore]
        public List<DateTime> UnavailableDates;
        public List<Member> MemberList;

        public RawInput()
        {
            Resources = new List<Resource>();
            UnavailableDatesStrings = new List<string>();
            MemberList = new List<Member>();

            UnavailableDates = new List<DateTime>();
        }
    }
}
