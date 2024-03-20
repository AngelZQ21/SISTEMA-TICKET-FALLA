using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Indicator_Answer: BE_Audit
    {
        public int IdIndicatorComment { get; set; }
        public BE_Indicator_User bE_Indicator_User;
        public string Comment { set; get; }
        public string RegistrationUserName { get; set; }
        public string UpdateUserName { get; set; }

        public string PathFile { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string FileExtension { get; set; }
        public string FileType { get; set; }
        public string QueryValue { get; set; }

    }
}
