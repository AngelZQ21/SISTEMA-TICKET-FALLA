using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CL_BE;
using CL_BL;
namespace SmartAdminMvc.Controllers
{
    public class MenuProfileActionController : Controller
    {
        //
        // GET: /MenuProfileAction/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarMenuPerfilAction(int idPerfil, string valorConsulta)
        {
            var lista = new BL_Menu_Profile_Action().ListarMenuPerfilAction(idPerfil, valorConsulta);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult guardarConfiguracionMenuPerfilAccion(String arrayIdMenu, int idPerfil)
        {
            var lista = new BL_Menu_Profile_Action().guardarConfiguracionMenuPerfilAccion(arrayIdMenu, idPerfil);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
	}
}