using CL_BL;
using CL_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class ReasonController : Controller
    {

        public JsonResult ListarReason()
        {
            var lista = new BL_Reason().ListarReason();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarLocation()
        {
            var lista = new BL_Reason().ListarLocation();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        

        public JsonResult CrearReason(string ReasonName)
        {
            BE_Reason bE_Reason = new BE_Reason();

            bE_Reason.ReasonName = ReasonName.Trim().ToUpper();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Reason.RegistrationUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Reason().CrearReason(bE_Reason);

            return Json(lista, JsonRequestBehavior.AllowGet);

        }

        public JsonResult CrearLocacion(string LocacionName)
        {
            BE_Location bE_Location = new BE_Location();

            bE_Location.LocationName = LocacionName.Trim().ToUpper();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Location.RegistrationUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Reason().CrearLocacion(bE_Location);

            return Json(lista, JsonRequestBehavior.AllowGet);

        }

    }
}