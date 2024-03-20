using CL_BE;
using CL_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BL
{
    public class BL_Components 
    {

        public List<BE_Components> ListarComponentes(string valorBusqueda)
        {

            var listaResultado = new List<BE_Components>();
            try
            {
                listaResultado = new DA_Components().ListarComponentes(valorBusqueda);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Components bE_Components = new BE_Components();
                bE_Components.ValorConsulta = "0";
                bE_Components.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Components);
            }
            return listaResultado;
        }

        public string CrearComponente(string txtComponente, int RegistrationUser)
        {
            var listaResultado = "";

            try
            {
                listaResultado = new DA_Components().CrearComponente(txtComponente, RegistrationUser);
            }
            catch (Exception ex)
            {

                listaResultado = ex.Message;
            }

            return listaResultado;
        }

        public string EditarComponente(int idComponent, string txtComponente, int RegistrationUser)
        {
            var listaResultado = "";

            try
            {
                listaResultado = new DA_Components().EditarComponente(idComponent, txtComponente, RegistrationUser);
            }
            catch (Exception ex)
            {

                listaResultado = ex.Message;
            }

            return listaResultado;
        }

    }
}
