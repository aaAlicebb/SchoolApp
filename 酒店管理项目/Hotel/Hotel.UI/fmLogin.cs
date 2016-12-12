using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.Model;
using Hotel.BLL;

namespace Hotel.UI
{
    public partial class fmLogin : Form
    {
        private fmMain fms;
        public fmLogin()
        {
            InitializeComponent();
        }
        public fmLogin(fmMain fms)
        {
            InitializeComponent();
            this.fms = fms;
        }
        /// <summary>
        /// 窗体移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        Point mouseOff;
        bool leftFlag;
        private void fmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        private void fmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  
                Location = mouseSet;
            }
        }

        private void fmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); 
                leftFlag = true;                  
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmLogin_Load(object sender, EventArgs e)
        {
            
        }

       
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if(fms!=null)
            {
                this.Hide();
                fms.Show();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fms != null)
            {
                this.Hide();
                fms.Show();
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.fms != null)
            {
                if (textUserName.Text == "" || textPwd.Text == "")
                {
                    new showMessagecs("系统提示", "账户或密码不允许为空!").ShowDialog();
                }
                else
                {
                    UserInfoBLL bll = new UserInfoBLL();
                    UserInfo user = new UserInfo();
                    user = bll.Login(textUserName.Text.Trim());
                   
                    if (user == null)
                    {
                        new showMessagecs("系统提示", "该账号不存在!").ShowDialog();
                    }
                    else if (textUserName.Text.Equals(user.UserName) && textPwd.Text.Equals(user.UserPwd))
                    {
                        this.Hide();
                        Global.user = user;
                        fms.Show();
                        
                    }
                    else
                    {
                        new showMessagecs("系统提示", "账号密码错误!").ShowDialog();
                    }
                }
            }
            else 
            {
                if (textUserName.Text == "" || textPwd.Text == "")
                {
                    new showMessagecs("系统提示", "账户或密码不允许为空!").ShowDialog();
                }
                else
                {
                    UserInfoBLL bll = new UserInfoBLL();
                    UserInfo user = new UserInfo();
                    user = bll.Login(textUserName.Text.Trim());
                    Global.user = user;
                    if (user == null)
                    {
                        new showMessagecs("系统提示", "该账号不存在!").ShowDialog();
                    }
                    else if (textUserName.Text.Equals(user.UserName) && textPwd.Text.Equals(user.UserPwd))
                    {
                        //fmMain dm = new fmMain(user);
                        //dm.Show();
                        //this.Hide();
                        this.Hide();
                        fmProgress pro = new fmProgress(user);
                        pro.ShowDialog();
                       

                    }
                    else
                    {
                        new showMessagecs("系统提示", "账号密码错误!").ShowDialog();
                    }
                }      
            }
                          
        }

        private void fmLogin_Activated(object sender, EventArgs e)
        {
            textUserName.Focus();
        }
                 
    }
}
