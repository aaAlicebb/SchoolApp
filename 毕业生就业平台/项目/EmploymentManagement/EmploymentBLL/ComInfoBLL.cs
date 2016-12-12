using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployementDAL;
using EmployementMODEL;

namespace EmploymentBLL
{
   public class ComInfoBLL
    {
        /// <summary>
        /// 改变头像根据教师工号
        /// </summary>
        /// <returns></returns>
        public int updateComImg(byte[] img, string id)
        {
            ComInfoDAL dal = new ComInfoDAL();
            return dal.updateComImg(img,id);
        }
        public int InsertComInfo(ComInfo com)
        {
            ComInfoDAL dal = new ComInfoDAL();
            return dal.InsertComInfo(com);
        }
        /// <summary>
        /// 加入登录信息
        /// </summary>
        /// <returns></returns>
        public int InsertComLogn(ComLoginMes mes)
        {
            ComInfoDAL dal = new ComInfoDAL();
            return dal.InsertComLogn(mes);
        }
        /// <summary>
        /// 查询企业信息
        /// </summary>
        /// <returns></returns>
        public ComInfo SelectComInfoByID(string id)
        {
            ComInfoDAL dal = new ComInfoDAL();
            return dal.SelectComInfoByID(id);
        }
        /// <summary>
        /// 修改企业信息
        /// </summary>
        /// <returns></returns>
        public int alterComInfo(ComInfo com)
        {
            ComInfoDAL dal = new ComInfoDAL();
            return dal.alterComInfo(com);

        }
    }
}
