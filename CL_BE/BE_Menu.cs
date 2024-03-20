using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Menu:BE_Audit
    {
        public int IdMenu { set; get; }
        public int MenuGroup { set; get; }
        public int Scale { set; get; }
        public int ScaleId { set; get; }
        public int DependencyScale { set; get; }
        public int MainId { set; get; }
        public int DependencyMainId { set; get; }
        public string VisualName { set; get; }
        public string HasDependency { set; get; }
        public string IconShowed { set; get; }
        public string Controller { set; get; }
        public string ViewController { set; get; }
        public string DependencySequence { set; get; }
        public string DependencySequenceName { set; get; }

        //Additional Variables

        public bool ActiveViews { set; get; }

    }
}
