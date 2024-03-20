using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Indicator_Type : BE_Audit
    {
        public int IdIndicatorType { get; set; }
        public string IndicatorTypeCode { get; set; }
        public string IndicatorTypeDescription { get; set; }
    }
}
