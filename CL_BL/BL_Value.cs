using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Value
    {
        public List<BE_Value> ListarValues(string valorBusqueda, string nombreTabla, string nombreColumna)
        {
            var listaResultado = new List<BE_Value>();
            try
            {
                listaResultado = new DA_Value().ListarValues(valorBusqueda, nombreTabla, nombreColumna);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Value bE_Value = new BE_Value();
                bE_Value.ValorConsulta = "0";
                bE_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Value);
            }
            return listaResultado;
        }

        public List<BE_Value> ListadoAlarmaConCodigo()
        {
            var listaResultado = new List<BE_Value>();
            try
            {
                listaResultado = new DA_Value().ListadoAlarmaConCodigo();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Value bE_Value = new BE_Value();
                bE_Value.ValorConsulta = "0";
                bE_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Value);
            }
            return listaResultado;
        }

        public List<BE_Value> ListarAnos()
        {
            var listaResultado = new List<BE_Value>();
            try
            {
                listaResultado = new DA_Value().ListarAnos();
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Value bE_Value = new BE_Value();
                bE_Value.ValorConsulta = "0";
                bE_Value.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Value);
            }
            return listaResultado;
        }

    }
}
