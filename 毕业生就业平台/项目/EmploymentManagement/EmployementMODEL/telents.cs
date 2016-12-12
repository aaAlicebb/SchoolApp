using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployementMODEL
{
   public class telents
    {
       public int RdID { get; set;}
       public string JobIntention { get; set; }
       public string School { get; set; }
       public string StuMajor { get; set; }
       public string StuName { get; set; }
       public string GraduateYear { get; set; }
       public int LookTimes { get; set; }
       public DateTime  ReSetTime { get; set; }
       public string StuId { get; set; }
       public telents() { }
       public telents(string id, int RdID, string JobIntention, string School, string StuMajor, string StuName, int LookTimes, string GraduateYear, DateTime ReSetTime) 
        {
            this.StuId = id;
            this.RdID = RdID;
            this.JobIntention = JobIntention;
            this.School = School;
            this.StuMajor= StuMajor;
            this.StuName =StuName;
            this.GraduateYear = GraduateYear;
            this.LookTimes = LookTimes;
            this.ReSetTime = ReSetTime;
        }
    }
}
