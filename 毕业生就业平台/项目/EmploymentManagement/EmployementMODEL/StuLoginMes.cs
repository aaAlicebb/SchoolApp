using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployementMODEL
{
   public class StuLoginMes
    {
       /// <summary>
       /// 学号
       /// </summary>
      public string StuId { get; set; }
       /// <summary>
       /// 密码
       /// </summary>
      public string StuPwd { get; set; }
      public StuLoginMes() { }
      public StuLoginMes(string id,string pwd) 
      {
          StuId = id;
          StuPwd = pwd;
      }
    }
}
