using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.BLL;
using Hotel.Model;
using System.Collections;

namespace Hotel.UI
{
    public partial class fmAcgtcs : Form
    {
        public fmAcgtcs()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 关闭最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmAcgtcs_Load(object sender, EventArgs e)
        {
            listLode();

        }

        public void listLode()
        {
            this.listView1.Items.Clear();
            UserInfoBLL bll = new UserInfoBLL();
            List<UserInfo> list = new List<UserInfo>();
            list = bll.selectAll();
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    ListViewItem item = new ListViewItem(list[i].UserName);
                    item.SubItems.Add(list[i].UserType);
                    item.SubItems.Add(list[i].UserBM);
                    this.listView1.Items.Add(item);
                }
            }
        }
        Point mouseOff;
        bool leftFlag;
        private void fmAcgtcs_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        private void fmAcgtcs_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }

        private void fmAcgtcs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string acount = this.listView1.SelectedItems[0].SubItems[0].Text;
            UserInfoBLL bll = new UserInfoBLL();
            UserInfo user = new UserInfo(); 
            user = bll.selectById(acount);
            txtAccount.Text = user.UserName.ToString();
            cbBM.Text = user.UserBM.ToString();
            cbType.Text = user.UserType.ToString();
            txtPwd.Text = user.UserPwd.ToString();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            UserInfo user = new UserInfo();
            user.UserName = txtAccount.Text;
            user.UserPwd = txtPwd.Text;
            user.UserPwd = txtReMiMa.Text;
            user.UserType = cbType.Text;
            user.UserBM = cbBM.Text;
            UserInfoBLL bll = new UserInfoBLL();
            int result = bll.userExist(user);
             if (txtPwd.Text.Trim() == txtReMiMa.Text.Trim())
            {
                if (result == 1)
                {
                    new showMessagecs("系统提示", "该用户已存在！").ShowDialog();
                }
                else
                {
                    int results = bll.userAdd(user);
                    if (results == 1)
                    {

                        new showMessageok("系统提示", "添加成功！").ShowDialog();
                        listLode();
                        txtAccount.Text = "";
                        txtPwd.Text = "";
                        txtReMiMa.Text = "";
                        cbType.Text = "";
                        cbBM.Text = "";
                    }
                    else
                    {
                        new showMessagecs("系统提示", "添加失败！").ShowDialog();
                    }
                }
            }
             else
             {
                 new showMessagecs("系统提示", "密码不一致！").ShowDialog();
             }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            string inder = "";
            if (this.listView1.SelectedItems.Count > 0)
            {
                inder = this.listView1.SelectedItems[0].SubItems[0].Text;                
                UserInfoBLL bll = new UserInfoBLL();
                UserInfo user = new UserInfo();
                user.UserName = inder;
                int count = bll.userDelect(user);
                if (count >= 0)
                {
                    new showMessage("系统提示", "确定要删除该账户吗？").ShowDialog();
                    if (showMessage.result.Equals(true))
                    {
                        new showMessageok("系统提示", "删除成功！").ShowDialog();
                    
                        fmAcgtcs f = new fmAcgtcs();
                        listLode();
                        txtAccount.Text = "";
                        txtPwd.Text = "";
                        txtReMiMa.Text = "";
                        cbType.Text = "";
                        cbBM.Text = "";
                    }
                    else { }
                }
                else
                {
                    new showMessagecs("系统提示", "删除失败！").ShowDialog();
                }

            }

        }
        /// <summary>
        /// 更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if(txtAccount.Text==""||txtPwd.Text==""||txtReMiMa.Text==""||cbBM.Text==""||cbType.Text=="")
            {
                new showMessagecs("系统提示","请将信息填写完整！").ShowDialog();
            }
            else
            {
            UserInfo user = new UserInfo();
            user.UserName = txtAccount.Text;
            user.UserPwd = txtPwd.Text;
            user.UserPwd = txtReMiMa.Text;
            user.UserType = cbType.Text;
            user.UserBM = cbBM.Text;
            UserInfoBLL bll = new UserInfoBLL();
            int result = bll.userUp(user);
            if (txtPwd.Text.Trim() == txtReMiMa.Text.Trim())
            {
                if (result == 1)
                {
                    new showMessageok("系统提示", "账户信息更新成功！").ShowDialog();
                    listLode();
                    txtAccount.Text = "";
                    txtPwd.Text = "";
                    txtReMiMa.Text="";
                    cbType.Text = "";
                    cbBM.Text = "";
                }
                else
                {
                    new showMessagecs("系统提示", "账户信息更新失败！").ShowDialog();
                }
            }
            else
            {
                new showMessagecs("系统提示", "密码不一致或不能为空！").ShowDialog();
            }
                
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }
    }
}