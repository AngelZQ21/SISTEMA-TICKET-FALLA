using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BL;
using CL_BE;

namespace SmartAdminMvc.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Vuser()
        {
            try { 
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "user", "Vuser");

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

        public JsonResult ListarUser(string valorBusqueda, string valorConsulta)
        {
            var lista = new BL_User().ListarUser(valorBusqueda, valorConsulta);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CrearUser(int IdPerson, int IdProfile, string UserType, string UUser, string UPasword, string Contratistas)
        {
            EncryptAndDecryptFile ClaseEncriptar = new EncryptAndDecryptFile();
            BE_User bE_User = new BE_User();
            BE_Person bE_Person = new BE_Person() { IdPerson = IdPerson };
            bE_User.Person = bE_Person;
            bE_User.IdProfile = IdProfile;
            bE_User.UserType = UserType;
            bE_User.UUser = UUser;
            bE_User.UPassword = ClaseEncriptar.EncryptToString(UPasword);
            bE_User.UContratistasSelecionados = Contratistas;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_User.RegistrationUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_User().CrearUser(bE_User);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EditarUser(int IdUser, int IdPerson, int IdProfile, string UserType, string UUser, string UPasword, string Contratistas)
        {
            EncryptAndDecryptFile ClaseEncriptar = new EncryptAndDecryptFile();
            BE_User bE_User = new BE_User();
            bE_User.IdUser = IdUser;
            BE_Person bE_Person = new BE_Person() { IdPerson = IdPerson };
            bE_User.Person = bE_Person;
            
            bE_User.IdProfile = IdProfile;
            bE_User.UserType = UserType;
            bE_User.UUser = UUser;            
            bE_User.UPassword = ClaseEncriptar.EncryptToString(UPasword);
            bE_User.UContratistasSelecionados = Contratistas;
            bE_User.UpdateProcess = 1;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_User.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_User().EditarUser(bE_User);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EditarEstadoUser(int IdUser)
        {
            BE_User bE_User = new BE_User();
            bE_User.IdUser = IdUser;
            BE_Person bE_Person = new BE_Person() { IdPerson = 0 };
            bE_User.Person = bE_Person;

            bE_User.UpdateProcess = 0;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_User.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_User().EditarUser(bE_User);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult CambiarClave(string clave, string claveNueva)
        {
            EncryptAndDecryptFile ClaseEncriptar = new EncryptAndDecryptFile();
            BE_User bE_User = new BE_User();
            BE_Person bE_Person = new BE_Person() { IdPerson = 0 };
            bE_User.Person = bE_Person;
            bE_User.UPassword = ClaseEncriptar.EncryptToString(claveNueva);
            bE_User.actualPassword = ClaseEncriptar.EncryptToString(clave);
            bE_User.UpdateProcess = 2;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_User.UpdateUser = Convert.ToInt32(usuario[0]);
            bE_User.IdUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_User().CambiarClave(bE_User);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EliminarUser(int IdUser)
        {
            BE_User bE_User = new BE_User();
            bE_User.IdUser = IdUser;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_User.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_User().EliminarUser(bE_User);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult ValidarRelacionUsuarioPersona(int idUser)
        {
            var lista = new BL_User().ValidarRelacionUsuarioPersona(idUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CambiarClaveOReseteo(int idUser,string claveNueva)
        {
            EncryptAndDecryptFile ClaseEncriptar = new EncryptAndDecryptFile();
            BE_User bE_User = new BE_User();
            BE_Person bE_Person = new BE_Person() { IdPerson = 0 };
            bE_User.Person = bE_Person;
            bE_User.UPassword = ClaseEncriptar.EncryptToString(claveNueva);            
            bE_User.UpdateProcess = 3;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_User.UpdateUser = Convert.ToInt32(usuario[0]);
            bE_User.IdUser = idUser;

            var resultado = new BL_User().CambiarClaveOReseteo(bE_User);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
    }
}