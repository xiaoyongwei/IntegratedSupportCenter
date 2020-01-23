namespace 工作数据
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.基础数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.每日数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物料管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.汇总报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.每日数据汇总ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.每日数据汇总图表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物料管理汇总ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基础数据ToolStripMenuItem,
            this.汇总报表ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(750, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 基础数据ToolStripMenuItem
            // 
            this.基础数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.每日数据ToolStripMenuItem,
            this.物料管理ToolStripMenuItem});
            this.基础数据ToolStripMenuItem.Name = "基础数据ToolStripMenuItem";
            this.基础数据ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.基础数据ToolStripMenuItem.Text = "基础数据";
            this.基础数据ToolStripMenuItem.Click += new System.EventHandler(this.基础数据ToolStripMenuItem_Click);
            // 
            // 每日数据ToolStripMenuItem
            // 
            this.每日数据ToolStripMenuItem.Name = "每日数据ToolStripMenuItem";
            this.每日数据ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.每日数据ToolStripMenuItem.Text = "每日数据";
            this.每日数据ToolStripMenuItem.Click += new System.EventHandler(this.每日数据ToolStripMenuItem_Click);
            // 
            // 物料管理ToolStripMenuItem
            // 
            this.物料管理ToolStripMenuItem.Name = "物料管理ToolStripMenuItem";
            this.物料管理ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.物料管理ToolStripMenuItem.Text = "物料管理";
            this.物料管理ToolStripMenuItem.Click += new System.EventHandler(this.物料管理ToolStripMenuItem_Click);
            // 
            // 汇总报表ToolStripMenuItem
            // 
            this.汇总报表ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.每日数据汇总ToolStripMenuItem,
            this.每日数据汇总图表ToolStripMenuItem,
            this.物料管理汇总ToolStripMenuItem});
            this.汇总报表ToolStripMenuItem.Name = "汇总报表ToolStripMenuItem";
            this.汇总报表ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.汇总报表ToolStripMenuItem.Text = "汇总报表";
            // 
            // 每日数据汇总ToolStripMenuItem
            // 
            this.每日数据汇总ToolStripMenuItem.Name = "每日数据汇总ToolStripMenuItem";
            this.每日数据汇总ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.每日数据汇总ToolStripMenuItem.Text = "每日数据汇总";
            this.每日数据汇总ToolStripMenuItem.Click += new System.EventHandler(this.每日数据汇总ToolStripMenuItem_Click);
            // 
            // 每日数据汇总图表ToolStripMenuItem
            // 
            this.每日数据汇总图表ToolStripMenuItem.Name = "每日数据汇总图表ToolStripMenuItem";
            this.每日数据汇总图表ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.每日数据汇总图表ToolStripMenuItem.Text = "每日数据汇总_图表";
            this.每日数据汇总图表ToolStripMenuItem.Click += new System.EventHandler(this.每日数据汇总图表ToolStripMenuItem_Click);
            // 
            // 物料管理汇总ToolStripMenuItem
            // 
            this.物料管理汇总ToolStripMenuItem.Name = "物料管理汇总ToolStripMenuItem";
            this.物料管理汇总ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.物料管理汇总ToolStripMenuItem.Text = "物料价格更新";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 457);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "工作数据";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 基础数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 每日数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 物料管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 汇总报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 每日数据汇总ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 物料管理汇总ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 每日数据汇总图表ToolStripMenuItem;
    }
}

