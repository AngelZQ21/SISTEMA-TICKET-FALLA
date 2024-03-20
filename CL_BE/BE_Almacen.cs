using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Almacen : BE_Audit
    {

        public int Id { get; set; }
        public string BusinessUnit { get; set; }
        public string SetId { get; set; }
        public string Location { get; set; }
        public string Descr { get; set; }
        public string LocationDescr { get; set; }

    }
}
