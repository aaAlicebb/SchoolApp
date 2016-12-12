using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.Model;

namespace Hotel.UI
{

    public partial class fmProgress : Form
    {
        private BackgroundWorker bkWorker = new BackgroundWorker();
        private UserInfo users;
        private fmMain notifyForm = new fmMain();
      
        public fmProgress(UserInfo user)
        {
            users = user;
            InitializeComponent();
            // 添加下列语句可以避免异常。
            CheckForIllegalCrossThreadCalls = false;
            bkWorker.WorkerReportsProgress = true;
            bkWorker.WorkerSupportsCancellation = true;
            bkWorker.DoWork += new DoWorkEventHandler(DoWork);
            bkWorker.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);
            bkWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork);
        }


        private void fmProgress_Load(object sender, EventArgs e)
        {
            //this.label1.Text = message;
            //this.progressBar1.Value =Percent;            
            bkWorker.RunWorkerAsync();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //notifyForm.StartPosition = FormStartPosition.CenterParent;


            //notifyForm.ShowDialog();

        }
        public void DoWork(object sender, DoWorkEventArgs e)
        {
            // 事件处理，指定处理函数
            e.Result = ProcessProgress(bkWorker, e);
        }
        public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            // bkWorker.ReportProgress 会调用到这里，此处可以进行自定义报告方式
            notifyForm.SetNotifyInfo(e.ProgressPercentage, "处理进度:" + Convert.ToString(e.ProgressPercentage) + "%");
        }
        public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {

            notifyForm.Show();
            //new showMessageok("系统提示", "加载完毕！").ShowDialog();
            this.Hide();
        }
        private int ProcessProgress(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 500; i++)
            {
                if (bkWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return -1;
                }
                else
                {
                    bkWorker.ReportProgress(i / 10);
                    System.Threading.Thread.Sleep(1);
                }
            }
            return -1;
        }

       
    }
}
