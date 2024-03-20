using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Menu_Profile:BE_Audit
    {
        public int IdMenuProfile { set; get; }
        public BE_Menu Menu;
        public BE_Profile Profile;
        public string MainView { set; get; }

    }
}
