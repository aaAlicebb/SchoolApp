using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployementMODEL
{
    public class ResumeManner
    {
        public string ComId { get; set; }
        public string recID { get; set; }
        public ResumeManner() { }
        public ResumeManner(string com, string rec)
        {
            this.ComId = com;
            this.recID = rec;
        }
    }
}
