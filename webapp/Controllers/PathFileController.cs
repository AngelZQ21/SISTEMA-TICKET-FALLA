using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using CL_BL;
using CL_BE;

namespace SmartAdminMvc.Controllers
{
    public class PathFileController : Controller
    {
        // GET: PathFile
        public ActionResult SubirArchivo(string FileType, int IdRegister, string TableAbrev, string NombreCarpeta)
        {
            /*
                 100-Peso del archivo muye grande
                 101-Se supero el peso maximo por ticket
                 102-No es el archivo correcto
                 103-Se guardo el archivo pero no se guardo la ruta en el servidor             
                 */

            HttpFileCollectionBase files = Request.Files;
            string path = "";
            string isValid = string.Empty;
            string pth = "";
            List<BE_PathFile> Resultado = new List<BE_PathFile>();

            string rutaInicial = "";

            rutaInicial = "/ARCHIVOS/" + NombreCarpeta + "/";
            
            try
            {
                foreach (string upload in Request.Files)
                {
                    var i = Request.Files[upload].ContentType;
                    //string xd = Request.Files[upload].ContentType;
                    if (Request.Files[upload].ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                        || Request.Files[upload].ContentType == "image/jpeg"
                        || Request.Files[upload].ContentType == "image/png"
                        || Request.Files[upload].ContentType == "application/pdf"
                        || Request.Files[upload].ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                        || Request.Files[upload].ContentType == "application/octet-stream"
                        //|| Request.Files[upload].ContentType == "application/zip"
                        || Request.Files[upload].ContentType == "application/vnd.ms-excel"
                        || Request.Files[upload].ContentType == "text/plain")
                    {
                        /* parametros de la fecha actual, se ocupan para crear los directorios*/
                        DateTime fechaActual = DateTime.Now;
                        string Año = fechaActual.Year.ToString();
                        int MesNumero = fechaActual.Month;
                        string diaNumero = fechaActual.Day.ToString();
                        string NombreMes = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MesNumero);
                        string DiaHoraMinutoSegundo = fechaActual.Hour.ToString() + "" + fechaActual.Minute.ToString() + "" + fechaActual.Second.ToString();

                        /* ruta del archivo a guardar */
                        path = AppDomain.CurrentDomain.BaseDirectory + rutaInicial + "/" + Año + "/" + NombreMes + "/dia_" + diaNumero + "/" + DiaHoraMinutoSegundo;
                        /* ruta del directorio del tickets, se ocupa para validar el peso total de los archivos */
                        string pathPrincipal = AppDomain.CurrentDomain.BaseDirectory + rutaInicial + "/" + Año + "/" + NombreMes;

                        /* verifico si existe la ruta para crearla en caso sea nueva*/
                        if (!Directory.Exists(path))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(path);
                        }
                        /* obtengo los directorios para calcular el peso de todos los archivos del ticket*/
                        DirectoryInfo Directorio = new DirectoryInfo(pathPrincipal);
                        FileInfo[] fiArr = Directorio.GetFiles();
                        long pesoDir = 0;
                        //foreach (FileInfo fi in fiArr)
                        //{
                        //    pesoDir += fi.Length;
                        //}
                        /* recupero el peso del archivo subido para sumarlo al de todos los archivos y validar el peso total */
                        string PesoArchivo = Path.GetFileName(Request.Files[upload].ContentLength.ToString());
                        //if ((pesoDir + Convert.ToInt64(PesoArchivo)) < 20000000)
                        //{
                        string NombreArchivo = Path.GetFileName(Request.Files[upload].FileName);
                        string Extencion = Path.GetExtension(Request.Files[upload].FileName);
                        pth = Path.Combine(path, NombreArchivo);
                        Request.Files[upload].SaveAs(pth);

                        BE_PathFile bE_PathFile = new BE_PathFile();
                        string[] stringSeparators = new string[] { "," };
                        string usuariocadena = @User.Identity.Name.ToUpper();
                        string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                        bE_PathFile.RegistrationUser = Convert.ToInt32(usuario[0]);
                        bE_PathFile.PathFile = ".." + rutaInicial + "/" + Año + "/" + NombreMes + "/dia_" + diaNumero + "/" + DiaHoraMinutoSegundo + "/" + NombreArchivo;
                        bE_PathFile.FileNameRegister = NombreArchivo;
                        bE_PathFile.FileSize = PesoArchivo;
                        bE_PathFile.FileExtension = Extencion;
                        bE_PathFile.FileType = FileType.Trim().ToUpper();
                        bE_PathFile.IdRegister = IdRegister;
                        bE_PathFile.FileTableAbbreviation = TableAbrev.Trim().ToUpper();

                        Resultado = new BL_PathFile().CrearRuta(bE_PathFile);
                        //}
                        //else
                        //{
                        //    Resultado = "101";
                        //}

                    }
                    else
                    {
                        BE_PathFile bE_Path = new BE_PathFile();
                        bE_Path.ValorConsulta = "102";
                        Resultado.Add(bE_Path);

                        //Resultado = "102";
                    }
                }
            }
            catch (Exception ex)
            {
                BE_PathFile bE_Path = new BE_PathFile();
                bE_Path.MensajeConsulta = ex.Message;
                Resultado.Add(bE_Path);

                //Resultado = ex.Message;
            }

            var json = Json(Resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public ActionResult SubirArchivoActivity(string FileType, int IdRegister, string TableAbrev, string NombreCarpeta , string OperacionName)
        {
            /*
                 100-Peso del archivo muye grande
                 101-Se supero el peso maximo por ticket
                 102-No es el archivo correcto
                 103-Se guardo el archivo pero no se guardo la ruta en el servidor             
                 */

            HttpFileCollectionBase files = Request.Files;
            string path = "";
            string isValid = string.Empty;
            string pth = "";
            List<BE_PathFile> Resultado = new List<BE_PathFile>();

            string rutaInicial = "";

            rutaInicial = "/ARCHIVOS/" + NombreCarpeta + "/";

            try
            {
                foreach (string upload in Request.Files)
                {
                    var i = Request.Files[upload].ContentType;
                    //string xd = Request.Files[upload].ContentType;
                    if (Request.Files[upload].ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                        || Request.Files[upload].ContentType == "image/jpeg"
                        || Request.Files[upload].ContentType == "image/png"
                        || Request.Files[upload].ContentType == "application/pdf"
                        || Request.Files[upload].ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                        || Request.Files[upload].ContentType == "application/octet-stream"
                        //|| Request.Files[upload].ContentType == "application/zip"
                        || Request.Files[upload].ContentType == "application/vnd.ms-excel"
                        || Request.Files[upload].ContentType == "text/plain")
                    {
                        /* parametros de la fecha actual, se ocupan para crear los directorios*/
                        DateTime fechaActual = DateTime.Now;
                        string Año = fechaActual.Year.ToString();
                        int MesNumero = fechaActual.Month;
                        string diaNumero = fechaActual.Day.ToString();
                        string NombreMes = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MesNumero);
                        string DiaHoraMinutoSegundo = fechaActual.Hour.ToString() + "" + fechaActual.Minute.ToString() + "" + fechaActual.Second.ToString();

                        /* ruta del archivo a guardar */
                        path = AppDomain.CurrentDomain.BaseDirectory + rutaInicial + "/" + Año + "/" + NombreMes + "/dia_" + diaNumero + "/" + DiaHoraMinutoSegundo;
                        /* ruta del directorio del tickets, se ocupa para validar el peso total de los archivos */
                        string pathPrincipal = AppDomain.CurrentDomain.BaseDirectory + rutaInicial + "/" + Año + "/" + NombreMes;

                        /* verifico si existe la ruta para crearla en caso sea nueva*/
                        if (!Directory.Exists(path))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(path);
                        }
                        /* obtengo los directorios para calcular el peso de todos los archivos del ticket*/
                        DirectoryInfo Directorio = new DirectoryInfo(pathPrincipal);
                        FileInfo[] fiArr = Directorio.GetFiles();
                        long pesoDir = 0;
                        //foreach (FileInfo fi in fiArr)
                        //{
                        //    pesoDir += fi.Length;
                        //}
                        /* recupero el peso del archivo subido para sumarlo al de todos los archivos y validar el peso total */
                        string PesoArchivo = Path.GetFileName(Request.Files[upload].ContentLength.ToString());
                        //if ((pesoDir + Convert.ToInt64(PesoArchivo)) < 20000000)
                        //{
                        string NombreArchivo = Path.GetFileName(Request.Files[upload].FileName);
                        string Extencion = Path.GetExtension(Request.Files[upload].FileName);
                        pth = Path.Combine(path, NombreArchivo);
                        Request.Files[upload].SaveAs(pth);

                        BE_PathFile bE_PathFile = new BE_PathFile();
                        string[] stringSeparators = new string[] { "," };
                        string usuariocadena = @User.Identity.Name.ToUpper();
                        string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                        bE_PathFile.RegistrationUser = Convert.ToInt32(usuario[0]);
                        bE_PathFile.PathFile = ".." + rutaInicial + "/" + Año + "/" + NombreMes + "/dia_" + diaNumero + "/" + DiaHoraMinutoSegundo + "/" + NombreArchivo;
                        bE_PathFile.FileNameRegister = NombreArchivo;
                        bE_PathFile.FileSize = PesoArchivo;
                        bE_PathFile.FileExtension = Extencion;
                        bE_PathFile.FileType = FileType.Trim().ToUpper();
                        bE_PathFile.IdRegister = IdRegister;
                        bE_PathFile.FileTableAbbreviation = TableAbrev.Trim().ToUpper();
                        bE_PathFile.OperationName = OperacionName;

                        Resultado = new BL_PathFile().CrearRutaActivity(bE_PathFile);
                        //}
                        //else
                        //{
                        //    Resultado = "101";
                        //}

                    }
                    else
                    {
                        BE_PathFile bE_Path = new BE_PathFile();
                        bE_Path.ValorConsulta = "102";
                        Resultado.Add(bE_Path);

                        //Resultado = "102";
                    }
                }
            }
            catch (Exception ex)
            {
                BE_PathFile bE_Path = new BE_PathFile();
                bE_Path.MensajeConsulta = ex.Message;
                Resultado.Add(bE_Path);

                //Resultado = ex.Message;
            }

            var json = Json(Resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult ListarArchivos(string idsPathFiles, string TableAbrev, string IdRegister, string FileType)
        {
            var lista = new BL_PathFile().ListarRutaArchivo(idsPathFiles, TableAbrev, IdRegister, FileType);
            var a = Json(lista, JsonRequestBehavior.AllowGet);
            a.MaxJsonLength = int.MaxValue;
            return a;
        }

        public JsonResult EliminarRutaArchivo(int IdPath)
        {
            BE_PathFile bE_PathFile = new BE_PathFile();

            bE_PathFile.IdPathFile = IdPath;

            string[] stringSeparators = new string[] { "," };
            string usuariocadena = @User.Identity.Name.ToUpper();
            string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            bE_PathFile.UpdateUser = Convert.ToInt32(usuario[0]);

            var resultado = new BL_PathFile().EliminarRuta(bE_PathFile);
            var json = Json(resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public ActionResult SubirArchivoTicket(string FileType, int IdRegister, string TableAbrev, string NombreCarpeta,string OperacionName)
        {
            /*
                 100-Peso del archivo muye grande
                 101-Se supero el peso maximo por ticket
                 102-No es el archivo correcto
                 103-Se guardo el archivo pero no se guardo la ruta en el servidor             
                 */

            HttpFileCollectionBase files = Request.Files;
            string path = "";
            string isValid = string.Empty;
            string pth = "";
            List<BE_PathFile> Resultado = new List<BE_PathFile>();

            string rutaInicial = "";

            rutaInicial = "/ARCHIVOS/" + NombreCarpeta + "/";

            try
            {
                foreach (string upload in Request.Files)
                {
                    var i = Request.Files[upload].ContentType;
                    //string xd = Request.Files[upload].ContentType;
                    if (Request.Files[upload].ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                        || Request.Files[upload].ContentType == "image/jpeg"
                        || Request.Files[upload].ContentType == "image/png"
                        || Request.Files[upload].ContentType == "application/pdf"
                        || Request.Files[upload].ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                        || Request.Files[upload].ContentType == "application/octet-stream"
                        //|| Request.Files[upload].ContentType == "application/zip"
                        || Request.Files[upload].ContentType == "application/vnd.ms-excel"
                        || Request.Files[upload].ContentType == "text/plain")
                    {
                        /* parametros de la fecha actual, se ocupan para crear los directorios*/
                        DateTime fechaActual = DateTime.Now;
                        string Año = fechaActual.Year.ToString();
                        int MesNumero = fechaActual.Month;
                        string diaNumero = fechaActual.Day.ToString();
                        string NombreMes = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MesNumero);
                        string DiaHoraMinutoSegundo = fechaActual.Hour.ToString() + "" + fechaActual.Minute.ToString() + "" + fechaActual.Second.ToString();

                        /* ruta del archivo a guardar */
                        path = AppDomain.CurrentDomain.BaseDirectory + rutaInicial + "/" + Año + "/" + NombreMes + "/dia_" + diaNumero + "/" + DiaHoraMinutoSegundo;
                        /* ruta del directorio del tickets, se ocupa para validar el peso total de los archivos */
                        string pathPrincipal = AppDomain.CurrentDomain.BaseDirectory + rutaInicial + "/" + Año + "/" + NombreMes;

                        /* verifico si existe la ruta para crearla en caso sea nueva*/
                        if (!Directory.Exists(path))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(path);
                        }
                        /* obtengo los directorios para calcular el peso de todos los archivos del ticket*/
                        DirectoryInfo Directorio = new DirectoryInfo(pathPrincipal);
                        FileInfo[] fiArr = Directorio.GetFiles();
                        long pesoDir = 0;
                        //foreach (FileInfo fi in fiArr)
                        //{
                        //    pesoDir += fi.Length;
                        //}
                        /* recupero el peso del archivo subido para sumarlo al de todos los archivos y validar el peso total */
                        string PesoArchivo = Path.GetFileName(Request.Files[upload].ContentLength.ToString());
                        //if ((pesoDir + Convert.ToInt64(PesoArchivo)) < 20000000)
                        //{
                        string NombreArchivo = Path.GetFileName(Request.Files[upload].FileName);
                        string Extencion = Path.GetExtension(Request.Files[upload].FileName);
                        pth = Path.Combine(path, NombreArchivo);
                        Request.Files[upload].SaveAs(pth);

                        BE_PathFile bE_PathFile = new BE_PathFile();
                        string[] stringSeparators = new string[] { "," };
                        string usuariocadena = @User.Identity.Name.ToUpper();
                        string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                        bE_PathFile.RegistrationUser = Convert.ToInt32(usuario[0]);
                        bE_PathFile.PathFile = ".." + rutaInicial + "/" + Año + "/" + NombreMes + "/dia_" + diaNumero + "/" + DiaHoraMinutoSegundo + "/" + NombreArchivo;
                        bE_PathFile.FileNameRegister = NombreArchivo;
                        bE_PathFile.FileSize = PesoArchivo;
                        bE_PathFile.FileExtension = Extencion;
                        bE_PathFile.FileType = FileType.Trim().ToUpper();
                        bE_PathFile.IdRegister = IdRegister;
                        bE_PathFile.FileTableAbbreviation = TableAbrev.Trim().ToUpper();
                        bE_PathFile.OperationName = OperacionName.Trim().ToUpper();

                        Resultado = new BL_PathFile().CrearRutaTicket(bE_PathFile);
                        //}
                        //else
                        //{
                        //    Resultado = "101";
                        //}

                    }
                    else
                    {
                        BE_PathFile bE_Path = new BE_PathFile();
                        bE_Path.ValorConsulta = "102";
                        Resultado.Add(bE_Path);

                        //Resultado = "102";
                    }
                }
            }
            catch (Exception ex)
            {
                BE_PathFile bE_Path = new BE_PathFile();
                bE_Path.MensajeConsulta = ex.Message;
                Resultado.Add(bE_Path);

                //Resultado = ex.Message;
            }

            var json = Json(Resultado, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
    }
}