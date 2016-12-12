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
    public partial class RoomUpdate : Form
    {
        public fmRoomManager manner;
        int id;
        public RoomUpdate(fmRoomManager fm, string str)
        {
            manner = fm;
            id = int.Parse(str);
            InitializeComponent();
        }

        Point mouseOff;
        bool left;
        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            RoomInfo room = new RoomInfo();
            room.r_id = int.Parse(this.txtRoomId.Text.ToString());//房间号
            room.r_price = int.Parse(this.txtRoomPrice.Text.ToString());//单价
            room.r_bed = int.Parse(this.txtRoomBed.Text.ToString());//床位数
            room.r_type = this.cmbRoomType.SelectedItem.ToString();//房间类型
            room.r_remark = this.txtRoomRemark.Text.ToString();//备注
            room.phone = this.txtRoomPhone.Text.Trim();//电话号码 
            room.r_floatid = int.Parse(this.txtRoomFloat.Text.Trim());//楼层号
            RoomInfoBLL bll = new RoomInfoBLL();
            if (id != room.r_id)//房间号有更改
            {
                int count = bll.PdRoomIdExist(room.r_id);
                if (count == 1)
                {
                    new showMessagecs("系统提示", "该房间号已存在").ShowDialog();
                }
                else 
                {
                    int result = bll.RoomUpdate(room, id);
                   
                    
                        if (result == 1)
                        {
                            new showMessageok("系统提示", "房间信息更新成功").ShowDialog();
                            manner.ListLoad();
                            this.Close();
                        }
                        else
                        {
                            new showMessagecs("系统提示", "房间信息更新失败").ShowDialog();
                        }
                    
                    
                }
            }
            else 
            {
                int result = bll.RoomUpdate(room,id);
                if (result == 1)
                {
                    new showMessageok("系统提示", "房间信息更新成功").ShowDialog();
                    manner.ListLoad();
                    this.Close();
                }
                else
                {
                    new showMessagecs("系统提示", "房间信息更新失败").ShowDialog();
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (left)
            {
                left = false;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (left)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                left = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 房间信息加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomUpdate_Load(object sender, EventArgs e)
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            RoomInfo room = new RoomInfo();
            room = bll.selectByRoomId(id);
            txtRoomBed.Text = room.r_bed.ToString();
            txtRoomFloat.Text = room.r_floatid.ToString();
            txtRoomId.Text = room.r_id.ToString();
            txtRoomPhone.Text = room.phone.ToString();
            txtRoomPrice.Text = room.r_price.ToString();
            txtRoomRemark.Text = room.r_remark.ToString();
            cmbRoomType.Text = room.r_type.ToString();
            textBox3.Text = room.r_price.ToString();
        }
    }
}
