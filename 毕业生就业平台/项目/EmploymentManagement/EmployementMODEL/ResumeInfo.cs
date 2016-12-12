using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployementMODEL
{
   public class ResumeInfo
    {
        /// <summary>
        /// 简历Id自增长列
        /// </summary>
       public int ReId { get; set; }
        /// <summary>
        /// 照片头像
        /// </summary>
       public string ReImage { get; set; }
       /// <summary>
       /// 姓名
       /// </summary>
       public string Name { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
       public DateTime ReBirth { get; set; }
        /// <summary>
        /// 住址地址
        /// </summary>
       public string ReAddress { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
       public string ReSex { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
       public string RePhone { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
       public string ReEmail { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
       public string RePolitical { get; set; }
        /// <summary>
        /// 是否投递
        /// </summary>
       public string RequestPozision { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
       public string IsPost { get; set; }
        /// <summary>
        /// 简历创建时间
        /// </summary>
       public DateTime ReSetTime { get; set; }
        /// <summary>
        /// 求职意向
        /// </summary>
       public string JobIntension { get; set; }
       /// <summary>
       /// 专业
       /// </summary>
       public string stuMajor { get; set; }
       /// <summary>
       /// 教育经历
       /// </summary>
       public string JYJL { get; set; }
       /// <summary>
       /// 个人经历
       /// </summary>
       public string GRJL { get; set; }
       /// <summary>
       /// 自我介绍
       /// </summary>
       public string ZWJS { get; set; }
       /// <summary>
       /// 擅长技能
       /// </summary>
       public string SCJN { get; set; }
       /// <summary>
       /// 学号
       /// </summary>
       public string StuXH { get; set; }
        public ResumeInfo() { }
        public ResumeInfo(string xh,string major,string name,string image,DateTime birth,string address,string sex,string phone,string email,string political,string pozision,string ispost,DateTime settime,string intension,string jyjl,string grjl,string zwjs,string scjn) 
        {
            this.StuXH = xh;
            this.stuMajor = major;
            this.Name = name;
            this.IsPost = ispost;
            this.JobIntension = intension;
            this.ReAddress = address;
            this.ReBirth = birth;
            this.ReEmail = email;
            this.ReImage = image;
            this.RePhone = phone;
            this.RePolitical = political;
            this.RequestPozision = pozision;
            this.ReSetTime = settime;
            this.ReSex = sex;
            this.JYJL = jyjl;
            this.GRJL = grjl;
            this.ZWJS = zwjs;
            this.SCJN = scjn;
        }
    }
}
