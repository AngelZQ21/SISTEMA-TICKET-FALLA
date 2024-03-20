using CL_BE;
using CL_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BL
{
    public class BL_Activity
    {
        public List<BE_Activity> CrearActivity(BE_Activity bE_Activity)
        {
            //var listaResultado = "";
            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().CrearTicket(bE_Activity);
            }
            catch (Exception ex)
            {

                //listaResultado = ex.Message;
                listaResultado.Clear();
                //BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);

            }

            return listaResultado;
        }

        public List<BE_Activity> EditarActivity(BE_Activity bE_Activity)
        {
            //var listaResultado = "";
            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().EditarActivity(bE_Activity);
            }
            catch (Exception ex)
            {

                //listaResultado = ex.Message;
                listaResultado.Clear();
                //BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);

            }

            return listaResultado;
        }

        public List<BE_Board> ActualizarRegistrarVitacora(BE_Board bE_Board)
        {
            //var listaResultado = "";
            var listaResultado = new List<BE_Board>();
            try
            {
                listaResultado = new DA_Activity().ActualizarRegistrarVitacora(bE_Board);
            }
            catch (Exception ex)
            {

                //listaResultado = ex.Message;
                //listaResultado.Clear();
                //BE_Board bE_Board = new BE_Board();
                bE_Board.ValorConsulta = "0";
                bE_Board.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Board);

            }

            return listaResultado;
        }

        public List<BE_Board> ActualizarRegistrarVitacoraActivityDetail(BE_Board bE_Board)
        {
            //var listaResultado = "";
            var listaResultado = new List<BE_Board>();
            try
            {
                listaResultado = new DA_Activity().ActualizarRegistrarVitacoraActivityDetail(bE_Board);
            }
            catch (Exception ex)
            {

                //listaResultado = ex.Message;
                //listaResultado.Clear();
                //BE_Board bE_Board = new BE_Board();
                bE_Board.ValorConsulta = "0";
                bE_Board.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Board);

            }

            return listaResultado;
        }

        public List<BE_Activity> ListarActivityCreado(string NroTicket, int RegistrationUser)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().ListarActivityCreado(NroTicket , RegistrationUser);
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

        public List<BE_Activity> ListarActivityCreadoUsuario(string NroTicket, int RegistrationUser)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().ListarActivityCreadoUsuario(NroTicket, RegistrationUser);
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

        public List<BE_Activity> ListarActivityExpirationbDash(string NroTicket, int RegistrationUser, string StatusCategory)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().ListarActivityExpirationbDash(NroTicket, RegistrationUser, StatusCategory);
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

        public List<BE_Activity> ListarActivityToTicketToAct(int IdTicket)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().ListarActivityToTicketToAct(IdTicket);
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

        public List<BE_Activity> ListarActivityToTicketToActPendiente(int IdTicket, int RegistrationUser)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().ListarActivityToTicketToActPendiente(IdTicket, RegistrationUser);
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

        public List<BE_Activity> ListarActivityToTicketToActCompletado(int IdTicket, int RegistrationUser)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().ListarActivityToTicketToActCompletado(IdTicket, RegistrationUser);
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

        public List<BE_Activity> ListarActivityCreadoDASH(string NroTicket, int RegistrationUser)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().ListarActivityCreadoDASH(NroTicket, RegistrationUser);
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

        public List<BE_Activity> ListarActivityBusqueda(string NroTicket, int RegistrationUser)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().ListarActivityBusqueda(NroTicket, RegistrationUser);
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

        public List<BE_Activity> ListarActividadesCompletadas(string StartDate, string EndDate, string IdUsuarios, int RegistrationUser)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().ListarActividadesCompletadas(StartDate, EndDate, IdUsuarios, RegistrationUser);
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

        public List<BE_Board> ListarDescriptionVitacora(string NroTicket, int RegistrationUser)
        {

            var listaResultado = new List<BE_Board>();
            try
            {
                listaResultado = new DA_Activity().ListarDescriptionVitacora(NroTicket , RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Board bE_Board = new BE_Board();
                bE_Board.ValorConsulta = "0";
                bE_Board.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Board);
            }
            return listaResultado;
        }

        public List<BE_Board> ListarDescriptionVitacoraActivityDetail(int IdActivity, int RegistrationUser)
        {


            var listaResultado = new List<BE_Board>();
            try
            {
                listaResultado = new DA_Activity().ListarDescriptionVitacoraActivityDetail(IdActivity, RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Board bE_Board = new BE_Board();
                bE_Board.ValorConsulta = "0";
                bE_Board.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Board);
            }
            return listaResultado;
        }

        public List<BE_Activity> ListarActividadesTodas(int RegistrationUser,int IdPerson, string StatusCategory)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().ListarActividadesTodas(RegistrationUser, IdPerson, StatusCategory);
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

        public string ListValidationActivity(int IdActivity)
        {

            var resultado = "";
            try
            {
                resultado = new DA_Activity().ListValidationActivity(IdActivity);
            }
            catch (Exception ex)
            {
                 resultado = ex.Message;
                //listaResultado.Clear();
                //BE_Activity bE_Activity = new BE_Activity();
                //bE_Activity.ValorConsulta = "0";
                //bE_Activity.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_Activity);
            }
            return resultado;
        }

        public List<BE_Activity> ListarActividadesCompletas(int RegistrationUser, string StatusCategory)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().ListarActividadesCompletas(RegistrationUser, StatusCategory);
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

        public string CrearReportActivityDetail(BE_ActivityDetail bE_ActivityDetail)
        {
            var listaResultado = "";
            //var listaResultado = new List<BE_ActivityDetail>();
            try
            {
                listaResultado = new DA_Activity().CrearReportActivityDetail(bE_ActivityDetail);
            }
            catch (Exception ex)
            {

                listaResultado = ex.Message;
                //listaResultado.Clear();
                //BE_ActivityDetail bE_ActivityDetail = new BE_ActivityDetail();
                //bE_ActivityDetail.ValorConsulta = "0";
                //bE_ActivityDetail.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_ActivityDetail);

            }

            return listaResultado;
        }

        public string EditarReportActivityDetail(BE_ActivityDetail bE_ActivityDetail)
        {
            var listaResultado = "";
            //var listaResultado = new List<BE_ActivityDetail>();
            try
            {
                listaResultado = new DA_Activity().EditarReportActivityDetail(bE_ActivityDetail);
            }
            catch (Exception ex)
            {

                listaResultado = ex.Message;
                //listaResultado.Clear();
                //BE_ActivityDetail bE_ActivityDetail = new BE_ActivityDetail();
                //bE_ActivityDetail.ValorConsulta = "0";
                //bE_ActivityDetail.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_ActivityDetail);

            }

            return listaResultado;
        }

        public string EditPercentageActivity(BE_Activity bE_Activity)
        {
            var listaResultado = "";
            //var listaResultado = new List<BE_ActivityDetail>();
            try
            {
                listaResultado = new DA_Activity().EditPercentageActivity(bE_Activity);
            }
            catch (Exception ex)
            {

                listaResultado = ex.Message;
                //listaResultado.Clear();
                //BE_ActivityDetail bE_ActivityDetail = new BE_ActivityDetail();
                //bE_ActivityDetail.ValorConsulta = "0";
                //bE_ActivityDetail.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_ActivityDetail);

            }

            return listaResultado;
        }

        public string ValidationEnableActivity(BE_Activity bE_Activity)
        {
            var listaResultado = "";
            //var listaResultado = new List<BE_ActivityDetail>();
            try
            {
                listaResultado = new DA_Activity().ValidationEnableActivity(bE_Activity);
            }
            catch (Exception ex)
            {

                listaResultado = ex.Message;
                //listaResultado.Clear();
                //BE_ActivityDetail bE_ActivityDetail = new BE_ActivityDetail();
                //bE_ActivityDetail.ValorConsulta = "0";
                //bE_ActivityDetail.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_ActivityDetail);

            }

            return listaResultado;
        }

        public string EliminarActivityDetail(int IdActivityDetail, int RegistrationUser)
        {
            var listaResultado = "";

            try
            {
                listaResultado = new DA_Activity().EliminarActivityDetail(IdActivityDetail,RegistrationUser);
            }
            catch (Exception ex)
            {

                listaResultado = ex.Message;
            }

            return listaResultado;
        }

        public string ActivityFinish(BE_Activity bE_Activity)
        {
            var listaResultado = "";
            //var listaResultado = new List<BE_ActivityDetail>();
            try
            {
                listaResultado = new DA_Activity().ActivityFinish(bE_Activity);
            }
            catch (Exception ex)
            {

                listaResultado = ex.Message;
                //listaResultado.Clear();
                //BE_ActivityDetail bE_ActivityDetail = new BE_ActivityDetail();
                //bE_ActivityDetail.ValorConsulta = "0";
                //bE_ActivityDetail.MensajeConsulta = ex.Message;
                //listaResultado.Add(bE_ActivityDetail);

            }

            return listaResultado;
        }

        public List<BE_Activity> StatusActivities(int IdTicket)
        {
            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_Activity().StatusActivities(IdTicket);
            }
            catch (Exception ex)
            {

                //listaResultado = ex.Message;
                listaResultado.Clear();
                BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);

            }

            return listaResultado;
        }

        public List<BE_ActivityDetail> ListarInformeDetalleActivity(BE_ActivityDetail bE_ActivityDetail)
        {

            var listaResultado = new List<BE_ActivityDetail>();
            try
            {
                listaResultado = new DA_Activity().ListarInformeDetalleActivity(bE_ActivityDetail);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                //BE_ActivityDetail bE_ActivityDetail = new BE_ActivityDetail();
                bE_ActivityDetail.ValorConsulta = "0";
                bE_ActivityDetail.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_ActivityDetail);
            }
            return listaResultado;
        }

        public String ChangeStatus(int IdActivity, string Comentario, int RegistrationUser)
        {
            var listaResultado = "";
            try
            {
                listaResultado = new DA_Activity().ChangeStatus(IdActivity, Comentario, RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado = ex.Message;
            }
            return listaResultado;
        }
    }
}
