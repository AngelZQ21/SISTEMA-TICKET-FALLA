using CL_BE;
using CL_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class ListGeneralActivityController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VlistGeneralActivity()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "ListGeneralActivity", "VlistGeneralActivity");

                if (Valicacion == "1")
                {
                    return View();
                }
                else
                {
                    TempData["MsgTmp"] = "Validacion retornada " + Valicacion;
                    return RedirectToAction("Vnoautorizado", "Error");
                }
            }
            catch (Exception e)
            {
                TempData["MsgTmp"] = "Validacion retornada " + e.Message;
                return RedirectToAction("Login", "Account");
            }
        }

        public JsonResult ListarGeneralActivity()
        {
            BE_Activity bE_Ticket = new BE_Activity();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_ListGeneralActivity().ListarGeneralActivity();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketYResponsableGraphic(string StatusTicket0, string ResponsibleId0, string EventFilterTicket)
        {
            BE_Activity bE_Ticket = new BE_Activity();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_ListGeneralActivity().ListarTicketYResponsableGraphic(StatusTicket0, ResponsibleId0, EventFilterTicket);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarUserActivitiesGraphic()
        {
            BE_Activity bE_Activity = new BE_Activity();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            var RegistrationUserX = Convert.ToInt32(usuario[0]);



            var lista = new BL_ListGeneralActivity().ListarUserActivitiesGraphic(RegistrationUserX);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListDetalleTicketResponsible(string TicketNumber)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_ListGeneralActivity().ListDetalleTicketResponsible(TicketNumber);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarArchivosDeActividades(int IdTicket)
        {

            var lista = new BL_ListGeneralActivity().ListarArchivosDeActividades(IdTicket);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTodosArchivosDeActividades(int IdTicket, string RadioFile)
        {

            var lista = new BL_ListGeneralActivity().ListarTodosArchivosDeActividades(IdTicket, RadioFile);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

    }
}