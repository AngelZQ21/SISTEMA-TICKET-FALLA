using CL_BE;
using CL_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BL
{
    public class BL_Reason
    {

        public List<BE_Reason> ListarReason()
        {
            var listaResultado = new List<BE_Reason>();
            try
            {
                listaResultado = new DA_Reason().ListarReason();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Reason bE_Reason = new BE_Reason();
                bE_Reason.ValorConsulta = "0";
                bE_Reason.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Reason);
            }
            return listaResultado;
        }

        public List<BE_Location> ListarLocation()
        {
            var listaResultado = new List<BE_Location>();
            try
            {
                listaResultado = new DA_Reason().ListarLocation();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Location bE_Location = new BE_Location();
                bE_Location.ValorConsulta = "0";
                bE_Location.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Location);
            }
            return listaResultado;
        }


        public string CrearReason(BE_Reason bE_Reason)
        {
            string resultado = "";

            try
            {
                resultado = new DA_Reason().CrearReason(bE_Reason);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }


        public string CrearLocacion(BE_Location bE_Location)
        {
            string resultado = "";

            try
            {
                resultado = new DA_Reason().CrearLocacion(bE_Location);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

    }
}
