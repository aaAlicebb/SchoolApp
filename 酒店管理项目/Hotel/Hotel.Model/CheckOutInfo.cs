using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
   public class CheckOutInfo
    {
       /// <summary>
       /// 结账单号
       /// </summary>
       public string checkno { get; set; }
      
       /// <summary>
       /// 总金额
       /// </summary>
       public decimal to_monet { get; set; }
       /// <summary>
       /// 结算时间
       /// </summary>
       public DateTime checktime { get; set; }
       /// <summary>
       /// 房间号
       /// </summary>
       public decimal forgift { get; set; }
       /// <summary>
       /// 房间号
       /// </summary>
       public int RoomId { get; set; }
       /// <summary>
       /// 结账时间
       /// </summary>
       public DateTime times { get; set; }
       public CheckOutInfo() { }
       public CheckOutInfo(string checkno, Decimal money, DateTime times, int roomid, decimal forgift,DateTime time) 
       {
           this.checkno = checkno;
           this.to_monet = money;
           this.checktime = times;
           this.RoomId = roomid;
           this.forgift = forgift;
           times = time;
       }
    }
}
