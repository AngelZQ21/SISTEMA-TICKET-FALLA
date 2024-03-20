using CL_BE;
using CL_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BL
{
    public class BL_Criticality
    {
        public List<BE_Criticality> ListarCriticality()
        {
            var listaResultado = new List<BE_Criticality>();
            try
            {
                listaResultado = new DA_Criticality().ListarCriticality();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Criticality bE_Criticality = new BE_Criticality();
                bE_Criticality.ValorConsulta = "0";
                bE_Criticality.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Criticality);
            }
            return listaResultado;
        }
    }
}
