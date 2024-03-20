using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Profile
    {
        public List<BE_Profile> ListarPerfil(string valorBusqueda, string valorConsulta)
        {
            var listaResultado = new List<BE_Profile>();
            try
            {
                listaResultado = new DA_Profile().ListarPerfil(valorBusqueda, valorConsulta);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Profile bE_profile = new BE_Profile();
                bE_profile.ValorConsulta = "0";
                bE_profile.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_profile);
            }
            return listaResultado;
        }

        public string CrearPerfil(BE_Profile bE_Profile)
        {

            string resultado = "";

            try
            {
                resultado = new DA_Profile().CrearPerfil(bE_Profile);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string EditarPerfil(BE_Profile bE_Profile)
        {

            string resultado = "";

            try
            {
                resultado = new DA_Profile().EditarPerfil(bE_Profile);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string EliminarPerfil(BE_Profile bE_Profile)
        {

            var resultado = "";

            try
            {
                resultado = new DA_Profile().EliminarPerfil(bE_Profile);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public List<BE_User> ValidarRelacionPerfil(int idPerfil)
        {
            var listaResultado = new List<BE_User>();
            try
            {
                listaResultado = new DA_Profile().ValidarRelacionPerfil(idPerfil);
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
    }
}
