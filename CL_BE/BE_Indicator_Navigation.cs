using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Indicator_Navigation:BE_Audit
    {
        public BE_Indicator bE_indicator;
        public BE_Profile_Indicator bE_Profile_Indicator;
        public BE_Indicator_Answer bE_Indicator_Answer;
        public int IndicatorsQuantity { set; get; }
        public int AlertQuantity { set; get; }
        public int NotificationQuantity { set; get; }

        public int totalIndicatorQuantity { set; get; }
    }
}
