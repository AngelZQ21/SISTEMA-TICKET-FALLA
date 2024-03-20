using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Meeting_Record_Detail:BE_Audit
    {
        public int  IdMeetingRecordDetail { get; set; }
        public BE_Meeting_Record bE_Meeting_Record { get; set; }
        public BE_Employee bE_Employee { get; set; }
        public BE_PathFile bE_PathFile { get; set; }
        public int IdPointDiscussed { get; set; }
        public string  MeetingRecordDetailTopic { get; set; }
        public string  MeetingRecordDetailEvent { get; set; }
        public DateTime  MeetingRecordDetailDate { get; set; }
        public string  MeetingRecordDetailStatus { get; set; }

        //ADICIONAL
        public string IdPointDiscussedDescription { get; set; }
        public string MeetingRecordDetailDateString { get; set; }
        public string MeetingRecordDetailStatusDescription { get; set; }

        public int IdPrincipalEmployee { get; set; }
        public string PrincipalFullName { get; set; }
           
    }
}
