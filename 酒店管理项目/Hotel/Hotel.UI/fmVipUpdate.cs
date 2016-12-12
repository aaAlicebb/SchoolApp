using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel.UI
{
    public partial class fmVipUpdate : Form
    {
        public fmVipUpdate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体关闭最小化取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
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

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff1.X, mouseOff1.Y);
                Location = mouseSet;
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
        /// <summary>
        /// 窗体可拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        Point mouseOff1;
        bool leftFlag1;
        private void fmVipUpdate_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                leftFlag1 = false;
            }
        }

        private void fmVipUpdate_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag1)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff1.X, mouseOff1.Y);
                Location = mouseSet;
            }
        }

        private void fmVipUpdate_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                mouseOff1 = new Point(-e.X, -e.Y);
                leftFlag1 = true;
            }
        }
    }
}
