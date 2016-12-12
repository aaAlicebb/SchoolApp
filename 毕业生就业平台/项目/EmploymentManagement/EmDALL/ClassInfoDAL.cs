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
    public class ClassInfoDAL
    {
        private SqlHelper db;
        public ClassInfoDAL()
        {
            db=new SqlHelper();
        }
         public List<ClassInfo> SelectStu()
        {

            string cmdText = "select * from ClassInfo";
            string[] param = { null };
            object[] values = { null };

            SqlDataReader reader = db.ExecuteReader(cmdText, null, null);
            List<ClassInfo> Classlist = new List<ClassInfo>();
            while (reader.Read())
            {
                ClassInfo cla = new ClassInfo();
                cla.ID = int.Parse(reader["ID"].ToString());
                cla.ClassName = reader["ClassName"].ToString();
                cla.ClassTeacher = reader["ClassTeacher"].ToString();
                cla.ClassGride = reader["ClassGride"].ToString();
                cla.ClassMajor = reader["ClassMajor"].ToString();
                Classlist.Add(cla);

            }

            if (Classlist != null)
            {
                reader.Close();
                return Classlist;
            }
            reader.Close();
            return null;
        }
        //删除
         public int DeleteById(int ID)
         {
             string cmdText = "delete from ClassInfo where ID=@ID";
             string[] param = { "@ID" };
             object[] values = { ID };

             int count =(int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
        //更新
         public int UpdateById(ClassInfo cla)
         {
             string cmdText = "Update ClassInfo set ClassName=@ClassName,ClassTeacher=@ClassTeacher,ClassGride=@ClassGride,ClassMajor=@ClassMajor where ID=@ID";
             string[] param = { "@ClassName", "@ClassTeacher", "@ClassGride", "@ClassMajor", "@ID" };
             object[] values = { cla.ClassName,cla.ClassTeacher,cla.ClassGride,cla.ClassMajor,cla.ID };

             int count = (int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
        //插入
         public int Insert(ClassInfo cla)
         {
             string cmdText = "insert into ClassInfo(ClassName,ClassTeacher,ClassGride,ClassMajor) values(@ClassName,@ClassTeacher, @ClassGride, @ClassMajor)";
             string[] param = { "@ClassName", "@ClassTeacher", "@ClassGride", "@ClassMajor" };
             object[] values = { cla.ClassName, cla.ClassTeacher, cla.ClassGride, cla.ClassMajor };

             int count = (int)db.ExecuteNoneQuery(cmdText, param, values);
             return count;
         }
    }
}
