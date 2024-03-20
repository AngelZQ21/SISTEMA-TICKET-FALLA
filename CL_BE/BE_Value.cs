using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Value : BE_Audit
    {
        public int IdValue { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string Attribute { get; set; }
        public string Meaning { get; set; }
        public string Comment { get; set; }

        public int IdYear { set; get; } //Referente al sp LSP_YEAR_LIST para mostrar en un combo los años 
        public int YearNumber { set; get; }//Referente al sp LSP_YEAR_LIST para mostrar en un combo los años 
    }
}
