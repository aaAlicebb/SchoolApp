using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.DAL;
using Hotel.Model;

namespace Hotel.BLL
{
    public class MemberBLL
    {
        public int count(string number)
        {
            MemberDAL dao = new MemberDAL();
            return dao.count(number);
        }
        /// <summary>
        /// 会员号查询
        /// </summary>
        /// <param name="VipId"></param>
        /// <returns></returns>
        public int VipIdCount(string VipId)
        {
            MemberDAL dao = new MemberDAL();
            return dao.VipIdCount(VipId);
        }
    }
}
