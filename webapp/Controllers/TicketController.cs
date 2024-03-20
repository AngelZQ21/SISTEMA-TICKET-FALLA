using CL_BE;
using CL_BL;
using SmartAdminMvc.Libs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class TicketController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VTicket()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "Ticket", "VTicket");

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

        public JsonResult CrearTicket(BE_Ticket bE_Ticket)
        {
            //BE_Ticket bE_Ticket = new BE_Ticket();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);


            var resultado = new BL_Ticket().CrearTicket(bE_Ticket);

            if (resultado.Count > 0)
            {
                var EnviarCorreo = EnvioCorreo(usuario[4], resultado[0].NroTicket, resultado[0].ResponsibleNameTicket, resultado[0].CriticalityName, resultado[0].StartDate , resultado[0].PersonMail , bE_Ticket.InvitadoTicket, resultado[0].EmailWhoCall, bE_Ticket.StatusCategory , resultado[0].TitleDescription , resultado[0].OperationName);

                if (EnviarCorreo == true)
                {
                    var json = Json(resultado, JsonRequestBehavior.AllowGet);
                    json.MaxJsonLength = int.MaxValue;
                    return json;
                }
                else
                {
                    return Json(4, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json(2, JsonRequestBehavior.AllowGet);
            }

           

            //if (EnviarCorreo == true)
            //{
            //    return Json(lista, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json(4, JsonRequestBehavior.AllowGet);
            //}
        }

        public JsonResult ReenviarTicket(BE_Ticket bE_Ticket)
        {
            //BE_Ticket bE_Ticket = new BE_Ticket();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);
            bE_Ticket.ValorConsulta = "1";

            //var resultado = bE_Ticket;
            //resultado = bE_Ticket;

            var resultado = new BL_Ticket().ListNumberTicket(bE_Ticket);

            StringBuilder BuilderTable = new StringBuilder();

            if(bE_Ticket.ArrayListadoActividades != null )
            {
               for (var i = 0; i < bE_Ticket.ArrayListadoActividades.Count; i++)
               {
                   BuilderTable.Append("<tr style='border: 1px solid black; border - collapse: collapse; width: 600px' >");
                   BuilderTable.Append("<td style='width: 150px; border: 1px solid black; border - collapse: collapse;'>" + bE_Ticket.ArrayListadoActividades[i].ActivityText + "</td>");
                   BuilderTable.Append("<td style='width: 150px; border: 1px solid black; border - collapse: collapse;'>" + bE_Ticket.ArrayListadoActividades[i].FullNameActivity + "</td>");
                   BuilderTable.Append("<td style='width: 150px; border: 1px solid black; border - collapse: collapse;'>" + bE_Ticket.ArrayListadoActividades[i].FechaCierre + "</td>");
                   BuilderTable.Append("<td style='width: 150px; border: 1px solid black; border - collapse: collapse;'>" + bE_Ticket.ArrayListadoActividades[i].Estado + "</td>");
                   //builder.Append("<td>" + data.docType + "</td>");
                   //builder.Append("<td>" + data.uploadedBy + "</td>");
                   //builder.Append("<td>" + data.uploadedOn + "</td>");
                   //builder.Append("<td>" + data.docStatus + "</td>");
                   BuilderTable.Append("</tr>");
               }
            }

            var EnviarCorreo = EnvioCorreoReenviar(usuario[4], resultado[0].NroTicket, resultado[0].ResponsibleNameTicket, resultado[0].CriticalityName, resultado[0].StartDate,  bE_Ticket.InvitadoTicket , BuilderTable , bE_Ticket.DetalleCorreo, bE_Ticket.StatusCategory, resultado[0].TitleDetalle, resultado[0].OperationName);

            if (EnviarCorreo == true)
            {
                var json = Json("1", JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;
            }
            else
            {
                return Json("4", JsonRequestBehavior.AllowGet);

            }

        }

        private bool EnvioCorreo(string Usuario, string NroTicket, string ResponsibleNameTicket, string CriticalityName, string StartDate, string emailResponsable, string InvitadoTicket, string EmailWhoCall, string StatusCategory, string TituloTicket, string OperationName)
        {
            //string MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString();

            string MailDestinoPrincipal;
            string TextoStatusCategory;

            if (StatusCategory == "E")
            {

                TextoStatusCategory = "FALLA SISTEMA";

            }
            else if (StatusCategory == "R")
            {

                TextoStatusCategory = "REQUERIMIENTO";

            }
            else
            {

                TextoStatusCategory = "NUEVO PROYECTO";

            }

            if (InvitadoTicket == "" || InvitadoTicket == null)
            {
                MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString()
                +";" + emailResponsable + ";" + EmailWhoCall;
                //MailDestinoPrincipal = emailResponsable;
            }
            else
            {

                MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString()
                +";" + emailResponsable + ";" + EmailWhoCall + ";" + InvitadoTicket;
            }

            //string MailDestinoPrincipal = emailResponsable;

            ConfigMail correoLib = new ConfigMail
            {
                MailDestino = MailDestinoPrincipal,
                Asunto = " TICKET : " + TituloTicket,
            };

            string cuerpo = string.Empty;
            string urlASSAC = ConfigurationManager.AppSettings["urlASSAC"].ToString();

            string plantilla = correoLib.ObtenerPlantilla("03_Generar_Ticket");

            //cuerpo = plantilla.Replace("[USUARIO]", Usuario);
            cuerpo = plantilla.Replace("[NUMEROTICKET]", NroTicket);
            cuerpo = cuerpo.Replace("[OPERATIONNAME]", OperationName);
            cuerpo = cuerpo.Replace("[RESPONSABLE]", ResponsibleNameTicket);
            cuerpo = cuerpo.Replace("[EVENTO]", TextoStatusCategory);
            cuerpo = cuerpo.Replace("[CRITICIDAD]", CriticalityName);
            cuerpo = cuerpo.Replace("[FECHA]", StartDate);
            cuerpo = cuerpo.Replace("[URLASSAC]", urlASSAC);
            //cuerpo = cuerpo.Replace("[TABLAACTIVIDAD]", BuilderTable.ToString());
            correoLib.Cuerpo = cuerpo;
            bool envio = correoLib.EnviarCorreo();

            return envio;
        }

        private bool EnvioCorreoReenviar(string Usuario, string NroTicket, string ResponsibleNameTicket, string CriticalityName, string StartDate, string InvitadoTicket, StringBuilder BuilderTable , string DetalleAsuntoCorreo , string StatusCategory , string TituloTicket,  string OperationName)
        {
            //string MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString();

            string TextoStatusCategory;

            if (StatusCategory == "E")
            {

                TextoStatusCategory = "FALLA SISTEMA";

            }
            else if (StatusCategory == "R")
            {

                TextoStatusCategory = "REQUERIMIENTO";

            }
            else
            {

                TextoStatusCategory = "NUEVO PROYECTO";

            }

            string MailDestinoPrincipal;

            if (InvitadoTicket == "")
            {
                MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString();
                //MailDestinoPrincipal = emailResponsable;
            }
            else
            {
                MailDestinoPrincipal = ConfigurationManager.AppSettings["CorreosPrincipal"].ToString() + ";"
                     //+ emailResponsable + ";"
                     + InvitadoTicket;
            }

            //string MailDestinoPrincipal = emailResponsable;

            ConfigMail correoLib = new ConfigMail
            {
                MailDestino = MailDestinoPrincipal,
                Asunto = " TICKET : " + TituloTicket,
            };

            string cuerpo = string.Empty;
            string urlASSAC = ConfigurationManager.AppSettings["urlASSAC"].ToString();

            string plantilla = correoLib.ObtenerPlantilla("03_Generar_Ticket_2");

            cuerpo = plantilla.Replace("[NUMEROTICKET]", NroTicket);
            cuerpo = cuerpo.Replace("[OPERATIONNAME]", OperationName);
            cuerpo = cuerpo.Replace("[RESPONSABLE]", ResponsibleNameTicket);
            cuerpo = cuerpo.Replace("[EVENTO]", TextoStatusCategory);
            cuerpo = cuerpo.Replace("[CRITICIDAD]", CriticalityName);
            cuerpo = cuerpo.Replace("[FECHA]", StartDate);
            cuerpo = cuerpo.Replace("[URLASSAC]", urlASSAC);
            cuerpo = cuerpo.Replace("[COMENTARIOTICKET]", DetalleAsuntoCorreo);

            if (BuilderTable.Length > 0)
            {
                cuerpo = cuerpo.Replace("[TABLAACTIVIDAD]", BuilderTable.ToString());
            }
            else
            {
                cuerpo = cuerpo.Replace("[TABLAACTIVIDAD]", "");
            }

            correoLib.Cuerpo = cuerpo;
            bool envio = correoLib.EnviarCorreo();

            return envio;
        }

        public JsonResult ListarTicketCreado(string StartDate, string EndDate, string IdTicket, int ValueFilter)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketCreado(StartDate, EndDate, IdTicket, ValueFilter);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketBusqueda(string StartDate, string EndDate, string StatusCategory, string NumberTicketSearch, string FilterType)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketBusqueda(StartDate, EndDate, RegistrationUser, StatusCategory, NumberTicketSearch, FilterType);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketPendientes(string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);
            bE_Ticket.StatusCategory = StatusCategory;
            //bE_Ticket.ValorConsulta = "1";

            var lista = new BL_Ticket().ListarTicketPendientes(bE_Ticket);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketCompletados()
        {
            BE_Ticket bE_Ticket = new BE_Ticket();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);
            //bE_Ticket.ValorConsulta = "1";

            var lista = new BL_Ticket().ListarTicketCompletados(bE_Ticket);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActividadesXOperacion()
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarActividadesXOperacion(RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketsXOperacion(string fechaInicio, string fechaFin, string Estado, string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketsXOperacion(RegistrationUser, fechaInicio, fechaFin, Estado, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListCycleTicketVehicle(string ValueYear, string ValueMonth)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            var lista = new BL_Ticket().ListCycleTicketVehicle(ValueYear, ValueMonth);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketsXMeses(string fechaInicio, string fechaFin, string Estado, string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketsXMeses(RegistrationUser, fechaInicio, fechaFin, Estado, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActividadesXUsuario(string fechaInicio, string fechaFin, string Estado, string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarActividadesXUsuario(RegistrationUser, fechaInicio, fechaFin, Estado, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketXActividad(int IdTicket, string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketXActividad(IdTicket, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActividadesXUsuarioASSAC()
        {
            var lista = new BL_Ticket().ListarActividadesXUsuarioASSAC();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListActivityXTicket(string fechaInicio, string fechaFin, string Estado, string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListActivityXTicket(fechaInicio, fechaFin, Estado, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarArchivoTicket(int IdTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var lista = new BL_Ticket().ListarArchivoTicket(IdTicket);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult AnularTicket(int IdTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().AnularTicket(IdTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketCriticidad(string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketCriticidad(RegistrationUser, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketBuscarUsuario(int IdPerson, string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketBuscarUsuario(RegistrationUser, IdPerson, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketCriticidadMediaCA(string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketCriticidadMediaCA(RegistrationUser, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketCriticidadBajaCA(string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketCriticidadBajaCA(RegistrationUser, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketMedia(string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketMedia(RegistrationUser, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketGraphic(string OperationName)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketGraphic(OperationName);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketResponsibleGraphic(int IdResponsible)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketResponsibleGraphic(IdResponsible);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarFileTicketGraphic(int IdTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarFileTicketGraphic(IdTicket);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketPorActividad(int IdTicket, string Estado)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketPorActividad(IdTicket, Estado);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketBaja(string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketBaja(RegistrationUser, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketAlta(string StatusCategory)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketAlta(RegistrationUser, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActRefereceTicket(string NroTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarActRefereceTicket(NroTicket);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActRefereceTicketPendiente(string NroTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarActRefereceTicketPendiente(NroTicket);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActRefereceTicketCompletado(string NroTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarActRefereceTicketCompletado(NroTicket);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketCombo()
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketCombo(RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketxResponsable(string StartDate, string EndDate , string IdsResponsible , string IdsTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketxResponsable(StartDate , EndDate , IdsResponsible, IdsTicket,  RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketxResponsable2(string StartDate, string EndDate, string IdsTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketxResponsable2(StartDate, EndDate, IdsTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarDetalleTicketGraphic(string NumberTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarDetalleTicketGraphic(NumberTicket);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult EditarResponsible(int ResponsibleId, int TicketId)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().EditarResponsible(ResponsibleId, TicketId, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ActualizarSolutionTicketMovil(int TicketIdMovil, string ValueLstComponent, string ValueProblem, string ValueSolution)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ActualizarSolutionTicketMovil(TicketIdMovil, ValueLstComponent, ValueProblem, ValueSolution, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ActualizarDetalleTicketMovil(int TicketIdMovil, string TitleDetailMovil, int IdLocationDetail, string DetailTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ActualizarDetalleTicketMovil(TicketIdMovil, TitleDetailMovil, IdLocationDetail, DetailTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult EditarTicketResponsible(int ResponsibleId, string TicketId)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            //var RegistrationUser = 0;
            //RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().EditarTicketResponsible(ResponsibleId, TicketId);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult AnularArchivoTicket(int IdTicketFile)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().AnularArchivoTicket(IdTicketFile, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult TicketClose(int IdTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().TicketClose(IdTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult TicketOperando(int IdTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().TicketOperando(IdTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarResponsableReport(string StartDate, string EndDate, string IdsResponsible, string NumberTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarResponsableReport(StartDate, EndDate, IdsResponsible, NumberTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
        
        public JsonResult ListarTicketsCompletados(string StartDate, string EndDate, string IdTickets)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketsCompletados(StartDate, EndDate, IdTickets, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ChangeStatus(int IdTicket, string Comentario)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);
            bE_Ticket.ValorConsulta = "1";

            //var resultado = bE_Ticket;
            //resultado = bE_Ticket;
            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var resultado = new BL_Ticket().ChangeStatus(IdTicket , Comentario , RegistrationUser);

            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
            
        }

        public JsonResult ListarTreeViewTicketActivity(string idTickets, string FechaInicio, string FechaFin, string ValueRadio)
        {
            var lista = new BL_Ticket().ListarTreeViewTicketActivity(idTickets, FechaInicio, FechaFin, ValueRadio);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketsMenu(string ValueTicketMenu)
        {
            var lista = new BL_Ticket().ListarTicketsMenu(ValueTicketMenu);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActivityMenu(string ValueActivityMenu)
        {
            var lista = new BL_Ticket().ListarActivityMenu(ValueActivityMenu);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketDiaHoy(string StatusCategory, int OperationId)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ListarTicketToday(RegistrationUser, StatusCategory, OperationId);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult CantidadTicketByEvent()
        {
            var lista = new BL_Ticket().CantidadTicketByEvent();
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarTicketsHistoricos(string StatusCategory, string StartDate, string EndDate)
        {
            var lista = new BL_Ticket().ListarTicketsHistoricos(StatusCategory, StartDate, EndDate);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListarActivityByreponsible(string StatusValue, string ReponsibleId, string StatusCategory)
        {
            var lista = new BL_Ticket().ListarActivityByreponsible(StatusValue, ReponsibleId, StatusCategory);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListQuantityTicketStatus(string fechaInicio, string fechaFin, string ValueTicketFilter)
        {
            BE_Grafic_Value bE_Grafic_Value = new BE_Grafic_Value();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Grafic_Value.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Grafic_Value.RegistrationUser;

            var lista = new BL_Ticket().ListQuantityTicketStatus(RegistrationUser, fechaInicio, fechaFin, ValueTicketFilter);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult ListQuantityTickePenCom(string StatusTicket, string StatusTicketCreation, string ValueTicketFilter, string OperationId)
        {
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            var lista = new BL_Ticket().ListQuantityTickePenCom(StatusTicket, StatusTicketCreation, ValueTicketFilter, OperationId);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
        
        public JsonResult CrearReportTicketDetail(int IdTicketDetailReports, int IdTicket, string TitleReport, int ForWhoReport, string ReportMatter, string OperationName, string StartDateReport, string ReportBackgroundActivity, string ReportConclusionActivity, string ReportActivityDevelop, string ReportRecommendationActivity)
        {
            BE_TicketDetail bE_TicketDetail = new BE_TicketDetail();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_TicketDetail.RegistrationUser = Convert.ToInt32(usuario[0]);

            bE_TicketDetail.IdTicketDetailReports = IdTicketDetailReports;
            bE_TicketDetail.IdTicket = IdTicket;
            bE_TicketDetail.TituloInforme = TitleReport;
            bE_TicketDetail.ParaQuienInforme = ForWhoReport;
            bE_TicketDetail.AsuntoInforme = ReportMatter;
            bE_TicketDetail.OperacionNombre = OperationName;
            bE_TicketDetail.FechaRegistroInforme = StartDateReport;
            bE_TicketDetail.AntecedentesInforme = ReportBackgroundActivity;
            bE_TicketDetail.ConclusionesInforme = ReportConclusionActivity;
            bE_TicketDetail.ActivityDevelopInforme = ReportActivityDevelop;
            bE_TicketDetail.RecomendacionesInforme = ReportRecommendationActivity;
            
            var resultado = "";

            if (IdTicketDetailReports == 0)
            {
                resultado = new BL_Ticket().CrearReportTicketDetail(bE_TicketDetail);
            }
            else
            {
                resultado = new BL_Ticket().EditReportTicketDetail(bE_TicketDetail);
            }

            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult ValidationByOperation(int IdTicket)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_Ticket().ValidationByOperation(IdTicket, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }
    }
}