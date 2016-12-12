using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmModel;
using EmDALL;
namespace EmBLL
{
    public class ComBLL
    {
        public List<ComInfo> SelectStu()
        {

            ComInfoDAL comDao = new ComInfoDAL();

            List<ComInfo> Comlist = new List<ComInfo>();
            Comlist = comDao.SelectStu();
            return Comlist;
        }
        public int DeleteById(int ID)
        {
            ComInfoDAL comDao = new ComInfoDAL();
            return comDao.DeleteById(ID);
        }
        public int UpdateById(ComInfo com)
        {
            ComInfoDAL comDao = new ComInfoDAL();
            return comDao.UpdateById(com);
        }
        public int Insert(ComInfo com)
        {
            ComInfoDAL comDao = new ComInfoDAL();
            return comDao.Insert(com);
        }
    }
}
