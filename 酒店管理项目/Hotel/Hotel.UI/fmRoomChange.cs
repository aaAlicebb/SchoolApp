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
    public partial class fmRoomChange : Form
    {
        private string RoomId;
        private fmMain fm;
        InInfo user = new InInfo();
        public fmRoomChange()
        {
            InitializeComponent();
        }
        public fmRoomChange(string id,fmMain fms)
        {
            RoomId = id;
            fm = fms;
            InitializeComponent();
        }
        /// <summary>
        /// 窗体关闭最小化取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 窗体可拖动
        /// </summary>
        Point mouseOff;
        bool leftFlag;

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
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

        private void fmRoomChange_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        private void fmRoomChange_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }

        }

        private void fmRoomChange_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtNRoomId.Text != "" && txtNRoomPrice.Text != "")
                {

                    RoomInfoBLL bll = new RoomInfoBLL();
                    RoomInfo room = new RoomInfo();
                    room = bll.selectByRoomId(int.Parse(txtNRoomId.Text));
                    int counts= bll.PdRoomIdExist(int.Parse(txtNRoomId.Text.ToString()));
                    if (counts == 0)
                    {
                        new showMessagecs("系统提示", "该房不存在").ShowDialog();
                    }
                    else 
                    {
                        if (!room.r_state.Equals("0"))
                        {
                            new showMessagecs("系统提示", "不是空房不能入住!").ShowDialog();
                        }
                        else
                        {
                            user.r_RelPrice = double.Parse(txtNRoomPrice.Text);
                            user.r_id = int.Parse(txtNRoomId.Text);
                            BLLcustomer cus = new BLLcustomer();
                            int count = cus.updateSpanById(RoomId, txtNRoomId.Text);
                            if (count >= 0)
                            {
                                cus.enrollInsert(user);
                                cus.deleInfotByRoomid(RoomId);
                                RoomInfoBLL info = new RoomInfoBLL();
                                info.opertStateZang(RoomId);
                                RoomInfo rooms = new RoomInfo();
                                rooms = info.selectByRoomId(int.Parse(RoomId));
                                if (fmMain.xxkInder == 0)//所有
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                                    uc.state = "2";
                                    uc.BGlode();
                                    if (rooms.r_type.Equals("标准房"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flpStandard.Controls[RoomId] as UCRoom;
                                        ucs.state = "2";
                                        ucs.BGlode();
                                    }
                                    else if (rooms.r_type.Equals("单人房"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flyOne.Controls[RoomId] as UCRoom;
                                        ucs.state = "2";
                                        ucs.BGlode();
                                    }
                                    else if (rooms.r_type.Equals("商务房"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flyBusiness.Controls[RoomId] as UCRoom;
                                        ucs.state = "2";
                                        ucs.BGlode();
                                    }
                                    else if (rooms.r_type.Equals("商务单套"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flyLeveBus.Controls[RoomId] as UCRoom;
                                        ucs.state = "2";
                                        ucs.BGlode();
                                    }
                                    else if (rooms.r_type.Equals("海景房"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flySeaview.Controls[RoomId] as UCRoom;
                                        ucs.state = "2";
                                        ucs.BGlode();
                                    }
                                    else if (rooms.r_type.Equals("豪华单人"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flyDexSingle.Controls[RoomId] as UCRoom;
                                        ucs.state = "2";
                                        ucs.BGlode();
                                    }
                                    else if (rooms.r_type.Equals("豪华标准"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flyDexStandard.Controls[RoomId] as UCRoom;
                                        ucs.state = "2";
                                        ucs.BGlode();
                                    }
                                    else if (rooms.r_type.Equals("总统套房"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flyPresent.Controls[RoomId] as UCRoom;
                                        ucs.state = "2";
                                        ucs.BGlode();
                                    }
                                    else { }
                                }
                                else if (fmMain.xxkInder == 1)//标准房
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flpStandard.Controls[RoomId] as UCRoom;
                                    uc.state = "2";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                                    uca.state = "2";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 2)//单人房
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyOne.Controls[RoomId] as UCRoom;
                                    uc.state = "2";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                                    uca.state = "2";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 3)//商务房
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyBusiness.Controls[RoomId] as UCRoom;
                                    uc.state = "2";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                                    uca.state = "2";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 4)//商务单套
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyLeveBus.Controls[RoomId] as UCRoom;
                                    uc.state = "2";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                                    uca.state = "2";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 5)//海景房
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flySeaview.Controls[RoomId] as UCRoom;
                                    uc.state = "2";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                                    uca.state = "2";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 6)//豪华单人
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyDexSingle.Controls[RoomId] as UCRoom;
                                    uc.state = "2";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                                    uca.state = "2";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 7)//豪华标准
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyDexStandard.Controls[RoomId] as UCRoom;
                                    uc.state = "2";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                                    uca.state = "2";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 8)//总统套房
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyPresent.Controls[RoomId] as UCRoom;
                                    uc.state = "2";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                                    uca.state = "2";
                                    uca.BGlode();
                                }
                                else { }
                                info.opertStateIn(txtNRoomId.Text);//当前房间改为入住
                                RoomInfo roo = new RoomInfo();
                                roo = info.selectByRoomId(int.Parse(txtNRoomId.Text.ToString()));
                                if (fmMain.xxkInder == 0)//所有
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyPanelAll.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uc.state = "1";
                                    uc.BGlode();
                                    if (roo.r_type.Equals("标准房"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flpStandard.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                        ucs.state = "1";
                                        ucs.BGlode();
                                    }
                                    else if (roo.r_type.Equals("单人房"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flyOne.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                        ucs.state = "1";
                                        ucs.BGlode();
                                    }
                                    else if (roo.r_type.Equals("商务房"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flyBusiness.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                        ucs.state = "1";
                                        ucs.BGlode();
                                    }
                                    else if (roo.r_type.Equals("商务单套"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flyLeveBus.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                        ucs.state = "1";
                                        ucs.BGlode();
                                    }
                                    else if (roo.r_type.Equals("海景房"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flySeaview.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                        ucs.state = "1";
                                        ucs.BGlode();
                                    }
                                    else if (roo.r_type.Equals("豪华单人"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flyDexSingle.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                        ucs.state = "1";
                                        ucs.BGlode();
                                    }
                                    else if (roo.r_type.Equals("豪华标准"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flyDexStandard.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                        ucs.state = "1";
                                        ucs.BGlode();
                                    }
                                    else if (roo.r_type.Equals("总统套房"))
                                    {
                                        UCRoom ucs = new UCRoom();
                                        ucs = fm.flyPresent.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                        ucs.state = "1";
                                        ucs.BGlode();
                                    }
                                    else { }
                                }
                                else if (fmMain.xxkInder == 1)//标准房
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flpStandard.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uc.state = "1";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uca.state = "1";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 2)//单人房
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyOne.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uc.state = "1";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uca.state = "1";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 3)//商务房
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyBusiness.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uc.state = "1";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uca.state = "1";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 4)//商务单套
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyLeveBus.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uc.state = "1";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uca.state = "1";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 5)//海景房
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flySeaview.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uc.state = "1";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uca.state = "1";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 6)//豪华单人
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyDexSingle.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uc.state = "1";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uca.state = "1";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 7)//豪华标准
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyDexStandard.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uc.state = "1";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uca.state = "1";
                                    uca.BGlode();
                                }
                                else if (fmMain.xxkInder == 8)//总统套房
                                {
                                    UCRoom uc = new UCRoom();
                                    uc = fm.flyPresent.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uc.state = "1";
                                    uc.BGlode();
                                    UCRoom uca = new UCRoom();
                                    uca = fm.flyPanelAll.Controls[txtNRoomId.Text.ToString()] as UCRoom;
                                    uca.state = "1";
                                    uca.BGlode();
                                }
                                else { }
                                new showMessageok("系统提示","更换成功").ShowDialog();
                                getSpend();
                                this.Close();

                            }
                            else
                            {
                                new showMessagecs("系统提示", "操作失败!").ShowDialog();
                            }


                        }
                    }


                }
                else
                {
                    new showMessagecs("系统提示", "请填写完整信息!").ShowDialog();
                }
            }
            catch(Exception)
            {
                new showMessagecs("系统提示", "请联系工程师").ShowDialog();
            }
        }
        /// <summary>
        /// 刷新在住账单
        /// </summary>
        private void getSpend()
        {
            try
            {
                this.fm.listView2.Items.Clear();
                BLLcustomer bll = new BLLcustomer();
                List<InInfo> Inlist = new List<InInfo>();
                Inlist = bll.SelectInfo();
                if (Inlist.Count != 0)
                {
                    for (int i = 0; i < Inlist.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(Inlist[i].r_id.ToString());
                        item.SubItems.Add(Inlist[i].foregift.ToString());

                        item.SubItems.Add(((DateTime.Now.Subtract(Inlist[i].c_intoday)).Days).ToString());
                        //
                        Inlist[i].r_RelPrice.ToString();//房价
                        List<CusSpenInfo> Spendlist = new List<CusSpenInfo>();
                        CuspenBLL blls = new CuspenBLL();

                        Spendlist = blls.SelectSpend(Inlist[i].r_id, Inlist[i].in_number.ToString());
                        float sum = 0;
                        if (Spendlist.Count != 0)
                        {

                            for (int j = 0; j < Spendlist.Count; j++)
                            {
                                sum = sum + float.Parse(Spendlist[j].totolAmount.ToString());
                            }
                        }
                        item.SubItems.Add((float.Parse(Inlist[i].r_RelPrice.ToString()) * (DateTime.Now.Subtract(Inlist[i].c_intoday)).Days + sum).ToString());
                        this.fm.listView2.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fmRoomChange_Load(object sender, EventArgs e)
        {
            txtYRoomId.Text = RoomId;
            BLLcustomer cus = new BLLcustomer();          
            user=cus.selectByRooid(RoomId);
            txtYroomPrice.Text = user.r_RelPrice.ToString();
        }
    }
}
