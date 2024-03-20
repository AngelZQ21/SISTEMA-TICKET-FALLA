using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BL;
using CL_BE;

namespace SmartAdminMvc.Controllers
{
    public class SystemController : Controller
    {
        // GET: System
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VSystem()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "System", "VSystem");

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

        public JsonResult ListarConfiguracion(string valorBusqueda, string valorConsulta)
        {
            var lista = new BL_Configuration().ListarConfiguracion(valorBusqueda, valorConsulta);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult EditarConfiguracion(int IdConfiguration, int ZCSyncTime, int EmbeddedQuantityDays, int MinDate, string StockRestriction,
            string PrefixSetting, int DecimalQuantity, int DecimalQuantity2, int MaxRowsReport, int MaxRowsSummary, int MaxRowsGraphic, int MaxDataGraphic,
            string PathFile, string PathFileInput, string PathFileOut, string PathFileDencrypt, string PathFileTemp, string PathSystem, string PathFileDispatchOk,
            string PathFileDispatchError, int TypeLoginZeus, int LogBus, int LogDispatch, int LogProtocol, int logError, int Migration_BlackList_Driver,
            int Migration_BlackList_Vehicle, int Migration_Driver, int Migration_Operator, int Migration_Vehicle, int DefaultStation, decimal PercentVIMS, bool ValidateVehicle,
            bool ValidateOperator, bool ValidateDriver, bool Sound, int MaxColumnRestriction, int NumberLockType, int MaxTimeBombas,
            int MaxTimeNoFujo)

        {
            BE_Configuration bE_Configuration = new BE_Configuration();
            bE_Configuration.IdConfiguration = IdConfiguration;
            bE_Configuration.ZCSyncTime = ZCSyncTime;
            bE_Configuration.EmbeddedQuantityDays = EmbeddedQuantityDays;
            bE_Configuration.MinDate = MinDate;
            bE_Configuration.StockRestriction = StockRestriction;
            bE_Configuration.PrefixSetting = PrefixSetting;
            bE_Configuration.DecimalQuantity = DecimalQuantity;
            bE_Configuration.DecimalQuantity2 = DecimalQuantity2;
            bE_Configuration.MaxRowsReport = MaxRowsReport;
            bE_Configuration.MaxRowsSummary = MaxRowsSummary;
            bE_Configuration.MaxRowsGraphic = MaxRowsGraphic;
            bE_Configuration.MaxDataGraphic = MaxDataGraphic;

            bE_Configuration.PathFile = PathFile;
            bE_Configuration.PathFileInput = PathFileInput;
            bE_Configuration.PathFileOut = PathFileOut;
            bE_Configuration.PathFileDencrypt = PathFileDencrypt;
            bE_Configuration.PathFileTemp = PathFileTemp;
            bE_Configuration.PathSystem = PathSystem;
            bE_Configuration.PathFileDispatchOk = PathFileDispatchOk;
            bE_Configuration.PathFileDispatchError = PathFileDispatchError;
            bE_Configuration.TypeLoginZeus = TypeLoginZeus;
            bE_Configuration.LogBus = LogBus;
            bE_Configuration.LogDispatch = LogDispatch;
            bE_Configuration.LogProtocol = LogProtocol;
            bE_Configuration.logError = logError;
            bE_Configuration.Migration_BlackList_Driver = Migration_BlackList_Driver;
            bE_Configuration.Migration_BlackList_Vehicle = Migration_BlackList_Vehicle;
            bE_Configuration.Migration_Driver = Migration_Driver;
            bE_Configuration.Migration_Operator = Migration_Operator;
            bE_Configuration.Migration_Vehicle = Migration_Vehicle;
            bE_Configuration.DefaultStation = DefaultStation;
            bE_Configuration.PercentVIMS = PercentVIMS;
            bE_Configuration.ValidateVehicle = ValidateVehicle;
            bE_Configuration.ValidateOperator = ValidateOperator;
            bE_Configuration.ValidateDriver = ValidateDriver;

            bE_Configuration.Sound = Sound;
            bE_Configuration.MaxColumnRestriction = MaxColumnRestriction;
            bE_Configuration.NumberLockType = NumberLockType;
            bE_Configuration.MaxTimeBombas = MaxTimeBombas;
            bE_Configuration.MaxTimeNoFujo = MaxTimeNoFujo;
  

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Configuration.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Configuration().EditarConfiguracion(bE_Configuration);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
    }
}