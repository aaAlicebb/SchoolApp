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
    public partial class _Default : System.Web.UI.Page
    {
        static companyBLL comBLL = new companyBLL();
        static List<companyInfo> comInfo = comBLL.ComInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<province> aa = comBLL.ProInfo();
                foreach (province a in aa)
                {
                    this.DropDownList1.DataValueField = "ProID";
                    this.DropDownList1.DataTextField = "ProName";
                    DropDownList1.DataSource = aa;
                    DropDownList1.DataBind();
                    DropDownList1.Items.Add("不限");
                    DropDownList1.Items[this.DropDownList1.Items.Count - 1].Value = "不限";
                    DropDownList1.SelectedIndex = this.DropDownList1.Items.Count - 1;
                }
                this.Repeater1.DataSource = pds();
                this.Repeater1.DataBind();

            }
            string PositionType = Request.QueryString["id"];//根据职位类型搜索
            if (PositionType != null)
            {
                companyInfo com2 = new companyInfo();
                com2.PositionType = PositionType;
                List<companyInfo> cc = comBLL.selectComInfoByPositionType(com2.PositionType);
                this.Repeater1.DataSource = cc;
                this.Repeater1.DataBind();
            }
            string JobAttribute = Request.QueryString["name"];//根据职位性质搜索
            if (JobAttribute != null)
            {
                companyInfo com2 = new companyInfo();
                com2.PositionAttribute = JobAttribute;
                List<companyInfo> job = comBLL.selectComInfoByPosition(com2.PositionAttribute);
                this.Repeater1.DataSource = job;
                this.Repeater1.DataBind();
            }
            string time1 = Request.QueryString["time"];//最新
            if (time1 != null)
            {
                List<companyInfo> times = comBLL.selectComInfoByTime();
                this.Repeater1.DataSource = times;
                this.Repeater1.DataBind();
            }
            string ComNames = Request.QueryString["comname"];//浏览次数+1
            if (ComNames != null)
            {
                companyInfo info1 = new companyInfo();
                info1.ComName = ComNames;
                List<companyInfo> cominfo = comBLL.AddLooktime(info1.ComName);
            }
            string glance = Request.QueryString["Looktime"];//最热
            if (glance != null)
            {
                List<companyInfo> cominfo = comBLL.Looktime();
                this.Repeater1.DataSource = cominfo;
                this.Repeater1.DataBind();
            }
        }

        //Repeater分页控制显示方法

        private PagedDataSource pds()
        {
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = comInfo;
            pds.AllowPaging = true;//允许分页  
            pds.PageSize = 9;//单页显示项数  
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
            return pds;
        }
        private PagedDataSource pds1()
        {
            string comName = Request.Form.Get("txtName");
            List<companyInfo> coms = comBLL.ComInfoByName(comName);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = coms;
            pds.AllowPaging = true;//允许分页  
            pds.PageSize = 9;//单页显示项数  
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
            Response.Redirect("Default.aspx?page=" + pg);//页面转向  
        }


        protected void Button1_Click(object sender, EventArgs e)//查询按钮
        {
            this.Repeater1.DataSource = pds1();
            this.Repeater1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)//省市选择
        {
            DropDownList2.Items.Clear();
            List<province> bb = comBLL.cityInfo(this.DropDownList1.SelectedIndex + 1);
            foreach (province b in bb)
            {
                DropDownList2.DataValueField = "ProID";
                DropDownList2.DataTextField = "ProName";
                DropDownList2.DataSource = bb;
                DropDownList2.DataBind();
            }

            if (DropDownList1.SelectedIndex == this.DropDownList1.Items.Count - 1)//不限
            {
                Repeater1.DataSource = comInfo;
                Repeater1.DataBind();
            }
        }
        protected void Click(object sender, EventArgs e)//不限
        {
            Repeater1.DataSource = comInfo;
            Repeater1.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)//城市选择
        {
            companyInfo comInfo = new companyInfo();
            comInfo.ComCity = DropDownList2.SelectedItem.Text;
            List<companyInfo> infos = comBLL.workplace(comInfo.ComCity);
            Repeater1.DataSource = infos;
            Repeater1.DataBind();
        }
    }
}