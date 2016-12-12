using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmModel
{
    public class EmInfo
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
        /// 姓名
        /// </summary>
        public string stuName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int ComID  { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string ComName  { get; set; }
        /// <summary>
        /// 所属年级
        /// </summary>
        public DateTime Injobtime  { get; set; }
        /// <summary>
        /// 所属专业
        /// </summary>
        public decimal Wage  { get; set; }
        /// <summary>
        /// 就业状态
        /// </summary>
        public string FeedbackInfo  { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public  DateTime Feedbacktime {get;set;}
        public EmInfo() { }
        public EmInfo(int ID, string stuID, string stuName, int ComID, string ComName, DateTime Injobtime, decimal Wage, string FeedbackInfo, DateTime Feedbacktime) 
        {
            this.stuID = stuID;
            this.stuName = stuName;
            this.stuName = stuName;
            this.ComID = ComID;
            this.ComName = ComName;
            this.Injobtime = Injobtime;
            this.Wage = Wage;
            this.FeedbackInfo = FeedbackInfo;
            this.Feedbacktime = Feedbacktime;
        }
    }
}
