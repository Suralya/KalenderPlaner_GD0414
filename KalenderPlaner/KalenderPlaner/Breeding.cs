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
        private static Genome<List<Member>> child1 = new Genome<List<Member>>();
        private static Genome<List<Member>> child2 = new Genome<List<Member>>();

        public static Genome<List<Member>>[] Crossover(Genome<List<Member>> parent1, Genome<List<Member>> parent2)
        {
            child1.Parameter.Clear();
            child2.Parameter.Clear();

            _crossPoint = Rnd.Next(1, parent1.Parameter.Count - 1);

            for (int i = 0; i < parent1.Parameter.Count; i++)
            {
                if (i < _crossPoint)
                {
                    child1.Parameter.Add(parent1.Parameter[i]);
                    child2.Parameter.Add(parent2.Parameter[i]);
                }
                else
                {
                    child1.Parameter.Add(parent2.Parameter[i]);
                    child2.Parameter.Add(parent1.Parameter[i]);
                }
            }

            Genome<List<Member>>[] newGenomes = new Genome<List<Member>>[2];
            newGenomes[0] = child1;
            newGenomes[1] = child2;

            return newGenomes;
        }

        public static Genome<List<Member>> Mutation(Genome<List<Member>> genom)
        {
            child1.Parameter.Clear();
            child2.Parameter.Clear();

            _mutatePoint = Rnd.Next(0, genom.Parameter.Count);
            Member mutation = new Member("NAME", new List<Resource>(), new List<Resource>(), new List<DateTime>());
            child1.Parameter.AddRange(genom.Parameter);

            child1.Parameter.RemoveAt(_mutatePoint);
            child1.Parameter.Insert(_mutatePoint, mutation);

            return child1;
        }
    }
}
