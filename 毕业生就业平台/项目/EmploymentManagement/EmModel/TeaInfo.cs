using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmModel
{
    public class TeaInfo
    {
        public int ID { get; set; }
        public string TeaID { get; set; }
        public string TeaPwd{get;set;}
        public string TeaName { get; set; }
        public char TeaSex { get; set; }
        public int TeaAge { get; set; }
        public string IDnumber { get; set; }
        public TeaInfo() { }
        public TeaInfo(int ID,string TeaID,string TeaPwd,string TeaName,char TeaSex,int TeaAge,string IDnumber) 
        {
            this.ID = ID;
            this.TeaID = TeaID;
            this.TeaName = TeaName;
            this.TeaSex = TeaSex;
            this.TeaAge = TeaAge;
            this.IDnumber = IDnumber;
        }
    }
}
