using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BL;
using CL_BE;

namespace SmartAdminMvc.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Vprofile()
        {
            try { 
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            string validacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "Profile", "Vprofile");

            if (validacion == "1")
            {
                return View();
            }
            else
            {
                TempData["MsgTmp"] = "Validacion retornada " + validacion;
                return RedirectToAction("Vnoautorizado", "Error");
            }
            }
            catch (Exception e)
            {
                TempData["MsgTmp"] = "Validacion retornada " + e.Message;
                return RedirectToAction("Login", "Account");
            }
        }
        public JsonResult ListarPerfil(string valorBusqueda, string valorConsulta)
        {
            var lista = new BL_Profile().ListarPerfil(valorBusqueda, valorConsulta);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CrearPerfil(string txtNombre, int MaxIntentos)
        {
            BE_Profile bE_Profile = new BE_Profile();
            bE_Profile.ProfileName = txtNombre;
            bE_Profile.MaxAttempts = MaxIntentos;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Profile.RegistrationUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Profile().CrearPerfil(bE_Profile);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EditarPerfil(int idProfile, string txtNombre, int MaxIntentos)
        {
            BE_Profile bE_Profile = new BE_Profile();
            bE_Profile.IdProfile = idProfile;
            bE_Profile.ProfileName = txtNombre;
            bE_Profile.MaxAttempts = MaxIntentos;
            bE_Profile.UpdateProcess = 1;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Profile.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Profile().EditarPerfil(bE_Profile);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EditarEstadoPerfil(int idProfile)
        {
            BE_Profile bE_Profile = new BE_Profile();
            bE_Profile.IdProfile = idProfile;
            bE_Profile.UpdateProcess = 0;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Profile.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Profile().EditarPerfil(bE_Profile);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EliminarPerfil(int idProfile)
        {
            BE_Profile bE_Profile = new BE_Profile();
            bE_Profile.IdProfile = idProfile;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Profile.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Profile().EliminarPerfil(bE_Profile);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult ValidarRelacionPerfil(int idPerfil)
        {
            var lista = new BL_Profile().ValidarRelacionPerfil(idPerfil);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

    }
}