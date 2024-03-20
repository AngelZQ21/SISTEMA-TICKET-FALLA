using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CL_BL;
using CL_BE;


namespace SmartAdminMvc.Controllers
{
    public class ValueController : Controller
    {
        // GET: Value
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarValues(string valorBusqueda, string nombreTabla, string nombreColumna)
        {
            var lista = new BL_Value().ListarValues(valorBusqueda,nombreTabla,nombreColumna);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListadoAlarmaConCodigo()
        {
            var lista = new BL_Value().ListadoAlarmaConCodigo();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }


        public JsonResult ListarAnos()
        {
            var lista = new BL_Value().ListarAnos();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
        
    }
}