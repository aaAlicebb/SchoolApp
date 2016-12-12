using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Hotel.DBHelper;
using Hotel.Model;
using System.Collections;
namespace Hotel.DAL
{
    public class RoomOperaDAL
    {
       
        public RoomOperaDAL() { }
        SqlHelper sql = new SqlHelper();
        /// <summary>
        /// 房间加载
        /// </summary>
        /// <returns></returns>
        public List<RoomInfo> RoomLode()
        {
            string cmds = "select * from RoomInfo";
            SqlDataReader reader = sql.ExecuteReader(cmds, null, null);
            List<RoomInfo> list = new List<RoomInfo>();
            while (reader.Read())
            {
                RoomInfo room = new RoomInfo();
                room.r_id = (int)reader["RoomId"];
                room.r_type = reader["RoomType"].ToString();
                room.r_state = reader["RoomState"].ToString();
                room.r_price = (decimal)reader["RoomPrice"];
                room.r_remark = reader["RoomRemark"].ToString();
                room.r_bed = (int)reader["RoomBed"];
                room.phone = reader["RoomPhone"].ToString();
                room.r_floatid = (int)reader["RoomFloatId"];
                list.Add(room);
            }
            if (list != null)
            {
                return list;
            }
            return null;
        }
        /// <summary>
        /// 通过楼层查找
        /// </summary>
        /// <returns></returns>
        public List<RoomInfo> selectByFloat(int floatid)
        {

            string cmds = "select * from RoomInfo where RoomFloatId=@floatid";
            string[] pra = { "@floatid" };
            string[] value = { floatid.ToString() };
            SqlDataReader reader = sql.ExecuteReader(cmds, pra, value);
            List<RoomInfo> list = new List<RoomInfo>();
            while (reader.Read())
            {
                RoomInfo room = new RoomInfo();
                room.r_id = (int)reader["RoomId"];
                room.r_type = reader["RoomType"].ToString();
                room.r_state = reader["RoomState"].ToString();
                room.r_floatid = int.Parse(reader["RoomFloatId"].ToString());
                list.Add(room);
            }
            if (list != null)
            {
                return list;
            }
            return null;
        }
        /// <summary>
        /// 通过房号查询
        /// </summary>
        /// <returns></returns>

        public RoomInfo selectById(int id)
        {
            try
            {
                string cmds = "select * from RoomInfo where RoomId=@roomid ";
                string[] pra = { "@roomid" };
                string[] value = { id.ToString() };
                SqlDataReader reader = sql.ExecuteReader(cmds, pra, value);
                RoomInfo room = new RoomInfo();
                while (reader.Read())
                {
                    room.r_id = (int)reader["RoomId"];
                    room.r_type = reader["RoomType"].ToString();
                    room.r_price = (decimal)reader["RoomPrice"];
                    room.r_remark = reader["RoomRemark"].ToString();
                    room.r_bed = (int)reader["RoomBed"];
                    room.r_floatid = int.Parse(reader["RoomFloatId"].ToString());
                    room.phone = reader["RoomPhone"].ToString();
                    room.r_state = reader["RoomState"].ToString(); ;
                }
                if (room != null)
                {
                    return room;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 通过姓名查询入住表里的房号，可能有相同姓名的用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns>int</returns>
        public ArrayList selectByName(string name)
        {
            string cmds = "select RoomId from InInfo where CName=@cName";
            string[] pra = { "@cName" };
            string[] value = { name };
            SqlDataReader reader = sql.ExecuteReader(cmds, pra, value);
            ArrayList list = new ArrayList();
            while (reader.Read())
            {
                int roomid;
                roomid = int.Parse(reader["RoomId"].ToString());
                list.Add(roomid);
            }
            if (list != null)
            {
                return list;
            }
            return null;
        }
        /// <summary>
        /// 查找各种类型的数量
        /// </summary>
        /// <returns></returns>
        public int SelectByState(int stateid)
        {
            string cmds = "select count(*) from RoomInfo where RoomState=@state";
            string[] pra = { "@state" };
            string[] value = { stateid.ToString() };
            int count = (int)sql.ExecuteScalar(cmds, pra, value);
            return count;
        }
        /// <summary>
        /// 查找通过房间状态和类型超找房间数
        /// </summary>
        /// <returns></returns>
        public int StlectByStateAndTape(int stateid, string roomtype)
        {
            string cmds = "select count(*) from RoomInfo where RoomState=@state and RoomType=@roomtape ";
            string[] pra = { "@state", "@roomtape" };
            string[] value = { stateid.ToString(), roomtype };
            int count = (int)sql.ExecuteScalar(cmds, pra, value);
            return count;
        }
        /// <summary>
        /// 通过id将房间置净
        /// </summary>
        /// <returns></returns>
        public int OpertState(string roomid) 
        {
            string cmds = "update RoomInfo set RoomState='0' where RoomId=@roomid";
            string[] pra = { "@roomid" };
            string[] value = { roomid.ToString() };
            int count = (int)sql.ExecuteNoneQuery(cmds,pra,value);
            return count;
        }
        /// <summary>
        /// 通过id将房间置为预订
        /// </summary>
        /// <returns></returns>
        public int OpertStateYd(string roomid)
        {
            string cmds = "update RoomInfo set RoomState='3' where RoomId=@roomid";
            string[] pra = { "@roomid" };
            string[] value = { roomid.ToString() };
            int count = (int)sql.ExecuteNoneQuery(cmds, pra, value);
            return count;
        }
        /// <summary>
        /// 房间增添操作，查看该房间是否已存在
        /// </summary>
        /// <returns></returns>
        public int PdRoomIdExist(int roomid) 
        {
            string cmds = "select count(*) from RoomInfo where RoomId=@roomid";
            string[] pra = { "@roomid" };
            string[] value = { roomid.ToString() };
            int count = (int)sql.ExecuteScalar(cmds,pra,value);
            return count;
        }
        //添加房间
        public int Insert(RoomInfo room)
        {
            string cdtext = "insert into RoomInfo (RoomId,RoomType,RoomBed,RoomFreeBed,RoomPrice,RoomRemark,RoomState,RoomFloatId,RoomPhone) values (@RoomId,@RoomType,@RoomBed,@RoomFreeBed,@RoomPrice,@RoomRemark,@RoomState,@RoomFloatId,@RoomPhone)";
            string[] pra = {"@RoomId","@RoomType","@RoomBed","@RoomFreeBed","@RoomPrice","@RoomRemark","@RoomState","@RoomFloatId","@RoomPhone" }; 
            object[] value = { room.r_id, room.r_type, room.r_bed,room.freebed, room.r_price,room.r_remark, room.r_state,room.r_floatid,room.phone };
            int count = sql.ExecuteNoneQuery(cdtext, pra, value);
            return count;
        }
        //修改
        public int Update(RoomInfo room,int id)
        {
            string cdtext = "update RoomInfo set RoomId=@RoomId,RoomType=@RoomType,RoomBed=@RoomBed,RoomPrice=@RoomPrice,RoomRemark=@RoomRemark,RoomPhone=@phone,RoomFloatId=@RoomFloat where RoomId=@Id";
            string[] pra = { "@RoomId", "@RoomType", "@RoomBed", "@RoomPrice", "@RoomRemark", "@phone", "@RoomFloat","Id" };
            object[] value = { room.r_id, room.r_type, room.r_bed, room.r_price, room.r_remark, room.phone,room.r_floatid,id };
            int count = sql.ExecuteNoneQuery(cdtext, pra, value);
            return count;
        }
        //删除
        public int Delete(int id)
        {
            string cdtext = "delete from RoomInfo where RoomId=@RoomId";
            string[] pra = { "@RoomId" };
            object[] value = { id.ToString() };
            int count = sql.ExecuteNoneQuery(cdtext, pra, value);
            return count;
        }
        /// <summary>
        /// 将房间状态变为入住
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public int OpertStateIN(string roomid)
        {
            string cmds = "update RoomInfo set RoomState='1' where RoomId=@roomid";
            string[] pra = { "@roomid" };
            string[] value = { roomid.ToString() };
            int count = (int)sql.ExecuteNoneQuery(cmds, pra, value);
            return count;
        }
        /// <summary>
        /// 将房间状态变为脏房
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public int OpertStateZang(string roomid)
        {
            string cmds = "update RoomInfo set RoomState='2' where RoomId=@roomid";
            string[] pra = { "@roomid" };
            string[] value = { roomid.ToString() };
            int count = (int)sql.ExecuteNoneQuery(cmds, pra, value);
            return count;
        }
        /// <summary>
        /// 通过房间类型和状态查找。
        /// </summary>
        /// <returns></returns>
        public List<RoomInfo> selectByStateAndRoomType(string roomtype, string state)
        {
            string cmds = "select * from RoomInfo where RoomType=@type and RoomState=@state";
            string[] pra = { "@type", "@state" };
            string[] value = { roomtype, state };
            SqlDataReader reader = sql.ExecuteReader(cmds, pra, value);
            List<RoomInfo> list = new List<RoomInfo>();
            while (reader.Read())
            {
                RoomInfo room = new RoomInfo();
                room.r_id = (int)reader["RoomId"];
                room.r_type = reader["RoomType"].ToString();
                room.r_state = reader["RoomState"].ToString();
                room.r_floatid = int.Parse(reader["RoomFloatId"].ToString());
                list.Add(room);
            }
            if (list != null)
            {
                return list;
            }
            return null;
        }
        /// <summary>
        /// 通过房间状态查找。
        /// </summary>
        /// <returns></returns>
        public List<RoomInfo> selectByState(string state)
        {
            string cmds = "select * from RoomInfo where RoomState=@state";
            string[] pra = { "@state" };
            string[] value = { state };
            SqlDataReader reader = sql.ExecuteReader(cmds, pra, value);
            List<RoomInfo> list = new List<RoomInfo>();
            while (reader.Read())
            {
                RoomInfo room = new RoomInfo();
                room.r_id = (int)reader["RoomId"];
                room.r_type = reader["RoomType"].ToString();
                room.r_state = reader["RoomState"].ToString();
                room.r_floatid = int.Parse(reader["RoomFloatId"].ToString());
                list.Add(room);
            }
            if (list != null)
            {
                return list;
            }
            return null;
        }
        /// <summary>
        /// 通过房间类型查找
        /// </summary>
        /// <param name="roomtype"></param>
        /// <returns></returns>
        public List<RoomInfo> selectByType(string roomtype)
        {
            string cmds = "select * from RoomInfo where RoomType=@type";
            string[] pra = { "type" };
            string[] value = { roomtype };
            SqlDataReader reader = sql.ExecuteReader(cmds, pra, value);
            List<RoomInfo> list = new List<RoomInfo>();
            while (reader.Read())
            {
                RoomInfo room = new RoomInfo();
                room.r_id = (int)reader["RoomId"];
                room.r_type = reader["RoomType"].ToString();
                room.r_state = reader["RoomState"].ToString();
                room.r_floatid = int.Parse(reader["RoomFloatId"].ToString());
                list.Add(room);
            }
            if (list != null)
            {
                return list;
            }
            return null;
        }
        /// <summary>
        /// 通过房间号码查找。
        /// </summary>
        /// <returns></returns>

        public RoomInfo selecByRoomId() 
        {
            string cmds = "select * from RoomInfo";
            SqlDataReader reader = sql.ExecuteReader(cmds, null, null);
            if (reader.Read())
            {
                RoomInfo room = new RoomInfo();
                room.r_id = (int)reader["RoomId"];
                room.r_type = reader["RoomType"].ToString();
                room.r_state = reader["RoomState"].ToString();
                room.r_price = (decimal)reader["RoomPrice"];
                room.r_remark = reader["RoomRemark"].ToString();
                room.r_bed = (int)reader["RoomBed"];
                room.phone = reader["RoomPhone"].ToString();
                room.r_floatid = (int)reader["RoomFloatId"];
                return room;
            }
            else 
            {
                return null;
            }
        }



    }
}
