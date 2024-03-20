using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_BE;
using CL_DA;
namespace CL_BL
{
    public class BL_Meeting_Record_Activity
    {
        public List<BE_Meeting_Record_Activity> ListarActividadesPendientes(int IdGuardChange)
        {
            var listaResultado = new List<BE_Meeting_Record_Activity>();
            try
            {
                listaResultado = new DA_Meeting_Record_Activity().ListarActividadesPendientes(IdGuardChange);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Meeting_Record_Activity bE_Meeting_Record_Activity = new BE_Meeting_Record_Activity();
                bE_Meeting_Record_Activity.ValorConsulta = "0";
                bE_Meeting_Record_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Meeting_Record_Activity);
            }
            return listaResultado;
        }

    }
}
