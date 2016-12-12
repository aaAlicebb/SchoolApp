using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.DAL;
namespace Hotel.BLL
{
   public class InFriendWithBLL
    {
        /// <summary>
        /// 通过单号和房号查询同住客人
        /// </summary>
        /// <returns></returns>
        public List<InFriendInfo> SelectInfo(string number, string id)
        {
            InFriendsWithDal DAL = new InFriendsWithDal();
            List<InFriendInfo> friend = new List<InFriendInfo>();
            friend=DAL.SelectInfo(number,id);
            return friend;
        }
        /// <summary>
        /// 通过单号和房号客人姓名删除同住客人
        /// </summary>
        /// <returns></returns>
        public int DeleteInfo(string number, string id, string name)
        {
            InFriendsWithDal DAL = new InFriendsWithDal();
           int count=DAL.DeleteInfo(number,id,name);
           return count;

        }
        /// <summary>
        /// 增加客人
        /// </summary>
        /// <param name="friend"></param>
        /// <returns></returns>
        public int insertInfo(InFriendInfo friend)
        {
            InFriendsWithDal DAL = new InFriendsWithDal();
            int count = DAL.insertInfo(friend);
            return count;
        }
        /// <summary>
        /// 通过单号和房号和证件号查询同住客人
        /// </summary>
        /// <returns></returns>
        public int SelectExist(string number, string id, string zjNumber)
        {
            InFriendsWithDal dal = new InFriendsWithDal();
            int count=dal.SelectExist(number,id,zjNumber);
            return count;
        }
    }
}
