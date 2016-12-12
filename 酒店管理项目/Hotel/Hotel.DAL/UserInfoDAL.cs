using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.DBHelper;
using System.Data;
using System.Data.SqlClient;


namespace Hotel.DAL
{
   public class UserInfoDAL
    {
        SqlHelper sql = new SqlHelper();
        public UserInfoDAL() { }
        public UserInfo Login(string id) 
        {
            string cmds = "select * from UserInfo where UserAccount=@UserName";
            string[] pra = { "@UserName" };
            string[] value = { id.ToString() };
            SqlDataReader reader = sql.ExecuteReader(cmds, pra, value);
            UserInfo user=new UserInfo();
            while(reader.Read())
            {
                user.UserName = reader["UserAccount"].ToString();
                user.UserPwd = reader["UserPwd"].ToString();
                user.UserType = reader["UserType"].ToString();
                return user;
            }
            return null;
        }
       /// <summary>
       /// 查询所有
       /// </summary>
       /// <returns></returns>
        public List<UserInfo> selectAll() 
        {
            string cmd = "select * from UserInfo";
            SqlDataReader reader = sql.ExecuteReader(cmd,null,null);
            List<UserInfo> list = new List<UserInfo>();
            while(reader.Read())
            {
                UserInfo user = new UserInfo();
                user.UserName = reader["UserAccount"].ToString();
                user.UserPwd = reader["UserPwd"].ToString();
                user.UserType = reader["UserType"].ToString();
                user.UserBM = reader["UserBM"].ToString();
                list.Add(user);
            }
            if (list != null)
            {
                return list;
            }
            else 
            {
                return null;
            }
        }
       /// <summary>
        /// 通过账户名查询
       /// </summary>
       /// <returns></returns>
        public UserInfo selectById(string account) 
        {
            string str = "select * from UserInfo where UserAccount=@account";
            string[] pra = {"@account" };
            string[] value = {account };
            SqlDataReader reader = sql.ExecuteReader(str,pra,value);
            UserInfo user = new UserInfo();
            while(reader.Read())
            {
                
                user.UserName = reader["UserAccount"].ToString();
                user.UserPwd = reader["UserPwd"].ToString();
                user.UserType = reader["UserType"].ToString();
                user.UserBM = reader["UserBM"].ToString();
            }
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 添加用户，查看该用户是否已存在
        /// </summary>
        /// <returns></returns>
        public int userExist(UserInfo user)
        {
            string cmds = "select count(*) from UserInfo where UserAccount=@UserAccount";
            string[] pra = { "@UserAccount" };
            string[] value = { user.UserName};
            int count = (int)sql.ExecuteScalar(cmds, pra, value);
            return count;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        /// 
       public int Insert(UserInfo user)
        {
            string cdt = "insert into UserInfo (UserAccount,UserPwd,UserType,UserBM) values (@UserAccount,@UserPwd,@UserType,@UserBM)";
            string[] pra = { "@UserAccount", "@UserPwd", "@UserType", "@UserBM" };
           object[] values = { user.UserName, user.UserPwd, user.UserType, user.UserBM };
           int count = sql.ExecuteNoneQuery(cdt, pra, values);
           return count;
        }
       /// <summary>
       /// 更改用户
       /// </summary>
       /// <returns></returns>
       /// 
       public int Update(UserInfo user)
       {
           string cdt = "update  UserInfo set UserAccount=@UserAccount,UserPwd=@UserPwd,UserType=@UserType,UserBM=@UserBM where UserAccount=@UserAccount";
           string[] pra = { "@UserAccount", "@UserPwd", "@UserType", "@UserBM" };
           object[] values = { user.UserName, user.UserPwd, user.UserType, user.UserBM };
           int count = sql.ExecuteNoneQuery(cdt, pra, values);
           return count;
       }
       /// <summary>
       /// 删除用户
       /// </summary>
       /// <returns></returns>
       /// 
       public int Delect(UserInfo user)
       {
           string cdt = "delete from UserInfo where UserAccount=@UserAccount";
           string[] pra = { "@UserAccount"};
           object[] values = { user.UserName};
           int count = sql.ExecuteNoneQuery(cdt, pra, values);
           return count;
       }
    }
}
