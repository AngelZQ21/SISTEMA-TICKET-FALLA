using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Person:BE_Audit
    {
        public int IdPerson { set; get; }
        public int IdRole { set; get; }
        public int DocumentId { set; get; }
        public string DocumentNumber { set; get; }
        public string PersonName { set; get; }
        public string FirstLastName { set; get; }
        public string SecondLastName { set; get; }
        public string PersonMainAddress { set; get; }
        public string PersonPhone { set; get; }
        public string Birthdate { set; get; }
        public string PersonMail { set; get; }
        public string Photocheck { set; get; }
        public string UserStatus { set; get; }
        public string OperatorStatus { set; get; }
        public string DriverStatus { set; get; }
        public BE_Role Role { set; get; }

        /*Otros Campos*/
        public string FullName { get; set; }

        public string FullNameOperation { get; set; }

    }
}
