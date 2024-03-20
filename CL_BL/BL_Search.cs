using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CL_BE;
using CL_DA;
namespace CL_BL
{
    public class BL_Search
    {
        public List<BE_Search> ListaResultadoBusquedaInteligente(string valorBusqueda)
        {
            var listaResultado = new List<BE_Search>();
            try
            {
                listaResultado = new DA_Search().ListaResultadoBusquedaInteligente(valorBusqueda);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Search bE_Search = new BE_Search();
                bE_Search.ValorConsulta = "0";
                bE_Search.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Search);
            }
            return listaResultado;
        }
    }
}
