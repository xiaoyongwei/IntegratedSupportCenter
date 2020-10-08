namespace 综合保障中心.其它
{
    partial class FormYijie_自动获取
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.一键获取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerBackup = new System.Windows.Forms.Timer(this.components);
            this.timerClr = new System.Windows.Forms.Timer(this.components);
            this.tbShow = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.一键获取ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 25);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 一键获取ToolStripMenuItem
            // 
            this.一键获取ToolStripMenuItem.Name = "一键获取ToolStripMenuItem";
            this.一键获取ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.一键获取ToolStripMenuItem.Text = "一键获取";
            this.一键获取ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem一键获取_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 543);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(434, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // timerBackup
            // 
            this.timerBackup.Enabled = true;
            this.timerBackup.Interval = 1800000;
            this.timerBackup.Tag = "自动备份";
            // 
            // timerClr
            // 
            this.timerClr.Enabled = true;
            this.timerClr.Interval = 172800000;
            this.timerClr.Tag = "清除文本框";
            this.timerClr.Tick += new System.EventHandler(this.timerClr_Tick);
            // 
            // tbShow
            // 
            this.tbShow.BackColor = System.Drawing.SystemColors.Window;
            this.tbShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbShow.Location = new System.Drawing.Point(0, 25);
            this.tbShow.Multiline = true;
            this.tbShow.Name = "tbShow";
            this.tbShow.ReadOnly = true;
            this.tbShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbShow.Size = new System.Drawing.Size(434, 518);
            this.tbShow.TabIndex = 12;
            // 
            // FormYijie_自动获取
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 565);
            this.Controls.Add(this.tbShow);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormYijie_自动获取";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据自动获取";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormYijie_自动获取_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timerBackup;
        private System.Windows.Forms.Timer timerClr;
        private System.Windows.Forms.ToolStripMenuItem 一键获取ToolStripMenuItem;
        private System.Windows.Forms.TextBox tbShow;
    }
}