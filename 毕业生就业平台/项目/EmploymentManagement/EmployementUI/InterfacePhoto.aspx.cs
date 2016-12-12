using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EmployementUI
{
    public partial class InterfacePhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            byte[] tp = new byte[0];
            string hrid = Request.QueryString["hrid"];
            string type = Request.QueryString["type"];
            if(type.Equals("stu"))
            {
                //string strConn = "Data Source=.;Initial Catalog=imageText;Persist Security Info=True;User ID=sa;Password=123456";
                string strConn = "Data Source=.;Initial Catalog=EmDB;Persist Security Info=True;User ID=sa;Password=123456";
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                string cmd = "select * from StuInfo where stuID=" + hrid;
                SqlCommand cmds = new SqlCommand(cmd, conn);
                SqlDataReader reader = cmds.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["stuImg"].ToString() != "")
                    {
                        tp = (byte[])reader["stuImg"];
                        Response.ContentType = "image/jpeg";
                        Response.BinaryWrite(tp);
                        conn.Close();
                    }

                    Response.WriteFile(Server.MapPath("\\photo.png"));
                }
                Response.WriteFile(Server.MapPath("\\photo.png"));
                conn.Close();
            }
            else if (type.Equals("tea"))
            {
                //string strConn = "Data Source=.;Initial Catalog=imageText;Persist Security Info=True;User ID=sa;Password=123456";
                string strConn = "Data Source=.;Initial Catalog=EmDB;Persist Security Info=True;User ID=sa;Password=123456";
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                string cmd = "select * from TeaInfo where TeaID=" + hrid;
                SqlCommand cmds = new SqlCommand(cmd, conn);
                SqlDataReader reader = cmds.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["teaImg"].ToString() != "")
                    {
                        tp = (byte[])reader["teaImg"];
                        Response.ContentType = "image/jpeg";
                        Response.BinaryWrite(tp);
                        conn.Close();
                    }
                    Response.WriteFile(Server.MapPath("\\photo.png"));
                }
                Response.WriteFile(Server.MapPath("\\photo.png"));
                conn.Close();
            }
            else if (type.Equals("com"))
            {
                string strConn = "Data Source=.;Initial Catalog=EmDB;Persist Security Info=True;User ID=sa;Password=123456";
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                string cmd = "select * from ComInfo where ComId=" + hrid;
                SqlCommand cmds = new SqlCommand(cmd, conn);
                SqlDataReader reader = cmds.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["ComSign"].ToString() != "")
                    {
                        tp = (byte[])reader["ComSign"];
                        Response.ContentType = "image/jpeg";
                        Response.BinaryWrite(tp);
                        conn.Close();
                    }
                }
                conn.Close();
            }
           
        }
    }
}