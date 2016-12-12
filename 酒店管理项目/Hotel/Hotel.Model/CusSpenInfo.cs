using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
   public class CusSpenInfo
    {
       /// <summary>
       /// 消费单号
       /// </summary>
       public string span_no { get; set; }
       /// <summary>
       /// 商品名称
       /// </summary>
       public string Goods_name { get; set; }
       /// <summary>
       /// 商品单价
       /// </summary>
       public Decimal g_price { get; set; }
       /// <summary>
       /// 消费数量
       /// </summary>
       public string g_count { get; set; }
       /// <summary>
       /// 总金额
       /// </summary>
       public Decimal totolAmount { get; set; }
       /// <summary>
       /// 其它消费
       /// </summary>
       public Decimal OtherSpend { get; set; }
       /// <summary>
       /// 房号
       /// </summary>
       public int RoomId { get; set; }
       /// <summary>
       /// 入账时间
       /// </summary>
       public DateTime s_time { get; set; }
       /// <summary>
       /// 操作员
       /// </summary>
       public string operation { get; set;}
       /// <summary>
       /// 操作员
       /// </summary>
       public string s_name { get; set; }
     
     
       public CusSpenInfo() { }
       public CusSpenInfo(string spanno, string goodsname, Decimal price,string count, DateTime time, int roomid,decimal otherspend, Decimal amount, string operation,string customname)
      {
          this.span_no = spanno;
          this.Goods_name = goodsname;
          this.g_price = price;
          this.g_count = count;
          this.s_time = time;
          this.RoomId = roomid;
          this.OtherSpend = otherspend;
          this.totolAmount = amount;
          this.operation = operation;
          this.s_name = customname;
      }
    }
}
