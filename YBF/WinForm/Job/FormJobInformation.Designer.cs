namespace YBF.WinForm.Job
{
    partial class FormJobInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJobInformation));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTimeNow = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewSelect = new System.Windows.Forms.ListView();
            this.关联的文件 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.印版类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.印版数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.颜色 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.咬口印能捷 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.下料尺寸 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.制造尺寸 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.文件名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客户名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.机台 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.稿袋号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.报废 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.出版 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.暂停 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.从易捷导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopy});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(99, 22);
            this.tsmiCopy.Text = "复制信息";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.tsmiExit,
            this.tsmiClear,
            this.tsmiImport,
            this.tsmiTimeNow,
            this.从易捷导入ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1220, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSave.Image")));
            this.tsmiSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(75, 21);
            this.tsmiSave.Text = "保存(&S)";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(84, 21);
            this.tsmiExit.Text = "直接退出(&X)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiClear
            // 
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(44, 21);
            this.tsmiClear.Text = "清空";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(73, 21);
            this.tsmiImport.Text = "导入Excel";
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
            // 
            // tsmiTimeNow
            // 
            this.tsmiTimeNow.Name = "tsmiTimeNow";
            this.tsmiTimeNow.Size = new System.Drawing.Size(116, 21);
            this.tsmiTimeNow.Text = "全部改为现在时间";
            this.tsmiTimeNow.Click += new System.EventHandler(this.tsmiTimeNow_Click);
            // 
            // listViewSelect
            // 
            this.listViewSelect.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listViewSelect.FullRowSelect = true;
            this.listViewSelect.GridLines = true;
            this.listViewSelect.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.listViewSelect.Location = new System.Drawing.Point(284, 133);
            this.listViewSelect.MultiSelect = false;
            this.listViewSelect.Name = "listViewSelect";
            this.listViewSelect.ShowGroups = false;
            this.listViewSelect.Size = new System.Drawing.Size(77, 128);
            this.listViewSelect.TabIndex = 4;
            this.listViewSelect.UseCompatibleStateImageBehavior = false;
            this.listViewSelect.View = System.Windows.Forms.View.List;
            this.listViewSelect.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listViewSelect.VisibleChanged += new System.EventHandler(this.listViewSelect_VisibleChanged);
            this.listViewSelect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listViewSelect_KeyPress);
            // 
            // 关联的文件
            // 
            this.关联的文件.DataPropertyName = "关联的文件";
            this.关联的文件.HeaderText = "关联的文件";
            this.关联的文件.Name = "关联的文件";
            this.关联的文件.Width = 90;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "备注";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.Width = 54;
            // 
            // 印版类型
            // 
            this.印版类型.DataPropertyName = "印版类型";
            this.印版类型.HeaderText = "印版类型";
            this.印版类型.Name = "印版类型";
            this.印版类型.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.印版类型.Width = 78;
            // 
            // 印版数量
            // 
            this.印版数量.DataPropertyName = "印版数量";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.印版数量.DefaultCellStyle = dataGridViewCellStyle3;
            this.印版数量.HeaderText = "印版数量";
            this.印版数量.Name = "印版数量";
            this.印版数量.Width = 78;
            // 
            // 颜色
            // 
            this.颜色.DataPropertyName = "颜色";
            this.颜色.HeaderText = "颜色";
            this.颜色.Name = "颜色";
            this.颜色.Width = 54;
            // 
            // 咬口印能捷
            // 
            this.咬口印能捷.DataPropertyName = "咬口印能捷";
            this.咬口印能捷.HeaderText = "咬口印能捷";
            this.咬口印能捷.Name = "咬口印能捷";
            this.咬口印能捷.Width = 90;
            // 
            // 下料尺寸
            // 
            this.下料尺寸.DataPropertyName = "下料尺寸";
            this.下料尺寸.HeaderText = "下料尺寸";
            this.下料尺寸.Name = "下料尺寸";
            this.下料尺寸.Width = 78;
            // 
            // 制造尺寸
            // 
            this.制造尺寸.DataPropertyName = "制造尺寸";
            this.制造尺寸.HeaderText = "制造尺寸";
            this.制造尺寸.Name = "制造尺寸";
            this.制造尺寸.Width = 78;
            // 
            // 文件名
            // 
            this.文件名.DataPropertyName = "文件名";
            this.文件名.HeaderText = "文件名";
            this.文件名.Name = "文件名";
            this.文件名.Width = 66;
            // 
            // 客户名
            // 
            this.客户名.DataPropertyName = "客户名";
            this.客户名.HeaderText = "客户名";
            this.客户名.Name = "客户名";
            this.客户名.Width = 66;
            // 
            // 机台
            // 
            this.机台.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.机台.DataPropertyName = "机台";
            this.机台.HeaderText = "机台";
            this.机台.Name = "机台";
            this.机台.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.机台.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.机台.Width = 35;
            // 
            // 稿袋号
            // 
            this.稿袋号.DataPropertyName = "稿袋号";
            this.稿袋号.HeaderText = "稿袋号";
            this.稿袋号.Name = "稿袋号";
            this.稿袋号.Width = 66;
            // 
            // 工单号
            // 
            this.工单号.DataPropertyName = "工单号";
            this.工单号.HeaderText = "工单号";
            this.工单号.Name = "工单号";
            this.工单号.Width = 66;
            // 
            // 报废
            // 
            this.报废.DataPropertyName = "报废";
            this.报废.HeaderText = "报废";
            this.报废.Name = "报废";
            this.报废.Width = 35;
            // 
            // 出版
            // 
            this.出版.DataPropertyName = "出版";
            this.出版.HeaderText = "出版";
            this.出版.Name = "出版";
            this.出版.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.出版.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.出版.Width = 54;
            // 
            // 暂停
            // 
            this.暂停.DataPropertyName = "暂停";
            this.暂停.HeaderText = "暂停";
            this.暂停.Name = "暂停";
            this.暂停.Width = 35;
            // 
            // 时间
            // 
            this.时间.DataPropertyName = "时间";
            this.时间.HeaderText = "时间";
            this.时间.Name = "时间";
            this.时间.Width = 54;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 42;
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.时间,
            this.暂停,
            this.出版,
            this.报废,
            this.工单号,
            this.稿袋号,
            this.机台,
            this.客户名,
            this.文件名,
            this.制造尺寸,
            this.下料尺寸,
            this.咬口印能捷,
            this.颜色,
            this.印版数量,
            this.印版类型,
            this.备注,
            this.关联的文件});
            this.dgv.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv.Location = new System.Drawing.Point(0, 25);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(1220, 408);
            this.dgv.TabIndex = 3;
            this.dgv.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellLeave);
            this.dgv.CurrentCellChanged += new System.EventHandler(this.dgv_CurrentCellChanged);
            this.dgv.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_DefaultValuesNeeded);
            this.dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
            // 
            // 从易捷导入ToolStripMenuItem
            // 
            this.从易捷导入ToolStripMenuItem.Name = "从易捷导入ToolStripMenuItem";
            this.从易捷导入ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.从易捷导入ToolStripMenuItem.Text = "从易捷导入";
            this.从易捷导入ToolStripMenuItem.Click += new System.EventHandler(this.从易捷导入ToolStripMenuItem_Click);
            // 
            // FormJobInformation
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 433);
            this.Controls.Add(this.listViewSelect);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormJobInformation";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加和修改作业";
            this.Load += new System.EventHandler(this.FormJobInformation_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormJobAdd_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormJobAdd_DragEnter);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
        private System.Windows.Forms.ListView listViewSelect;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.DataGridViewTextBoxColumn 关联的文件;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.DataGridViewTextBoxColumn 印版类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 印版数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 颜色;
        private System.Windows.Forms.DataGridViewTextBoxColumn 咬口印能捷;
        private System.Windows.Forms.DataGridViewTextBoxColumn 下料尺寸;
        private System.Windows.Forms.DataGridViewTextBoxColumn 制造尺寸;
        private System.Windows.Forms.DataGridViewTextBoxColumn 文件名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 机台;
        private System.Windows.Forms.DataGridViewTextBoxColumn 稿袋号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工单号;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 报废;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 出版;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 暂停;
        private System.Windows.Forms.DataGridViewTextBoxColumn 时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ToolStripMenuItem tsmiTimeNow;
        private System.Windows.Forms.ToolStripMenuItem 从易捷导入ToolStripMenuItem;

    }
}