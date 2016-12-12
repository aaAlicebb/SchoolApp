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
    public partial class fmThingDe : Form
    {
         public string bm;
        fmMain fms = new fmMain();
        public fmThingDe(string Bm,fmMain fm)
        {
            fms = fm;
            bm = Bm;
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
               /// <summary>
        /// 商品信息加载
        /// </summary>
        private void LodeList()
        {
            try
            {
                GoodsBLL bll = new GoodsBLL();
                GoodsListInfo list = new GoodsListInfo();
                list = bll.SelectByBmoNE(bm);
                TxtGoodsBN.Text = list.Goods_BM;
                TxtGoodsCount.Text = list.Goods_count.ToString();
                TxtGoodsJP.Text = list.Goods_JP;
                TxtGoodsName.Text = list.Goods_Name;
                TxtGoodsPrice.Text = list.Goods_price.ToString();
                TxtGoodsUnit.Text = list.Goods_Unit.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmThingDe_Load(object sender, EventArgs e)
        {
            LodeList();
        }
        /// <summary>
        /// 窗体可拖动
        /// </summary>
        Point mouseOff;
        bool leftFlag;
        private void fmThingDe_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff1 = new Point(-e.X, -e.Y);
                leftFlag1 = true;
            }
        }

        private void fmThingDe_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff1.X, mouseOff1.Y);
                Location = mouseSet;
            }
        }

        private void fmThingDe_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                leftFlag1 = false;
            }
        }
        Point mouseOff1;
        bool leftFlag1;
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                leftFlag1 = false;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                mouseOff1 = new Point(-e.X, -e.Y);
                leftFlag1 = true;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff1.X, mouseOff1.Y);
                Location = mouseSet;
            }
        }
        /// <summary>
        /// 确定更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            GoodsListInfo list = new GoodsListInfo();
            list.Goods_BM = TxtGoodsBN.Text;
            list.Goods_count = int.Parse(TxtGoodsCount.Text);
            list.Goods_JP = TxtGoodsJP.Text;
            list.Goods_Name = TxtGoodsName.Text;
            list.Goods_price = decimal.Parse(TxtGoodsPrice.Text);
            list.Goods_Unit = TxtGoodsUnit.Text;
            GoodsBLL bll = new GoodsBLL();
            int count = bll.AlterGoods(list);
            if (count == 1)
            {
                new showMessageok("系统提示", "成功!").ShowDialog();
                fms.GoodsListLode();
                this.Close();

            }
            else
            {
                new showMessagecs("系统提示", "失败!").ShowDialog();
            }
        }
    }
}
