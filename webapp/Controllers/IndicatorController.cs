using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BL;
using CL_BE;
namespace SmartAdminMvc.Controllers
{
    public class IndicatorController : Controller
    {
        // GET: Alert
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vindicator()
        {
            try { 
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            string validacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "Indicator", "Vindicator");

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

        public JsonResult ListarIndicador()
        {
            var lista = new BL_Indicator().ListarIndicador();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

       

        public JsonResult guardarConfiguracionIndicador(string idsIndicadores)
        {
            var lista = new BL_Indicator().guardarConfiguracionIndicador(idsIndicadores);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarIndicadorBarraSuperior()
        {
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            int idProfile = Convert.ToInt32(usuario[2]);
            int idUser = Convert.ToInt32(usuario[0]);
            var lista = new BL_Indicator().ListarIndicadorParaNavigation();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarIndicadorDetalleBarraSuperior(int IdIndicatorType)
        {
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            int idProfile = Convert.ToInt32(usuario[2]);
            int idUser = Convert.ToInt32(usuario[0]);
            var lista = new BL_Indicator().ListarIndicadorDetalleParaNavigation(IdIndicatorType);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
        public JsonResult listarIndicadorReporte(string startDate, string endDate, int IdIndicator, int IdIndicatorType, int IdUser)
        {
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            int idProfile = Convert.ToInt32(usuario[2]);
            int idUser = Convert.ToInt32(usuario[0]);
            //  Verifico si es para todos los usuario o solo uno
            idUser = IdUser == 0 ? 0 : idUser;
            var lista = new BL_Indicator().listarIndicadorModalBarraSuperior(IdIndicator, IdIndicatorType, startDate, endDate, idUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public PartialViewResult redireccion()
        {
            return PartialView();
        }

        public JsonResult ListarTipoIndicador()
        {
            var lista = new BL_Indicator_Type().ListarTipoIndicador();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult listarIndicadorPorTipo(int IdIndicatorType)
        {
            var lista = new BL_Indicator().listarIndicadorPorTipo(IdIndicatorType);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

    }
}