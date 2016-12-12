using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    public class RoomInfo
    {
        /// <summary>
        /// 房间号
        /// </summary>
        public int r_id { get; set; }
        /// <summary>
        /// 房间类型
        /// </summary>
        public string r_type { get; set; }
        /// <summary>
        /// 床位数
        /// </summary>
        public int r_bed { get; set; }
        /// <summary>
        /// 剩余床位数
        /// </summary>
        public int freebed { get; set; }
        /// <summary>
        /// 房间状态
        /// </summary>
        public string r_state { get; set; }
        /// <summary>
        /// 房间单价
        /// </summary>
        public Decimal r_price { get; set; }
        /// <summary>
        /// 楼层号
        /// </summary>
        public int r_floatid { get; set; }
        /// <summary>
        /// 房间备注
        /// </summary>
        public String r_remark { get; set; }
        ///
        ///电话
        /// 
        public string phone { get; set; }

        public RoomInfo() { }
        public RoomInfo(int rid, int rbed, int freebeds, string rtype, string state, Decimal price, string remark, int rfloat,string phonnumber)
        {
            this.r_id = rid;
            this.r_bed = rbed;
            this.freebed = freebeds;
            this.r_type = rtype;
            this.r_state = state;
            this.r_price = price;
            this.r_remark = remark;
            this.r_floatid = r_floatid;
            this.phone = phonnumber;
        }

    }
}
