using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    public class CheckInfo
    {
        /// <summary>
        /// 房间号
        /// </summary>
        public int r_id { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string c_name { get; set; }
        /// <summary>
        /// 入住类型
        /// </summary>
        public string InType { get; set; }
        /// <summary>
        /// 房间单价
        /// </summary>
        public Decimal roomPrice { get; set; }
        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime c_intoday { get; set; }
        /// <summary>
        /// 押金
        /// </summary>
        public Decimal foregift { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string roomState { get; set; }
        public CheckInfo(){}

        public CheckInfo(int id, string name, string InType, Decimal roomPrice, DateTime intoday, Decimal foregift, string roomState) 
        {
            this.r_id = id;
            this.c_name = name;
            this.InType = InType;
            this.roomPrice = roomPrice;
            this.c_intoday = intoday;
            this.foregift = foregift;
            this.roomState = roomState;
        }
    }
}
