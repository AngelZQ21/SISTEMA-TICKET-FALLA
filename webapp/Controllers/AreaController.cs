using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BL;
using CL_BE;

namespace SmartAdminMvc.Controllers
{
    public class AreaController : Controller
    {
        // GET: Area
        public JsonResult ListarAreas()
        {
            var lista = new BL_Area().ListarAreas();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CrearArea(string AreaName)
        {

            BE_Area bE_Area = new BE_Area();
            bE_Area.AreaName = AreaName.Trim().ToUpper();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Area.RegistrationUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Area().CrearArea(bE_Area);
            return Json(lista, JsonRequestBehavior.AllowGet);

        }
    }
}