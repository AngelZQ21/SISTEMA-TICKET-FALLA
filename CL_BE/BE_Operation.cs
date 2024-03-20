using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Operation:BE_Audit
    {
        public int IdOperation { get; set; }
        public string OperationName { get; set; }
    }
}
