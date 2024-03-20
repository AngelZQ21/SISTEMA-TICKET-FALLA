using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Profile_Indicator
    {
        public List<BE_Profile_Indicator> ListarIndicadorPerfil(string valorBusqueda, string valorConsulta,int idPerfil)
        {
            var listaResultado = new List<BE_Profile_Indicator>();
            try
            {
                listaResultado = new DA_Profile_Indicator().ListarIndicadorPerfil(valorBusqueda, valorConsulta,idPerfil);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Profile_Indicator bE_profile_indicator = new BE_Profile_Indicator();
                bE_profile_indicator.ValorConsulta = "0";
                bE_profile_indicator.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_profile_indicator);
            }
            return listaResultado;
        }

        public string guardarConfiguracionIndicadorPerfil(string arrayIdProfileIndicator, int idPerfil)
        {
            string resultado = "0";
            //resultado = 0 - No se actualizaron todas las vistas en la base de datos (Error durante ejecución del SP)
            //resultado = 1 - éxito
            try
            {
                    if (new DA_Profile_Indicator().actualizarEstadoIndicadorPerfilP1(idPerfil) == "1")
                    {
                        if (new DA_Profile_Indicator().actualizarEstadoIndicadorPerfilP2(arrayIdProfileIndicator, idPerfil) == "1")
                        {
                        resultado = "1";
                        }
                        else { resultado = "0"; }
                    }
                    else { resultado = "0"; }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
    }
}
