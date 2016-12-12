using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.Model;
using Hotel.BLL;

namespace Hotel.UI
{
    public partial class UCRoom : UserControl
    {
        //状态变量
        public string state = "";
        public static string id = "";
        public static string tp = "";
        public static string yrtp = "";
        public static int a = 0;//选项卡索引
        bool flag = false;
        private fmMain fm;
       fmMess tc = new fmMess();//悬停窗口
        private fmMain fms;
        public UCRoom()
        {
            InitializeComponent();
        }
        public UCRoom(fmMain fms)
        {
            this.fms = fms;
            fm=fms;
            InitializeComponent();
           

        }
        string kf100 = @"\image\k55.jpg";//空房背景
        string kfe102 = @"\image\k666.jpg";//空房移入
        string zuf104 = @"\image\r1010.jpg";//住房背景
        string zufe107 = @"\image\r999.jpg";//住房移入
        string zf105 = @"\image\2222.jpg";//脏房背景
        string zfe106 = @"\image\4444.jpg";//空房背景
        string yudbg = @"\image\1212.jpg";//预订背景
        string yudry = @"\image\1313.jpg";//预订移入
        string click103 = @"\image\k777.jpg";//空房点击
        string zuclick = @"\image\r144.jpg";//住房点击
        string zangclick = @"\image\3333.jpg";//脏房点击
        string yuding = @"\image\11111.jpg";//预订点击
        string tdbg = @"\image\tdbacks.jpg";//团队入住背景
        string tdyr = @"\image\tdyrbg.jpg";//团队移入背景
        string tdclik = @"\image\tdclik.jpg";//团队选中背景


        /// <summary>
        /// 背景加载，鼠标移入有边框
        /// </summary>
        private void BGenter()
        {
            if (state.Equals("0"))
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + kfe102);
            }
            else if (state.Equals("1"))
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + zufe107);
            }
            else if (state.Equals("2"))
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + zfe106);
            }
            else if (state.Equals("3"))
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + yudry);
            }
            else 
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + tdyr);
            }
        }
        /// <summary>
        /// 背景加载
        /// </summary>
        public void BGlode()
        {
            if (state.Equals("0"))
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + kf100);
                tp = kf100;
            }
            else if (state.Equals("1"))
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + zuf104);
                tp = zuf104;
            }
            else if (state.Equals("2"))
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + zf105);
                tp = zf105;
            }
            else if (state.Equals("3"))
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + yudbg);
                tp = yudbg;
            }
            else 
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + tdbg);
            }
            tc.Hide();
        }

        private void UCRoom_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Hide();
            id = this.lbRoonId.Text.Trim();
            if (this.BackColor == Color.DimGray)
            {
                BGlode();
            }

        }

        /// <summary>
        ///单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCRoom_Click(object sender, EventArgs e)
        {
            fmMain.RoomId = lbRoonId.Text;
           
        }

        private void 结账退房ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (state.Equals("1") || state.Equals("4"))
            {
                fmAccount fms = new fmAccount(int.Parse(this.lbRoonId.Text),fm);
                fms.ShowDialog();
            }
            else
            {
                new showMessagecs("系统提示", "空房不能结账退房！").ShowDialog();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (state.Equals("1") || state.Equals("4"))
            {
                FmSpend fm = new FmSpend(this.lbRoonId.Text, fms);
                fm.ShowDialog();
            }
            else
            {
                new showMessagecs("系统提示", "空房不能消费入单！").ShowDialog();
            }
        }

        private void 置空净房ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.state.Equals("2"))
            {
                new showMessagecs("系统提示", "该房不是脏房无法置净！").ShowDialog();
            }
            else
            {
                RoomInfoBLL bll = new RoomInfoBLL();
                int i = bll.opertState(this.lbRoonId.Text.Trim());
                if (i == 1)
                {
                    this.state = "0";
                    BGlode();
                }
                else
                {
                    new showMessagecs("系统提示","请联系管理员！").ShowDialog();
                }
            }
        }

        private void UCRoom_MouseEnter(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DimGray)
            {
                BGenter();
            }
            tc.Hide();
        }

        private void UCRoom_MouseClick(object sender, MouseEventArgs e)
        {

            TPtrans();
            Yrtp();
            a = fmMain.xxkInder;
            if (fmMain.RoomId != null)
            {
                INDEXLODE();
            }
            this.BackgroundImage = Image.FromFile(Application.StartupPath + yrtp);
            this.BackColor = Color.Red;
            fmMain.RoomId = lbRoonId.Text;
            fmMain.tpdz = tp;
            SpendFF();
        }
        /// <summary>
        /// 消费
        /// </summary>
        private void SpendFF()
        {
            this.fms.listView3.Items.Clear();
            if (this.state.Equals("1"))
            {
                fmMain.RoomId = this.lbRoonId.Text;
                try
                {
                    BLLcustomer bllsa = new BLLcustomer();
                    InInfo select = bllsa.selectByRooid(this.lbRoonId.Text);
                    CuspenBLL blls = new CuspenBLL();

                    this.fms.listView3.Items.Clear();

                    this.fms.listView3.Enabled = true;
                    if (select != null)
                    {
                        List<CusSpenInfo> Spendlist = new List<CusSpenInfo>();
                        this.fms.listView3.AllowDrop = true;
                        Spendlist = blls.SelectSpend(int.Parse(this.lbRoonId.Text), select.in_number);
                        for (int i = 0; i < Spendlist.Count; i++)
                        {

                            ListViewItem li = new ListViewItem(Spendlist[i].Goods_name.ToString());
                            li.SubItems.Add(Spendlist[i].g_price.ToString());
                            li.SubItems.Add(Spendlist[i].g_count.ToString());
                            li.SubItems.Add(Spendlist[i].totolAmount.ToString());
                            li.SubItems.Add(Spendlist[i].RoomId.ToString());
                            li.SubItems.Add(Spendlist[i].s_time.ToString());
                            li.SubItems.Add(Spendlist[i].operation.ToString());

                            this.fms.listView3.Items.Add(li);

                        }
                    }
                    else
                    {

                        //MessageBox.Show("该组内没有联系人");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            { }
        }
        /// <summary>
        /// 选项卡索引选择；
        /// </summary>
        private void INDEXLODE()
        {
            try
            {

                if (a == 0)//所有房间
                {
                    TabControl tb = new TabControl();
                    tb = this.Parent.Parent.Parent as TabControl;
                    tb.TabPages[0].Controls["flyPanelAll"].Controls[fmMain.RoomId].BackgroundImage = Image.FromFile(Application.StartupPath + fmMain.tpdz);
                    tb.TabPages[0].Controls["flyPanelAll"].Controls[fmMain.RoomId].BackColor = Color.DimGray;
                }
                else if (a == 1)//标准房
                {
                    TabControl tb = new TabControl();
                    tb = this.Parent.Parent.Parent as TabControl;
                    tb.TabPages[1].Controls["flpStandard"].Controls[fmMain.RoomId].BackgroundImage = Image.FromFile(Application.StartupPath + fmMain.tpdz);
                    tb.TabPages[1].Controls["flpStandard"].Controls[fmMain.RoomId].BackColor = Color.DimGray;
                }
                else if (a == 2)//单人房
                {
                    TabControl tb = new TabControl();
                    tb = this.Parent.Parent.Parent as TabControl;
                    tb.TabPages[2].Controls["flyOne"].Controls[fmMain.RoomId].BackgroundImage = Image.FromFile(Application.StartupPath + fmMain.tpdz);
                    tb.TabPages[2].Controls["flyOne"].Controls[fmMain.RoomId].BackColor = Color.DimGray;
                }
                else if (a == 3)//商务房
                {
                    TabControl tb = new TabControl();
                    tb = this.Parent.Parent.Parent as TabControl;
                    tb.TabPages[3].Controls["flyBusiness"].Controls[fmMain.RoomId].BackgroundImage = Image.FromFile(Application.StartupPath + fmMain.tpdz);
                    tb.TabPages[3].Controls["flyBusiness"].Controls[fmMain.RoomId].BackColor = Color.DimGray;
                }
                else if (a == 4)//商务单套
                {
                    TabControl tb = new TabControl();
                    tb = this.Parent.Parent.Parent as TabControl;
                    tb.TabPages[4].Controls["flyLeveBus"].Controls[fmMain.RoomId].BackgroundImage = Image.FromFile(Application.StartupPath + fmMain.tpdz);
                    tb.TabPages[4].Controls["flyLeveBus"].Controls[fmMain.RoomId].BackColor = Color.DimGray;
                }
                else if (a == 5)//海景房
                {
                    TabControl tb = new TabControl();
                    tb = this.Parent.Parent.Parent as TabControl;
                    tb.TabPages[5].Controls["flySeaview"].Controls[fmMain.RoomId].BackgroundImage = Image.FromFile(Application.StartupPath + fmMain.tpdz);
                    tb.TabPages[5].Controls["flySeaview"].Controls[fmMain.RoomId].BackColor = Color.DimGray;
                }

                else if (a == 6)//豪华单人
                {
                    TabControl tb = new TabControl();
                    tb = this.Parent.Parent.Parent as TabControl;
                    tb.TabPages[6].Controls["flyDexSingle"].Controls[fmMain.RoomId].BackgroundImage = Image.FromFile(Application.StartupPath + fmMain.tpdz);
                    tb.TabPages[6].Controls["flyDexSingle"].Controls[fmMain.RoomId].BackColor = Color.DimGray;
                }
                else if (a == 7)//豪华标准
                {
                    TabControl tb = new TabControl();
                    tb = this.Parent.Parent.Parent as TabControl;
                    tb.TabPages[7].Controls["flyDexStandard"].Controls[fmMain.RoomId].BackgroundImage = Image.FromFile(Application.StartupPath + fmMain.tpdz);
                    tb.TabPages[7].Controls["flyDexStandard"].Controls[fmMain.RoomId].BackColor = Color.DimGray;
                }
                else if (a == 8)//总统套房
                {
                    TabControl tb = new TabControl();
                    tb = this.Parent.Parent.Parent as TabControl;
                    tb.TabPages[8].Controls["flyPresent"].Controls[fmMain.RoomId].BackgroundImage = Image.FromFile(Application.StartupPath + fmMain.tpdz);
                    tb.TabPages[8].Controls["flyPresent"].Controls[fmMain.RoomId].BackColor = Color.DimGray;
                }
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }
        /// <summary>
        /// 将当前的状态背景地址获取
        /// </summary>
        private void TPtrans()
        {
            if (state.Equals("0"))
            {
                tp = kf100;
            }
            else if (state.Equals("1"))
            {
                tp = zuf104;
            }
            else if (state.Equals("2"))
            {
                tp = zf105;
            }
            else if (state.Equals("3"))
            {
                tp = yudbg;
            }
            else 
            {
                tp = tdbg;
            }
        }
        /// <summary>
        /// 移入选中状态图片地址问题的判断。
        /// </summary>
        private void Yrtp()
        {
            if (state.Equals("0"))
            {
                yrtp = click103;
            }
            else if (state.Equals("1"))
            {
                yrtp = zuclick;
            }
            else if (state.Equals("2"))
            {
                yrtp = zangclick;
            }
            else if (state.Equals("3"))
            {
                yrtp = yuding;
            }
            else 
            {
                yrtp = tdclik;
            }
        }

        private void UCRoom_MouseLeave(object sender, EventArgs e)
        {
            tc.Hide();
            if (this.BackColor == Color.DimGray)
            {
                BGlode();
            }
        }
        private void lbENter(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DimGray)
            {
                BGenter();
            }
            else 
            {
                Yrtp();
                this.BackgroundImage = Image.FromFile(Application.StartupPath + yrtp);
            }

        }
        private void lbLeve(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DimGray)
            {
                BGlode();
            }
            else
            {
                Yrtp();
                this.BackgroundImage = Image.FromFile(Application.StartupPath + yrtp);
            }

        }

        private void UCRoom_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tc.Hide();
            fmMain.RoomId = lbRoonId.Text;
            if (this.state.Equals("0"))
            {
                fmUser fm = new fmUser(this.lbRoonId.Text, fmMain.userOper,fms);
                fm.ShowDialog();
            }
            else if (state.Equals("1"))
            {
                fmInAlter fmin = new fmInAlter(this.lbRoonId.Text, fm);
                fmin.ShowDialog();
            }
            else if (state.Equals("2"))
            {
                new showMessage("系统提示", "确定要将该房间置为空房？").ShowDialog();
                if (showMessage.result.Equals(true))
                {
                    RoomInfoBLL bll = new RoomInfoBLL();
                    int i = bll.opertState(this.lbRoonId.Text.Trim());
                    if (i == 1)
                    {
                        this.state = "0";
                        BGlode();
                    }
                    else
                    {
                        new showMessagecs("系统提示", "操作失败，请联系管理员！").ShowDialog();
                    }
                }
                else { }
            }
            else if (state.Equals("3"))
            {
                fmBookAlter fm = new fmBookAlter(this.lbRoonId.Text, fmMain.userOper,fms);
                fm.ShowDialog(); 
            }
            else 
            {
                fmInAlter fmin = new fmInAlter(this.lbRoonId.Text, fm);
                fmin.ShowDialog();
            }
        }
        /// <summary>
        /// 鼠标悬停事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCRoom_MouseHover(object sender, EventArgs e)
        {
            hoveRoomMessLode();
            Point po = new Point();
            po = this.Location;
            po.X = po.X + 250;
            po.Y = po.Y + 220;
            tc.Location = po;
            tc.Show();
        }

        private void hoveRoomMessLode()
        {
            if (state.Equals("0"))
            {
                tc.lbRoomId.Text = this.lbRoonId.Text;
                tc.lbRoomState.Text = "空房";
                RoomInfoBLL bll = new RoomInfoBLL();
                RoomInfo room = new RoomInfo();
                room = bll.selectByRoomId(int.Parse(this.lbRoonId.Text));
                tc.lbRoomPrice.Text = room.r_price.ToString();

            }
            else if (state.Equals("1"))
            {
                tc.lbRoomId.Text = this.lbRoonId.Text;
                tc.lbRoomState.Text = "在住";
                BLLcustomer cus = new BLLcustomer();
                InInfo infofo = new InInfo();
                infofo = cus.selectByRooid(this.lbRoonId.Text);
                if (infofo != null)
                {
                    tc.lbCusName.Text = infofo.c_name.ToString();
                    tc.lbInTime.Text = infofo.c_intoday.ToShortDateString();
                    tc.lbLeveTime.Text = infofo.levatime.ToShortDateString(); ;
                    tc.lbRoomPrice.Text = infofo.r_RelPrice.ToString();
                    tc.lbRoomYaJin.Text = infofo.foregift.ToString();
                }
                List<InInfo> listinfo = new List<InInfo>();
                listinfo = cus.selectIdCount(this.lbRoonId.Text);
                if (listinfo.Count == 2)
                {
                    tc.lbYd.Text = "有人预定";
                    for (int i = 0; i < listinfo.Count; i++)
                    {
                        if (!listinfo[i].r_id.Equals(this.lbRoonId))
                        {
                            tc.lbTime.Text = listinfo[i].c_intoday.ToShortDateString();
                        }
                    }
                }   

            }
            else if (state.Equals("2"))
            {
                tc.lbRoomId.Text = this.lbRoonId.Text;
                tc.lbRoomState.Text = "脏房";
                tc.lbRoomPrice.Text = "不可用";
                BLLcustomer cus = new BLLcustomer();
                InInfo infofo = new InInfo();
                infofo = cus.selectByRooid(this.lbRoonId.Text);
                if (infofo != null)
                {
                    tc.lbRoomState.Text = "脏房有人预定";
                    tc.lbCusName.Text = infofo.c_name.ToString();
                    tc.lbInTime.Text = infofo.c_intoday.ToShortDateString();
                    tc.lbLeveTime.Text = infofo.levatime.ToShortDateString(); ;
                    tc.lbRoomPrice.Text = infofo.r_RelPrice.ToString();
                    tc.lbRoomYaJin.Text = infofo.foregift.ToString();
                }
            }
            else if (state.Equals("3"))
            {
                tc.lbRoomId.Text = this.lbRoonId.Text;
                tc.lbRoomState.Text = "预订房";
                BLLcustomer cus = new BLLcustomer();
                InInfo infofo = new InInfo();
                infofo = cus.selectByRooid(this.lbRoonId.Text);
                if (infofo != null)
                {
                    tc.lbCusName.Text = infofo.c_name.ToString();
                    tc.lbInTime.Text = infofo.c_intoday.ToShortDateString();
                    tc.lbLeveTime.Text = infofo.levatime.ToShortDateString(); ;
                    tc.lbRoomPrice.Text = infofo.r_RelPrice.ToString();
                    tc.lbRoomYaJin.Text = infofo.foregift.ToString();
                }
            }
            else 
            {
                tc.lbRoomId.Text = this.lbRoonId.Text;
                tc.lbRoomState.Text = "团队入住";
                BLLcustomer cus = new BLLcustomer();
                InInfo infofo = new InInfo();
                infofo = cus.selectByRooid(this.lbRoonId.Text);
                if (infofo != null)
                {
                    tc.lbCusName.Text = infofo.c_name.ToString();
                    tc.lbInTime.Text = infofo.c_intoday.ToShortDateString();
                    tc.lbLeveTime.Text = infofo.levatime.ToShortDateString(); ;
                    tc.lbRoomPrice.Text = infofo.r_RelPrice.ToString();
                    tc.lbRoomYaJin.Text = infofo.foregift.ToString();
                }
            }

        }

        private void UCRoom_Leave(object sender, EventArgs e)
        {
            tc.Hide();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tc.Hide();           
                if (state.Equals("0"))
                {
                    Foregift hotel = new Foregift(this.lbRoonId.Text, fmMain.userOper,fm);
                    hotel.ShowDialog();
                }
                else if (state.Equals("1"))
                {
                    new showMessagecs("系统提示", "该房已有客人入住！").ShowDialog();
                }
                else if (state.Equals("2"))
                {
                    new showMessagecs("系统提示", "请将脏房置净！").ShowDialog();
                }
                else if (state.Equals("3"))
                {
                    new showMessagecs("系统提示", "该房已有客人预订！").ShowDialog();
                }
                else 
                {
                    new showMessagecs("系统提示", "该房已有客人入住！").ShowDialog();
                }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            tc.Hide();
            if (state.Equals("0"))
            {
                fmUser users = new fmUser(this.lbRoonId.Text, fmMain.userOper, fm);
                users.ShowDialog();
            }
            else if (state.Equals("1"))
            {
                new showMessagecs("系统提示", "该房已有客人入住！").ShowDialog();

            }
            else if (state.Equals("2"))
            {
                new showMessagecs("系统提示", "请将脏房置净！").ShowDialog();
            }
            else if (state.Equals("3"))
            {
                new showMessagecs("系统提示", "该房已被预订，确定他人入住吗？").ShowDialog();
                if (showMessagecs.result.Equals(true))
                {
                    BLLcustomer cus = new BLLcustomer();
                    InInfo roommes = new InInfo();
                    roommes = cus.selectByRooid(this.lbRoonId.Text);
                    fmUser users = new fmUser(this.lbRoonId.Text, fmMain.userOper, fm,roommes);
                    users.ShowDialog();
                }
                else
                {
                   // MessageBox.Show("有");
                }
            }
            else
            {
                new showMessagecs("系统提示", "该房已有客人入住").ShowDialog();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            tc.Hide();
            if (this.state.Equals("1") || this.state.Equals("4"))
            {
                fmRoomChange roomchange = new fmRoomChange(this.lbRoonId.Text, fm);
                roomchange.ShowDialog();
            }
            else 
            {
                new showMessagecs("系统提示","空房或预定不可更改").ShowDialog();
            }
            
        }

        private void 修改登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tc.Hide();
            fmMain.RoomId = lbRoonId.Text;
            if (this.state.Equals("0"))
            {
                new showMessagecs("系统提示", "该房无人入住，不能修改").ShowDialog();
            }
            else if (state.Equals("1"))
            {
                fmInAlter fmin = new fmInAlter(this.lbRoonId.Text, fm);
                fmin.ShowDialog();
            }
            else if (state.Equals("2"))
            {
                new showMessage("系统提示", "确定要将该房间置为空房？").ShowDialog();
                if (showMessage.result.Equals(true))
                {
                    RoomInfoBLL bll = new RoomInfoBLL();
                    int i = bll.opertState(this.lbRoonId.Text.Trim());
                    if (i == 1)
                    {
                        this.state = "0";
                        BGlode();
                    }
                    else
                    {
                        new showMessagecs("系统提示", "操作失败，请联系管理员！").ShowDialog();
                    }
                }
                else { }
            }
            else if (state.Equals("3"))
            {
                fmBookAlter fm = new fmBookAlter(this.lbRoonId.Text, fmMain.userOper,fms);
                fm.Show();
            }
            else 
            {
                fmInAlter fmin = new fmInAlter(this.lbRoonId.Text, fm);
                fmin.ShowDialog();
            }
        }

        private void lbRoonId_Click(object sender, EventArgs e)
        {

        }

        private void 改为预定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tc.Hide();
            if (!this.state.Equals("1"))
            {

                RoomInfoBLL bll = new RoomInfoBLL();
                int i = bll.OpertStateYd(this.lbRoonId.Text.Trim());
                if (i == 1)
                {
                    this.state = "3";
                    BGlode();
                }
                else
                {
                    new showMessagecs("系统提示", "请联系管理员！").ShowDialog();
                }
            }
            else
            {
                new showMessagecs("系统提示", "该房不有人入住！").ShowDialog();
            }
        }

        private void 置空净房ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!this.state.Equals("2"))
            {
                new showMessagecs("系统提示", "该房不是脏房无法置净！").ShowDialog();
            }
            else
            {
                RoomInfoBLL bll = new RoomInfoBLL();
                int i = bll.opertState(this.lbRoonId.Text.Trim());
                if (i == 1)
                {
                    this.state = "0";
                    BGlode();
                }
                else
                {
                    new showMessagecs("系统提示", "请联系管理员！").ShowDialog();
                }
            }
        }



    }
}
