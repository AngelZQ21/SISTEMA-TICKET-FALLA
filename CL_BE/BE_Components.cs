using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Components : BE_Audit
    {

       public int IdComponent { get; set; }
       public string ComponentName { get; set; }
       public string RegistrationDateStrings { get; set; }
       public string UserCreation { get; set; }
    }
}
