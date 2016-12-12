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
using System.Collections;

namespace Hotel.UI
{
    public partial class fmRoomManager : Form
    {
        public fmRoomManager()
        {
            InitializeComponent();
        }
/// <summary>
/// 窗体关闭最小化
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
        /// <summary>
        /// 窗体可拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        Point mouseOff;
        bool left;
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
/// <summary>
/// 退出按钮
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RoomAdd add = new RoomAdd(this);
            add.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                new showMessagecs("系统提示", "请选择!").ShowDialog();
            }
            else
            {
                string str = listView1.SelectedItems[0].Text.ToString();
                RoomInfo room = new RoomInfo();
                RoomInfoBLL bll = new RoomInfoBLL();
                room = bll.selectByRoomId(int.Parse(str));
                if (room.r_state.Equals("1") || room.r_state.Equals("3") || room.r_state.Equals("4"))
                {
                    new showMessagecs("系统提示", "该房间有入住或预定信息!").ShowDialog();
                }
                else 
                {
                    RoomUpdate update = new RoomUpdate(this, str);//传值到update
                    update.ShowDialog();
                }               
            }

        }
        /// <summary>
        /// 删除房间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            RoomInfo room = new RoomInfo();
            int roomid = int.Parse(listView1.SelectedItems[0].Text);
            new showMessage("系统提示", "你确定要删除房间？"+roomid.ToString()).ShowDialog();
            if (showMessage.result.Equals(true))
            {
                room = bll.selectByRoomId(roomid);
                if (room.r_state.Equals("1") || room.r_state.Equals("3") || room.r_state.Equals("4"))
                {
                    new showMessagecs("系统提示", "该房间有入住或预定信息!").ShowDialog();
                }
                else
                {
                    int result = bll.RoomDelet(roomid);
                    if (result == 1)
                    {
                        new showMessageok("系统提示", "删除成功!").ShowDialog();
                        ListLoad();
                    }
                    else
                    {
                        new showMessagecs("系统提示", "删除失败!").ShowDialog();
                    }
                }
               
            }
            else 
            {
               
            }
        }
        /// <summary>
        /// 房间管理加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void fmRoomManager_Load(object sender, EventArgs e)
        {
            ListLoad();
        }

        public void ListLoad()
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            List<RoomInfo> list = new List<RoomInfo>();
            list = bll.RoomLode();
            this.listView1.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                listView1.Items.Add(list[i].r_id.ToString());
                listView1.Items[i].SubItems.Add(list[i].r_type.ToString());
                listView1.Items[i].SubItems.Add(list[i].r_price.ToString());
                listView1.Items[i].SubItems.Add(list[i].r_floatid.ToString());
                listView1.Items[i].SubItems.Add(list[i].r_bed.ToString());
                listView1.Items[i].SubItems.Add(list[i].r_remark.ToString());
            }
        }
    }
}
