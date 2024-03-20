using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL_BE;
using CL_BL;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.IO;
using SmartAdminMvc.Libs;
using System.Configuration;

namespace SmartAdminMvc.Controllers
{
    public class GuardChangeController : Controller
    {
        // GET: GuardChange
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VguardChange()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "GuardChange", "VguardChange");

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


        public JsonResult ListarReporteCambioDeGuardia(string StartDate, string EndDate, string IdsOperacion)
        {
            var lista = new BL_GuardChange().ListarReporteCambioDeGuardia(StartDate, EndDate, IdsOperacion);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
        
        public JsonResult RegistrarCambioDeGuardia(BE_GuardChange model)
        {

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            BE_GuardChange bE_GuardChange = new BE_GuardChange();
            bE_GuardChange.bE_Operation = new BE_Operation();
            bE_GuardChange.bE_Meeting_Record = new BE_Meeting_Record();
            bE_GuardChange.bE_Meeting_Record.IdMeetingRecord = model.bE_Meeting_Record.IdMeetingRecord;
            bE_GuardChange.bE_Operation.IdOperation = model.bE_Operation.IdOperation;

            if (model.ListaTrabajadores != null)
            {
                bE_GuardChange.ListaTrabajadoresXML = GetXMLFromObject_Save_Employee(model.ListaTrabajadores);
            }
            if (model.ListaActividades != null)
            {
                bE_GuardChange.ListaActividadesXML = GetXMLFromObject_Save_Activity(model.ListaActividades);
            }
            bE_GuardChange.RegistrationUser = Convert.ToInt32(usuario[0]);


            List<BE_Employee> Resultado = new List<BE_Employee>();

            Resultado = new BL_GuardChange().RegistrarCambioDeGuardia(bE_GuardChange);

            if (Resultado[0].ValorConsulta == "1") {
                EnvioCorreo(usuario[4],Resultado[0].EmployeeMails, model.bE_Operation.OperationName, "CREADO");
            }

            return Json(Resultado[0].ValorConsulta, JsonRequestBehavior.AllowGet);
        }


        // ENVIO DE CORREO
        private bool EnvioCorreo(string Usuario, string EmployeeMails, string Operacion, string estado)
        {
            ConfigMail correoLib = new ConfigMail
            {
                MailDestino = EmployeeMails,
                Asunto = "NUEVA ACTA DE REUNIÓN PARA LA OPERACIÓN " + Operacion
            };
            string cuerpo = string.Empty;
            string urlASSAC = ConfigurationManager.AppSettings["urlASSAC"].ToString();

            string plantilla = correoLib.ObtenerPlantilla("01_Acta_De_Reunion");

            cuerpo = plantilla.Replace("[USUARIO]", Usuario);
            cuerpo = cuerpo.Replace("[OPERACION]", Operacion);
            cuerpo = cuerpo.Replace("[ESTADO]", estado);
            cuerpo = cuerpo.Replace("[URLASSAC]", urlASSAC);

            correoLib.Cuerpo = cuerpo;
            bool envio = correoLib.EnviarCorreo();

            return envio;
        }

        /*------PROCESAR XML------*/
        /*LISTAR TRABAJADORES*/
        private string GetXMLFromObject_Save_Employee(List<ModelTrabajador> listaTrabajadores)
        {
            XDocument xdoc = new XDocument(
                                new XDeclaration("1.0", "utf-8", "yes"),
                                    new XElement("Rows",
                                    from emp in listaTrabajadores
                                    select new XElement("Campos",
                                        new XAttribute("IdEmployee", emp.IdEmployee),
                                        new XAttribute("GuardChangeEmployeeType", emp.GuardChangeEmployeeType)
                                        )
                                    ));
            return xdoc.ToString();
        }

        /*LISTAR ACTIVIDADES*/
        private string GetXMLFromObject_Save_Activity(List<BE_Meeting_Record_Activity> listaActividadesPendientes)
        {
            XDocument xdoc = new XDocument(
                                new XDeclaration("1.0", "utf-8", "yes"),
                                    new XElement("Rows",
                                    from emp in listaActividadesPendientes
                                    select new XElement("Campos",
                                        new XAttribute("IdMeetingRecordDetail", emp.bE_Meeting_Record_Detail.IdMeetingRecordDetail),
                                        new XAttribute("IdEmployee", emp.bE_Employee.IdEmployee),
                                        new XAttribute("MeetingRecordActivityActivity", emp.MeetingRecordActivityActivity),
                                        new XAttribute("MeetingRecordActivityCommentary", emp.MeetingRecordActivityCommentary == null ? "" : emp.MeetingRecordActivityCommentary),
                                        new XAttribute("MeetingRecordActivityEndDate", emp.MeetingRecordActivityEndDateString),
                                        new XAttribute("MeetingRecordActivityStatus", emp.MeetingRecordActivityStatus)
                                        )
                                    ));
            return xdoc.ToString();
        }

    }
}