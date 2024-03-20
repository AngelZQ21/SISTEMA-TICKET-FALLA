using CL_BE;
using CL_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BL
{
    public class BL_ReportListTicketActivity
    {
        public List<BE_Grafic_Value> ListTicketXActivityDate(string fechaInicio, string fechaFin)
        {
            var listaResultado = new List<BE_Grafic_Value>();
            try
            {
                listaResultado = new DA_ReportListTicketActivity().ListTicketXActivityDate(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public List<BE_Grafic_Value> ListTicketXActivityDate2(string fechaInicio, string fechaFin)
        {
            var listaResultado = new List<BE_Grafic_Value>();
            try
            {
                listaResultado = new DA_ReportListTicketActivity().ListTicketXActivityDate2(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
                bE_Grafic_Value.ValorConsulta = "0";
                bE_Grafic_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Grafic_Value);
            }
            return listaResultado;
        }

        public List<BE_Ticket> ListarTicket(string StatusBar, string FilterDate)
        {
            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_ReportListTicketActivity().ListarTicket(StatusBar, FilterDate);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Ticket bE_Ticket = new BE_Ticket();
                bE_Ticket.ValorConsulta = "0";
                bE_Ticket.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Ticket);
            }
            return listaResultado;
        }

        public List<BE_Activity> ListarActivity(string StatusBar, string FilterDate)
        {
            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_ReportListTicketActivity().ListarActivity(StatusBar, FilterDate);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);
            }
            return listaResultado;
        }
    }
}
