using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployementDAL;
using EmployementMODEL;

namespace EmploymentBLL
{
    public class LoginBLL
    {
        /// <summary>
        /// 学生登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public StuLoginMes StuLogn(string UserName)
        {
            LoginDAL dal = new LoginDAL();
            return dal.StuLogn(UserName);
        }
        /// <summary>
        /// 教师登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public TeaLoginMes TeaLogn(string UserName)
        {
            LoginDAL dal = new LoginDAL();
            return dal.TeaLogn(UserName);
        }
        /// <summary>
        /// 企业登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public ComLoginMes ComLogn(string UserName)
        {
            LoginDAL dal = new LoginDAL();
            return dal.ComLogn(UserName);
        }
        /// <summary>
        /// 超级管理员账户
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public SaLoginMes SaLogn(string UserName)
        {
            LoginDAL dal = new LoginDAL();
            return dal.SaLogn(UserName);
        }
        /// <summary>
        /// 学生用户密码修改
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int StuPwdAlter(StuLoginMes stu)
        {
            LoginDAL dal = new LoginDAL();
            return dal.StuPwdAlter(stu);
        }
        /// <summary>
        /// 教师用户密码修改
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int TeaPwdAlter(TeaLoginMes tea)
        {
            LoginDAL dal = new LoginDAL();
            return dal.TeaPwdAlter(tea);
        }
        /// <summary>
        /// 企业用户密码修改
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int ComPwdAlter(ComLoginMes com)
        {
            LoginDAL dal = new LoginDAL();
            return dal.ComPwdAlter(com);
        }
    }
}
