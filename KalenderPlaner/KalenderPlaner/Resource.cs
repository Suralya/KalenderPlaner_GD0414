using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    class Resource
    {
        public string Name;
        public float Value;

        public Resource(string name)
        {
            Name = name;
            Value = 0;
        }
    }
}
