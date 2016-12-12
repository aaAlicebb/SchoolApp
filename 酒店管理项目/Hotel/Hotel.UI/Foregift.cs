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
    public partial class Foregift : Form
    {
        public string RoomId;
        UserInfo OpertUser;
        public string DanHao;
        public fmMain fm;
        //public Foregift(string roomid, UserInfo user)
        //{
        //    OpertUser = user;
        //    RoomId = roomid;
        //    InitializeComponent();
        //}
        public Foregift(string roomid, UserInfo user,fmMain fms)
        {
            OpertUser = user;
            RoomId = roomid;
            fm=fms;
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 窗体移动
        /// </summary>
        Point mouseOff;
        bool leftFlag;

        private void Foregift_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }

        private void Foregift_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        private void Foregift_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
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

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
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
        private void Foregift_Load(object sender, EventArgs e)//页面加载
        {
            roomMesLode();//李，房间相关加载
            fmuserLode();//高，页面加载
        }
        /// <summary>
        /// 房间信息加载
        /// </summary>
        private void roomMesLode()
        {
            roomNumber.Text = RoomId;
            string date = DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "").Replace("/", "");
            lbDanId.Text = date;
            DanHao = date;
            groupBox1.Enabled = false;
            roomNumber.Text = RoomId;
            RoomInfoBLL bll = new RoomInfoBLL();
            RoomInfo room = new RoomInfo();
            room = bll.selectByRoomId(int.Parse(RoomId));
            lbRoomPrice.Text = room.r_price.ToString();
            txtRoomRelPrice.Text = room.r_price.ToString();
            lbYaJin.Text = (room.r_price + 100).ToString();

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
        }

        /// <summary>
        /// 显示房间信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void getRoomtype_SelectionChangeCommitted_1(object sender, EventArgs e)//选不同类型
        {
            listLeft.Items.Clear();
            RoomInfo roomType = new RoomInfo();
            roomType.r_type = getRoomtype.SelectedItem.ToString();
            BLLcustomer Broom = new BLLcustomer();
            List<tempInfo> excute = Broom.resarchRoomInfo(roomType.r_type, "0");
            // listLeft.Items.Add(title.r_id.ToString());

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

        private void right_Click_1(object sender, EventArgs e)//右移
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
        private void left_Click(object sender, EventArgs e)//左移
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


        private void save_Click(object sender, EventArgs e)//保存
        {
            try
            {
                int j = ZJPD(cardID.Text);
                if(j==1)
                {
                    if (roomType.Text == "" || DanHao == "" || this.userName.Text == "" || roomNumber.Text == "" || cardType.Text == "" || cardID.Text == "" || address.Text == "" || inTime.Value == null || textBox3.Text == "" || outTime.Value == null || textBox1.Text == "" || phone.Text == "" || txtRoomRelPrice.Text == "" || textBox5.Text == "" || numericUpDown1.Value.ToString() == "" || dateTimePicker1.Value.TimeOfDay.ToString() == "" || dateTimePicker2.Value.TimeOfDay.ToString() == "")
                    {
                        new showMessagecs("系统提示", "请将信息填写完整！").ShowDialog();
                    }
                    else
                    {
                        if (this.userName.Text != "" && cardID.Text != "")
                        {

                            if (listRight.Items.Count > 0)
                            {
                                for (int i = 0; i < listRight.Items.Count; i++)
                                {
                                    InInfo customers = new InInfo();
                                    customers.InType = roomType.Text;//入住类型
                                    customers.in_number = DanHao;//入住单号，自动生成
                                    customers.r_id = int.Parse(listRight.Items[i].Text.ToString());
                                    string id = listRight.Items[i].Text.ToString();
                                    customers.c_name = this.userName.Text;//客户姓名
                                    if (male.Checked == true)
                                    {
                                        customers.c_sex = true;
                                    }
                                    if (female.Checked == true)
                                    {
                                        customers.c_sex = false;
                                    }
                                    customers.zj_type = cardType.Text;
                                    customers.zj_number = cardID.Text;
                                    customers.c_address = address.Text;
                                    customers.c_intoday = inTime.Value;//入住时间
                                    customers.foregift = float.Parse(textBox3.Text);//押金,预订收款
                                    customers.levatime = outTime.Value;//离店时间
                                    customers.nationality = textBox1.Text;//国籍
                                    customers.C_Phone = phone.Text;
                                    customers.r_RelPrice = float.Parse(txtRoomRelPrice.Text);//实际房价
                                    customers.InFriend = textBox5.Text;//同住客人
                                    customers.C_inpeopleCount = int.Parse(numericUpDown1.Value.ToString());//入住人数
                                    customers.Inhour = dateTimePicker1.Value;
                                    customers.leavehour = dateTimePicker2.Value;
                                    BLLcustomer Bcustomers = new BLLcustomer();
                                    int reCount = Bcustomers.moreRoom(customers);
                                    int count = Bcustomers.updateTem2(customers.r_id);
                                    RoomInfoBLL bll = new RoomInfoBLL();
                                    RoomInfo room = new RoomInfo();
                                    room = bll.selectByRoomId(int.Parse(customers.r_id.ToString()));
                                    if (fmMain.xxkInder == 0)//所有
                                    {
                                        UCRoom uc = new UCRoom();
                                        uc = fm.flyPanelAll.Controls[customers.r_id.ToString()] as UCRoom;
                                        uc.state = "3";
                                        uc.BGlode();
                                        if (room.r_type.Equals("标准房"))
                                        {
                                            UCRoom ucs = new UCRoom();
                                            ucs = fm.flpStandard.Controls[customers.r_id.ToString()] as UCRoom;
                                            ucs.state = "3";
                                            ucs.BGlode();
                                        }
                                        else if (room.r_type.Equals("单人房"))
                                        {
                                            UCRoom ucs = new UCRoom();
                                            ucs = fm.flyOne.Controls[customers.r_id.ToString()] as UCRoom;
                                            ucs.state = "3";
                                            ucs.BGlode();
                                        }
                                        else if (room.r_type.Equals("商务房"))
                                        {
                                            UCRoom ucs = new UCRoom();
                                            ucs = fm.flyBusiness.Controls[customers.r_id.ToString()] as UCRoom;
                                            ucs.state = "3";
                                            ucs.BGlode();
                                        }
                                        else if (room.r_type.Equals("商务单套"))
                                        {
                                            UCRoom ucs = new UCRoom();
                                            ucs = fm.flyLeveBus.Controls[customers.r_id.ToString()] as UCRoom;
                                            ucs.state = "3";
                                            ucs.BGlode();
                                        }
                                        else if (room.r_type.Equals("海景房"))
                                        {
                                            UCRoom ucs = new UCRoom();
                                            ucs = fm.flySeaview.Controls[customers.r_id.ToString()] as UCRoom;
                                            ucs.state = "3";
                                            ucs.BGlode();
                                        }
                                        else if (room.r_type.Equals("豪华单人"))
                                        {
                                            UCRoom ucs = new UCRoom();
                                            ucs = fm.flyDexSingle.Controls[customers.r_id.ToString()] as UCRoom;
                                            ucs.state = "3";
                                            ucs.BGlode();
                                        }
                                        else if (room.r_type.Equals("豪华标准"))
                                        {
                                            UCRoom ucs = new UCRoom();
                                            ucs = fm.flyDexStandard.Controls[customers.r_id.ToString()] as UCRoom;
                                            ucs.state = "3";
                                            ucs.BGlode();
                                        }
                                        else if (room.r_type.Equals("总统套房"))
                                        {
                                            UCRoom ucs = new UCRoom();
                                            ucs = fm.flyPresent.Controls[customers.r_id.ToString()] as UCRoom;
                                            ucs.state = "3";
                                            ucs.BGlode();
                                        }
                                        else { }
                                    }
                                    else if (fmMain.xxkInder == 1)//标准房
                                    {
                                        UCRoom uc = new UCRoom();
                                        uc = fm.flpStandard.Controls[customers.r_id.ToString()] as UCRoom;
                                        uc.state = "3";
                                        uc.BGlode();
                                        UCRoom uca = new UCRoom();
                                        uca = fm.flyPanelAll.Controls[customers.r_id.ToString()] as UCRoom;
                                        uca.state = "3";
                                        uca.BGlode();
                                    }
                                    else if (fmMain.xxkInder == 2)//单人房
                                    {
                                        UCRoom uc = new UCRoom();
                                        uc = fm.flyOne.Controls[customers.r_id.ToString()] as UCRoom;
                                        uc.state = "3";
                                        uc.BGlode();
                                        UCRoom uca = new UCRoom();
                                        uca = fm.flyPanelAll.Controls[customers.r_id.ToString()] as UCRoom;
                                        uca.state = "3";
                                        uca.BGlode();
                                    }
                                    else if (fmMain.xxkInder == 3)//商务房
                                    {
                                        UCRoom uc = new UCRoom();
                                        uc = fm.flyBusiness.Controls[customers.r_id.ToString()] as UCRoom;
                                        uc.state = "3";
                                        uc.BGlode();
                                        UCRoom uca = new UCRoom();
                                        uca = fm.flyPanelAll.Controls[customers.r_id.ToString()] as UCRoom;
                                        uca.state = "3";
                                        uca.BGlode();
                                    }
                                    else if (fmMain.xxkInder == 4)//商务单套
                                    {
                                        UCRoom uc = new UCRoom();
                                        uc = fm.flyLeveBus.Controls[customers.r_id.ToString()] as UCRoom;
                                        uc.state = "3";
                                        uc.BGlode();
                                        UCRoom uca = new UCRoom();
                                        uca = fm.flyPanelAll.Controls[customers.r_id.ToString()] as UCRoom;
                                        uca.state = "3";
                                        uca.BGlode();
                                    }
                                    else if (fmMain.xxkInder == 5)//海景房
                                    {
                                        UCRoom uc = new UCRoom();
                                        uc = fm.flySeaview.Controls[customers.r_id.ToString()] as UCRoom;
                                        uc.state = "3";
                                        uc.BGlode();
                                        UCRoom uca = new UCRoom();
                                        uca = fm.flyPanelAll.Controls[customers.r_id.ToString()] as UCRoom;
                                        uca.state = "3";
                                        uca.BGlode();
                                    }
                                    else if (fmMain.xxkInder == 6)//豪华单人
                                    {
                                        UCRoom uc = new UCRoom();
                                        uc = fm.flyDexSingle.Controls[customers.r_id.ToString()] as UCRoom;
                                        uc.state = "3";
                                        uc.BGlode();
                                        UCRoom uca = new UCRoom();
                                        uca = fm.flyPanelAll.Controls[customers.r_id.ToString()] as UCRoom;
                                        uca.state = "3";
                                        uca.BGlode();
                                    }
                                    else if (fmMain.xxkInder == 7)//豪华标准
                                    {
                                        UCRoom uc = new UCRoom();
                                        uc = fm.flyDexStandard.Controls[customers.r_id.ToString()] as UCRoom;
                                        uc.state = "3";
                                        uc.BGlode();
                                        UCRoom uca = new UCRoom();
                                        uca = fm.flyPanelAll.Controls[customers.r_id.ToString()] as UCRoom;
                                        uca.state = "3";
                                        uca.BGlode();
                                    }
                                    else if (fmMain.xxkInder == 8)//总统套房
                                    {
                                        UCRoom uc = new UCRoom();
                                        uc = fm.flyPresent.Controls[customers.r_id.ToString()] as UCRoom;
                                        uc.state = "3";
                                        uc.BGlode();
                                        UCRoom uca = new UCRoom();
                                        uca = fm.flyPanelAll.Controls[customers.r_id.ToString()] as UCRoom;
                                        uca.state = "3";
                                        uca.BGlode();
                                    }
                                    else { }
                                    int lbyd = int.Parse(fm.label10.Text.ToString());
                                    fm.label10.Text = (lbyd + 1).ToString();//预订改变
                                    int lbkf = int.Parse(fm.label6.Text);
                                    fm.label6.Text = (lbkf - 1).ToString();//空房改变

                                }
                                DengJIs();
                                // new showMessage("系统提示", "成功").ShowDialog();
                            }
                            else
                            {
                                DengJI();
                            }
                        }

                        else
                        {
                            new showMessagecs("系统提示", "信息不能为空！").ShowDialog();
                        }
                    }
                
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

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
        /// 团队登记
        /// </summary>
        private void DengJIs()
        {
            InInfo customer = new InInfo();
            customer.InType = roomType.Text;
            customer.in_number = DanHao;
            customer.r_id = int.Parse(RoomId);
            customer.c_name = this.userName.Text;
            if (male.Checked == true)
            {
                customer.c_sex = true;
            }
            if (female.Checked == true)
            {
                customer.c_sex = false;
            }
            // customer.r_id = int.Parse(roomNumber.Text);
            customer.zj_type = cardType.Text;
            customer.zj_number = cardID.Text;
            customer.c_address = address.Text;
            customer.c_intoday = inTime.Value;
            // customer.c_aboutdays = "";
            customer.foregift = float.Parse(textBox3.Text);
            customer.levatime = outTime.Value;
            customer.nationality = textBox1.Text;
            customer.C_Phone = phone.Text;
            customer.r_RelPrice = float.Parse(txtRoomRelPrice.Text);
            customer.InFriend = textBox5.Text;
            customer.C_inpeopleCount = int.Parse(numericUpDown1.Value.ToString());
            customer.Inhour = dateTimePicker1.Value;
            customer.leavehour = dateTimePicker2.Value;
            BLLcustomer Bcustomers = new BLLcustomer();
            int count = Bcustomers.updateTem2(int.Parse(RoomId));
            if (count > 0)
            {
                OpResult result = Bcustomers.enrollInsert(customer);
                if (result == OpResult.yes)
                {
                   // new showMessageok("系统提示", "保存成功！").ShowDialog();                 
                    if (result == OpResult.yes)
                    {

                        new showMessageok("系统提示", "保存成功！").ShowDialog();
                        int lbyd = int.Parse(fm.label10.Text.ToString());
                        fm.label10.Text = (lbyd + 1).ToString();//预订改变
                        int lbkf = int.Parse(fm.label6.Text);
                        fm.label6.Text = (lbkf - 1).ToString();//空房改变
                        RoomInfoBLL bll = new RoomInfoBLL();
                        RoomInfo room = new RoomInfo();
                        room = bll.selectByRoomId(int.Parse(RoomId));
                        if (fmMain.xxkInder == 0)//所有
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            if (room.r_type.Equals("标准房"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flpStandard.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("单人房"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flyOne.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("商务房"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flyBusiness.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("商务单套"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flyLeveBus.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("海景房"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flySeaview.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("豪华单人"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flyDexSingle.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("豪华标准"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flyDexStandard.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("总统套房"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flyPresent.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else { }
                        }
                        else if (fmMain.xxkInder == 1)//标准房
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flpStandard.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 2)//单人房
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyOne.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 3)//商务房
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyBusiness.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 4)//商务单套
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyLeveBus.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 5)//海景房
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flySeaview.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 6)//豪华单人
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyDexSingle.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 7)//豪华标准
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyDexStandard.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 8)//总统套房
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyPresent.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else { }
                        this.Close();
                    }
                    else if (result == OpResult.no)
                    {
                        new showMessagecs("系统提示", "保存失败！").ShowDialog();
                    }
                    else
                    {
                        new showMessagecs("系统提示", "该客户已登记过！").ShowDialog();
                    }
                    //new showMessage("系统提示","成功").ShowDialog();

                }
                else
                {
                    new showMessagecs("系统提示", "有问题！").ShowDialog();
                }
                // fm.RoomLode();


            }
        }
        /// <summary>
        /// 无房间添加的登记界面
        /// </summary>
        private void DengJI()
        {
            int j = ZJPD(cardID.Text);
            if(j==1)
            {
                InInfo customer = new InInfo();
                customer.InType = roomType.Text;
                customer.in_number = DanHao;
                customer.r_id = int.Parse(RoomId);
                customer.c_name = this.userName.Text;
                if (male.Checked == true)
                {
                    customer.c_sex = true;
                }
                if (female.Checked == true)
                {
                    customer.c_sex = false;
                }
                // customer.r_id = int.Parse(roomNumber.Text);
                customer.zj_type = cardType.Text;
                customer.zj_number = cardID.Text;
                customer.c_address = address.Text;
                customer.c_intoday = inTime.Value;
                // customer.c_aboutdays = "";
                customer.foregift = float.Parse(textBox3.Text);
                customer.levatime = outTime.Value;
                customer.nationality = textBox1.Text;
                customer.C_Phone = phone.Text;
                customer.r_RelPrice = float.Parse(txtRoomRelPrice.Text);
                customer.InFriend = textBox5.Text;
                customer.C_inpeopleCount = int.Parse(numericUpDown1.Value.ToString());
                customer.Inhour = dateTimePicker1.Value;
                customer.leavehour = dateTimePicker2.Value;
                BLLcustomer Bcustomers = new BLLcustomer();
                int count = Bcustomers.updateTem2(int.Parse(RoomId));
                if (count > 0)
                {
                    OpResult result = Bcustomers.enroll(customer);
                    if (result == OpResult.yes)
                    {

                        new showMessageok("系统提示", "保存成功！").ShowDialog();
                        int lbyd = int.Parse(fm.label10.Text.ToString());
                        fm.label10.Text = (lbyd + 1).ToString();//预订改变
                        int lbkf = int.Parse(fm.label6.Text);
                        fm.label6.Text = (lbkf - 1).ToString();//空房改变
                        RoomInfoBLL bll = new RoomInfoBLL();
                        RoomInfo room = new RoomInfo();
                        room = bll.selectByRoomId(int.Parse(RoomId));
                        if (fmMain.xxkInder == 0)//所有
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            if (room.r_type.Equals("标准房"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flpStandard.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("单人房"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flyOne.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("商务房"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flyBusiness.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("商务单套"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flyLeveBus.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("海景房"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flySeaview.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("豪华单人"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flyDexSingle.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("豪华标准"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flyDexStandard.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else if (room.r_type.Equals("总统套房"))
                            {
                                UCRoom ucs = new UCRoom();
                                ucs = fm.flyPresent.Controls[RoomId] as UCRoom;
                                ucs.state = "3";
                                ucs.BGlode();
                            }
                            else { }
                        }
                        else if (fmMain.xxkInder == 1)//标准房
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flpStandard.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 2)//单人房
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyOne.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 3)//商务房
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyBusiness.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 4)//商务单套
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyLeveBus.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 5)//海景房
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flySeaview.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 6)//豪华单人
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyDexSingle.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 7)//豪华标准
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyDexStandard.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else if (fmMain.xxkInder == 8)//总统套房
                        {
                            UCRoom uc = new UCRoom();
                            uc = fm.flyPresent.Controls[RoomId] as UCRoom;
                            uc.state = "3";
                            uc.BGlode();
                            UCRoom uca = new UCRoom();
                            uca = fm.flyPanelAll.Controls[RoomId] as UCRoom;
                            uca.state = "3";
                            uca.BGlode();
                        }
                        else { }
                        this.Close();
                    }
                    else if (result == OpResult.no)
                    {
                        new showMessagecs("系统提示", "保存失败！").ShowDialog();
                    }
                    else
                    {
                        new showMessagecs("系统提示", "该客户已登记过！").ShowDialog();
                    }

                }
                else
                {
                    new showMessagecs("系统提示", "有问题！").ShowDialog();
                }
            }
           // fm.RoomLode();

           
        }//刷新问题待解决。

        private void roomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void roomType_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (roomType.SelectedIndex == 1)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 点击同住客人右侧小图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            //fmAddUser addu = new fmAddUser();
            //addu.ShowDialog();
            new showMessagecs("系统提示","请入住后在操作").ShowDialog();
        }

        private void cardID_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.cardID.Text != "")
                {
                    BLLcustomer bll = new BLLcustomer();
                    List<InInfo> Inlist = new List<InInfo>();
                    Inlist = bll.selectInByNumber(this.cardID.Text);
                    if (Inlist != null)
                    {
                        this.userName.Text = Inlist[0].c_name.ToString();
                        this.phone.Text = Inlist[0].C_Phone.ToString();
                        if (Inlist[0].c_sex == true)
                        {
                            this.male.Checked = true;
                            this.female.Checked = false;
                        }
                        else
                        {
                            this.female.Checked = true;
                            this.male.Checked = false;
                        }
                        this.address.Text = Inlist[0].c_address.ToString();
                        this.textBox1.Text = Inlist[0].nationality.ToString();
                    }
                    else
                    { }
                }
                else
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
