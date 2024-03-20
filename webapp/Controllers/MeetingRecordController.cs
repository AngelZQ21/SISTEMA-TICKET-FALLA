using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CL_BE;
using CL_BL;
using System.Xml.Linq;
using SmartAdminMvc.Libs;
using System.Configuration;

namespace SmartAdminMvc.Controllers
{
    public class MeetingRecordController : Controller
    {
        // GET: MeetingRecord
        public ActionResult VmeetingRecord()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "MeetingRecord", "VmeetingRecord");

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

        public JsonResult ListarReporteActaDeReunion(string StartDate, string EndDate, string IdsOperacion)
        {
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            var lista = new BL_MeetingRecord().ListarReporteActaDeReunion(StartDate, EndDate, IdsOperacion, Convert.ToInt32(usuario[0]));
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
        
        public JsonResult ListarActaDeReunionDetalle(int IdMeetingRecord, int IdOperation)
        {
            var lista = new BL_MeetingRecord().ListarActaDeReunionDetalle(IdMeetingRecord, IdOperation);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult RegistrarActaDeReunion(BE_Meeting_Record model)
        {

            BE_Meeting_Record bE_Meeting_Record = new BE_Meeting_Record();
            bE_Meeting_Record.bE_Operation = new BE_Operation();
            bE_Meeting_Record.IdMeetingRecord = model.IdMeetingRecord;
            if (model.ListaPuntosATratar != null)
            {
                bE_Meeting_Record.ListaPuntosATratarXML = GetXMLFromObject_Save_MeetingRecordDetail(model.ListaPuntosATratar);
            }
            bE_Meeting_Record.bE_Operation.IdOperation = model.bE_Operation.IdOperation;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            var lista = "";
            var estadoCierreFinGuardia = "";
            if (model.IdMeetingRecord == 0)
            {
                estadoCierreFinGuardia = "CREADO";
                bE_Meeting_Record.RegistrationUser = Convert.ToInt32(usuario[0]);
                lista = new BL_MeetingRecord().RegistrarActaDeReunion(bE_Meeting_Record);
            }
            else
            {
                estadoCierreFinGuardia = "ACTUALIZADO";
                bE_Meeting_Record.IdsMeetingRecordDetail = model.IdsMeetingRecordDetail;
                bE_Meeting_Record.UpdateUser = Convert.ToInt32(usuario[0]);
                lista = new BL_MeetingRecord().ActualizarActaDeReunion(bE_Meeting_Record);
            }

            if (lista.Split('|')[0] == "1")
            {
                EnvioCorreo(usuario[4], model.bE_Operation.OperationName, lista.Split('|')[1], estadoCierreFinGuardia);
            }

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        // ENVIO DE CORREO
        private bool EnvioCorreo(string Usuario, string Operacion,string NroCierre, string estado)
        {
            var estadoAsunto = estado == "CREADO" ? "NUEVO" : "ACTUALIZACIÓN DE";
            
            string MailsDestinos = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString();
            ConfigMail correoLib = new ConfigMail
            {
                MailDestino = MailsDestinos,
                Asunto = estadoAsunto + " CIERRE DE FIN DE GUARDIA PARA LA OPERACIÓN " + Operacion + " CON NÚMERO " + NroCierre
            };
            string cuerpo = string.Empty;
            string urlASSAC = ConfigurationManager.AppSettings["urlASSAC"].ToString();

            string plantilla = correoLib.ObtenerPlantilla("02_Cierre_Fin_Guardia");

            cuerpo = plantilla.Replace("[USUARIO]", Usuario);
            cuerpo = cuerpo.Replace("[OPERACION]", Operacion);
            cuerpo = cuerpo.Replace("[NUMERO]", NroCierre);
            cuerpo = cuerpo.Replace("[ESTADO]", estado);
            cuerpo = cuerpo.Replace("[URLASSAC]", urlASSAC);

            correoLib.Cuerpo = cuerpo;
            bool envio = correoLib.EnviarCorreo();

            return envio;
        }


        /*------PROCESAR XML------*/
        /*LISTAR ACTA DE REUNIÓN DETALLE - PUNTOS A TRATAR*/
        private string GetXMLFromObject_Save_MeetingRecordDetail(List<BE_Meeting_Record_Detail> listaPuntosATratar)
        {
            XDocument xdoc = new XDocument(
                                new XDeclaration("1.0", "utf-8", "yes"),
                                    new XElement("Rows",
                                    from emp in listaPuntosATratar
                                    select new XElement("Campos",
                                        new XAttribute("IdMeetingRecordDetail", emp.IdMeetingRecordDetail),
                                        new XAttribute("IdEmployee", emp.bE_Employee.IdEmployee),
                                        new XAttribute("IdPointDiscussed", emp.IdPointDiscussed),
                                        new XAttribute("IdPathFile", emp.bE_PathFile.IdPathFile),
                                        new XAttribute("MeetingRecordDetailTopic", emp.MeetingRecordDetailTopic),
                                        new XAttribute("MeetingRecordDetailEvent", emp.MeetingRecordDetailEvent == null ? "" : emp.MeetingRecordDetailEvent),
                                        new XAttribute("MeetingRecordDetailDate", emp.MeetingRecordDetailDateString),
                                        new XAttribute("MeetingRecordDetailStatus", emp.MeetingRecordDetailStatus))
                                    ));
            return xdoc.ToString();
        }

    }
}