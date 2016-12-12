using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.DAL;
using System.Collections;

namespace Hotel.BLL
{
    public class BLLcustomer
    {
        public OpResult enroll(InInfo customer)
        {

            InInfoDAL HotleCustomer = new InInfoDAL();
            InInfo tempCustomer = HotleCustomer.SelectByc_zjh(customer.zj_number);
            if (tempCustomer != null)
            {
                return OpResult.exist;
            }
            else
            {
                int count = HotleCustomer.Insert(customer);
                if (count == 1)
                {
                    return OpResult.yes;
                }
                else
                {
                    return OpResult.no;
                }
            }

        }
        public List<tempInfo> resarchRoomInfo(string r_type,string state)
        {
            tempInfo roomInfo = new tempInfo();
            InInfoDAL rooms = new InInfoDAL();
            List<tempInfo> room = rooms.selectRoomInfo(r_type,state);
            return room;

        }
        public ArrayList resarchRoomtype()
        {
            //RoomInfo roomInfo = new RoomInfo();
            InInfoDAL rooms = new InInfoDAL();
            ArrayList aa = rooms.selectRoomtype();
            return aa;

        }
        public int shanchu(int roomID)//删除T_temp选中行
        {
            InInfoDAL dao = new InInfoDAL();
            int Bdelete = dao.deletTemInfo(roomID);
            return Bdelete;
        }
        public int insertTemp(tempInfo info)//向T_temp插入数据
        {
            InInfoDAL dao = new InInfoDAL();
            tempInfo temp = new tempInfo();
            int Binsert = dao.insertTemInfo(info);
            return Binsert;
        }
        public int updateTem(int roomID)//更改为已住
        {
            InInfoDAL dao = new InInfoDAL();
            int updateInfo = dao.updateRoomState1(roomID);
            return updateInfo;

        }
        public int updateTem1(int roomID)//更改为空
        {
            InInfoDAL dao = new InInfoDAL();
            int updateInfo = dao.updateRoomState(roomID);
            return updateInfo;

        }
        public int updateTem2(int roomID)//更改为预定
        {
            InInfoDAL dao = new InInfoDAL();
            int updateInfo = dao.updateRoomState2(roomID);
            return updateInfo;

        }
        /// <summary>
        /// 置脏房
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        public int updateTemzang(int roomID)
        {
            InInfoDAL dao = new InInfoDAL();
            int updateInfo = dao.updateRoomStateZang(roomID);
            return updateInfo;

        }
        public int countRoom(string roomType)
        {
            InInfoDAL dao = new InInfoDAL();
            int count = dao.selectRoomCount(roomType);
            return count;
        }
        public int moreRoom(InInfo customers)
        {
            InInfoDAL dao = new InInfoDAL();
            int moreRooms = dao.InsertMoreRoom(customers);
            return moreRooms;
        }
        public int NewTem()//刷新T_temp
        {
            InInfoDAL dao = new InInfoDAL();
            int counts = dao.updateTem();
            return counts;
        }
        public int deleTem()//删除T_temp
        {
            InInfoDAL dao = new InInfoDAL();
            int counts = dao.deleteTemp();
            return counts;
        }
        /// <summary>
        /// 李，通过房间号查询入住信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InInfo selectByRooid(string id) 
        {
            InInfoDAL dal = new InInfoDAL();
            InInfo infomes = new InInfo();
            infomes= dal.SelectByRoomId(id);
            return infomes;
        }
        /// <summary>
        /// 更改入住信息
        /// </summary>
        /// <returns></returns>
        public int UpdateInfo(InInfo infomes) 
        {
            InInfoDAL dal = new InInfoDAL();
            return dal.UpdateInfo(infomes);
        }
        /// <summary>
        /// 不查询增加
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public OpResult enrollInsert(InInfo customer)
        {

            InInfoDAL HotleCustomer = new InInfoDAL();
            
                int count = HotleCustomer.Insert(customer);
                if (count == 1)
                {
                    return OpResult.yes;
                }
                else
                {
                    return OpResult.no;
                }
            

        }
        /// <summary>
        /// 结账删除入住表
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public int deleInfotByRoomid(string roomId)
        {
            InInfoDAL dal = new InInfoDAL();
            return dal.deleInfotByRoomid(roomId);
        }
        /// <summary>
        /// 结账删除消费表
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public int deletSpanByRoomid(string roomId)
        {
            InInfoDAL dal = new InInfoDAL();
            return dal.deletSpanByRoomid(roomId);
        }
        /// <summary>
        /// 更改消费者房号
        /// </summary>
        /// <param name="yroomid"></param>
        /// <param name="nroomid"></param>
        /// <returns></returns>
        public int updateSpanById(string yroomid, string nroomid) 
        {
            InInfoDAL dal = new InInfoDAL();
            return dal.updateSpanById(yroomid,nroomid);
        }
        /// <summary>
        /// 在住账单查询
        /// </summary>
        /// <returns></returns>
        public List<InInfo> SelectInfo()
        {
            InInfoDAL InDao = new InInfoDAL();

            List<InInfo> Inlist = new List<InInfo>();
            Inlist = InDao.SelectInfo();
            return Inlist;
        }
        /// <summary>
        /// 通过单号查询一批信息，用于团队房右边的更改.李
        /// </summary>
        /// <returns></returns>
        public List<InInfo> selectByDanHao(string Danhao)
        {
            List<InInfo> list = new List<InInfo>();
            InInfoDAL dal = new InInfoDAL();
            list=dal.selectByDanHao(Danhao);
            return list;
        }
        /// <summary>
        /// 更改为团队入住
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        public int updateRoomState4(int roomID)//更改房间状态为团队入住
        {
            InInfoDAL dao = new InInfoDAL();
            int updateInfo = dao.updateRoomState4(roomID);
            return updateInfo;
        }
        /// <summary>
        /// 通过单号和房间号查询入住信息，用于团队入住新增房间。
        /// </summary>
        /// <returns></returns>
        public InInfo selectByDanHaoandId(string Danhao, string roomid)
        {
            InInfoDAL dal = new InInfoDAL();
            InInfo room = new InInfo();
            room=dal.selectByDanHaoandId(Danhao, roomid);
            return room;
        }
        public List<InInfo> SelectCheck(string CName, string spanno)
        {
            InInfoDAL dao = new InInfoDAL();

            List<InInfo> Inlist = new List<InInfo>();
            Inlist = dao.SelectCheck(CName, spanno);
            return Inlist;
        }
        public int count(string CName, string spanno)
        {
            //string cmdText = "select count(*) from InInfo";
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1;User ID=sa;Password=121314;";
            //conn.Open();
            InInfoDAL dao = new InInfoDAL();
            return dao.count(CName, spanno);
        }
        /// <summary>
        /// 查询脏房数
        /// </summary>
        /// <param name="spanno"></param>
        /// <returns></returns>
        public int zangfangcount(string spanno)
        {

            InInfoDAL dao = new InInfoDAL();
            return dao.zangfangcount(spanno);
        }
        /// <summary>
        /// 单人结账删除入住表
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public int deleInfotByRoomidAndSpanno(string roomId, string spanno)
        {
            InInfoDAL dal = new InInfoDAL();
            return dal.deleInfotByRoomidAndSpanno(roomId, spanno);
        }
        public int selectInfotByRoomidAndSpanno(string roomId, string spanno)
        {
            InInfoDAL dal = new InInfoDAL();
            return dal.selectInfotByRoomidAndSpanno(roomId, spanno);
        }
        /// <summary>
        /// 查询房号的入住信息，用于预订入住的条数判断。李
        /// </summary>
        /// <returns></returns>
        public List<InInfo> selectIdCount(string id)
        {
            List<InInfo> info = new List<InInfo>();
            InInfoDAL dal = new InInfoDAL();
            info = dal.selectIdCount(id);
            return info;

        }
        public List<InInfo> selectInByNumber(string ZJNumber)
        {
            List<InInfo> info = new List<InInfo>();
            InInfoDAL dal = new InInfoDAL();
            info = dal.selectInByNumber(ZJNumber);
            return info;

        }
    }
}
