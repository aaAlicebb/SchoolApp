using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmModel;
using EmDALL;
namespace EmBLL
{
    public class EmpBLL
    {
        public List<EmInfo> SelectStu()
        {

            EmInfoDAL emDao = new EmInfoDAL();

            List<EmInfo> Emlist = new List<EmInfo>();
            Emlist = emDao.SelectStu();
            return Emlist;
        }
        public int DeleteById(int ID)
        {
            EmInfoDAL emdao = new EmInfoDAL();
            return emdao.DeleteById(ID);
        }
        public int UpdateById(int ID, EmInfo em)
        {
            EmInfoDAL emdao = new EmInfoDAL();
            return emdao.UpdateById(ID, em);
        }
        public int Insert(EmInfo em)
        {
            EmInfoDAL emdao = new EmInfoDAL();
            return emdao.Insert(em);
        }
    }
}
