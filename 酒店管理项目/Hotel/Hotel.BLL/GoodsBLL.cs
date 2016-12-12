using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.BLL;
using System.Collections;
using Hotel.Model;
using Hotel.DAL;

namespace Hotel.BLL
{
    public class GoodsBLL
    {
        public int count()
        {
            GoodSlistDAL Goods = new GoodSlistDAL();
            return Goods.count();

        }
        public List<GoodsListInfo> SelectGoods()
        {
            GoodSlistDAL Goods = new GoodSlistDAL();

            List<GoodsListInfo> Goodslist = new List<GoodsListInfo>();
            Goodslist = Goods.SelectGoods();
            return Goodslist;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Update(GoodsListInfo good)
        {
            GoodSlistDAL goods= new GoodSlistDAL();
            int count = goods.Update(good);
            return count;
        }
        /// <summary>
        /// 更改退换数量
        /// </summary>
        /// <param name="good"></param>
        /// <param name="bcount"></param>
        /// <returns></returns>
        public int Updatecount(string good, int bcount)
        {
            GoodSlistDAL goods = new GoodSlistDAL();
            int count = goods.Updatecount(good, bcount);
            return count;
        }
       /// <summary>
       /// 编码查询
        /// <param name="user"></param>
        /// <returns></returns>
        public List<GoodsListInfo> SelectGoodsBM(string GoodsBM)
        {
            GoodSlistDAL dao = new GoodSlistDAL();
            List<GoodsListInfo> list = new List<GoodsListInfo>();
            list = dao.SelectGoodsBM(GoodsBM);

            if (list != null)
            {
                return list;
            }
            return null;

        }
        /// <summary>
        /// 简拼查询
        /// <param name="user"></param>
        /// <returns></returns>
        public List<GoodsListInfo> SelectGoodsJP(string GoodsJP)
        {
            GoodSlistDAL dao = new GoodSlistDAL();
            List<GoodsListInfo> list = new List<GoodsListInfo>();
            list = dao.SelectGoodsJP(GoodsJP);

            if (list != null)
            {
                return list;
            }
            return null;

        }
        /// <summary>
        /// 仓库物品增加
        /// </summary>
        /// <param name="LIST"></param>
        /// <returns></returns>
        public int GoodsAdd(GoodsListInfo list)
        {
            GoodSlistDAL dal = new GoodSlistDAL();
            int count = dal.GoodsAdd(list);
            return count;
        }
        /// <summary>
        /// 仓库物品删除
        /// </summary>
        /// <returns></returns>
        public int GoodsDelete(string BM)
        {
            GoodSlistDAL dal = new GoodSlistDAL();
            int count = dal.GoodsDelet(BM);
            return count;
        }
        /// <summary>
        /// 仓库物品通过编码查询是否存在
        /// </summary>
        /// <returns></returns>
        public int GoodsSelectByBMsingle(string BM)
        {
            GoodSlistDAL list = new GoodSlistDAL();
            return list.SelectGoodsBMSingel(BM);
        }
        /// <summary>
        /// 通过编码查询单个商品信息
        /// </summary>
        /// <param name="bM"></param>
        /// <returns></returns>
        public GoodsListInfo SelectByBmoNE(string bM)
        {
            GoodSlistDAL dal = new GoodSlistDAL();
            GoodsListInfo list = new GoodsListInfo();
            list = dal.SelectOneGoogsByBm(bM);
            return list;
        }
        /// <summary>
        /// 商品更改
        /// </summary>
        /// <returns></returns>
        public int AlterGoods(GoodsListInfo list)
        {
            GoodSlistDAL dal = new GoodSlistDAL();
            int c = dal.AlterGoosMess(list);
            return c;
        }
        /// <summary>
        /// 通过商品名单个商品信息
        /// </summary>
        /// <param name="bM"></param>
        /// <returns></returns>
        public GoodsListInfo SelectByBmoName(string Name)
        {
            GoodSlistDAL dal = new GoodSlistDAL();
            GoodsListInfo list = new GoodsListInfo();
            list = dal.SelectOneGoogsByName(Name);
            return list;
        }
    }
}
