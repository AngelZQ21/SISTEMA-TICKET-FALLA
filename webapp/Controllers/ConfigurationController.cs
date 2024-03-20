using CL_BE;
using CL_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class ConfigurationController : Controller
    {

        public JsonResult ListarConfigurationAlert()
        {
            BE_Configuration bE_Configuration = new BE_Configuration();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Configuration.RegistrationUser = Convert.ToInt32(usuario[0]);

            var IdUser = bE_Configuration.RegistrationUser;

            var lista = new BL_Configuration().ListarConfigurationAlert(IdUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult EditAlertStatus(string AlertStatusValue)
        {
            BE_Configuration bE_Configuration = new BE_Configuration();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Configuration.RegistrationUser = Convert.ToInt32(usuario[0]);

            var IdUser = bE_Configuration.RegistrationUser;

            var resultado = new BL_Configuration().EditAlertStatus(AlertStatusValue, IdUser);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
    }
}