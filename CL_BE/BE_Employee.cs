using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Employee:BE_Audit
    {
        public int IdEmployee { get; set; }
        public BE_Area bE_Area { get; set; }
        public BE_Position bE_Position { get; set; }
        public BE_Person bE_Person { get; set; }
        public BE_Operation bE_Operation { get; set; }

        //Adicionales
        public string FullName { get; set; }
        public string EmployeeMails { get; set; }
    }
}
