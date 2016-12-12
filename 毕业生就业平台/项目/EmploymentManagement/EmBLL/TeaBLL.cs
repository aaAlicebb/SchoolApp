using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmModel;
using EmDALL;

namespace EmBLL
{
    public class TeaBLL
    {
        public List<TeaInfo> SelectStu()
        {

            TeaInfoDAL teaDao = new TeaInfoDAL();

            List<TeaInfo> Tealist = new List<TeaInfo>();
            Tealist = teaDao.SelectStu();
            return Tealist;
        }
        public int DeleteById(int ID)
        {
            TeaInfoDAL teaDao = new TeaInfoDAL();
            return teaDao.DeleteById(ID);
        }
        public int UpdateById(int ID, TeaInfo tea)
        {
            TeaInfoDAL teaDao = new TeaInfoDAL();
            return teaDao.UpdateById(ID, tea);
        }
        public int Insert(TeaInfo tea)
        {
            TeaInfoDAL teaDao = new TeaInfoDAL();
            return teaDao.Insert(tea);
        }
    }
}
