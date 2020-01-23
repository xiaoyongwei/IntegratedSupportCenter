namespace 工作数据分析.WinForm.物流
{
    partial class Form发货通知单Add
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ColumnKehu = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnGongdanhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSonghuoshuliang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSonghuodidian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChanpinzhuangtai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnXuyaofahuoshijian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShijifahuoshijian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBeizhu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.报货人ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstbBaohuoren = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.报货时间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstbBaohuoshijian = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnKehu,
            this.ColumnGongdanhao,
            this.ColumnSonghuoshuliang,
            this.ColumnSonghuodidian,
            this.ColumnChanpinzhuangtai,
            this.ColumnXuyaofahuoshijian,
            this.ColumnShijifahuoshijian,
            this.ColumnBeizhu});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 25);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(954, 336);
            this.dgv.TabIndex = 0;
            // 
            // ColumnKehu
            // 
            this.ColumnKehu.HeaderText = "客户";
            this.ColumnKehu.Name = "ColumnKehu";
            // 
            // ColumnGongdanhao
            // 
            this.ColumnGongdanhao.HeaderText = "工单号";
            this.ColumnGongdanhao.Name = "ColumnGongdanhao";
            // 
            // ColumnSonghuoshuliang
            // 
            this.ColumnSonghuoshuliang.HeaderText = "送货数量";
            this.ColumnSonghuoshuliang.Name = "ColumnSonghuoshuliang";
            // 
            // ColumnSonghuodidian
            // 
            this.ColumnSonghuodidian.HeaderText = "送货地点";
            this.ColumnSonghuodidian.Name = "ColumnSonghuodidian";
            // 
            // ColumnChanpinzhuangtai
            // 
            this.ColumnChanpinzhuangtai.HeaderText = "产品状态";
            this.ColumnChanpinzhuangtai.Name = "ColumnChanpinzhuangtai";
            // 
            // ColumnXuyaofahuoshijian
            // 
            this.ColumnXuyaofahuoshijian.HeaderText = "需要发货时间";
            this.ColumnXuyaofahuoshijian.Name = "ColumnXuyaofahuoshijian";
            // 
            // ColumnShijifahuoshijian
            // 
            this.ColumnShijifahuoshijian.HeaderText = "实际发货时间";
            this.ColumnShijifahuoshijian.Name = "ColumnShijifahuoshijian";
            // 
            // ColumnBeizhu
            // 
            this.ColumnBeizhu.HeaderText = "备注";
            this.ColumnBeizhu.Name = "ColumnBeizhu";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.报货人ToolStripMenuItem,
            this.tstbBaohuoren,
            this.toolStripMenuItem2,
            this.报货时间ToolStripMenuItem,
            this.tstbBaohuoshijian,
            this.toolStripMenuItem1,
            this.保存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(954, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(23, 21);
            this.toolStripMenuItem1.Text = "|";
            // 
            // 报货人ToolStripMenuItem
            // 
            this.报货人ToolStripMenuItem.Name = "报货人ToolStripMenuItem";
            this.报货人ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.报货人ToolStripMenuItem.Text = "报货人:";
            // 
            // tstbBaohuoren
            // 
            this.tstbBaohuoren.Name = "tstbBaohuoren";
            this.tstbBaohuoren.Size = new System.Drawing.Size(110, 21);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(23, 21);
            this.toolStripMenuItem2.Text = "|";
            // 
            // 报货时间ToolStripMenuItem
            // 
            this.报货时间ToolStripMenuItem.Name = "报货时间ToolStripMenuItem";
            this.报货时间ToolStripMenuItem.Size = new System.Drawing.Size(71, 21);
            this.报货时间ToolStripMenuItem.Text = "报货时间:";
            // 
            // tstbBaohuoshijian
            // 
            this.tstbBaohuoshijian.Name = "tstbBaohuoshijian";
            this.tstbBaohuoshijian.Size = new System.Drawing.Size(160, 21);
            // 
            // Form发货通知单Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 361);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form发货通知单Add";
            this.Text = "Form发货通知单Add";
            this.Load += new System.EventHandler(this.Form发货通知单Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnKehu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGongdanhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSonghuoshuliang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSonghuodidian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChanpinzhuangtai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnXuyaofahuoshijian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShijifahuoshijian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBeizhu;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 报货人ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tstbBaohuoren;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 报货时间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tstbBaohuoshijian;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}