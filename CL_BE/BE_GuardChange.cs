using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_GuardChange:BE_Audit
    {
        public int IdGuardChange { get; set; }
        public BE_Operation bE_Operation { get; set; }
        public BE_Meeting_Record bE_Meeting_Record { get; set; }
        public DateTime GuardChangeDate { get; set; }
        public string GuardChangeDateString { get; set; }
        public List<ModelTrabajador> ListaTrabajadores { get; set; }
        public string ListaTrabajadoresXML { get; set; }
        public List<BE_Meeting_Record_Activity> ListaActividades { get; set; }
        public string ListaActividadesXML { get; set; }

        //ADICIONALES
        public string GuardChangeHour { get; set; }
        public string IdsPrincipals { get; set; }
        public string IdsGuests { get; set; }
        public string IdsPathFileUpdate { get; set; }
    }

    public class ModelTrabajador {
        public string GuardChangeEmployeeType { get; set; }
        public int IdEmployee { get; set; }
        public string FullName { get; set; }
    }
}
