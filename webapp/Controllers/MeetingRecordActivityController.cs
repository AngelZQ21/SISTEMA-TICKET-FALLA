using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BE;
using CL_BL;

namespace SmartAdminMvc.Controllers
{
    public class MeetingRecordActivityController : Controller
    {
        // GET: MeetingRecordActivity

        public JsonResult ListarActividadesPendientes(int IdGuardChange)
        {
            var lista = new BL_Meeting_Record_Activity().ListarActividadesPendientes(IdGuardChange);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

    }
}