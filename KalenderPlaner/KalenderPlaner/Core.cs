using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackpackProblem;
using GeneticAlgorithm;

namespace KalenderPlaner
{
    class Core
    {
        public List<Member> Selection = new List<Member>(); 

        // Jeder Member sucht sich einen wieteren Member etc-( solange bis alle demands an Member gestillt sind ?)- dann sucht sich der Member Zeiten

        //Evolutionärer Algorythmus!!
        //viele Raumwechsle-schlecht// 2member direkt hinterinander-schlecht   .etc

        //Rückgabe einer Liste 

        public Genome<List<Member>> GetMemberGenomes(List<Member> members)
        {
            return new Genome<List<Member>>(members);
        }

        public List<Genome<List<Member>>> GenerateSolutions(int populationSize, List<Member> members)
        {
            var temp = new List<Genome<List<Member>>>();
            for (int i = 0; i < populationSize; i++)
            {
                temp.Add(new Genome<List<Member>>(members));
            }
            return temp;
        }

        public void GenerateRandomMember(int number)
        {
            for (int i = 0; i < number; i++)
            {
                //Member mit zufallswerten füllen
                Selection.Add(new Member());
            }
        }
    }
}
