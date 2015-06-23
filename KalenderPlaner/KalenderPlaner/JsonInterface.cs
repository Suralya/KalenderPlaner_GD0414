using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KalenderPlaner
{
    class JsonInterface
    {

        public static void Import(string jsonfile)
        {
            RawInput Lists = JsonConvert.DeserializeObject<RawInput>(jsonfile);
        }

    }
}