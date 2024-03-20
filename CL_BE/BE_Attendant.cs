using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Attendant:BE_Audit
    {
        public int IdAttendant { set; get; }
        public int IdStation { set; get; }
        public int IdOperator { set; get; }
        public string AttendantKey { set; get; }
        public string AttendantName { set; get; }

    }
}
