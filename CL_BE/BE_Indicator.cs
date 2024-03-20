using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Indicator:BE_Audit
    {
        public BE_Indicator_Navigation bE_Indicator_Navigation;
        public BE_Indicator_Type bE_Indicator_Type;
        public BE_Indicator_User bE_Indicator_User;
        public int IdIndicator { set; get; }
        public string IndicatorType { set; get; }
        public string IndicatorCode { set; get; }
        public string IndicatorDescription { set; get; }

        public int IndicatorsQuantity { get; set; }
        public string IndicatorTypeDescription { get; set; }
        public int IndicatorsCodeQuantity { get; set; }
        public string IndicatorCodeDescription { get; set; }

        /*OTROS*/
        public string BackDay { get; set; }
        public string CurrentDay { get; set; }
    }
}
