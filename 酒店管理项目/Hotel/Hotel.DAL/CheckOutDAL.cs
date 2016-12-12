using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.DBHelper;
using System.Data.SqlClient;
using Hotel.Model;
using System.Data;


namespace Hotel.DAL
{
    public class CheckOutDAL
    {
        private SqlHelper db;
        public CheckOutDAL()
        {
            db = new SqlHelper();
        }
        public List<CusSpenInfo> SelectSpend(int RoomId)
        {

            string cmdText = "select * from ConsumeInfo where RoomId=@Roomid";
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1; Persist Security Info=True;User ID=sa;Password=121314;";
            //conn.Open();
            //SqlDataReader reader;
            //SqlCommand cmd = new SqlCommand(cmdText, conn);
            //reader = cmd.ExecuteReader();
            string[] param = { "@RoomId" };
            object[] values = { RoomId };

            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);

            List<CusSpenInfo> Spendlist = new List<CusSpenInfo>();
            while (reader.Read())
            {
                CusSpenInfo Spend = new CusSpenInfo();
                Spend.g_price = decimal.Parse(reader["GoodsPrice"].ToString());
                Spend.g_count = reader["GoodsCount"].ToString();
                Spend.totolAmount = Convert.ToDecimal(reader["TotolAmount"].ToString());
                Spend.RoomId = Convert.ToInt32(reader["RoomId"].ToString());
                Spend.s_time = Convert.ToDateTime(reader["CostTime"].ToString());
                Spend.Goods_name = reader["GoodsName"].ToString();
                Spend.operation = reader["Operator"].ToString();
                Spend.span_no = reader["Spanno"].ToString();

                Spendlist.Add(Spend);

            }
            if (Spendlist != null)
            {
                reader.Close();
                return Spendlist;
            }
            reader.Close();
            return null;
        }
        public int counts(int RoomId)
        {
            string cmdText = "select count(*) from ConsumeInfo where RoomId=@Roomid";
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1;User ID=sa;Password=121314;";
            //conn.Open();
            //SqlCommand cmd = new SqlCommand(cmdText, conn);
            //int count = (int)cmd.ExecuteScalar();
            string[] param = { "@RoomId" };
            object[] values = { RoomId };

            int count = (int)db.ExecuteScalar(cmdText, param, values);
            return count;
        }
        //
        /// <summary>
        /// 查询个数
        /// </summary>
        /// <param name="CName"></param>
        /// <returns></returns>
        public int count(string CName)
        {
            //string cmdText = "select count(*) from InInfo";
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1;User ID=sa;Password=121314;";
            //conn.Open();
            string cmdText = "select count(*) from V_Check where CName=@CName";
            string[] param = { "@CName" };
            object[] values = { CName };

            int count = (int)db.ExecuteScalar(cmdText, param, values);
            return count;
        }
        public List<CheckInfo> SelectCheck(string CName, string spanno)
        {

            string cmdText = "select * from V_Check where CName=@CName and InNumber=@InNumber";
            string[] param = { "@CName", "@InNumber" };
            object[] values = { CName, spanno };

            SqlDataReader reader = db.ExecuteReader(cmdText, param, values);
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1; Persist Security Info=True;User ID=sa;Password=121314;";
            //conn.Open();

            List<CheckInfo> Checklist = new List<CheckInfo>();
            while (reader.Read())
            {
                CheckInfo Check = new CheckInfo();
                Check.r_id = Convert.ToInt32(reader["RoomId"].ToString());
                Check.c_name = reader["CName"].ToString();
                Check.InType = reader["InType"].ToString();
                Check.roomPrice = Convert.ToDecimal(reader["RoomPrice"].ToString());
                Check.c_intoday = Convert.ToDateTime(reader["CInTime"].ToString());
                Check.foregift = Convert.ToDecimal(reader["Foregift"].ToString());
                Check.roomState = reader["RoomState"].ToString();

                Checklist.Add(Check);

            }
            if (Checklist != null)
            {
                reader.Close();
                return Checklist;
            }
            reader.Close();
            return null;
        }
        /// <summary>
        /// 插入消费记录
        /// </summary>
        /// <param name="CName"></param>
        /// <returns></returns>
        public int Insert(CheckOutInfo check)
        {

            string cmdText = "insert  into  CheckoutInfo(CheckoutId,RoomId,CheckAmount,foregift) values( @CheckoutId,@RoomId,@CheckAmount,@foregift)";

            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1;User ID=sa;Password=121314;";

            SqlCommand myCommand = new SqlCommand(cmdText, Global.conn);
            Global.conn.Open();
            myCommand.Parameters.Add("@CheckoutId", SqlDbType.VarChar);
            myCommand.Parameters["@CheckoutId"].Value = check.checkno;
            myCommand.Parameters.Add("@RoomId", SqlDbType.Int);
            myCommand.Parameters["@RoomId"].Value = check.RoomId;
            myCommand.Parameters.Add("@CheckAmount", SqlDbType.Decimal);
            myCommand.Parameters["@CheckAmount"].Value = check.to_monet;//3
            myCommand.Parameters.Add("@foregift", SqlDbType.Decimal);
            myCommand.Parameters["@foregift"].Value = check.forgift;

            int count = myCommand.ExecuteNonQuery();
            Global.conn.Close();
            return count;


        }
        /// <summary>
        /// 团队入住
        /// </summary>
        /// <param name="CName"></param>
        /// <returns></returns>
        public int count(string CName, string spanno)
        {
            //string cmdText = "select count(*) from InInfo";
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1;User ID=sa;Password=121314;";
            //conn.Open();
            string cmdText = "select count(*) from V_Check where CName=@CName and InNumber=@InNumber";
            string[] param = { "@CName", "@InNumber" };
            object[] values = { CName, spanno };

            int count = (int)db.ExecuteScalar(cmdText, param, values);
            return count;
        }
    }
}
