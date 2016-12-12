using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmModel;
using EmDALL;

namespace EmBLL
{
    public class stuBLL
    {
        public List<StuInfo> SelectStu()
        {

            stuInfoDAL stuDao = new stuInfoDAL();

            List<StuInfo> Stulist = new List<StuInfo>();
            Stulist = stuDao.SelectStu();
            return Stulist;
        }
        public List<StuInfo> SelectStu(string search)
        {

            stuInfoDAL stuDao = new stuInfoDAL();

            List<StuInfo> Stulist = new List<StuInfo>();
            Stulist = stuDao.SelectStu(search);
            return Stulist;
        }
        public int DeleteById(int ID)
        {
            stuInfoDAL studao = new stuInfoDAL();
            return studao.DeleteById(ID);
        }
        public int UpdateById(int ID,StuInfo stu)
        {
            stuInfoDAL studao = new stuInfoDAL();
            return studao.UpdateById(ID,stu);
        }
        public int Insert(StuInfo stu)
        {
            stuInfoDAL studao = new stuInfoDAL();
            return studao.Insert(stu);
        }
    }
}
