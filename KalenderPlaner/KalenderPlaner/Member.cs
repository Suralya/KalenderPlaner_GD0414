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
        public int Itterations;

        public List<DateTime> Dates;

        public Member(string name, List<Resource> offer, List<Resource> demand, List<DateTime> blockedDays, int itterations)
        {
            Name = name;
            Offer = offer;
            Demand = demand;
            BlockedDays = blockedDays;
            Itterations = itterations;

            Dates = new List<DateTime> { new DateTime(1, 1, 1, new GregorianCalendar()) }; //TODO DateTime-Factory-Methode hier einsätzen
        }

        public Member()
        {

        }

        public Member(string name, List<Resource> offer, List<Resource> demand, List<DateTime> blockedDays) : this(name, offer, demand, blockedDays, -1) { }
    }
}
