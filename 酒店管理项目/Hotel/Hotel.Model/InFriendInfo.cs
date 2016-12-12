using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
   public class InFriendInfo
    {
        /// <summary>
        /// 入住单号
        /// </summary>
        public string in_number { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string c_name { get; set; }
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
        /// 电话号码
        /// </summary>
        public string C_Phone { get; set; }
        /// <summary>
        /// 客户性别
        /// </summary>
        public string c_sex { get; set; }
       /// <summary>
       /// 房间号
       /// </summary>
        public string RoomId { get; set; }
        public InFriendInfo() { }
        public InFriendInfo(string number,string name,string zjtype,string zjnumber, string address,string phone,string roomid,string sex) 
        {
            this.c_address = address;
            this.c_name = name;
            this.zj_type = zjtype;
            this.zj_number = zjnumber;
            this.c_address = address;
            this.C_Phone = phone;
            this.RoomId = roomid;
            this.c_sex = sex;
        }


       
    }
}
