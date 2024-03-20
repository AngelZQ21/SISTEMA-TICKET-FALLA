using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_Employee
    {
        public List<BE_Employee> ListarTrabajadores(int IdOperation)
        {

            var listaResultado = new List<BE_Employee>();
            try
            {
                listaResultado = new DA_Employee().ListarTrabajadores(IdOperation);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Employee bE_Employee = new BE_Employee();
                bE_Employee.ValorConsulta = "0";
                bE_Employee.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Employee);
            }
            return listaResultado;
        }

        public string CrearTrabajador(BE_Employee bE_Employee)
        {
            string resultado = "";

            try
            {
                resultado = new DA_Employee().CrearTrabajador(bE_Employee);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

    }
}
