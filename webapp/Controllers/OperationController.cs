using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BE;
using CL_BL;

namespace SmartAdminMvc.Controllers
{
    public class OperationController : Controller
    {
        // GET: Operation
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarOperaciones()
        {
            var lista = new BL_Operation().ListarOperaciones();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CrearOperacion(string OperationName)
        {

            BE_Operation bE_Operation = new BE_Operation();
            bE_Operation.OperationName = OperationName.Trim().ToUpper();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Operation.RegistrationUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Operation().CrearOperacion(bE_Operation);
            return Json(lista, JsonRequestBehavior.AllowGet);

        }

    }
}