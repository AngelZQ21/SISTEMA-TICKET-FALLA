using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Profile:BE_Audit
    {
        public int IdProfile { set; get; }
        public string ProfileName { set; get; }
        public int MaxAttempts { set; get; }
    }
}
