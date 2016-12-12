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
     
    public class stuInfoDAL
    {
       private SqlHelper db;
       public stuInfoDAL()
        {
            db=new SqlHelper();
        }
         public List<StuInfo> SelectStu()
        {

            string cmdText = "select * from stuInfo";
            string[] param = { null };
            object[] values = { null };

            SqlDataReader reader = db.ExecuteReader(cmdText, null, null);
            List<StuInfo> Stulist = new List<StuInfo>();
            while (reader.Read())
            {
                StuInfo stu = new StuInfo();
                stu.ID = int.Parse(reader["ID"].ToString());
                stu.stuID = reader["stuID"].ToString();
                stu.stuPwd = reader["stuPwd"].ToString();
                stu.stuName = reader["stuName"].ToString();
                stu.stuSex = char.Parse(reader["stuSex"].ToString());
                stu.stuAge = Convert.ToInt32(reader["stuAge"].ToString());
                stu.stuGrade = Convert.ToInt32(reader["stuGrade"].ToString());
                stu.stuMajor = reader["stuMajor"].ToString();
                stu.stuStatus = reader["stuStatus"].ToString();
                stu.IDnumber = reader["IDnumber"].ToString();
                stu.Class = reader["Class"].ToString();
                Stulist.Add(stu);

            }
            
            if (Stulist != null)
            {
                reader.Close();
                return Stulist;
            }
            reader.Close();
            return null;
        }
         public List<StuInfo> SelectStu(string search)
         {

             string cmdText = "select * from stuInfo where stuName like @search or stuAge like @search or stuID like @search ";
             string[] param = { "@search" };
             object[] values = { search + "%" };

             SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
             List<StuInfo> Stulist = new List<StuInfo>();
             while (reader.Read())
             {
                 StuInfo stu = new StuInfo();
                 stu.ID = int.Parse(reader["ID"].ToString());
                 stu.stuID = reader["stuID"].ToString();
                 stu.stuPwd = reader["stuPwd"].ToString();
                 stu.stuName = reader["stuName"].ToString();
                 stu.stuSex = char.Parse(reader["stuSex"].ToString());
                 stu.stuAge = Convert.ToInt32(reader["stuAge"].ToString());
                 stu.stuGrade = Convert.ToInt32(reader["stuGrade"].ToString());
                 stu.stuMajor = reader["stuMajor"].ToString();
                 stu.stuStatus = reader["stuStatus"].ToString();
                 stu.IDnumber = reader["IDnumber"].ToString();
                 stu.Class = reader["Class"].ToString();
                 Stulist.Add(stu);

             }

             if (Stulist != null)
             {
                 reader.Close();
                 return Stulist;
             }
             reader.Close();
             return null;
         }
        //删除
         public int DeleteById(int ID)
         {
             string cmdText = "delete from stuInfo where ID=@ID";
             string[] param = { "@ID" };
             object[] values = { ID };

             int count =(int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
        //更新
         public int UpdateById(int ID,StuInfo stu)
         {
             string cmdText = "Update stuInfo set stuID=@stuID,stuPwd=@stuPwd,stuName=@stuName,stuSex=@stuSex,stuAge=@stuAge,stuGrade=@stuGrade,stuMajor=@stuMajor,stuStatus=@stuStatus,IDnumber=@IDnumber,Class=@Class where ID=@ID";
             string[] param = { "@ID","@IDnumber", "@stuID", "@stuPwd", "@stuName", "@stuSex", "@stuAge", "@stuGrade", "@stuMajor", "@stuStatus","@Class" };
             object[] values = { stu.ID,stu.IDnumber,stu.stuID,stu.stuPwd,stu.stuName,stu.stuSex,stu.stuAge,stu.stuGrade,stu.stuMajor,stu.stuStatus,stu.Class };

             int count = (int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
        //插入
         public int Insert(StuInfo stu)
         {
             string cmdText = "insert into stuInfo(stuID,stuPwd,stuName,stuSex,stuAge,stuGrade,stuMajor,stuStatus,IDnumber,Class) values(@stuID,@stuPwd,@stuName,@stuSex,@stuAge,@stuGrade,@stuMajor,@stuStatus,@IDnumber,@Class)";
             string[] param = { "@stuID", "@stuPwd", "@stuName", "@stuSex", "@stuAge", "@stuGrade", "@stuMajor", "@stuStatus", "@IDnumber", "@Class" };
             object[] values = { stu.stuID, stu.stuPwd, stu.stuName, stu.stuSex, stu.stuAge, stu.stuGrade, stu.stuMajor, stu.stuStatus, stu.IDnumber, stu.Class };

             int count = (int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
    }
}

