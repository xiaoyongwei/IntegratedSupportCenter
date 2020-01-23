namespace YBF.WinForm.ChuBan
{
    partial class FormChuBan
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
            this.dgvJob = new System.Windows.Forms.DataGridView();
            this.contextMenuStripJob = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiStatistics1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBaoBiao1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSearchFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiInit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewExcel = new System.Windows.Forms.TreeView();
            this.contextMenuStripExcel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBaoBiao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectAllNode = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJob)).BeginInit();
            this.contextMenuStripJob.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStripExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvJob
            // 
            this.dgvJob.AllowUserToAddRows = false;
            this.dgvJob.AllowUserToDeleteRows = false;
            this.dgvJob.AllowUserToResizeRows = false;
            this.dgvJob.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJob.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJob.ContextMenuStrip = this.contextMenuStripJob;
            this.dgvJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJob.Location = new System.Drawing.Point(0, 0);
            this.dgvJob.Name = "dgvJob";
            this.dgvJob.ReadOnly = true;
            this.dgvJob.RowHeadersVisible = false;
            this.dgvJob.RowTemplate.Height = 23;
            this.dgvJob.Size = new System.Drawing.Size(510, 502);
            this.dgvJob.TabIndex = 0;
            // 
            // contextMenuStripJob
            // 
            this.contextMenuStripJob.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStatistics1,
            this.tsmiBaoBiao1,
            this.tsmiSearchFile});
            this.contextMenuStripJob.Name = "contextMenuStrip1";
            this.contextMenuStripJob.Size = new System.Drawing.Size(153, 92);
            // 
            // tsmiStatistics1
            // 
            this.tsmiStatistics1.Name = "tsmiStatistics1";
            this.tsmiStatistics1.Size = new System.Drawing.Size(152, 22);
            this.tsmiStatistics1.Text = "统计数量";
            this.tsmiStatistics1.Click += new System.EventHandler(this.tsmiStatistics1_Click);
            // 
            // tsmiBaoBiao1
            // 
            this.tsmiBaoBiao1.Name = "tsmiBaoBiao1";
            this.tsmiBaoBiao1.Size = new System.Drawing.Size(152, 22);
            this.tsmiBaoBiao1.Text = "报表";
            this.tsmiBaoBiao1.Click += new System.EventHandler(this.tsmiBaoBiao1_Click);
            // 
            // tsmiSearchFile
            // 
            this.tsmiSearchFile.Name = "tsmiSearchFile";
            this.tsmiSearchFile.Size = new System.Drawing.Size(152, 22);
            this.tsmiSearchFile.Text = "找文件";
            this.tsmiSearchFile.Click += new System.EventHandler(this.tsmiSearchFile_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInit,
            this.tsmiShow});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiInit
            // 
            this.tsmiInit.Name = "tsmiInit";
            this.tsmiInit.Size = new System.Drawing.Size(56, 21);
            this.tsmiInit.Text = "初始化";
            this.tsmiInit.Click += new System.EventHandler(this.tsmiInit_Click);
            // 
            // tsmiShow
            // 
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(44, 21);
            this.tsmiShow.Text = "查询";
            this.tsmiShow.Click += new System.EventHandler(this.tsmiShow_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewExcel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvJob);
            this.splitContainer1.Size = new System.Drawing.Size(639, 502);
            this.splitContainer1.SplitterDistance = 125;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeViewExcel
            // 
            this.treeViewExcel.CheckBoxes = true;
            this.treeViewExcel.ContextMenuStrip = this.contextMenuStripExcel;
            this.treeViewExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewExcel.Location = new System.Drawing.Point(0, 0);
            this.treeViewExcel.Name = "treeViewExcel";
            this.treeViewExcel.ShowPlusMinus = false;
            this.treeViewExcel.ShowRootLines = false;
            this.treeViewExcel.Size = new System.Drawing.Size(125, 502);
            this.treeViewExcel.TabIndex = 0;
            this.treeViewExcel.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewExcel_NodeMouseDoubleClick);
            // 
            // contextMenuStripExcel
            // 
            this.contextMenuStripExcel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStatistics,
            this.tsmiBaoBiao,
            this.tsmiSelectAllNode});
            this.contextMenuStripExcel.Name = "contextMenuStripExcel";
            this.contextMenuStripExcel.Size = new System.Drawing.Size(125, 70);
            // 
            // tsmiStatistics
            // 
            this.tsmiStatistics.Name = "tsmiStatistics";
            this.tsmiStatistics.Size = new System.Drawing.Size(124, 22);
            this.tsmiStatistics.Text = "统计数量";
            this.tsmiStatistics.Click += new System.EventHandler(this.tsmiStatistics_Click);
            // 
            // tsmiBaoBiao
            // 
            this.tsmiBaoBiao.Name = "tsmiBaoBiao";
            this.tsmiBaoBiao.Size = new System.Drawing.Size(124, 22);
            this.tsmiBaoBiao.Text = "报表";
            this.tsmiBaoBiao.Click += new System.EventHandler(this.tsmiBaoBiao_Click);
            // 
            // tsmiSelectAllNode
            // 
            this.tsmiSelectAllNode.Name = "tsmiSelectAllNode";
            this.tsmiSelectAllNode.Size = new System.Drawing.Size(124, 22);
            this.tsmiSelectAllNode.Text = "全选";
            this.tsmiSelectAllNode.Click += new System.EventHandler(this.tsmiSelectAllNode_Click);
            // 
            // FormChuBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 527);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormChuBan";
            this.ShowIcon = false;
            this.Text = "出版";
            this.Load += new System.EventHandler(this.FormChuBan_Load);
            this.SizeChanged += new System.EventHandler(this.FormChuBan_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJob)).EndInit();
            this.contextMenuStripJob.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStripExcel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJob;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiInit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewExcel;
        private System.Windows.Forms.ToolStripMenuItem tsmiShow;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripJob;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearchFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripExcel;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatistics;
        private System.Windows.Forms.ToolStripMenuItem tsmiBaoBiao;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatistics1;
        private System.Windows.Forms.ToolStripMenuItem tsmiBaoBiao1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAllNode;
    }
}