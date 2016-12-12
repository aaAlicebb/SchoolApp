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
    public partial class WebJobAbout : System.Web.UI.Page
    {
        public companyInfo company1 = new companyInfo();
        public List<companyInfo> coms2 = new List<companyInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            companyBLL company = new companyBLL();
            string aa = Context.Request.QueryString["comname"];
            coms2 = company.ComInfoByName(aa);
            company1 = coms2[0];

        }
    }
}