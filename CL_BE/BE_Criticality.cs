using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Criticality : BE_Audit
    {
        public int IdCriticality { get; set; }
        public string CriticalityNameTime { get; set; }
    }
}
