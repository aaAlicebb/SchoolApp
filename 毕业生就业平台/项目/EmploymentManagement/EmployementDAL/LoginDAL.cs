using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLHelper;
using EmployementMODEL;
using System.Data;
using System.Data.SqlClient;

namespace EmployementDAL
{
    public class LoginDAL
    {
        SqlHelper sql = new SqlHelper();
        /// <summary>
        /// 学生登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public StuLoginMes StuLogn(string UserName)
        {
            string str = "select * from StuLoginMes where stuID=@stuid";
            string[] pra = { "@stuid" };
            string[] val = { UserName };
            SqlDataReader reader = sql.ExecuteReader(str, pra, val);
            if (reader.Read())
            {
                StuLoginMes mes = new StuLoginMes();
                mes.StuId = reader["stuID"].ToString();
                mes.StuPwd = reader["stuPwd"].ToString();
                return mes;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 教师登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public TeaLoginMes TeaLogn(string UserName)
        {
            string str = "select * from TeaLoginMes where TeaID=@teaid";
            string[] pra = { "@teaid" };
            string[] val = { UserName };
            SqlDataReader reader = sql.ExecuteReader(str, pra, val);
            if (reader.Read())
            {
                TeaLoginMes mes = new TeaLoginMes();
                mes.TeaId = reader["TeaID"].ToString();
                mes.TeaPwd = reader["TeaPwd"].ToString();
                return mes;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 企业登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public ComLoginMes ComLogn(string UserName)
        {
            string str = "select * from ComLoginMes where ComId=@teaid";
            string[] pra = { "@teaid" };
            string[] val = { UserName };
            SqlDataReader reader = sql.ExecuteReader(str, pra, val);
            if (reader.Read())
            {
                ComLoginMes mes = new ComLoginMes();
                mes.ComId = reader["ComId"].ToString();
                mes.ComPwd = reader["ComPwd"].ToString();
                return mes;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 超级管理员账户
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public SaLoginMes SaLogn(string UserName)
        {
            string str = "select * from AdminInfo where adminName=@admin";
            string[] pra = { "@admin" };
            string[] val = { UserName };
            SqlDataReader reader = sql.ExecuteReader(str, pra, val);
            if (reader.Read())
            {
                SaLoginMes mes = new SaLoginMes();
                mes.SaId = reader["adminName"].ToString();
                mes.SaPwd = reader["adminPwd"].ToString();
                return mes;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 学生用户密码修改
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int StuPwdAlter(StuLoginMes stu)
        {
            string cmd = "update StuLoginMes set stuPwd=@pwd where stuID=@id";
            string[] pra = { "@pwd","@id"};
            string[] val = { stu.StuPwd,stu.StuId};
            int c = sql.ExecuteNoneQuery(cmd,pra,val);
            return c;
        }
        /// <summary>
        /// 教师用户密码修改
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int TeaPwdAlter(TeaLoginMes tea)
        {
            string cmd = "update TeaLoginMes set TeaPwd=@pwd where TeaID=@id";
            string[] pra = { "@pwd", "@id" };
            string[] val = { tea.TeaPwd, tea.TeaPwd};
            int c = sql.ExecuteNoneQuery(cmd, pra, val);
            return c;
        }
        /// <summary>
        /// 企业用户密码修改
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int ComPwdAlter(ComLoginMes com)
        {
            string cmd = "update ComLoginMes set ComPwd=@pwd where ComId=@id";
            string[] pra = { "@pwd", "@id" };
            string[] val = { com.ComId,com.ComPwd };
            int c = sql.ExecuteNoneQuery(cmd, pra, val);
            return c;
        }
    }
}
