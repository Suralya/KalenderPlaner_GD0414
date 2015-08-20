using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    internal static class Breeding
    {
        private static readonly Random Rnd = new Random();

        private static int _crossPoint;
        private static int _mutatePoint;
        private static int _child1;
        private static int _child2;

        public static Member[] Crossover(Genome<Member> parent1, Genome<Member> parent2)
        {
            return new Member[0];
        }

        public static Member Mutation(Genome<Member> genom)
        {
            return new Member("NAME", new List<Resource>(), new List<Resource>(), new List<DateTime>());
        }
    }
}
