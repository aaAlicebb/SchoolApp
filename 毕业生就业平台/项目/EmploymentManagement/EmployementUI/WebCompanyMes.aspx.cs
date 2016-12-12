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
    public partial class WebCompanyMes : System.Web.UI.Page
    {
        public string ComId;
        public ComInfo com = new ComInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            ComId = Global.ComMes.ComId;
            ComInfoBLL bll = new ComInfoBLL();
            com = bll.SelectComInfoByID(Global.ComMes.ComId);
            if (!IsPostBack)
            {
                bindload();
                JianLbindload();
            }
        }
        private void bindload()
        {
            companyBLL bll = new companyBLL();
            List<companyInfo> list = new List<companyInfo>();
            list = bll.selectComInfoById(Global.ComMes.ComId);
            this.GridView1.DataSource = list;
            this.GridView1.DataBind();
        }
        public void JianLbindload()
        {
            ComInfo com = new ComInfo();
            ComInfoBLL combll = new ComInfoBLL();
            com = combll.SelectComInfoByID(Global.ComMes.ComId);
            ResumeInfoBLL blls = new ResumeInfoBLL();
            List<ResumeManner> lists = new List<ResumeManner>();
            lists = blls.selectByComName(com.ComName);
            this.GridView2.DataSource = lists;
            this.GridView2.DataBind();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (this.FileUpload1.HasFile)
            {
                string extension = String.Empty;
                extension = System.IO.Path.GetExtension(FileUpload1.FileName.ToLower());
                string[] extensions = { ".jpg" };
                bool fileType = false;
                for (int i = 0; i < extensions.Length; i++)
                {
                    if (extension == extensions[i])
                    {
                        fileType = true;
                        break;
                    }
                }
                if (fileType)
                {
                    //string ss;
                    //ss = System.IO.Path.GetFullPath(FileUpload1.FileName.ToLower());//获取文件路径
                    string path = Server.MapPath("~");
                    string fileName = this.FileUpload1.PostedFile.FileName;
                    this.FileUpload1.PostedFile.SaveAs(path + "\\files\\" + fileName);
                    string ss = "files\\" + FileUpload1.FileName;

                    int len = this.FileUpload1.PostedFile.ContentLength; // 图片大小
                    byte[] pic;
                    pic = new byte[len]; // 创建一个字节数组，大小为图片的大小，数据库中就存储这个东西  
                    this.FileUpload1.PostedFile.InputStream.Read(pic, 0, len); // 把上传控件中的文件用二进制读取存到pic字节数组中  

                    ComInfoBLL bll = new ComInfoBLL();
                    int res = bll.updateComImg(pic, Global.ComMes.ComId.ToString());
                    if (res > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>tpxs(" + ss + ")</script>");
                        // Response.Write(ss);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>text()</script>");
                    }
                }
                else
                {
                    Response.Write("no");
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.FileUpload2.HasFile)
            {
                string extension = String.Empty;
                extension = System.IO.Path.GetExtension(FileUpload2.FileName.ToLower());
                string[] extensions = { ".jpg" };
                bool fileType = false;
                for (int i = 0; i < extensions.Length; i++)
                {
                    if (extension == extensions[i])
                    {
                        fileType = true;
                        break;
                    }
                }
                if (fileType)
                {
                    //string ss;
                    //ss = System.IO.Path.GetFullPath(FileUpload2.FileName.ToLower());//获取文件路径
                    string path = Server.MapPath("~");
                    string fileName = this.FileUpload2.PostedFile.FileName;
                    this.FileUpload2.PostedFile.SaveAs(path + "\\files\\" + fileName);
                    string ss = "files\\" + FileUpload2.FileName;

                    int len = this.FileUpload2.PostedFile.ContentLength; // 图片大小
                    byte[] pic;
                    pic = new byte[len]; // 创建一个字节数组，大小为图片的大小，数据库中就存储这个东西  
                    this.FileUpload2.PostedFile.InputStream.Read(pic, 0, len); // 把上传控件中的文件用二进制读取存到pic字节数组中  

                    ComInfoBLL bll = new ComInfoBLL();
                    int res = bll.updateComImg(pic, Global.ComMes.ComId.ToString());
                    if (res > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>tpxs(" + ss + ")</script>");
                        // Response.Write(ss);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>text()</script>");
                    }
                }
                else
                {
                    Response.Write("no");
                }
            }
        }
        /// <summary>
        /// gridview1删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void BtnDeletes(object sender, EventArgs e)
        {

            DateTime times;
            string name;
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.Parent.Parent;
            times = DateTime.Parse(row.Cells[4].Text);
            name = row.Cells[1].Text;
            //Response.Write(name + times);
            companyBLL bll = new companyBLL();
            int count = bll.DeleteByTimeAndName(name, times);
            if (count > 0)
            {
                bindload();
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功');</script>");
            }
            else
            {
                bindload();
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败，请联系管理员');</script>");
            }
        }

        /// <summary>
        /// gridview2查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LookIt(object sender, EventArgs e)
        {
            string name;
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.Parent.Parent;
            name = row.Cells[1].Text;
            //Response.Write(name);
            string url = "WebMyjianli.aspx?comName=" + name;
            Response.Redirect(url);

        }
        /// <summary>
        /// gridview2删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void BtnDelT(object sender, EventArgs e)
        {

            string name;
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.Parent.Parent;
            name = row.Cells[1].Text;
            //Response.Write(name + times);
            ResumeInfoBLL bll = new ResumeInfoBLL();
            int count = bll.deltByRecIds(name);
            if (count > 0)
            {
                JianLbindload();
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功');</script>");
            }
            else
            {
                JianLbindload();
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败，请联系管理员');</script>");
            }
        }
    }
}