using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmHelper;
using EmModel;
using System.Data;
using System.Data.SqlClient;

namespace EmDALL
{
    public class EmInfoDAL
    {
        private SqlHelper db;
        public EmInfoDAL()
        {
            db=new SqlHelper();
        }
         public List<EmInfo> SelectStu()
        {

            string cmdText = "select * from EmploymentInfo";
            string[] param = { null };
            object[] values = { null };

            SqlDataReader reader = db.ExecuteReader(cmdText, null, null);
            List<EmInfo> Emlist = new List<EmInfo>();
            while (reader.Read())
            {
                EmInfo em = new EmInfo();
                em.ID = int.Parse(reader["ID"].ToString());
                em.stuID = reader["stuID"].ToString();
                em.stuName = reader["stuName"].ToString();
                em.ComID =int.Parse(reader["ComID"].ToString());
                em.ComName = reader["ComName"].ToString();
                em.Injobtime = Convert.ToDateTime(reader["Injobtime"].ToString());
                em.Wage = Convert.ToInt32(reader["Wage"].ToString());
                em.FeedbackInfo = reader["FeedbackInfo"].ToString();
                em.Feedbacktime = Convert.ToDateTime(reader["Feedbacktime"].ToString());
                Emlist.Add(em);

            }
            
            if (Emlist != null)
            {
                reader.Close();
                return Emlist;
            }
            reader.Close();
            return null;
        }
        //删除
         public int DeleteById(int ID)
         {
             string cmdText = "delete from EmploymentInfo where ID=@ID";
             string[] param = { "@ID" };
             object[] values = { ID };

             int count =(int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
        //更新
         public int UpdateById(int ID,EmInfo em)
         {
             string cmdText = "Update EmploymentInfo set stuID=@stuID,stuName=@stuName,ComID=@ComID,ComName=@ComName,Injobtime=@Injobtime,Wage=@Wage,FeedbackInfo=@FeedbackInfo,Feedbacktime=@Feedbacktime where ID=@ID";
             string[] param = { "@ID","@stuID", "@stuName", "@ComID", "@ComName", "@Injobtime", "@Wage", "@FeedbackInfo", "@Feedbacktime" };
             object[] values = { em.ID, em.stuID, em.stuName, em.ComID, em.ComName, em.Injobtime, em.Wage, em.FeedbackInfo, em.Feedbacktime };

             int count = (int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
        //插入
         public int Insert(EmInfo em)
         {
             string cmdText = "insert into EmploymentInfo(stuID,stuName, ComID, ComName, Injobtime, Wage, FeedbackInfo, Feedbacktime) values(@stuID,@stuName, @ComID, @ComName, @Injobtime, @Wage, @FeedbackInfo, @Feedbacktime)";
             string[] param = { "@stuID", "@stuName", "@ComID", "@ComName", "@Injobtime", "@Wage", "@FeedbackInfo", "@Feedbacktime" };
             object[] values = {  em.stuID, em.stuName, em.ComID, em.ComName, em.Injobtime, em.Wage, em.FeedbackInfo, em.Feedbacktime };

             int count = (int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
    }
}
