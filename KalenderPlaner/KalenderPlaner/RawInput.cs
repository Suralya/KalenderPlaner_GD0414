using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    [Serializable]
    public class RawInput
    {
        public int CurrentYear;
        public List<Resource> Resources;
        public List<TimeConditions> UnavailableDates;
        public List<Member> MemberList;
    }
}
