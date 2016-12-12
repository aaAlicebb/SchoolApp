using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployementMODEL;
using EmploymentBLL;
using System.Collections;

namespace EmployementUI
{
    public partial class homepage : System.Web.UI.Page
    {
        public List<ResumeInfo> list = new List<ResumeInfo>();
        public string xlk;
        public string dls;
        protected void Page_Load(object sender, EventArgs e)
        {
            ResumeInfoBLL bll = new ResumeInfoBLL();
            list = bll.ResumeSelect();
            if(Session["index"]!=null)
            {
                if (Session["index"].ToString()!="")
                {
                    dls = "style='display:none'";
                    xlk = "style='display:block'";
                }
                else
                {
                    dls = "style='display:block'";
                    xlk = "style='display:none'";
                }
            }
            else
            {
                dls = "style='display:block'";
                xlk = "style='display:none'";
            }
            if(Request.QueryString["Click"]!=null) 
            {
                if (Request.QueryString["Click"].ToString().Equals("selfClick"))
                {
                    if (Session["index"] != null)
                    {
                        if (Session["index"].ToString().Equals("stu"))
                        {
                            Response.Redirect("webStudentSelfMes.aspx");
                        }
                        else if (Session["index"].ToString().Equals("tea"))
                        {
                            Response.Redirect("webTeacherSelfMes.aspx");
                        }
                        else if (Session["index"].ToString().Equals("emp"))
                        {
                            Response.Redirect("webCompanyMes.aspx");
                        }
                        else
                        {
                            Response.Write("管理员");
                        }
                    }
                    
                }
                
            }
        }
    }
}