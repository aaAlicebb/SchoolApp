using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Hotel.DAL;
using Hotel.Model;

namespace Hotel.BLL
{
    public class RoomInfoBLL
    {
        /// <summary>
        /// 房间加载
        /// </summary>
        /// <returns></returns>
        public List<RoomInfo> RoomLode()
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            List<RoomInfo> list = new List<RoomInfo>();
            return dal.RoomLode();
        }
        /// <summary>
        /// 按楼层查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<RoomInfo> SelectByFloat(int id)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            List<RoomInfo> room = new List<RoomInfo>();
            room = dal.selectByFloat(id);
            return room;
        }
        /// <summary>
        /// 通过房间号查询房间信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoomInfo selectByRoomId(int id)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            RoomInfo room = new RoomInfo();
            room = dal.selectById(id);
            return room;
        }
        /// <summary>
        /// 通过姓名查询房号
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ArrayList selectByName(string name)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            ArrayList list = new ArrayList();
            list = dal.selectByName(name);
            return list;

        }
        /// <summary>
        /// 通过状态ID查找各个状态的数量
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns></returns>
        public int SelectByState(int stateID)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            int c = dal.SelectByState(stateID);
            return c;
        }
        /// <summary>
        /// 查找通过房间状态和类型超找房间数
        /// </summary>
        /// <param name="state"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int StlectByStateAndTape(int state, string type)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            return dal.StlectByStateAndTape(state, type);
        }
        /// <summary>
        /// 将房间置净
        /// </summary>
        /// <returns></returns>
        public int opertState(string roomid) 
        {
           RoomOperaDAL dal=new RoomOperaDAL();
           return dal.OpertState(roomid);
        }
        /// <summary>
        /// 通过id将房间置为预订
        /// </summary>
        /// <returns></returns>
        public int OpertStateYd(string roomid)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            return dal.OpertStateYd(roomid);
        }
        /// <summary>
        /// 房间增加前判断该房间是否已存在
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public int PdRoomIdExist(int roomid) 
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            return dal.PdRoomIdExist(roomid);
        }
        /// <summary>
        ///添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public int RoomAdd(RoomInfo id)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            return dal.Insert(id);
        }
        /// <summary>
        ///更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public int RoomUpdate(RoomInfo id,int ids)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            return dal.Update(id,ids);
        }
        /// <summary>
        ///删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public int RoomDelet(int id)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            return dal.Delete(id);

        }
        /// <summary>
        /// 将房间变为住房
        /// </summary>
        /// <returns></returns>
        public int opertStateIn(string roomid)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            return dal.OpertStateIN(roomid);
        }
        /// <summary>
        /// 将房间变为脏房。
        /// </summary>
        /// <returns></returns>
        public int opertStateZang(string roomid)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            return dal.OpertStateZang(roomid);
        }
        /// <summary>
        /// 通过房间类型和状态查找。
        /// </summary>
        /// <returns></returns>
        public List<RoomInfo> selectByStateAndRoomType(string roomtype, string state)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            List<RoomInfo> list = new List<RoomInfo>();
            list = dal.selectByStateAndRoomType(roomtype, state);
            return list;
        }
        /// <summary>
        /// 通过房间状态查找。
        /// </summary>
        /// <returns></returns>
        public List<RoomInfo> selectByState(string state)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            List<RoomInfo> list = new List<RoomInfo>();
            list = dal.selectByState(state);
            return list;
        }
        /// <summary>
        /// 通过房间类型查找。
        /// </summary>
        /// <returns></returns>
        public List<RoomInfo> selectByType(string roomtype)
        {
            RoomOperaDAL dal = new RoomOperaDAL();
            List<RoomInfo> list = new List<RoomInfo>();
            list = dal.selectByType(roomtype);
            return list;
        }
    }
}
