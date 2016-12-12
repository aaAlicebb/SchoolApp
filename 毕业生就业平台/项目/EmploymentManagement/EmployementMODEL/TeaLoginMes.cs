using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployementMODEL
{
   public class TeaLoginMes
    {
        /// <summary>
       /// 工号
       /// </summary>
      public string TeaId { get; set; }
       /// <summary>
       /// 密码
       /// </summary>
      public string TeaPwd { get; set; }
      public TeaLoginMes() { }
      public TeaLoginMes(string id, string pwd) 
      {
          TeaId = id;
          TeaPwd = pwd;
      }
    }
}
