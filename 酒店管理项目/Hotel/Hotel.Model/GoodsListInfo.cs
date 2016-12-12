using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    /// <summary>
    /// 仓库货品列表
    /// </summary>
    public class GoodsListInfo
    {
        /// <summary>
        /// 商品名
        /// </summary>
        public string Goods_Name { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public Decimal Goods_price { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int Goods_count { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string Goods_BM { get; set; }
        /// <summary>
        /// 商品简拼
        /// </summary>
        public string Goods_JP { get; set; }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string Goods_Unit { get; set; }
        public GoodsListInfo() { }
        public GoodsListInfo(String name, Decimal price, int count, string bm, string unit, string jp)
        {
            this.Goods_JP = jp;
            this.Goods_Name = name;
            this.Goods_price = price;
            this.Goods_count = count;
            this.Goods_BM = bm;
            this.Goods_Unit = unit;
        }
    }
}
