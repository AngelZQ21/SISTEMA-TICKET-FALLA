using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CL_BE;
using CL_BL;

namespace SmartAdminMvc.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        public ActionResult Index()
        {
            return View();
        }

        public List<BE_Menu_Profile> ListarMenu(string idPerfil, string valorConsulta)
        {
            var listaResultado = new List<BE_Menu_Profile>();
            try
            {
                listaResultado = new BL_Menu().ListarMenu(Convert.ToInt32(idPerfil), valorConsulta);
            }
            catch (Exception ex)
            {
                BE_Menu_Profile bE_Menu_Profile = new BE_Menu_Profile();
                bE_Menu_Profile.ValorConsulta = "0";
                bE_Menu_Profile.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Menu_Profile);
            }
            return listaResultado;
        }

        public JsonResult ListarMenuJson(string idPerfil, string valorConsulta)
        {
            var lista = new BL_Menu().ListarMenu(Convert.ToInt32(idPerfil), valorConsulta);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public String ListarVistaPrincipalMenu(string idPerfil, string valorConsulta)
        {
            var ResultadoConsulta = "";
            try
            {
                if (idPerfil == "")
                {
                    RedirectToAction("Login", "Account");
                }
                ResultadoConsulta = new BL_Menu().ListarMenu(Convert.ToInt32(idPerfil), valorConsulta).Where(x => x.MainView == "S").Select(x => x.Menu.DependencySequence).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ResultadoConsulta = "";
            }
            return ResultadoConsulta;
        }

        
	}
}