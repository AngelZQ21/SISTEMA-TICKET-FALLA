using CL_BE;
using CL_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class ListTicketValidityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VlistTicketValidity()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "ListTicketValidity", "VlistTicketValidity");

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

        public JsonResult ListarVigenciaFechas(string StartDate, string EndDate, string IdTicket, string IdResponsable, string TypeValue)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarVigenciaFechas(StartDate, EndDate, IdTicket, IdResponsable, TypeValue);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

    }
}