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
    public partial class fmThingAdd : Form
    {
        fmMain fm = new fmMain();
        public fmThingAdd(fmMain fms)
        {
            fm = fms;
            InitializeComponent();
        }
        /// <summary>
        /// 窗体关闭最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 窗体panel可拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        Point mouseOff;
        bool leftFlag;
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
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag1 = true;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }

        private void fmThingAdd_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 窗体可拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        Point mouseOff1;
        bool leftFlag1;
        private void fmThingAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff1 = new Point(-e.X, -e.Y);
                leftFlag1 = true;
            }
        }

        private void fmThingAdd_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                leftFlag1 = false;
            }
          
        }

        private void fmThingAdd_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff1.Y);
                Location = mouseSet;
            }
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            GoodsListInfo list = new GoodsListInfo();
            list.Goods_JP = TxtGoodsJP.Text;
            list.Goods_Name = TxtGoodsName.Text;
            list.Goods_price = decimal.Parse(TxtGoodsPrice.Text);
            list.Goods_Unit = TxtGoodsUnit.Text;
            list.Goods_count = int.Parse(TxtGoodsCount.Text);
            list.Goods_BM = TxtGoodsBN.Text;
            GoodsBLL bll = new GoodsBLL();
            int exist = bll.GoodsSelectByBMsingle(TxtGoodsBN.Text.ToString());
            if (exist == 1)
            {
                new showMessagecs("系统提示", "该商品编码已存在!").ShowDialog();
            }
            else
            {
                int count = bll.GoodsAdd(list);
                if (count == 1)
                {
                    new showMessageok("系统提示", "成功!").ShowDialog();
                    fm.GoodsListLode();
                    this.Close();
                }
                else
                {
                    new showMessagecs("系统提示", "失败，具体原因不清楚!").ShowDialog();
                }
            }
        }
       
    }
}
