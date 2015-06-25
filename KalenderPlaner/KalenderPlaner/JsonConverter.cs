using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KalenderPlaner
{
    class JsonConverter
    {
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

    }
}
