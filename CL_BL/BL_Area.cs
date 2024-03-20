using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Area
    {
        public List<BE_Area> ListarAreas()
        {

            var listaResultado = new List<BE_Area>();
            try
            {
                listaResultado = new DA_Area().ListarAreas();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Area bE_Area = new BE_Area();
                bE_Area.ValorConsulta = "0";
                bE_Area.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Area);
            }
            return listaResultado;
        }

        public string CrearArea(BE_Area bE_Area)
        {
            string resultado = "";

            try
            {
                resultado = new DA_Area().CrearArea(bE_Area);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
    }
}
