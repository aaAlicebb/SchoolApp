using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.DBHelper;
using System.Data.SqlClient;
using System.Collections;


namespace Hotel.DAL
{
    public class BookInfoDAL
    {
        SqlHelper db = new SqlHelper();
        public BookInfoDAL()
        {

        }
        public bookRoomInfo SelectByc_zjh(string zj_number)
        {
            string cmdText = "select * from T_bookRoom where ZjNumber=@zj_number";
            string[] param = { "@zj_number" };
            object[] values = { zj_number };
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            if (reader.Read())
            {
                bookRoomInfo customer = new bookRoomInfo();
                customer.c_name = reader["CName"].ToString();
                customer.c_sex = (bool)reader["CSex"];
                customer.c_intoday = (DateTime)reader["CInTime"];
                customer.c_address = reader["CAddress"].ToString();
                customer.c_aboutdays = (int)reader["InDays"];
                customer.foregift = float.Parse(reader["Foregift"].ToString());
                customer.zj_number = reader["ZjNumber"].ToString();
                customer.zj_type = reader["ZjType"].ToString();
                customer.C_inpeopleCount = (int)reader["InPeopleCount"];
                customer.C_Phone = reader["CPhone"].ToString();
                customer.levatime = (DateTime)reader["CLeveTime"];
                customer.InFriend = reader["InFriends"].ToString();
                customer.in_number = (int)reader["InNumber"];
                customer.InType = reader["InType"].ToString();
                customer.nationality = reader["CNationality"].ToString();
                customer.r_id = (int)reader["RoomId"];
                customer.r_RelPrice = (float)reader["RoomRelPrice"];
                customer.Inhour = reader["Inhour"].ToString();
                customer.leavehour = reader["leavehour"].ToString();
                return customer;

            }
            reader.Close();
            return null;
        }
        public int Insert(bookRoomInfo customer)//预定
        {
            string str = customer.c_intoday.ToShortDateString();
            string str1 = customer.levatime.ToShortDateString();
            string comText = "insert into T_bookRoom (InNumber,RoomId,CName,CSex,ZjType,ZjNumber,CAddress,CInTime,InDays,Foregift,CLeveTime,CNationality,CPhone,RoomRelPrice,InType,InFriends,InPeopleCount,Inhour,leavehour) values( @number, @rid, @cname,@sexs,@zjtyoe,@zjnumber, @address,@intime,@aboutday,@yajin,@lavetime,@nation,@phone,@relprice,@Intype,@infriend,@peoplecount,@Inhour,@leavehour)";
            string[] param = { "@number", "@rid", "@cname", "@sexs", "@zjtyoe", "@zjnumber", "@address", "@intime", "@aboutday", "@yajin", "@lavetime", "@nation", "@phone", "@relprice", "@Intype", "@infriend", "@peoplecount", "@Inhour", "@leavehour" };
            object[] values = { customer.in_number, customer.r_id.ToString(), customer.c_name, customer.c_sex, customer.zj_type, customer.zj_number, customer.c_address, str, customer.c_aboutdays, customer.foregift, str1, customer.nationality, customer.C_Phone, customer.r_RelPrice, customer.InType, customer.InFriend, customer.C_inpeopleCount, customer.Inhour, customer.leavehour };
            int row = db.ExecuteNoneQuery(comText, param, values);
            return row;

        }
        /// <summary>
        /// 查找房间数
        /// </summary>
        /// <param name="r_id"></param>
        /// <returns></returns>
        public int selectRoomCount(string roomType)//可选房间数
        {
            //string str = "Server=.;Initial Catalog=Hotel;uid=sa;pwd=123456;";
            //SqlConnection Conn = new SqlConnection(str);
            //Conn.Open();
            //string cmdText = "select count(roomId) from T_temp ";
            //SqlCommand comm = new SqlCommand(cmdText,Conn);
            string cmdText = "select count(roomId) from T_temp where roomType=@roomType";
            string[] param = { "@roomType" };
            object[] values = { roomType };
            int count = (int)db.ExecuteScalar(cmdText, param, values);
            if (count >= 1)
            {

                return count;
            }
            else
            {

                return 0;
            }


        }
        /// <summary>
        /// 查找房间类型
        /// </summary>
        /// <returns></returns>
        public ArrayList selectRoomtype()//查找房间类型
        {
            string str = "Server=.;Initial Catalog=hotels;uid=sa;pwd=123456;";
            SqlConnection Conn = new SqlConnection(str);
            Conn.Open();
            // Global.conn.Open();

            ArrayList array = new ArrayList();
            string cmdText = "select distinct RoomType from RoomInfo ";
            SqlCommand cmm = new SqlCommand(cmdText, Conn);
            SqlDataReader reader = cmm.ExecuteReader();
            while (reader.Read())
            {
                RoomInfo room = new RoomInfo();
                room.r_type = reader["RoomType"].ToString();
                array.Add(room.r_type);

            }
            reader.Close();
            if (array != null)
            {
                return array;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 显示房间信息
        /// </summary>
        /// <param name="r_id"></param>
        /// <returns></returns>

        public List<tempInfo> selectRoomInfo(string r_type)//显示房间信息
        {
            List<tempInfo> Array = new List<tempInfo>();
            string cmdText = "select * from  T_temp where roomType=@r_type";
            string[] param = { "@r_type" };
            object[] values = { r_type };
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            while (reader.Read())
            {
                tempInfo info = new tempInfo();
                info.roomId = (int)reader["roomId"];
                info.roomType = reader["roomType"].ToString();
                info.roomPrice = (decimal)reader["roomPrice"];
                info.roomState = reader["roomState"].ToString();
                Array.Add(info);
            }
            reader.Close();
            if (Array != null)
            {
                return Array;
            }
            else
            {

                return null;
            }
        }
        /// <summary>
        /// 向T_temp里插入数据
        /// </summary>
        /// <returns></returns>
        public int insertTemInfo(tempInfo info)
        {
            string cmdText = "insert into T_temp(roomId,roomType,roomPrice,roomState) values (@roomId,@roomType,@roomPrice,@roomState)";
            string[] param = { "@roomId", "@roomType", "@roomPrice", "@roomState" };
            object[] values = { info.roomId, info.roomType, info.roomPrice, info.roomState };
            int count = db.ExecuteNoneQuery(cmdText, param, values);
            if (count > 0)
            {
                return count;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 删除T_temp里的数据
        /// </summary>
        /// <returns></returns>
        public int deletTemInfo(int roomID)
        {
            string cmdText = "delete  from  T_temp where roomId=@roomID";
            string[] param = { "@roomID" };
            object[] values = { roomID };
            int count = db.ExecuteNoneQuery(cmdText, param, values);
            if (count > 0)
            {
                return count;
            }
            else
            {
                return 0;
            }
        }
        public int updateRoomState(int roomID)//更改房间状态为空
        {
            string cmdText = "update RoomInfo set RoomState='预定' where RoomId=@roomID"; ;
            string[] param = { "@roomID" };
            object[] values = { roomID };
            int count = db.ExecuteNoneQuery(cmdText, param, values);
            if (count > 0)
            {
                return count;
            }
            else
            {
                return 0;
            }
        }
        public int updateRoomState1(int roomID)//更改房间状态为已住
        {
            string cmdText = "update RoomInfo  set RoomState='已住' where RoomId=@roomID"; ;
            string[] param = { "@roomID" };
            object[] values = { roomID };
            int count = db.ExecuteNoneQuery(cmdText, param, values);
            if (count > 0)
            {
                return count;
            }
            else
            {
                return 0;
            }
        }
        public int updateRoomState2(int roomID)//更改房间状态为预定
        {
            string cmdText = "update RoomInfo  setRoomState='预定' where RoomId=@roomID"; ;
            string[] param = { "@roomID" };
            object[] values = { roomID };
            int count = db.ExecuteNoneQuery(cmdText, param, values);
            if (count > 0)
            {
                return count;
            }
            else
            {
                return 0;
            }
        }
        public int InsertMoreRoom(bookRoomInfo customers)//添加多间房
        {
            string str = customers.c_intoday.ToShortDateString();
            string str1 = customers.levatime.ToShortDateString();
            string comText = "insert into InInfo(InNumber,RoomId,CName,CSex,ZjType,ZjNumber,CAddress,CInTime,InDays,Foregift,CLeveTime,CNationality,CPhone,RoomRelPrice,InType,InFriends,InPeopleCount) values( @number, @rid, @cname,@sexs,@zjtyoe,@zjnumber, @address,@intime,@aboutday,@yajin,@lavetime,@nation,@phone,@relprice,@Intype,@infriend,@peoplecount)";
            string[] param = { "@number", "@rid", "@cname", "@sexs", "@zjtyoe", "@zjnumber", "@address", "@intime", "@aboutday", "@yajin", "@lavetime", "@nation", "@phone", "@relprice", "@Intype", "@infriend", "@peoplecount" };
            object[] values = { customers.in_number, customers.r_id.ToString(), customers.c_name, customers.c_sex, customers.zj_type, customers.zj_number, customers.c_address, str, customers.c_aboutdays, customers.foregift, str1, customers.nationality, customers.C_Phone, customers.r_RelPrice, customers.InType, customers.InFriend, customers.C_inpeopleCount };

            //object[] values = { customer.in_number, customer.r_id, customer.c_name, customer.c_sex, customer.zj_type, customer.zj_number, customer.c_address, customer.c_intoday, customer.c_aboutdays, customer.foregift, customer.levatime, customer.nationality, customer.C_Phone, customer.r_RelPrice, customer.InFriend, customer.C_inpeopleCount };
            //object[] values = { 1001, 1001, 1,1,1, 1, 1, "2014/2/2" ,1, 1,"2014/2/2",1,1,1, 1,1,1};
            int row = db.ExecuteNoneQuery(comText, param, values);
            return row;

        }
        public int updateTem()//刷新 T_temp表
        {
            string str = "Server=.;Initial Catalog=hotels;uid=sa;pwd=123456;";
            SqlConnection Conn = new SqlConnection(str);
            Conn.Open();
            string cmdText = "insert into T_temp select RoomId,RoomType,RoomPrice,RoomState from RoomInfo";
            SqlCommand comm = new SqlCommand(cmdText, Conn);
            int count = comm.ExecuteNonQuery();
            if (count > 0)
            {
                return count;
            }
            else
            {
                return 0;
            }
        }
        public int deleteTemp()
        {
            string str = "Server=.;Initial Catalog=hotels;uid=sa;pwd=123456;";
            SqlConnection Conn = new SqlConnection(str);
            Conn.Open();
            string cmdText = "delete  from T_temp ";
            SqlCommand comm = new SqlCommand(cmdText, Conn);
            int count = comm.ExecuteNonQuery();
            if (count > 0)
            {
                return count;
            }
            else
            {
                return 0;
            }
        }

    }
}
