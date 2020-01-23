namespace 工作数据分析.WinForm.WuLiu
{
    partial class Form添加报货
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
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ColumnKehu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGongdanhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSonghuoshuliang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSonghuodidian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChanpinzhuangtai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnXuyaofahuoshijian = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnShijidaohuoshijian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBeizhu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBaohuoshijian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBaohuoren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFahuoren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem,
            this.清空ToolStripMenuItem,
            this.关闭ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1035, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.清空ToolStripMenuItem.Text = "清空";
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关闭ToolStripMenuItem.Text = "关闭";
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
            this.ColumnShijidaohuoshijian,
            this.ColumnBeizhu,
            this.ColumnBaohuoshijian,
            this.ColumnBaohuoren,
            this.ColumnFahuoren});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv.Location = new System.Drawing.Point(0, 25);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(1035, 426);
            this.dgv.TabIndex = 1;
            this.dgv.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_DefaultValuesNeeded);
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
            // ColumnShijidaohuoshijian
            // 
            this.ColumnShijidaohuoshijian.HeaderText = "实际到货时间";
            this.ColumnShijidaohuoshijian.Name = "ColumnShijidaohuoshijian";
            // 
            // ColumnBeizhu
            // 
            this.ColumnBeizhu.HeaderText = "备注";
            this.ColumnBeizhu.Name = "ColumnBeizhu";
            // 
            // ColumnBaohuoshijian
            // 
            this.ColumnBaohuoshijian.HeaderText = "报货时间";
            this.ColumnBaohuoshijian.Name = "ColumnBaohuoshijian";
            // 
            // ColumnBaohuoren
            // 
            this.ColumnBaohuoren.HeaderText = "报货人";
            this.ColumnBaohuoren.Name = "ColumnBaohuoren";
            // 
            // ColumnFahuoren
            // 
            this.ColumnFahuoren.HeaderText = "发货人";
            this.ColumnFahuoren.Name = "ColumnFahuoren";
            // 
            // Form添加报货
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 451);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form添加报货";
            this.Text = "添加报货";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKehu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGongdanhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSonghuoshuliang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSonghuodidian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChanpinzhuangtai;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnXuyaofahuoshijian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShijidaohuoshijian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBeizhu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBaohuoshijian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBaohuoren;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFahuoren;
    }
}