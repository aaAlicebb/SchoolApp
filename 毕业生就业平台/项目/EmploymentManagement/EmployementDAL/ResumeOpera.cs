using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployementMODEL;
using System.Data;
using System.Data.SqlClient;
using SQLHelper;
using System.Collections;

namespace EmployementDAL
{
   public class ResumeOpera
    {
       SqlHelper sql = new SqlHelper();
       /// <summary>
       /// 取发布的简历前五条放到主界面。
       /// </summary>
       /// <returns></returns>
       public List<ResumeInfo> ResumeSelect()
       {
           string cmdStr = "select top 6 * from ResumeInfo";
           SqlDataReader reader = sql.ExecuteReader(cmdStr,null,null);
           List<ResumeInfo> list = new List<ResumeInfo>();
           while(reader.Read())
           {
               ResumeInfo res = new ResumeInfo();
               res.Name = reader["StuName"].ToString();
               res.JobIntension=reader["JobIntension"].ToString();
               res.stuMajor = reader["StuMajor"].ToString();
               list.Add(res);
           }
           if(list!=null)
           {
               return list;
           }
           return null;
       }
       /// <summary>
       /// 通过学号查询一条简历
       /// </summary>
       /// <returns></returns>
       public ResumeInfo selectByStuId(string id) 
       {
           string cmdStr = "select * from ResumeInfo where stuId=@id";
           string[] pra = {"@id"};
           string[] val = { id};
           SqlDataReader reader = sql.ExecuteReader(cmdStr, pra,val);
           if (reader.Read())
           {
               ResumeInfo res = new ResumeInfo();
               res.Name = reader["StuName"].ToString();
               res.JobIntension = reader["JobIntension"].ToString();
               res.stuMajor = reader["StuMajor"].ToString();
               return res;
           }
           else 
           {
               return null;
           }
       }
       /// <summary>
       /// 通过ID查询一批简历,一般方式
       /// </summary>
       /// <returns></returns>
       public List<ResumeInfo> selectListById(string id) 
       {
           string cmdStr = "select * from ResumeInfo where stuId=@id";
           string[] pra = { "@id" };
           string[] val = { id };
           SqlDataReader reader = sql.ExecuteReader(cmdStr, pra, val);
           List<ResumeInfo> list = new List<ResumeInfo>();
           while(reader.Read())
           {
               ResumeInfo res = new ResumeInfo();
               res.Name = reader["StuName"].ToString();
               res.JobIntension = reader["JobIntension"].ToString();
               res.stuMajor = reader["StuMajor"].ToString();
               res.ReSetTime = (DateTime)reader["ReSetTime"];
               list.Add(res);
           }
           if(list!=null)
           {
               return list;
           }
           else
           {
               return null;
           }
       
       }
       /// <summary>
       /// 通过姓名和时间删除简历
       /// </summary>
       /// <param name="times"></param>
       /// <param name="name"></param>
       /// <returns></returns>
       public int deleteByNameAndTime(DateTime times,string name) 
       {
           string cmd = "delete from ResumeInfo where StuName=@name and ReSetTime=@times";
           string[] pra = {"@name","@times" };
           object[] val = { name,times};
           int result = sql.ExecuteNoneQuery(cmd,pra,val);
           return result;
       }

       /// <summary>
       /// 通过ID查询一批简历,数据集方式
       /// </summary>
       /// <returns></returns>
       public List<ResumeInfo> selectListByIdDate(string id)
       {
           string cmdStr = "select * from ResumeInfo where stuId=@id";
           string[] pra = { "@id" };
           string[] val = { id };
           SqlDataReader reader = sql.ExecuteReader(cmdStr, pra, val);
           List<ResumeInfo> list = new List<ResumeInfo>();
           while (reader.Read())
           {
               ResumeInfo res = new ResumeInfo();
               res.Name = reader["StuName"].ToString();
               res.JobIntension = reader["JobIntension"].ToString();
               res.stuMajor = reader["StuMajor"].ToString();
               res.ReSetTime = (DateTime)reader["ReSetTime"];
               list.Add(res);
           }
           if (list != null)
           {
               return list;
           }
           else
           {
               return null;
           }

       }
       /// <summary>
       /// 创建一个简历
       /// </summary>
       /// <returns></returns>
       public int insertResume(ResumeInfo res) 
       {
           string cmd = "insert into ResumeInfo(ReAddre,ReSex,RePhone,ReEmail,RePolitical,StuName,RequestPostion,IsPost,ReSetTime,JobIntension,StuMajor,StuId,PersonalExperience,SelfIntroduction,EducationalExperience,GoodSkills,LookTimes) values(@ReAddre,@ReSex,@RePhone,@ReEmail,@RePolitical,@StuName,@RequestPostion,@IsPost,@ReSetTime,@JobIntension,@StuMajor,@StuId,@PersonalExperience,@SelfIntroduction,@EducationalExperience,@GoodSkills,@times)";
           string[] pra = {"@ReAddre","@ReSex","@RePhone","@ReEmail","@RePolitical","@StuName","@RequestPostion","@IsPost","@ReSetTime","@JobIntension","@StuMajor","@StuId","@PersonalExperience","@SelfIntroduction","@EducationalExperience","@GoodSkills","@times"};
           object[] val = {res.ReAddress,res.ReSex,res.RePhone,res.ReEmail,res.RePolitical,res.Name,res.RequestPozision,res.IsPost,res.ReSetTime,res.JobIntension,res.stuMajor,res.StuXH,res.GRJL,res.ZWJS,res.JYJL,res.SCJN,0};
           int result = sql.ExecuteNoneQuery(cmd,pra,val);
           return result;
       }
       /// <summary>
       /// 通过姓名查询
       /// </summary>
       /// <returns></returns>
       public ResumeInfo selectByStuName(string name)
       {
           string cmdStr = "select * from ResumeInfo where StuName=@name";
           string[] pra = { "@name" };
           string[] val = { name };
           SqlDataReader reader = sql.ExecuteReader(cmdStr, pra, val);
           if (reader.Read())
           {
               ResumeInfo res = new ResumeInfo();
               res.Name = reader["StuName"].ToString();
               res.JobIntension = reader["JobIntension"].ToString();
               res.stuMajor = reader["StuMajor"].ToString();
               res.GRJL = reader["PersonalExperience"].ToString();
               res.ReAddress = reader["Readdre"].ToString();
               res.ReEmail=reader["ReEmail"].ToString();
               res.RePhone = reader["Rephone"].ToString();
               res.RePolitical = reader["RePolitical"].ToString();
               res.ReSex = reader["ReSex"].ToString();
               res.SCJN = reader["GoodSkills"].ToString();
               res.StuXH=reader["StuId"].ToString();
               res.ZWJS = reader["SelfIntroduction"].ToString();
               res.JYJL = reader["EducationalExperience"].ToString();
               return res;
           }
           else
           {
               return null;
           }
       }
       /// <summary>
       /// 通过公司名和简历id插入企业收藏表
       /// </summary>
       /// <param name="Comname"></param>
       /// <param name="JlId"></param>
       /// <returns></returns>
       public int InsertMangerResume(string Comname, string JlId)
       {
           string cmd = "insert into RecruitManagementInfo(ComId,recID) values(@comid,@recid)";
           string[] pra = { "@comid", "@recid" };
           string[] val = { Comname, JlId };
           int cn = sql.ExecuteNoneQuery(cmd, pra, val);
           return cn;
       }
       /// <summary>
       /// 取一条简历id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public string slelectByStuIds(string id)
       {
           string cmd = "select * from ResumeInfo where StuId=@id order by ReSetTime desc";
           string[] pra = { "@id" };
           string[] val = { id };
           SqlDataReader reader = sql.ExecuteReader(cmd, pra, val);
           if (reader.Read())
           {
               string jlid;
               jlid = reader["RdID"].ToString();
               return jlid;
           }
           else
           {
               return null;
           }
       }
       /// <summary>
       /// 通过企业名查询信息
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       public List<ResumeManner> selectByComName(string name)
       {
           string cmd = "select * from RecruitManagementInfo where ComId=@name";
           string[] pra = { "@name" };
           string[] val = { name };
           List<ResumeManner> list = new List<ResumeManner>();
           SqlDataReader reader = sql.ExecuteReader(cmd, pra, val);
           while (reader.Read())
           {
               ResumeManner res = new ResumeManner();
               res.recID = reader["recID"].ToString();
               res.ComId = reader["ComId"].ToString();
               list.Add(res);
           }
           if (list != null)
           {
               return list;
           }
           else
           {
               return null;
           }
       }
       /// <summary>
       /// 通过简历编号查询
       /// </summary>
       /// <returns></returns>
       public ResumeInfo selectByRecID(string id)
       {
           string cmdStr = "select * from ResumeInfo where RdID=@name";
           string[] pra = { "@name" };
           string[] val = { id };
           SqlDataReader reader = sql.ExecuteReader(cmdStr, pra, val);
           if (reader.Read())
           {
               ResumeInfo res = new ResumeInfo();
               res.Name = reader["StuName"].ToString();
               res.JobIntension = reader["JobIntension"].ToString();
               res.stuMajor = reader["StuMajor"].ToString();
               res.GRJL = reader["PersonalExperience"].ToString();
               res.ReAddress = reader["Readdre"].ToString();
               res.ReEmail = reader["ReEmail"].ToString();
               res.RePhone = reader["Rephone"].ToString();
               res.RePolitical = reader["RePolitical"].ToString();
               res.ReSex = reader["ReSex"].ToString();
               res.SCJN = reader["GoodSkills"].ToString();
               res.StuXH = reader["StuId"].ToString();
               res.ZWJS = reader["SelfIntroduction"].ToString();
               res.JYJL = reader["EducationalExperience"].ToString();
               return res;
           }
           else
           {
               return null;
           }
       }
       /// <summary>
       /// 删除企业简历管理表里的简历
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public int deltByRecIds(string id)
       {
           string cmd = "delete from RecruitManagementInfo where recID=@id";
           string[] pra = { "@id" };
           string[] val = { id };
           int c = sql.ExecuteNoneQuery(cmd, pra, val);
           return c;
       }
    }
}
