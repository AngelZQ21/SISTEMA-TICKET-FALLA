using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Restriction : BE_Audit
    {
        public int IdRestriction { get; set; }
        public string RestrictionName { get; set; }
        public string RestrictionTable { get; set; }
        public string RestrictionTableDesc { get; set; }
        public string RestrictionColumn { get; set; }
        public string OldColumnName { get; set; }

        /*Otros*/
        public int IdValidationMap { get; set; }
        public string ValidationDescription { get; set; }
        public string Status { get; set; }
    }
}
