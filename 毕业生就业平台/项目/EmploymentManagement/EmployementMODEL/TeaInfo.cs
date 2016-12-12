using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployementMODEL
{
     public class TeaInfo
    {
         /// <summary>
         /// 教师工号
         /// </summary>
         public string TeaId { get; set; }
         /// <summary>
         /// 教师姓名
         /// </summary>
         public string TeaName { get; set; }
         /// <summary>
         /// 性别
         /// </summary>
         public string TeaSex { get; set; }
         /// <summary>
         /// 年龄
         /// </summary>
         public int TeaAge {get;set; }
         /// <summary>
         /// 身份证号码
         /// </summary>
         public string TeaIDNumber { get; set; }
         /// <summary>
         /// 电话号码
         /// </summary>
         public string TeaPhone { get; set; }
         /// <summary>
         /// 所属学院
         /// </summary>
         public string TeaInstitute { get; set; }
         public string TeaAddress { get; set; }
         public TeaInfo() { }
         public TeaInfo(string id,string name,string sex,int age,string idnumber,string phone,string institute,string address) 
         {
             this.TeaAddress = address;
             this.TeaPhone = phone;
             this.TeaInstitute = institute;
             TeaId = id;
             TeaName = name;
             TeaSex = sex;
             TeaAge = age;
             TeaIDNumber = idnumber;
         }
    }
}
