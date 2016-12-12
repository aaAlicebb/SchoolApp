using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployementMODEL;

namespace EmployementUI
{
    public class Global
    {
        /// <summary>
        /// 判断标志，0学生，1教师，2企业,3超级管理员
        /// </summary>
        public static int index { get; set; }
        /// <summary>
        /// 企业
        /// </summary>
        public static ComLoginMes ComMes { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>
        public static SaLoginMes SsMes { get; set; }
        /// <summary>
        /// 学生
        /// </summary>
        public static StuLoginMes StuMes { get; set; }
        /// <summary>
        /// 教师
        /// </summary>
        public static TeaLoginMes TeaMes { get; set; }
    }
}