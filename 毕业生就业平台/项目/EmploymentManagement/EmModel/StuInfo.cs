using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmModel
{
    public class StuInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public string stuID { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string stuPwd { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string stuName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public char stuSex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int stuAge { get; set; }
        /// <summary>
        /// 所属年级
        /// </summary>
        public int stuGrade { get; set; }
        /// <summary>
        /// 所属专业
        /// </summary>
        public string stuMajor { get; set; }
        /// <summary>
        /// 就业状态
        /// </summary>
        public string stuStatus { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public  string IDnumber{get;set;}
       /// <summary>
       /// 所属班级
       /// </summary>
        public string Class { get; set; }
        public StuInfo() { }
        public StuInfo(string stuID,string stuPwd,string stuName,char stuSex,int stuAge,int stuGrade,string stuMajor,string stuStatus,string IDnumber,string Class) 
        {
            this.stuID = stuID;
            this.stuPwd = stuPwd;
            this.stuName = stuName;
            this.stuSex = stuSex;
            this.stuAge = stuAge;
            this.stuGrade=stuGrade;
            this.stuMajor = stuMajor;
            this.stuStatus = stuStatus;
            this.IDnumber = IDnumber;
            this.Class = Class;
        }
    }
}
