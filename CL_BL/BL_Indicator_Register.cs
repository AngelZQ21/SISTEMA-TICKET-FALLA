using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;
namespace CL_BL
{
    public class BL_Indicator_Register
    {
        public List<BE_Indicator_Register> ListarRegistroIndicador (string starDate, string endDate)
        {
            var listaResultado = new List<BE_Indicator_Register>();
            try
            {
                listaResultado = new DA_Indicator_Register().ListarRegistroIndicador(starDate, endDate);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Indicator_Register bE_indicator_Register = new BE_Indicator_Register();
                bE_indicator_Register.ValorConsulta = "0";
                bE_indicator_Register.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_indicator_Register);
            }
            return listaResultado;
        }
    }
}
