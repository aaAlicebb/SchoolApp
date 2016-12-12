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
using System.Data.SqlClient;



namespace Hotel.UI
{
    public partial class fmMain : Form
    {
        public static string RoomId;
        public static string tpdz;
        public static int xxkInder = 0;
       
        
        //主板本
        AutoSizeFormClass asc = new AutoSizeFormClass();
        UserInfo user = new UserInfo();//登录操作员传值
        public static UserInfo userOper;
        
        public fmMain() { InitializeComponent(); }
         public fmMain(UserInfo us)
        {
            userOper = us;
             user = us;
             InitializeComponent();          
           //this.flyPanelAll.Resize += new System.EventHandler(this.flowLayoutPanel2_Resize);//FlowLayoutPanel大小自适应
            
        }
         public void SetNotifyInfo(int percent, string message)
         { }
        /// <summary>
        /// 窗体移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        Point mouseOff;
        bool leftFlag;
        private void fmMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
          
        }

        private void fmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); 
                leftFlag = true;                 
            }
        }

        private void fmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  
                Location = mouseSet;
            }
        }
        /// <summary>
        /// 窗体最上方panel可拖动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmMain_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“hotelsDataSet1.V_cutomerInfo”中。您可以根据需要移动或删除它。
           // this.v_cutomerInfoTableAdapter.Fill(this.hotelsDataSet1.V_cutomerInfo);
           
            RoomLode();
            //this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.tabPage2.Parent = null;//默认情况不显示物料设置
            this.tabPage6.Parent = null;//默认情况不显示会员管理
            this.tabPage7.Parent = null;//默认情况不显示报表
            int oldwidth = this.Width;
            asc.controllInitializeSize(this);//窗体最大化自适应
            this.tabControl2.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl2.DrawItem += new DrawItemEventHandler(this.tabControl2_DrawItem);//改变tabcontrol选项卡背景
            this.panel1.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\bac99.jpg");
            getSpend();
        }
        /// <summary>
        /// 获取价格
        /// </summary>
        private void getSpend()
        {
            try
            {
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

                                //ListViewItem li = new ListViewItem(Spendlist[i].g_price.ToString());
                                //li.SubItems.Clear();
                                //li.SubItems.Add(Goodslist[i].Goods_BM.ToString());

                                //li.SubItems.Add(Spendlist[i].g_count.ToString());
                                //li.SubItems.Add(Spendlist[i].totolAmount.ToString());
                                //li.SubItems.Add(Spendlist[i].RoomId.ToString());
                                //li.SubItems.Add(Spendlist[i].s_time.ToString());
                                //li.SubItems.Add(Spendlist[i].operation.ToString());
                                //li.SubItems.Add(Spendlist[i].Goods_name.ToString());

                                sum = sum + float.Parse(Spendlist[j].totolAmount.ToString());
                                //MessageBox.Show(float.Parse(Spendlist[i].totolAmount.ToString()).ToString());

                            }
                        }
                        item.SubItems.Add((float.Parse(Inlist[i].r_RelPrice.ToString()) * (DateTime.Now.Subtract(Inlist[i].c_intoday)).Days + sum).ToString());
                        this.listView2.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fmMain_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
            this.WindowState = (System.Windows.Forms.FormWindowState)(2);
        }
        private void MainPage_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);

        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
        /// <summary>
        /// 加载房间
        /// </summary>
        public void RoomLode()
        {
            RoomId = null;
            List<RoomInfo> list = new List<RoomInfo>();
            RoomInfoBLL bll = new RoomInfoBLL();
            list = bll.RoomLode();
            this.label6.Text = bll.SelectByState(0).ToString();//空房数
            this.label7.Text = (bll.SelectByState(1)+bll.SelectByState(4)).ToString();//住房数
            this.label8.Text = bll.SelectByState(2).ToString();//脏房数
            this.label1.Text = list.Count.ToString();//所有房间数。
            this.label10.Text = bll.SelectByState(3).ToString();//预订房间数
            if (list == null)
            {
                MessageBox.Show("无房间信息");
            }
            //所有房间加载
            this.flyPanelAll.Controls.Clear();
            this.flpStandard.Controls.Clear();
            this.flyBusiness.Controls.Clear();
            this.flyDexSingle.Controls.Clear();
            this.flyDexStandard.Controls.Clear();
            this.flyOne.Controls.Clear();
            this.flySeaview.Controls.Clear();
            this.flyPresent.Controls.Clear();
            this.flyLeveBus.Controls.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                UCRoom room = new UCRoom(this);
                room.lbRoonId.Text = list[i].r_id.ToString();
                room.lbRoomType.Text = list[i].r_type.ToString();
                room.state = list[i].r_state.ToString();
                room.Name = list[i].r_id.ToString();
                this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Add(room);
            }
            //标准房
            
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].r_type.ToString().Equals("标准房"))
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbStandard"].Controls["flpStandard"].Controls.Add(room);
                }
            }
            //商务房
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].r_type.ToString().Equals("商务房"))
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbBusiness"].Controls["flyBusiness"].Controls.Add(room);
                }
            }
            //单人房
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].r_type.ToString().Equals("单人房"))
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbOne"].Controls["flyOne"].Controls.Add(room);
                }
            }
            //商务单套
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].r_type.ToString().Equals("商务单套"))
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbLeveBus"].Controls["flyLeveBus"].Controls.Add(room);
                }
            }
            //豪华单人
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].r_type.ToString().Equals("豪华单人"))
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbDeluxeSingle"].Controls["flyDexSingle"].Controls.Add(room);
                }
            }
            //豪华标间
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].r_type.ToString().Equals("豪华标间"))
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbDeluxeStandard"].Controls["flyDexStandard"].Controls.Add(room);
                }
            }
            //海景房
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].r_type.ToString().Equals("海景房"))
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbSeaview"].Controls["flySeaview"].Controls.Add(room);
                }
            }
            //总统套房
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].r_type.ToString().Equals("总统套房"))
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbPresent"].Controls["flyPresent"].Controls.Add(room);
                }
            }

        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fmLogin login = new fmLogin();
            login.ShowDialog();
        }

        private void orderPictureBox_Click(object sender, EventArgs e)
        {
            if (RoomId != null)
            {
                Foregift hotel = new Foregift(RoomId,user,this);
                hotel.ShowDialog();
            }
            else 
            {
                new showMessage("系统提示", "请选择房间").ShowDialog();
            }
            
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        /// <summary>
        /// 点击仓库管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.tabPage2.Parent=this.tabControl1;
            this.tabControl1.SelectedIndex = 1;
           
        }
        /// <summary>
        /// 仓库管理右键关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int c=tabControl1.SelectedIndex;
            if(tabControl1.SelectedIndex>0)
            {
                if (c == 0)
                {
                    new showMessagecs("系统提示", "房态图不能关闭").ShowDialog();
                    if (showMessage.result.Equals(true))
                    {

                    }
                    else { }

                }
                else { tabControl1.TabPages[c].Parent = null; }
                
            }
            
           // this.tabPage2.Parent = null;
        }
        
       
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            new showMessage("系统提示", "你确定要退出当前系统吗？").ShowDialog();
            if (showMessage.result.Equals(true))
            {
                Application.Exit();
            }
            else { }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.label5.Text = DateTime.Now.ToString();
        }
        /// <summary>
        /// 空房按钮事件，请勿更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            RoomId = null;
            int a = int.Parse(this.tabControl2.SelectedIndex.ToString());//获取当前选显卡的索引
            if (a == 0)//所有房间
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();

                list = bll.RoomLode();
                if (list == null)
                {
                    MessageBox.Show("无房间信息");
                }
                //所有房间加载
                this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Clear();
                //this.flowLayoutPanel2.Controls.Clear();
                for (int i = 0; i < list.Count; i++)
                {

                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    if(room.state.Equals("0"))
                    {
                    this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Add(room);
                    }                   
                }
            }
            else if (a == 1)//标准房
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.RoomLode();
                this.tabControl2.TabPages["tbStandard"].Controls["flpStandard"].Controls.Clear();
                if (list == null)
                {
                    MessageBox.Show("无房间信息");
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].r_type.ToString().Equals("标准房"))
                    {
                        UCRoom room = new UCRoom(this);
                        room.lbRoonId.Text = list[i].r_id.ToString();
                        room.lbRoomType.Text = list[i].r_type.ToString();
                        room.state = list[i].r_state.ToString();
                        room.Name = list[i].r_id.ToString();
                       if(room.state.Equals("0"))
                        {
                        this.tabControl2.TabPages["tbStandard"].Controls["flpStandard"].Controls.Add(room);
                         }
                    }
                }
            }
            else if (a == 2)//单人房
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.RoomLode();
                this.tabControl2.TabPages["tbOne"].Controls["flyOne"].Controls.Clear();
                if (list == null)
                {
                    MessageBox.Show("无房间信息");
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].r_type.ToString().Equals("单人房"))
                    {
                        UCRoom room = new UCRoom(this);
                        room.lbRoonId.Text = list[i].r_id.ToString();
                        room.lbRoomType.Text = list[i].r_type.ToString();
                        room.state = list[i].r_state.ToString();
                        room.Name = list[i].r_id.ToString();
                         if(room.state.Equals("0"))
                        {
                        this.tabControl2.TabPages["tbOne"].Controls["flyOne"].Controls.Add(room);                       
                         }
                       
                    }
                }
            }
            else if (a == 3)//商务房
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.RoomLode();
                this.tabControl2.TabPages["tbBusiness"].Controls["flyBusiness"].Controls.Clear();
                if (list == null)
                {
                    MessageBox.Show("无房间信息");
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].r_type.ToString().Equals("商务房"))
                    {
                        UCRoom room = new UCRoom(this);
                        room.lbRoonId.Text = list[i].r_id.ToString();
                        room.lbRoomType.Text = list[i].r_type.ToString();
                        room.state = list[i].r_state.ToString();
                        room.Name = list[i].r_id.ToString();
                         if(room.state.Equals("0"))
                        {
                        this.tabControl2.TabPages["tbBusiness"].Controls["flyBusiness"].Controls.Add(room);                       
                         }
                       
                    }
                }
            }
            else if (a == 4)//商务单套
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.RoomLode();
                this.tabControl2.TabPages["tbLeveBus"].Controls["flyLeveBus"].Controls.Clear();
                if (list == null)
                {
                    MessageBox.Show("无房间信息");
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].r_type.ToString().Equals("商务单套"))
                    {
                        UCRoom room = new UCRoom(this);
                        room.lbRoonId.Text = list[i].r_id.ToString();
                        room.lbRoomType.Text = list[i].r_type.ToString();
                        room.state = list[i].r_state.ToString();
                        room.Name = list[i].r_id.ToString();
                         if(room.state.Equals("0"))
                        {
                       this.tabControl2.TabPages["tbLeveBus"].Controls["flyLeveBus"].Controls.Add(room);                       
                         }
                    }
                }
            }
            else if (a == 5)//海景房
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.RoomLode();
                this.tabControl2.TabPages["tbSeaview"].Controls["flySeaview"].Controls.Clear();
                if (list == null)
                {
                    MessageBox.Show("无房间信息");
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].r_type.ToString().Equals("海景房"))
                    {
                        UCRoom room = new UCRoom(this);
                        room.lbRoonId.Text = list[i].r_id.ToString();
                        room.lbRoomType.Text = list[i].r_type.ToString();
                        room.state = list[i].r_state.ToString();
                        room.Name = list[i].r_id.ToString();
                         if(room.state.Equals("0"))
                        {
                       this.tabControl2.TabPages["tbSeaview"].Controls["flySeaview"].Controls.Add(room);                     
                         }
                       
                    }
                }
            }
            
            else if (a == 6)//豪华单人
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.RoomLode();
                this.tabControl2.TabPages["tbDeluxeSingle"].Controls["flyDexSingle"].Controls.Clear();
                if (list == null)
                {
                    MessageBox.Show("无房间信息");
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].r_type.ToString().Equals("豪华单人"))
                    {
                        UCRoom room = new UCRoom(this);
                        room.lbRoonId.Text = list[i].r_id.ToString();
                        room.lbRoomType.Text = list[i].r_type.ToString();
                        room.state = list[i].r_state.ToString();
                        room.Name = list[i].r_id.ToString();
                         if(room.state.Equals("0"))
                        {
                       this.tabControl2.TabPages["tbDeluxeSingle"].Controls["flyDexSingle"].Controls.Add(room);                   
                         }
                       
                    }
                }
            }
            else if (a == 7)//豪华标准
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.RoomLode();
                this.tabControl2.TabPages["tbDeluxeStandard"].Controls["flyDexStandard"].Controls.Clear();
                if (list == null)
                {
                    MessageBox.Show("无房间信息");
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].r_type.ToString().Equals("海景房"))
                    {
                        UCRoom room = new UCRoom(this);
                        room.lbRoonId.Text = list[i].r_id.ToString();
                        room.lbRoomType.Text = list[i].r_type.ToString();
                        room.state = list[i].r_state.ToString();
                        room.Name = list[i].r_id.ToString();
                           if(room.state.Equals("0"))
                        {
                      this.tabControl2.TabPages["tbDeluxeStandard"].Controls["flyDexStandard"].Controls.Add(room);                  
                         }
                       
                    }
                }
            }
            else if (a == 8)//总统套房
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.RoomLode();
                this.tabControl2.TabPages["tbPresent"].Controls["flyPresent"].Controls.Clear();
                if (list == null)
                {
                    MessageBox.Show("无房间信息");
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].r_type.ToString().Equals("总统套房"))
                    {
                        UCRoom room = new UCRoom(this);
                        room.lbRoonId.Text = list[i].r_id.ToString();
                        room.lbRoomType.Text = list[i].r_type.ToString();
                        room.state = list[i].r_state.ToString();
                        room.Name = list[i].r_id.ToString();
                            if(room.state.Equals("0"))
                        {
                     this.tabControl2.TabPages["tbPresent"].Controls["flyPresent"].Controls.Add(room);              
                         }
                       
                    }
                }
            }
            else
            {
                MessageBox.Show("请刷新房态");
            }


        }
           
        
        
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
           
        }
        int oldsize = 0;
        private void flowLayoutPanel2_Resize(object sender, EventArgs e)
        {
            if(oldsize!=this.flyPanelAll.Width)
            {                
                oldsize = this.Width;
            }
        }

        
        
        /// <summary>
        /// 窗体最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click_1(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// tabcontrol选项卡美化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl2_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            StringFormat sf = new StringFormat();

            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            if (e.Index == tabControl2.SelectedIndex)
            {
                e.Graphics.FillRectangle(Brushes.SkyBlue, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                e.Graphics.DrawString(((TabControl)sender).TabPages[e.Index].Text,
                System.Windows.Forms.SystemInformation.MenuFont, new SolidBrush(Color.Black), e.Bounds, sf);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label5.Text = DateTime.Now.ToString();
        }

        private void fmMain_Resize(object sender, EventArgs e)
        {
           
        }

        private void flowLayoutPanel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
        /// <summary>
        ///全部按钮事件，显示所有结果集。请勿私自更改.代码已优化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            RoomId = null;
            int a = int.Parse(this.tabControl2.SelectedIndex.ToString());//获取当前选显卡的索引
            if (a == 0)//所有房间
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.RoomLode();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                //所有房间加载
                this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Clear();

                for (int i = 0; i < list.Count; i++)
                {

                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Add(room);
                }
            }
            else if (a == 1)//标准房
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByType("标准房");
                this.tabControl2.TabPages["tbStandard"].Controls["flpStandard"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbStandard"].Controls["flpStandard"].Controls.Add(room);
                }

            }
            else if (a == 2)//单人房
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByType("单人房");
                this.tabControl2.TabPages["tbOne"].Controls["flyOne"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {

                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbOne"].Controls["flyOne"].Controls.Add(room);
                }

            }
            else if (a == 3)//商务房
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByType("商务房");
                this.tabControl2.TabPages["tbBusiness"].Controls["flyBusiness"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {

                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbBusiness"].Controls["flyBusiness"].Controls.Add(room);
                }

            }
            else if (a == 4)//商务单套
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByType("商务单套");
                this.tabControl2.TabPages["tbLeveBus"].Controls["flyLeveBus"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbLeveBus"].Controls["flyLeveBus"].Controls.Add(room);
                }

            }
            else if (a == 5)//海景房
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByType("海景房");
                this.tabControl2.TabPages["tbSeaview"].Controls["flySeaview"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbSeaview"].Controls["flySeaview"].Controls.Add(room);
                }
            }
            else if (a == 6)//豪华单人
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByType("豪华单人");
                this.tabControl2.TabPages["tbDeluxeSingle"].Controls["flyDexSingle"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {

                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbDeluxeSingle"].Controls["flyDexSingle"].Controls.Add(room);
                }

            }
            else if (a == 7)//豪华标准
            {
                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByType("豪华标准");
                this.tabControl2.TabPages["tbDeluxeStandard"].Controls["flyDexStandard"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbDeluxeStandard"].Controls["flyDexStandard"].Controls.Add(room);
                }
            }
            else if (a == 8)//总统套房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByType("总统套房");
                this.tabControl2.TabPages["tbPresent"].Controls["flyPresent"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbPresent"].Controls["flyPresent"].Controls.Add(room);
                }

            }
            else
            {
                new showMessagecs("系统提示", "请刷新房态！").ShowDialog();
            }

        }
        /// <summary>
        /// 住房按钮时间，谨慎操作，已经优化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            RoomId = null;
            int a = int.Parse(this.tabControl2.SelectedIndex.ToString());//获取当前选显卡的索引
            if (a == 0)//所有房间
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByState("1");
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                //所有房间加载
                this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Clear();
                for (int i = 0; i < list.Count; i++)
                {

                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Add(room);
                }
            }
            else if (a == 1)//标准房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("标准房", "1");
                List<RoomInfo> lists = new List<RoomInfo>();
                lists = bll.selectByStateAndRoomType("标准房", "4");
                this.tabControl2.TabPages["tbStandard"].Controls["flpStandard"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbStandard"].Controls["flpStandard"].Controls.Add(room);
                }
                for (int i = 0; i < lists.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = lists[i].r_id.ToString();
                    room.lbRoomType.Text = lists[i].r_type.ToString();
                    room.state = lists[i].r_state.ToString();
                    room.Name = lists[i].r_id.ToString();
                    this.tabControl2.TabPages["tbStandard"].Controls["flpStandard"].Controls.Add(room);
                }
            }
            else if (a == 2)//单人房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("单人房", "1");
                List<RoomInfo> lists = new List<RoomInfo>();
                lists = bll.selectByStateAndRoomType("单人房", "4");
                this.tabControl2.TabPages["tbOne"].Controls["flyOne"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbOne"].Controls["flyOne"].Controls.Add(room);
                }
                for (int i = 0; i < lists.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = lists[i].r_id.ToString();
                    room.lbRoomType.Text = lists[i].r_type.ToString();
                    room.state = lists[i].r_state.ToString();
                    room.Name = lists[i].r_id.ToString();
                    this.tabControl2.TabPages["tbOne"].Controls["flyOne"].Controls.Add(room);
                }

            }
            else if (a == 3)//商务房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("商务房", "1");
                List<RoomInfo> lists = new List<RoomInfo>();
                lists = bll.selectByStateAndRoomType("商务房", "4");
                this.tabControl2.TabPages["tbBusiness"].Controls["flyBusiness"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbBusiness"].Controls["flyBusiness"].Controls.Add(room);
                }
                for (int i = 0; i < lists.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = lists[i].r_id.ToString();
                    room.lbRoomType.Text = lists[i].r_type.ToString();
                    room.state = lists[i].r_state.ToString();
                    room.Name = lists[i].r_id.ToString();
                    this.tabControl2.TabPages["tbBusiness"].Controls["flyBusiness"].Controls.Add(room);
                }
            }
            else if (a == 4)//商务单套
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("商务单套", "1");
                List<RoomInfo> lists = new List<RoomInfo>();
                lists = bll.selectByStateAndRoomType("商务单套", "4");
                this.tabControl2.TabPages["tbLeveBus"].Controls["flyLeveBus"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbLeveBus"].Controls["flyLeveBus"].Controls.Add(room);
                }
                for (int i = 0; i < lists.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = lists[i].r_id.ToString();
                    room.lbRoomType.Text = lists[i].r_type.ToString();
                    room.state = lists[i].r_state.ToString();
                    room.Name = lists[i].r_id.ToString();
                    this.tabControl2.TabPages["tbLeveBus"].Controls["flyLeveBus"].Controls.Add(room);
                }
            }
            else if (a == 5)//海景房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("海景房", "1");
                List<RoomInfo> lists = new List<RoomInfo>();
                lists = bll.selectByStateAndRoomType("海景房", "4");
                this.tabControl2.TabPages["tbSeaview"].Controls["flySeaview"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbSeaview"].Controls["flySeaview"].Controls.Add(room);

                }
                for (int i = 0; i < lists.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = lists[i].r_id.ToString();
                    room.lbRoomType.Text = lists[i].r_type.ToString();
                    room.state = lists[i].r_state.ToString();
                    room.Name = lists[i].r_id.ToString();
                    this.tabControl2.TabPages["tbSeaview"].Controls["flySeaview"].Controls.Add(room);

                }
            }
            else if (a == 6)//豪华单人
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("豪华单人", "1");
                List<RoomInfo> lists = new List<RoomInfo>();
                lists = bll.selectByStateAndRoomType("豪华单人", "4");
                this.tabControl2.TabPages["tbDeluxeSingle"].Controls["flyDexSingle"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbDeluxeSingle"].Controls["flyDexSingle"].Controls.Add(room);
                }
                for (int i = 0; i < lists.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = lists[i].r_id.ToString();
                    room.lbRoomType.Text = lists[i].r_type.ToString();
                    room.state = lists[i].r_state.ToString();
                    room.Name = lists[i].r_id.ToString();
                    this.tabControl2.TabPages["tbDeluxeSingle"].Controls["flyDexSingle"].Controls.Add(room);
                }
            }
            else if (a == 7)//豪华标准
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("豪华标准", "1");
                List<RoomInfo> lists = new List<RoomInfo>();
                lists = bll.selectByStateAndRoomType("豪华标准", "4");
                this.tabControl2.TabPages["tbDeluxeStandard"].Controls["flyDexStandard"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbDeluxeStandard"].Controls["flyDexStandard"].Controls.Add(room);
                }
                for (int i = 0; i < lists.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = lists[i].r_id.ToString();
                    room.lbRoomType.Text = lists[i].r_type.ToString();
                    room.state = lists[i].r_state.ToString();
                    room.Name = lists[i].r_id.ToString();
                    this.tabControl2.TabPages["tbDeluxeStandard"].Controls["flyDexStandard"].Controls.Add(room);
                }
            }
            else if (a == 8)//总统套房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("总统套房", "1");
                List<RoomInfo> lists = new List<RoomInfo>();
                lists = bll.selectByStateAndRoomType("总统套房", "4");
                this.tabControl2.TabPages["tbPresent"].Controls["flyPresent"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbPresent"].Controls["flyPresent"].Controls.Add(room);
                }
                for (int i = 0; i < lists.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = lists[i].r_id.ToString();
                    room.lbRoomType.Text = lists[i].r_type.ToString();
                    room.state = lists[i].r_state.ToString();
                    room.Name = lists[i].r_id.ToString();
                    this.tabControl2.TabPages["tbPresent"].Controls["flyPresent"].Controls.Add(room);
                }
            }
            else
            {
                new showMessagecs("系统提示", "请刷新房态！").ShowDialog();
            }


        }
        /// <summary>
        /// 预订按钮事件请勿更改,已优化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button16_Click(object sender, EventArgs e)
        {
            RoomId = null;
            int a = int.Parse(this.tabControl2.SelectedIndex.ToString());//获取当前选显卡的索引
            if (a == 0)//所有房间
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByState("3");
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                //所有房间加载
                this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Clear();
                for (int i = 0; i < list.Count; i++)
                {

                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Add(room);
                }
            }
            else if (a == 1)//标准房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("标准房", "3");
                this.tabControl2.TabPages["tbStandard"].Controls["flpStandard"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbStandard"].Controls["flpStandard"].Controls.Add(room);
                }
            }
            else if (a == 2)//单人房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("单人房", "3");
                this.tabControl2.TabPages["tbOne"].Controls["flyOne"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbOne"].Controls["flyOne"].Controls.Add(room);
                }

            }
            else if (a == 3)//商务房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("商务房", "3");
                this.tabControl2.TabPages["tbBusiness"].Controls["flyBusiness"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbBusiness"].Controls["flyBusiness"].Controls.Add(room);
                }
            }
            else if (a == 4)//商务单套
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("商务单套", "3");
                this.tabControl2.TabPages["tbLeveBus"].Controls["flyLeveBus"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbLeveBus"].Controls["flyLeveBus"].Controls.Add(room);
                }
            }
            else if (a == 5)//海景房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("海景房", "3");
                this.tabControl2.TabPages["tbSeaview"].Controls["flySeaview"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbSeaview"].Controls["flySeaview"].Controls.Add(room);

                }
            }
            else if (a == 6)//豪华单人
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("豪华单人", "3");
                this.tabControl2.TabPages["tbDeluxeSingle"].Controls["flyDexSingle"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbDeluxeSingle"].Controls["flyDexSingle"].Controls.Add(room);
                }
            }
            else if (a == 7)//豪华标准
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("豪华标准", "3");
                this.tabControl2.TabPages["tbDeluxeStandard"].Controls["flyDexStandard"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbDeluxeStandard"].Controls["flyDexStandard"].Controls.Add(room);
                }
            }
            else if (a == 8)//总统套房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("总统套房", "3");
                this.tabControl2.TabPages["tbPresent"].Controls["flyPresent"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbPresent"].Controls["flyPresent"].Controls.Add(room);
                }
            }
            else
            {
                new showMessagecs("系统提示", "请刷新房态！").ShowDialog();
            }


        }
        /// <summary>
        /// 空脏房按钮事件,已优化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_Click(object sender, EventArgs e)
        {
            RoomId = null;
            int a = int.Parse(this.tabControl2.SelectedIndex.ToString());//获取当前选显卡的索引
            if (a == 0)//所有房间
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByState("2");
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                //所有房间加载
                this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Clear();
                for (int i = 0; i < list.Count; i++)
                {

                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Add(room);
                }
            }
            else if (a == 1)//标准房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("标准房", "2");
                this.tabControl2.TabPages["tbStandard"].Controls["flpStandard"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbStandard"].Controls["flpStandard"].Controls.Add(room);
                }
            }
            else if (a == 2)//单人房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("单人房", "2");
                this.tabControl2.TabPages["tbOne"].Controls["flyOne"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbOne"].Controls["flyOne"].Controls.Add(room);
                }

            }
            else if (a == 3)//商务房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("商务房", "2");
                this.tabControl2.TabPages["tbBusiness"].Controls["flyBusiness"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbBusiness"].Controls["flyBusiness"].Controls.Add(room);
                }
            }
            else if (a == 4)//商务单套
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("商务单套", "2");
                this.tabControl2.TabPages["tbLeveBus"].Controls["flyLeveBus"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbLeveBus"].Controls["flyLeveBus"].Controls.Add(room);
                }
            }
            else if (a == 5)//海景房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("海景房", "2");
                this.tabControl2.TabPages["tbSeaview"].Controls["flySeaview"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbSeaview"].Controls["flySeaview"].Controls.Add(room);

                }
            }
            else if (a == 6)//豪华单人
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("豪华单人", "2");
                this.tabControl2.TabPages["tbDeluxeSingle"].Controls["flyDexSingle"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbDeluxeSingle"].Controls["flyDexSingle"].Controls.Add(room);
                }
            }
            else if (a == 7)//豪华标准
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("豪华标准", "2");
                this.tabControl2.TabPages["tbDeluxeStandard"].Controls["flyDexStandard"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbDeluxeStandard"].Controls["flyDexStandard"].Controls.Add(room);
                }
            }
            else if (a == 8)//总统套房
            {

                List<RoomInfo> list = new List<RoomInfo>();
                RoomInfoBLL bll = new RoomInfoBLL();
                list = bll.selectByStateAndRoomType("总统套房", "2");
                this.tabControl2.TabPages["tbPresent"].Controls["flyPresent"].Controls.Clear();
                if (list == null)
                {
                    new showMessagecs("系统提示", "无房间信息！").ShowDialog();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    UCRoom room = new UCRoom(this);
                    room.lbRoonId.Text = list[i].r_id.ToString();
                    room.lbRoomType.Text = list[i].r_type.ToString();
                    room.state = list[i].r_state.ToString();
                    room.Name = list[i].r_id.ToString();
                    this.tabControl2.TabPages["tbPresent"].Controls["flyPresent"].Controls.Add(room);
                }
            }
            else
            {
                new showMessagecs("系统提示", "请刷新房态！").ShowDialog();
            }


        }
        /// <summary>
        /// 查找按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox3.SelectedIndex >= 0)
                {
                    if (textBox1.Text == "")
                    {
                        new showMessagecs("系统提示", "查询信息不能为空").ShowDialog();
                    }
                    else 
                    {
                        selectBtnMes();
                    }
                    
                }
                else
                {
                    new showMessagecs("系统提示", "请选择查询方式").ShowDialog();
                }

            }
            catch (Exception ex) 
            {
                new showMessagecs("系统提示", "输入有误！").ShowDialog();
            }
           
        }

        private void selectBtnMes()
        {
            RoomId = null;
            int index = comboBox3.SelectedIndex;//索引，0为房号，一为姓名
            if (index == 0)
            {
                int i = int.Parse(this.textBox1.Text);
                RoomInfoBLL bll = new RoomInfoBLL();
                RoomInfo room = new RoomInfo();
                room = bll.selectByRoomId(i);
                if (room != null)
                {
                    this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Clear();//清空当前选项卡下的房间
                    UCRoom rooms = new UCRoom(this);
                    rooms.lbRoonId.Text = room.r_id.ToString();
                    rooms.lbRoomType.Text = room.r_type.ToString();
                    rooms.state = room.r_state.ToString();
                    rooms.Name = room.r_id.ToString();
                    this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Add(rooms);
                }
                else
                {
                    new showMessagecs("系统提示", "没有该房间！").ShowDialog();
                }
            }
            else
            {
                this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Clear();//清空当前选项卡下的房间
                RoomInfoBLL bll = new RoomInfoBLL();
                ArrayList list = new ArrayList();
                list = bll.selectByName(this.textBox1.Text.ToString());
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int id = int.Parse(list[i].ToString());
                        RoomInfo room = new RoomInfo();
                        room = bll.selectByRoomId(id);
                        if (room != null)
                        {

                            UCRoom rooms = new UCRoom(this);
                            rooms.lbRoonId.Text = room.r_id.ToString();
                            rooms.lbRoomType.Text = room.r_type.ToString();
                            rooms.state = room.r_state.ToString();
                            rooms.Name = room.r_id.ToString();
                            this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Add(rooms);
                        }
                        else
                        {
                            new showMessagecs("系统提示", "没有该房间！").ShowDialog();
                        }
                    }
                }
                else
                {
                    new showMessagecs("系统提示", "空！").ShowDialog();
                }

            }
        }
        /// <summary>
        /// 楼层选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = comboBox2.SelectedIndex;
            RoomInfoBLL bll = new RoomInfoBLL();
            List<RoomInfo> list = new List<RoomInfo>();
            list = bll.SelectByFloat(id + 1);//索引加1才是楼层号
            if (list == null)
            {
                new showMessagecs("系统提示", "无房间信息！").ShowDialog();
            }
            this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Clear();//清空当前选项卡下的房间
            for (int i = 0; i < list.Count; i++)
            {
                UCRoom room = new UCRoom(this);
                room.lbRoonId.Text = list[i].r_id.ToString();
                room.lbRoomType.Text = list[i].r_type.ToString();
                room.state = list[i].r_state.ToString();
                room.Name = list[i].r_id.ToString();
                this.tabControl2.TabPages["tbAll"].Controls["flyPanelAll"].Controls.Add(room);
            }
        }
        /// <summary>
        /// 刷新房态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            RoomLode();
        }
        /// <summary>
        /// 选项卡更改事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoomId = null;
            int index = this.tabControl2.SelectedIndex;
           // MessageBox.Show(index.ToString());
            RoomInfoBLL bll = new RoomInfoBLL();
            if (index == 0)
            {
                int free = (int)bll.SelectByState(0);//空房数
                int RuZhu = (int)bll.SelectByState(1)+(int)bll.SelectByState(4);//住房数
                int ZangFang = (int)bll.SelectByState(2);//脏房书
                int Yuding = (int)bll.SelectByState(3);//预订房
                this.label6.Text = free.ToString();//空房数
                this.label7.Text = RuZhu.ToString();//住房数
                this.label8.Text = ZangFang.ToString();//脏房书
                this.label10.Text =Yuding.ToString();//预订数
                this.label1.Text = (free + RuZhu + ZangFang + Yuding).ToString();
                xxkInder = 0;

            }
            else if (index == 1)
            {
                int free = (int)bll.StlectByStateAndTape(0, "标准房");
                int RuZhu = bll.StlectByStateAndTape(1, "标准房") + bll.StlectByStateAndTape(4, "标准房");
                int ZangFang = bll.StlectByStateAndTape(2, "标准房");
                int Yuding = (int)bll.StlectByStateAndTape(3, "标准房");//预订房
                this.label6.Text = free.ToString();//空房数
                this.label7.Text = RuZhu.ToString();//住房数
                this.label8.Text = ZangFang.ToString();//脏房书
                this.label10.Text = Yuding.ToString();//预订数
                this.label1.Text = (free + RuZhu + ZangFang + Yuding).ToString();
                xxkInder = 1;
            }
            else if (index == 2)
            {
                int free = (int)bll.StlectByStateAndTape(0, "单人房");
                int RuZhu = bll.StlectByStateAndTape(1, "单人房") + bll.StlectByStateAndTape(4, "单人房");
                int ZangFang = bll.StlectByStateAndTape(2, "单人房");
                int Yuding = (int)bll.StlectByStateAndTape(3, "单人房");//预订房
                this.label6.Text = free.ToString();//空房数
                this.label7.Text = RuZhu.ToString();//住房数
                this.label8.Text = ZangFang.ToString();//脏房书
                this.label10.Text = Yuding.ToString();//预订数
                this.label1.Text = (free + RuZhu + ZangFang + Yuding).ToString();
                xxkInder = 2;
            }
            else if (index == 3)
            {
                int free = (int)bll.StlectByStateAndTape(0, "商务房");
                int RuZhu = bll.StlectByStateAndTape(1, "商务房") + bll.StlectByStateAndTape(4, "商务房");
                int ZangFang = bll.StlectByStateAndTape(2, "商务房");
                int Yuding = (int)bll.StlectByStateAndTape(3, "商务房");//预订房
                this.label6.Text = free.ToString();//空房数
                this.label7.Text = RuZhu.ToString();//住房数
                this.label8.Text = ZangFang.ToString();//脏房书
                this.label10.Text = Yuding.ToString();//预订数
                this.label1.Text = (free + RuZhu + ZangFang + Yuding).ToString();
                xxkInder = 3;
            }
            else if (index == 4)
            {
                int free = (int)bll.StlectByStateAndTape(0, "商务单套");
                int RuZhu = bll.StlectByStateAndTape(1, "商务单套") + bll.StlectByStateAndTape(4, "商务单套");
                int ZangFang = bll.StlectByStateAndTape(2, "商务单套");
                int Yuding = (int)bll.StlectByStateAndTape(3, "商务单套");//预订房
                this.label6.Text = free.ToString();//空房数
                this.label7.Text = RuZhu.ToString();//住房数
                this.label8.Text = ZangFang.ToString();//脏房书
                this.label10.Text = Yuding.ToString();//预订数
                this.label1.Text = (free + RuZhu + ZangFang + Yuding).ToString();
                xxkInder = 4;
            }
            else if (index == 5)
            {
                int free = (int)bll.StlectByStateAndTape(0, "海景房");
                int RuZhu = bll.StlectByStateAndTape(1, "海景房") + bll.StlectByStateAndTape(4, "海景房");
                int ZangFang = bll.StlectByStateAndTape(2, "海景房");
                int Yuding = (int)bll.StlectByStateAndTape(3, "海景房");//预订房
                this.label6.Text = free.ToString();//空房数
                this.label7.Text = RuZhu.ToString();//住房数
                this.label8.Text = ZangFang.ToString();//脏房书
                this.label10.Text = Yuding.ToString();//预订数
                this.label1.Text = (free + RuZhu + ZangFang + Yuding).ToString();
                xxkInder = 5;
            }
            else if (index == 6)
            {
                int free = (int)bll.StlectByStateAndTape(0, "豪华单人");
                int RuZhu = bll.StlectByStateAndTape(1, "豪华单人") + bll.StlectByStateAndTape(4, "豪华单人"); 
                int ZangFang = bll.StlectByStateAndTape(2, "豪华单人");
                int Yuding = (int)bll.StlectByStateAndTape(3, "豪华单人");//预订房
                this.label6.Text = free.ToString();//空房数
                this.label7.Text = RuZhu.ToString();//住房数
                this.label8.Text = ZangFang.ToString();//脏房书
                this.label10.Text = Yuding.ToString();//预订数
                this.label1.Text = (free + RuZhu + ZangFang + Yuding).ToString();
                xxkInder = 6;
            }
            else if (index == 7)
            {
                int free = (int)bll.StlectByStateAndTape(0, "豪华标间");
                int RuZhu = bll.StlectByStateAndTape(1, "豪华标间") + bll.StlectByStateAndTape(4, "豪华标间");
                int ZangFang = bll.StlectByStateAndTape(2, "豪华标间");
                int Yuding = (int)bll.StlectByStateAndTape(3, "豪华标间");//预订房
                this.label6.Text = free.ToString();//空房数
                this.label7.Text = RuZhu.ToString();//住房数
                this.label8.Text = ZangFang.ToString();//脏房书
                this.label10.Text = Yuding.ToString();//预订数
                this.label1.Text = (free + RuZhu + ZangFang + Yuding).ToString();
                xxkInder = 7;
            }
            else if (index == 8)
            {
                int free = (int)bll.StlectByStateAndTape(0, "总统套房");
                int RuZhu = bll.StlectByStateAndTape(1, "总统套房") + bll.StlectByStateAndTape(4, "总统套房");
                int ZangFang = bll.StlectByStateAndTape(2, "总统套房");
                int Yuding = (int)bll.StlectByStateAndTape(3, "总统套房");//预订房
                this.label6.Text = free.ToString();//空房数
                this.label7.Text = RuZhu.ToString();//住房数
                this.label8.Text = ZangFang.ToString();//脏房书
                this.label10.Text = Yuding.ToString();//预订数
                this.label1.Text = (free + RuZhu + ZangFang + Yuding).ToString();
                xxkInder = 8;
            }
            else
            {
                new showMessagecs("系统提示", "有问题！").ShowDialog();
            }
        }
       
        /// <summary>
        /// 图片点击弹窗事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic1_Click(object sender, EventArgs e)
        {
            this.tabPage7.Parent = null;
            fmLogin login = new fmLogin(this);
           // this.Hide();
            login.ShowDialog(); 
        }
        /// <summary>
        /// 客户预定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic2_Click(object sender, EventArgs e)
        {
            if (RoomId != null)
            {
                RoomInfoBLL bll = new RoomInfoBLL();
                RoomInfo info = new RoomInfo();
                info=bll.selectByRoomId(int.Parse(RoomId));
                if (!info.r_state.Equals("0"))
                {
                    new showMessagecs("系统提示","该房不是空房，不能入住").ShowDialog();
                }
                else 
                {
                    Foregift hotel = new Foregift(RoomId, user, this);
                    hotel.ShowDialog();
                }
                
            }
            else 
            {
                new showMessagecs("系统提示","请选择房间").ShowDialog();
            }
           
            
        }
        /// <summary>
        /// 客户登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic3_Click(object sender, EventArgs e)
        {
            
                if (RoomId != null)
                {
                    RoomInfoBLL bll = new RoomInfoBLL();
                    RoomInfo room = new RoomInfo();
                    room = bll.selectByRoomId(int.Parse(RoomId));
                    if (room.r_state.Equals("0"))
                    {
                        fmUser users = new fmUser(RoomId, user,this);
                        users.ShowDialog();
                    }
                    else if (room.r_state.Equals("1"))
                    {
                        new showMessagecs("系统提示", "该房已有客人入住").ShowDialog();
                    }
                    else if (room.r_state.Equals("2"))
                    {
                        new showMessagecs("系统提示", "请将脏房置净").ShowDialog();
                    }
                    else if (room.r_state.Equals("3"))
                    {
                        new showMessagecs("系统提示", "该房已被预订，确定入住吗？").ShowDialog();
                        if (showMessagecs.result.Equals(true))
                        {
                            BLLcustomer cus = new BLLcustomer();
                            InInfo roommes = new InInfo();
                            roommes = cus.selectByRooid(RoomId);
                            fmUser users = new fmUser(RoomId, fmMain.userOper, this,roommes);
                            users.ShowDialog();
                        }
                        else
                        {
                            // MessageBox.Show("有");
                        }
                    }
                    else 
                    {
                        new showMessagecs("系统提示", "该房已有客人预订").ShowDialog();
                    }                    
            }
            else 
            {
                new showMessagecs("系统提示", "请选择房间").ShowDialog();
            }
           
        }

        private void pic4_Click(object sender, EventArgs e)
        {
            fmRoomManager roomm = new fmRoomManager();
            roomm.ShowDialog();
        }

        private void pic5_Click(object sender, EventArgs e)
        {
            fmWorkChange workC = new fmWorkChange();
            workC.ShowDialog();
        }
 
        private void picvip_Click(object sender, EventArgs e)
        {
            this.tabPage6.Parent = this.tabControl1;
            this.tabControl1.SelectedTab = tabPage6;
        }
        //private void pictureBox9_Click(object sender, EventArgs e)
        //{
        //    this.tabPage7.Parent = this.tabControl1;
        //    this.tabControl1.SelectedTab = tabPage7;
        //}
        
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            userOper = Global.user;
            if (userOper.UserType.Equals("主管"))
            {
                fmAcgtcs acgt = new fmAcgtcs();
                acgt.ShowDialog();
            }
            else 
            {
                new showMessagecs("提示","你没有权限执行该操作！").ShowDialog();
            }
            
        }

       
        /// <summary>
        /// 窗体最小化最大化关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                this.Refresh();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            new showMessage("系统提示", "你确定要退出当前系统吗？").ShowDialog();
            if (showMessage.result.Equals(true))
            {
                Application.Exit();
            }
            else { }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\back.jpg");
        }
        /// <summary>
        /// 鼠标移过picturebox出现白色边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic1_MouseEnter(object sender, EventArgs e)
        {
            this.pic1.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\ZHB.jpg");
        }

        private void pic1_MouseLeave(object sender, EventArgs e)
        {
            this.pic1.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\z.jpg");
        }

        private void pic2_MouseEnter(object sender, EventArgs e)
        {
            this.pic2.BackgroundImage =  Image.FromFile(Application.StartupPath + @"\image\yudingmb.jpg");
        }

        private void pic2_MouseLeave(object sender, EventArgs e)
        {
            this.pic2.BackgroundImage =  Image.FromFile(Application.StartupPath + @"\image\yuding.jpg");
        }

        private void pic3_MouseEnter(object sender, EventArgs e)
        {
            this.pic3.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\KHB.jpg");
        }

        private void pic3_MouseLeave(object sender, EventArgs e)
        {
            this.pic3.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\KH.jpg");
        }

        private void pic4_MouseEnter(object sender, EventArgs e)
        {
            this.pic4.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\FGB.jpg");
        }

        private void pic4_MouseLeave(object sender, EventArgs e)
        {
            this.pic4.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\home.jpg");
        }

        private void pic5_MouseEnter(object sender, EventArgs e)
        {
            this.pic5.BackgroundImage =Image.FromFile(Application.StartupPath + @"\image\JJB.jpg");
        }

        private void pic5_MouseLeave(object sender, EventArgs e)
        {
            this.pic5.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\jb.jpg");
        }

        private void pic6_MouseEnter(object sender, EventArgs e)
        {
            this.pic6.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\CHB.jpg");
        }

        private void pic6_MouseLeave(object sender, EventArgs e)
        {
            this.pic6.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\CG.jpg");
        }
        private void picvip_MouseEnter(object sender, EventArgs e)
        {
            this.picvip.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\huiyuanmb.jpg");
        }

        private void picvip_MouseLeave(object sender, EventArgs e)
        {
            this.picvip.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\huiyuan.jpg");
        }
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox3.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\ZSB.jpg");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\ZS1.jpg");
        }
        /// <summary>
        /// 会员管理右键关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关闭ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tabPage6.Parent = null;
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            VipAdd add = new VipAdd();
            add.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            fmVipUpdate update = new fmVipUpdate();
            update.ShowDialog();
        }

        /// <summary>
        /// 仓库管理增加按钮，
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            fmThingAdd add = new fmThingAdd(this);
            add.ShowDialog();
        }
        /// <summary>
        /// 仓库管理修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                new showMessagecs("系统设置", "请选择房间").ShowDialog();
            }
            else
            {
                string BM = this.listView1.SelectedItems[0].SubItems[0].Text;//获取选中编码
                fmThingDe alter = new fmThingDe(BM, this);
                alter.ShowDialog();
            }
        }
        /// <summary>
        /// 仓库管理删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                new showMessagecs("系统提示", "请选择！").ShowDialog();
            }
            else
            {
                string BM = this.listView1.SelectedItems[0].SubItems[0].Text;//获取选中编码
                new showMessage("慎重操作", "确认要删除吗?").ShowDialog();
                if (showMessage.result.Equals(true))
                {
                    GoodsBLL bll = new GoodsBLL();
                    int count = bll.GoodsDelete(BM);
                    if (count >= 1)
                    {
                        new showMessageok("系统提示", "删除成功").ShowDialog();
                        GoodsListLode();
                    }
                    else
                    {
                        new showMessagecs("系统提示", "删除失败").ShowDialog();
                    }
                }
                else
                {
                    BM = null;
                }
            }
        }
        /// <summary>
        /// 仓库刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            GoodsListLode();
        }
        /// <summary>
        /// 点击仓库管理图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic6_Click(object sender, EventArgs e)
        {
            this.tabPage2.Parent = this.tabControl1;
            this.tabControl1.SelectedTab = tabPage2;
            GoodsListLode();
        }
        /// <summary>
        /// 仓库列表
        /// </summary>
        public void GoodsListLode()
        {
            GoodsBLL bll = new GoodsBLL();
            listView1.Items.Clear();
            List<GoodsListInfo> Goodslist = new List<GoodsListInfo>();
            Goodslist = bll.SelectGoods();
            for (int i = 0; i < Goodslist.Count; i++)
            {
                ListViewItem li = new ListViewItem(Goodslist[i].Goods_BM.ToString());
                li.SubItems.Add(Goodslist[i].Goods_Name.ToString());//姓名
                li.SubItems.Add(Goodslist[i].Goods_JP.ToString());//简拼
                li.SubItems.Add(Goodslist[i].Goods_price.ToString());//价格
                li.SubItems.Add(Goodslist[i].Goods_Unit.ToString());//单位
                li.SubItems.Add(Goodslist[i].Goods_count.ToString());//数量库存
                this.listView1.Items.Add(li);
            }
        }       

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            fmThingAdd thingadd = new fmThingAdd(this);
            thingadd.ShowDialog();
        }


        private void button3_Click_3(object sender, EventArgs e)
        {
            VipAdd add = new VipAdd();
            add.ShowDialog();
        }

        private void button15_Click_2(object sender, EventArgs e)
        {
            fmVipUpdate vipupdate = new fmVipUpdate();
            vipupdate.ShowDialog();
        }
        /// <summary>
        /// 选项卡更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)//报表
        {
            int count = dataGridView1.RowCount;
         //  statusStrip1.Text = "总共" + count + "条记录";
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            StartHour.Enabled = false;
            endHour.Enabled = false;

            dateTimePicker10.Enabled = false;
            dateTimePicker9.Enabled = false;
            CstartHour.Enabled = false;
            CendHour.Enabled = false;
 
        }
        /// <summary>
        /// 仓库管理查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                new showMessagecs("系统提示", "请选择查询方式").ShowDialog();
            }
            else
            {
                if (comboBox1.SelectedItem.Equals("编码查询"))
                {
                    // MessageBox.Show("编码查询");
                    if (tbSelect.Text != "")
                    {
                        GoodsBLL bll = new GoodsBLL();
                        GoodsListInfo Goodslist = new GoodsListInfo();
                        Goodslist = bll.SelectByBmoNE(tbSelect.Text.Trim());
                        if (Goodslist == null)
                        {
                            new showMessagecs("系统提示", "该商品不存在").ShowDialog();
                        }
                        else
                        {
                            listView1.Items.Clear();
                            ListViewItem li = new ListViewItem(Goodslist.Goods_BM.ToString());
                            li.SubItems.Add(Goodslist.Goods_Name.ToString());//姓名
                            li.SubItems.Add(Goodslist.Goods_JP.ToString());//简拼
                            li.SubItems.Add(Goodslist.Goods_price.ToString());//价格
                            li.SubItems.Add(Goodslist.Goods_Unit.ToString());//单位
                            li.SubItems.Add(Goodslist.Goods_count.ToString());//数量库存
                            this.listView1.Items.Add(li);

                        }
                    }
                    else
                    {
                        new showMessagecs("系统提示", "请输入商品编码").ShowDialog();
                    }
                }
                else
                {//MessageBox.Show("商品名查询");
                    if (tbSelect.Text != "")
                    {
                        GoodsBLL bll = new GoodsBLL();
                        GoodsListInfo Goodslist = new GoodsListInfo();
                        Goodslist = bll.SelectByBmoName(tbSelect.Text.Trim());
                        if (Goodslist == null)
                        {
                            new showMessagecs("系统提示", "该商品不存在").ShowDialog();
                        }
                        else
                        {
                            listView1.Items.Clear();
                            ListViewItem li = new ListViewItem(Goodslist.Goods_BM.ToString());
                            li.SubItems.Add(Goodslist.Goods_Name.ToString());//姓名
                            li.SubItems.Add(Goodslist.Goods_JP.ToString());//简拼
                            li.SubItems.Add(Goodslist.Goods_price.ToString());//价格
                            li.SubItems.Add(Goodslist.Goods_Unit.ToString());//单位
                            li.SubItems.Add(Goodslist.Goods_count.ToString());//数量库存
                            this.listView1.Items.Add(li);

                        }
                    }
                    else
                    {
                        new showMessagecs("系统提示", "请输入商品名").ShowDialog();
                    }

                }
            }
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox9.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\mb.jpg");
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
           this.pictureBox9.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\bb.jpg");
        }

 /// <summary>
 /// 会员管理
 /// </summary>
 /// <param name="sender"></param>
 /// <param name="e"></param>
        private void comselect_SelectionChangeCommitted(object sender, EventArgs e)//选不同方式查询
        {
            if (comselect.SelectedIndex == 0)
            {
                txtSelect.AutoCompleteCustomSource.Clear();
                txtSelect.Clear();
                try
                {
                    string conn = "Data Source=.;Initial Catalog=hotels;User ID=sa;Password=123456";
                    SqlConnection connection = new SqlConnection(conn);
                    string comText = "select VipName from VipRoomInfo";
                    //SqlCommand comm = new SqlCommand(comText, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(comText, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        txtSelect.AutoCompleteCustomSource.Add(dr["VipName"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            if (comselect.SelectedIndex == 1)
            {
                txtSelect.AutoCompleteCustomSource.Clear();
                txtSelect.Clear();
                try
                {
                    string conn = "Data Source=.;Initial Catalog=hotels;User ID=sa;Password=123456";
                    SqlConnection connection = new SqlConnection(conn);
                    string comText = "select VipPhone from VipRoomInfo";
                    //SqlCommand comm = new SqlCommand(comText, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(comText, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        txtSelect.AutoCompleteCustomSource.Add(dr["VipPhone"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            if (comselect.SelectedIndex == 2)
            {
                txtSelect.AutoCompleteCustomSource.Clear();
                txtSelect.Clear();
                try
                {
                    string conn = "Data Source=.;Initial Catalog=hotels;User ID=sa;Password=123456";
                    SqlConnection connection = new SqlConnection(conn);
                    string comText = "select VipId from VipRoomInfo";
                    //SqlCommand comm = new SqlCommand(comText, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(comText, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        txtSelect.AutoCompleteCustomSource.Add(dr["VipId"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comselect.SelectedIndex == 3)
            {
                txtSelect.AutoCompleteCustomSource.Clear();
                txtSelect.Clear();
                try
                {
                    string conn = "Data Source=.;Initial Catalog=hotels;User ID=sa;Password=123456";
                    SqlConnection connection = new SqlConnection(conn);
                    string comText = "select VipZJNumber from VipRoomInfo";
                    //SqlCommand comm = new SqlCommand(comText, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(comText, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        txtSelect.AutoCompleteCustomSource.Add(dr["VipZJNumber"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comselect.SelectedIndex == 4)
            {
                string conn = "Data Source=.;Initial Catalog=hotels;User ID=sa;Password=123456";
                SqlConnection connection = new SqlConnection(conn);
                string comText = "select * from VipRoomInfo ";
                SqlDataAdapter adapter = new SqlDataAdapter(comText, connection);
                connection.Open();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
        }

        private void button22_Click(object sender, EventArgs e)//查找
        {
            if (txtSelect.Text =="")
            {
                new showMessagecs("系统提示", "请输入要查询的内容！").ShowDialog();
            }
            if (comselect.SelectedIndex == 0)
            {
                string conn = "Data Source=.;Initial Catalog=hotels;User ID=sa;Password=123456";
                SqlConnection connection = new SqlConnection(conn);
                string comText = "select * from VipRoomInfo where VipName=@vipname";
                SqlDataAdapter adapter = new SqlDataAdapter(comText, connection);
                DataTable dt = new DataTable();
                adapter.SelectCommand.Parameters.AddWithValue("@vipname", txtSelect.Text);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;

                    //自动选择行选择

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.Rows[0].Selected = true;   //默认选择第一行，光标定位
                }
                comselect.Text = "";
                txtSelect.Text = "";
            }

            if (comselect.SelectedIndex == 1)
            {

                string conn = "Data Source=.;Initial Catalog=hotels;User ID=sa;Password=123456";
                SqlConnection connection = new SqlConnection(conn);
                string comText = "select * from VipRoomInfo where VipPhone=@VipPhone";
                SqlDataAdapter adapter = new SqlDataAdapter(comText, connection);
                DataTable dt = new DataTable();
                adapter.SelectCommand.Parameters.AddWithValue("@VipPhone", txtSelect.Text);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;

                    //自动选择行选择

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.Rows[0].Selected = true;   //默认选择第一行，光标定位
                }
                comselect.Text = "";
                txtSelect.Text = "";

            }

            if (comselect.SelectedIndex == 2)
            {

                string conn = "Data Source=.;Initial Catalog=hotels;User ID=sa;Password=123456";
                SqlConnection connection = new SqlConnection(conn);
                string comText = "select * from VipRoomInfo where VipId=@VipId";
                SqlDataAdapter adapter = new SqlDataAdapter(comText, connection);
                DataTable dt = new DataTable();
                adapter.SelectCommand.Parameters.AddWithValue("@VipId", txtSelect.Text);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;

                    //自动选择行选择

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.Rows[0].Selected = true;   //默认选择第一行，光标定位
                }
                comselect.Text = "";
                txtSelect.Text = "";
            }

            if (comselect.SelectedIndex == 3)
            {

                string conn = "Data Source=.;Initial Catalog=hotels;User ID=sa;Password=123456";
                SqlConnection connection = new SqlConnection(conn);
                string comText = "select * from VipRoomInfo where VipZJNumber=@VipZJNumber";
                SqlDataAdapter adapter = new SqlDataAdapter(comText, connection);
                DataTable dt = new DataTable();
                adapter.SelectCommand.Parameters.AddWithValue("@VipZJNumber", txtSelect.Text);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;

                    //自动选择行选择

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.Rows[0].Selected = true;   //默认选择第一行，光标定位
                }
                comselect.Text = "";
                txtSelect.Text = "";
            }
        }

        private void 删除_Click(object sender, EventArgs e)//删除
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                new showMessage("系统提示", "确定要删除选中内容吗？").ShowDialog();
                if (showMessage.result.Equals(true))
                {
                    DataRowView drv = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
                    drv.Row.Delete(); // 对绑定的DataTable的选中行做删除标记，向DB更新时，DB的对应行也被删除。或者drv.Row.Table.Rows.Remove(drv.Row); // 将要删除的行移除，更新时不影响数据库。  
                    new showMessageok("系统提示", "删除成功！").ShowDialog();
                }
            }
            else
            {
                new showMessagecs("系统提示", "您没有选中任何行！").ShowDialog();
            }
        }

        private void 修改_Click(object sender, EventArgs e)//修改
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                this.dataGridView1.CurrentCell = this.dataGridView1.SelectedRows[0].Cells[0];
                this.dataGridView1.BeginEdit(true);
            }
            else
            {
                new showMessagecs("系统提示", "您没有选中任何行！").ShowDialog();
            }
        }

        private void 添加_Click(object sender, EventArgs e)//添加
        {
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0];
            string time = DateTime.Now.ToShortDateString();
            this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[10].Value = time;
        }

        private void 刷新_Click(object sender, EventArgs e)//刷新
        {
            try
            {
                refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void refresh()
        {
            try
            {
                string conn = "Data Source=.;Initial Catalog=hotels;User ID=sa;Password=123456";
                SqlConnection connection = new SqlConnection(conn);
                string comText = "select * from VipRoomInfo ";
                SqlDataAdapter adapter = new SqlDataAdapter(comText, connection);
                SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(adapter);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt = (DataTable)this.dataGridView1.DataSource;
                connection.Open();
                adapter.Update(dt);
                connection.Close();
                dataGridView1.Refresh();
                new showMessageok("系统提示", "刷新成功！").ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click_2(object sender, EventArgs e)
        {
            userOper = Global.user;
            if (userOper.UserType.Equals("主管"))
            {
                this.tabPage7.Parent = this.tabControl1;
                this.tabControl1.SelectedTab = tabPage7;
            }
            else
            {
                new showMessagecs("提示", "你没有权限执行该操作！").ShowDialog();
            }
           
        }

        
       
        /// <summary>
        /// 住客清单表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comTime_SelectionChangeCommitted(object sender, EventArgs e)//根据不同类型查询
        {
            if (comTime.SelectedIndex == 0)//自选
            {

                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                StartHour.Enabled = true;
                endHour.Enabled = true;
            }
            if (comTime.SelectedIndex == 1)//今天
            {
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
                dateTimePicker2.Text = DateTime.Now.ToShortDateString();
                StartHour.Text = "0:0:0";
                endHour.Text = "23:59:59";
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                StartHour.Enabled = false;
                endHour.Enabled = false;

            }
            if (comTime.SelectedIndex == 2)//昨天
            {

                dateTimePicker1.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                dateTimePicker2.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                StartHour.Text = "0:0:0";
                endHour.Text = "23:59:59";
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                StartHour.Enabled = false;
                endHour.Enabled = false;
            }

            if (comTime.SelectedIndex == 3)//本周
            {
                dateTimePicker1.Text = DateTime.Now.AddDays(Convert.ToDouble((0 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString();
                dateTimePicker2.Text = DateTime.Now.AddDays(Convert.ToDouble((6 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString();
                StartHour.Text = "0:0:0";
                endHour.Text = "23:59:59";
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                StartHour.Enabled = false;
                endHour.Enabled = false;
            }
            if (comTime.SelectedIndex == 4)//上周
            {
                dateTimePicker1.Text = DateTime.Now.AddDays(Convert.ToDouble((0 - Convert.ToInt16(DateTime.Now.DayOfWeek) - 7))).ToShortDateString();
                dateTimePicker2.Text = DateTime.Now.AddDays(Convert.ToDouble((6 - Convert.ToInt16(DateTime.Now.DayOfWeek) - 7))).ToShortDateString();
                StartHour.Text = "0:0:0";
                endHour.Text = "23:59:59";
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                StartHour.Enabled = false;
                endHour.Enabled = false;
            }
            if (comTime.SelectedIndex == 5)//本月
            {
                dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-01");
                dateTimePicker2.Text = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToShortDateString();
                StartHour.Text = "0:0:0";
                endHour.Text = "23:59:59";
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                StartHour.Enabled = false;
                endHour.Enabled = false;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)//查询
        {
            if (DateTime.Parse(dateTimePicker2.Text) < DateTime.Parse(dateTimePicker1.Text))
            {
               
                new showMessagecs("系统提示", "截止日期不能小于起始日期！").ShowDialog();
            }
            if (DateTime.Parse(dateTimePicker2.Text) == DateTime.Parse(dateTimePicker1.Text))
            {
                if (DateTime.Parse(endHour.Text) <= DateTime.Parse(StartHour.Text))
                {
                    new showMessagecs("系统提示", "截止日期不能小于起始日期！").ShowDialog();
                }
            }
            SqlConnection connection = Gloable.conn;
            connection.Open();
            string comText = "select * from V_cutomerInfo where CInTime>=@startdate and  CInTime<=@enddate";
            SqlDataAdapter adapter = new SqlDataAdapter(comText, connection);
            adapter.SelectCommand.Parameters.Add("@startdate", SqlDbType.DateTime);
            adapter.SelectCommand.Parameters.Add("@enddate", SqlDbType.DateTime);
            adapter.SelectCommand.Parameters[0].Value = DateTime.Parse(dateTimePicker1.Text).ToShortDateString();
            adapter.SelectCommand.Parameters[1].Value = DateTime.Parse(dateTimePicker2.Text).ToShortDateString();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            int count = dataGridView2.RowCount;
            tool1.Text = "总共" + count + "条记录";
            connection.Close();
            
        }
        /// <summary>
        /// 消费明细表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void comselect2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comselect2.SelectedIndex == 0)//自选
            {

                dateTimePicker10.Enabled = true;
                dateTimePicker9.Enabled = true;
                CstartHour.Enabled = true;
                CendHour.Enabled = true;
            }
            if (comselect2.SelectedIndex == 1)//今天
            {
                dateTimePicker9.Text = DateTime.Now.ToShortDateString();
                dateTimePicker10.Text = DateTime.Now.ToShortDateString();
                CstartHour.Text = "0:0:0";
                CendHour.Text = "23:59:59";
                dateTimePicker10.Enabled = false;
                dateTimePicker9.Enabled = false;
                CstartHour.Enabled = false;
                CendHour.Enabled = false;

            }
            if (comselect2.SelectedIndex == 2)//昨天
            {

                dateTimePicker10.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                dateTimePicker9.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                CstartHour.Text = "0:0:0";
                CendHour.Text = "23:59:59";
                dateTimePicker10.Enabled = false;
                dateTimePicker9.Enabled = false;
                CstartHour.Enabled = false;
                CendHour.Enabled = false;
            }

            if (comselect2.SelectedIndex == 3)//本周
            {
                dateTimePicker10.Text = DateTime.Now.AddDays(Convert.ToDouble((0 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString();
                dateTimePicker9.Text = DateTime.Now.AddDays(Convert.ToDouble((6 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString();
                CstartHour.Text = "0:0:0";
                CendHour.Text = "23:59:59";
                dateTimePicker10.Enabled = false;
                dateTimePicker9.Enabled = false;
                CstartHour.Enabled = false;
                CendHour.Enabled = false;
            }
            if (comselect2.SelectedIndex == 4)//上周
            {
                dateTimePicker10.Text = DateTime.Now.AddDays(Convert.ToDouble((0 - Convert.ToInt16(DateTime.Now.DayOfWeek) - 7))).ToShortDateString();
                dateTimePicker9.Text = DateTime.Now.AddDays(Convert.ToDouble((6 - Convert.ToInt16(DateTime.Now.DayOfWeek) - 7))).ToShortDateString();
                CstartHour.Text = "0:0:0";
                CendHour.Text = "23:59:59";
                dateTimePicker10.Enabled = false;
                dateTimePicker9.Enabled = false;
                CstartHour.Enabled = false;
                CendHour.Enabled = false;
            }
            if (comselect2.SelectedIndex == 5)//本月
            {
                dateTimePicker10.Text = DateTime.Now.ToString("yyyy-MM-01");
                dateTimePicker9.Text = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToShortDateString();
                CstartHour.Text = "0:0:0";
                CendHour.Text = "23:59:59";
                dateTimePicker10.Enabled = false;
                dateTimePicker9.Enabled = false;
                CstartHour.Enabled = false;
                CendHour.Enabled = false;
            }
        }

        private void button15_Click_3(object sender, EventArgs e)//查询
        {
             if (DateTime.Parse(dateTimePicker9.Text) < DateTime.Parse(dateTimePicker10.Text))
            {
                new showMessagecs("系统提示", "截止日期不能小于起始日期！").ShowDialog();
            }
            if (DateTime.Parse(dateTimePicker9.Text) == DateTime.Parse(dateTimePicker10.Text))
            {
                if (DateTime.Parse(CendHour.Text) <= DateTime.Parse(CstartHour.Text))
                {
                    new showMessagecs("系统提示", "截止日期不能小于起始日期！").ShowDialog();
                }
            }
            string conn = "Data Source=.;Initial Catalog=hotels;User ID=sa;Password=123456";
            SqlConnection connection = new SqlConnection(conn);
            //SqlConnection connection = Global.conn;
            //connection.Open();
            string comText = "select * from V_consume where CostTime>=@startdate and CostTime<=@enddate";
            SqlDataAdapter adapter = new SqlDataAdapter(comText, connection);
            adapter.SelectCommand.Parameters.Add("@startdate", SqlDbType.DateTime);
            adapter.SelectCommand.Parameters.Add("@enddate", SqlDbType.DateTime);
            adapter.SelectCommand.Parameters[0].Value = DateTime.Parse(dateTimePicker10.Text).ToShortDateString();
            adapter.SelectCommand.Parameters[1].Value = DateTime.Parse(dateTimePicker9.Text).ToShortDateString();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;
            int count = dataGridView3.RowCount;
             tool2.Text = "总共" + count + "条记录";
            foreach(DataGridViewRow row in dataGridView3.Rows)
            {
                row.Cells["总价"].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells["数量"].Value);
            }
            connection.Close();
        }

        private void tabControl6_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = ((TabControl)sender).TabPages[e.Index].Text;
            SolidBrush brush = new SolidBrush(Color.Black);
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(text, SystemInformation.MenuFont, brush, e.Bounds, sf);
        }
        bool flag = true;
        private void label18_Click(object sender, EventArgs e)
        {           
            if (flag == true)
            {
                this.label18.Text = "<<";
                //if (this.WindowState == FormWindowState.Maximized)
                //{
                //    this.label18.Location = new Point(1100, 4);
                //}
                //else
                //{
                //    this.label18.Location = new Point(1075, 4);
                //}
                this.label18.Location = new Point(1075, 4);
                this.tabControl3.Hide();
                this.panel4.Width = this.tabControl1.Width;
                this.splitContainer1.Width = this.tabControl1.Width;
                this.tabControl2.Width = this.tabControl1.Width;
                this.tabControl4.Width = this.tabControl1.Width;
                this.flyPanelAll.Width = this.tabControl1.Width;
                this.panel3.Width = this.tabControl1.Width;

                flag = false;
            }
            else
            {
                this.label18.Text = ">>";
                //if (this.WindowState == FormWindowState.Maximized)
                //{
                //    this.label18.Location = new Point(1100, 4);
                //}
                //else
                //{
                //    this.label18.Location = new Point(891, 4);
                //}
                this.label18.Location = new Point(891, 4);
                this.tabControl3.Show();
                if (this.WindowState != FormWindowState.Maximized)
                {
                    this.splitContainer1.Width = 928;
                }
                else
                {
                    this.splitContainer1.Width = 1000;
                }
                //this.splitContainer1.Width = 928;
                flag = true;
            }
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }
    }
}
