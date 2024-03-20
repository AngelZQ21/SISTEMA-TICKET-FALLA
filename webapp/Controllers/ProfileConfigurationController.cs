using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CL_BL;
using CL_BE;

namespace SmartAdminMvc.Controllers
{
    public class ProfileConfigurationController : Controller
    {
        //
        // GET: /ProfileConfiguration/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VProfileConfiguration()
        {
            try { 
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            string validacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "ProfileConfiguration", "VProfileConfiguration");

            if (validacion == "1")
            {
                return View();
            }
            else
            {
                TempData["MsgTmp"] = "Validación retornada " + validacion;
                return RedirectToAction("Vnoautorizado", "Error");
            }
            }
            catch (Exception e)
            {
                TempData["MsgTmp"] = "Validacion retornada " + e.Message;
                return RedirectToAction("Login", "Account");
            }
        }

    }
}