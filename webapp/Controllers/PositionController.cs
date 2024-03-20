using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BL;
using CL_BE;

namespace SmartAdminMvc.Controllers
{
    public class PositionController : Controller
    {
        // GET: Position
        public JsonResult ListarCargos()
        {
            var lista = new BL_Position().ListarCargos();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CrearCargo(string PositionName)
        {

            BE_Position bE_Position = new BE_Position();
            bE_Position.PositionName = PositionName.Trim().ToUpper();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Position.RegistrationUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Position().CrearCargo(bE_Position);
            return Json(lista, JsonRequestBehavior.AllowGet);

        }
    }
}