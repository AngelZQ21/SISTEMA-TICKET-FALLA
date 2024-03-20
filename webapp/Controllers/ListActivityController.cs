using CL_BE;
using CL_BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class ListActivityController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VlistActivity()
        {
            try
            {
                string[] stringSeparators = new string[] { "," };
                string usuariocadena = @User.Identity.Name.ToUpper();
                string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string Valicacion = new BL_Menu().ValidarMenuPerfilActual(Convert.ToInt32(usuario[2]), "ListActivity", "VlistActivity");

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

        public JsonResult ListadoActividaDesUsuarios(string StartDate, string EndDate,string IdsTicket, string IdsPeople)
        {
            BE_Ticket bE_Ticket = new BE_Ticket();
            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Ticket.RegistrationUser = Convert.ToInt32(usuario[0]);

            var RegistrationUser = 0;
            RegistrationUser = bE_Ticket.RegistrationUser;

            var lista = new BL_ListActivity().ListadoActividaDesUsuarios(StartDate, EndDate, IdsTicket, IdsPeople, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult RegistrarActivityDetail(int IdActivityDetail, int IdActivity, string NroTicket ,string Comentario, string idsPathFileUpdate  ,string[] RutasArchivosMover)
        {

            string pathFileAnterior = "";
            string pathFileActual = "";
            string pathFileUpdate = "";
            var resultadoValidacion = "";

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            BE_ActivityDetail bE_ActivityDetail = new BE_ActivityDetail();
            //bE_Quotation.QuotationNumber = NroCotizacion;
            //bE_Quotation.QuotationDateString = FechaCotizacion;
            //bE_Quotation.QuotationDateRequestString = FechaCotizacionServicio;
            //bE_Quotation.QuotationDaysValidation = DiasVigencia;
            bE_ActivityDetail.IdActivity = IdActivity;
            //bE_ActivityDetail.Commentary = Comentario.Trim().ToUpper();
            //bE_Quotation.bE_Company = new BE_Company();
            //bE_Quotation.bE_Company.IdCompany = IdCompany;
            //bE_Quotation.bE_Contact = new BE_Contact();
            //bE_Quotation.bE_Contact.IdContact = IdContact;
            bE_ActivityDetail.idsPathFileUpdate = idsPathFileUpdate;

            var lista = "";

            //if (Desestimar != 0)
            //{
            //    bE_Quotation.RegistrationUser = Convert.ToInt32(usuario[0]);
            //    bE_Quotation.IdQuotation = Desestimar;
            //    lista = new BL_Quotation().DesestimarCotizacion(bE_Quotation);
            //}
            if (IdActivityDetail != 0)
            {
                //bE_ActivityDetail.UpdateUser = Convert.ToInt32(usuario[0]);
                //bE_ActivityDetail.IdActivityDetail = IdActivityDetail;
                //lista = new BL_ListActivityDetail().ActualizarActivityDetail(bE_ActivityDetail);
            }
            else
            {
                bE_ActivityDetail.RegistrationUser = Convert.ToInt32(usuario[0]);
                lista = new BL_ListActivityDetail().RegistrarActivityDetail(bE_ActivityDetail);
            }

            int contError = 0;


            if (lista == "1")
            {
                pathFileActual = AppDomain.CurrentDomain.BaseDirectory + "/COTIZACION/" + NroTicket + "/";

                if (!Directory.Exists(pathFileActual))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathFileActual);
                }

                for (int i = 0; i < RutasArchivosMover.Length; i++)
                {
                    pathFileAnterior = AppDomain.CurrentDomain.BaseDirectory + RutasArchivosMover[i].Replace("../", "/");
                    pathFileUpdate = pathFileActual + System.IO.Path.GetFileName(RutasArchivosMover[i]);

                    if (pathFileAnterior != pathFileUpdate)
                    {
                        if (System.IO.File.Exists(pathFileUpdate))
                        {
                            System.IO.File.Delete(pathFileUpdate);
                        }
                        System.IO.File.Move(pathFileAnterior, pathFileUpdate);

                        resultadoValidacion = new BL_PathFile().ActualizarRutaArchivo(Convert.ToInt32(usuario[0]), RutasArchivosMover[i], "../COTIZACION/" + NroTicket + "/" + System.IO.Path.GetFileName(RutasArchivosMover[i]));

                        if (resultadoValidacion != "1")
                        {
                            contError++;
                        }
                        else
                        {
                            if (RutasArchivosMover[i].Contains("/Temporal/") == true)
                            {
                                Directory.Delete(System.IO.Path.GetDirectoryName(pathFileAnterior));
                            }
                        }
                    }
                }

                return Json(lista, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(lista, JsonRequestBehavior.AllowGet);
            }

            //if (contError == 0)
            //{
            //    string estadoCot = "";
            //    if (IdCotizacion == 0)
            //    {
            //        estadoCot = "CREADO";
            //    }
            //    else
            //    {
            //        estadoCot = "ACTUALIZADO";
            //    }

            //    var EnviarCorreo = EnvioCorreo(usuario[4], NroCotizacion, CompanyName, estadoCot);

            //    if (EnviarCorreo == true)
            //    {

            //    }
            //    else
            //    {
            //        return Json(4, JsonRequestBehavior.AllowGet);
            //    }


            //}
            //else
            //{
            //    return Json(3, JsonRequestBehavior.AllowGet);
            //}
            
        }

        public JsonResult UpdateStateActivityDetail(int ActivityId, string NroTicket)
        {
            BE_ActivityDetail bE_ActivityDetail = new BE_ActivityDetail();

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_ActivityDetail.RegistrationUser = Convert.ToInt32(usuario[0]);

            bE_ActivityDetail.IdActivity = ActivityId;
            bE_ActivityDetail.NumberTicket = NroTicket;

            var resultado = new BL_ListActivityDetail().UpdateStateActivityDetail(bE_ActivityDetail);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

    }
}