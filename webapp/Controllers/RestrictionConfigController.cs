using CL_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class RestrictionConfigController : Controller
    {
        // GET: RestrictionConfig
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VrestrictionConfig()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "RestrictionConfig", "VrestrictionConfig");

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

        public JsonResult ListarConfiguracionRestriccion(string RestrictionTable, string Search, string QueryValue)
        {
            DataTable dt = new BL_Restriction_Setting().ListarConfiguracionRestriccion(RestrictionTable, Search, QueryValue);

            var lst = dt.AsEnumerable().Select(r => r.Table.Columns.Cast<DataColumn>().Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
                    ).ToDictionary(z => z.Key, z => z.Value)
                    ).ToList();

            var a = Json(lst, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarConfiguracionRestriccionColumn(string RestrictionTable)
        {
            DataTable dt = new BL_Restriction_Setting().ListarConfiguracionRestriccionColumn(RestrictionTable);

            var lst = dt.AsEnumerable().Select(r => r.Table.Columns.Cast<DataColumn>().Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
                    ).ToDictionary(z => z.Key, z => z.Value)
                    ).ToList();

            var a = Json(lst, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CrearMapa(string Nombre, string TablaRestriccion, string RestriccionesSeleccionadas, string RestrictionColumns)
        {
            string stringArray = "";

            string[] resultadoArray = RestriccionesSeleccionadas.Split(',');

            for (int i = 0; i < resultadoArray.Length; i++)
            {
                if (resultadoArray[i].ToString() != "")
                {
                    stringArray = stringArray + resultadoArray[i].ToString() + ", ";
                }
            }

            stringArray = stringArray.Length == 0 ? "" : stringArray.Substring(0, stringArray.Length - 2);
            
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);            

            var resultado = new BL_Restriction_Setting().CrearMapa(Convert.ToInt32(usuario[0]), Nombre, TablaRestriccion, stringArray, RestrictionColumns);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EditarMapa(int ID, string Nombre, string TablaRestriccion, string RestriccionesSeleccionadas, string RestrictionColumns)
        {
            string stringArray = "";

            string[] resultadoArray = RestriccionesSeleccionadas.Split(',');

            for (int i = 0; i < resultadoArray.Length; i++)
            {
                if (resultadoArray[i].ToString() != "")
                {
                    stringArray = stringArray + resultadoArray[i].ToString() + ", ";
                }
            }
            
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            stringArray = stringArray.Length > 0 ? stringArray.Substring(0, stringArray.Length - 2) : "";

            var resultado = new BL_Restriction_Setting().EditarMapa(ID, Convert.ToInt32(usuario[0]), Nombre, TablaRestriccion, stringArray, RestrictionColumns);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
       
        public JsonResult EditarEstadoRestriccionMapa(int ID, string TablaRestriccion)
        {           
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            var resultado = new BL_Restriction_Setting().EditarEstadoRestriccionMapa(ID, Convert.ToInt32(usuario[0]), TablaRestriccion);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EliminarMapa(int ID, string TablaRestriccion)
        {
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            var resultado = new BL_Restriction_Setting().EliminarMapa(ID, Convert.ToInt32(usuario[0]), TablaRestriccion);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }       

        //------------------------------------------------------------------------------------------------------------------------------------------------

        public ActionResult VmapVehicle()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "RestrictionConfig", "VmapVehicle");

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

        public JsonResult GrabarMapaVehiculo(string VehiculosSeleccionados, int IdMap, string ListaInicial)
        {
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            int IdUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Restriction_Setting().GrabarMapaVehiculo(VehiculosSeleccionados, IdMap, IdUser, ListaInicial);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public ActionResult VmapOperator()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "RestrictionConfig", "VmapOperator");

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

        public JsonResult GrabarMapaOperador(string OperadoresSeleccionados, int IdMap, string ListaInicial)
        {
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            int IdUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Restriction_Setting().GrabarMapaOperador(OperadoresSeleccionados, IdMap, IdUser, ListaInicial);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public ActionResult VmapDriver()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "RestrictionConfig", "VmapDriver");

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

        public JsonResult GrabarMapaConductor(string ConductoresSeleccionados, int IdMap, string ListaInicial)
        {
            string nuevaListaInicial = "";
            string[] arrayListaInicial = ListaInicial.Split(',');
            for (int i = 0; i < arrayListaInicial.Length; i++)
            {
                if (arrayListaInicial[i].ToString() != "")
                {
                    nuevaListaInicial = nuevaListaInicial + arrayListaInicial[i] + ",";
                }
            }
            
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            int IdUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Restriction_Setting().GrabarMapaConductor(ConductoresSeleccionados, IdMap, IdUser, ListaInicial);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }        

        public JsonResult ValidarRelacionRestriccionMapa(int IdRestriction, string RestrictionTable)
        {
            var lista = new BL_Restriction_Setting().ValidarRelacionRestriccionMapa(IdRestriction, RestrictionTable);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        //public JsonResult ListarMapaVehiculos(int Id)
        //{
        //    var lista = new BL_Vehicle().ListarMapaVehiculos(Id);
        //    var a = Json(lista, JsonRequestBehavior.AllowGet);
        //    a.MaxJsonLength = int.MaxValue;
        //    return a;
        //}
    }
}