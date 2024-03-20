using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;

namespace CL_BL
{
   public  class BL_Indicator
    {
        public List<BE_Indicator> ListarIndicador()
        {
            var listaResultado = new List<BE_Indicator>();
            try
            {
                listaResultado = new DA_Indicator().ListarIndicador();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator bE_indicator = new BE_Indicator();
                bE_indicator.ValorConsulta = "0";
                bE_indicator.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_indicator);
            }
            return listaResultado;
        }

        public List<BE_Indicator> ListarIndicadorParaNavigation()
        {
            var listaResultado = new List<BE_Indicator>();
            try
            {
                listaResultado = new DA_Indicator().ListarIndicadorParaNavigation();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator bE_indicator = new BE_Indicator();
                bE_indicator.ValorConsulta = "0";
                bE_indicator.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_indicator);
            }
            return listaResultado;
        }

        public List<BE_Indicator> ListarIndicadorDetalleParaNavigation(int IdIndicatorType)
        {
            var listaResultado = new List<BE_Indicator>();
            try
            {
                listaResultado = new DA_Indicator().ListarIndicadorDetalleParaNavigation(IdIndicatorType);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator bE_Indicator = new BE_Indicator();
                bE_Indicator.ValorConsulta = "0";
                bE_Indicator.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Indicator);
            }
            return listaResultado;
        }
        public List<BE_Indicator> listarIndicadorModalBarraSuperior(int IdIndicator, int IdIndicatorType, string startDate, string endDate, int RegistrationUser)
        {
            var listaResultado = new List<BE_Indicator>();
            try
            {
                listaResultado = new DA_Indicator().listarIndicadorModalBarraSuperior(IdIndicator, IdIndicatorType, startDate, endDate, RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator bE_indicator = new BE_Indicator();
                bE_indicator.ValorConsulta = "0";
                bE_indicator.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_indicator);
            }
            return listaResultado;
        }

        public List<BE_Indicator> listarIndicadorPorTipo(int IdIndicatorType)
        {
            var listaResultado = new List<BE_Indicator>();
            try
            {
                listaResultado = new DA_Indicator().listarIndicadorPorTipo(IdIndicatorType);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator bE_indicator = new BE_Indicator();
                bE_indicator.ValorConsulta = "0";
                bE_indicator.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_indicator);
            }
            return listaResultado;
        }

        public string guardarConfiguracionIndicador(string arrayIdProfileIndicator)
        {
            string resultado = "0";
            //resultado = 0 - No se actualizaron todas las vistas en la base de datos (Error durante ejecución del SP)
            //resultado = 1 - éxito
            try
            {
                if (new DA_Indicator().actualizarEstadoIndicadorP1() == "1")
                {
                    if (new DA_Indicator().actualizarEstadoIndicadorP2(arrayIdProfileIndicator) == "1")
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
