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
    public partial class fmAccount : Form
    {
        private int roomid;
        private fmMain fm;
        private fmInAlter fmalter;
        public fmAccount(int id)
        {
            InitializeComponent();
            this.roomid = id;
        }
        public fmAccount(int id, fmMain fms)
        {
            fm = fms;
            this.roomid = id;
            InitializeComponent();

        }
        public fmAccount(int id, fmMain fms,fmInAlter fmlter)
        {
            fm = fms;
            this.fmalter = fmlter;
            this.roomid = id;
            InitializeComponent();

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        int alltotal = 0;
        private void fmAccount_Load(object sender, EventArgs e)
        {
            this.label15.Hide();
            //this.label7.Hide();
            //消费单号查询
            //string spenno = DateTime.Now.ToString();            
            //string str2 = spenno.Replace(":", "").Replace("-", "").Replace(" ","") ;


            try
            {
                BLLcustomer bll = new BLLcustomer();
                CheckInfo In = new CheckInfo();
                BLLcustomer blls = new BLLcustomer();
                InInfo select = blls.selectByRooid(this.roomid.ToString());
                In.c_name = select.c_name;
                this.label2.Text = select.in_number;
                string ID = select.zj_number;
                int count = bll.count(In.c_name, select.in_number);
                if (count != 0)
                {
                    List<InInfo> Inlists = new List<InInfo>();
                    listView1.LabelEdit = true;
                    int days = 0;//天数

                    Inlists = bll.SelectCheck(In.c_name, this.label2.Text);
                    double sumforegift = 0;
                    for (int i = 0; i < Inlists.Count; i++)
                    {
                        if (Inlists[i].roomState.Equals("2"))
                        {
                            ListViewItem li = new ListViewItem(Inlists[i].r_id.ToString() + "[已退]");
                            li.SubItems.Add(Inlists[i].c_name.ToString());
                            li.SubItems.Add(Inlists[i].InType.ToString());
                            li.SubItems.Add(Inlists[i].r_RelPrice.ToString());
                            li.SubItems.Add(Inlists[i].c_intoday.ToString());
                            li.SubItems.Add(((DateTime.Now.Subtract(Inlists[i].c_intoday)).Days).ToString());
                            li.SubItems.Add(Inlists[i].foregift.ToString());
                            CuspenBLL childblls = new CuspenBLL();
                            List<CusSpenInfo> childlist = new List<CusSpenInfo>();
                            childlist = childblls.SelectSpend(Inlists[i].r_id);
                            int othertotal = 0;
                            if (childlist != null)
                            {

                                for (int k = 0; k < childlist.Count; k++)
                                {
                                    othertotal = othertotal + Convert.ToInt32(childlist[k].totolAmount);
                                }
                            }
                            days = Convert.ToInt32((DateTime.Now.Subtract(Inlists[i].c_intoday)).Days);
                            li.SubItems.Add((days * Convert.ToInt32(Inlists[i].r_RelPrice.ToString())).ToString());
                            li.SubItems.Add(othertotal.ToString());

                            this.listView1.Items.Add(li);
                            alltotal = alltotal + Convert.ToInt32(days * Convert.ToInt32(Inlists[i].r_RelPrice.ToString())) + othertotal;
                        }
                        else
                        {
                            ListViewItem li = new ListViewItem(Inlists[i].r_id.ToString());
                            li.SubItems.Add(Inlists[i].c_name.ToString());
                            li.SubItems.Add(Inlists[i].InType.ToString());
                            li.SubItems.Add(Inlists[i].r_RelPrice.ToString());
                            li.SubItems.Add(Inlists[i].c_intoday.ToString());
                            li.SubItems.Add(((DateTime.Now.Subtract(Inlists[i].c_intoday)).Days).ToString());
                            li.SubItems.Add(Inlists[i].foregift.ToString());
                            CuspenBLL childblls = new CuspenBLL();
                            List<CusSpenInfo> childlist = new List<CusSpenInfo>();
                            childlist = childblls.SelectSpend(Inlists[i].r_id, this.label2.Text);
                            int othertotal = 0;
                            if (childlist != null)
                            {
                                for (int k = 0; k < childlist.Count; k++)
                                {
                                    othertotal = othertotal + Convert.ToInt32(childlist[k].totolAmount);
                                }
                            }
                            days = Convert.ToInt32((DateTime.Now.Subtract(Inlists[i].c_intoday)).Days);
                            li.SubItems.Add((days * Convert.ToInt32(Inlists[i].r_RelPrice.ToString())).ToString());
                            li.SubItems.Add(othertotal.ToString());
                            li.SubItems.Add(Inlists[i].roomState.ToString());
                            this.listView1.Items.Add(li);
                            alltotal = alltotal + Convert.ToInt32(days * Convert.ToInt32(Inlists[i].r_RelPrice.ToString())) + othertotal;
                        }
                        sumforegift = sumforegift + Inlists[i].foregift;
                    }

                    this.textBox3.Text = alltotal.ToString();
                    this.label3.Text = Inlists[0].r_id.ToString();
                    this.label5.Text = "," + Inlists[0].c_name.ToString() + "的消费账单";
                    this.textBox4.Text = sumforegift.ToString();
                    //查询是否是会员
                    MemberBLL mber = new MemberBLL();
                    int mcount = mber.count(ID);
                    if (mcount > 0)
                    {
                        this.textBox2.Text = (0.88).ToString();
                        this.textBox5.Text = (float.Parse(this.textBox3.Text) * 0.88).ToString();
                    }
                    this.textBox6.Text = (-(int.Parse(this.textBox5.Text) + int.Parse(this.textBox4.Text) - int.Parse(this.textBox3.Text))).ToString();
                    //this.textBox7.Text=
                    this.textBox9.Text = (int.Parse(this.textBox7.Text) - int.Parse(this.textBox6.Text)).ToString();
                }
                else
                {
                    #region
                    //new fmMessageBox("系统提示", "该组内没有联系人", "确定").Show();
                    //MessageBox.Show("该组内没有联系人");
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //
            //
            try
            {
                this.listView2.Items.Clear();
                CuspenBLL blls = new CuspenBLL();
                int counts = blls.counts(this.roomid);
                if (counts != 0)
                {
                    List<CusSpenInfo> Spendlist = new List<CusSpenInfo>();
                    listView2.LabelEdit = true;
                    Spendlist = blls.SelectSpend(this.roomid, this.label2.Text);
                    for (int i = 0; i < Spendlist.Count; i++)
                    {

                        ListViewItem li = new ListViewItem(Spendlist[i].g_price.ToString());
                        li.SubItems.Add(Spendlist[i].g_count.ToString());
                        li.SubItems.Add(Spendlist[i].totolAmount.ToString());
                        li.SubItems.Add(Spendlist[i].RoomId.ToString());
                        li.SubItems.Add(Spendlist[i].s_time.ToString());
                        li.SubItems.Add(Spendlist[i].operation.ToString());
                        li.SubItems.Add(Spendlist[i].Goods_name.ToString());
                        this.listView2.Items.Add(li);
                    }
                }
                else
                {
                    #region
                    //new fmMessageBox("系统提示", "该组内没有联系人", "确定").Show();
                    //MessageBox.Show("该组内没有联系人");
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 选中显示消费信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_Click(object sender, EventArgs e)
        {
            try
            {
                this.listView2.Items.Clear();
                if (this.listView1.SelectedItems.Count > 0)
                {
                    CuspenBLL blls = new CuspenBLL();
                    #region
                    //int counts = blls.counts(int.Parse(this.listView1.SelectedItems[0].SubItems[0].Text));
                    //if (counts != 0)
                    //{
                    #endregion
                    List<CusSpenInfo> Spendlist = new List<CusSpenInfo>();
                    listView2.LabelEdit = true;
                    string roomid = this.listView1.SelectedItems[0].SubItems[0].Text.Replace("[", "").Replace("已退", "").Replace("]", "");
                    Spendlist = blls.SelectSpend(int.Parse(roomid), this.label2.Text);
                    this.label3.Text = roomid;
                    if (Spendlist.Count != 0)
                    {
                        for (int i = 0; i < Spendlist.Count; i++)
                        {

                            ListViewItem li = new ListViewItem(Spendlist[i].g_price.ToString());
                            li.SubItems.Add(Spendlist[i].g_count.ToString());
                            li.SubItems.Add(Spendlist[i].totolAmount.ToString());
                            li.SubItems.Add(Spendlist[i].RoomId.ToString());
                            li.SubItems.Add(Spendlist[i].s_time.ToString());
                            li.SubItems.Add(Spendlist[i].operation.ToString());
                            li.SubItems.Add(Spendlist[i].Goods_name.ToString());

                            this.listView2.Items.Add(li);
                        }
                    }
                    #region
                    //}
                    //else
                    //{
                    //new fmMessageBox("系统提示", "该组内没有联系人", "确定").Show();
                    //MessageBox.Show("该组内没有联系人");
                    //}
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 结账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            new showMessage("系统提示", "你确定要结账吗？").ShowDialog();
            if (showMessage.result.Equals(true))
            {
                
           
                try
                {
                    #region
                    //CheckBLL bll = new CheckBLL();
                    //CheckOutInfo check = new CheckOutInfo();
                    //check.checkno = this.label2.Text.ToString();
                    //check.RoomId = int.Parse(this.label3.Text);
                    //check.to_monet = Convert.ToDecimal(this.textBox3.Text);
                    //check.forgift = Convert.ToDecimal(this.textBox4.Text);
                    //check.checktime = DateTime.Now;
                    //int count = bll.Insert(check);
                    //if (count > 0)
                    //{
                    //BLLcustomer blls = new BLLcustomer();
                    //blls.deleInfotByRoomid(roomid.ToString());
                    //blls.deletSpanByRoomid(roomid.ToString())
                    #endregion

                    RoomInfoBLL bl = new RoomInfoBLL();
                    BLLcustomer ditybll = new BLLcustomer();
                    CheckBLL bll = new CheckBLL();//存表
                    CheckOutInfo check = new CheckOutInfo();//存表
                    for (int i = 0; i < this.listView1.Items.Count; i++)
                    {

                        string roomid = this.listView1.Items[i].SubItems[0].Text.Replace("[", "").Replace("已退", "").Replace("]", "");

                        int count = ditybll.selectInfotByRoomidAndSpanno(roomid.ToString(), this.label2.Text);

                        if (count > 0)
                        {
                            check.checkno = this.label2.Text.ToString();
                            check.RoomId = Convert.ToInt32(roomid);
                            check.to_monet = Convert.ToDecimal(this.textBox3.Text);
                            check.forgift = Convert.ToDecimal(this.textBox4.Text);
                            bll.Insert(check);
                            ditybll.deleInfotByRoomidAndSpanno(roomid.ToString(), this.label2.Text);

                            int lbzf = int.Parse(fm.label7.Text);
                            fm.label7.Text = (lbzf - 1).ToString();//住房
                            int lbzaf = int.Parse(fm.label8.Text);
                            fm.label8.Text = (lbzaf + 1).ToString();//脏房
                            bl.opertStateZang(roomid);
                            RoomInfo room = new RoomInfo();
                            room = bl.selectByRoomId(int.Parse(roomid.ToString()));
                            if (fmMain.xxkInder == 0)//所有
                            {
                                UCRoom uc = new UCRoom();
                                uc = fm.flyPanelAll.Controls[roomid.ToString()] as UCRoom;
                                uc.state = "2";
                                uc.BGlode();
                                if (room.r_type.Equals("标准房"))
                                {
                                    UCRoom ucs = new UCRoom();
                                    ucs = fm.flpStandard.Controls[roomid.ToString()] as UCRoom;
                                    ucs.state = "2";
                                    ucs.BGlode();
                                }
                                else if (room.r_type.Equals("单人房"))
                                {
                                    UCRoom ucs = new UCRoom();
                                    ucs = fm.flyOne.Controls[roomid.ToString()] as UCRoom;
                                    ucs.state = "2";
                                    ucs.BGlode();
                                }
                                else if (room.r_type.Equals("商务房"))
                                {
                                    UCRoom ucs = new UCRoom();
                                    ucs = fm.flyBusiness.Controls[roomid.ToString()] as UCRoom;
                                    ucs.state = "2";
                                    ucs.BGlode();
                                }
                                else if (room.r_type.Equals("商务单套"))
                                {
                                    UCRoom ucs = new UCRoom();
                                    ucs = fm.flyLeveBus.Controls[roomid.ToString()] as UCRoom;
                                    ucs.state = "2";
                                    ucs.BGlode();
                                }
                                else if (room.r_type.Equals("海景房"))
                                {
                                    UCRoom ucs = new UCRoom();
                                    ucs = fm.flySeaview.Controls[roomid.ToString()] as UCRoom;
                                    ucs.state = "2";
                                    ucs.BGlode();
                                }
                                else if (room.r_type.Equals("豪华单人"))
                                {
                                    UCRoom ucs = new UCRoom();
                                    ucs = fm.flyDexSingle.Controls[roomid.ToString()] as UCRoom;
                                    ucs.state = "2";
                                    ucs.BGlode();
                                }
                                else if (room.r_type.Equals("豪华标准"))
                                {
                                    UCRoom ucs = new UCRoom();
                                    ucs = fm.flyDexStandard.Controls[roomid.ToString()] as UCRoom;
                                    ucs.state = "2";
                                    ucs.BGlode();
                                }
                                else if (room.r_type.Equals("总统套房"))
                                {
                                    UCRoom ucs = new UCRoom();
                                    ucs = fm.flyPresent.Controls[roomid.ToString()] as UCRoom;
                                    ucs.state = "2";
                                    ucs.BGlode();
                                }
                                else { }
                            }
                            else if (fmMain.xxkInder == 1)//标准房
                            {
                                UCRoom uc = new UCRoom();
                                uc = fm.flpStandard.Controls[roomid.ToString()] as UCRoom;
                                uc.state = "2";
                                uc.BGlode();
                                UCRoom uca = new UCRoom();
                                uca = fm.flyPanelAll.Controls[roomid.ToString()] as UCRoom;
                                uca.state = "2";
                                uca.BGlode();
                            }
                            else if (fmMain.xxkInder == 2)//单人房
                            {
                                UCRoom uc = new UCRoom();
                                uc = fm.flyOne.Controls[roomid.ToString()] as UCRoom;
                                uc.state = "2";
                                uc.BGlode();
                                UCRoom uca = new UCRoom();
                                uca = fm.flyPanelAll.Controls[roomid.ToString()] as UCRoom;
                                uca.state = "2";
                                uca.BGlode();
                            }
                            else if (fmMain.xxkInder == 3)//商务房
                            {
                                UCRoom uc = new UCRoom();
                                uc = fm.flyBusiness.Controls[roomid.ToString()] as UCRoom;
                                uc.state = "2";
                                uc.BGlode();
                                UCRoom uca = new UCRoom();
                                uca = fm.flyPanelAll.Controls[roomid.ToString()] as UCRoom;
                                uca.state = "2";
                                uca.BGlode();
                            }
                            else if (fmMain.xxkInder == 4)//商务单套
                            {
                                UCRoom uc = new UCRoom();
                                uc = fm.flyLeveBus.Controls[roomid.ToString()] as UCRoom;
                                uc.state = "2";
                                uc.BGlode();
                                UCRoom uca = new UCRoom();
                                uca = fm.flyPanelAll.Controls[roomid.ToString()] as UCRoom;
                                uca.state = "2";
                                uca.BGlode();
                            }
                            else if (fmMain.xxkInder == 5)//海景房
                            {
                                UCRoom uc = new UCRoom();
                                uc = fm.flySeaview.Controls[roomid.ToString()] as UCRoom;
                                uc.state = "2";
                                uc.BGlode();
                                UCRoom uca = new UCRoom();
                                uca = fm.flyPanelAll.Controls[roomid.ToString()] as UCRoom;
                                uca.state = "2";
                                uca.BGlode();
                            }
                            else if (fmMain.xxkInder == 6)//豪华单人
                            {
                                UCRoom uc = new UCRoom();
                                uc = fm.flyDexSingle.Controls[roomid.ToString()] as UCRoom;
                                uc.state = "2";
                                uc.BGlode();
                                UCRoom uca = new UCRoom();
                                uca = fm.flyPanelAll.Controls[roomid.ToString()] as UCRoom;
                                uca.state = "2";
                                uca.BGlode();
                            }
                            else if (fmMain.xxkInder == 7)//豪华标准
                            {
                                UCRoom uc = new UCRoom();
                                uc = fm.flyDexStandard.Controls[roomid.ToString()] as UCRoom;
                                uc.state = "2";
                                uc.BGlode();
                                UCRoom uca = new UCRoom();
                                uca = fm.flyPanelAll.Controls[roomid.ToString()] as UCRoom;
                                uca.state = "2";
                                uca.BGlode();
                            }
                            else if (fmMain.xxkInder == 8)//总统套房
                            {
                                UCRoom uc = new UCRoom();
                                uc = fm.flyPresent.Controls[roomid.ToString()] as UCRoom;
                                uc.state = "2";
                                uc.BGlode();
                                UCRoom uca = new UCRoom();
                                uca = fm.flyPanelAll.Controls[roomid.ToString()] as UCRoom;
                                uca.state = "2";
                                uca.BGlode();
                            }
                            else { }
                        }
                    }
                    getSpend();
                    new showMessagecs("系统提示", "成功!").ShowDialog();
                    this.Close();
                    if(this.fmalter!=null)
                    {
                        this.fmalter.Close();
                    }
               
                    #region
                    //}
                    //else
                    //{
                    //    new showMessagecs("系统提示", "失败!").ShowDialog();
                    //}
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { }

        }
        Point mouseOff;
        bool leftFlag;
        private void fmAccount_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void fmAccount_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }

        private void fmAccount_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox7.Text != "")
            {
                this.textBox9.Text = (int.Parse(this.textBox7.Text) - int.Parse(this.textBox6.Text)).ToString();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox5.Text != "")
            {
                this.textBox6.Text = (double.Parse(this.textBox4.Text) - alltotal + double.Parse(this.textBox5.Text)).ToString();
            }
        }
        Bitmap bitmap;
        private void button5_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog print = new PrintPreviewDialog();
            print.Document = printDocument1;
            try
            {
                print.ShowDialog();
            }
            catch (Exception ex)
            {
                new showMessagecs("系统提示", "打印出错").ShowDialog();
            }

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bitmap = new Bitmap(600, 600);
            Graphics g = Graphics.FromImage(bitmap);
            TuPian(g);
            e.Graphics.DrawImage(bitmap, 0, 0);

        }
        private void TuPian(Graphics g)
        {
            CuspenBLL bll = new CuspenBLL();

            List<CusSpenInfo> list = new List<CusSpenInfo>();
            list = bll.SelectSpend(roomid,this.label2.Text);
            if (list.Count >= 0)
            {
                BLLcustomer cus = new BLLcustomer();
                InInfo roommes = new InInfo();
                roommes = cus.selectByRooid(roomid.ToString());
                int days=(DateTime.Now.Subtract(roommes.c_intoday)).Days;
               
                string dh = DateTime.Now.ToString().Replace(":", "").Replace(" ", "").Replace("/", "");

                Font font = new Font("宋体", 9);
                Brush brush = new SolidBrush(Color.Blue);
                Color color = Color.Blue;
                //g.DrawRectangle(new Pen(Color.Black), 5, 5, 300, 400);
                //g.DrawLine(new Pen(Color.Black), 5, 400, 305,405); 
                g.DrawString("高豪酒店收费系统", font, brush, 90, 20);
                g.DrawString("流水号：" + dh, font, brush, 5, 45);
                g.DrawString(DateTime.Now.ToString(), font, brush, 180, 45);
                Pen p = new Pen(Color.Blue);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawLine(p, 5, 60, 295, 60);
                g.DrawLine(p, 5, 65, 295, 65);
                g.DrawString("编号", font, brush, 5, 75);
                g.DrawString("商品名", font, brush, 70, 75);
                g.DrawString("单价", font, brush, 150, 75);
                g.DrawString("数量", font, brush, 200, 75);
                g.DrawString("金额", font, brush, 270, 75);
                g.DrawString("1", font, brush, 10, 95);
                g.DrawString("房费", font, brush, 75, 95);
                g.DrawString(roommes.r_RelPrice.ToString(), font, brush, 150, 95);
                g.DrawString(days.ToString(), font, brush, 205, 95);
                g.DrawString((roommes.r_RelPrice*days).ToString(), font, brush, 275, 95);
         
                int x = 5;
                int y = 95;
                double sum = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    y = y + 20;
                    g.DrawString((i + 2).ToString(), font, brush, x + 5, y);
                    g.DrawString(list[i].Goods_name, font, brush, x + 70, y);
                    g.DrawString(list[i].g_price.ToString(), font, brush, x + 145, y);
                    g.DrawString(list[i].g_count, font, brush, x + 200, y);
                    g.DrawString((list[i].g_price *Convert.ToDecimal(list[i].g_count)).ToString(), font, brush, x + 270, y);
                    sum = sum + Convert.ToDouble((list[i].g_price * Convert.ToDecimal(list[i].g_count)).ToString());
                }
                sum = sum + Convert.ToDouble((roommes.r_RelPrice * days));
                int endx = x + 270;
                int endy = y;
                g.DrawString("总计：" + sum, font, brush, endx - 50, endy + 80);
                g.DrawString("操作员：" + Global.user.UserName, font, brush, endx - 50, endy + 100);

            }
        }
        /// <summary>
        /// 单人退房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                BLLcustomer ditybll = new BLLcustomer();
                int count = ditybll.zangfangcount(this.label2.Text);
                if (count == this.listView1.Items.Count)
                {
                    BLLcustomer blls = new BLLcustomer();
                    CheckBLL bll = new CheckBLL();//存表
                    CheckOutInfo check = new CheckOutInfo();//存表
                    for (int i = 0; i < this.listView1.Items.Count; i++)
                    {
                        string roomid = this.listView1.Items[i].SubItems[0].Text.Replace("[", "").Replace("已退", "").Replace("]", "");
                        ditybll.deleInfotByRoomidAndSpanno(roomid.ToString(), this.label2.Text);

                        check.checkno = this.label2.Text.ToString();
                        check.RoomId = int.Parse(roomid);
                        check.to_monet = Convert.ToDecimal(this.textBox3.Text);
                        check.forgift = Convert.ToDecimal(this.textBox4.Text);
                        bll.Insert(check);
                        //blls.deletSpanByRoomid(roomid.ToString());
                    }
                    RoomInfoBLL bl = new RoomInfoBLL();

                    bl.opertStateZang(this.listView1.SelectedItems[0].SubItems[0].Text);
                    int lbzf = int.Parse(fm.label7.Text);
                    fm.label7.Text = (lbzf - 1).ToString();//住房
                    int lbzaf = int.Parse(fm.label8.Text);
                    fm.label8.Text = (lbzaf + 1).ToString();//脏房
                    this.listView1.SelectedItems[0].SubItems[0].Text = this.listView1.SelectedItems[0].SubItems[0].Text + "[已退]";
                    #region
                    //for (int i = 0; i < this.listView1.Items.Count; i++)
                    //{
                    //    if (this.listView1.Items[i].SubItems[9].Text.c== 0)
                    //    {
                    //        CheckBLL bll = new CheckBLL();
                    //        CheckOutInfo check = new CheckOutInfo();
                    //        check.checkno = this.label2.Text.ToString();
                    //        check.RoomId = int.Parse(this.label3.Text);
                    //        check.to_monet = Convert.ToDecimal(this.textBox3.Text);
                    //        check.forgift = Convert.ToDecimal(this.textBox4.Text);
                    //        check.checktime = DateTime.Now;
                    //        int count = bll.Insert(check);
                    //        for (int j = 0; j < this.listView1.Items.Count; j++)
                    //        {
                    //            BLLcustomer blls = new BLLcustomer();
                    //            blls.deleInfotByRoomid(this.listView1.Items[j].SubItems[0].Text.ToString());
                    //            blls.deletSpanByRoomid(this.listView1.Items[j].SubItems[0].Text.ToString());

                    //        }
                    //    }
                    //}
                    #endregion
                    RoomInfo room = new RoomInfo();
                    string Roomid = this.listView1.Items[0].SubItems[0].Text.Replace("[", "").Replace("已退", "").Replace("]", "");
                    room = bl.selectByRoomId(int.Parse(Roomid.ToString()));
                    int lbzfs = int.Parse(fm.label7.Text);
                    fm.label7.Text = (lbzfs - 1).ToString();//住房
                    int lbzafs = int.Parse(fm.label8.Text);
                    fm.label8.Text = (lbzafs + 1).ToString();//脏房
                    if (fmMain.xxkInder == 0)//所有
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        if (room.r_type.Equals("标准房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flpStandard.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("单人房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flyOne.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("商务房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flyBusiness.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("商务单套"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flyLeveBus.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("海景房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flySeaview.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("豪华单人"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flyDexSingle.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("豪华标准"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flyDexStandard.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("总统套房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flyPresent.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else { }
                    }
                    else if (fmMain.xxkInder == 1)//标准房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flpStandard.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 2)//单人房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyOne.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 3)//商务房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyBusiness.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 4)//商务单套
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyLeveBus.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 5)//海景房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flySeaview.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 6)//豪华单人
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyDexSingle.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 7)//豪华标准
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyDexStandard.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 8)//总统套房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyPresent.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else { }
                    getSpend();
                    new showMessagecs("系统提示", "成功!").ShowDialog();
                }
                else
                {
                    RoomInfoBLL bl = new RoomInfoBLL();

                    bl.opertStateZang(this.listView1.SelectedItems[0].SubItems[0].Text);
                    int lbzf = int.Parse(fm.label7.Text);
                    fm.label7.Text = (lbzf - 1).ToString();//住房
                    int lbzaf = int.Parse(fm.label8.Text);
                    fm.label8.Text = (lbzaf + 1).ToString();//脏房
                    this.listView1.SelectedItems[0].SubItems[0].Text = this.listView1.SelectedItems[0].SubItems[0].Text + "[已退]";
                    #region
                    //for (int i = 0; i < this.listView1.Items.Count; i++)
                    //{
                    //    if (this.listView1.Items[i].SubItems[9].Text.c== 0)
                    //    {
                    //        CheckBLL bll = new CheckBLL();
                    //        CheckOutInfo check = new CheckOutInfo();
                    //        check.checkno = this.label2.Text.ToString();
                    //        check.RoomId = int.Parse(this.label3.Text);
                    //        check.to_monet = Convert.ToDecimal(this.textBox3.Text);
                    //        check.forgift = Convert.ToDecimal(this.textBox4.Text);
                    //        check.checktime = DateTime.Now;
                    //        int count = bll.Insert(check);
                    //        for (int j = 0; j < this.listView1.Items.Count; j++)
                    //        {
                    //            BLLcustomer blls = new BLLcustomer();
                    //            blls.deleInfotByRoomid(this.listView1.Items[j].SubItems[0].Text.ToString());
                    //            blls.deletSpanByRoomid(this.listView1.Items[j].SubItems[0].Text.ToString());

                    //        }
                    //    }
                    //}
                    #endregion
                    RoomInfo room = new RoomInfo();
                    string Roomid = this.listView1.Items[0].SubItems[0].Text.Replace("[", "").Replace("已退", "").Replace("]", "");
                    room = bl.selectByRoomId(int.Parse(Roomid.ToString()));
                    if (fmMain.xxkInder == 0)//所有
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        if (room.r_type.Equals("标准房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flpStandard.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("单人房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flyOne.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("商务房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flyBusiness.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("商务单套"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flyLeveBus.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("海景房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flySeaview.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("豪华单人"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flyDexSingle.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("豪华标准"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flyDexStandard.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else if (room.r_type.Equals("总统套房"))
                        {
                            UCRoom ucs = new UCRoom();
                            ucs = fm.flyPresent.Controls[Roomid.ToString()] as UCRoom;
                            ucs.state = "2";
                            ucs.BGlode();
                        }
                        else { }
                    }
                    else if (fmMain.xxkInder == 1)//标准房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flpStandard.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 2)//单人房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyOne.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 3)//商务房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyBusiness.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 4)//商务单套
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyLeveBus.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 5)//海景房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flySeaview.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 6)//豪华单人
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyDexSingle.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 7)//豪华标准
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyDexStandard.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else if (fmMain.xxkInder == 8)//总统套房
                    {
                        UCRoom uc = new UCRoom();
                        uc = fm.flyPresent.Controls[Roomid.ToString()] as UCRoom;
                        uc.state = "2";
                        uc.BGlode();
                        UCRoom uca = new UCRoom();
                        uca = fm.flyPanelAll.Controls[Roomid.ToString()] as UCRoom;
                        uca.state = "2";
                        uca.BGlode();
                    }
                    else { }
                    getSpend();
                    new showMessagecs("系统提示", "成功!").ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("请选择要结账的账单！");
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

        private void label15_Click(object sender, EventArgs e)
        {
            MemberBLL Vipbll = new MemberBLL();
            int count = Vipbll.VipIdCount(this.textBox1.Text);
            if (count > 0)
            {
                this.textBox2.Text = (0.88).ToString();
                this.textBox5.Text = (0.12 * Convert.ToDouble(this.textBox3.Text)).ToString();
                //this.textBox6.Text =  (Convert.ToDouble(this.textBox5.Text) +  Convert.ToDouble(this.textBox4.Text) -  Convert.ToDouble(this.textBox3.Text)).ToString();
                this.textBox9.Text = Convert.ToDouble(this.textBox6.Text).ToString();
            }
            else
            {
                this.textBox2.Text = "不是会员！";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                this.label15.Hide();
            }
            else
            {
                this.label15.Show();
            }
        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    if (this.textBox1.Text == "")
        //    {
        //        this.label7.Hide();
        //    }
        //    else
        //    {
        //        this.label7.Show();
        //    }

        //}

        //private void label7_Click(object sender, EventArgs e)
        //{
        //    MemberBLL Vipbll = new MemberBLL();
        //    int count = Vipbll.VipIdCount(this.textBox1.Text);
        //    if (count > 0)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}



    }
}

