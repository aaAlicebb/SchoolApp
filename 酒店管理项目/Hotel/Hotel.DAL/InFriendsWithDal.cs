using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.DBHelper;
using Hotel.Model;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.DAL
{
   public class InFriendsWithDal
    {
       SqlHelper sql =new SqlHelper ();
       /// <summary>
       /// 通过单号和房号查询同住客人
       /// </summary>
       /// <returns></returns>
       public List<InFriendInfo> SelectInfo(string number,string id) 
       {
           string str = "select * from InFriendInfo where InNumber=@number and RoonId=@id";
           string[] pra = {"@number","@id"};
           string[] Value = {number,id };
           SqlDataReader reader = sql.ExecuteReader(str,pra,Value);
           List<InFriendInfo> list = new List<InFriendInfo>();
           while(reader.Read())
           {
               InFriendInfo friend = new InFriendInfo();
               friend.c_address = reader["InAddress"].ToString();
               friend.c_name = reader["CustName"].ToString();
               friend.C_Phone = reader["CusPhone"].ToString();
               friend.c_sex = reader["CusSex"].ToString();
               friend.in_number = reader["InNumber"].ToString();
               friend.zj_type = reader["ZJType"].ToString();
               friend.zj_number = reader["ZJNumber"].ToString();
               list.Add(friend);
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
       /// 通过单号和入住单号删除同住客人
       /// </summary>
       /// <returns></returns>
       public int DeleteInfo(string number, string id,string name)
       {
           string str = "delete from InFriendInfo where InNumber=@number and RoonId=@id and CustName=@name";
           string[] pra = { "@number", "@id","@name" };
           string[] Value = { number,id,name};
           int count = sql.ExecuteNoneQuery(str,pra,Value);
           return count;
           
       }
       /// <summary>
       /// 增加客人
       /// </summary>
       /// <param name="friend"></param>
       /// <returns></returns>
       public int insertInfo(InFriendInfo friend) 
       {
           string str = "insert into InFriendInfo(InNumber,CustName,CusPhone,ZJType,ZJNumber,InAddress,RoonId,CusSex) values(@Innumber,@CusName,@phone,@zjtype,@zjNumber,@InAddress,@Roomid,@CusSex)";
           string[] pra = { "@Innumber", "@CusName", "@phone", "@zjtype", "@zjNumber", "@InAddress", "@Roomid","CusSex" };
           string[] value = {friend.in_number,friend.c_name,friend.C_Phone,friend.zj_type,friend.zj_number,friend.c_address,friend.RoomId,friend.c_sex };
           int count = sql.ExecuteNoneQuery(str,pra,value);
           return count;
       }
       /// <summary>
       /// 通过单号和房号和证件号查询同住客人
       /// </summary>
       /// <returns></returns>
       public int SelectExist(string number, string id,string zjNumber)
       {
           string str = "select count(*) from InFriendInfo where InNumber=@number and RoonId=@id and ZJNumber=@zjnumber";
           string[] pra = { "@number", "@id", "@zjnumber" };
           string[] value = { number.ToString(), id.ToString(),zjNumber.ToString() };
           int count = (int)sql.ExecuteScalar(str,pra,value);
           return count;
       }
    }
}
