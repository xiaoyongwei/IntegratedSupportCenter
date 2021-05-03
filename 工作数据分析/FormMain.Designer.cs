namespace 工作数据分析
{
    partial class FormMain
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
            this.成品仓库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.入库明细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.入库分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.纸板管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.成品仓库ToolStripMenuItem,
            this.纸板管理ToolStripMenuItem,
            this.数据导入ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 成品仓库ToolStripMenuItem
            // 
            this.成品仓库ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.入库明细ToolStripMenuItem,
            this.入库分类ToolStripMenuItem});
            this.成品仓库ToolStripMenuItem.Name = "成品仓库ToolStripMenuItem";
            this.成品仓库ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.成品仓库ToolStripMenuItem.Text = "成品仓库";
            this.成品仓库ToolStripMenuItem.Click += new System.EventHandler(this.成品仓库ToolStripMenuItem_Click);
            // 
            // 入库明细ToolStripMenuItem
            // 
            this.入库明细ToolStripMenuItem.Name = "入库明细ToolStripMenuItem";
            this.入库明细ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.入库明细ToolStripMenuItem.Text = "入库明细";
            this.入库明细ToolStripMenuItem.Click += new System.EventHandler(this.入库明细ToolStripMenuItem_Click);
            // 
            // 入库分类ToolStripMenuItem
            // 
            this.入库分类ToolStripMenuItem.Name = "入库分类ToolStripMenuItem";
            this.入库分类ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.入库分类ToolStripMenuItem.Text = "入库分类";
            this.入库分类ToolStripMenuItem.Click += new System.EventHandler(this.入库分类ToolStripMenuItem_Click);
            // 
            // 纸板管理ToolStripMenuItem
            // 
            this.纸板管理ToolStripMenuItem.Name = "纸板管理ToolStripMenuItem";
            this.纸板管理ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.纸板管理ToolStripMenuItem.Text = "纸板管理";
            // 
            // 数据导入ToolStripMenuItem
            // 
            this.数据导入ToolStripMenuItem.Name = "数据导入ToolStripMenuItem";
            this.数据导入ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.数据导入ToolStripMenuItem.Text = "数据导入";
            this.数据导入ToolStripMenuItem.Click += new System.EventHandler(this.数据导入ToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "工作数据分析";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 成品仓库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 入库明细ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 入库分类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 纸板管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据导入ToolStripMenuItem;
    }
}