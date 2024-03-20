using CL_BE;
using CL_BL;
using SmartAdminMvc.Libs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class ActivityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vactivity()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "Activity", "Vactivity");

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

        public JsonResult CrearActivity(string NroTicket, int IdResponsible, string ActivityText, string FechaCierre)
        {
            BE_Activity bE_Activity = new BE_Activity();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Activity.RegistrationUser = Convert.ToInt32(usuario[0]);

            bE_Activity.NroTicket = NroTicket;
            bE_Activity.IdResponsible = IdResponsible;
            bE_Activity.ActivityText = ActivityText;
            //bE_Activity.DescripcionActivity = DescripcionActivity;
            //bE_Activity.Invitado = Invitado;
            bE_Activity.FechaCierre = FechaCierre;

            var resultado = new BL_Activity().CrearActivity(bE_Activity);
            //var json = Json(resultado, JsonRequestBehavior.AllowGet);
            //json.MaxJsonLength = int.MaxValue;
            //return json;
            //var EnviarCorreo;

            if (resultado.Count > 0 && resultado[0].ValorConsulta == "1")
            {
                var EnviarCorreo = EnvioCorreo(usuario[4], resultado[0].NroTicket, resultado[0].ActivityText, resultado[0].FullNameActivity, resultado[0].PersonMail, resultado[0].FechaCierre, resultado[0].RegistrationDateString, resultado[0].OperationName);

                if (EnviarCorreo == true)
                {
                    var json = Json(resultado, JsonRequestBehavior.AllowGet);
                    json.MaxJsonLength = int.MaxValue;
                    return json;
                }
                else
                {
                    return Json(EnviarCorreo, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json(4, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult EditarActivity(int IdActivity, int IdResponsible, string ActivityText, string FechaCierre)
        {
            BE_Activity bE_Activity = new BE_Activity();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Activity.RegistrationUser = Convert.ToInt32(usuario[0]);

            bE_Activity.IdActivity = IdActivity;
            bE_Activity.IdResponsible = IdResponsible;
            bE_Activity.ActivityText = ActivityText;
            //bE_Activity.DescripcionActivity = DescripcionActivity;
            //bE_Activity.Invitado = Invitado;
            bE_Activity.FechaCierre = FechaCierre;

            var resultado = new BL_Activity().EditarActivity(bE_Activity);
            //var json = Json(resultado, JsonRequestBehavior.AllowGet);
            //json.MaxJsonLength = int.MaxValue;
            //return json;
            //var EnviarCorreo;

            if (resultado.Count > 0 && resultado[0].ValorConsulta == "1")
            {
                var EnviarCorreo = EditadoEnvioCorreo(usuario[4], resultado[0].NroTicket, resultado[0].ActivityText, resultado[0].FullNameActivity, resultado[0].PersonMail, resultado[0].FechaCierre, resultado[0].RegistrationDateString, resultado[0].OperationName);

                if (EnviarCorreo == true)
                {
                    var json = Json(resultado, JsonRequestBehavior.AllowGet);
                    json.MaxJsonLength = int.MaxValue;
                    return json;
                }
                else
                {
                    return Json(EnviarCorreo, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json(4, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult EliminarActivityDetail(int IdActivityDetail)
        {
            BE_Activity bE_Activity = new BE_Activity();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            
            var RegistrationUser = 0;
            RegistrationUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Activity().EliminarActivityDetail(IdActivityDetail,RegistrationUser);

            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
               
        }

        public JsonResult ActualizarRegistrarVitacora(string NroTicket, string DescriptionBoard)
        {
            BE_Board bE_Board = new BE_Board();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Board.RegistrationUser = Convert.ToInt32(usuario[0]);
            bE_Board.NroTicket = NroTicket;
            bE_Board.DescripcionActivity = DescriptionBoard;

            var resultado = new BL_Activity().ActualizarRegistrarVitacora(bE_Board);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;   
        }

        public JsonResult ActualizarRegistrarVitacoraActivityDetail(int idActivity, string DescriptionBoard)
        {
            BE_Board bE_Board = new BE_Board();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Board.RegistrationUser = Convert.ToInt32(usuario[0]);
            bE_Board.IdActivity = idActivity;
            bE_Board.DescripcionActivity = DescriptionBoard;

            var resultado = new BL_Activity().ActualizarRegistrarVitacoraActivityDetail(bE_Board);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        private bool EnvioCorreo(string Usuario, string NroTicket, string ActivityText, string FullNameActivity, string FullNameEmail ,string FechaCierre, string RegistrationDateString, string OperationName)
        {
            string MailDestinoPrincipal= "";
            //string MailDestinoPrincipal = emailResponsable
            //string estadoActividad = "";

            //if (InvitadoActividad != "")
            //{
            //    MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString() + ";" + FullNameEmail + ";"  + InvitadoActividad; 
            //}
            //else
            //{
            MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString() + ";" + FullNameEmail;
            //}

            ConfigMail correoLib = new ConfigMail
            {
                MailDestino = MailDestinoPrincipal,
                Asunto = "ACTIVIDAD : " + ActivityText,
            };

            string cuerpo = string.Empty;
            string urlASSAC = ConfigurationManager.AppSettings["urlASSAC"].ToString();

            string plantilla = correoLib.ObtenerPlantilla("04_Generar_Actividad");

            //cuerpo = plantilla.Replace("[USUARIO]", Usuario);
            //cuerpo = cuerpo.Replace("[ACTIVIDAD]", ActivityText);
            cuerpo = plantilla.Replace("[NUMEROTICKET]", NroTicket);
            cuerpo = cuerpo.Replace("[OPERATIONNAME]", OperationName);
            cuerpo = cuerpo.Replace("[RESPONSABLE]", FullNameActivity);
            cuerpo = cuerpo.Replace("[FECHACIERRE]", FechaCierre);
            //cuerpo = cuerpo.Replace("[ESTADO]", Estado);
            cuerpo = cuerpo.Replace("[URLASSAC]", urlASSAC);

            correoLib.Cuerpo = cuerpo;
            bool envio = correoLib.EnviarCorreo();

            return envio;
        }

        private bool EditadoEnvioCorreo(string Usuario, string NroTicket, string ActivityText, string FullNameActivity, string FullNameEmail, string FechaCierre, string RegistrationDateString, string OperationName)
        {
            string MailDestinoPrincipal = "";
            //string MailDestinoPrincipal = emailResponsable
            //string estadoActividad = "";

            //if (InvitadoActividad != "")
            //{
            //    MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString() + ";" + FullNameEmail + ";"  + InvitadoActividad; 
            //}
            //else
            //{
            MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString() + ";" + FullNameEmail;
            //}

            ConfigMail correoLib = new ConfigMail
            {
                MailDestino = MailDestinoPrincipal,
                Asunto = "ACTIVIDAD EDITADA : " + ActivityText,
            };

            string cuerpo = string.Empty;
            string urlASSAC = ConfigurationManager.AppSettings["urlASSAC"].ToString();

            string plantilla = correoLib.ObtenerPlantilla("04_Generar_Actividad");

            //cuerpo = plantilla.Replace("[USUARIO]", Usuario);
            cuerpo = plantilla.Replace("[ACTIVIDAD]", ActivityText);
            cuerpo = cuerpo.Replace("[NUMEROTICKET]", NroTicket);
            cuerpo = cuerpo.Replace("[RESPONSABLE]", FullNameActivity);
            cuerpo = cuerpo.Replace("[FECHACIERRE]", FechaCierre);
            cuerpo = cuerpo.Replace("[OPERATIONNAME]", OperationName);
            //cuerpo = cuerpo.Replace("[ESTADO]", Estado);
            cuerpo = cuerpo.Replace("[URLASSAC]", urlASSAC);

            correoLib.Cuerpo = cuerpo;
            bool envio = correoLib.EnviarCorreo();

            return envio;
        }

        public JsonResult ListarActivityBusqueda(string NroTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Activity().ListarActivityBusqueda(NroTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActividadesCompletadas(string StartDate, string EndDate, string IdUsuarios)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Activity().ListarActividadesCompletadas(StartDate, EndDate, IdUsuarios, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActivityCreado(string NroTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Activity().ListarActivityCreado(NroTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActivityCreadoUsuario(string NroTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Activity().ListarActivityCreadoUsuario(NroTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActivityExpirationbDash(string NroTicket, string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Activity().ListarActivityExpirationbDash(NroTicket, RegistrationUser, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActivityToTicketToAct(int IdTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Activity().ListarActivityToTicketToAct(IdTicket);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActivityToTicketToActPendiente(int IdTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            int RegistrationUser = 0;
            RegistrationUser = Convert.ToInt32(usuario[0]);

            

            var lista = new BL_Activity().ListarActivityToTicketToActPendiente(IdTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActivityToTicketToActCompletado(int IdTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            int RegistrationUser = 0;
            RegistrationUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Activity().ListarActivityToTicketToActCompletado(IdTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActivityCreadoDASH(string NroTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Activity().ListarActivityCreadoDASH(NroTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarDescriptionVitacora(string NroTicket)
        {
            BE_Board bE_Board = new BE_Board();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Board.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Board.RegistrationUser;

            var lista = new BL_Activity().ListarDescriptionVitacora(NroTicket , RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarDescriptionVitacoraActivityDetail(int IdActivity)
        {
            BE_Board bE_Board = new BE_Board();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Board.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Board.RegistrationUser;

            var lista = new BL_Activity().ListarDescriptionVitacoraActivityDetail(IdActivity, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActividadesTodas(int IdPerson, string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Activity().ListarActividadesTodas(RegistrationUser, IdPerson, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListValidationActivity(int IdActivity)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Activity().ListValidationActivity(IdActivity);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarInformeDetalleActivity(int IdActivity)
        {
            BE_ActivityDetail bE_ActivityDetail = new BE_ActivityDetail();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_ActivityDetail.RegistrationUser = Convert.ToInt32(usuario[0]);

            bE_ActivityDetail.IdActivity = IdActivity;

            var lista = new BL_Activity().ListarInformeDetalleActivity(bE_ActivityDetail);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActividadesCompletas(string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Activity().ListarActividadesCompletas(RegistrationUser, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult EditPercentageActivity(int IdActivity , string NumberPercentage)
        {
            BE_Activity bE_Activity = new BE_Activity();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Activity.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Activity.RegistrationUser;

            bE_Activity.IdActivity = IdActivity;
            bE_Activity.PercentageNumber = NumberPercentage;

            var lista = new BL_Activity().EditPercentageActivity(bE_Activity);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ValidationEnableActivity(int IdActivity, string ValidationButton)
        {
            BE_Activity bE_Activity = new BE_Activity();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Activity.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Activity.RegistrationUser;

            bE_Activity.IdActivity = IdActivity;
            bE_Activity.ValidationButton = ValidationButton;

            var lista = new BL_Activity().ValidationEnableActivity(bE_Activity);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ActivityFinish(int IdActivity)
        {
            BE_Activity bE_Activity = new BE_Activity();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Activity.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Activity.RegistrationUser;

            bE_Activity.IdActivity = IdActivity;

            var lista = new BL_Activity().ActivityFinish(bE_Activity);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult StatusActivities(int IdTicket)
        {
            BE_Activity bE_Activity = new BE_Activity();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Activity.RegistrationUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Activity().StatusActivities(IdTicket);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CrearReportActivityDetail(int IdActivityDetail, int IdActivity,string TitleReport, int ForWhoReport, string ReportMatter, string OperationName, string StartDateReport, string ReportBackgroundActivity, string ReportConclusionActivity, string ReportActivityDevelop, string ReportRecommendationActivity)
        {
            BE_ActivityDetail bE_ActivityDetail = new BE_ActivityDetail();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_ActivityDetail.RegistrationUser = Convert.ToInt32(usuario[0]);

            bE_ActivityDetail.IdActivity = IdActivity;
            bE_ActivityDetail.TituloInforme = TitleReport;
            bE_ActivityDetail.ParaQuienInforme = ForWhoReport;
            bE_ActivityDetail.AsuntoInforme = ReportMatter;
            bE_ActivityDetail.OperacionNombre = OperationName;
            bE_ActivityDetail.FechaRegistroInforme = StartDateReport;
            bE_ActivityDetail.AntecedentesInforme = ReportBackgroundActivity;
            bE_ActivityDetail.ConclusionesInforme = ReportConclusionActivity;
            bE_ActivityDetail.ActivityDevelopInforme = ReportActivityDevelop;
            bE_ActivityDetail.RecomendacionesInforme = ReportRecommendationActivity;
            bE_ActivityDetail.IdActivityDetail = IdActivityDetail;

            var resultado = "";

            if (IdActivityDetail == 0)
            {
                resultado = new BL_Activity().CrearReportActivityDetail(bE_ActivityDetail);
            }
            else
            {
                resultado = new BL_Activity().EditarReportActivityDetail(bE_ActivityDetail);
            }

            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult GeneratePDF(string TituloInforme, string ParaQuienInforme, string AsuntoInforme, string OperacionInforme, string FechaRegistroInforme, string AntecedenteInforme, string ConclusionesInforme, string ReportActivityDevelop, string RecomendacionesInforme)
        {
            //string MailDestinoPrincipal = "";
            //string MailDestinoPrincipal = emailResponsable
            //string estadoActividad = "";

            //if (InvitadoActividad != "")
            //{
            //    MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString() + ";" + FullNameEmail + ";"  + InvitadoActividad; 
            //}
            //else
            //{
            //MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString() + ";" + FullNameEmail;
            //}
            var EnviarCorreo = CreatePDF(TituloInforme,ParaQuienInforme,AsuntoInforme,OperacionInforme,FechaRegistroInforme,AntecedenteInforme,ConclusionesInforme, ReportActivityDevelop, RecomendacionesInforme);

            var a = Json(EnviarCorreo, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        private string CreatePDF(string TituloInforme, string ParaQuienInforme, string AsuntoInforme, string OperacionInforme, string FechaRegistroInforme, string AntecedenteInforme ,string ConclusionesInforme, string ReportActivityDevelop, string RecomendacionesInforme)
        {
            string MailDestinoPrincipal = "";
            //string MailDestinoPrincipal = emailResponsable
            string estadoActividad = "";

            //if (InvitadoActividad != "")
            //{
            //    MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString() + ";" + FullNameEmail + ";"  + InvitadoActividad; 
            //}
            //else
            //{
            MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString();
            //}

            ConfigMail correoLib = new ConfigMail
            {
                MailDestino = "",
                Asunto = ""
            };

            string cuerpo = string.Empty;
            //string urlASSAC = ConfigurationManager.AppSettings["urlASSAC"].ToString();

            string plantilla = correoLib.ObtenerPlantilla("Plantillas-Informe-Assac");

            cuerpo = plantilla.Replace("[TITULO]", TituloInforme);
            cuerpo = cuerpo.Replace("[OPERACION]", OperacionInforme);
            cuerpo = cuerpo.Replace("[DEQUIEN]", ParaQuienInforme);
            cuerpo = cuerpo.Replace("[ASUNTO]", AsuntoInforme);
            cuerpo = cuerpo.Replace("[FECHA]", FechaRegistroInforme);
            cuerpo = cuerpo.Replace("[OPERACION2]", OperacionInforme);
            cuerpo = cuerpo.Replace("[ANTECEDENTES]", AntecedenteInforme);
            cuerpo = cuerpo.Replace("[DESARROLLOACTIVIDADES]", ReportActivityDevelop);
            cuerpo = cuerpo.Replace("[CONCLUSIONES]", ConclusionesInforme);
            cuerpo = cuerpo.Replace("[RECOMENDACIONES]", RecomendacionesInforme);

            //correoLib.Cuerpo = cuerpo;
            //bool envio = correoLib.EnviarCorreo();

            return cuerpo;
        }

        public JsonResult ChangeStatus(int IdActivity, string Comentario)
        {
            BE_Activity bE_Activity = new BE_Activity();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Activity.RegistrationUser = Convert.ToInt32(usuario[0]);
            bE_Activity.ValorConsulta = "1";

            //var resultado = bE_Ticket;
            //resultado = bE_Ticket;
            var RegistrationUser = 0;
            RegistrationUser = bE_Activity.RegistrationUser;

            var resultado = new BL_Activity().ChangeStatus(IdActivity, Comentario, RegistrationUser);

            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;

        }
    }
}