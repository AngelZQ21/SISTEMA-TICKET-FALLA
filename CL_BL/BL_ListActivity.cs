using CL_BE;
using CL_DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BL
{
    public class BL_ListActivity
    {

        public List<BE_Activity> ListadoActividaDesUsuarios(string StartDate, string EndDate, string IdsTicket, string IdsPeople, int RegistrationUser)
        {

            var listaResultado = new List<BE_Activity>();
            try
            {
                listaResultado = new DA_ListActivity().ListadoActividaDesUsuarios(StartDate, EndDate, IdsTicket, IdsPeople, RegistrationUser);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Activity bE_Activity = new BE_Activity();
                bE_Activity.ValorConsulta = "0";
                bE_Activity.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Activity);
            }
            return listaResultado;
        }

    }
}
