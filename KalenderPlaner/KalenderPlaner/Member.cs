using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    public class Member
    {
        public string Name;
        public List<Resource> Offer;
        public List<Resource> Demand;
        public List<TimeConditions> Constrains;

        public Member()
        {
            Offer = new List<Resource>();
            Demand = new List<Resource>();
            Constrains = new List<TimeConditions>();
        }
    }
}
