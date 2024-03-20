using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Position
    {
        public List<BE_Position> ListarCargos()
        {

            var listaResultado = new List<BE_Position>();
            try
            {
                listaResultado = new DA_Position().ListarCargos();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Position bE_Position = new BE_Position();
                bE_Position.ValorConsulta = "0";
                bE_Position.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Position);
            }
            return listaResultado;
        }

        public string CrearCargo(BE_Position bE_Position)
        {
            string resultado = "";

            try
            {
                resultado = new DA_Position().CrearCargo(bE_Position);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
    }
}
