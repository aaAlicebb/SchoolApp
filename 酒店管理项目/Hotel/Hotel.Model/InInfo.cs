using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    public class InInfo
    {
        /// <summary>
        /// 入住单号
        /// </summary>
        public string in_number { get; set; }
        /// <summary>
        /// 房间号
        /// </summary>
        public int r_id { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string c_name { get; set; }
        /// <summary>
        /// 客户性别
        /// </summary>
        public bool c_sex { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string zj_type { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string zj_number { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string c_address { get; set; }
        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime c_intoday { get; set; }
        /// <summary>
        /// 预住天数
        /// </summary>
        public int c_aboutdays { get; set; }
        /// <summary>
        /// 押金
        /// </summary>
        public double foregift { get; set; }
        /// <summary>
        /// 离店时间
        /// </summary>
        public DateTime levatime { get; set; }
        /// <summary>
        /// 国籍
        /// </summary>
        public string nationality { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string C_Phone { get; set; }
        /// <summary>
        /// 入住类型
        /// </summary>
        public string InType { get; set; }
        /// <summary>
        /// 同住客人
        /// </summary>
        public string InFriend { get; set; }
        /// <summary>
        /// 入住人数
        /// </summary>
        public int C_inpeopleCount { get; set; }

        public RoomInfo Room { get; set; }
        /// <summary>
        /// 实际房价
        /// </summary>
        public double r_RelPrice { get; set; }

        public DateTime Inhour { set; get; }

        public DateTime leavehour { set; get; }
        public string roomState { get; set; }
        public InInfo() { }
        /// <summary>
        /// 各属性实例化
        /// </summary>
        /// <param name="number"></param>
        /// <param name="rid"></param>
        /// <param name="rtpn"></param>
        /// <param name="cname"></param>
        /// <param name="sexs"></param>
        /// <param name="zjtyoe"></param>
        /// <param name="zjnumber"></param>
        /// <param name="address"></param>
        /// <param name="intime"></param>
        /// <param name="aboutday"></param>
        /// <param name="yajin"></param>
        public InInfo(string number, int rid, string cname, bool sexs, string zjtyoe, string zjnumber, string address, DateTime intime, int aboutday, double yajin, DateTime lavetime, string nation, string phone, double relprice, string Intype, string infriend, int peoplecount, DateTime Inhour, DateTime leavehour, RoomInfo room, string roomState)
        {

            this.in_number = number;
            this.r_id = rid;
            this.c_name = cname;
            this.c_sex = sexs;
            this.zj_type = zjtyoe;
            this.zj_number = zjnumber;
            this.c_address = address;
            this.c_intoday = intime;
            this.c_aboutdays = aboutday;
            this.foregift = yajin;
            this.levatime = lavetime;
            this.nationality = nation;
            this.C_Phone = phone;
            this.r_RelPrice = relprice;
            this.InType = Intype;
            this.InFriend = infriend;
            this.C_inpeopleCount = peoplecount;
            this.Inhour = Inhour;
            this.leavehour = leavehour;
            this.Room = room;
            this.roomState = roomState;
        }

    }
}
