using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmModel;
using EmBLL;

namespace EmployementUI
{
    public partial class WebAdmin : System.Web.UI.Page
    {
        public List<ClassInfo> callist = new List<ClassInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.AutoGenerateColumns = false;
            if (!IsPostBack)
            {
                bind();
                emInfobind();
                teaInfobind();
                comInfobind();
                classInfobind();
            }

        }
        //绑定
        public void bind()
        {
            //string sqlstr = "select * from 表";

            List<StuInfo> stulist = new List<StuInfo>();
            stuBLL stu = new stuBLL();
            stulist = stu.SelectStu();

            GridView1.DataSource = stulist;

            GridView1.DataBind();


        }
        //就业信息绑定绑定
        public void emInfobind()
        {
            //string sqlstr = "select * from 表";

            List<EmInfo> emlist = new List<EmInfo>();
            EmpBLL em = new EmpBLL();
            emlist = em.SelectStu();

            GridView2.DataSource = emlist;

            GridView2.DataBind();


        }
        //老师信息绑定
        public void teaInfobind()
        {
            //string sqlstr = "select * from 表";
            List<TeaInfo> tealist = new List<TeaInfo>();
            TeaBLL tea = new TeaBLL();
            tealist = tea.SelectStu();
            GridView3.DataSource = tealist;
            GridView3.DataBind();
        }
        //企业信息绑定
        public void comInfobind()
        {
            //string sqlstr = "select * from 表";
            List<ComInfo> comlist = new List<ComInfo>();
            ComBLL com = new ComBLL();
            comlist = com.SelectStu();
            GridView4.DataSource = comlist;
            GridView4.DataBind();
        }
        //班级信息绑定
        public void classInfobind()
        {
            //string sqlstr = "select * from 表";
            List<ClassInfo> callist = new List<ClassInfo>();
            ClassBLL cal = new ClassBLL();
            callist = cal.SelectStu();
            GridView5.DataSource = callist;
            GridView5.DataBind();
        }
        // 编辑
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.ShowFooter = true;
            bind();
        }
        //删除
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            stuBLL bll = new stuBLL();
            //int ID = int.Parse(((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].FindControl("GridView1"))).Text.ToString().Trim());
            int ID = int.Parse(GridView1.Rows[e.RowIndex].Cells[0].Text);
            bll.DeleteById(ID);
            bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            stuBLL bll = new stuBLL();
            int ID = int.Parse(((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim());
            StuInfo stu = new StuInfo();
            stu.ID = int.Parse(((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim());
            //TextBox temp = GridView1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
            //stu.stuID = temp.Text.ToString().Trim();((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[1])).Text.ToString().Trim();
            stu.stuID = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].FindControl("TextBox1"))).Text;
            stu.stuPwd = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].FindControl("TextBox2"))).Text;
            stu.stuName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBox3"))).Text;
            stu.stuSex = char.Parse(((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox4"))).Text);
            stu.stuAge = int.Parse(((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox5"))).Text);
            stu.stuGrade = int.Parse(((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox6"))).Text);
            stu.stuMajor = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[7].FindControl("TextBox7"))).Text;
            stu.stuStatus = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[8].FindControl("TextBox8"))).Text;
            stu.IDnumber = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[9].FindControl("TextBox9"))).Text;
            stu.Class = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[9].FindControl("TextBox19"))).Text;
            bll.UpdateById(ID, stu);
            GridView1.EditIndex = -1;
            bind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }





        protected void Button1_Click1(object sender, EventArgs e)
        {
            StuInfo stu = new StuInfo();

            stu.stuID = ((TextBox)(GridView1.FooterRow.FindControl("TextBox10"))).Text;
            stu.stuPwd = ((TextBox)(GridView1.FooterRow.FindControl("TextBox11"))).Text;
            stu.stuName = ((TextBox)(GridView1.FooterRow.FindControl("TextBox12"))).Text;
            stu.stuSex = char.Parse(((TextBox)(GridView1.FooterRow.FindControl("TextBox13"))).Text);
            stu.stuAge = int.Parse(((TextBox)(GridView1.FooterRow.FindControl("TextBox14"))).Text);
            stu.stuGrade = int.Parse(((TextBox)(GridView1.FooterRow.FindControl("TextBox15"))).Text);
            stu.stuMajor = ((TextBox)(GridView1.FooterRow.FindControl("TextBox16"))).Text;
            stu.stuStatus = ((TextBox)(GridView1.FooterRow.FindControl("TextBox17"))).Text;
            stu.IDnumber = ((TextBox)(GridView1.FooterRow.FindControl("TextBox18"))).Text;
            stu.Class = ((TextBox)(GridView1.FooterRow.FindControl("TextBox20"))).Text;
            stuBLL bll = new stuBLL();
            bll.Insert(stu);
            bind();
        }
        /// <summary>
        /// 就业管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            emInfobind();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EmpBLL bll = new EmpBLL();
            //int ID = int.Parse(((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].FindControl("GridView1"))).Text.ToString().Trim());
            int ID = int.Parse(GridView2.Rows[e.RowIndex].Cells[0].Text);
            bll.DeleteById(ID);
            emInfobind();
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView2.EditIndex = e.NewEditIndex;
            GridView2.ShowFooter = true;
            emInfobind();
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            EmpBLL bll = new EmpBLL();
            int ID = int.Parse(((TextBox)(GridView2.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim());
            EmInfo em = new EmInfo();
            em.ID = int.Parse(((TextBox)(GridView2.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim());
            //TextBox temp = GridView1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
            //stu.stuID = temp.Text.ToString().Trim();((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[1])).Text.ToString().Trim();
            em.stuID = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[1].FindControl("TextBox1"))).Text;
            em.stuName = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[2].FindControl("TextBox2"))).Text;
            em.ComID = int.Parse(((TextBox)(GridView2.Rows[e.RowIndex].Cells[3].FindControl("TextBox3"))).Text);
            em.ComName = ((TextBox)(GridView2.Rows[e.RowIndex].FindControl("TextBox4"))).Text;
            em.Injobtime = Convert.ToDateTime(((TextBox)(GridView2.Rows[e.RowIndex].FindControl("TextBox5"))).Text);
            em.Wage = decimal.Parse(((TextBox)(GridView2.Rows[e.RowIndex].FindControl("TextBox6"))).Text);
            em.FeedbackInfo = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[7].FindControl("TextBox8"))).Text;
            em.Feedbacktime = Convert.ToDateTime(((TextBox)(GridView2.Rows[e.RowIndex].Cells[8].FindControl("TextBox9"))).Text);
            bll.UpdateById(ID, em);
            GridView2.EditIndex = -1;
            emInfobind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EmpBLL bll = new EmpBLL();
            EmInfo em = new EmInfo();
            //TextBox temp = GridView1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
            //stu.stuID = temp.Text.ToString().Trim();((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[1])).Text.ToString().Trim();
            em.stuID = ((TextBox)(GridView2.FooterRow.FindControl("TextBox10"))).Text;
            em.stuName = ((TextBox)(GridView2.FooterRow.FindControl("TextBox11"))).Text;
            em.ComID = int.Parse(((TextBox)(GridView2.FooterRow.FindControl("TextBox12"))).Text);
            em.ComName = ((TextBox)(GridView2.FooterRow.FindControl("TextBox13"))).Text;
            em.Injobtime = Convert.ToDateTime(((TextBox)(GridView2.FooterRow.FindControl("TextBox14"))).Text);
            em.Wage = Convert.ToDecimal(((TextBox)(GridView2.FooterRow.FindControl("TextBox15"))).Text);
            em.FeedbackInfo = ((TextBox)(GridView2.FooterRow.FindControl("TextBox17"))).Text;
            em.Feedbacktime = Convert.ToDateTime(((TextBox)(GridView2.FooterRow.FindControl("TextBox18"))).Text);
            bll.Insert(em);
            emInfobind();
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView3.EditIndex = -1;
            teaInfobind();
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TeaBLL bll = new TeaBLL();
            //int ID = int.Parse(((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].FindControl("GridView1"))).Text.ToString().Trim());
            int ID = int.Parse(GridView3.Rows[e.RowIndex].Cells[0].Text);
            bll.DeleteById(ID);
            teaInfobind();
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView3.EditIndex = e.NewEditIndex;
            GridView3.ShowFooter = true;
            teaInfobind();
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TeaBLL bll = new TeaBLL();
            int ID = int.Parse(((TextBox)(GridView3.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim());
            TeaInfo tea = new TeaInfo();
            tea.ID = int.Parse(((TextBox)(GridView3.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim());
            //TextBox temp = GridView1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
            //stu.stuID = temp.Text.ToString().Trim();((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[1])).Text.ToString().Trim();
            tea.TeaID = ((TextBox)(GridView3.Rows[e.RowIndex].Cells[1].FindControl("TextBox1"))).Text;
            tea.TeaName = ((TextBox)(GridView3.Rows[e.RowIndex].Cells[1].FindControl("TextBox2"))).Text;
            tea.TeaPwd = ((TextBox)(GridView3.Rows[e.RowIndex].Cells[2].FindControl("TextBox3"))).Text;
            tea.TeaSex = char.Parse(((TextBox)(GridView3.Rows[e.RowIndex].Cells[3].FindControl("TextBox4"))).Text);
            tea.TeaAge = int.Parse(((TextBox)(GridView3.Rows[e.RowIndex].FindControl("TextBox5"))).Text);
            tea.IDnumber = ((TextBox)(GridView3.Rows[e.RowIndex].FindControl("TextBox6"))).Text;


            bll.UpdateById(ID, tea);
            GridView3.EditIndex = -1;
            teaInfobind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TeaBLL bll = new TeaBLL();
            TeaInfo tea = new TeaInfo();
            //TextBox temp = GridView1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
            //stu.stuID = temp.Text.ToString().Trim();((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[1])).Text.ToString().Trim();
            tea.TeaID = ((TextBox)(GridView3.FooterRow.FindControl("TextBox10"))).Text;
            tea.TeaName = ((TextBox)(GridView3.FooterRow.FindControl("TextBox11"))).Text;
            tea.TeaPwd = ((TextBox)(GridView3.FooterRow.FindControl("TextBox12"))).Text;
            tea.TeaSex = char.Parse(((TextBox)(GridView3.FooterRow.FindControl("TextBox13"))).Text);
            tea.TeaAge = Convert.ToInt32(((TextBox)(GridView3.FooterRow.FindControl("TextBox14"))).Text);
            tea.IDnumber = ((TextBox)(GridView3.FooterRow.FindControl("TextBox15"))).Text;
            bll.Insert(tea);
            teaInfobind();
        }

        protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView4.EditIndex = -1;
            comInfobind();
        }

        protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ComBLL bll = new ComBLL();
            //int ID = int.Parse(((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].FindControl("GridView1"))).Text.ToString().Trim());
            int ID = int.Parse(((TextBox)(GridView4.Rows[e.RowIndex].Cells[1].FindControl("TextBox1"))).Text);
            bll.DeleteById(ID);
            comInfobind();
        }

        protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView4.EditIndex = e.NewEditIndex;
            GridView4.ShowFooter = true;
            comInfobind();

        }

        protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            ComBLL bll = new ComBLL();
            ComInfo com = new ComInfo();

            //TextBox temp = GridView1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
            //stu.stuID = temp.Text.ToString().Trim();((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[1])).Text.ToString().Trim();
            com.ComId = int.Parse(((TextBox)(GridView4.Rows[e.RowIndex].Cells[1].FindControl("TextBox1"))).Text);
            com.ComUser = ((TextBox)(GridView4.Rows[e.RowIndex].Cells[1].FindControl("TextBox2"))).Text;
            com.ComPwd = ((TextBox)(GridView4.Rows[e.RowIndex].Cells[2].FindControl("TextBox3"))).Text;
            com.ComName = ((TextBox)(GridView4.Rows[e.RowIndex].Cells[3].FindControl("TextBox4"))).Text;
            com.ComType = ((TextBox)(GridView4.Rows[e.RowIndex].FindControl("TextBox5"))).Text;
            com.ComArea = ((TextBox)(GridView4.Rows[e.RowIndex].FindControl("TextBox6"))).Text;
            com.ComTel = ((TextBox)(GridView4.Rows[e.RowIndex].Cells[1].FindControl("TextBox7"))).Text;
            com.ComInfos = ((TextBox)(GridView4.Rows[e.RowIndex].Cells[2].FindControl("TextBox8"))).Text;
            com.Compeople = ((TextBox)(GridView4.Rows[e.RowIndex].Cells[1].FindControl("TextBox9"))).Text;
            com.FeedbackInfo = ((TextBox)(GridView4.Rows[e.RowIndex].Cells[2].FindControl("TextBox19"))).Text;
            bll.UpdateById(com);
            GridView3.EditIndex = -1;
            comInfobind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ComBLL bll = new ComBLL();
            ComInfo com = new ComInfo();
            //TextBox temp = GridView1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
            //stu.stuID = temp.Text.ToString().Trim();((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[1])).Text.ToString().Trim();
            com.ComId = int.Parse(((TextBox)(GridView4.FooterRow.FindControl("TextBox10"))).Text);
            com.ComUser = ((TextBox)(GridView4.FooterRow.FindControl("TextBox11"))).Text;
            com.ComPwd = ((TextBox)(GridView4.FooterRow.FindControl("TextBox12"))).Text;
            com.ComName = ((TextBox)(GridView4.FooterRow.FindControl("TextBox13"))).Text;
            com.ComType = ((TextBox)(GridView4.FooterRow.FindControl("TextBox14"))).Text;
            com.ComArea = ((TextBox)(GridView4.FooterRow.FindControl("TextBox15"))).Text;
            com.ComTel = ((TextBox)(GridView4.FooterRow.FindControl("TextBox10"))).Text;
            com.ComInfos = ((TextBox)(GridView4.FooterRow.FindControl("TextBox11"))).Text;
            com.Compeople = ((TextBox)(GridView4.FooterRow.FindControl("TextBox12"))).Text;
            com.FeedbackInfo = ((TextBox)(GridView4.FooterRow.FindControl("TextBox13"))).Text;
            bll.Insert(com);
            comInfobind();
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[11].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[3].Text + "\"吗?')");
                }
            }

        }

        protected void GridView5_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView5.EditIndex = -1;
            classInfobind();
        }

        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[1].Text + "\"吗?')");
                }
            }
        }

        protected void GridView5_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ClassBLL bll = new ClassBLL();
            //int ID = int.Parse(((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].FindControl("GridView1"))).Text.ToString().Trim());
            int ID = int.Parse(GridView5.Rows[e.RowIndex].Cells[0].Text);
            bll.DeleteById(ID);
            classInfobind();
        }

        protected void GridView5_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView5.EditIndex = e.NewEditIndex;
            GridView5.ShowFooter = true;
            classInfobind();
        }

        protected void GridView5_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ClassBLL bll = new ClassBLL();
            ClassInfo cla = new ClassInfo();
            cla.ID = int.Parse(((TextBox)(GridView5.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim());
            cla.ClassName = ((TextBox)(GridView5.Rows[e.RowIndex].Cells[1].FindControl("TextBox2"))).Text;
            cla.ClassTeacher = ((TextBox)(GridView5.Rows[e.RowIndex].Cells[1].FindControl("TextBox3"))).Text;
            cla.ClassGride = ((TextBox)(GridView5.Rows[e.RowIndex].Cells[2].FindControl("TextBox4"))).Text;
            cla.ClassMajor = ((TextBox)(GridView5.Rows[e.RowIndex].Cells[3].FindControl("TextBox5"))).Text;
            bll.UpdateById(cla);
            GridView5.EditIndex = -1;
            classInfobind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ClassBLL bll = new ClassBLL();
            ClassInfo cla = new ClassInfo();
            //TextBox temp = GridView1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
            //stu.stuID = temp.Text.ToString().Trim();((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[1])).Text.ToString().Trim();
            cla.ClassName = ((TextBox)(GridView5.FooterRow.FindControl("TextBox11"))).Text;
            cla.ClassTeacher = ((TextBox)(GridView5.FooterRow.FindControl("TextBox12"))).Text;
            cla.ClassGride = ((TextBox)(GridView5.FooterRow.FindControl("TextBox13"))).Text;
            cla.ClassMajor = ((TextBox)(GridView5.FooterRow.FindControl("TextBox14"))).Text;

            bll.Insert(cla);
            classInfobind();
        }

        protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView5.EditIndex = -1;

            GridView theGrid = (GridView)sender; // refer to the GridView 
            int newPageIndex = 0, txtNewPageIndex = 0;
            GridViewRow pagerRow = null;
            if (-2 == e.NewPageIndex)
            {
                // when click the "GO" Button 

                //GridViewRow pagerRow = theGrid.Controls[0].Controls[theGrid.Controls[0].Controls.Count - 1] as GridViewRow; // refer to PagerTemplate 
                pagerRow = theGrid.BottomPagerRow; //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow 
            }
            if (null != pagerRow)
            {
                txtNewPageIndex = Int16.Parse(((TextBox)pagerRow.FindControl("txtNewPageIndex")).Text); // refer to the TextBox with the NewPageIndex value 
            }


            if (0 != txtNewPageIndex)
            {
                newPageIndex = txtNewPageIndex - 1; // get the NewPageIndex 
            }

            else
            {
                // when click the first, last, previous and next Button 
                newPageIndex = e.NewPageIndex;
            }

            // check to prevent form the NewPageIndex out of the range 
            newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
            newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

            // specify the NewPageIndex 
            theGrid.PageIndex = newPageIndex;
            theGrid.PageIndex = newPageIndex;

            classInfobind();

        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[8].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[2].Text + "\"吗?')");
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[10].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[2].Text + "\"吗?')");
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[12].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[3].Text + "\"吗?')");
                }
            }
        }



        protected void Button6_Click(object sender, EventArgs e)
        {

            var xuan = Request.Form["xuan"].ToString();
            var search = Request.Form["search"].ToString();
            if (xuan != "" && search != "")
            {

                List<StuInfo> stulist = new List<StuInfo>();
                stuBLL stu = new stuBLL();
                stulist = stu.SelectStu(search);

                GridView1.DataSource = stulist;

                GridView1.DataBind();
            }
        }
     
    }
}