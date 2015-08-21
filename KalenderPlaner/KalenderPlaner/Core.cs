using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm;

namespace KalenderPlaner
{
    class Core
    {
        
        /*private double _crossoverProbability = 0.8;
        private double _mutationProbability = 0.1;
        private int _populationSize = 100;
        private int _generationCount = 500; */
        private static List<Member> _members; 
        private static readonly Random Random = new Random();
        private static List<DateTime> _blockedDays; 

        public Core(/*double crossoverProbability, double mutationProbability, int populationSize, int generationCount,*/ List<Member> members, List<DateTime> blockedDays)
        {
            /*_crossoverProbability = crossoverProbability;
            _mutationProbability = mutationProbability;
            _populationSize = populationSize;
            _generationCount = generationCount; */
            _blockedDays = blockedDays;
            _members = members;
        }

        public List<Member> Selection;


        // Jeder Member sucht sich einen wieteren Member etc-( solange bis alle demands an Member gestillt sind ?)- dann sucht sich der Member Zeiten

        //Evolutionärer Algorythmus!!
        //viele Raumwechsle-schlecht// 2member direkt hinterinander-schlecht   .etc

        //Rückgabe einer Liste 


        /*public Genome<Member> Generate()
        {
            //var algorithm = new MainAlgorithm<Member>(_crossoverProbability, _mutationProbability, _populationSize,
            //    _generationCount , FitnessFunction.CalculateFitness, Breeding.Crossover, Breeding.Mutation);

            //var temp = GenerateSolutions(Selection);

            //return algorithm.Evolve(new List<Genome<Member>>()); //TODO: algorithm aufräumen, schmeißt Fehler da Übergaben fehlen/unsinnig sind
            return new Genome<Member>();
        } */

        /*public List<Genome<List<Member>>> GenerateSolutions(List<Member> members)
        {
            var firstGeneration = new List<Genome<List<Member>>>();
            for (int i = 0; i < _populationSize; i++)
            {
                List<Member> randomGen = RandomMembersAtTime(_members);
                firstGeneration.Add(new Genome<List<Member>>(randomGen));
            }
            return firstGeneration;
        } */

        public static List<Member> RandomMembersAtTime()
        {
            return RandomMembersAtTime(_members);
        }
        public static List<Member> RandomMembersAtTime(List<Member> members)
        {
            List<Member> tempMembers = members.Select(member => new Member(member)).ToList();
            tempMembers.ForEach(i => i.Dates.Clear());
            foreach (Member member in tempMembers)
            {
                //For all DemandMember
                if (member.Itterations > 0)
                {
                    for (int i = 0; i < member.Itterations; i++)
                    {
                        DateTime tmp;
                        do
                        {
                            tmp = GetRandomDate(JsonConverter.StartTime, JsonConverter.EndTime);
                        } while (member.BlockedDays.Any(k => k == tmp) && _blockedDays.Any(l => l == tmp));

                        //Adding Random Day in Datas for Itterations
                        member.Dates.Add(tmp);
                    }
                }
                //For all OfferMember
                else
                {
                    for (int i = 0; i < NumberOfDays(JsonConverter.StartTime, JsonConverter.EndTime); i++)
                    {
                        DateTime tmp;
                        do
                        {
                            tmp = GetRandomDate(JsonConverter.StartTime, JsonConverter.EndTime);
                        } while (member.BlockedDays.Any(k => k == tmp) && _blockedDays.Any(l => l == tmp));

                        //Adding Random Day in Datas for Random Anzahl der Kalenders
                        member.Dates.Add(tmp);
                    }
                }
            }
            return tempMembers;
        }

        public static Member RandomizeDatesAtMember(Member member)
        {
            member.Dates.Clear();
            //For all DemandMember
            if (member.Itterations > 0)
            {
                for (int i = 0; i < member.Itterations; i++)
                {
                    DateTime tmp;
                    do
                    {
                        tmp = GetRandomDate(JsonConverter.StartTime, JsonConverter.EndTime);
                    } while (member.BlockedDays.Any(k => k == tmp) && _blockedDays.Any(l => l == tmp));

                    //Adding Random Day in Datas for Itterations
                    member.Dates.Add(tmp);
                }
            }
                //For all OfferMember
            else
            {
                for (int i = 0; i < NumberOfDays(JsonConverter.StartTime, JsonConverter.EndTime); i++)
                {
                    DateTime tmp;
                    do
                    {
                        tmp = GetRandomDate(JsonConverter.StartTime, JsonConverter.EndTime);
                    } while (member.BlockedDays.Any(k => k == tmp) && _blockedDays.Any(l => l == tmp));

                    //Adding Random Day in Datas for Random Anzahl der Kalenders
                    member.Dates.Add(tmp);
                }
                
            }
            return member;
        }

        private static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(Random.NextDouble() * range.Ticks));

            DateTime temp = from + randTimeSpan;

            DateTime outTime = new DateTime(temp.Year, temp.Month, temp.Day);

            return outTime;
        }

        private static int NumberOfDays(DateTime from, DateTime to)
        {
            int tmp = 0;
            if (from.Day >= to.Day)
                return tmp;
            while (from.Day != to.Day && from.Day < to.Day)
            {
                from = from.AddDays(1);
                tmp++;
            }
            return tmp;
        }
    }
}
