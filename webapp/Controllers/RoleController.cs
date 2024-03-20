using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BL;
using CL_BE;

namespace SmartAdminMvc.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vrole()
        {
            try { 
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "Role", "Vrole");

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

        public JsonResult ListarRole(string valorBusqueda, string valorConsulta)
        {
            var lista = new BL_Role().ListarRole(valorBusqueda, valorConsulta);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CrearRol(string RoleName, string RoleAbbreviation, string RoleType)
        {
            BE_Role bE_Role = new BE_Role();
            bE_Role.RoleName = RoleName.Trim();
            bE_Role.RoleAbbreviation = RoleAbbreviation.Trim();
            bE_Role.RoleType = RoleType;
          
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Role.RegistrationUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Role().CrearRol(bE_Role);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EditarRol(int IdRole, string RoleName, string RoleAbbreviation, string RoleType)
        {
            BE_Role bE_Role = new BE_Role();
            bE_Role.IdRole = IdRole;
            bE_Role.RoleName = RoleName.Trim();
            bE_Role.RoleAbbreviation = RoleAbbreviation.Trim();
            bE_Role.RoleType = RoleType;
            bE_Role.UpdateProcess = 1;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Role.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Role().EditarRol(bE_Role);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EditarEstadoRol(int IdRole)
        {
            BE_Role bE_Role = new BE_Role();
            bE_Role.IdRole = IdRole;
            bE_Role.UpdateProcess = 0;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Role.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Role().EditarRol(bE_Role);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EliminarRol(int IdRole)
        {
            BE_Role bE_Role = new BE_Role();
            bE_Role.IdRole = IdRole;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Role.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Role().EliminarRol(bE_Role);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }


        public JsonResult ValidarRelacionRol(int idRole)
        {
            var lista = new BL_Role().ValidarRelacionRol(idRole);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

    }
}