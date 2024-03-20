using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Activity : BE_Audit
    {
        /* -TICKET VALUE- */
        public string NumberTicket { get; set; }
        public string StatusTicket { get; set; }
        public int IdTicket { get; set; }
        public string NroTicket { get; set; }
        public string OperationName { get; set; }
        public string TitleDescription { get; set; }       
        public int IdResponsible { get; set; }
        public int IdResponsibleActivity { get; set; }
        public string PersonMail { get; set; }
        public string Invitado { get; set; }
        public string FullNameActivity { get; set; }
        public string DescripcionActivity { get; set; }
        /*public string NroTicket { get; set; }*/
        public string StartDate { get; set; }
        //public string OperationName { get; set; }
        public string FullNameTicket { get; set; }
        public string UsuarioNameTicket { get; set; }
        public string ResponsibleNameTicket { get; set; }
        public string LocationNameTicket { get; set; }
        public string ReasonName { get; set; }
        public string CriticalityName { get; set; }
        public string DetalleText { get; set; }
        public string OldDifferenceDate { get; set; }     
        
        /* -ACTIVITY VALUE- */
        public int IdActivity { get; set; }
        public int CantidadActividad { get; set; }
        public string ActivityText { get; set; }
        public string FechaCierre { get; set; }
        public string Estado { get; set; }

        /* ACTIVITY - DETAIL VALUE-*/
        public int IdActivityDetail { get; set; }
        public string PercentageNumber { get; set; }
        public int PercentageNumberEntero { get; set; }
        public string ValidationButton { get; set; }
        public int ResponsibleTicket { get; set; }
        public string StatusActivity { get; set; }
        public string ResponsibleActivity { get; set; }
        public int ResponsibleId { get; set; }

        public string OperationAlias { get; set; }
        public string CodeColorOperation { get; set; }

        public string IdPerson { get; set; }
        public string PersonAlias { get; set; }

        public string DescriptionBoard { get; set; }

        /*-----------------------------*/

        public int IdActivityFiles { get; set; }
        public string TituloInforme { get; set; }
        public string NameParaQuienInforme { get; set; }
        public string AsuntoInforme { get; set; }
        public string OperacionNombre { get; set; }
        public string FechaRegistroInforme { get; set; }
        public string AntecedentesInforme { get; set; }
        public string ConclusionesInforme { get; set; }
        public string ReportRecommendations { get; set; }
        public string ActivityDevelopInforme { get; set; }
        public string TipoArchivo { get; set; }
        public string PathFile { get; set; }

        public string ValueActivity { get; set; }
        public string ValueFilesTicket { get; set; }
        public string ValuesComponents { get; set; }

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
        public string ValidationUserOpId { get; set; }
        public string DateValidationUserOp { get; set; }
        public string StartHour { get; set; }
        public int WhoCallId { get; set; }

        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string ComponentIds { get; set; }
        public string TitleDetalle { get; set; }
    }
}
