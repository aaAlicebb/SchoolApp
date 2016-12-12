using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployementMODEL;
using EmploymentBLL;

namespace EmployementUI
{
    public partial class WebMyJianli : System.Web.UI.Page
    {
        public ResumeInfo res = new ResumeInfo();
        public string StuXh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.Request.QueryString["stuName"] != null)
            {
                string name = Context.Request.QueryString["stuName"];
                ResumeInfoBLL bll = new ResumeInfoBLL();
                res = bll.selectByStuName(name);
                StuXh= res.StuXH;
            }
            else
            {
                string id = Context.Request.QueryString["comName"];
                ResumeInfoBLL bll = new ResumeInfoBLL();
                res = bll.selectByRecID(id);
                StuXh = res.StuXH;
            }
        }
    }
}