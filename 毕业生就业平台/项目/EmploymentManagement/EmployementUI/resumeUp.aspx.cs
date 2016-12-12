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
    public partial class resumeUp : System.Web.UI.Page
    {
        public string stuxh;
        protected void Page_Load(object sender, EventArgs e)
        {
            stuxh = Global.StuMes.StuId;
        }
       
    }
}