using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm;

namespace KalenderPlaner
{
    internal static class FitnessFunction
    {
        public static void CalculateFitness(Genome<List<Member>> Genom)
        {
            foreach (Member member in Genom.Parameter)
            {
                List<DateTime> tempList = member.Dates.Distinct().ToList();
                Genom.Fitness = (tempList.Count == member.Dates.Count) ? + 10 : Genom.Fitness;


                foreach (DateTime time in tempList)
                {
                    if (member.Demand != null)
                    {
                        foreach (Resource demand in member.Demand)
                        {
                            foreach (Member offerMember in Genom.Parameter)
                            {
                                if (offerMember.Dates.Any(a => a == time))
                                {
                                    foreach (Resource offer in offerMember.Offer)
                                    {
                                       Genom.Fitness = (offer == demand)  ? +10 : Genom.Fitness; 

                                    }
                                }

                            }

                        }
                    }

                }


            }


        }
    }
}
