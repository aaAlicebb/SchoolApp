using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.DAL;
using Hotel.Model;


namespace Hotel.BLL
{
    public class CheckBLL
    {
        public List<CheckInfo> SelectCheck(string CName, string spanno)
        {
            CheckOutDAL dao = new CheckOutDAL();

            List<CheckInfo> Inlist = new List<CheckInfo>();
            Inlist = dao.SelectCheck(CName, spanno);
            return Inlist;
        }
        /// <summary>
        /// 返回查找个数
        /// </summary>
        /// <param name="ContactGroup"></param>
        /// <returns></returns>
        public int count(string CName)
        {
            CheckOutDAL dao = new CheckOutDAL();
            return dao.count(CName);

        }
        public int count(string CName, string spanno)
        {
            //string cmdText = "select count(*) from InInfo";
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1;User ID=sa;Password=121314;";
            //conn.Open();
            CheckOutDAL dao = new CheckOutDAL();
            return dao.count(CName, spanno);
        }
        public int Insert(CheckOutInfo check)
        {
            CheckOutDAL dao = new CheckOutDAL();
            return dao.Insert(check);
        }
    }
}
