using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm;

namespace KalenderPlaner
{
    class Core
    {
        
        private double _crossoverProbability = 0.8;
        private double _mutationProbability = 0.1;
        private int _populationSize = 100;
        private int _generationCount = 500;
        private List<Member> _members; 
        private static readonly Random Random = new Random();
        private DateTime _firstDay, _lastDay; //TODO FÜLLEN!!!!!!!!!!

        public Core(double crossoverProbability, double mutationProbability, int populationSize, int generationCount, JsonConverter jsonConverter, RawInput rawInput)
        {
            _crossoverProbability = crossoverProbability;
            _mutationProbability = mutationProbability;
            _populationSize = populationSize;
            _generationCount = generationCount;
            _members = jsonConverter.MembersGet(rawInput);
        }

        public List<Member> Selection;


        // Jeder Member sucht sich einen wieteren Member etc-( solange bis alle demands an Member gestillt sind ?)- dann sucht sich der Member Zeiten

        //Evolutionärer Algorythmus!!
        //viele Raumwechsle-schlecht// 2member direkt hinterinander-schlecht   .etc

        //Rückgabe einer Liste 


        public Genome<Member> Generate()
        {
            var algorithm = new MainAlgorithm<Member>(_crossoverProbability, _mutationProbability, _populationSize,
                _generationCount, FitnessFunction.CalculateFitness, Breeding.Crossover, Breeding.Mutation);

            var temp = GenerateSolutions(Selection);

            return algorithm.Evolve(new List<Genome<Member>>()); //WTF ?
        }

        public List<Genome<List<Member>>> GenerateSolutions(List<Member> members)
        {
            var firstGeneration = new List<Genome<List<Member>>>();
            for (int i = 0; i < _populationSize; i++)
            {
                List<Member> randomGen = RandomMembersAtTime(_members);
                firstGeneration.Add(new Genome<List<Member>>(randomGen));
            }
            return firstGeneration;
        }

        private List<Member> RandomMembersAtTime(List<Member> members)
        {
            foreach (Member member in members)
            {
                //For all DemandMember
                if (member.Itterations > 0)
                {
                    for (int i = 0; i < member.Itterations; i++)
                    {
                        DateTime tmp;
                        do
                        {
                            tmp = GetRandomDate(_firstDay, _lastDay);
                        } while (member.BlockedDays.Any(k => k == tmp));

                        //Adding Random Day in Datas for Itterations
                        member.Datas.Add(tmp);
                    }
                }
                //For all OfferMember
                else
                {
                    for (int i = 0; i < NumberOfDays(_firstDay, _lastDay); i++)
                    {
                        DateTime tmp;
                        do
                        {

                            tmp = GetRandomDate(_firstDay, _lastDay);
                        } while (member.BlockedDays.Any(k => k == tmp));

                        //Adding Random Day in Datas for Random Anzahl der Kalenders
                        member.Datas.Add(tmp);
                    }
                }
            }
            return members;
        }
        private static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(Random.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }

        private static int NumberOfDays(DateTime from, DateTime to)
        {
            int tmp = 0;
            if (from.Day >= to.Day)
                return tmp;
            while (from.Day != to.Day)
            {
                from.AddDays(1);
                tmp++;
            }
            return tmp;
        }
    }
}
