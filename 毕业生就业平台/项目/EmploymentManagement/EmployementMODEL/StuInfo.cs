using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployementMODEL
{
   public class StuInfo
    {
       /// <summary>
       /// 学号
       /// </summary>
       public string stuID {get;set; }
       /// <summary>
       /// 姓名
       /// </summary>
       public string stuName { get; set; }
       /// <summary>
       /// 性别
       /// </summary>
       public string stuSex { get; set; }
       /// <summary>
       /// 学历
       /// </summary>
       public string stuEducation { get; set; }
       /// <summary>
       /// 年龄
       /// </summary>
       public int stuAge { get; set; }
       /// <summary>
       /// 年级
       /// </summary>
       public int stuGride { get; set; }
       /// <summary>
       /// 专业
       /// </summary>
       public string stuMajir { get; set; }
       /// <summary>
       /// 状态
       /// </summary>
       public string stuStatus { get; set; }
       /// <summary>
       /// 身份证号
       /// </summary>
       public string stuIdnumber { get; set; }
       /// <summary>
       /// 家庭住址
       /// </summary>
       public string stuAddress { get; set; }
       /// <summary>
       /// 出生日期
       /// </summary>
       public string stuBirth { get; set; }
       public StuInfo() { }
       public StuInfo(string birth,string education,string id,string name,string sex,int age,int grade,string major,string status,string idnumber,string address) 
       {
           this.stuBirth = birth;
           stuEducation = education;
           stuAddress = address;
           stuAge = age;
           stuGride = grade;
           stuID = id;
           stuIdnumber = idnumber;
           stuMajir = major;
           stuName = name;
           stuSex = sex;
           stuStatus = status;
       }
    }
}
