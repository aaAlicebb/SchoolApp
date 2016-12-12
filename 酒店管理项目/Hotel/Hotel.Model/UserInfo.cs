using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
   public class UserInfo
    {
        public string UserName { get; set; }
        public string UserPwd { get; set; }

        public string UserType { get; set; }
        public string UserBM { get;set;}

        public UserInfo() { }
        public UserInfo(string name,string pwd,string type,string BM) 
        {
            this.UserName = name;
            this.UserPwd = pwd;
            this.UserType = type;
            this.UserBM=BM;
        }
    }
}
