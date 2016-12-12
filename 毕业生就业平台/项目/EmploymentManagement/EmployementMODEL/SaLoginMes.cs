using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployementMODEL
{
  public class SaLoginMes
    {
      /// <summary>
      /// 账号
      /// </summary>
      public string SaId { get; set; }
      /// <summary>
      /// 密码
      /// </summary>
      public string SaPwd { get; set; }
      public SaLoginMes() { }
      public SaLoginMes(string id, string pwd) 
      {
          SaId = id;
          SaPwd = pwd;
      }
    }
}
