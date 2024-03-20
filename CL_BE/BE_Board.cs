using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Board : BE_Audit
    {
        public int IdBoard { get; set; }
        public int IdActivity { get; set; }
        public string NroTicket { get; set; }
        public string DescripcionActivity { get; set; }
        public string DescriptionBoard { get; set; }
        public string NameUser { get; set; }
    }
}
