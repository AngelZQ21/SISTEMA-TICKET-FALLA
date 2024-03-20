﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Configuration;

namespace SmartAdminMvc.Libs
{
    public class ConfigMail
    {
        /***************************************************************************************/
        // Variables publicas
        public string MailDestino { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        /***************************************************************************************/
        public ConfigMail() { }
        /***************************************************************************************/
        //public static bool IsValidEmail(string email)
        //{
        //    return Utils.IsValidEmail(email);
        //}
        /***************************************************************************************/
        public bool EnviarCorreo()
        {
            int FL = 0;
            try
            {
                FL = 100;
                string SMTPHost = "us2.smtp.mailhostbox.com";
                int SMTPPort = 25;
                MailAddress SMTPUserName = new MailAddress("angel.quezada@assac.com.pe", "SISTEMA DE TICKET");
                string SMTPPassword = "Angel1186657";
                FL = 300;
                SmtpClient client = new SmtpClient(SMTPHost)
                {
                    //Port = SMTPPort,
                    //Credentials = new NetworkCredential(SMTPUserName.Address, SMTPPassword),
                    //EnableSsl = false,
                    //DeliveryMethod = SmtpDeliveryMethod.Network,
                    //UseDefaultCredentials = false
                    Port = SMTPPort,
                    Credentials = new NetworkCredential(SMTPUserName.Address, SMTPPassword),
                    EnableSsl = true
                };
                FL = 400;

                MailMessage objMsg = new MailMessage();
                objMsg.From = SMTPUserName;
                foreach (var address in MailDestino.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    objMsg.To.Add(address);
                }
                objMsg.Subject = Asunto;
                objMsg.Body = Cuerpo;
                objMsg.IsBodyHtml = true;

                FL = 500;
                client.Send(objMsg);
                return true;
            }
            catch (Exception ex)
            {

                //Utils.RegistrarError("Error en MailLib=>EnviarCorreo()::" + ex.Message + "::" + ex.GetType().Name + "::" + FL.ToString());
                return false;
            }
        }
        /***************************************************************************************/
        public string ObtenerPlantilla(string busqueda)
        {
            string plantilla = "";
            try
            {
                DirectoryInfo d = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/PlantillaCorreo"));
                FileInfo[] Plantillas = d.GetFiles("*.html");
                string NombrePlantilla = "";
                foreach (FileInfo p in Plantillas)
                {
                    string nombreCompleto = Path.GetFileNameWithoutExtension(p.Name);
                    /*
                    string[] div = nombreCompleto.Split('_');

                    if (div.Length != 2) continue;

                    if (busqueda.Equals(nombreCompleto, StringComparison.OrdinalIgnoreCase)
                        || busqueda.Equals(div[0], StringComparison.OrdinalIgnoreCase)
                        || busqueda.Equals(div[1], StringComparison.OrdinalIgnoreCase))
                    {
                        NombrePlantilla = p.Name;
                        break;
                    }*/
                    if (busqueda.Equals(nombreCompleto, StringComparison.OrdinalIgnoreCase))
                    {
                        NombrePlantilla = p.Name;
                        break;
                    }
                }

                if (NombrePlantilla.Trim().Length > 0)
                {
                    string rutaPlantilla = Path.Combine(HttpContext.Current.Server.MapPath("~/PlantillaCorreo"), NombrePlantilla);

                    System.IO.StreamReader file = new System.IO.StreamReader(rutaPlantilla);

                    string line = "";

                    while ((line = file.ReadLine()) != null)
                    {
                        plantilla = plantilla + " " + line;
                    }
                    file.Close();

                    string url_dominio = ConfigurationManager.AppSettings["UrlDominio"].ToString();
                    plantilla = plantilla.Replace("[URL_DOMINIO]", url_dominio);
                }
            }
            catch (Exception ex)
            {
                //Utils.RegistrarError("Error en MailLib=>ObtenerPlantilla()::" + ex.Message + "::" + ex.GetType().Name);
            }
            return plantilla;
        }
        /***************************************************************************************/
    }
}