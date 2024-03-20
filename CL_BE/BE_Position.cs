using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Position: BE_Audit
    {
        public int IdPosition { get; set; }
        public string PositionName { get; set; }
    }
}
