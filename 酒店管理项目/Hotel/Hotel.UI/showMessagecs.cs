﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel.UI
{
    public partial class showMessagecs : Form
    {
        public static bool result;
        public showMessagecs(string top,string msg)
        {
            InitializeComponent();
            this.lbTop.Text = top;
            this.lbMess.Text = msg;
        }

       
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            result = true;
            this.Close();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            result = false;
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            result = false;
            this.Close();
        }
        /// <summary>
        /// 窗体可拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        Point mouseOff;
        bool leftFlag;
        private void showMessagecs_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        private void showMessagecs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void showMessagecs_MouseMove(object sender, MouseEventArgs e)
        {

            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }

        private void showMessagecs_Load(object sender, EventArgs e)
        {
            result = true;
        }
    }
}
