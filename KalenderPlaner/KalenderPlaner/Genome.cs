using System.Collections.Generic;
using BackpackProblem;

namespace KalenderPlaner
{
    internal class Genome<T>
    {
        public float Fitness;
        public List<Item> ItemsPicked = new List<Item>();
        public List<Member> MemberPicked = new List<Member>();

        public T Parameter;

        public Genome(T parameter)
        {
            Parameter = parameter;
            Fitness = 0;
        }
    }
}