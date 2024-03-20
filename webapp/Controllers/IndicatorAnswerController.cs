using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CL_BE;
using CL_BL;
using System.Web.Security;
using System.IO;
namespace SmartAdminMvc.Controllers
{
    public class IndicatorAnswerController : Controller
    {
        // GET: IndicatorAnswer
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CrearRespuestaIndicador(int IdIndicatorUser, string Comment)
        {
            BE_Indicator_Answer bE_Indicator_Answer = new BE_Indicator_Answer();
            BE_Indicator_User bE_Indicator_User = new BE_Indicator_User();
            bE_Indicator_User.IdIndicatorUser = IdIndicatorUser;
            bE_Indicator_Answer.bE_Indicator_User = bE_Indicator_User;
            bE_Indicator_Answer.Comment = Comment;
            bE_Indicator_Answer.PathFile = "";
            bE_Indicator_Answer.FileName = "";
            bE_Indicator_Answer.FileSize = 0;
            bE_Indicator_Answer.FileExtension = "";
            bE_Indicator_Answer.FileType = "";
            bE_Indicator_Answer.QueryValue = "0";

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Indicator_Answer.RegistrationUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Indicator_Answer().CrearRespuestaIndicadorAdjunto(bE_Indicator_Answer);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public ActionResult CrearRespuestaIndicadorConAdjunto(int IdIndicatorUser, string TipoIndicador)
        {

            HttpFileCollectionBase files = Request.Files;
            string path = "";
            string isValid = string.Empty;
            string pth = "";
            var Resultado = "";

            try
            {
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                        || Request.Files[upload].ContentType == "image/jpeg"
                        || Request.Files[upload].ContentType == "application/pdf"
                        || Request.Files[upload].ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                        //|| Request.Files[upload].ContentType == "application/octet-stream"
                        || Request.Files[upload].ContentType == "text/plain"
                        //|| Request.Files[upload].ContentType == "application/zip"
                        //|| Request.Files[upload].ContentType == "application/vnd.msg-outlook"
                        || Request.Files[upload].ContentType == "application/vnd.ms-excel")
                    {
                        /* parametros de la fecha actual, se ocupan para crear los directorios*/
                        DateTime fechaActual = DateTime.Now;
                        string Año = fechaActual.Year.ToString();
                        int MesNumero = fechaActual.Month;
                        string NombreMes = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MesNumero);
                        string DiaHoraMinutoSegundo = fechaActual.Day.ToString() + "_" + fechaActual.Hour.ToString() + "_" + fechaActual.Minute.ToString() + "_" + fechaActual.Second.ToString();

                        /* ruta del archivo a guardar */
                        path = AppDomain.CurrentDomain.BaseDirectory + "/" + TipoIndicador + "/" + Año + "/" + NombreMes + "/" + IdIndicatorUser + "/" + DiaHoraMinutoSegundo;
                        /* ruta del directorio del tickets, se ocupa para validar el peso total de los archivos */
                        string pathPrincipal = AppDomain.CurrentDomain.BaseDirectory + "/" + TipoIndicador + "/" + Año + "/" + NombreMes + "/" + IdIndicatorUser;

                        /* verifico si existe la ruta para crearla en caso sea nueva*/
                        if (!Directory.Exists(path))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(path);
                        }
                        /* obtengo los directorios para calcular el peso de todos los archivos del ticket*/
                        DirectoryInfo Directorio = new DirectoryInfo(pathPrincipal);
                        FileInfo[] fiArr = Directorio.GetFiles();
                        long pesoDir = 0;
                        foreach (FileInfo fi in fiArr)
                        {
                            pesoDir += fi.Length;
                        }

                        /* recupero el peso del archivo subido para sumarlo al de todos los archivos y validar el peso total */
                        string PesoArchivo = Path.GetFileName(Request.Files[upload].ContentLength.ToString());
                        if ((pesoDir + Convert.ToInt64(PesoArchivo)) < 20000000)
                        {
                            string NombreArchivo = Path.GetFileName(Request.Files[upload].FileName);
                            string Extencion = Path.GetExtension(Request.Files[upload].FileName);
                            pth = Path.Combine(path, NombreArchivo);
                            Request.Files[upload].SaveAs(pth);

                            BE_Indicator_Answer bE_Indicator_Answer = new BE_Indicator_Answer();
                            string[] stringSeparators = new string[] { "," };
                            string usuariocadena = @User.Identity.Name.ToUpper();
                            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                            BE_Indicator_User bE_Indicator_User = new BE_Indicator_User();
                            bE_Indicator_User.IdIndicatorUser = IdIndicatorUser;
                            bE_Indicator_Answer.bE_Indicator_User = bE_Indicator_User;
                            bE_Indicator_Answer.Comment = "";
                            bE_Indicator_Answer.RegistrationUser = Convert.ToInt16(usuario[0]);
                            bE_Indicator_Answer.PathFile = "../" + TipoIndicador + "/" + Año + "/" + NombreMes + "/" + IdIndicatorUser + "/" + DiaHoraMinutoSegundo + "/" + NombreArchivo;
                            bE_Indicator_Answer.FileName = NombreArchivo;
                            bE_Indicator_Answer.FileSize = Convert.ToInt32(PesoArchivo);
                            bE_Indicator_Answer.FileExtension = Extencion;
                            bE_Indicator_Answer.FileType = TipoIndicador;
                            bE_Indicator_Answer.QueryValue = "1";
                            Resultado = new BL_Indicator_Answer().CrearRespuestaIndicadorAdjunto(bE_Indicator_Answer);
                        }
                        else
                        {
                            Resultado = "101";
                        }
                    }
                    else
                    {
                        Resultado = "102";
                    }
                }
            }
            catch (Exception ex)
            {
                Resultado = ex.Message;
            }

            var json = Json(Resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult ActualizarRespuestaIndicador(int IdIndicatorComment, string Comment)
        {
            BE_Indicator_Answer bE_Indicator_Answer = new BE_Indicator_Answer();
            bE_Indicator_Answer.IdIndicatorComment = IdIndicatorComment;
            bE_Indicator_Answer.Comment = Comment;
            bE_Indicator_Answer.PathFile = "";
            bE_Indicator_Answer.FileName = "";
            bE_Indicator_Answer.FileSize = 0;
            bE_Indicator_Answer.FileExtension = "";
            bE_Indicator_Answer.FileType = "";
            bE_Indicator_Answer.QueryValue = "0";

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Indicator_Answer.RegistrationUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Indicator_Answer().ActualizarRespuestaIndicadorAdjunto(bE_Indicator_Answer);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public ActionResult ActualizarRespuestaIndicadorConAdjunto(int IdIndicatorComment, int IdIndicatorUser, string TipoIndicador)
        {
            HttpFileCollectionBase files = Request.Files;
            string path = "";
            string isValid = string.Empty;
            string pth = "";
            var Resultado = "";

            try
            {
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                        || Request.Files[upload].ContentType == "image/jpeg"
                        || Request.Files[upload].ContentType == "application/pdf"
                        || Request.Files[upload].ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                        //|| Request.Files[upload].ContentType == "application/octet-stream"
                        || Request.Files[upload].ContentType == "text/plain"
                        //|| Request.Files[upload].ContentType == "application/zip"
                        //|| Request.Files[upload].ContentType == "application/vnd.msg-outlook"
                        || Request.Files[upload].ContentType == "application/vnd.ms-excel")
                    {
                        /* parametros de la fecha actual, se ocupan para crear los directorios*/
                        DateTime fechaActual = DateTime.Now;
                        string Año = fechaActual.Year.ToString();
                        int MesNumero = fechaActual.Month;
                        string NombreMes = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MesNumero);
                        string DiaHoraMinutoSegundo = fechaActual.Day.ToString() + "_" + fechaActual.Hour.ToString() + "_" + fechaActual.Minute.ToString() + "_" + fechaActual.Second.ToString();

                        /* ruta del archivo a guardar */
                        path = AppDomain.CurrentDomain.BaseDirectory + "/" + TipoIndicador + "/" + Año + "/" + NombreMes + "/" + IdIndicatorUser + "/" + DiaHoraMinutoSegundo;
                        /* ruta del directorio del tickets, se ocupa para validar el peso total de los archivos */
                        string pathPrincipal = AppDomain.CurrentDomain.BaseDirectory + "/" + TipoIndicador + "/" + Año + "/" + NombreMes + "/" + IdIndicatorUser;

                        /* verifico si existe la ruta para crearla en caso sea nueva*/
                        if (!Directory.Exists(path))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(path);
                        }
                        /* obtengo los directorios para calcular el peso de todos los archivos del ticket*/
                        DirectoryInfo Directorio = new DirectoryInfo(pathPrincipal);
                        FileInfo[] fiArr = Directorio.GetFiles();
                        long pesoDir = 0;
                        foreach (FileInfo fi in fiArr)
                        {
                            pesoDir += fi.Length;
                        }

                        /* recupero el peso del archivo subido para sumarlo al de todos los archivos y validar el peso total */
                        string PesoArchivo = Path.GetFileName(Request.Files[upload].ContentLength.ToString());
                        if ((pesoDir + Convert.ToInt64(PesoArchivo)) < 20000000)
                        {
                            string NombreArchivo = Path.GetFileName(Request.Files[upload].FileName);
                            string Extencion = Path.GetExtension(Request.Files[upload].FileName);
                            pth = Path.Combine(path, NombreArchivo);
                            Request.Files[upload].SaveAs(pth);

                            BE_Indicator_Answer bE_Indicator_Answer = new BE_Indicator_Answer();
                            string[] stringSeparators = new string[] { "," };
                            string usuariocadena = @User.Identity.Name.ToUpper();
                            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                            BE_Indicator_User bE_Indicator_User = new BE_Indicator_User();
                            bE_Indicator_User.IdIndicatorUser = IdIndicatorUser;
                            bE_Indicator_Answer.IdIndicatorComment = IdIndicatorComment;
                            bE_Indicator_Answer.bE_Indicator_User = bE_Indicator_User;
                            bE_Indicator_Answer.Comment = "";
                            bE_Indicator_Answer.RegistrationUser = Convert.ToInt16(usuario[0]);
                            bE_Indicator_Answer.PathFile = "../" + TipoIndicador + "/" + Año + "/" + NombreMes + "/" + IdIndicatorUser + "/" + DiaHoraMinutoSegundo + "/" + NombreArchivo;
                            bE_Indicator_Answer.FileName = NombreArchivo;
                            bE_Indicator_Answer.FileSize = Convert.ToInt32(PesoArchivo);
                            bE_Indicator_Answer.FileExtension = Extencion;
                            bE_Indicator_Answer.FileType = TipoIndicador;
                            bE_Indicator_Answer.QueryValue = "1";
                            Resultado = new BL_Indicator_Answer().ActualizarRespuestaIndicadorAdjunto(bE_Indicator_Answer);
                        }
                        else
                        {
                            Resultado = "101";
                        }
                    }
                    else
                    {
                        Resultado = "102";
                    }
                }
            }
            catch (Exception ex)
            {
                Resultado = ex.Message;
            }

            var json = Json(Resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult EliminarRespuestaIndicador(int IdIndicatorComment)
        {
            BE_Indicator_Answer bE_Indicator_Answer = new BE_Indicator_Answer();
            bE_Indicator_Answer.IdIndicatorComment = IdIndicatorComment;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_Indicator_Answer.RegistrationUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_Indicator_Answer().EliminarRespuestaIndicador(bE_Indicator_Answer);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult ListarRespuestaIndicador(int IdIndicatorUser, int RegistrationUser)
        {
            var lista = new BL_Indicator_Answer().ListarRespuestaIndicador(IdIndicatorUser, RegistrationUser);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

    }
}