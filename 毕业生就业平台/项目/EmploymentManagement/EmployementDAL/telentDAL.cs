using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SQLHelper;
using EmployementMODEL;

namespace EmployementDAL
{
   public class telentDAL
    {
        static SqlHelper db = new SqlHelper();
        public List<telents> selectTelent()//显示简历摘要信息
        {
            List<telents> Array = new List<telents>();
            string cmdText = "select * from  ResumeInfo";
            SqlDataReader reader = db.ExecuteReader(cmdText, null, null);
            while (reader.Read())
            {
                telents info = new telents();
                info.RdID = int.Parse(reader["RdID"].ToString());
                info.JobIntention = reader["JobIntension"].ToString();
                info.School = reader["School"].ToString();
                info.StuMajor = reader["StuMajor"].ToString();
                info.StuName = reader["StuName"].ToString();
               info.StuId=reader["StuId"].ToString();
               info.LookTimes = int.Parse(reader["LookTimes"].ToString());
            
                Array.Add(info);
            }
            reader.Close();
            if (Array != null)
            {
                return Array;
            }
            else
            {

                return null;
            }
        }
        public List<telents> selectTelents(string key)//查找
        {
            List<telents> Array = new List<telents>();
            string cmdText = "select * from  ResumeInfo where StuName like @key or School like @key or StuMajor like @key union all(select * from ResumeInfo EXCEPT select * from ResumeInfo  whereStuName like @key or School like @key or StuMajor like @key) ";
            string[]param = {"@key"};
            string[] values = {key};
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            while (reader.Read())
            {
                telents info = new telents();
                info.RdID = int.Parse(reader["RdID"].ToString());
                info.JobIntention = reader["JobIntension"].ToString();
                info.School = reader["School"].ToString();
                info.StuMajor = reader["StuMajor"].ToString();
                info.StuName = reader["StuName"].ToString();
                info.StuId = reader["StuId"].ToString();
                info.LookTimes = int.Parse(reader["LookTimes"].ToString());
                Array.Add(info);
            }
            reader.Close();
            if (Array != null)
            {
                return Array;
            }
            else
            {

                return null;
            }
        }
        public List<telents> selectByYear(string GraduateYear)//根据毕业年份查找
        {
            List<telents> Array = new List<telents>();
            string cmdText = "select * from  ResumeInfo where GraduateYear=@GraduateYear union all(select * from ResumeInfo EXCEPT select * from ResumeInfo where GraduateYear=@GraduateYear)  ";
            string[] param = { "@GraduateYear " };
            string[] values = { GraduateYear };
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            while (reader.Read())
            {
                telents info = new telents();
                info.RdID = int.Parse(reader["RdID"].ToString());
                info.JobIntention = reader["JobIntension"].ToString();
                info.School = reader["School"].ToString();
                info.StuMajor = reader["StuMajor"].ToString();
                info.StuName = reader["StuName"].ToString();
                info.StuId = reader["StuId"].ToString();
                info.LookTimes = int.Parse(reader["LookTimes"].ToString());
                Array.Add(info);
            }
            reader.Close();
            if (Array != null)
            {
                return Array;
            }
            else
            {

                return null;
            }
        }
        public List<telents> selectByClass(string Class)//根据所选专业查找
        {
            List<telents> Array = new List<telents>();
            string cmdText = "select * from ResumeInfo where StuMajor=@class union all(select * from ResumeInfo EXCEPT select * from ResumeInfo where StuMajor=@class) ";
            string[] param = { "@class" };
            string[] values = { Class};
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            while (reader.Read())
            {
                telents info = new telents();
                info.RdID = int.Parse(reader["RdID"].ToString());
                info.JobIntention = reader["JobIntension"].ToString();
                info.School = reader["School"].ToString();
                info.StuMajor = reader["StuMajor"].ToString();
                info.StuName = reader["StuName"].ToString();
                info.StuId = reader["StuId"].ToString();
                info.LookTimes = int.Parse(reader["LookTimes"].ToString());
                Array.Add(info);
            }
            reader.Close();
            if (Array != null)
            {
                return Array;
            }
            else
            {

                return null;
            }
            
        }
     public List<telents> Recommand(string  ReID)//加推
        {
           telents te=new telents();
            List<telents> Array = new List<telents>();
            string cmdText = "Update ResumeInfo set LookTimes=LookTimes+1 where RdID=@ReID";
            string[] param = { "@ReID" };
            object[] values = { ReID };
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            while (reader.Read())
            {
                telents info = new telents();
                info.RdID = int.Parse(reader["RdID"].ToString());
                info.JobIntention = reader["JobIntension"].ToString();
                info.School = reader["School"].ToString();
                info.StuMajor = reader["StuMajor"].ToString();
                info.StuName = reader["StuName"].ToString();
                info.LookTimes = int.Parse(reader["LookTimes"].ToString());
                info.GraduateYear=reader["GraduateYear"].ToString();
                info.StuId = reader["StuId"].ToString();
                Array.Add(info);
            }
            reader.Close();
            if (Array != null)
            {
                return Array;
            }
            else
            {

                return null;
            }
            
        }
     public List<telents> order()//根据最新显示
     {
         List<telents> Array = new List<telents>();
         string cmdText = "select * from ResumeInfo order by ReSetTime desc";
         SqlDataReader reader = db.ExecuteReader(cmdText, null, null);
         while (reader.Read())
         {
             telents info = new telents();
             info.RdID = int.Parse(reader["RdID"].ToString());
             info.JobIntention = reader["JobIntension"].ToString();
             info.School = reader["School"].ToString();
             info.StuMajor = reader["StuMajor"].ToString();
             info.StuName = reader["StuName"].ToString();
             info.GraduateYear = reader["GraduateYear"].ToString();
             info.StuId = reader["StuId"].ToString();
             info.LookTimes = int.Parse(reader["LookTimes"].ToString());
             Array.Add(info);
         }
         reader.Close();
         if (Array != null)
         {
             return Array;
         }
         else
         {

             return null;
         }

     }
     public List<telents> orderByRecommand()//根据加推数显示
     {
         List<telents> Array = new List<telents>();
         string cmdText = "select * from ResumeInfo order by LookTimes desc";
         SqlDataReader reader = db.ExecuteReader(cmdText, null, null);
         while (reader.Read())
         {
             telents info = new telents();
             info.RdID = int.Parse(reader["RdID"].ToString());
             info.JobIntention = reader["JobIntension"].ToString();
             info.School = reader["School"].ToString();
             info.StuMajor = reader["StuMajor"].ToString();
             info.StuName = reader["StuName"].ToString();
             info.GraduateYear = reader["GraduateYear"].ToString();
             info.StuId = reader["StuId"].ToString();
             info.LookTimes = int.Parse(reader["LookTimes"].ToString());
             Array.Add(info);
         }
         reader.Close();
         if (Array != null)
         {
             return Array;
         }
         else
         {

             return null;
         }

      }
    }
   }

