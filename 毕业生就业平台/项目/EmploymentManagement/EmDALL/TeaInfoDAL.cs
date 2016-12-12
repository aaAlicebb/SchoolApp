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
    public class TeaInfoDAL
    {
         private SqlHelper db;
         public TeaInfoDAL()
        {
            db=new SqlHelper();
        }
         public List<TeaInfo> SelectStu()
        {

            string cmdText = "select * from TeaInfo";
            string[] param = { null };
            object[] values = { null };

            SqlDataReader reader = db.ExecuteReader(cmdText, null, null);
            List<TeaInfo> Tealist = new List<TeaInfo>();
            while (reader.Read())
            {
                TeaInfo tea = new TeaInfo();
                tea.ID = int.Parse(reader["ID"].ToString());
                tea.TeaID = reader["TeaID"].ToString();
                tea.TeaPwd = reader["TeaPwd"].ToString();
                tea.TeaName = reader["TeaName"].ToString();
                tea.TeaSex = char.Parse(reader["TeaSex"].ToString());
                tea.TeaAge = Convert.ToInt32(reader["TeaAge"].ToString());
                tea.IDnumber = reader["IDnumber"].ToString();
                Tealist.Add(tea);

            }
            
            if (Tealist != null)
            {
                reader.Close();
                return Tealist;
            }
            reader.Close();
            return null;
        }
        //删除
         public int DeleteById(int ID)
         {
             string cmdText = "delete from TeaInfo where ID=@ID";
             string[] param = { "@ID" };
             object[] values = { ID };

             int count =(int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
        //更新
         public int UpdateById(int ID, TeaInfo tea)
         {
             string cmdText = "Update TeaInfo set TeaID=@TeaID,TeaPwd=@TeaPwd,TeaName=@TeaName,TeaSex=@TeaSex,TeaAge=@TeaAge,IDnumber=@IDnumber where ID=@ID";
             string[] param = { "@ID", "@TeaID", "@TeaPwd", "@TeaName", "@TeaSex", "@TeaAge", "@IDnumber"};
             object[] values = {tea.ID,tea.TeaID,tea.TeaPwd,tea.TeaName,tea.TeaSex,tea.TeaAge,tea.IDnumber };

             int count = (int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
        //插入
         public int Insert(TeaInfo tea)
         {
             string cmdText = "insert into TeaInfo(TeaID,TeaPwd, TeaName, TeaSex, TeaAge, IDnumber) values(@TeaID,@TeaPwd,@TeaName,@TeaSex,@TeaAge,@IDnumber)";
             string[] param = { "@TeaID", "@TeaPwd", "@TeaName", "@TeaSex", "@TeaAge", "@IDnumber" };
             object[] values = { tea.TeaID, tea.TeaPwd, tea.TeaName, tea.TeaSex, tea.TeaAge, tea.IDnumber };

             int count = (int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
    }
}
