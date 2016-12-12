using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Hotel.Model;
using Hotel.DAL;

namespace Hotel.BLL
{
     public class UserInfoBLL
    {
         /// <summary>
         /// 登录传值
         /// </summary>
         /// <param name="id"></param>
         /// <returns></returns>
         public UserInfo Login(string id) 
         {
         UserInfoDAL dal=new UserInfoDAL();
         UserInfo user = new UserInfo();
         user= dal.Login(id);
         return user;

         }
         public List<UserInfo> selectAll() 
         {
             UserInfoDAL dal = new UserInfoDAL();
             return dal.selectAll();
         }
         /// <summary>
         /// 通过账户名查询
         /// </summary>
         /// <returns></returns>
         public UserInfo selectById(string id)
         {
             UserInfoDAL dal = new UserInfoDAL();
             return dal.selectById(id);
         }
         /// <summary>
         ///添加
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         public int userAdd(UserInfo user)
         {
             UserInfoDAL dal = new UserInfoDAL();
             return dal.Insert(user);
         }
         /// <summary>
         ///修改
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         public int userUp(UserInfo user)
         {
             UserInfoDAL dal = new UserInfoDAL();
             return dal.Update(user);
         }
         /// <summary>
         ///删除
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         public int userDelect(UserInfo user)
         {
             UserInfoDAL dal = new UserInfoDAL();
             return dal.Delect(user);
         }
         /// <summary>
         /// 用户增加前判断用户是否已存在
         /// </summary>
         /// <param name="roomid"></param>
         /// <returns></returns>
         public int userExist(UserInfo user)
         {
             UserInfoDAL dal = new UserInfoDAL();
             return dal.userExist(user);
         }
    }
}
