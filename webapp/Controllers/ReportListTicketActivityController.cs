using CL_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class ReportListTicketActivityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VreportListTicketActivity()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "ReportListTicketActivity", "VreportListTicketActivity");

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

        public JsonResult ListTicketXActivityDate(string fechaInicio, string fechaFin)
        {
            var lista = new BL_ReportListTicketActivity().ListTicketXActivityDate(fechaInicio, fechaFin);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListTicketXActivityDate2(string fechaInicio, string fechaFin)
        {
            var lista = new BL_ReportListTicketActivity().ListTicketXActivityDate2(fechaInicio, fechaFin);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicket(string StatusBar, string FilterDate)
        {
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            //bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_ReportListTicketActivity().ListarTicket(StatusBar, FilterDate);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActivity(string StatusBar, string FilterDate)
        {
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            //bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_ReportListTicketActivity().ListarActivity(StatusBar, FilterDate);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
    }
}