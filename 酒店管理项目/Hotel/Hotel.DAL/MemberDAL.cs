using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.DBHelper;

namespace Hotel.DAL
{
    public class MemberDAL
    {
          private SqlHelper db;
          public MemberDAL()
        {
            db = new SqlHelper();
        }
          public int count(string number)
        {
            //string cmdText = "select count(*) from InInfo";
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1;User ID=sa;Password=121314;";
            //conn.Open();
            string cmdText = "select count(*) from VipRoomInfo  where VipZJNumber=@number";
            string[] param = { "@number" };
            object[] values = { number };

            int count = (int)db.ExecuteScalar(cmdText, param, values);
            return count;
        }
          public int VipIdCount(string VipId)
          {
              //string cmdText = "select count(*) from InInfo";
              //SqlConnection conn = new SqlConnection();
              //conn.ConnectionString = "Data Source=.;Initial Catalog=HoTel1;User ID=sa;Password=121314;";
              //conn.Open();
              string cmdText = "select count(*) from VipRoomInfo  where VipId=@VipId";
              string[] param = { "@VipId" };
              object[] values = { VipId };

              int count = (int)db.ExecuteScalar(cmdText, param, values);
              return count;
          }
    }
}
