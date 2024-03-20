using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;

namespace CL_BL
{
    public class BL_GuardChange
    {
        public List<BE_GuardChange> ListarReporteCambioDeGuardia(string StartDate, string EndDate, string IdsOperacion)
        {

            var listaResultado = new List<BE_GuardChange>();
            try
            {
                listaResultado = new DA_GuardChange().ListarReporteCambioDeGuardia(StartDate,EndDate, IdsOperacion);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_GuardChange bE_GuardChange = new BE_GuardChange();
                bE_GuardChange.ValorConsulta = "0";
                bE_GuardChange.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_GuardChange);
            }
            return listaResultado;
        }

        public List<BE_Employee> RegistrarCambioDeGuardia(BE_GuardChange bE_GuardChange)
        {
            var listaResultado = new List<BE_Employee>();
            try
            {
                listaResultado = new DA_GuardChange().RegistrarCambioDeGuardia(bE_GuardChange);
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
    }
}
