using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CL_BE;
using CL_BL;

namespace SmartAdminMvc.Controllers
{
    public class MenuProfileController : Controller
    {
        //
        // GET: /MenuProfile/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult guardarConfiguracionMenuPerfil(String arrayIdMenu, int idPerfil, int mainId, int idMenu)
        {
            var lista = new BL_Menu_Profile().guardarConfiguracionMenuPerfil(arrayIdMenu, idPerfil, mainId, idMenu);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
	}
}