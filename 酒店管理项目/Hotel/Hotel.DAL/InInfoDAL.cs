using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using Hotel.DBHelper;
using Hotel.Model;

namespace Hotel.DAL
{
    public class InInfoDAL
    {
        SqlHelper db = new SqlHelper();
        public InInfoDAL()
        {

        }
        public InInfo SelectByc_zjh(string zj_number)
        {
            string cmdText = "select * from InInfo where ZjNumber=@zj_number";
            string[] param = { "@zj_number" };
            object[] values = { zj_number };
            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            if (reader.Read())
            {
                InInfo customer = new InInfo();
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
                customer.in_number = reader["InNumber"].ToString();
                customer.InType = reader["InType"].ToString();
                customer.nationality = reader["CNationality"].ToString();
                customer.r_id = (int)reader["RoomId"];
                customer.r_RelPrice = (double)reader["RoomRelPrice"];
                customer.leavehour = (DateTime)reader["leavehour"];
                customer.Inhour = (DateTime)reader["Inhour"];
                return customer;

            }
            reader.Close();
            return null;
        }
        public int Insert(InInfo customer)//登记
        {
            string str = customer.c_intoday.ToShortDateString();
            string str1 = customer.levatime.ToShortDateString();
            string comText = "insert into InInfo(InNumber,RoomId,CName,CSex,ZjType,ZjNumber,CAddress,CInTime,InDays,Foregift,CLeveTime,CNationality,CPhone,RoomRelPrice,InType,InFriends,InPeopleCount,Inhour,leavehour) values( @number, @rid, @cname,@sexs,@zjtyoe,@zjnumber, @address,@intime,@aboutday,@yajin,@lavetime,@nation,@phone,@relprice,@Intype,@infriend,@peoplecount,@Inhour,@leavehour)";
            string[] param = { "@number", "@rid", "@cname", "@sexs", "@zjtyoe", "@zjnumber", "@address", "@intime", "@aboutday", "@yajin", "@lavetime", "@nation", "@phone", "@relprice", "@Intype", "@infriend", "@peoplecount", "@Inhour", "@leavehour" };
            object[] values = { customer.in_number, customer.r_id.ToString(), customer.c_name, customer.c_sex, customer.zj_type, customer.zj_number, customer.c_address, str, customer.c_aboutdays, customer.foregift, str1, customer.nationality, customer.C_Phone, customer.r_RelPrice, customer.InType, customer.InFriend, customer.C_inpeopleCount, customer.Inhour, customer.leavehour };

            //object[] values = { customer.in_number, customer.r_id, customer.c_name, customer.c_sex, customer.zj_type, customer.zj_number, customer.c_address, customer.c_intoday, customer.c_aboutdays, customer.foregift, customer.levatime, customer.nationality, customer.C_Phone, customer.r_RelPrice, customer.InFriend, customer.C_inpeopleCount };
            //object[] values = { 1001, 1001, 1,1,1, 1, 1, "2014/2/2" ,1, 1,"2014/2/2",1,1,1, 1,1,1};
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

        public List<tempInfo> selectRoomInfo(string r_type,string state)//显示房间信息
        {
            List<tempInfo> Array = new List<tempInfo>();
            string cmdText = "select * from  T_temp where roomType=@r_type and roomState=@state";
            string[] param = { "@r_type","@state" };
            object[] values = { r_type,state };
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
            string cmdText = "delete from  T_temp where roomId=@roomID";
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
            string cmdText = "update RoomInfo set RoomState='0' where RoomId=@roomID"; ;
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
            string cmdText = "update RoomInfo  set RoomState='1' where RoomId=@roomID"; ;
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
            string cmdText = "update RoomInfo set RoomState='3' where RoomId=@roomID"; ;
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
        public int InsertMoreRoom(InInfo customers)//添加多间房
        {
            string str = customers.c_intoday.ToShortDateString();
            string str1 = customers.levatime.ToShortDateString();
            string comText = "insert into InInfo(InNumber,RoomId,CName,CSex,ZjType,ZjNumber,CAddress,CInTime,InDays,Foregift,CLeveTime,CNationality,CPhone,RoomRelPrice,InType,InFriends,InPeopleCount,Inhour,leavehour) values( @number, @rid, @cname,@sexs,@zjtyoe,@zjnumber, @address,@intime,@aboutday,@yajin,@lavetime,@nation,@phone,@relprice,@Intype,@infriend,@peoplecount,@Inhour,@leavehour)";
            string[] param = { "@number", "@rid", "@cname", "@sexs", "@zjtyoe", "@zjnumber", "@address", "@intime", "@aboutday", "@yajin", "@lavetime", "@nation", "@phone", "@relprice", "@Intype", "@infriend", "@peoplecount", "@Inhour", "@leavehour" };
            object[] values = { customers.in_number, customers.r_id.ToString(), customers.c_name, customers.c_sex, customers.zj_type, customers.zj_number, customers.c_address, str, customers.c_aboutdays, customers.foregift, str1, customers.nationality, customers.C_Phone, customers.r_RelPrice, customers.InType, customers.InFriend, customers.C_inpeopleCount, customers.Inhour, customers.leavehour };

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
        /// <summary>
        /// 李，查询通过房间号查询入住信息
        /// </summary>
        /// <returns></returns>
        public InInfo SelectByRoomId(string id) 
        {
            string cmd = "select * from InInfo where RoomId=@id";
            string[] pra = {"@id"};
            string[] Value = { id};
            SqlDataReader reader = db.ExecuteReader(cmd,pra,Value);
            InInfo inmes = new InInfo();
            if(reader.Read())
            {
                inmes.in_number =reader["InNumber"].ToString();
                inmes.c_name = reader["CName"].ToString();
                inmes.r_id = (int)reader["RoomId"];
                inmes.c_sex = (bool)reader["CSex"];
                inmes.c_aboutdays = (int)reader["InDays"];
                inmes.C_inpeopleCount = (int)reader["InPeopleCount"];
                inmes.zj_type = reader["ZJType"].ToString();
                inmes.zj_number = reader["ZJNumber"].ToString();
                inmes.c_address=reader["CAddress"].ToString();
                inmes.C_Phone=reader["CPhone"].ToString();
                inmes.nationality = reader["CNationality"].ToString();
                inmes.r_RelPrice = float.Parse(reader["RoomRelPrice"].ToString());
                inmes.foregift = float.Parse(reader["Foregift"].ToString());
                inmes.c_intoday = (DateTime)reader["CInTime"];
                inmes.levatime = (DateTime)reader["CLeveTime"];
                inmes.InType = reader["InType"].ToString();
                inmes.InFriend = reader["InFriends"].ToString();
                inmes.Inhour = (DateTime)reader["Inhour"];
                inmes.leavehour = (DateTime)reader["leavehour"];
                return inmes;
            }            
            else 
            {
                return null;
            }
        }
        /// <summary>
        /// 更改入住信息,李
        /// </summary>
        /// <returns></returns>
        public int UpdateInfo(InInfo customer)
        {
            string str = customer.c_intoday.ToShortDateString();
            string str1 = customer.levatime.ToShortDateString();
            string comText = "UPDATE InInfo SET CName=@name,CSex=@Sex,InDays=@indays,InPeopleCount=@peopleCount,ZjType=@zjType,ZjNumber=@ZjNumber,CAddress=@CAddress,CPhone=@CPhone,CNationality=@CNationality,RoomRelPrice=@RoomRelPrice,Foregift=@Foregift,CInTime=@CInTime,CLeveTime=@CLeveTime,InType=@InType,InFriends=@InFriends,leavehour=@leaveour,Inhour=@inhour WHERE RoomId=@RoomId";
            string[] param = { "@name", "@Sex", "@indays", "@peopleCount", "@zjType", "@ZjNumber", "@CAddress", "@CPhone", "@CNationality", "@RoomRelPrice", "@Foregift", "@CInTime", "@CLeveTime", "@InType", "@InFriends", "@RoomId", "@leaveour", "@inhour" };
            object[] values = { customer.c_name, customer.c_sex, customer.c_aboutdays, customer.C_inpeopleCount, customer.zj_type, customer.zj_number, customer.c_address, customer.C_Phone, customer.nationality, customer.r_RelPrice, customer.foregift, str, str1, customer.InType, customer.InFriend, customer.r_id, customer.leavehour, customer.Inhour };
            int row = db.ExecuteNoneQuery(comText, param, values);
            return row;
        }
        /// <summary>
        /// 结账删除入住表
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public int deleInfotByRoomid(string roomId)
        {
            string str = "delete from InInfo where RoomId=@roomid";
            string[] pra = { "@roomid" };
            string[] value = { roomId };
            int count = db.ExecuteNoneQuery(str, pra, value);
            return count;
        }
          /// <summary>
        /// 结账删除消费表
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public int deletSpanByRoomid(string roomId) 
        {
            string str = "delete from ConsumeInfo where RoomId=@roomid";
            string[] pra = { "@roomid" };
            string[] value = {roomId};
            int count = db.ExecuteNoneQuery(str, pra, value);
            return count;
        }
        /// <summary>
        /// 更改消费表房号
        /// </summary>
        /// <param name="yroomid"></param>
        /// <param name="nroomid"></param>
        /// <returns></returns>
        public int updateSpanById(string yroomid, string nroomid)
        {
            string str = "update ConsumeInfo set RoomId=@nroomid where RoomId=@roomid";
            string[] pra = { "@roomid", "@nroomid" };
            string[] value = { yroomid,nroomid };
            int count = db.ExecuteNoneQuery(str, pra, value);
            return count;
        }
        /// <summary>
        /// 查询入住信息
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 查询入住信息
        /// </summary>
        /// <returns></returns>
        public List<InInfo> SelectInfo()
        {
            string cmd = "select * from V_Check as a where exists(select 1 from V_Check where RoomId=a.RoomId group by RoomId having max(InNumber)=a.InNumber) and RoomState=1";
            string[] pra = { null };
            string[] Value = { null };
            SqlDataReader reader = db.ExecuteReader(cmd, null, null);
            List<InInfo> Inlist = new List<InInfo>();

            while (reader.Read())
            {
                InInfo inmes = new InInfo();
                inmes.r_id = (int)reader["RoomId"];
                inmes.foregift = float.Parse(reader["Foregift"].ToString());
                inmes.c_intoday = (DateTime)reader["CInTime"];
                inmes.c_name = reader["CName"].ToString();
                inmes.r_RelPrice = float.Parse(reader["RoomPrice"].ToString());
                inmes.in_number = reader["InNumber"].ToString();
                Inlist.Add(inmes);
            }
            if (Inlist != null)
            {
                return Inlist;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 通过单号查询一批信息，用于团队房右边的更改
        /// </summary>
        /// <returns></returns>
        public List<InInfo> selectByDanHao(string Danhao) 
        {
            string cmd = "SELECT *FROM dbo.InInfo INNER JOIN dbo.RoomInfo ON dbo.InInfo.RoomId = dbo.RoomInfo.RoomId and InNumber=@dannumber";
            string[] pra = { "@dannumber" };
            string[] Value = { Danhao };
            SqlDataReader reader = db.ExecuteReader(cmd, pra, Value);
            List<InInfo> list = new List<InInfo>();
            while (reader.Read())
            {
                InInfo inmes = new InInfo();
                inmes.in_number = reader["InNumber"].ToString();
                inmes.c_name = reader["CName"].ToString();
                inmes.r_id = (int)reader["RoomId"];
                inmes.c_sex = (bool)reader["CSex"];
                inmes.c_aboutdays = (int)reader["InDays"];
                inmes.C_inpeopleCount = (int)reader["InPeopleCount"];
                inmes.zj_type = reader["ZJType"].ToString();
                inmes.zj_number = reader["ZJNumber"].ToString();
                inmes.c_address = reader["CAddress"].ToString();
                inmes.C_Phone = reader["CPhone"].ToString();
                inmes.nationality = reader["CNationality"].ToString();
                inmes.r_RelPrice = float.Parse(reader["RoomRelPrice"].ToString());
                inmes.foregift = float.Parse(reader["Foregift"].ToString());
                inmes.c_intoday = (DateTime)reader["CInTime"];
                inmes.levatime = (DateTime)reader["CLeveTime"];
                inmes.InType = reader["InType"].ToString();
                inmes.InFriend = reader["InFriends"].ToString();
                inmes.Inhour = (DateTime)reader["Inhour"];
                inmes.leavehour = (DateTime)reader["leavehour"];
                RoomInfo room = new RoomInfo();
                room.r_type = reader["RoomType"].ToString();
                room.r_state = reader["RoomState"].ToString();
                inmes.Room = room;
                list.Add(inmes);
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
        /// 更改为团队入住
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        public int updateRoomState4(int roomID)//更改房间状态为团队入住
        {
            string cmdText = "update RoomInfo set RoomState='4' where RoomId=@roomID"; ;
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
        /// <summary>
        /// 更改为脏房
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        public int updateRoomStateZang(int roomID)//更改房间状态为预定
        {
            string cmdText = "update RoomInfo set RoomState='2' where RoomId=@roomID"; ;
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
        /// <summary>
        /// 通过单号和房间号查询入住信息，用于团队入住新增房间。
        /// </summary>
        /// <returns></returns>
        public InInfo selectByDanHaoandId(string Danhao,string roomid)
        {
            string cmd = "select * from InInfo where RoomId=@id and InNumber=@danhao";
            string[] pra = { "@id", "@danhao" };
            string[] Value = { roomid,Danhao};
            SqlDataReader reader = db.ExecuteReader(cmd,pra,Value);
            InInfo inmes = new InInfo();
            if (reader.Read())
            {
                inmes.in_number = reader["InNumber"].ToString();
                inmes.c_name = reader["CName"].ToString();
                inmes.r_id = (int)reader["RoomId"];
                inmes.c_sex = (bool)reader["CSex"];
                inmes.c_aboutdays = (int)reader["InDays"];
                inmes.C_inpeopleCount = (int)reader["InPeopleCount"];
                inmes.zj_type = reader["ZJType"].ToString();
                inmes.zj_number = reader["ZJNumber"].ToString();
                inmes.c_address = reader["CAddress"].ToString();
                inmes.C_Phone = reader["CPhone"].ToString();
                inmes.nationality = reader["CNationality"].ToString();
                inmes.r_RelPrice = float.Parse(reader["RoomRelPrice"].ToString());
                inmes.foregift = float.Parse(reader["Foregift"].ToString());
                inmes.c_intoday = (DateTime)reader["CInTime"];
                inmes.levatime = (DateTime)reader["CLeveTime"];
                inmes.InType = reader["InType"].ToString();
                inmes.InFriend = reader["InFriends"].ToString();
                inmes.Inhour = (DateTime)reader["Inhour"];
                inmes.leavehour = (DateTime)reader["leavehour"];
                return inmes;
            }
            else 
            {
                return null;
            }
        }
        public List<InInfo> SelectCheck(string CName, string spanno)
        {

            string cmdText = "select * from V_Check where CName=@CName and InNumber=@InNumber";
            string[] param = { "@CName", "@InNumber" };
            object[] values = { CName, spanno };

            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1; Persist Security Info=True;User ID=sa;Password=121314;";
            //conn.Open();

            List<InInfo> Checklist = new List<InInfo>();
            while (reader.Read())
            {
                InInfo Check = new InInfo();
                Check.r_id = Convert.ToInt32(reader["RoomId"].ToString());
                Check.c_name = reader["CName"].ToString();
                Check.InType = reader["InType"].ToString();
                Check.r_RelPrice = Convert.ToDouble(reader["RoomRelPrice"].ToString());
                Check.c_intoday = Convert.ToDateTime(reader["CInTime"].ToString());
                Check.foregift = Convert.ToDouble(reader["Foregift"].ToString());
                Check.roomState = reader["RoomState"].ToString();
                Checklist.Add(Check);

            }
            if (Checklist != null)
            {
                reader.Close();
                return Checklist;
            }
            reader.Close();
            return null;
        }
        public int count(string CName, string spanno)
        {
            //string cmdText = "select count(*) from InInfo";
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1;User ID=sa;Password=121314;";
            //conn.Open();
            string cmdText = "select count(*) from V_Check where CName=@CName and InNumber=@InNumber";
            string[] param = { "@CName", "@InNumber" };
            object[] values = { CName, spanno };

            int count = (int)db.ExecuteScalar(cmdText, param, values);
            return count;
        }
        /// <summary>
        /// 查剩余脏房数
        /// </summary>
        /// <param name="CName"></param>
        /// <param name="spanno"></param>
        /// <returns></returns>
        public int zangfangcount(string spanno)
        {
            //string cmdText = "select count(*) from InInfo";
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1;User ID=sa;Password=121314;";
            //conn.Open();
            string cmdText = "select count(*) from V_Check where InNumber=@InNumber and RoomState=2";
            string[] param = { "@InNumber" };
            object[] values = { spanno };

            int count = (int)db.ExecuteScalar(cmdText, param, values);
            return count;
        }
        /// <summary>
        /// 结账删除入住表
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public int deleInfotByRoomidAndSpanno(string roomId, string spanno)
        {
            string str = "delete from InInfo where RoomId=@roomid and InNumber=@InNumber";
            string[] pra = { "@roomid", "@InNumber" };
            string[] value = { roomId, spanno };
            int count = db.ExecuteNoneQuery(str, pra, value);
            return count;
        }
        public int selectInfotByRoomidAndSpanno(string roomId, string spanno)
        {
            string str = "select count(*) from InInfo where RoomId=@RoomId and InNumber=@InNumber";
            string[] pra = { "@RoomId", "@InNumber" };
            string[] value = { roomId, spanno };

            int count = (int)db.ExecuteScalar(str, pra, value);
            return count;
        }
        /// <summary>
        /// 查询房号的入住信息，用于预订入住的条数判断。李
        /// </summary>
        /// <returns></returns>
        public List<InInfo> selectIdCount(string id)
        {
            string cmd = "select * from InInfo where RoomId=@RoomId";
            string[] pra = { "@RoomId" };
            string[] value = { id };
            SqlDataReader reader = db.ExecuteReader(cmd, pra, value);
            List<InInfo> info = new List<InInfo>();
            while (reader.Read())
            {
                InInfo inmes = new InInfo();
                inmes.in_number = reader["InNumber"].ToString();//单号
                inmes.c_name = reader["CName"].ToString();//顾客姓名
                inmes.r_id = (int)reader["RoomId"];//房号
                inmes.c_sex = (bool)reader["CSex"];
                inmes.c_aboutdays = (int)reader["InDays"];
                inmes.C_inpeopleCount = (int)reader["InPeopleCount"];
                inmes.zj_type = reader["ZJType"].ToString();
                inmes.zj_number = reader["ZJNumber"].ToString();
                inmes.c_address = reader["CAddress"].ToString();
                inmes.C_Phone = reader["CPhone"].ToString();
                inmes.nationality = reader["CNationality"].ToString();
                inmes.r_RelPrice = float.Parse(reader["RoomRelPrice"].ToString());
                inmes.foregift = float.Parse(reader["Foregift"].ToString());
                inmes.c_intoday = (DateTime)reader["CInTime"];
                inmes.levatime = (DateTime)reader["CLeveTime"];
                inmes.InType = reader["InType"].ToString();
                inmes.InFriend = reader["InFriends"].ToString();
                inmes.Inhour = (DateTime)reader["Inhour"];
                inmes.leavehour = (DateTime)reader["leavehour"];
                info.Add(inmes);
            }
            if (info != null)
            {
                return info;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        ///查询此人是否入住过
        /// </summary>
        /// <returns></returns>
        public List<InInfo> selectInByNumber(string ZJNumber)
        {
            string cmd = "select top 1 * from InBaoInfo where ZJNumber=@ZJNumber order by InNumber";
            string[] pra = { "@ZJNumber" };
            string[] value = { ZJNumber };
            SqlDataReader reader = db.ExecuteReader(cmd, pra, value);
            List<InInfo> info = new List<InInfo>();
            if (reader.Read())
            {
                InInfo inmes = new InInfo();
                inmes.c_name = reader["CName"].ToString();//顾客姓名
                inmes.c_sex = (bool)reader["CSex"];
                inmes.c_aboutdays = (int)reader["InDays"];
                inmes.C_inpeopleCount = (int)reader["InPeopleCount"];
                inmes.zj_type = reader["ZJType"].ToString();
                inmes.zj_number = reader["ZJNumber"].ToString();
                inmes.c_address = reader["CAddress"].ToString();
                inmes.C_Phone = reader["CPhone"].ToString();
                inmes.nationality = reader["CNationality"].ToString();
                inmes.r_RelPrice = float.Parse(reader["RoomRelPrice"].ToString());
                inmes.foregift = float.Parse(reader["Foregift"].ToString());
                inmes.c_intoday = (DateTime)reader["CInTime"];
                inmes.levatime = (DateTime)reader["CLeveTime"];
                inmes.InType = reader["InType"].ToString();
                inmes.InFriend = reader["InFriends"].ToString();
                inmes.Inhour = (DateTime)reader["Inhour"];
                inmes.leavehour = (DateTime)reader["leavehour"];
                info.Add(inmes);
                return info;
            }         
            else
            {
                return null;
            }
        }
    }
}
