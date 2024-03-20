using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Configuration
    {
        public List<BE_Configuration> ListarConfiguracion(string valorBusqueda, string valorConsulta)
        {
            var listaResultado = new List<BE_Configuration>();
            try
            {
                listaResultado = new DA_Configuration().ListarConfiguracion(valorBusqueda, valorConsulta);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Configuration bE_Configuration = new BE_Configuration();
                bE_Configuration.ValorConsulta = "0";
                bE_Configuration.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Configuration);
            }
            return listaResultado;
        }

        public string EditarConfiguracion(BE_Configuration bE_Configuration)
        {

            string resultado = "";

            try
            {
                resultado = new DA_Configuration().EditarConfiguracion(bE_Configuration);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public List<BE_Configuration> ListarConfigurationAlert(int IdUser)
        {
            var listaResultado = new List<BE_Configuration>();
            try
            {
                listaResultado = new DA_Configuration().ListarConfigurationAlert(IdUser);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Configuration bE_Configuration = new BE_Configuration();
                bE_Configuration.ValorConsulta = "0";
                bE_Configuration.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Configuration);
            }
            return listaResultado;
        }
        public string EditAlertStatus(string AlertStatusValue , int IdUser)
        {

            string resultado = "";

            try
            {
                resultado = new DA_Configuration().EditAlertStatus(AlertStatusValue, IdUser);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
    }
}
