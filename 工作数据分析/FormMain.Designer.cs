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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.成品仓库ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 成品仓库ToolStripMenuItem
            // 
            this.成品仓库ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.入库明细ToolStripMenuItem,
            this.入库分类ToolStripMenuItem});
            this.成品仓库ToolStripMenuItem.Name = "成品仓库ToolStripMenuItem";
            this.成品仓库ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.成品仓库ToolStripMenuItem.Text = "成品仓库";
            // 
            // 入库明细ToolStripMenuItem
            // 
            this.入库明细ToolStripMenuItem.Name = "入库明细ToolStripMenuItem";
            this.入库明细ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.入库明细ToolStripMenuItem.Text = "入库明细";
            // 
            // 入库分类ToolStripMenuItem
            // 
            this.入库分类ToolStripMenuItem.Name = "入库分类ToolStripMenuItem";
            this.入库分类ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.入库分类ToolStripMenuItem.Text = "入库分类";
            this.入库分类ToolStripMenuItem.Click += new System.EventHandler(this.入库分类ToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
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
    }
}