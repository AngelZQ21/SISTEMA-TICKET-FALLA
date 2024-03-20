using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_User : BE_Audit
    {
        public int IdUser { get; set; }
        //public int IdPerson { get; set; }
        public int IdProfile { get; set; }
        public BE_Profile bE_Profile;
        public string UserType { get; set; }
        public string UUser { get; set; }
        public string UPassword { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string ViewController { get; set; }
        public int Attempts { get; set; }
        public int MaxAttempts { get; set; }

        public BE_Person Person { get; set; }        

        /*Otros Campos*/       
        public string UContratistasSelecionados { get; set; }
        public string actualPassword { get; set; }
    }
}
