using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployementMODEL;
using SQLHelper;
using System.Data.SqlClient;
namespace EmployementDAL
{
   public class ComInfoDAL
    {
       SqlHelper sql = new SqlHelper();
        /// <summary>
        /// 改变头像根据教师工号
        /// </summary>
        /// <returns></returns>
        public int updateComImg(byte[] img, string id)
        {
            string cmd = "update ComInfo set ComSign=@img where ComId=@id";
            string[] pra = { "@img", "@id" };
            object[] val = { img, id };
            int result = (int)sql.ExecuteNoneQuery(cmd, pra, val);
            return result;
        }

        /// <summary>
        /// 加入企业信息
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public int InsertComInfo(ComInfo com)
        {
            string cmd = "insert into ComInfo(ComId,ComName,ComType,ComInfo,Compeople,ComTel,ComArea) values(@ComId,@ComName,@ComType,@ComInfo,@Compeople,@ComTel,@ComArea)";
            string[] pra = { "@ComId", "@ComName", "@ComType", "@ComInfo", "@Compeople", "@ComTel", "@ComArea" };
            object[] val = { com.ComId, com.ComName, com.ComType, com.ComJieS, com.ComPeople, com.ComTel, com.ComArea };
            int c = sql.ExecuteNoneQuery(cmd, pra, val);
            return c;
        }
        /// <summary>
        /// 加入登录信息
        /// </summary>
        /// <returns></returns>
        public int InsertComLogn(ComLoginMes mes)
        {
            string cmd = "insert into ComLoginMes(ComId,ComPwd) values(@comid,@compwd)";
            string[] pra = { "@comid", "@compwd" };
            string[] val = { mes.ComId, mes.ComPwd };
            int c = sql.ExecuteNoneQuery(cmd, pra, val);
            return c;
        }
        /// <summary>
        /// 查询企业信息
        /// </summary>
        /// <returns></returns>
        public ComInfo SelectComInfoByID(string id)
        {
            string cmd = "select * from ComInfo where ComId=@id";
            string[] pra = { "@id" };
            string[] val = { id };
            SqlDataReader reader = sql.ExecuteReader(cmd, pra, val);
            if (reader.Read())
            {
                ComInfo com = new ComInfo();
                com.ComName = reader["ComName"].ToString();
                com.ComType = reader["ComType"].ToString();
                com.ComJieS = reader["ComInfo"].ToString();
                com.ComPeople = reader["Compeople"].ToString();
                com.ComTel = reader["ComTel"].ToString();
                com.ComArea = reader["ComArea"].ToString();
                return com;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 修改企业信息
        /// </summary>
        /// <returns></returns>
        public int alterComInfo(ComInfo com)
        {
            string cmd = "update ComInfo set ComName=@name,ComType=@type,ComInfo=@info,ComTel=@tel,Compeople=@people,ComArea=@area where ComId=@id";
            string[] pra = {"@name", "@type", "@info", "@tel", "@people", "@area", "@id" };
            object[] val = {com.ComName.ToString(),com.ComType.ToString(),com.ComJieS.ToString(),com.ComTel.ToString(),com.ComPeople.ToString(),com.ComArea.ToString(),com.ComId};
            //object[] val = { "霞光", "股份", "我们的公司","213345","50000","西山","110"};
            int count = sql.ExecuteNoneQuery(cmd, pra, val);
            return count;

        }
    }
}
