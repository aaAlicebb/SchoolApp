using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmploymentBLL;
using EmployementMODEL;

namespace EmployementUI
{
    public partial class recruit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void submits(object sender, EventArgs e)
        {
            companyInfo companys = new companyInfo();
           companys.ComName = Request.Form.Get("comName");
            companys.PositionType = Request.Form.Get("PositionType");
            companys.ComType = Request.Form.Get("comType");
            companys.Compeople = Request.Form.Get("scale");
            string feedBack = Request.Form.Get("btnRadio");
             companys.ComRemark = feedBack;
            companys.ComInfo = Request.Form.Get("S1");
            companys.ComPosition = Request.Form.Get("requestPosition");
            companys.PositionInfo = Request.Form.Get("request");
            companys.LinkMan = Request.Form.Get("linkman");
            companys.ComTel = Request.Form.Get("phone");
            companys.ComArea = Request.Form.Get("ComAddress");
            companys.Comnet = Request.Form.Get("net");
            companys.ComCity = Request.Form.Get("city");
            companys.ComId =int.Parse(Global.ComMes.ComId);
            //companys.uploadTime =DateTime.Parse(DateTime.Now.ToShortDateString());
            companys.uploadTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            //companys.uploadTime = DateTime.Now;
            
            PresentBLL comBll = new PresentBLL();
            int coms = comBll.present(companys);
            Response.Redirect("WebCompanyMes.aspx");
            if(coms>0)
            {
                string p = Request.Form.Get("comName");
               string p1= Request.Form.Get("PositionType");
               string p2 = Request.Form.Get("comType");
               string p3 = Request.Form.Get("scale");
               string p4 = Request.Form.Get("btnRadio");
               string p5 = Request.Form.Get("S1");
               string p6 = Request.Form.Get("requestPosition");
               string p7 = Request.Form.Get("request");
               string p8 = Request.Form.Get("linkman");
               string p9 = Request.Form.Get("phone");
               string p10 = Request.Form.Get("ComAddress");
               string p11 = Request.Form.Get("net");
               p = "";
               p1 = "";
               p2 = "";
               p3 = "";
               p4 = "";
               p5 = "";
               p6 = "";
               p7= "";
               p8 = "";
               p9 = "";
               p10= "";
               p11 = "";

            }
   
        }
        protected void disuse(object sender, EventArgs e)
        {
            string p = Request.Form.Get("comName");
            string p1 = Request.Form.Get("PositionType");
            string p2 = Request.Form.Get("comType");
            string p3 = Request.Form.Get("scale");
            string p4 = Request.Form.Get("btnRadio");
            string p5 = Request.Form.Get("S1");
            string p6 = Request.Form.Get("requestPosition");
            string p7 = Request.Form.Get("request");
            string p8 = Request.Form.Get("linkman");
            string p9 = Request.Form.Get("phone");
            string p10 = Request.Form.Get("ComAddress");
            string p11 = Request.Form.Get("net");
            p = "";
            p1 = "";
            p2 = "";
            p3 = "";
            p4 = "";
            p5 = "";
            p6 = "";
            p7 = "";
            p8 = "";
            p9 = "";
            p10 = "";
            p11 = "";

        }
    }
}