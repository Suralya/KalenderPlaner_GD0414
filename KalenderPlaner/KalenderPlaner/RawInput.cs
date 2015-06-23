using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    class RawInput
    {
        public List<Resource> Resources { get; set; }
        public List<TimeConditions> UnavailableDates { get; set; }
        public List<Member> MemberList { get; set; }
    }
}
