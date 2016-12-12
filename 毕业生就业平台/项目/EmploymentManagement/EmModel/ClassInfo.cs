using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmModel
{
    public class ClassInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 班级姓名
        /// </summary>
        public string ClassName { get; set;}
        /// <summary>
        /// 老师
        /// </summary>
        public string ClassTeacher { get; set; }
       /// <summary>
       /// 年级
       /// </summary>
        public string ClassGride { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public string ClassMajor { get; set; }
        public ClassInfo() { }
        public ClassInfo(int ID,string ClassName,string ClassTeacher,string ClassGride,string ClassMajor) 
        {
            this.ID = ID;
            this.ClassName = ClassName;
            this.ClassTeacher = ClassTeacher;
            this.ClassGride = ClassGride;
            this.ClassMajor = ClassMajor;
        }

    }
}
