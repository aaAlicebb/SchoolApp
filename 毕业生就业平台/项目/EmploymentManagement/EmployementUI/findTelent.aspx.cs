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
    public partial class findTelent : System.Web.UI.Page
    {
        static TelentBLL Tebll = new TelentBLL();
        static List<telents> TelentsInfo = Tebll.findtelent();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Repeater1.DataSource = pds();
                //this.Repeater1.DataSource = TelentsInfo;
                this.Repeater1.DataBind();

            }
            string num = Request.QueryString["num"];//给他加推
            if (num != null)
            {
                List<telents> cc = Tebll.introduce(num);
                TelentBLL Tebll1 = new TelentBLL();
              List<telents> TelentsInfo = Tebll.findtelent();
                this.Repeater1.DataSource = TelentsInfo;
                Repeater1.DataBind();
               
            }
            string Years = Request.QueryString["Year"];//根据毕业年份显示
            if (Years != null)
            {
                Repeater1.DataSource = pds3();
                Repeater1.DataBind();
            }
            string Class = Request.QueryString["Major"];//根据所选专业显示
            if (Class != null)
            {
                Repeater1.DataSource = pds2();
                Repeater1.DataBind();
            }
            string UpdateTime = Request.QueryString["date"];//根据最新日期显示
            if (UpdateTime != null)
            {
                Repeater1.DataSource = pds4();
                Repeater1.DataBind();
            }
            string Recommand = Request.QueryString["recommand"];//根据加推数显示
            if (Recommand != null)
            {
                Repeater1.DataSource = pds5();
                Repeater1.DataBind();
            }
        }
        //Repeater分页控制显示方法

        private PagedDataSource pds()
        {
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = TelentsInfo;
            pds.AllowPaging = true;//允许分页  
            pds.PageSize = 12;//单页显示项数  
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
            return pds;
        }
        private PagedDataSource pds1()
        {
            string key1 = Request.Form.Get("keys");
            List<telents> TelentsInfos = Tebll.findtelents(key1);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = TelentsInfos;
            pds.AllowPaging = true;//允许分页  
            pds.PageSize = 12;//单页显示项数  
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
            return pds;
        }
        private PagedDataSource pds2()
        {
            telents tee = new telents();
            tee.StuMajor = Request.QueryString["Major"];
            List<telents> TelentsInfos1 = Tebll.findtelentByClass(tee.StuMajor);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = TelentsInfos1;
            pds.AllowPaging = true;//允许分页  
            pds.PageSize = 12;//单页显示项数  
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
            return pds;
        }
        private PagedDataSource pds3()
        {
            telents tee = new telents();
            tee.GraduateYear = Request.QueryString["Year"];
            List<telents> TelentsInfos2 = Tebll.findtelentByYear(tee.GraduateYear);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = TelentsInfos2;
            pds.AllowPaging = true;//允许分页  
            pds.PageSize = 12;//单页显示项数  
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
            return pds;
        }
        private PagedDataSource pds4()
        {
            List<telents> TelentsInfos2 = Tebll.orderBy();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = TelentsInfos2;
            pds.AllowPaging = true;//允许分页  
            pds.PageSize = 12;//单页显示项数  
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
            return pds;
        }
        private PagedDataSource pds5()
        {
            List<telents> TelentsInfos2 = Tebll.orderByRecommand();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = TelentsInfos2;
            pds.AllowPaging = true;//允许分页  
            pds.PageSize = 12;//单页显示项数  
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
            return pds;
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                DropDownList ddlp = (DropDownList)e.Item.FindControl("ddlp");

                HyperLink lpfirst = (HyperLink)e.Item.FindControl("hlfir");
                HyperLink lpprev = (HyperLink)e.Item.FindControl("hlp");
                HyperLink lpnext = (HyperLink)e.Item.FindControl("hln");
                HyperLink lplast = (HyperLink)e.Item.FindControl("hlla");

                pds().CurrentPageIndex = ddlp.SelectedIndex;

                int n = Convert.ToInt32(pds().PageCount);//n为分页数  
                int i = Convert.ToInt32(pds().CurrentPageIndex);//i为当前页  

                Label lblpc = (Label)e.Item.FindControl("lblpc");
                lblpc.Text = n.ToString();
                Label lblp = (Label)e.Item.FindControl("lblp");
                lblp.Text = Convert.ToString(pds().CurrentPageIndex + 1);

                if (!IsPostBack)
                {
                    for (int j = 0; j < n; j++)
                    {
                        ddlp.Items.Add(Convert.ToString(j + 1));
                    }
                }

                if (i <= 0)
                {
                    lpfirst.Enabled = false;
                    lpprev.Enabled = false;
                    lplast.Enabled = true;
                    lpnext.Enabled = true;
                }
                else
                {
                    lpprev.NavigateUrl = "?page=" + (i - 1);
                }
                if (i >= n - 1)
                {
                    lpfirst.Enabled = true;
                    lplast.Enabled = false;
                    lpnext.Enabled = false;
                    lpprev.Enabled = true;
                }
                else
                {
                    lpnext.NavigateUrl = "?page=" + (i + 1);
                }

                lpfirst.NavigateUrl = "?page=0";//向本页传递参数page  
                lplast.NavigateUrl = "?page=" + (n - 1);

                ddlp.SelectedIndex = Convert.ToInt32(pds().CurrentPageIndex);//更新下拉列表框中的当前选中页序号  
            }

        }
        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {//脚模板中的下拉列表框更改时激发  
            string pg = Convert.ToString((Convert.ToInt32(((DropDownList)sender).SelectedValue) - 1));//获取列表框当前选中项  
            Response.Redirect("findTelent.aspx?page=" + pg);//页面转向  
        }

        protected void select(object sender, EventArgs e)
        {

            Repeater1.DataSource = pds1();
            Repeater1.DataBind();
        }
        protected void whatever(object sender, EventArgs e)
        {

            Repeater1.DataSource = pds();
            Repeater1.DataBind();
        }
    }
}