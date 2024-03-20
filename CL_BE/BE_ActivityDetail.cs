using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_ActivityDetail : BE_Audit
    {
        public int IdActivityDetail { get; set; }
        public int IdActivity { get; set; }
        public string TituloInforme { get; set; }
        public int IdParaQuienInforme { get; set; }
        public int ParaQuienInforme { get; set; }
        public string NameParaQuienInforme { get; set; }
        public string AsuntoInforme { get; set; }
        public string OperacionNombre { get; set; }
        public string FechaRegistroInforme { get; set; }
        public string AntecedentesInforme { get; set; }
        public string ConclusionesInforme { get; set; }
        public string ActivityDevelopInforme { get; set; }
        public string RecomendacionesInforme { get; set; }
        public string idsPathFileUpdate { get; set; }
        public string PathFile { get; set; }
        public string NumberTicket { get; set; }
        public string TipoArchivo { get; set; }
        public string RegistrationUserName { get; set; }
        public string FileNameRegister { get; set; }
        public string FileSize { get; set; }

    }
}
