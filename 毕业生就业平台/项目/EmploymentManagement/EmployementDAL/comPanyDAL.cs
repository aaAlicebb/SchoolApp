using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployementMODEL;
using System.Data.SqlClient;
using  SQLHelper;
using System.Data;
using System.Collections;

namespace EmployementDAL
{
    public class comPanyDAL
    {
        static SqlHelper db = new SqlHelper();
        public List<companyInfo> selectComInfo()//显示企业招聘信息
        {
            List<companyInfo> Array = new List<companyInfo>();
            string cmdText = "select distinct * from  JobInfo";
            SqlDataReader reader = db.ExecuteReader(cmdText, null, null);
            while (reader.Read())
            {
                companyInfo info = new companyInfo();
                info.ComId = int.Parse(reader["ComId"].ToString());
                info.ComName = reader["ComName"].ToString();
                info.ComType = reader["ComType"].ToString();
                info.ComArea = reader["ComArea"].ToString();
                info.Compeople = reader["Compeople"].ToString();
                info.ComTel = reader["ComTel"].ToString();
                info.FeedbackInfo = reader["FeedbackInfo"].ToString();
                info.PositionInfo = reader["PositionInfo"].ToString();
                info.ComRemark = reader["ComRemark"].ToString();
                info.ComInfo = reader["ComInfo"].ToString();
                //info.uploadTime = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                info.uploadTime = (DateTime)reader["uploadTime"];
                info.ComPosition = reader["ComPosition"].ToString();
                info.PositionType = reader["PositionType"].ToString();
                info.PositionAttribute = reader["PositionAttribute"].ToString();
                info.ComCity = reader["ComCity"].ToString();
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
        public List<companyInfo> selectComInfoByName(string comName)//通过企业名称显示企业招聘信息
        {
            List<companyInfo> Array = new List<companyInfo>();
            string cmdText = "select distinct * from JobInfo where ComName=@comName union all(select * from JobInfo EXCEPT select * from JobInfo where ComName=@comName)";
            string[] param = { "@comName" };
            object[] values = { comName };
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            while (reader.Read())
            {
                companyInfo info = new companyInfo();
                info.ComId = int.Parse(reader["ComId"].ToString());
                info.ComName = reader["ComName"].ToString();
                info.ComType = reader["ComType"].ToString();
                info.ComArea = reader["ComArea"].ToString();
                info.Compeople = reader["Compeople"].ToString();
                info.ComTel = reader["ComTel"].ToString();
                info.FeedbackInfo = reader["FeedbackInfo"].ToString();
                info.PositionInfo = reader["PositionInfo"].ToString();
                info.ComRemark = reader["ComRemark"].ToString();
                info.ComInfo = reader["ComInfo"].ToString();
                info.uploadTime = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                info.ComPosition = reader["ComPosition"].ToString();
                info.PositionType = reader["PositionType"].ToString();
                info.ComCity = reader["ComCity"].ToString();
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
        public List<companyInfo> selectComInfoByPositionType(string PositionType)//根据职位类型显示企业招聘信息
        {
            List<companyInfo> Array = new List<companyInfo>();
            string cmdText = "select * from JobInfo where PositionType=@PositionType union all(select * from JobInfo EXCEPT select * from JobInfo where PositionType=@PositionType)";
            string[] param = { "@PositionType" };
            object[] values = { PositionType };
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            while (reader.Read())
            {
                companyInfo info = new companyInfo();
                info.ComId = int.Parse(reader["ComId"].ToString());
                info.ComName = reader["ComName"].ToString();
                info.ComType = reader["ComType"].ToString();
                info.ComArea = reader["ComArea"].ToString();
                info.Compeople = reader["Compeople"].ToString();
                info.ComTel = reader["ComTel"].ToString();
                info.FeedbackInfo = reader["FeedbackInfo"].ToString();
                info.PositionInfo = reader["PositionInfo"].ToString();
                info.ComRemark = reader["ComRemark"].ToString();
                info.ComInfo = reader["ComInfo"].ToString();
                info.uploadTime = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                info.ComPosition = reader["ComPosition"].ToString();
                info.PositionType = reader["PositionType"].ToString();
                info.ComCity = reader["ComCity"].ToString();
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
        public List<province> selectPrvinceByName()//省份
        {
            List<province> Array = new List<province>();
            string cmdText = "select * from Province where ParentID=0";
            SqlDataReader reader = db.ExecuteReader(cmdText, null, null);
            while (reader.Read())
            {
                province info = new province();
                info.ProName = reader["ProName"].ToString();
                info.ProID = int.Parse((reader["ProID"].ToString()));
                info.ParentID = int.Parse(reader["ParentID"].ToString());
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
        public List<province> selectCity(int index)//城市
        {
            List<province> Array = new List<province>();
            string cmdText = "select * from Province  where ParentID=@index";
            string[] param = { "@index" };
            object[] values = { index };
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            while (reader.Read())
            {
                province info = new province();
                info.ProName = reader["ProName"].ToString();
                info.ProID = int.Parse((reader["ProID"].ToString()));
                info.ParentID = int.Parse(reader["ParentID"].ToString());
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
        public List<companyInfo> selectComInfoByPosition(string Job)//根据职位性质显示企业招聘信息
        {
            List<companyInfo> Array = new List<companyInfo>();
            string cmdText = "select distinct * from JobInfo where PositionAttribute=@Job union all(select * from JobInfo EXCEPT select * from JobInfo where PositionAttribute=@Job)";
            string[] param = { "@Job" };
            object[] values = { Job };
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            while (reader.Read())
            {
                companyInfo info = new companyInfo();
                info.ComId = int.Parse(reader["ComId"].ToString());
                info.ComName = reader["ComName"].ToString();
                info.ComType = reader["ComType"].ToString();
                info.ComArea = reader["ComArea"].ToString();
                info.Compeople = reader["Compeople"].ToString();
                info.ComTel = reader["ComTel"].ToString();
                info.FeedbackInfo = reader["FeedbackInfo"].ToString();
                info.PositionInfo = reader["PositionInfo"].ToString();
                info.ComRemark = reader["ComRemark"].ToString();
                info.ComInfo = reader["ComInfo"].ToString();
                info.uploadTime = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                info.ComPosition = reader["ComPosition"].ToString();
                info.PositionType = reader["PositionType"].ToString();
                info.PositionAttribute = reader["PositionAttribute"].ToString();
                info.ComCity = reader["ComCity"].ToString();
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
        public List<companyInfo> selectComInfoByTime()//根据发布时间显示企业招聘信息
        {
            List<companyInfo> Array = new List<companyInfo>();
            string cmdText = "select distinct * from JobInfo order by uploadTime desc";
            SqlDataReader reader = db.ExecuteReader(cmdText, null, null);
            while (reader.Read())
            {
                companyInfo info = new companyInfo();
                info.ComId = int.Parse(reader["ComId"].ToString());
                info.ComName = reader["ComName"].ToString();
                info.ComType = reader["ComType"].ToString();
                info.ComArea = reader["ComArea"].ToString();
                info.Compeople = reader["Compeople"].ToString();
                info.ComTel = reader["ComTel"].ToString();
                info.FeedbackInfo = reader["FeedbackInfo"].ToString();
                info.PositionInfo = reader["PositionInfo"].ToString();
                info.ComRemark = reader["ComRemark"].ToString();
                info.ComInfo = reader["ComInfo"].ToString();
                info.uploadTime = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                info.ComPosition = reader["ComPosition"].ToString();
                info.PositionType = reader["PositionType"].ToString();
                info.PositionAttribute = reader["PositionAttribute"].ToString();
                info.ComCity = reader["ComCity"].ToString();
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
        public List<companyInfo> selectComInfoByCity(string ComCity)//根据工作地点显示企业招聘信息
        {
            List<companyInfo> Array = new List<companyInfo>();
            string cmdText = "select distinct * from JobInfo where ComCity=@ComCity union all(select * from JobInfo EXCEPT select * from JobInfo where ComCity=@ComCity)";
            string[] param = { "@ComCity" };
            object[] values = { ComCity };
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            while (reader.Read())
            {
                companyInfo info = new companyInfo();
                info.ComId = int.Parse(reader["ComId"].ToString());
                info.ComName = reader["ComName"].ToString();
                info.ComType = reader["ComType"].ToString();
                info.ComArea = reader["ComArea"].ToString();
                info.Compeople = reader["Compeople"].ToString();
                info.ComTel = reader["ComTel"].ToString();
                info.FeedbackInfo = reader["FeedbackInfo"].ToString();
                info.PositionInfo = reader["PositionInfo"].ToString();
                info.ComRemark = reader["ComRemark"].ToString();
                info.ComInfo = reader["ComInfo"].ToString();
                info.uploadTime = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                info.ComPosition = reader["ComPosition"].ToString();
                info.PositionType = reader["PositionType"].ToString();
                info.PositionAttribute = reader["PositionAttribute"].ToString();
                info.ComCity = reader["ComCity"].ToString();
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
        public List<companyInfo> selectComInfoByLookTime()//根据浏览次数显示企业招聘信息
        {
            List<companyInfo> Array = new List<companyInfo>();
            string cmdText = "select distinct * from JobInfo order by LookTimes desc";
            SqlDataReader reader = db.ExecuteReader(cmdText, null, null);
            while (reader.Read())
            {
                companyInfo info = new companyInfo();
                info.ComId = int.Parse(reader["ComId"].ToString());
                info.ComName = reader["ComName"].ToString();
                info.ComType = reader["ComType"].ToString();
                info.ComArea = reader["ComArea"].ToString();
                info.Compeople = reader["Compeople"].ToString();
                info.ComTel = reader["ComTel"].ToString();
                info.FeedbackInfo = reader["FeedbackInfo"].ToString();
                info.PositionInfo = reader["PositionInfo"].ToString();
                info.ComRemark = reader["ComRemark"].ToString();
                info.ComInfo = reader["ComInfo"].ToString();
                info.uploadTime = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                info.ComPosition = reader["ComPosition"].ToString();
                info.PositionType = reader["PositionType"].ToString();
                info.PositionAttribute = reader["PositionAttribute"].ToString();
                info.ComCity = reader["ComCity"].ToString();
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
        public List<companyInfo> Times(string ComName)//浏览次数+1
        {
            List<companyInfo> Array = new List<companyInfo>();
            string cmdText = "Update JobInfo set LookTimes=LookTimes+1 where ComName=@ComName";
            string[] param = { "@ComName" };
            object[] values = { ComName };
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            while (reader.Read())
            {
                companyInfo info = new companyInfo();
                info.ComId = int.Parse(reader["ComId"].ToString());
                info.ComName = reader["ComName"].ToString();
                info.ComType = reader["ComType"].ToString();
                info.ComArea = reader["ComArea"].ToString();
                info.Compeople = reader["Compeople"].ToString();
                info.ComTel = reader["ComTel"].ToString();
                info.FeedbackInfo = reader["FeedbackInfo"].ToString();
                info.PositionInfo = reader["PositionInfo"].ToString();
                info.ComRemark = reader["ComRemark"].ToString();
                info.ComInfo = reader["ComInfo"].ToString();
                info.uploadTime = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                info.ComPosition = reader["ComPosition"].ToString();
                info.PositionType = reader["PositionType"].ToString();
                info.PositionAttribute = reader["PositionAttribute"].ToString();
                info.ComCity = reader["ComCity"].ToString();
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
        public List<companyInfo> selectComInfoById(string comid)//通过企业账号显示企业招聘信息
        {
            List<companyInfo> Array = new List<companyInfo>();
            string cmdText = "select * from JobInfo where ComLognNum=@comid";
            string[] param = { "@comid" };
            object[] values = { comid };
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            while (reader.Read())
            {
                companyInfo info = new companyInfo();
                info.ComId = int.Parse(reader["ComId"].ToString());
                info.ComName = reader["ComName"].ToString();
                info.ComType = reader["ComType"].ToString();
                info.ComArea = reader["ComArea"].ToString();
                info.Compeople = reader["Compeople"].ToString();
                info.ComTel = reader["ComTel"].ToString();
                info.FeedbackInfo = reader["FeedbackInfo"].ToString();
                info.PositionInfo = reader["PositionInfo"].ToString();
                info.ComRemark = reader["ComRemark"].ToString();
                info.ComInfo = reader["ComInfo"].ToString();
                //info.uploadTime = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                info.uploadTime =(DateTime)reader["uploadTime"];
                //info.uploadTime = Convert.ToDateTime(reader["uploadTime"]);
                info.ComPosition = reader["ComPosition"].ToString();
                info.PositionType = reader["PositionType"].ToString();
                info.ComCity = reader["ComCity"].ToString();
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
        /// <summary>
        /// 通过名称和时间招聘信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="uptime"></param>
        /// <returns></returns>
        public int DeleteByTimeAndName(string name,DateTime uptime) 
        {
            string cmd = "delete from JobInfo where ComName=@Comname and uploadTime=@time";
            string[] pra = {"@Comname","@time"};
            object[] val = {name,uptime };
            int key = db.ExecuteNoneQuery(cmd,pra,val);
            return key;
        }
    }
}
