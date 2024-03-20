using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Error:BE_Audit
    {
        public int IdError { set; get; }
        public string ErrorNumber { set; get; }
        public string ErrorMessage { set; get; }
        public string Comment { set; get; }
        public string SpName { set; get; }

    }
}
