using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Contratista : BE_Audit
    {

        public int ID { get; set; }
        public string SETID { get; set; }
        public string VENDOR_ID { get; set; }
        public string VNDR_FIELD_C30_F { get; set; }
        public string NAME1 { get; set; }

    }
}
