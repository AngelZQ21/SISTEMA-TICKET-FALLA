using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_PathFile : BE_Audit
    {
        public int IdPathFile { get; set; }
        public string FileTableAbbreviation { get; set; }
        public int IdRegister { get; set; }
        public string PathFile { get; set; }
        public string FileNameRegister { get; set; }
        public string FileSize { get; set; }
        public string FileExtension { get; set; }
        public string FileType { get; set; }

        /*Otros Campos*/
        public string OperationName { get; set; }
        //public string FullName { get; set; }
        public string PathFileUpdate { get; set; }
        //public string RegistrationDateString { get; set; }
        /*--------------------------------*/
        public string TituloInforme { get; set; }
        public int IdParaQuienInforme { get; set; }
        public string NameParaQuienInforme { get; set; }
        public string AsuntoInforme { get; set; }
        public string OperacionNombre { get; set; }
        public string FechaRegistroInforme { get; set; }
        public string AntecedentesInforme { get; set; }
        public string ConclusionesInforme { get; set; }
        public string ActivityDevelopInforme { get; set; }
        public string RecomendacionesInforme { get; set; }
        public string TipoArchivo { get; set; }

    }
}
