using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Grafic_Value : BE_Audit
    {

        public int ActivityQuantity { get; set; }
        public string OperationName { get; set; }
        public int TicketQuantity { get; set; }
        public string NumberTicket { get; set; }
        /*---------------------------------------*/
        public int NumberPercentage { get; set; }
        public string ResponsibleName { get; set; }
        public int ResponsibleId { get; set; }

        /*------- GRAPHIC COLUMN BAR -----------*/

        public int CantidadTicketPendiente { get; set; }
        public int CantidadTicketCompletado { get; set; }

        public int CantidadActivityPendiente { get; set; }
        public int CantidadActivityCompletado { get; set; }
        public string FechaCreacion { get; set; }

        /*--------------------------------------*/
        public int IdTicket { get; set; }
        public int QuantityValue { get; set; }
        public string ColumnValue { get; set; }
        public int DifferenceDays { get; set; }
        public string Statusticket { get; set; }
        public string TitleDescription { get; set; }
        public string StartDate { get; set; }

        /*----------------------------------------*/
        public string CalendarMonthName { get; set; }

        public string Pendiente { get; set; }
        public string Operando { get; set; }
        public string Completado { get; set; }
        public int DifferenceFirst { get; set; }
        public int DifferenceSecond { get; set; }
        public string FechaValue { get; set; }
        public string StatusTicket { get; set; }
        public string DataType { get; set; }
    }
}
