using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BL;
using CL_BE;
namespace SmartAdminMvc.Controllers
{
    public class IndicatorAdminReportController : Controller
    {
        // GET: IndicatorAdministrativeReport
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VindicatorAdminReport()
        {
            try { 
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            string validacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "IndicatorAdminReport", "VindicatorAdminReport");

            if (validacion == "1")
            {
                return View();
            }
            else
            {
                TempData["MsgTmp"] = "Validación retornada " + validacion;
                return RedirectToAction("Vnoautorizado", "Error");
            }
            }
            catch (Exception e)
            {
                TempData["MsgTmp"] = "Validacion retornada " + e.Message;
                return RedirectToAction("Login", "Account");
            }
        }

        public JsonResult ListarRegistroIndicador(string starDate, string endDate)
        {
            var lista = new BL_Indicator_Register().ListarRegistroIndicador(starDate, endDate);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

    }
}