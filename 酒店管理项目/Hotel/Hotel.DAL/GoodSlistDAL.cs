using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.DBHelper;
using Hotel.Model;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Hotel.DAL
{
    public class GoodSlistDAL
    {
        SqlHelper sql = new SqlHelper();
        private SqlHelper db;
        public GoodSlistDAL()
        {
            db = new SqlHelper();
        }
        public List<GoodsListInfo> SelectGoods()
        {

            string cmdText = "select * from GoodsListInfo";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=hoTels; Persist Security Info=True;User ID=sa;Password=123456;";
            conn.Open();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            reader = cmd.ExecuteReader();
            List<GoodsListInfo> Goodslist = new List<GoodsListInfo>();
            while (reader.Read())
            {
                GoodsListInfo Goods = new GoodsListInfo();
                Goods.Goods_Name = reader["GoodsName"].ToString();
                Goods.Goods_price = decimal.Parse(reader["GoodsPrice"].ToString());
                Goods.Goods_count =Convert.ToInt32 (reader["GoodsCount"].ToString());
                Goods.Goods_BM = reader["GoodsBM"].ToString();
                Goods.Goods_Unit = reader["GoodsUnit"].ToString();
                Goods.Goods_JP = reader["GoodsJP"].ToString();
                Goodslist.Add(Goods);

            }
            if (Goodslist != null)
            {
                reader.Close();
                return Goodslist;
            }
            reader.Close();
            return null;
        }
        public int count()
        {
            string cmdText = "select count(*) from GoodsListInfo";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=hotels;User ID=sa;Password=123456;";
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            int count = (int)cmd.ExecuteScalar();
            return count;
        }
        /// <summary>
        /// 修改联系人
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <summary>
        public int Update(GoodsListInfo good)
        {
            if (Global.conn.State == ConnectionState.Open)
            {
                Global.conn.Close();
            }
            string cmdText = "update GoodsListInfo set GoodsCount=@GoodsCount where GoodsName=@GoodsName";

            SqlCommand myCommand = new SqlCommand(cmdText, Global.conn);
            Global.conn.Open();
            myCommand.Parameters.Add("@GoodsCount", SqlDbType.NChar);
            myCommand.Parameters["@GoodsCount"].Value = good.Goods_count;
            myCommand.Parameters.Add("@GoodsName", SqlDbType.VarChar);
            myCommand.Parameters["@GoodsName"].Value = good.Goods_Name;
            //myCommand.Parameters.Add("@GoodsPrice", SqlDbType.Decimal);
            //myCommand.Parameters["@GoodsPrice"].Value = good.Goods_price;//3
            //myCommand.Parameters.Add("@GoodsBM", SqlDbType.VarChar);
            //myCommand.Parameters["@GoodsBM"].Value = good.Goods_BM;
            //myCommand.Parameters.Add("@GoodsUnit", SqlDbType.NVarChar);
            //myCommand.Parameters["@GoodsUnit"].Value = good.Goods_Unit;
            int count = myCommand.ExecuteNonQuery();
            Global.conn.Close();
            return count;

        }
        public int Updatecount(string good, int bcount)
        {
            string cmdText = "update GoodsListInfo set GoodsCount=@GoodsCount where GoodsName=@GoodsName";

            SqlCommand myCommand = new SqlCommand(cmdText, Global.conn);
            Global.conn.Open();
            myCommand.Parameters.Add("@GoodsName", SqlDbType.NChar);
            myCommand.Parameters["@GoodsName"].Value = good;
            myCommand.Parameters.Add("@GoodsCount", SqlDbType.VarChar);
            string cmdTexts = "select * from GoodsListInfo where GoodsName=@GoodsName";
            string[] param = { "@GoodsName" };
            object[] values = { good };
            SqlDataReader reader = db.ExecuteReader(cmdTexts, param, values);
            int aacount = 0;
            while (reader.Read())
            {
                aacount = int.Parse(reader["GoodsCount"].ToString());
            }
            myCommand.Parameters["@GoodsCount"].Value = aacount;
            int count = myCommand.ExecuteNonQuery();
            Global.conn.Close();
            return count;
        }
        public List<GoodsListInfo> SelectGoodsBM(string GoodsBM)
        {
            string cmdText = "select * from GoodsListInfo where GoodsBM like @GoodsBM ";
            string[] param = { "@GoodsBM" };
            object[] values = { GoodsBM + "%" };

            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);

            List<GoodsListInfo> list = new List<GoodsListInfo>();
            while (reader.Read())
            {
                GoodsListInfo Goods = new GoodsListInfo();
                Goods.Goods_BM = reader["GoodsBM"].ToString();
                Goods.Goods_count = int.Parse(reader["GoodsCount"].ToString());
                Goods.Goods_Name = reader["GoodsName"].ToString();
                Goods.Goods_price = Convert.ToDecimal(reader["GoodsPrice"].ToString());
                Goods.Goods_Unit = reader["GoodsUnit"].ToString();


                list.Add(Goods);
            }
            if (list != null)
            {
                reader.Close();
                return list;
            }
            reader.Close();
            return null;
        }
        /// <summary>
        /// 简拼查询
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <summary>
        public List<GoodsListInfo> SelectGoodsJP(string GoodsJP)
        {
            string cmdText = "select * from GoodsListInfo where GoodsJP like @GoodsJP ";
            string[] param = { "@GoodsJP" };
            object[] values = { GoodsJP + "%" };

            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);

            List<GoodsListInfo> list = new List<GoodsListInfo>();
            while (reader.Read())
            {
                GoodsListInfo Goods = new GoodsListInfo();
                Goods.Goods_BM = reader["GoodsBM"].ToString();
                Goods.Goods_count = int.Parse(reader["GoodsCount"].ToString());
                Goods.Goods_Name = reader["GoodsName"].ToString();
                Goods.Goods_price = Convert.ToDecimal(reader["GoodsPrice"].ToString());
                Goods.Goods_Unit = reader["GoodsUnit"].ToString();


                list.Add(Goods);
            }
            if (list != null)
            {
                reader.Close();
                return list;
            }
            reader.Close();
            return null;
        }
        /// <summary>
        /// 物料增加
        /// </summary>
        /// <returns></returns>
        public int GoodsAdd(GoodsListInfo list)
        {
            string cmd = "insert into GoodsListInfo(GoodsBM,GoodsCount,GoodsJP,GoodsName,GoodsPrice,GoodsUnit) values(@BM,@COUNT,@JP,@Name,@Price,@Unit)";
            string[] pra = { "@BM", "@COUNT", "@JP", "@Name", "@Price", "@Unit" };
            string[] value = { list.Goods_BM, list.Goods_count.ToString(), list.Goods_JP, list.Goods_Name, list.Goods_price.ToString(), list.Goods_Unit };
            int count = sql.ExecuteNoneQuery(cmd, pra, value);
            return count;
        }
        /// <summary>
        /// 物品删除
        /// </summary>
        /// <returns></returns>
        public int GoodsDelet(string Bm)
        {
            string cmd = "delete from GoodsListInfo where GoodsBM=@BM";
            string[] pra = { "@BM" };
            string[] value = { Bm };
            int count = sql.ExecuteNoneQuery(cmd, pra, value);
            return count;
        }
        /// <summary>
        /// 物品编码查询是否存在
        /// </summary>
        /// <param name="GoodsBM"></param>
        /// <returns></returns>
        public int SelectGoodsBMSingel(string GoodsBM)
        {
            string cmdText = "select count(*) from GoodsListInfo where GoodsBM=@GoodsBM ";
            string[] param = { "@GoodsBM" };
            object[] values = { GoodsBM };
            int count = (int)sql.ExecuteScalar(cmdText, param, values);
            if (count > 0)
            {
                return count;
            }
            else
            {
                return 0;
            }

        }
        /// <summary>
        /// 通过编码查询商品信息
        /// </summary>
        /// <param name="Bm"></param>
        /// <returns></returns>
        public GoodsListInfo SelectOneGoogsByBm(string Bm)
        {
            string str = "select * from GoodsListInfo where GoodsBM=@BM";
            string[] pra = { "@BM" };
            string[] value = { Bm };
            SqlDataReader reader = sql.ExecuteReader(str, pra, value);
            GoodsListInfo list = new GoodsListInfo();
            if (reader.Read())
            {
                list.Goods_BM = reader["GoodsBM"].ToString();
                list.Goods_JP = reader["GoodsJP"].ToString();
                list.Goods_Name = reader["GoodsName"].ToString();
                list.Goods_price = (decimal)reader["GoodsPrice"];
                list.Goods_Unit = reader["GoodsUnit"].ToString();
                list.Goods_count = int.Parse(reader["GoodsCount"].ToString());
                return list;
            }
            else 
            {
                return null;
            }
            
            
        }
        /// <summary>
        /// 通过商品编码修改商品信息
        /// </summary>
        /// <returns></returns>
        public int AlterGoosMess(GoodsListInfo goods)
        {
            string cmd = "update GoodsListInfo set GoodsCount=@Count,GoodsJP=@Sp,GoodsName=@Name,GoodsPrice=@Price,GoodsUnit=@Unit where GoodsBM=@Bm";
            string[] pra = { "@Count", "@Sp", "@Name", "@Price", "@Unit", "@Bm" };
            string[] value = { goods.Goods_count.ToString(), goods.Goods_JP, goods.Goods_Name, goods.Goods_price.ToString(), goods.Goods_Unit, goods.Goods_BM };
            int count = sql.ExecuteNoneQuery(cmd, pra, value);
            return count;
        }
        /// <summary>
        /// 通过商品名查询商品信息
        /// </summary>
        /// <param name="Bm"></param>
        /// <returns></returns>
        public GoodsListInfo SelectOneGoogsByName(string Name)
        {
            string str = "select * from GoodsListInfo where GoodsName=@Name";
            string[] pra = { "@Name" };
            string[] value = { Name };
            SqlDataReader reader = sql.ExecuteReader(str, pra, value);
            GoodsListInfo list = new GoodsListInfo();
            if (reader.Read())
            {
                list.Goods_BM = reader["GoodsBM"].ToString();
                list.Goods_JP = reader["GoodsJP"].ToString();
                list.Goods_Name = reader["GoodsName"].ToString();
                list.Goods_price = (decimal)reader["GoodsPrice"];
                list.Goods_Unit = reader["GoodsUnit"].ToString();
                list.Goods_count = int.Parse(reader["GoodsCount"].ToString());
                return list;
            }
            else 
            {
                return null;
            }
        }
    }
}
