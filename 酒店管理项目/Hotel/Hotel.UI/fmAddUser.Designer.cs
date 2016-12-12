namespace Hotel.UI
{
    partial class fmAddUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmAddUser));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtZJNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtUserPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtUserAddress = new System.Windows.Forms.TextBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnSaveAndAdd = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtSex = new System.Windows.Forms.ComboBox();
            this.comZJtype = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 30);
            this.panel2.TabIndex = 33;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(336, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "一";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(370, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(3, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "同住客人信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "证件类型：";
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.LightBlue;
            this.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Location = new System.Drawing.Point(309, 232);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(66, 33);
            this.BtnClose.TabIndex = 37;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "证件号码：";
            // 
            // TxtZJNumber
            // 
            this.TxtZJNumber.Location = new System.Drawing.Point(251, 61);
            this.TxtZJNumber.Multiline = true;
            this.TxtZJNumber.Name = "TxtZJNumber";
            this.TxtZJNumber.Size = new System.Drawing.Size(124, 20);
            this.TxtZJNumber.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 34;
            this.label3.Text = "姓名：";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(78, 110);
            this.TxtUserName.Multiline = true;
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(92, 20);
            this.TxtUserName.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "电话：";
            // 
            // TxtUserPhone
            // 
            this.TxtUserPhone.Location = new System.Drawing.Point(251, 113);
            this.TxtUserPhone.Multiline = true;
            this.TxtUserPhone.Name = "TxtUserPhone";
            this.TxtUserPhone.Size = new System.Drawing.Size(124, 20);
            this.TxtUserPhone.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "地址：";
            // 
            // TxtUserAddress
            // 
            this.TxtUserAddress.Location = new System.Drawing.Point(200, 167);
            this.TxtUserAddress.Multiline = true;
            this.TxtUserAddress.Name = "TxtUserAddress";
            this.TxtUserAddress.Size = new System.Drawing.Size(175, 20);
            this.TxtUserAddress.TabIndex = 35;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.LightBlue;
            this.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Location = new System.Drawing.Point(134, 232);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(77, 33);
            this.BtnDelete.TabIndex = 39;
            this.BtnDelete.Text = "删除客人";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnSaveAndAdd
            // 
            this.BtnSaveAndAdd.BackColor = System.Drawing.Color.LightBlue;
            this.BtnSaveAndAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnSaveAndAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveAndAdd.Location = new System.Drawing.Point(23, 232);
            this.BtnSaveAndAdd.Name = "BtnSaveAndAdd";
            this.BtnSaveAndAdd.Size = new System.Drawing.Size(95, 33);
            this.BtnSaveAndAdd.TabIndex = 38;
            this.BtnSaveAndAdd.Text = "保存并添加";
            this.BtnSaveAndAdd.UseVisualStyleBackColor = false;
            this.BtnSaveAndAdd.Click += new System.EventHandler(this.BtnSaveAndAdd_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.LightBlue;
            this.BtnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Location = new System.Drawing.Point(227, 232);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(66, 33);
            this.BtnSave.TabIndex = 40;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "性别：";
            // 
            // TxtSex
            // 
            this.TxtSex.FormattingEnabled = true;
            this.TxtSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.TxtSex.Location = new System.Drawing.Point(78, 165);
            this.TxtSex.Name = "TxtSex";
            this.TxtSex.Size = new System.Drawing.Size(53, 20);
            this.TxtSex.TabIndex = 42;
            this.TxtSex.Text = "男";
            // 
            // comZJtype
            // 
            this.comZJtype.FormattingEnabled = true;
            this.comZJtype.Items.AddRange(new object[] {
            "身份证",
            "驾驶证",
            "医疗证",
            "临时身份证",
            "临时护照"});
            this.comZJtype.Location = new System.Drawing.Point(78, 58);
            this.comZJtype.Name = "comZJtype";
            this.comZJtype.Size = new System.Drawing.Size(92, 20);
            this.comZJtype.TabIndex = 43;
            this.comZJtype.Text = "身份证";
            // 
            // fmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.comZJtype);
            this.Controls.Add(this.TxtSex);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnSaveAndAdd);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.TxtUserPhone);
            this.Controls.Add(this.TxtZJNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtUserAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmAddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmAddUser";
            this.Load += new System.EventHandler(this.fmAddUser_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fmAddUser_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fmAddUser_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fmAddUser_MouseUp);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtZJNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtUserPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtUserAddress;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnSaveAndAdd;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox TxtSex;
        private System.Windows.Forms.ComboBox comZJtype;
    }
}