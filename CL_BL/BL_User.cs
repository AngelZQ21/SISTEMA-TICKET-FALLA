using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_User
    {
        public List<BE_User> ValidarUsuario(BE_User bE_User)
        {
            var listaResultado = new List<BE_User>();
            try
            {
                listaResultado = new DA_User().ValidarUsuario(bE_User);

                if (listaResultado.Count >= 1 && listaResultado[0].ValorConsulta == "1" && listaResultado[0].RegistrationStatus=="A")
                {
                    string Respuesta = new DA_User().ActualizarIntentosEstadoUsuario(bE_User.UUser,"1");
                }
                else
                {
                    string Respuesta = new DA_User().ActualizarIntentosEstadoUsuario(bE_User.UUser, "0");
                }

            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_User bE_Company = new BE_User();
                bE_Company.ValorConsulta = "0";
                bE_Company.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Company);
            }
            return listaResultado;
        }

        public List<BE_User> ListarUser(string valorBusqueda, string valorConsulta)
        {
            var listaResultado = new List<BE_User>();
            try
            {
                listaResultado = new DA_User().ListarUser(valorBusqueda, valorConsulta);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_User bE_User = new BE_User();
                bE_User.ValorConsulta = "0";
                bE_User.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_User);
            }
            return listaResultado;
        }

        public string CrearUser(BE_User bE_User)
        {

            string resultado = "";

            try
            {
                resultado = new DA_User().CrearUser(bE_User);

                //string[] cadena;

                //if (resultado.Contains("1#"))
                //{
                //    cadena = resultado.Split('#');

                //    string[] contratistas = bE_User.UContratistasSelecionados.Split(',');
                //    if (contratistas[0] != "")
                //    {

                //        for (int i = 0; i < contratistas.Length; i++)
                //        {
                //            BE_Company_User bE_CompanyUser = new BE_Company_User();
                //            bE_CompanyUser.RegistrationUser = bE_User.RegistrationUser;

                //            BE_User bE_User_1 = new BE_User() { IdUser = Convert.ToInt32(cadena[1].ToString()) };
                //            bE_CompanyUser.User = bE_User_1;

                //            BE_Company bE_Company_1 = new BE_Company() { IdCompany = Convert.ToInt32(contratistas[i].ToString()) };
                //            bE_CompanyUser.Company = bE_Company_1;

                //            resultado = new BL_Company_User().CrearCompanyUser(bE_CompanyUser);
                //        }
                //    }
                //    else {
                //        resultado = "1";
                //    }

                      
                //}
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string EditarUser(BE_User bE_User)
        {

            string resultado = "";

            try
            {
                resultado = new DA_User().EditarUser(bE_User);

                //if (resultado == "1")
                //{
                //    if (bE_User.UpdateProcess != 0)
                //    {
                //        string[] contratistas = bE_User.UContratistasSelecionados.Split(',');
                //        if (contratistas[0] != "")
                //        {
                //            for (int i = 0; i < contratistas.Length; i++)
                //            {
                //                BE_Company_User bE_CompanyUser = new BE_Company_User();
                //                bE_CompanyUser.RegistrationUser = bE_User.UpdateUser;

                //                BE_User bE_User_1 = new BE_User() { IdUser = bE_User.IdUser };
                //                bE_CompanyUser.User = bE_User_1;

                //                BE_Company bE_Company_1 = new BE_Company() { IdCompany = Convert.ToInt32(contratistas[i].ToString()) };
                //                bE_CompanyUser.Company = bE_Company_1;

                //                resultado = new DA_Company_User().CrearCompanyUser(bE_CompanyUser);
                //            }
                //        }
                //    }
                //}

                //if (resultado == "1" && bE_User.UserType == "T")
                //{
                //    string[] contratistas = bE_User.UContratistasSelecionados.Split(',');

                //    DA_Company_User dA_CompanyUser = new DA_Company_User();
                //    BE_Company_User bE_CompanyUser = new BE_Company_User();

                //    for (int i = 0; i < contratistas.Length; i++)
                //    {
                //        bE_CompanyUser.RegistrationUser = bE_User.RegistrationUser;

                //        BE_User bE_User_1 = new BE_User() { IdUser = bE_User.IdUser };
                //        bE_CompanyUser.User = bE_User_1;

                //        BE_Company bE_Company_1 = new BE_Company() { IdCompany = Convert.ToInt32(contratistas[i].ToString()) };
                //        bE_CompanyUser.Company = bE_Company_1;

                //        resultado = dA_CompanyUser.CrearCompanyUser(bE_CompanyUser);
                //    }
                //}       
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string CambiarClave(BE_User bE_User)
        {

            string resultado = "";

            try
            {
                resultado = new DA_User().EditarUser(bE_User);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string EliminarUser(BE_User bE_User)
        {

            var resultado = "";

            try
            {
                resultado = new DA_User().EliminarUser(bE_User);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public List<BE_User> ValidarRelacionUsuarioPersona(int idUser)
        {
            var listaResultado = new List<BE_User>();
            try
            {
                listaResultado = new DA_User().ValidarRelacionUsuarioPersona(idUser);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_User bE_User = new BE_User();
                bE_User.ValorConsulta = "0";
                bE_User.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_User);
            }
            return listaResultado;
        }

        public string CambiarClaveOReseteo(BE_User bE_User)
        {

            string resultado = "";

            try
            {
                resultado = new DA_User().EditarUser(bE_User);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

    }
}
