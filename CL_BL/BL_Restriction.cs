using CL_BE;
using CL_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BL
{
    public class BL_Restriction
    {
        public List<BE_Restriction> ListarRestriccion(string valorBusqueda, string valorConsulta)
        {
            var listaResultado = new List<BE_Restriction>();
            try
            {
                listaResultado = new DA_Restriction().ListarRestriccion(valorBusqueda, valorConsulta);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Restriction bE_Restriction = new BE_Restriction();
                bE_Restriction.ValorConsulta = "0";
                bE_Restriction.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Restriction);
            }
            return listaResultado;
        }
        public string CrearRestriccion(BE_Restriction bE_Restriction)
        {

            string resultado = "";

            try
            {
                resultado = new DA_Restriction().CrearRestriccion(bE_Restriction);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string EditarRestriccion(BE_Restriction bE_Restriction)
        {

            string resultado = "";

            try
            {
                resultado = new DA_Restriction().EditarRestriccion(bE_Restriction);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string EliminarRestriccion(BE_Restriction bE_Restriction)
        {

            var resultado = "";

            try
            {
                resultado = new DA_Restriction().EliminarRestriccion(bE_Restriction);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public List<BE_Restriction> ValidarRelacionRestriccionMapa(int IdRestriction, string RestrictionTable, string RestrictionColumn)
        {

            var listaResultado = new List<BE_Restriction>();
            try
            {
                listaResultado = new DA_Restriction().ValidarRelacionRestriccionMapa(IdRestriction, RestrictionTable, RestrictionColumn);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Restriction bE_Restriction = new BE_Restriction();
                bE_Restriction.ValorConsulta = "0";
                bE_Restriction.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Restriction);
            }
            return listaResultado;

        }
    }
}
