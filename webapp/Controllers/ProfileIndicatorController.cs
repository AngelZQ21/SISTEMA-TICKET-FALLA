using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BL;
using CL_BE;

namespace SmartAdminMvc.Controllers
{
    public class ProfileIndicatorController : Controller
    {
        // GET: ProfileIndicator
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult ListarIndicadorPerfil(string valorBusqueda, string valorConsulta, int idPerfil)
        {
            var lista = new BL_Profile_Indicator().ListarIndicadorPerfil(valorBusqueda, valorConsulta, idPerfil);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
        public JsonResult guardarConfiguracionIndicadorPerfil(string idsIndicadores, int idPerfil)
        {
            var lista = new BL_Profile_Indicator().guardarConfiguracionIndicadorPerfil(idsIndicadores, idPerfil);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
    }
}