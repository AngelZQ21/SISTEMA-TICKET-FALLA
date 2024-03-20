using CL_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class AlertListController : Controller
    {
        // GET: AlertList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ValertList()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "AlertList", "ValertList");

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

        //public JsonResult AlarmaTelemetriaPorTipoIncidencia(string StartDate, string EndDate, int TypeAlarm)
        //{
        //    var lista = new BL_ZR_Telemetry_Tank_Alarm().AlarmaTelemetriaPorTipoIncidencia(StartDate, EndDate, TypeAlarm);
        //    var a = Json(lista, JsonRequestBehavior.AllowGet);
        //    a.MaxJsonLength = int.MaxValue;
        //    return a;
        //}


    }
}