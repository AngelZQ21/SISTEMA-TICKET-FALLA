using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Indicator_User : BE_Audit
    {
        public int IdIndicatorUser { get; set; }
        public int IdIndicator { get; set; }
        public string RegisterDetail { get; set; }

        /*Adicional*/
        public string RegistrationUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
