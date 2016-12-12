using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SQLHelper;
using EmployementMODEL;

namespace EmployementDAL
{
   public class TeaInfoDAL
    {
       SqlHelper sql = new SqlHelper();
        /// <summary>
        /// 方法用于个人界面图片传输
        /// </summary>
        /// <param name="stuId"></param>
        /// <returns></returns>
        public byte[] tpcz(string teaid)
        {
            string cmd = "select * from TeaInfo where teaID=@id";
            string[] pra = { "@id" };
            string[] value = { teaid };
            byte[] tp = null;
            SqlDataReader reader = sql.ExecuteReader(cmd, pra, value);
            if (reader.Read())
            {
                if (reader["teaImg"].ToString() != "")
                {
                    tp = (byte[])reader["teaImg"];
                    return tp;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }
       /// <summary>
       /// 通过教师工号查询教师信息
       /// </summary>
       /// <returns></returns>
        public TeaInfo selectById(string id) 
        {
            string cmd = "select * from TeaInfo where teaID=@id";
            string[] pra = { "@id" };
            string[] val = { id };
            SqlDataReader reader = sql.ExecuteReader(cmd, pra, val);
            if(reader.Read())
            {
                TeaInfo tea = new TeaInfo();
                tea.TeaAge = (int)reader["TeaAge"];
                tea.TeaId = reader["TeaID"].ToString();
                tea.TeaIDNumber = reader["IDnumber"].ToString();
                tea.TeaName = reader["TeaName"].ToString();
                tea.TeaSex = reader["TeaSex"].ToString();
                tea.TeaInstitute = reader["TeaInstitute"].ToString();
                tea.TeaPhone = reader["TeaPhone"].ToString();
                tea.TeaAddress = reader["TeaAddress"].ToString();
                return tea;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 改变头像根据教师工号
        /// </summary>
        /// <returns></returns>
        public int updateTeaImg(byte[] img, string id)
        {
            string cmd = "update TeaInfo set teaImg=@img where TeaID=@id";
            string[] pra = { "@img", "@id" };
            object[] val = { img, id };
            int result = (int)sql.ExecuteNoneQuery(cmd, pra, val);
            return result;
        }
       /// <summary>
       /// 改变教师表信息
       /// </summary>
       /// <param name="tea"></param>
       /// <returns></returns>
        public int upDateTeaInfoMes(TeaInfo tea) 
        {
            string cmd = "update TeaInfo set TeaName=@TeaName,TeaSex=@TeaSex,TeaAge=@TeaAge,TeaInstitute=@Institute,TeaPhone=@TeaPhone,TeaAddress=@Address where TeaID=@Id";
            string[] pra = {"@TeaName","@TeaSex","@TeaAge","@Institute","@TeaPhone","@Address","@Id"};
            object[] val = {tea.TeaName,tea.TeaSex,tea.TeaAge,tea.TeaInstitute,tea.TeaPhone,tea.TeaAddress,tea.TeaId };
            int conunt = sql.ExecuteNoneQuery(cmd,pra,val);
            return conunt;
        }
    }
}
