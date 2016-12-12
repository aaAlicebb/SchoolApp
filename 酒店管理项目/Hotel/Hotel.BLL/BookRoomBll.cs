using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Hotel.Model;
using Hotel.DAL;
using System.Collections;
namespace Hotel.BLL
{
    public class BookRoomBll
    {
        public OpResult enroll(bookRoomInfo customer)//预定
        {

            BookInfoDAL HotleCustomer = new BookInfoDAL();
            bookRoomInfo tempCustomer = HotleCustomer.SelectByc_zjh(customer.zj_number);
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
        public List<tempInfo> resarchRoomInfo(string r_type)
        {
            tempInfo roomInfo = new tempInfo();
            InInfoDAL rooms = new InInfoDAL();
            List<tempInfo> room = rooms.selectRoomInfo(r_type,"0");
            return room;

        }
        public ArrayList resarchRoomtype()
        {
            //RoomInfo roomInfo = new RoomInfo();
            BookInfoDAL rooms = new BookInfoDAL();
            ArrayList aa = rooms.selectRoomtype();
            return aa;

        }
        public int shanchu(int roomID)//删除T_temp选中行
        {
            BookInfoDAL dao = new BookInfoDAL();
            int Bdelete = dao.deletTemInfo(roomID);
            return Bdelete;
        }
        public int insertTemp(tempInfo info)//向T_temp插入数据
        {
            BookInfoDAL dao = new BookInfoDAL();
            tempInfo temp = new tempInfo();
            int Binsert = dao.insertTemInfo(info);
            return Binsert;
        }
        public int updateTem(int roomID)//更改为已住
        {
            BookInfoDAL dao = new BookInfoDAL();
            int updateInfo = dao.updateRoomState1(roomID);
            return updateInfo;

        }
        public int updateTem1(int roomID)//更改为空
        {
            BookInfoDAL dao = new BookInfoDAL();
            int updateInfo = dao.updateRoomState(roomID);
            return updateInfo;

        }
        public int updateTem2(int roomID)//更改为预定
        {
            BookInfoDAL dao = new BookInfoDAL();
            int updateInfo = dao.updateRoomState(roomID);
            return updateInfo;

        }
        public int countRoom(string roomType)
        {
            BookInfoDAL dao = new BookInfoDAL();
            int count = dao.selectRoomCount(roomType);
            return count;
        }
        public int moreRoom(bookRoomInfo customers)
        {
            BookInfoDAL dao = new BookInfoDAL();
            int moreRooms = dao.InsertMoreRoom(customers);
            return moreRooms;
        }
        public int NewTem()//刷新T_temp
        {
            BookInfoDAL dao = new BookInfoDAL();
            int counts = dao.updateTem();
            return counts;
        }
        public int deleTem()//删除T_temp
        {
            BookInfoDAL dao = new BookInfoDAL();
            int counts = dao.deleteTemp();
            return counts;
        }
    }
}
