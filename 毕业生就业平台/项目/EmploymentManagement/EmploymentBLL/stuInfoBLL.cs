using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployementDAL;
using EmployementMODEL;
namespace EmploymentBLL
{
   public class stuInfoBLL
    {
        /// <summary>
        /// 方法用于个人界面图片传输
        /// </summary>
        /// <param name="stuId"></param>
        /// <returns></returns>
        public byte[] tpcz(string stuId)
        {
            StuInfoDAL dal = new StuInfoDAL();
            return dal.tpcz(stuId);
        }
       /// <summary>
       /// 通过学号查询学生信息
       /// </summary>
       /// <returns></returns>
        public StuInfo selectByStuID(string id) 
        {
             StuInfoDAL dal=new StuInfoDAL();
             return dal.selectStuById(id);
        }
        /// <summary>
        /// 学生个人中心界面修改信息
        /// </summary>
        /// <returns></returns>
        public int updateStuMes(StuInfo Stu)
        {
            StuInfoDAL dal = new StuInfoDAL();
            return dal.updateStuMes(Stu);
        }
        /// <summary>
        /// 改变头像根据学号
        /// </summary>
        /// <returns></returns>
        public int updateStuImg(byte[] img, string id)
        {
            StuInfoDAL dal = new StuInfoDAL();
            return dal.updateStuImg(img,id);
        }
    }
}
