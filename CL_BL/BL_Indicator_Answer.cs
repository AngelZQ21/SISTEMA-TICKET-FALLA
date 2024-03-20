using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Indicator_Answer
    {
        public string CrearRespuestaIndicador(BE_Indicator_Answer bE_Indicator_Answer)
        {

            string resultado = "";

            try
            {
                resultado = new DA_Indicator_Answer().CrearRespuestaIndicador(bE_Indicator_Answer);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string CrearRespuestaIndicadorAdjunto(BE_Indicator_Answer bE_Indicator_Answer)
        {

            string resultado = "";

            try
            {
                resultado = new DA_Indicator_Answer().CrearRespuestaIndicadorAdjunto(bE_Indicator_Answer);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string ActualizarRespuestaIndicadorAdjunto(BE_Indicator_Answer bE_Indicator_Answer)
        {
            string resultado = "";

            try
            {
                resultado = new DA_Indicator_Answer().ActualizarRespuestaIndicadorAdjunto(bE_Indicator_Answer);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
        public string EliminarRespuestaIndicador(BE_Indicator_Answer bE_Indicator_Answer)
        {
            string resultado = "";

            try
            {
                resultado = new DA_Indicator_Answer().EliminarRespuestaIndicador(bE_Indicator_Answer);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public List<BE_Indicator_Answer> ListarRespuestaIndicador(int IdIndicatorUser, int RegistrationUser)
        {
            var listaResultado = new List<BE_Indicator_Answer>();
            try
            {
                listaResultado = new DA_Indicator_Answer().ListarRespuestaIndicador(IdIndicatorUser, RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator_Answer bE_Indicator_Answer = new BE_Indicator_Answer();
                bE_Indicator_Answer.ValorConsulta = "0";
                bE_Indicator_Answer.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Indicator_Answer);
            }
            return listaResultado;
        }
    }
}
