using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.DAL;

namespace Hotel.BLL
{
    public class CuspenBLL
    {


        public int Insert(List<CusSpenInfo> spenlist)
        {
            CustSpenDAL dal = new CustSpenDAL();

            int list = dal.Insert(spenlist);
            //int count= dao.Insert(user);
            return list;

        }
        public int counts(int roomid)
        {
            CheckOutDAL spend = new CheckOutDAL();
            return spend.counts(roomid);

        }
        public List<CusSpenInfo> SelectSpend(int roomid, string spanno)
        {
            CustSpenDAL spend = new CustSpenDAL();
            List<CusSpenInfo> Spendlist = new List<CusSpenInfo>();
            Spendlist = spend.SelectCheck(roomid, spanno);
            return Spendlist;

        }
        public List<CusSpenInfo> SelectSpend(int roomid)
        {
            CheckOutDAL spend = new CheckOutDAL();

            List<CusSpenInfo> Spendlist = new List<CusSpenInfo>();
            Spendlist = spend.SelectSpend(roomid);
            return Spendlist;
        }
        public int delete(DateTime intime)
        {
            CustSpenDAL dao = new CustSpenDAL();
            return dao.delete(intime);
        }
    }
}
