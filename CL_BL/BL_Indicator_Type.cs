using CL_BE;
using CL_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BL
{
    public class BL_Indicator_Type
    {
        public List<BE_Indicator_Type> ListarTipoIndicador()
        {
            var listaResultado = new List<BE_Indicator_Type>();
            try
            {
                listaResultado = new DA_Indicator_Type().ListarTipoIndicador();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator_Type bE_Indicator_Type = new BE_Indicator_Type();
                bE_Indicator_Type.ValorConsulta = "0";
                bE_Indicator_Type.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Indicator_Type);
            }
            return listaResultado;
        }
    }
}
