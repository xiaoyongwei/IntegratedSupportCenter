namespace 工作数据分析.WinForm.WuLiu
{
    partial class Form物流Mian
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.回单管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运费结算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.回单管理ToolStripMenuItem,
            this.运费结算ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1002, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 回单管理ToolStripMenuItem
            // 
            this.回单管理ToolStripMenuItem.Name = "回单管理ToolStripMenuItem";
            this.回单管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.回单管理ToolStripMenuItem.Text = "回单管理";
            this.回单管理ToolStripMenuItem.Click += new System.EventHandler(this.回单管理ToolStripMenuItem_Click);
            // 
            // 运费结算ToolStripMenuItem
            // 
            this.运费结算ToolStripMenuItem.Name = "运费结算ToolStripMenuItem";
            this.运费结算ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.运费结算ToolStripMenuItem.Text = "运费结算";
            this.运费结算ToolStripMenuItem.Click += new System.EventHandler(this.运费结算ToolStripMenuItem_Click);
            // 
            // Form物流Mian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 584);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "Form物流Mian";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "物流";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 回单管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运费结算ToolStripMenuItem;
    }
}