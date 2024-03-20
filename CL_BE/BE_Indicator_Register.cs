using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Indicator_Register:BE_Audit
    {
        public int IdIndicatorRegister { set; get; }

        public BE_Indicator bE_Indicator;
        public string RegisterDetail { set; get; }
        public int IdStation { set; get; }
        public int IdOperation { set; get; }
        public int IdTank { set; get; }
        public int IdConsole { set; get; }
        public DateTime TransactionDate { set; get; }
        public int TicketNumber { set; get; }
        public int Plate { set; get; }


        //Aditional variables
        public string IndicatorTypeDescription { set; get; }
        public string RegistrationDateString { set; get; }

    }
}
