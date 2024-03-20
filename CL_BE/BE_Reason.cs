using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Reason : BE_Audit
    {
        public int IdReason { get; set; }
        public string ReasonName { get; set; }
    }
}
