using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployementMODEL
{
  public  class province
    {
        public int ProID { get; set; }
        public string ProName { get; set; }
        public int ParentID { get; set; }
       public   province() { } 
       public  province(int ProID, string ProName,int ParentID)
        {
            this.ProID = ProID;
            this.ProName = ProName;
            this.ParentID = ParentID;
        }

    }
}
