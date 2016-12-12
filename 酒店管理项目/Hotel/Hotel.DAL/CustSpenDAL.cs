using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Hotel.DBHelper;
using Hotel.Model;
using System.Data;



namespace Hotel.DAL
{
    public class CustSpenDAL
    {
        private SqlHelper db;
        public CustSpenDAL()
        {
            db = new SqlHelper();
        }
        /// <summary>
        /// 消费单插入
        /// </summary>
        /// <param name="custom"></param>
        /// <returns></returns>
        public int Insert(List<CusSpenInfo> spenlist)
        {
            if (Global.conn.State == ConnectionState.Open)
            {
                Global.conn.Close();
            }
            string cmdText = "insert  into  ConsumeInfo(CostName,GoodsPrice,GoodsCount,OtherSpend,TotolAmount,RoomId,CostTime,GoodsName,Operator,Spanno) values(@CostName,@GoodsPrice,@GoodsCount,@OtherSpend,@TotolAmount,@RoomId,@CostTime,@GoodsName,@Operator,@Spanno)";

            SqlCommand myCommand = new SqlCommand(cmdText, Global.conn);
            Global.conn.Open();
            for (int i = 0; i < spenlist.Count; i++)
            {
                myCommand.Parameters.Add("@CostName", SqlDbType.VarChar);
                myCommand.Parameters["@CostName"].Value = spenlist[i].s_name;
                myCommand.Parameters.Add("@GoodsPrice", SqlDbType.Decimal);
                myCommand.Parameters["@GoodsPrice"].Value = spenlist[i].g_price;
                myCommand.Parameters.Add("@GoodsCount", SqlDbType.VarChar);
                myCommand.Parameters["@GoodsCount"].Value = spenlist[i].g_count;
                myCommand.Parameters.Add("@OtherSpend", SqlDbType.Decimal);
                myCommand.Parameters["@OtherSpend"].Value = spenlist[i].OtherSpend;
                myCommand.Parameters.Add("@TotolAmount", SqlDbType.VarChar);
                myCommand.Parameters["@TotolAmount"].Value = spenlist[i].totolAmount;
                myCommand.Parameters.Add("@RoomId", SqlDbType.VarChar);
                myCommand.Parameters["@RoomId"].Value = spenlist[i].RoomId;
                myCommand.Parameters.Add("@CostTime", SqlDbType.VarChar);
                myCommand.Parameters["@CostTime"].Value = spenlist[i].s_time;
                myCommand.Parameters.Add("@GoodsName", SqlDbType.VarChar);
                myCommand.Parameters["@GoodsName"].Value = spenlist[i].Goods_name;
                myCommand.Parameters.Add("@Operator", SqlDbType.VarChar);
                myCommand.Parameters["@Operator"].Value = spenlist[i].operation;
                myCommand.Parameters.Add("@Spanno", SqlDbType.VarChar);
                myCommand.Parameters["@Spanno"].Value = spenlist[i].span_no;
            }
            int count = myCommand.ExecuteNonQuery();
            Global.conn.Close();
            return count;


        }
        public int delete(DateTime intime)
        {
            string cmdText = "delete from ConsumeInfo where CostTime=@CostTime";
            string[] param = { "@CostTime" };
            object[] values = { intime };
            int count = db.ExecuteNoneQuery(cmdText, param, values);
            if (count > 0)
            {
                return count;
            }
            else
            {
                return 0;
            }
        }
        public List<CusSpenInfo> SelectCheck(int roomid, string spanno)
        {

            string cmdText = "select * from ConsumeInfo where RoomId=@RoomId and Spanno=@Spanno";
            string[] param = { "@RoomId", "@Spanno" };
            object[] values = { roomid, spanno };

            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1; Persist Security Info=True;User ID=sa;Password=121314;";
            //conn.Open();

            List<CusSpenInfo> Checklist = new List<CusSpenInfo>();
            while (reader.Read())
            {
                CusSpenInfo spen = new CusSpenInfo();
                spen.g_price = Convert.ToDecimal(reader["GoodsPrice"].ToString());
                spen.g_count = reader["GoodsCount"].ToString();
                spen.totolAmount = Convert.ToDecimal(reader["TotolAmount"].ToString());
                spen.RoomId = int.Parse(reader["RoomId"].ToString());
                spen.s_time = Convert.ToDateTime(reader["CostTime"].ToString());
                spen.operation = reader["Operator"].ToString();
                spen.Goods_name = reader["GoodsName"].ToString();
                spen.span_no = reader["Spanno"].ToString();
                Checklist.Add(spen);

            }
            if (Checklist != null)
            {
                reader.Close();
                return Checklist;
            }
            reader.Close();
            return null;
        }
    }
}
