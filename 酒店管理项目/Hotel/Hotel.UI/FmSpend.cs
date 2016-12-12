using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.BLL;
using System.Collections;
using Hotel.Model;

namespace Hotel.UI
{
    public partial class FmSpend : Form
    {
        private string roomid;
        private fmMain fm;
        private fmMain fms;
        public FmSpend(string roomid, fmMain fms)
        {
            this.roomid = roomid;
            this.fms = fms;
            fm = fms;
            InitializeComponent();


        }
        public FmSpend(string roomid)
        {
            this.roomid = roomid;
            InitializeComponent();


        }
        public FmSpend()
        {
            InitializeComponent();
        }

        private void FmSpend_Load(object sender, EventArgs e)
        {

            getlistview();
            this.groupBox2.Text = this.roomid + "房间的消费清单";
            //listview2
            try
            {
                CuspenBLL blls = new CuspenBLL();
                //int counts = blls.counts(int.Parse(this.roomid),);
                BLLcustomer bllsa = new BLLcustomer();
                InInfo select = bllsa.selectByRooid(this.roomid.ToString());
                List<CusSpenInfo> Spendlist = new List<CusSpenInfo>();
                Spendlist = blls.SelectSpend(int.Parse(this.roomid), select.in_number);


                listView2.LabelEdit = true;
                for (int i = 0; i < Spendlist.Count; i++)
                {

                    ListViewItem li = new ListViewItem(Spendlist[i].Goods_name.ToString());
                    //li.SubItems.Clear();
                    //li.SubItems.Add(Goodslist[i].Goods_BM.ToString());
                    li.SubItems.Add(Spendlist[i].g_price.ToString());
                    li.SubItems.Add(Spendlist[i].g_count.ToString());
                    li.SubItems.Add(Spendlist[i].totolAmount.ToString());
                    li.SubItems.Add(Spendlist[i].RoomId.ToString());
                    li.SubItems.Add(Spendlist[i].s_time.ToString());
                    li.SubItems.Add(Spendlist[i].operation.ToString());

                    this.listView2.Items.Add(li);

                    //MessageBox.Show(list[i].ConstactName.ToString());

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Getspend();

        }

        private void getlistview()
        {
            try
            {
                GoodsBLL bll = new GoodsBLL();
                int count = bll.count();
                if (count != 0)
                {
                    List<GoodsListInfo> Goodslist = new List<GoodsListInfo>();
                    listView1.LabelEdit = true;
                    Goodslist = bll.SelectGoods();
                    for (int i = 0; i < count; i++)
                    {

                        ListViewItem li = new ListViewItem(Goodslist[i].Goods_BM.ToString());
                        //li.SubItems.Clear();
                        //li.SubItems.Add(Goodslist[i].Goods_BM.ToString());
                        li.SubItems.Add(Goodslist[i].Goods_Name.ToString());
                        li.SubItems.Add(Goodslist[i].Goods_price.ToString());
                        li.SubItems.Add(Goodslist[i].Goods_count.ToString());
                        li.SubItems.Add(Goodslist[i].Goods_Unit.ToString());
                        this.listView1.Items.Add(li);

                        //MessageBox.Show(list[i].ConstactName.ToString());

                    }
                }
                else
                {
                    //new fmMessageBox("系统提示", "该组内没有联系人", "确定").Show();
                    //MessageBox.Show("该组内没有联系人");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 获取费用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Getspend()
        {
            int sum = 0;
            for (int i = 0; i < this.listView2.Items.Count; i++)
            {

                if (this.listView2.Items[i].SubItems[0].Text.IndexOf("房费") >= 0)
                {

                    sum = sum + Convert.ToInt32(this.listView2.Items[i].SubItems[3].Text);
                    this.textBox4.Text = sum.ToString();
                }
                else
                {
                    sum = sum + Convert.ToInt32(this.listView2.Items[i].SubItems[3].Text);
                    this.textBox5.Text = sum.ToString();
                }
            }
            if (this.textBox4.Text == "" && this.textBox5.Text != "")
            {
                this.textBox6.Text = this.textBox5.Text;
            }
            else if (this.textBox4.Text != "" && this.textBox5.Text == "")
            {
                this.textBox6.Text = this.textBox4.Text;
            }
            else if (this.textBox4.Text != "" && this.textBox5.Text != "")
            {
                this.textBox6.Text = (Convert.ToInt32(this.textBox4.Text) + Convert.ToInt32(this.textBox5.Text)).ToString();
            }
            else
            {
                this.textBox6.Text = "";
            }
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                this.textBox3.Text = e.Item.SubItems[1].Text;
                //MessageBox.Show(e.Item.Text + e.Item.SubItems[1].Text + e.Item.SubItems[2].Text);
            }
        }

        public void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                //MessageBox.Show(info.Item.SubItems[1].Text);
                ChildSpend child = new ChildSpend(this, info.Item.SubItems[1].Text, Convert.ToInt32(this.textBox2.Text), decimal.Parse(info.Item.SubItems[2].Text), this.roomid);

                child.Show();
                info.Item.Selected = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ChildSpend child = new ChildSpend(this, this.listView1.SelectedItems[0].SubItems[1].Text, Convert.ToInt32(this.textBox2.Text), decimal.Parse(this.listView1.SelectedItems[0].SubItems[2].Text), this.roomid);
                child.Show();
                this.listView1.SelectedItems[0].Checked = true;
            }

        }
        //判断用户输入的数据，是数字还是字符，数字为true，名字false
        public bool bolNum(string temp)
        {
            try
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    byte tempByte = Convert.ToByte(temp[i]);
                    if (tempByte < 48 || (tempByte > 57))
                    {
                        return false;
                    }

                }
                return true;//为编码
            }
            catch (Exception)
            {
                return false;
            }

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = this.textBox1.Text.ToString();

            if (text != "")
            {
                if (bolNum(text))//查找输入为编码
                {
                    GoodsBLL bll = new GoodsBLL();
                    List<GoodsListInfo> Spendlist = new List<GoodsListInfo>();
                    Spendlist = bll.SelectGoodsBM(text);
                    this.listView1.Items.Clear();
                    if (Spendlist != null)
                    {
                        for (int i = 0; i < Spendlist.Count; i++)
                        {
                            ListViewItem li = new ListViewItem(Spendlist[i].Goods_BM.ToString());
                            //li.SubItems.Add(Goodslist[i].Goods_BM.ToString());
                            li.SubItems.Add(Spendlist[i].Goods_Name.ToString());
                            li.SubItems.Add(Spendlist[i].Goods_price.ToString());
                            li.SubItems.Add(Spendlist[i].Goods_count.ToString());
                            li.SubItems.Add(Spendlist[i].Goods_Unit.ToString());
                            this.listView1.Items.Add(li);


                        }
                    }
                }
                else
                {
                    GoodsBLL bll = new GoodsBLL();
                    List<GoodsListInfo> Spendlist = new List<GoodsListInfo>();
                    Spendlist = bll.SelectGoodsJP(text);
                    this.listView1.Items.Clear();
                    if (Spendlist != null)
                    {
                        for (int i = 0; i < Spendlist.Count; i++)
                        {
                            ListViewItem li = new ListViewItem(Spendlist[i].Goods_BM.ToString());
                            //li.SubItems.Add(Goodslist[i].Goods_BM.ToString());
                            li.SubItems.Add(Spendlist[i].Goods_Name.ToString());
                            li.SubItems.Add(Spendlist[i].Goods_price.ToString());
                            li.SubItems.Add(Spendlist[i].Goods_count.ToString());
                            li.SubItems.Add(Spendlist[i].Goods_Unit.ToString());
                            this.listView1.Items.Add(li);


                        }
                    }


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fmAccount fms = new fmAccount(int.Parse(this.roomid), fm);
            fms.ShowDialog();
            this.Close();
        }
        Point mouseOff;
        bool leftFlag;
        private void FmSpend_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void FmSpend_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }

        private void FmSpend_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (this.listView2.SelectedItems.Count > 0)
            {
                DateTime intime = Convert.ToDateTime(this.listView2.SelectedItems[0].SubItems[5].Text);//入账时间
                CuspenBLL bll = new CuspenBLL();
                int count = bll.delete(intime);
                //if (count > 0)
                //{
                //    MessageBox.Show("删除成功！");
                //}
                //else
                //{
                //    MessageBox.Show("删除失败！");
                //}
                string Good = this.listView2.SelectedItems[0].SubItems[0].Text;
                //MessageBox.Show(Good);
                int selectcount = int.Parse(this.listView2.SelectedItems[0].SubItems[2].Text);
                GoodsBLL gbll = new GoodsBLL();
                int bcount = gbll.Updatecount(Good, selectcount);
                //if (bcount > 0)
                //{
                //    MessageBox.Show("修改成功");
                //}
                //else
                //{
                //    MessageBox.Show("修改失败");
                //}
                this.listView2.SelectedItems[0].Remove();
                getlistview();
            }
        }

    }
}
