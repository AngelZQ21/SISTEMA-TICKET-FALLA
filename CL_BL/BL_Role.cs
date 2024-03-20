using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Role
    {
        public List<BE_Role> ListarRole(string valorBusqueda, string valorConsulta)
        {
            var listaResultado = new List<BE_Role>();
            try
            {
                listaResultado = new DA_Role().ListarRole(valorBusqueda, valorConsulta);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Role bE_Role = new BE_Role();
                bE_Role.ValorConsulta = "0";
                bE_Role.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Role);
            }
            return listaResultado;
        }

        public string CrearRol(BE_Role bE_Role)
        {

            string resultado = "";

            try
            {
                resultado = new DA_Role().CrearRol(bE_Role);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string EditarRol(BE_Role bE_Role)
        {

            string resultado = "";

            try
            {
                resultado = new DA_Role().EditarRol(bE_Role);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string EliminarRol(BE_Role bE_Role)
        {

            var resultado = "";

            try
            {
                resultado = new DA_Role().EliminarRol(bE_Role);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }



        public List<BE_Person> ValidarRelacionRol(int idRole)
        {
            var listaResultado = new List<BE_Person>();
            try
            {
                listaResultado = new DA_Role().ValidarRelacionRol(idRole);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Person bE_Person = new BE_Person();
                bE_Person.ValorConsulta = "0";
                bE_Person.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Person);
            }
            return listaResultado;
        }
    }
}
