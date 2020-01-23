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
            this.添加报货ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当日报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加报货ToolStripMenuItem,
            this.当日报表ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1002, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 添加报货ToolStripMenuItem
            // 
            this.添加报货ToolStripMenuItem.Name = "添加报货ToolStripMenuItem";
            this.添加报货ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.添加报货ToolStripMenuItem.Text = "添加报货";
            this.添加报货ToolStripMenuItem.Click += new System.EventHandler(this.添加报货ToolStripMenuItem_Click);
            // 
            // 当日报表ToolStripMenuItem
            // 
            this.当日报表ToolStripMenuItem.Name = "当日报表ToolStripMenuItem";
            this.当日报表ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.当日报表ToolStripMenuItem.Text = "当日报表";
            this.当日报表ToolStripMenuItem.Click += new System.EventHandler(this.当日报表ToolStripMenuItem_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgv.Location = new System.Drawing.Point(0, 25);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(1002, 559);
            this.dgv.TabIndex = 2;
            // 
            // Form物流Mian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 584);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form物流Mian";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "物流";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form物流Mian_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加报货ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当日报表ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv;

    }
}