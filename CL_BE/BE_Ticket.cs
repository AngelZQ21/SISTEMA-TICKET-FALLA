using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Ticket : BE_Audit
    {
        public int IdTicket { get; set; }
        public int IdOperation { get; set; }
        public int IdEncargado { get; set; }
        public int IdRazon { get; set; }
        public int IdCriticidad { get; set; }
        public string TitleDetalle { get; set; }
        public string TitleDescription { get; set; }
        public string DetalleText { get; set; }  
        public string FechaInicio { get; set; }       
        public int IdLocation { get; set; }
        public int ResponsibleId { get; set; }
        public string StatusFile { get; set; }
        public string InvitadoTicket { get; set; }
        public string Cargo { get; set; }
        public string CantidadTicket { get; set; }
        public string CantidadActividades { get; set; }
        public string OldDifferenceDate { get; set; }
        public string StatusCategory { get; set; }
        /*------------------------------------*/
        public string NroTicket { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DifferenceDate { get; set; }
        public string OperationName { get; set; }
        public string FullNameTicket { get; set; }
        public string UsuarioNameTicket { get; set; }
        public string ResponsibleNameTicket { get; set; }
        public string LocationNameTicket { get; set; }
        public string ReasonName { get; set; }
        public string CriticalityName { get; set; }
        public string PersonMail { get; set; }
        public string EmailWhoCall { get; set; }
        public List<BE_Activity> ArrayListadoActividades { get; set; }
        public string StatusTicket { get; set; }
        /*-----------*/
        public int IdActivity { get; set; }
        public int IdActivityTicket { get; set; }
        public string AliasTicket { get; set; }
        public bool ActiveViews { get; set; }
        public string DependencySequence { get; set; }
        public int DependencyMainId { get; set; }
        public string ActivityText { get; set; }
        public string FechaCierre { get; set; }
        public string ReponsibleNameActivity { get; set; }
        public string DetalleCorreo { get; set; }

        public string QuantityTicketEvent { get; set; }
        public string CategoryTicketStatus { get; set; }
        public string ProblemTicket { get; set; }
        public string SolutionTicket { get; set; }
        public string TicketTypeStatus { get; set; }

        /*---------------------------------------------*/
        public string TitleValue { get; set; }
        public string LocationValue { get; set; }
        public string DetailValue { get; set; }
        public string ProblemValue { get; set; }
        public string SolutionValue { get; set; }
        public string  ValidationUserOpId { get; set; }
        public string  DateValidationUserOp { get; set; }
        public string StartHour { get; set; }
        public int WhoCallId { get; set; }
        public string OperationDateString { get; set; }
        public string StartDateTime { get; set; }
        public string OperandDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string ComponentIds { get; set; }
    }
}
