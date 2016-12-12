using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployementMODEL
{
     public class ComLoginMes
    {
       public string ComId { get; set; }
       /// <summary>
       /// 密码
       /// </summary>
      public string ComPwd { get; set; }
      public ComLoginMes() { }
      public ComLoginMes(string id, string pwd) 
      {
          ComId = id;
          ComPwd = pwd;
      }
    }
}
