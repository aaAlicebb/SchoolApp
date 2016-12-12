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
    public partial class fmBookAlter : Form
    {
        UserInfo user;
        private string RoomId;
        fmMain fms;
        ArrayList ler = new ArrayList();//新增房间记录
        ArrayList tuf = new ArrayList();//退房房间记录
        ArrayList roomlist = new ArrayList();//原来已有房间记录
        private string DanHao;
        public fmBookAlter(string roomId, UserInfo us,fmMain fm)
        {
            this.fms = fm;
            RoomId = roomId;
            user = us;
            InitializeComponent();
        }

        Point mouseOff;
        bool leftFlag;
        private void fmBookAlter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void fmBookAlter_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }

        private void fmBookAlter_MouseUp(object sender, MouseEventArgs e)
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

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 点关闭图片关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            leftTuiFang();
            rightadd();
            UpdateOpera();
        }
        private int ZJPD(string ZJNumber)
        {
            string xx;//存放textBox中的字符
            xx = ZJNumber;
            int totalNumber;//字符串的长度
            totalNumber = xx.Length;
            //char []  xx = new char[1000];
            ZJNumber = totalNumber.ToString();
            for (int i = 0; i <= totalNumber - 1; i++)
            {
                if (xx[i] > '9' || xx[i] < '0')//如果字符串中有一个字符大于‘9’或者小于‘0’；
                {
                    new showMessagecs("系统提示", "您输入了非数字字符！").ShowDialog();
                    return -1;

                }
                else
                {
                    if (xx.Length != 15 && xx.Length != 18)//如果输入的不是15位也不是18位出错
                    {
                        new showMessagecs("系统提示", "身份证号输入有误！").ShowDialog();
                        return -1;

                    }
                }
            }
            return 1;

        }
        /// <summary>
        ///  左边退房
        /// </summary>
        private void leftTuiFang()
        {
            if (tuf.Count > 0)
            {
                for (int i = 0; i < tuf.Count; i++)
                {
                    string id = tuf[i].ToString();
                    BLLcustomer cus = new BLLcustomer();
                    cus.updateTem1(int.Parse(id));
                    if (fmMain.xxkInder == 0)//所有
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyPanelAll.Controls[id] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 1)//标准房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flpStandard.Controls[id] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 2)//单人房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyOne.Controls[id] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 3)//商务房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyBusiness.Controls[id] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 4)//商务单套
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyLeveBus.Controls[id] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 5)//海景房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flySeaview.Controls[id] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 6)//豪华单人
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyDexSingle.Controls[id] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 7)//豪华标准
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyDexStandard.Controls[id] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 8)//总统套房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyPresent.Controls[id] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                    }
                    else { }
                    cus.deleInfotByRoomid(id);
                    int lbkf = int.Parse(fms.label6.Text);
                    fms.label6.Text = (lbkf + 1).ToString();//空房
                    int lbyd = int.Parse(fms.label10.Text);
                    fms.label10.Text = (lbyd - 1).ToString();//预订
                }
            }
        }
        /// <summary>
        ///  右边加房
        /// </summary>
        private void rightadd()
        {
            if (ler.Count > 0)
            {
                for (int i = 0; i < ler.Count; i++)
                {
                    string id = ler[i].ToString();
                    BLLcustomer cus = new BLLcustomer();
                    InInfo room = new InInfo();
                    room = cus.selectByDanHaoandId(DanHao, RoomId);
                    room.r_id = int.Parse(ler[i].ToString());
                    cus.updateTem2(int.Parse(id));//更改为预订
                    cus.enrollInsert(room);
                    if (fmMain.xxkInder == 0)//所有
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyPanelAll.Controls[id] as UCRoom;
                        uc.state = "3";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 1)//标准房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flpStandard.Controls[id] as UCRoom;
                        uc.state = "3";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 2)//单人房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyOne.Controls[id] as UCRoom;
                        uc.state = "3";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 3)//商务房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyBusiness.Controls[id] as UCRoom;
                        uc.state = "3";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 4)//商务单套
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyLeveBus.Controls[id] as UCRoom;
                        uc.state = "3";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 5)//海景房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flySeaview.Controls[id] as UCRoom;
                        uc.state = "3";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 6)//豪华单人
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyDexSingle.Controls[id] as UCRoom;
                        uc.state = "3";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 7)//豪华标准
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyDexStandard.Controls[id] as UCRoom;
                        uc.state = "3";
                        uc.BGlode();
                    }
                    else if (fmMain.xxkInder == 8)//总统套房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyPresent.Controls[id] as UCRoom;
                        uc.state = "3";
                        uc.BGlode();
                    }
                    int lbkf = int.Parse(fms.label6.Text);
                    fms.label6.Text = (lbkf - 1).ToString();//空房
                    int lbyd = int.Parse(fms.label10.Text);
                    fms.label10.Text = (lbyd - 1).ToString();//预订                
                }
            }
        }
        /// <summary>
        /// 更新操作
        /// </summary>
        private void UpdateOpera()
        {
            int j = ZJPD(txtZJNumber.Text);
            if(j==1)
            {
                if(this.userName.Text == ""||this.cbInType.Text == "" || this.txtZJNumber.Text == "" || this.address.Text == ""|| this.txtYuShouK.Text == "" || this.phone.Text == "" || this.txtRoomRelPrice.Text == "" )
                {
                    new showMessagecs("系统设置", "请将信息提醒完整！").ShowDialog();
                }
                else
                {
                    InInfo customer = new InInfo();
                    customer.r_id = int.Parse(RoomId);//证件号;
                    customer.c_name = userName.Text;//住客姓名
                    if (cbZJType.SelectedIndex > 0)
                    {
                        customer.zj_type = cbZJType.SelectedItem.ToString();//证件类型

                    }
                    else
                    {
                        customer.zj_type = "身份证";
                    }
                    if (cbInType.SelectedIndex > 0)
                    {
                        customer.InType = cbInType.SelectedItem.ToString();
                    }
                    else
                    {
                        customer.InType = cbInType.Text;//入住类型
                    }                 
                    customer.zj_number = txtZJNumber.Text;//证件号
                    customer.c_address = address.Text; //地址
                    customer.c_intoday = inTime.Value;//入住时间
                    customer.foregift = float.Parse(txtYuShouK.Text);//预收款
                    customer.levatime = outTime.Value;//离店时间
                    customer.nationality = txtGuoJi.Text;//国际
                    customer.C_Phone = phone.Text;//电话
                    customer.r_RelPrice = float.Parse(txtRoomRelPrice.Text);//房间实际价格
                    customer.InFriend = txtFriend.Text;//同住客人
                    customer.C_inpeopleCount = int.Parse(numericUpDown1.Value.ToString());//人数
                    customer.Inhour = dateTimePicker1.Value;//入住小时
                    customer.leavehour = dateTimePicker2.Value;//离开小时

                    if (male.Checked == true)//性别
                    {
                        customer.c_sex = true;
                    }
                    else if (male.Checked == false)
                    {
                        customer.c_sex = false;
                    }
                    else
                    {
                        customer.c_sex = true;
                    }
                    BLLcustomer bll = new BLLcustomer();
                    int count = bll.UpdateInfo(customer);
                    if (count == 1)
                    {
                        new showMessageok("系统设置", "成功！").ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        new showMessage("系统设置", "失败！").ShowDialog();
                    }
                }
            }
            
        }

        private void right_Click(object sender, EventArgs e)
        {
            try
            {

                int counts = this.listLeft.SelectedItems.Count;
                if (counts > 0)
                {
                    string value = this.listLeft.SelectedItems[0].SubItems[0].Text;
                    for (int i = 0; i < counts; i++)
                    {
                        string[] str = new string[4];
                        str[0] = this.listLeft.SelectedItems[i].SubItems[0].Text;
                        if (str[0].Equals(RoomId))
                        {
                            new showMessage("系统提示", "该房不能移动").ShowDialog();
                            break;
                        }
                        ler.Add(str[0]);
                        for (int k = 0; k < tuf.Count; k++)
                        {
                            if (tuf[k].Equals(str[0]))
                            {
                                tuf.Remove(tuf[k]);
                            }
                        }
                        str[1] = this.listLeft.SelectedItems[i].SubItems[1].Text;
                        str[2] = this.listLeft.SelectedItems[i].SubItems[2].Text;
                        str[3] = this.listLeft.SelectedItems[i].SubItems[3].Text;
                        ListViewItem item2 = new ListViewItem(str);
                        this.listRight.Items.AddRange(new ListViewItem[] { item2 });
                        this.listLeft.SelectedItems[0].Remove();
                        BLLcustomer user = new BLLcustomer();
                        tempInfo temps = new tempInfo();
                        temps.roomId = int.Parse(value);
                        int deCount = user.shanchu(temps.roomId);
                    }

                }

                else
                {
                    new showMessagecs("系统提示", "您没有选中任何项！").ShowDialog();
                }

                int rightcounts = listRight.Items.Count;
                Ckroomcount.Text = "(" + rightcounts + "间" + ")";
                int leftcount = listLeft.Items.Count;
                roomCount.Text = "(" + leftcount + "间" + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            try
            {
                int counts = this.listRight.SelectedItems.Count;
                if (this.listRight.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < counts; i++)
                    {

                        string[] str = new string[4];
                        BLLcustomer bll = new BLLcustomer();
                        str[0] = this.listRight.SelectedItems[i].SubItems[0].Text;
                        RoomInfoBLL bl = new RoomInfoBLL();
                        RoomInfo room = new RoomInfo();
                        room = bl.selectByRoomId(int.Parse(str[0]));
                        if (room.r_state.Equals("1") || room.r_state.Equals("4"))
                        {
                            new showMessage("系统提示", "该房已入住不能移动").ShowDialog();
                            break;
                        }
                        if (str[0].Equals(RoomId))
                        {
                            new showMessage("系统提示", "该房不能移动").ShowDialog();
                            break;
                        }
                        for (int j = 0; j < ler.Count; j++)
                        {
                            if (ler[i].Equals(str[0]))
                            {
                                ler.Remove(roomlist[i]);
                            }
                        }
                        for (int k = 0; k < roomlist.Count; k++)
                        {
                            if (roomlist[k].Equals(str[0]))
                            {
                                tuf.Add(str[0]);
                            }
                        }
                        str[1] = this.listRight.SelectedItems[i].SubItems[1].Text;
                        str[2] = this.listRight.SelectedItems[i].SubItems[2].Text;
                        str[3] = this.listRight.SelectedItems[i].SubItems[3].Text;
                        ListViewItem item = new ListViewItem(str);
                        this.listLeft.Items.AddRange(new ListViewItem[] { item });
                        tempInfo Tem = new tempInfo();
                        Tem.roomId = int.Parse(this.listRight.SelectedItems[0].SubItems[0].Text.ToString());
                        Tem.roomType = this.listRight.SelectedItems[0].SubItems[1].Text.ToString();
                        Tem.roomPrice = decimal.Parse(this.listRight.SelectedItems[0].SubItems[2].Text.ToString());
                        Tem.roomState = "空";
                        BLLcustomer blls = new BLLcustomer();
                        int insertCount = blls.insertTemp(Tem);
                        this.listRight.SelectedItems[0].Remove();
                        BLLcustomer Broom = new BLLcustomer();
                        tempInfo temCount = new tempInfo();
                    }
                }
                else
                {
                    new showMessagecs("系统提示", "您没有选中任何项！").ShowDialog();
                }

                int rightcounts = listRight.Items.Count;
                Ckroomcount.Text = "(" + rightcounts + "间" + ")";
                int leftcount = listLeft.Items.Count;
                roomCount.Text = "(" + leftcount + "间" + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getRoomtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void roomType_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cardType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }       
        /// <summary>
        /// 页面加载方法
        /// </summary>
        private void fmuserLode()
        {
            tempInfo room = new tempInfo();
            BLLcustomer Broom = new BLLcustomer();
            ArrayList bb = Broom.resarchRoomtype();
            int deDao = Broom.deleTem();
            int dao = Broom.NewTem();
            foreach (string a in bb)
            {
                getRoomtype.Items.Add(a);
            }
            inTime.Enabled = false;
            dateTimePicker1.Enabled = false;
            int rightcounts = listRight.Items.Count;
            Ckroomcount.Text = "(" + rightcounts + "间" + ")";
            int leftcount = listLeft.Items.Count;
            roomCount.Text = "(" + leftcount + "间" + ")";
        }//高
        /// <summary>
        /// 页面数据加载事件
        /// </summary>
        private void PageDateLode()
        {
            roomNumber.Text = RoomId;
            BLLcustomer bll = new BLLcustomer();
            InInfo mes = new InInfo();
            mes = bll.selectByRooid(RoomId);
            orderNumber.Text = mes.in_number.ToString();//单号
            DanHao = mes.in_number.ToString();
            userName.Text = mes.c_name.ToString();//姓名
            phone.Text = mes.C_Phone.ToString();//电话
            cbInType.Text = mes.InType.ToString();//入住类别
            if (!mes.InType.Equals("团队房"))
            {
                groupBox1.Enabled = false;
            }
            else 
            {
                groupBox1.Enabled = true;
                BLLcustomer bllc = new BLLcustomer();
                List<InInfo> list = new List<InInfo>();
                list = bllc.selectByDanHao(mes.in_number.ToString());
                for (int i = 0; i < list.Count; i++)
                {
                    roomlist.Add(list[i].r_id.ToString());
                    listRight.Items.Add(list[i].r_id.ToString());
                    listRight.Items[i].SubItems.Add(list[i].Room.r_type.ToString());
                    listRight.Items[i].SubItems.Add(list[i].r_RelPrice.ToString());
                    listRight.Items[i].SubItems.Add(list[i].Room.r_state.ToString());
                }
            }
            cbZJType.Text = mes.zj_type.ToString();//证件类型
            txtZJNumber.Text = mes.zj_number.ToString();//证件号
            address.Text = mes.c_address.ToString();//地址
            txtGuoJi.Text = mes.nationality.ToString();//国际
            numericUpDown1.Value = mes.C_inpeopleCount;//入住人数
            txtYuShouK.Text = mes.foregift.ToString();//预收款
            txtRoomRelPrice.Text = mes.r_RelPrice.ToString();//实际价格
            txtFriend.Text = mes.InFriend.ToString();//同住客人
            if (mes.c_sex == true)//性别
            {
                male.Checked = true;
            }
            else
            {
                male.Checked = false;
            }
            inTime.Value = mes.c_intoday;//入住时间
            outTime.Value = mes.levatime;//离店时间
            cashMoney.Text = mes.r_RelPrice.ToString();//页头押金加载
            dateTimePicker1.Value = mes.Inhour;
            dateTimePicker2.Value = mes.leavehour;
        }

        private void fmBookAlter_Load_1(object sender, EventArgs e)
        {
            PageDateLode();
            fmuserLode();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            int count=bll.opertStateIn(RoomId);
            if (count > 0)
            {
                RoomInfo room = new RoomInfo();
                room = bll.selectByRoomId(int.Parse(RoomId));
                if (fmMain.xxkInder == 0)//所有
                {
                    UCRoom uc = new UCRoom();
                    uc = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                    uc.state = "1";
                    uc.BGlode();
                    if (room.r_type.Equals("标准房"))
                    {
                        UCRoom ucs = new UCRoom();
                        ucs = fms.flpStandard.Controls[RoomId] as UCRoom;
                        ucs.state = "1";
                        ucs.BGlode();
                    }
                    else if (room.r_type.Equals("单人房"))
                    {
                        UCRoom ucs = new UCRoom();
                        ucs = fms.flyOne.Controls[RoomId] as UCRoom;
                        ucs.state = "1";
                        ucs.BGlode();
                    }
                    else if (room.r_type.Equals("商务房"))
                    {
                        UCRoom ucs = new UCRoom();
                        ucs = fms.flyBusiness.Controls[RoomId] as UCRoom;
                        ucs.state = "1";
                        ucs.BGlode();
                    }
                    else if (room.r_type.Equals("商务单套"))
                    {
                        UCRoom ucs = new UCRoom();
                        ucs = fms.flyLeveBus.Controls[RoomId] as UCRoom;
                        ucs.state = "1";
                        ucs.BGlode();
                    }
                    else if (room.r_type.Equals("海景房"))
                    {
                        UCRoom ucs = new UCRoom();
                        ucs = fms.flySeaview.Controls[RoomId] as UCRoom;
                        ucs.state = "1";
                        ucs.BGlode();
                    }
                    else if (room.r_type.Equals("豪华单人"))
                    {
                        UCRoom ucs = new UCRoom();
                        ucs = fms.flyDexSingle.Controls[RoomId] as UCRoom;
                        ucs.state = "1";
                        ucs.BGlode();
                    }
                    else if (room.r_type.Equals("豪华标准"))
                    {
                        UCRoom ucs = new UCRoom();
                        ucs = fms.flyDexStandard.Controls[RoomId] as UCRoom;
                        ucs.state = "1";
                        ucs.BGlode();
                    }
                    else if (room.r_type.Equals("总统套房"))
                    {
                        UCRoom ucs = new UCRoom();
                        ucs = fms.flyPresent.Controls[RoomId] as UCRoom;
                        ucs.state = "1";
                        ucs.BGlode();
                    }
                    else { }
                }
                else if (fmMain.xxkInder == 1)//标准房
                {
                    UCRoom uc = new UCRoom();
                    uc = fms.flpStandard.Controls[RoomId] as UCRoom;
                    uc.state = "1";
                    uc.BGlode();
                    UCRoom uca = new UCRoom();
                    uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                    uca.state = "1";
                    uca.BGlode();
                }
                else if (fmMain.xxkInder == 2)//单人房
                {
                    UCRoom uc = new UCRoom();
                    uc = fms.flyOne.Controls[RoomId] as UCRoom;
                    uc.state = "1";
                    uc.BGlode();
                    UCRoom uca = new UCRoom();
                    uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                    uca.state = "1";
                    uca.BGlode();
                }
                else if (fmMain.xxkInder == 3)//商务房
                {
                    UCRoom uc = new UCRoom();
                    uc = fms.flyBusiness.Controls[RoomId] as UCRoom;
                    uc.state = "1";
                    uc.BGlode();
                    UCRoom uca = new UCRoom();
                    uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                    uca.state = "1";
                    uca.BGlode();
                }
                else if (fmMain.xxkInder == 4)//商务单套
                {
                    UCRoom uc = new UCRoom();
                    uc = fms.flyLeveBus.Controls[RoomId] as UCRoom;
                    uc.state = "1";
                    uc.BGlode();
                    UCRoom uca = new UCRoom();
                    uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                    uca.state = "1";
                    uca.BGlode();
                }
                else if (fmMain.xxkInder == 5)//海景房
                {
                    UCRoom uc = new UCRoom();
                    uc = fms.flySeaview.Controls[RoomId] as UCRoom;
                    uc.state = "1";
                    uc.BGlode();
                    UCRoom uca = new UCRoom();
                    uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                    uca.state = "1";
                    uca.BGlode();
                }
                else if (fmMain.xxkInder == 6)//豪华单人
                {
                    UCRoom uc = new UCRoom();
                    uc = fms.flyDexSingle.Controls[RoomId] as UCRoom;
                    uc.state = "1";
                    uc.BGlode();
                    UCRoom uca = new UCRoom();
                    uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                    uca.state = "1";
                    uca.BGlode();
                }
                else if (fmMain.xxkInder == 7)//豪华标准
                {
                    UCRoom uc = new UCRoom();
                    uc = fms.flyDexStandard.Controls[RoomId] as UCRoom;
                    uc.state = "1";
                    uc.BGlode();
                    UCRoom uca = new UCRoom();
                    uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                    uca.state = "1";
                    uca.BGlode();
                }
                else if (fmMain.xxkInder == 8)//总统套房
                {
                    UCRoom uc = new UCRoom();
                    uc = fms.flyPresent.Controls[RoomId] as UCRoom;
                    uc.state = "1";
                    uc.BGlode();
                    UCRoom uca = new UCRoom();
                    uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                    uca.state = "1";
                    uca.BGlode();
                }
                else { }
                new showMessageok("系统提示", "已转为入住！").ShowDialog();
                this.Close();
            }
            else 
            {
                new showMessagecs("系统提示", "操作失败请联系管理员！").ShowDialog();
            }
        }

        /// <summary>
        /// 显示房间信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void getRoomtype_SelectionChangeCommitted(object sender, EventArgs e)//选不同类型
        {
            //listLeft.Items.Clear();
            //RoomInfo roomType = new RoomInfo();
            //roomType.r_type = getRoomtype.SelectedItem.ToString();
            //BLLcustomer Broom = new BLLcustomer();
            //List<tempInfo> excute = Broom.resarchRoomInfo(roomType.r_type, "0");
            //for (int i = 0; i < excute.Count; i++)
            //{
            //    listLeft.Items.Add(excute[i].roomId.ToString());
            //    listLeft.Items[i].SubItems.Add(excute[i].roomType.ToString());
            //    listLeft.Items[i].SubItems.Add(excute[i].roomPrice.ToString());
            //    listLeft.Items[i].SubItems.Add(excute[i].roomState.ToString());
            //}
            //int leftcount = listLeft.Items.Count;
            //roomCount.Text = "(" + leftcount + "间" + ")";
            
        }
        /// <summary>
        /// 取消预订
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            BLLcustomer cusbll = new BLLcustomer();
            int result= cusbll.deleInfotByRoomid(RoomId);
            if(result>0)
            {
                int count = bll.opertState(RoomId);
                if (count > 0)
                {
                    new showMessageok("系统提示", "已取消预订！").ShowDialog();
                    RoomInfo room = new RoomInfo();
                    room = bll.selectByRoomId(int.Parse(RoomId));
                    if (fmMain.xxkInder == 0)//所有
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                        if (room.r_type.Equals("标准房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fms.flpStandard.Controls[RoomId] as UCRoom;
                            ucs.state = "0";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("单人房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fms.flyOne.Controls[RoomId] as UCRoom;
                            ucs.state = "0";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("商务房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fms.flyBusiness.Controls[RoomId] as UCRoom;
                            ucs.state = "0";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("商务单套"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fms.flyLeveBus.Controls[RoomId] as UCRoom;
                            ucs.state = "0";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("海景房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fms.flySeaview.Controls[RoomId] as UCRoom;
                            ucs.state = "0";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("豪华单人"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fms.flyDexSingle.Controls[RoomId] as UCRoom;
                            ucs.state = "0";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("豪华标准"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fms.flyDexStandard.Controls[RoomId] as UCRoom;
                            ucs.state = "0";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("总统套房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fms.flyPresent.Controls[RoomId] as UCRoom;
                            ucs.state = "0";
                            ucs.BGlode();
                        }
                        else { }
                    }
                    else if (fmMain.xxkInder == 1)//标准房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flpStandard.Controls[RoomId] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                        uca.state = "0";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 2)//单人房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyOne.Controls[RoomId] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                        uca.state = "0";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 3)//商务房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyBusiness.Controls[RoomId] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                        uca.state = "0";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 4)//商务单套
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyLeveBus.Controls[RoomId] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                        uca.state = "0";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 5)//海景房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flySeaview.Controls[RoomId] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                        uca.state = "0";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 6)//豪华单人
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyDexSingle.Controls[RoomId] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                        uca.state = "0";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 7)//豪华标准
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyDexStandard.Controls[RoomId] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                        uca.state = "0";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 8)//总统套房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fms.flyPresent.Controls[RoomId] as UCRoom;
                        uc.state = "0";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fms.flyPanelAll.Controls[RoomId] as UCRoom;
                        uca.state = "0";
                        uca.BGlode();
                    }
                    else { }
                    this.Close();

                }
                else
                {
                    new showMessagecs("系统提示", "操作失败请联系管理员!").ShowDialog();
                }
            }
            
        }
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 点击同住客人右侧小图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            //fmAddUser addu = new fmAddUser(RoomId,);
            //addu.ShowDialog();
            new showMessagecs("系统提示", "请入住后在操作").ShowDialog();
        }

        private void getRoomtype_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            listLeft.Items.Clear();
            RoomInfo roomType = new RoomInfo();
            roomType.r_type = getRoomtype.SelectedItem.ToString();
            BLLcustomer Broom = new BLLcustomer();
            List<tempInfo> excute = Broom.resarchRoomInfo(roomType.r_type, "0");
            for (int i = 0; i < excute.Count; i++)
            {
                listLeft.Items.Add(excute[i].roomId.ToString());
                listLeft.Items[i].SubItems.Add(excute[i].roomType.ToString());
                listLeft.Items[i].SubItems.Add(excute[i].roomPrice.ToString());
                listLeft.Items[i].SubItems.Add(excute[i].roomState.ToString());
            }
            int leftcount = listLeft.Items.Count;
            roomCount.Text = "(" + leftcount + "间" + ")";
        }

        private void getRoomtype_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cbInType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbInType.SelectedIndex > 0)
            {
                if (cbInType.SelectedItem.ToString().Equals("团队房"))
                {
                    groupBox1.Enabled = true;
                }
            }
        }
    }
}
