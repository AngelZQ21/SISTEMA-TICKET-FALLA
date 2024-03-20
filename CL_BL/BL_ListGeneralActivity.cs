using CL_BE;
using CL_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BL
{
    public class BL_ListGeneralActivity
    {
        public List<BE_Activity> ListarGeneralActivity()
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_ListGeneralActivity().ListarGeneralActivity();
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

        public List<BE_Activity> ListarTicketYResponsableGraphic(string StatusTicket0, string ResponsibleId0, string EventFilterTicket)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_ListGeneralActivity().ListarTicketYResponsableGraphic(StatusTicket0, ResponsibleId0, EventFilterTicket);
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

        public List<BE_Activity> ListarUserActivitiesGraphic(int RegistrationUserX)
        {

            var listaResultado = new List<BE_Activity>();

            try
            {
                listaResultado = new DA_ListGeneralActivity().ListarUserActivitiesGraphic(RegistrationUserX);
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

        public List<BE_Ticket> ListDetalleTicketResponsible(string TicketNumber)
        {

            var listaResultado = new List<BE_Ticket>();
            try
            {
                listaResultado = new DA_ListGeneralActivity().ListDetalleTicketResponsible(TicketNumber);
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

        public List<BE_Activity> ListarArchivosDeActividades(int IdTicket)
        {

            var listaResultado = new List<BE_Activity>();

            try
            {
                listaResultado = new DA_ListGeneralActivity().ListarArchivosDeActividades(IdTicket);
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

        public List<BE_Activity> ListarTodosArchivosDeActividades(int IdTicket, string RadioFile)
        {

            var listaResultado = new List<BE_Activity>();

            try
            {
                listaResultado = new DA_ListGeneralActivity().ListarTodosArchivosDeActividades(IdTicket, RadioFile);
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
