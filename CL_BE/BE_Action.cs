using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Action:BE_Audit
    {
        public int IdAction { set; get; }
        public string ActionName { set; get; }
    }
}
