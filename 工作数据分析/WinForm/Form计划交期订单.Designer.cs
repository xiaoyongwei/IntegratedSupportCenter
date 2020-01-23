namespace 工作数据分析.WinForm
{
    partial class Form计划交期订单
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form计划交期订单));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewDate = new System.Windows.Forms.TreeView();
            this.imageListSelected = new System.Windows.Forms.ImageList(this.components);
            this.dgv = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看报工情况ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看工序情况ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改交期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.交期锁定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.交期反锁定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewDate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv);
            this.splitContainer1.Size = new System.Drawing.Size(771, 465);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewDate
            // 
            this.treeViewDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDate.ImageIndex = 0;
            this.treeViewDate.ImageList = this.imageListSelected;
            this.treeViewDate.Location = new System.Drawing.Point(0, 0);
            this.treeViewDate.Name = "treeViewDate";
            this.treeViewDate.SelectedImageIndex = 1;
            this.treeViewDate.ShowLines = false;
            this.treeViewDate.Size = new System.Drawing.Size(93, 465);
            this.treeViewDate.TabIndex = 0;
            this.treeViewDate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDate_AfterSelect);
            // 
            // imageListSelected
            // 
            this.imageListSelected.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSelected.ImageStream")));
            this.imageListSelected.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSelected.Images.SetKeyName(0, "蓝色方块.png");
            this.imageListSelected.Images.SetKeyName(1, "红色方块.png");
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(674, 465);
            this.dgv.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看报工情况ToolStripMenuItem,
            this.查看工序情况ToolStripMenuItem,
            this.修改交期ToolStripMenuItem,
            this.交期锁定ToolStripMenuItem,
            this.交期反锁定ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 114);
            // 
            // 查看报工情况ToolStripMenuItem
            // 
            this.查看报工情况ToolStripMenuItem.Name = "查看报工情况ToolStripMenuItem";
            this.查看报工情况ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查看报工情况ToolStripMenuItem.Text = "查看报工情况";
            this.查看报工情况ToolStripMenuItem.Click += new System.EventHandler(this.查看报工情况ToolStripMenuItem_Click);
            // 
            // 查看工序情况ToolStripMenuItem
            // 
            this.查看工序情况ToolStripMenuItem.Name = "查看工序情况ToolStripMenuItem";
            this.查看工序情况ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查看工序情况ToolStripMenuItem.Text = "查看工序情况";
            this.查看工序情况ToolStripMenuItem.Click += new System.EventHandler(this.查看工序情况ToolStripMenuItem_Click);
            // 
            // 修改交期ToolStripMenuItem
            // 
            this.修改交期ToolStripMenuItem.Name = "修改交期ToolStripMenuItem";
            this.修改交期ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改交期ToolStripMenuItem.Text = "修改交期";
            // 
            // 交期锁定ToolStripMenuItem
            // 
            this.交期锁定ToolStripMenuItem.Name = "交期锁定ToolStripMenuItem";
            this.交期锁定ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.交期锁定ToolStripMenuItem.Text = "交期锁定";
            // 
            // 交期反锁定ToolStripMenuItem
            // 
            this.交期反锁定ToolStripMenuItem.Name = "交期反锁定ToolStripMenuItem";
            this.交期反锁定ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.交期反锁定ToolStripMenuItem.Text = "交期反锁定";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(771, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form计划交期订单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 489);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form计划交期订单";
            this.ShowIcon = false;
            this.Text = "计划交期订单";
            this.Load += new System.EventHandler(this.Form计划交期订单_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewDate;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查看报工情况ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看工序情况ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改交期ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 交期锁定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 交期反锁定ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListSelected;
    }
}