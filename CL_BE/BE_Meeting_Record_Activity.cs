using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BE
{
    public class BE_Meeting_Record_Activity:BE_Audit
    {
        public int IdMeetingRecordActivity { get; set; }
        public BE_Meeting_Record_Detail bE_Meeting_Record_Detail { get; set; }
        public BE_Employee bE_Employee { get; set; }
        public BE_GuardChange bE_GuardChange { get; set; }
        public string MeetingRecordActivityActivity { get; set; }
        public string MeetingRecordActivityCommentary { get; set; }
        public DateTime MeetingRecordActivityEndDate { get; set; }
        public string MeetingRecordActivityEndDateString { get; set; }
        public string MeetingRecordActivityStatus { get; set; }
        public string MeetingRecordActivityStatusDescription { get; set; }
    }
}
