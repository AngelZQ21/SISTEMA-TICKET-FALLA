using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Operation
    {
        public List<BE_Operation> ListarOperaciones()
        {

            var listaResultado = new List<BE_Operation>();
            try
            {
                listaResultado = new DA_Operation().ListarOperaciones();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Operation bE_Operation = new BE_Operation();
                bE_Operation.ValorConsulta = "0";
                bE_Operation.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Operation);
            }
            return listaResultado;
        }

        public string CrearOperacion(BE_Operation bE_Operation)
        {
            string resultado = "";

            try
            {
                resultado = new DA_Operation().CrearOperacion(bE_Operation);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

    }
}
