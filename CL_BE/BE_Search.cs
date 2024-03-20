using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Search : BE_Audit
    {
        public string Controller { set; get; }
        public string ViewController { set; get; }
        public string VisualName { set; get; }
        public string Description { set; get; }
        public string Type { set; get; }
        public string SearchValue { set; get; }
        public string RegistrationStatus { set; get; }
        public string TableName { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public int IdProduct { set; get; }
    }
}
