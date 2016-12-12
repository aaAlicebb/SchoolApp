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
    public class ComInfoDAL
    {
         private SqlHelper db;
        public ComInfoDAL()
        {
            db=new SqlHelper();
        }
         public List<ComInfo> SelectStu()
        {

            string cmdText = "select * from ComInfo";
            string[] param = { null };
            object[] values = { null };

            SqlDataReader reader = db.ExecuteReader(cmdText, null, null);
            List<ComInfo> Comlist = new List<ComInfo>();
            while (reader.Read())
            {
                ComInfo com = new ComInfo();
                com.ComId = int.Parse(reader["ComId"].ToString());
                com.ComName = reader["ComName"].ToString();
                com.ComType = reader["ComType"].ToString();
                com.ComArea = reader["ComArea"].ToString();
                com.ComTel = reader["ComTel"].ToString();
                com.ComInfos = reader["ComInfo"].ToString();
                com.Compeople = reader["Compeople"].ToString();
                com.FeedbackInfo = reader["FeedbackInfo"].ToString();
                com.ComUser = reader["ComUser"].ToString();
                com.ComPwd = reader["ComPwd"].ToString();
                Comlist.Add(com);

            }
            
            if (Comlist != null)
            {
                reader.Close();
                return Comlist;
            }
            reader.Close();
            return null;
        }
        //删除
         public int DeleteById(int ID)
         {
             string cmdText = "delete from ComInfo where ComId=@ComId";
             string[] param = { "@ComId" };
             object[] values = { ID };

             int count =(int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
        //更新
         public int UpdateById(ComInfo com)
         {
             string cmdText = "Update ComInfo set ComId=@ComId,ComName=@ComName,ComType=@ComType,ComArea=@ComArea,ComTel=@ComTel,ComInfo=@ComInfo,Compeople=@Compeople,FeedbackInfo=@FeedbackInfo,ComUser=@ComUser,ComPwd=@ComPwd where ComId=@ComId";
             string[] param = { "@ComId", "@ComName", "@ComType", "@ComArea", "@ComTel", "@ComInfo", "@Compeople", "@FeedbackInfo", "@ComUser", "@ComPwd" };
             object[] values = { com.ComId,com.ComName,com.ComType,com.ComArea,com.ComTel,com.ComInfos,com.Compeople,com.FeedbackInfo,com.ComUser,com.ComPwd };

             int count = (int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
        //插入
         public int Insert(ComInfo com)
         {
             string cmdText = "insert into ComInfo(ComId,ComName, ComType, ComArea, ComTel, ComInfo, Compeople,FeedbackInfo,ComUser,ComPwd) values(@ComId,@ComName, @ComType, @ComArea, @ComTel, @ComInfo, @Compeople,@FeedbackInfo,@ComUser,@ComPwd)";
             string[] param = { "@ComId", "@ComName", "@ComType", "@ComArea", "@ComTel", "@ComInfo", "@Compeople", "@FeedbackInfo","@ComUser","ComPwd" };
             object[] values = {  com.ComId,com.ComName,com.ComType,com.ComArea,com.ComTel,com.ComInfos,com.Compeople,com.FeedbackInfo,com.ComUser,com.ComPwd };

             int count = (int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
    }
}
