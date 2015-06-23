using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KalenderPlaner
{
    class JsonInterface
    {

        public static RawInput Import(string jsonfile)
        {
            RawInput lists = JsonConvert.DeserializeObject<RawInput>(jsonfile);
            return lists;
        }

        public static List<Resource> ResourcesGet(RawInput lists)
        {
            return lists.Resources;
        }

        public static List<TimeConditions> UnavailableDatesGet(RawInput lists)
        {
            return lists.UnavailableDates;
        }

        public static List<Member> MembersGet(RawInput lists)
        {
            return lists.MemberList;
        }

    }
}