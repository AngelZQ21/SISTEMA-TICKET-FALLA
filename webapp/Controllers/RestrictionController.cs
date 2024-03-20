using CL_BE;
using CL_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class RestrictionController : Controller
    {
        // GET: Restriction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vrestriction()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "Restriction", "Vrestriction");

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

        public JsonResult ListarRestriccion(string valorBusqueda, string valorConsulta)
        {
            var lista = new BL_Restriction().ListarRestriccion(valorBusqueda, valorConsulta);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CrearRestriccion(string RestrictionName, string RestrictionTable)//, string RestrictionColumn)
        {            
            BE_Restriction bE_Restriction = new BE_Restriction();
            bE_Restriction.RestrictionName = RestrictionName.ToUpper();
            bE_Restriction.RestrictionTable = RestrictionTable.ToUpper();
            //bE_Restriction.RestrictionColumn = RestrictionColumn.ToUpper();            

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Restriction.RegistrationUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Restriction().CrearRestriccion(bE_Restriction);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EditarRestriccion(int IdRestriction, string RestrictionName, string RestrictionTable, string RestrictionColumn, string OldColumnName)
        {
            BE_Restriction bE_Restriction = new BE_Restriction();
            bE_Restriction.IdRestriction = IdRestriction;

            bE_Restriction.RestrictionName = RestrictionName.ToUpper();
            bE_Restriction.RestrictionTable = RestrictionTable.ToUpper();
            bE_Restriction.RestrictionColumn = RestrictionColumn.ToUpper();
            bE_Restriction.OldColumnName = OldColumnName.ToUpper();
            bE_Restriction.UpdateProcess = 1;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Restriction.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Restriction().EditarRestriccion(bE_Restriction);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EditarEstadoRestriccion(int IdRestriction)
        {
            BE_Restriction bE_Restriction = new BE_Restriction();
            bE_Restriction.IdRestriction = IdRestriction;

            bE_Restriction.UpdateProcess = 0;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Restriction.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Restriction().EditarRestriccion(bE_Restriction);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EliminarRestriccion(int IdRestriction)
        {
            BE_Restriction bE_Restriction = new BE_Restriction();
            bE_Restriction.IdRestriction = IdRestriction;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Restriction.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Restriction().EliminarRestriccion(bE_Restriction);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult ValidarRelacionRestriccionMapa(int IdRestriction, string RestrictionTable, string RestrictionColumn)
        {
            var lista = new BL_Restriction().ValidarRelacionRestriccionMapa(IdRestriction, RestrictionTable, RestrictionColumn);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
    }
}