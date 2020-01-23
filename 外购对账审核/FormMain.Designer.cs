namespace 外购对账审核
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
            this.数据维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账簿分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.对账表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.其它ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.金蝶未入库明细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据维护ToolStripMenuItem,
            this.账簿分类ToolStripMenuItem,
            this.对账表ToolStripMenuItem,
            this.其它ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(683, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 数据维护ToolStripMenuItem
            // 
            this.数据维护ToolStripMenuItem.Name = "数据维护ToolStripMenuItem";
            this.数据维护ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据维护ToolStripMenuItem.Text = "类型维护";
            this.数据维护ToolStripMenuItem.Click += new System.EventHandler(this.数据维护ToolStripMenuItem_Click);
            // 
            // 账簿分类ToolStripMenuItem
            // 
            this.账簿分类ToolStripMenuItem.Name = "账簿分类ToolStripMenuItem";
            this.账簿分类ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.账簿分类ToolStripMenuItem.Text = "账簿维护";
            this.账簿分类ToolStripMenuItem.Click += new System.EventHandler(this.账簿分类ToolStripMenuItem_Click);
            // 
            // 对账表ToolStripMenuItem
            // 
            this.对账表ToolStripMenuItem.Name = "对账表ToolStripMenuItem";
            this.对账表ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.对账表ToolStripMenuItem.Text = "对账表";
            this.对账表ToolStripMenuItem.Click += new System.EventHandler(this.对账表ToolStripMenuItem_Click);
            // 
            // 其它ToolStripMenuItem
            // 
            this.其它ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.金蝶未入库明细ToolStripMenuItem});
            this.其它ToolStripMenuItem.Name = "其它ToolStripMenuItem";
            this.其它ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.其它ToolStripMenuItem.Text = "其它";
            // 
            // 金蝶未入库明细ToolStripMenuItem
            // 
            this.金蝶未入库明细ToolStripMenuItem.Name = "金蝶未入库明细ToolStripMenuItem";
            this.金蝶未入库明细ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.金蝶未入库明细ToolStripMenuItem.Text = "金蝶未入库明细";
            this.金蝶未入库明细ToolStripMenuItem.Click += new System.EventHandler(this.金蝶未入库明细ToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 532);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "外购对账审核";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 数据维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 对账表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 账簿分类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其它ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 金蝶未入库明细ToolStripMenuItem;
    }
}

