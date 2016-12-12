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
    public partial class webTeacherSelfMes : System.Web.UI.Page
    {
        public string teaIDS="10086";
        public TeaInfo tea;
        protected void Page_Load(object sender, EventArgs e)
        {
            teaIDS = Global.TeaMes.TeaId;
            TeaInfoBLL bll = new TeaInfoBLL();
            tea=bll.selectById(Global.TeaMes.TeaId);
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

                    TeaInfoBLL bll = new TeaInfoBLL();
                    int res = bll.updateTeaImg(pic, Global.TeaMes.TeaId);
                    if (res > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>tpxs(" + ss + ")</script>");
                        //Response.Write(ss);
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

                    TeaInfoBLL bll = new TeaInfoBLL();
                    int res = bll.updateTeaImg(pic, Global.TeaMes.TeaId);
                    if (res > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>tpxs(" + ss + ")</script>");
                        //Response.Write(ss);
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
    }
}