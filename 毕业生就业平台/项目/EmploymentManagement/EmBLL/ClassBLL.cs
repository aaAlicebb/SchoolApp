using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmModel;
using EmDALL;
namespace EmBLL
{
    public class ClassBLL
    {
        public List<ClassInfo> SelectStu()
        {

            ClassInfoDAL claDao = new ClassInfoDAL();

            List<ClassInfo> Clalist = new List<ClassInfo>();
            Clalist = claDao.SelectStu();
            return Clalist;
        }
        public int DeleteById(int ID)
        {
            ClassInfoDAL claDao = new ClassInfoDAL();
            return claDao.DeleteById(ID);
        }
        public int UpdateById(ClassInfo cla)
        {
            ClassInfoDAL claDao = new ClassInfoDAL();
            return claDao.UpdateById(cla);
        }
        public int Insert(ClassInfo cla)
        {
            ClassInfoDAL claDao = new ClassInfoDAL();
            return claDao.Insert(cla);
        }
    }
}
