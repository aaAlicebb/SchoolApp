using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EmployementMODEL;
using SQLHelper;

namespace EmployementDAL
{
   public class StuInfoDAL
    {
       SqlHelper sql = new SqlHelper();
       /// <summary>
       /// 方法用于个人界面图片传输
       /// </summary>
       /// <param name="stuId"></param>
       /// <returns></returns>
       public byte[] tpcz(string stuId)
       {
           string cmd = "select * from StuInfo where stuID=@id";
           string[] pra = { "@id"};
           string[] value = { stuId};
           byte[] tp = null;
           SqlDataReader reader = sql.ExecuteReader(cmd,pra,value);
           if (reader.Read())
           {
               if (reader["stuImg"].ToString() != "")
               {
                   tp = (byte[])reader["stuImg"];
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
       /// 通过学号查询学生信息
       /// </summary>
       /// <param name="stuID"></param>
       /// <returns></returns>
       public StuInfo selectStuById(string stuID) 
       {
           string cmd = "select * from StuInfo where stuID=@id";
           string[] pra = { "@id"};
           string[] val = { stuID};
           SqlDataReader reader = sql.ExecuteReader(cmd,pra,val);
           if (reader.Read())
           {
               StuInfo stu = new StuInfo();
               stu.stuAddress = reader["stuAddress"].ToString();
               stu.stuAge = (int)reader["stuAge"];
               stu.stuGride = (int)reader["stuGrade"];
               stu.stuID = reader["stuID"].ToString();
               stu.stuIdnumber = reader["IDnumber"].ToString();
               stu.stuMajir = reader["stuMajor"].ToString();
               stu.stuName = reader["stuName"].ToString();
               stu.stuSex = reader["stuSex"].ToString();
               stu.stuStatus = reader["stuStatus"].ToString();
               stu.stuEducation = reader["stuEducation"].ToString();
               //stu.stuBirth = reader["stuBirth"].ToString();
               return stu;
           }
           else 
           {
               return null;
           }          
       }
       /// <summary>
       /// 学生个人中心界面修改信息
       /// </summary>
       /// <returns></returns>
       public int updateStuMes(StuInfo Stu) 
       {
           string cmd = "update StuInfo set stuName=@name,stuSex=@sex,stuAge=@age,stuGrade=@gride,stuMajor=@major,stuEducation=@education,stuAddress=@address where stuID=@ID";
           string[] pra={"@name","@sex","@age","@gride","@major","@education","@address","@ID"};
           string[] val={Stu.stuName,Stu.stuSex,Stu.stuAge.ToString(),Stu.stuGride.ToString(),Stu.stuMajir,Stu.stuEducation,Stu.stuAddress,Stu.stuID};
           int count = sql.ExecuteNoneQuery(cmd,pra,val);
           return count;
       }
       /// <summary>
       /// 改变头像根据学号
       /// </summary>
       /// <returns></returns>
       public int updateStuImg(byte[] img,string id) 
       {
           string cmd = "update StuInfo set stuImg=@img where stuID=@id";
           string[] pra = {"@img","@id" };
           object[] val = {img,id };
           int result= (int)sql.ExecuteNoneQuery(cmd,pra,val);
          
           return result;
       }
    }
}
