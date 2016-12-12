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
    public partial class RoomAdd : Form
    {
        public fmRoomManager fm;
        public RoomAdd(fmRoomManager fms)
        {
            fm = fms;
            InitializeComponent();
        }
        /// <summary>
        /// 窗体最小化关闭
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
        /// 窗体上方panel可拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        Point mouseOff;
        bool left;
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (left)
            {
                left = false;
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

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (left)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            
            RoomInfo room = new RoomInfo();
            room.r_id = int.Parse(this.txtRoomId.Text.ToString());//房间号
            room.r_price = int.Parse(this.txtRoomPrice.Text.ToString());//单价
            room.r_state = "0";//默认房间状态为0，即空房
            room.r_bed = int.Parse(this.txtRoomBed.Text.ToString());//床位数
            room.r_type = this.cmbRoomType.SelectedItem.ToString();//房间类型
            room.r_remark = this.txtRoomRemark.Text.ToString();//备注
            room.freebed = int.Parse(this.txtRoomBed.Text.ToString());//剩余床位数
            room.phone = this.txtRoomPhone.Text.Trim();//电话号码 
            room.r_floatid =int.Parse(this.txtRoomFloat.Text.Trim());//楼层号
            RoomInfoBLL bll = new RoomInfoBLL();
            int count=bll.PdRoomIdExist(room.r_id);
            if (count == 1)
            {
                new showMessagecs("系统提示", "该房间号已存在").ShowDialog();
            }
            else 
            {
                int result = bll.RoomAdd(room);
                if (result == 1)
                {
                    fm.ListLoad();
                    new showMessageok("系统提示", "添加成功！").ShowDialog();                    
                    this.Close();
                }
                else
                {
                    new showMessagecs("系统提示", "添加失败！").ShowDialog();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
