namespace 工作数据分析.WinForm
{
    partial class Form筛选弹窗
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
            this.ColumnLuoji = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.columnZiduan = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnTiaojian = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnZhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.确定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLuoji,
            this.columnZiduan,
            this.ColumnTiaojian,
            this.ColumnZhi});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv.Location = new System.Drawing.Point(0, 24);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(610, 354);
            this.dgv.TabIndex = 0;
            this.dgv.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_DefaultValuesNeeded);
            // 
            // ColumnLuoji
            // 
            this.ColumnLuoji.HeaderText = "逻辑";
            this.ColumnLuoji.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.ColumnLuoji.Name = "ColumnLuoji";
            // 
            // columnZiduan
            // 
            this.columnZiduan.HeaderText = "字段";
            this.columnZiduan.Name = "columnZiduan";
            // 
            // ColumnTiaojian
            // 
            this.ColumnTiaojian.HeaderText = "条件";
            this.ColumnTiaojian.Items.AddRange(new object[] {
            "等于",
            "不等于",
            "包含",
            "不包含",
            "开头是",
            "开头不是",
            "结尾是",
            "结尾不是",
            "大于",
            "小于",
            "大于等于",
            "小于等于"});
            this.ColumnTiaojian.Name = "ColumnTiaojian";
            // 
            // ColumnZhi
            // 
            this.ColumnZhi.HeaderText = "值";
            this.ColumnZhi.Name = "ColumnZhi";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.确定ToolStripMenuItem,
            this.清空ToolStripMenuItem,
            this.关闭ToolStripMenuItem,
            this.删除行ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(610, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 确定ToolStripMenuItem
            // 
            this.确定ToolStripMenuItem.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.确定ToolStripMenuItem.Name = "确定ToolStripMenuItem";
            this.确定ToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.确定ToolStripMenuItem.Text = "确定";
            this.确定ToolStripMenuItem.Click += new System.EventHandler(this.确定ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Font = new System.Drawing.Font("幼圆", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // 删除行ToolStripMenuItem
            // 
            this.删除行ToolStripMenuItem.Name = "删除行ToolStripMenuItem";
            this.删除行ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.删除行ToolStripMenuItem.Text = "删除行(-)";
            this.删除行ToolStripMenuItem.Click += new System.EventHandler(this.删除行ToolStripMenuItem_Click);
            // 
            // Form筛选弹窗
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 378);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form筛选弹窗";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form筛选弹窗";
            this.Load += new System.EventHandler(this.Form筛选弹窗_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 确定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除行ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnLuoji;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnZiduan;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnTiaojian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnZhi;
    }
}