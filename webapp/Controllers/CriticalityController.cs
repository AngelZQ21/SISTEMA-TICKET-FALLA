using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BL;

namespace SmartAdminMvc.Controllers
{
    public class CriticalityController : Controller
    {
        public JsonResult ListarCriticality()
        {
            var lista = new BL_Criticality().ListarCriticality();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
    }
}