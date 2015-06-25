using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    public class Resource
    {
        public string Name;
        public float Value;

        public Resource(string name)
        {
            Name = name;
            Value = 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
