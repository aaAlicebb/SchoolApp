namespace Hotel.UI
{
    partial class UCRoom
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCRoom));
            this.lbRoonId = new System.Windows.Forms.Label();
            this.lbRoomType = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.修改登记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客人留言ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.置空净房ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结账退房ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改房态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.置空净房ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.改为预定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRoonId
            // 
            this.lbRoonId.AutoSize = true;
            this.lbRoonId.BackColor = System.Drawing.Color.Transparent;
            this.lbRoonId.ForeColor = System.Drawing.Color.Black;
            this.lbRoonId.Location = new System.Drawing.Point(16, 8);
            this.lbRoonId.Name = "lbRoonId";
            this.lbRoonId.Size = new System.Drawing.Size(41, 12);
            this.lbRoonId.TabIndex = 0;
            this.lbRoonId.Text = "label1";
            this.lbRoonId.Click += new System.EventHandler(this.lbRoonId_Click);
            this.lbRoonId.Leave += new System.EventHandler(this.UCRoom_Leave);
            this.lbRoonId.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCRoom_MouseClick);
            this.lbRoonId.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UCRoom_MouseDoubleClick);
            this.lbRoonId.MouseEnter += new System.EventHandler(this.lbENter);
            this.lbRoonId.MouseLeave += new System.EventHandler(this.lbLeve);
            this.lbRoonId.MouseHover += new System.EventHandler(this.UCRoom_MouseHover);
            // 
            // lbRoomType
            // 
            this.lbRoomType.AutoSize = true;
            this.lbRoomType.BackColor = System.Drawing.Color.Transparent;
            this.lbRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRoomType.ForeColor = System.Drawing.Color.Black;
            this.lbRoomType.Location = new System.Drawing.Point(15, 20);
            this.lbRoomType.Name = "lbRoomType";
            this.lbRoomType.Size = new System.Drawing.Size(46, 18);
            this.lbRoomType.TabIndex = 1;
            this.lbRoomType.Text = "label1";
            this.lbRoomType.Leave += new System.EventHandler(this.UCRoom_Leave);
            this.lbRoomType.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCRoom_MouseClick);
            this.lbRoomType.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UCRoom_MouseDoubleClick);
            this.lbRoomType.MouseEnter += new System.EventHandler(this.lbENter);
            this.lbRoomType.MouseLeave += new System.EventHandler(this.lbLeve);
            this.lbRoomType.MouseHover += new System.EventHandler(this.UCRoom_MouseHover);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.contextMenuStrip1.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.修改登记ToolStripMenuItem,
            this.客人留言ToolStripMenuItem,
            this.置空净房ToolStripMenuItem,
            this.结账退房ToolStripMenuItem,
            this.修改房态ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 224);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.toolStripMenuItem2.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem2.Text = "客人预订（&Y）";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.toolStripMenuItem3.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem3.Text = "客人登记（&D）";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.toolStripMenuItem4.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem4.Text = "消费入单（&X）";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem5.Image")));
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem5.Text = "更换房间（&E）";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // 修改登记ToolStripMenuItem
            // 
            this.修改登记ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("修改登记ToolStripMenuItem.Image")));
            this.修改登记ToolStripMenuItem.Name = "修改登记ToolStripMenuItem";
            this.修改登记ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.修改登记ToolStripMenuItem.Text = "修改登记（&U）";
            this.修改登记ToolStripMenuItem.Click += new System.EventHandler(this.修改登记ToolStripMenuItem_Click);
            // 
            // 客人留言ToolStripMenuItem
            // 
            this.客人留言ToolStripMenuItem.Name = "客人留言ToolStripMenuItem";
            this.客人留言ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.客人留言ToolStripMenuItem.Text = "客人留言";
            // 
            // 置空净房ToolStripMenuItem
            // 
            this.置空净房ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("置空净房ToolStripMenuItem.Image")));
            this.置空净房ToolStripMenuItem.Name = "置空净房ToolStripMenuItem";
            this.置空净房ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.置空净房ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.置空净房ToolStripMenuItem.Text = "置空净房（&C）";
            this.置空净房ToolStripMenuItem.Click += new System.EventHandler(this.置空净房ToolStripMenuItem_Click);
            // 
            // 结账退房ToolStripMenuItem
            // 
            this.结账退房ToolStripMenuItem.Name = "结账退房ToolStripMenuItem";
            this.结账退房ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.结账退房ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.结账退房ToolStripMenuItem.Text = "结账退房（&V）";
            this.结账退房ToolStripMenuItem.Click += new System.EventHandler(this.结账退房ToolStripMenuItem_Click);
            // 
            // 修改房态ToolStripMenuItem
            // 
            this.修改房态ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.置空净房ToolStripMenuItem1,
            this.改为预定ToolStripMenuItem});
            this.修改房态ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("修改房态ToolStripMenuItem.Image")));
            this.修改房态ToolStripMenuItem.Name = "修改房态ToolStripMenuItem";
            this.修改房态ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.修改房态ToolStripMenuItem.Text = "修改房态（&M）";
            // 
            // 置空净房ToolStripMenuItem1
            // 
            this.置空净房ToolStripMenuItem1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.置空净房ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("置空净房ToolStripMenuItem1.Image")));
            this.置空净房ToolStripMenuItem1.Name = "置空净房ToolStripMenuItem1";
            this.置空净房ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.置空净房ToolStripMenuItem1.Text = "置空净房";
            this.置空净房ToolStripMenuItem1.Click += new System.EventHandler(this.置空净房ToolStripMenuItem1_Click);
            // 
            // 改为预定ToolStripMenuItem
            // 
            this.改为预定ToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.改为预定ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("改为预定ToolStripMenuItem.Image")));
            this.改为预定ToolStripMenuItem.Name = "改为预定ToolStripMenuItem";
            this.改为预定ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.改为预定ToolStripMenuItem.Text = "改为预定";
            this.改为预定ToolStripMenuItem.Click += new System.EventHandler(this.改为预定ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(55, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 14);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // UCRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbRoomType);
            this.Controls.Add(this.lbRoonId);
            this.DoubleBuffered = true;
            this.Name = "UCRoom";
            this.Size = new System.Drawing.Size(75, 46);
            this.Load += new System.EventHandler(this.UCRoom_Load);
            this.Leave += new System.EventHandler(this.UCRoom_Leave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCRoom_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UCRoom_MouseDoubleClick);
            this.MouseEnter += new System.EventHandler(this.UCRoom_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UCRoom_MouseLeave);
            this.MouseHover += new System.EventHandler(this.UCRoom_MouseHover);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbRoonId;
        public System.Windows.Forms.Label lbRoomType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem 修改登记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 置空净房ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结账退房ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改房态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 置空净房ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 客人留言ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 改为预定ToolStripMenuItem;
    }
}
