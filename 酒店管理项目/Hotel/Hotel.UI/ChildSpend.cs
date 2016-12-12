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
    public partial class ChildSpend : Form
    {
        private string Goodsname;
        private int count;
        private decimal price;
        private string roomid;
        private FmSpend frmParent = new FmSpend();
        public ChildSpend(FmSpend fmparent, string name, int count, decimal price, string roomid)
        {
            InitializeComponent();
            this.frmParent = fmparent;
            this.Goodsname = name;
            this.count = count;
            this.price = price;
            this.roomid = roomid;
        }

        private void ChildSpend_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = this.Goodsname;
            this.textBox2.Text = this.count.ToString();
            this.textBox3.Text = this.price.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            ListViewItem li = new ListViewItem(this.textBox1.Text);
            li.SubItems.Add(this.textBox3.Text);
            li.SubItems.Add(this.textBox2.Text);
            li.SubItems.Add((Convert.ToInt32(this.textBox3.Text) * Convert.ToInt32(this.textBox2.Text)).ToString());
            li.SubItems.Add(this.roomid);
            li.SubItems.Add(DateTime.Now.ToString());
            li.SubItems.Add(Global.user.UserName);//操作员
            this.frmParent.listView2.Items.Add(li);


            for (int i = 0; i < this.frmParent.listView1.Items.Count; i++)
            {
                if (this.frmParent.listView1.Items[i].SubItems[1].Text.IndexOf(textBox1.Text.Trim()) >= 0)
                {

                    this.frmParent.listView1.Items[i].SubItems[3].Text = (Convert.ToInt32(this.frmParent.listView1.Items[i].SubItems[3].Text) - Convert.ToInt32(this.textBox2.Text)).ToString();

                    GoodsBLL bll = new GoodsBLL();
                    try
                    {
                        GoodsListInfo good = new GoodsListInfo();

                        good.Goods_Name = textBox1.Text.Trim();
                        good.Goods_count = Convert.ToInt32(this.frmParent.listView1.Items[i].SubItems[3].Text);
                        int temp = bll.Update(good);
                        if (temp > 0)
                        {

                            //MessageBox.Show("修改成功");
                        }
                        else
                        {

                            //MessageBox.Show("修改失败！");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            CuspenBLL bllspen = new CuspenBLL();
            List<CusSpenInfo> spenlist = new List<CusSpenInfo>();
            for (int i = 0; i < this.frmParent.listView2.Items.Count; i++)
            {
                if (i == this.frmParent.listView2.Items.Count - 1)
                {
                    CusSpenInfo spen = new CusSpenInfo();
                    spen.Goods_name = this.frmParent.listView2.Items[i].SubItems[0].Text;
                    spen.g_price = Convert.ToDecimal(this.frmParent.listView2.Items[i].SubItems[1].Text);
                    spen.g_count = this.frmParent.listView2.Items[i].SubItems[2].Text;
                    if (this.frmParent.textBox5.Text != "")
                    {
                        spen.OtherSpend = Convert.ToDecimal(this.frmParent.textBox5.Text);
                    }
                    else
                    {

                    }
                    spen.totolAmount = Convert.ToDecimal(this.frmParent.listView2.Items[i].SubItems[3].Text);
                    spen.RoomId = int.Parse(this.frmParent.listView2.Items[i].SubItems[4].Text);
                    spen.s_time = Convert.ToDateTime(this.frmParent.listView2.Items[i].SubItems[5].Text);
                    spen.operation = Global.user.UserName;//操作员
                    BLLcustomer blls = new BLLcustomer();
                    InInfo select = blls.selectByRooid(this.roomid.ToString());
                    spen.span_no = select.in_number;//消费单号
                    spen.s_name = select.c_name;//客户名
                    spenlist.Add(spen);
                }
            }
            int count = bllspen.Insert(spenlist);
            Getspend();
            this.Close();
        }
        /// <summary>
        /// 点击重新跟新
        /// </summary>
        private void Getspend()
        {
            int sum = 0;
            for (int i = 0; i < this.frmParent.listView2.Items.Count; i++)
            {

                if (this.frmParent.listView2.Items[i].SubItems[0].Text.IndexOf("房费") >= 0)
                {

                    sum = sum + Convert.ToInt32(this.frmParent.listView2.Items[i].SubItems[3].Text);
                    this.frmParent.textBox4.Text = sum.ToString();
                }
                else
                {
                    sum = sum + Convert.ToInt32(this.frmParent.listView2.Items[i].SubItems[3].Text);
                    this.frmParent.textBox5.Text = sum.ToString();
                }
            }
            if (this.frmParent.textBox4.Text == "" && this.frmParent.textBox5.Text != "")
            {
                this.frmParent.textBox6.Text = this.frmParent.textBox5.Text;
            }
            else if (this.frmParent.textBox4.Text != "" && this.frmParent.textBox5.Text == "")
            {
                this.frmParent.textBox6.Text = this.frmParent.textBox4.Text;
            }
            else if (this.frmParent.textBox4.Text != "" && this.frmParent.textBox5.Text != "")
            {
                this.frmParent.textBox6.Text = (Convert.ToInt32(this.frmParent.textBox4.Text) + Convert.ToInt32(this.frmParent.textBox5.Text)).ToString();
            }
            else
            {
                this.frmParent.textBox6.Text = "";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Point mouseOff;
        bool leftFlag;
        private void ChildSpend_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void ChildSpend_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }

        private void ChildSpend_MouseUp(object sender, MouseEventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
