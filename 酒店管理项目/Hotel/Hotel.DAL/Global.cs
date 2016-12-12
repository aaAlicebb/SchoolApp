using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Hotel.DAL
{
   public class Global
    {
        private static string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        public static SqlConnection conn = new SqlConnection(strConn);
    }
}
