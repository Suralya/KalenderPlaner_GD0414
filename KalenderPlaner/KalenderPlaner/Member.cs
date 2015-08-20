using System;
using System.Collections.Generic;
using System.Globalization;
namespace KalenderPlaner
{
    public class Member
    {
        public string Name;
        public List<Resource> Offer;
        public List<Resource> Demand;
        public List<DateTime> BlockedDays;
        public int Itterations = -1;

        public List<DateTime> Datas;

        public Member(string name, List<Resource> offer, List<Resource> demand, List<DateTime> blockedDays, int itterations)
        {
            Name = name;
            Offer = offer;
            Demand = demand;
            BlockedDays = blockedDays;
            Itterations = itterations;

            Datas = new List<DateTime>();
            Datas.Add(new DateTime(0, 1, 1, new GregorianCalendar())); //TODO DateTime-Factory-Methode hier einsätzen
        }
    }
}
