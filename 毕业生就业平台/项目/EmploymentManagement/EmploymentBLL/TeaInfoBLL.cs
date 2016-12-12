using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployementMODEL;
using EmployementDAL;

namespace EmploymentBLL
{
   public class TeaInfoBLL
    {
       /// <summary>
       /// 用于个人图片传输
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public byte[] tpcz(string id) 
       {
           TeaInfoDAL bll = new TeaInfoDAL();
           return bll.tpcz(id);
       }
       /// <summary>
       /// 通过工号查询教师信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public TeaInfo selectById(string id)
       {
           TeaInfoDAL dal = new TeaInfoDAL();
           return dal.selectById(id);
       }

       /// <summary>
       /// 改变头像根据教师工号
       /// </summary>
       /// <returns></returns>
       public int updateTeaImg(byte[] img, string id)
       {
           TeaInfoDAL dal = new TeaInfoDAL();
           return dal.updateTeaImg(img,id);
       }
       /// <summary>
       /// 改变教师表信息
       /// </summary>
       /// <param name="tea"></param>
       /// <returns></returns>
       public int upDateTeaInfoMes(TeaInfo tea)
       {
           TeaInfoDAL dal = new TeaInfoDAL();
           return dal.upDateTeaInfoMes(tea);
       }
    }
}
