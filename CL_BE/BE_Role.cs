using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Role:BE_Audit
    {
        public int IdRole { set; get; }
        public string RoleName { set; get; }
        public string RoleAbbreviation { set; get; }
        public string RoleType { get; set; }
        public string RoleTypeDesc { get; set; }

    }
}
