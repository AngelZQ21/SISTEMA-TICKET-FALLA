using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Meeting_Record:BE_Audit
    {
        public int  IdMeetingRecord { get; set; }
        public BE_Operation bE_Operation{ get; set; }
        public BE_Employee bE_Employee { get; set; }
        public DateTime  MeetingRecordDate { get; set; }
        public string MeetingRecordNumber { get; set; }
        public string MeetingRecordStatus { get; set; }

        //ADICIONALES
        public string MeetingRecordDateString { get; set; }
        public string MeetingRecordHour { get; set; }
        public string MeetingRecordStatusDescription { get; set; }

        public List<BE_Meeting_Record_Detail> ListaPuntosATratar { get; set; }
        public string ListaPuntosATratarXML { get; set; }

        public string IdsMeetingRecordDetail { get; set; }

    }

}
