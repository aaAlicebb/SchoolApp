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

namespace Hotel.UI
{
    public partial class fmAddUser : Form
    {
        string RoomId;
        string InNumber;
        fmUser fms;
        fmInAlter inalter;
        string txtfriend;
        private int totol;
        int fs;
        public fmAddUser(string id,string number,fmUser fm)
        {
            fms = fm;
            fs = 0;
            this.RoomId = id;
            this.InNumber = number;
            InitializeComponent();
        }
        public fmAddUser(string id, string number, fmInAlter fm)
        {
            fs = 1;
            inalter = fm;
            this.RoomId = id;
            this.InNumber = number;
            InitializeComponent();
        }
        /// <summary>
        /// 窗体关闭最小化取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 窗体可拖动
        /// </summary>
        Point mouseOff;
        bool leftFlag1;
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                leftFlag1 = false;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag1 = true;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }

        private void fmAddUser_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                leftFlag1 = false;
            }
        }

        private void fmAddUser_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag1 = true;
            }
        }

        private void fmAddUser_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }

        private void fmAddUser_Load(object sender, EventArgs e)
        {
          
            AddLode();
        }

        public void AddLode()
        {
            TxtUserAddress.Text = "";
            TxtUserName.Text = "";
            TxtUserPhone.Text = "";
            TxtZJNumber.Text = ""; 
            InFriendWithBLL blls = new InFriendWithBLL();
            List<InFriendInfo> list = new List<InFriendInfo>();
            list = blls.SelectInfo(InNumber, RoomId);
            totol = list.Count + 1;
            if (list.Count>0)
            {
                TxtUserName.Text = list[0].c_name;
                TxtSex.Text = list[0].c_sex;
                TxtUserAddress.Text = list[0].c_address;
                TxtUserPhone.Text = list[0].C_Phone;
                TxtZJNumber.Text = list[0].zj_number;
                comZJtype.Text = list[0].zj_type;
            }
        }
        
        private void BtnSave_Click(object sender, EventArgs e)//保存同住客人
        {
            if (fs == 0)
            {
                saveLodeZero();
            }
            else 
            {
                saveLodeOne();
            }
            
                                                       
        }
        /// <summary>
        /// fz==0
        /// </summary>
        private void saveLodeZero()
        {
            InFriendInfo friend = new InFriendInfo();
            if (TxtUserAddress.Text != "" && TxtUserName.Text != "" && TxtUserPhone.Text != "" && TxtZJNumber.Text != "")
            {
                friend.c_address = TxtUserAddress.Text;
                friend.c_name = TxtUserName.Text;
                friend.C_Phone = TxtUserPhone.Text;
                if (TxtSex.SelectedIndex >= 0)
                {
                    friend.c_sex = TxtSex.SelectedItem.ToString();
                }
                else
                {
                    friend.c_sex = "男";
                }
                if (comZJtype.SelectedIndex >= 0)
                {
                    friend.zj_type = comZJtype.SelectedItem.ToString();
                }
                else
                {
                    friend.zj_type = "身份证";
                }
                friend.RoomId = RoomId;
                friend.in_number = InNumber;//入住单号
                friend.zj_number = TxtZJNumber.Text;

                InFriendWithBLL bll = new InFriendWithBLL();
               int result= bll.SelectExist(InNumber,RoomId,friend.zj_number);
               if (result > 0)
               {
                   new showMessagecs("系统提示", "该客人已存在").ShowDialog();
               }
               else 
               {
                   int count = bll.insertInfo(friend);
                   if (count > 0)
                   {
                       new showMessageok("系统提示", "保存成功").ShowDialog();
                       totol = totol + 1;
                       fms.numericUpDown1.Value = totol;//改变人数的值
                       txtfriend = fms.textBox5.Text;
                       if (txtfriend == "" || txtfriend.Equals("无"))
                       {
                           txtfriend = "";
                           txtfriend = "[" + TxtUserName.Text + "," + TxtZJNumber.Text + "]";
                           fms.textBox5.Text = txtfriend;
                       }
                       else
                       {
                           txtfriend = fms.textBox5.Text;
                           txtfriend = txtfriend + "," + "[" + TxtUserName.Text + "," + TxtZJNumber.Text + "]";
                           fms.textBox5.Text = txtfriend;
                       }
                   }
                   else
                   {
                       new showMessagecs("系统提示", "保存失败").ShowDialog();
                   }
               }
                
            }
            else
            {
                new showMessagecs("系统提示", "请将信息显示完整").ShowDialog();
            }
        }
        /// <summary>
        /// fs=1
        /// </summary>
        private void saveLodeOne()
        {
            InFriendInfo friend = new InFriendInfo();
            if (TxtUserAddress.Text != "" && TxtUserName.Text != "" && TxtUserPhone.Text != "" && TxtZJNumber.Text != "")
            {
                friend.c_address = TxtUserAddress.Text;
                friend.c_name = TxtUserName.Text;
                friend.C_Phone = TxtUserPhone.Text;
                if (TxtSex.SelectedIndex >= 0)
                {
                    friend.c_sex = TxtSex.SelectedItem.ToString();
                }
                else
                {
                    friend.c_sex = "男";
                }
                if (comZJtype.SelectedIndex >= 0)
                {
                    friend.zj_type = comZJtype.SelectedItem.ToString();
                }
                else
                {
                    friend.zj_type = "身份证";
                }
                friend.RoomId = RoomId;
                friend.in_number = InNumber;//入住单号
                friend.zj_number = TxtZJNumber.Text;

                InFriendWithBLL bll = new InFriendWithBLL();
                int result = bll.SelectExist(InNumber, RoomId, friend.zj_number);
                if (result > 0)
                {
                    new showMessagecs("系统提示", "该客人已存在").ShowDialog();
                }
                else 
                {
                    int count = bll.insertInfo(friend);
                    if (count > 0)
                    {
                        new showMessageok("系统提示", "保存成功").ShowDialog();
                        totol = totol + 1;
                        inalter.numericUpDown1.Value = totol;//改变人数的值
                        txtfriend = inalter.txtFriend.Text;
                        if (txtfriend == "" || txtfriend.Equals("无"))
                        {
                            txtfriend = "";
                            txtfriend = "[" + TxtUserName.Text + "," + TxtZJNumber.Text + "]";
                            inalter.txtFriend.Text = txtfriend;
                        }
                        else
                        {
                            txtfriend = inalter.txtFriend.Text;
                            txtfriend = txtfriend + "," + "[" + TxtUserName.Text + "," + TxtZJNumber.Text + "]";
                            inalter.txtFriend.Text = txtfriend;
                        }
                    }
                    else
                    {
                        new showMessagecs("系统提示", "保存失败").ShowDialog();
                    }
                }
                
            }
            else
            {
                new showMessagecs("系统提示", "请将信息显示完整").ShowDialog();
            }
        }
        /// <summary>
        /// 保存并添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveAndAdd_Click(object sender, EventArgs e)//保存并添加
        {
            if (fs == 0)
            {
                saveAndAddZero();
                TxtUserAddress.Text = "";
                TxtUserName.Text = "";
                TxtUserPhone.Text = "";
                TxtZJNumber.Text = "";

            }
            else 
            {
                saveLodeOne();
                TxtUserAddress.Text = "";
                TxtUserName.Text = "";
                TxtUserPhone.Text = "";
                TxtZJNumber.Text = "";
            }
                              
        }
        /// <summary>
        /// fs==0
        /// </summary>
        private void saveAndAddZero()
        {
            InFriendInfo friend = new InFriendInfo();
            if (TxtUserAddress.Text != "" && TxtUserName.Text != "" && TxtUserPhone.Text != "" && TxtZJNumber.Text != "")
            {
                friend.c_address = TxtUserAddress.Text;
                friend.c_name = TxtUserName.Text;
                friend.C_Phone = TxtUserPhone.Text;
                if (TxtSex.SelectedIndex >= 0)
                {
                    friend.c_sex = TxtSex.SelectedItem.ToString();
                }
                else
                {
                    friend.c_sex = "男";
                }
                if (comZJtype.SelectedIndex >= 0)
                {
                    friend.zj_type = comZJtype.SelectedItem.ToString();
                }
                else
                {
                    friend.zj_type = "身份证";
                }
                friend.RoomId = RoomId;
                friend.in_number = InNumber;//入住单号
                friend.zj_number = TxtZJNumber.Text;

                InFriendWithBLL bll = new InFriendWithBLL();
                int result = bll.SelectExist(InNumber, RoomId, friend.zj_number);
                if (result > 0)
                {
                    new showMessagecs("系统提示", "该客人已存在").ShowDialog();
                }
                else 
                {
                    int count = bll.insertInfo(friend);
                    if (count > 0)
                    {
                        new showMessageok("系统提示", "保存成功").ShowDialog();
                        totol = totol + 1;
                        fms.numericUpDown1.Value = totol;//改变人数的值
                        txtfriend = fms.textBox5.Text;
                        if (txtfriend == "" || txtfriend.Equals("无"))
                        {
                            txtfriend = "";
                            txtfriend = "[" + TxtUserName.Text + "," + TxtZJNumber.Text + "]";
                            fms.textBox5.Text = txtfriend;
                        }
                        else
                        {
                            txtfriend = fms.textBox5.Text;
                            txtfriend = txtfriend + "," + "[" + TxtUserName.Text + "," + TxtZJNumber.Text + "]";
                            fms.textBox5.Text = txtfriend;
                        }
                        TxtUserAddress.Text = "";
                        TxtUserName.Text = "";
                        TxtUserPhone.Text = "";
                        TxtZJNumber.Text = "";
                    }
                    else
                    {
                        new showMessagecs("系统提示", "保存失败").ShowDialog();
                    }
                }
                
            }
            else
            {
                new showMessagecs("系统提示", "请将信息显示完整").ShowDialog();
            }
            TxtUserAddress.Text = "";
            TxtUserName.Text = "";
            TxtUserPhone.Text = "";
            TxtZJNumber.Text = "";
        }
        /// <summary>
        /// fs=1
        /// </summary>
        private void saveAndAddOne()
        {
            InFriendInfo friend = new InFriendInfo();
            if (TxtUserAddress.Text != "" && TxtUserName.Text != "" && TxtUserPhone.Text != "" && TxtZJNumber.Text != "")
            {
                friend.c_address = TxtUserAddress.Text;
                friend.c_name = TxtUserName.Text;
                friend.C_Phone = TxtUserPhone.Text;
                if (TxtSex.SelectedIndex >= 0)
                {
                    friend.c_sex = TxtSex.SelectedItem.ToString();
                }
                else
                {
                    friend.c_sex = "男";
                }
                if (comZJtype.SelectedIndex >= 0)
                {
                    friend.zj_type = comZJtype.SelectedItem.ToString();
                }
                else
                {
                    friend.zj_type = "身份证";
                }
                friend.RoomId = RoomId;
                friend.in_number = InNumber;//入住单号
                friend.zj_number = TxtZJNumber.Text;

                InFriendWithBLL bll = new InFriendWithBLL();
                int result = bll.SelectExist(InNumber, RoomId, friend.zj_number);
                if (result > 0)
                {
                    new showMessagecs("系统提示", "该客人已存在").ShowDialog();
                }
                else 
                {
                    int count = bll.insertInfo(friend);
                    if (count > 0)
                    {
                        new showMessageok("系统提示", "保存成功").ShowDialog();
                        totol = totol + 1;
                        inalter.numericUpDown1.Value = totol;//改变人数的值
                        txtfriend = inalter.txtFriend.Text;
                        if (txtfriend == "" || txtfriend.Equals("无"))
                        {
                            txtfriend = inalter.txtFriend.Text;
                            txtfriend = "[" + TxtUserName.Text + "," + TxtZJNumber.Text + "]";
                            inalter.txtFriend.Text = txtfriend;
                        }
                        else
                        {
                            txtfriend = inalter.txtFriend.Text;
                            txtfriend = txtfriend + "," + "[" + TxtUserName.Text + "," + TxtZJNumber.Text + "]";
                            inalter.txtFriend.Text = txtfriend;
                        }
                        TxtUserAddress.Text = "";
                        TxtUserName.Text = "";
                        TxtUserPhone.Text = "";
                        TxtZJNumber.Text = "";
                    }
                    else
                    {
                        new showMessagecs("系统提示", "保存失败").ShowDialog();
                    }
                }
                
            }
            else
            {
                new showMessagecs("系统提示", "请将信息显示完整").ShowDialog();
            }
            TxtUserAddress.Text = "";
            TxtUserName.Text = "";
            TxtUserPhone.Text = "";
            TxtZJNumber.Text = "";
        }
        /// <summary>
        /// 删除客人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)//删除客人
        {
            if (fs == 0)
            {
                deleteZero();
            }
            else 
            {
                deleteOne();
            }
            

        }
        /// <summary>
        /// fs=0客人登记
        /// </summary>
        private void deleteZero()
        {
            if (TxtUserAddress.Text != "" && TxtUserName.Text != "" && TxtUserPhone.Text != "" && TxtZJNumber.Text != "")
            {
                InFriendWithBLL bll = new InFriendWithBLL();
                int count = bll.DeleteInfo(InNumber, RoomId, TxtUserName.Text.Trim());
                if (count > 0)
                {
                    new showMessageok("系统提示", "删除成功").ShowDialog();
                    totol = totol - 1;
                    fms.numericUpDown1.Value = totol;//改变人数的值
                    AddLode();
                    InFriendWithBLL bllss = new InFriendWithBLL();
                    List<InFriendInfo> list = new List<InFriendInfo>();
                    list = bllss.SelectInfo(InNumber, RoomId);
                    txtfriend = "";
                    if (list.Count>0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (i == 0)
                            {
                                txtfriend = txtfriend + "[" + list[i].c_name + "," + list[i].zj_number + "]";
                            }
                            else
                            {
                                txtfriend = txtfriend + "," + "[" + list[i].c_name + "," + list[i].zj_number + "]";
                            }

                        }
                        fms.textBox5.Text = txtfriend;
                    }
                    else
                    {
                        fms.textBox5.Text = "无";
                        TxtUserAddress.Text = "";
                        TxtUserName.Text = "";
                        TxtUserPhone.Text = "";
                        TxtZJNumber.Text = "";
                    }

                }
                else
                {
                    new showMessagecs("系统提示", "删除失败").ShowDialog();
                }
            }
            else
            {
                new showMessagecs("系统提示", "没有客人信息！").ShowDialog();
            }
        }
        /// <summary>
        /// fs=1客人登记修改
        /// </summary>
        private void deleteOne()
        {
            if (TxtUserAddress.Text != "" && TxtUserName.Text != "" && TxtUserPhone.Text != "" && TxtZJNumber.Text != "")
            {
                InFriendWithBLL bll = new InFriendWithBLL();
                int count = bll.DeleteInfo(InNumber, RoomId, TxtUserName.Text.Trim());
                if (count > 0)
                {
                    new showMessageok("系统提示", "删除成功").ShowDialog();
                    totol = totol - 1;
                    inalter.numericUpDown1.Value = totol;//改变人数的值
                    AddLode();
                    InFriendWithBLL bllss = new InFriendWithBLL();
                    List<InFriendInfo> list = new List<InFriendInfo>();
                    list = bllss.SelectInfo(InNumber, RoomId);
                    txtfriend = "";
                    if (list != null)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (i == 0)
                            {
                                txtfriend = txtfriend + "[" + list[i].c_name + "," + list[i].zj_number + "]";
                            }
                            else
                            {
                                txtfriend = txtfriend + "," + "[" + list[i].c_name + "," + list[i].zj_number + "]";
                            }

                        }
                        inalter.txtFriend.Text = txtfriend;
                    }
                    else
                    {
                        fms.textBox5.Text = "无";
                        TxtUserAddress.Text = "";
                        TxtUserName.Text = "";
                        TxtUserPhone.Text = "";
                        TxtZJNumber.Text = "";
                    }

                }
                else
                {
                    new showMessagecs("系统提示", "删除失败").ShowDialog();
                }
            }
            else
            {
                new showMessagecs("系统提示", "没有客人信息！").ShowDialog();
            }
        }
    }
}
