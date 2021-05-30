namespace 外购对账审核
{
    partial class FormDuizhangbiao
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_dgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选择类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加到对账簿ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从对账簿移除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输入工单号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.金蝶入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.金蝶入库取消ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.提取工单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.彩盒工单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.checkBoxJingque = new System.Windows.Forms.CheckBox();
            this.comboBoxDuizhang = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_duizhang = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_dgvDuizhang = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.输入工单号ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.金蝶入库确认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.金蝶入库取消ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelgongji = new System.Windows.Forms.Label();
            this.checkBoxShuaxin = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip_dgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_duizhang)).BeginInit();
            this.contextMenuStrip_dgvDuizhang.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.ContextMenuStrip = this.contextMenuStrip_dgv;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(846, 351);
            this.dgv.TabIndex = 0;
            this.dgv.DataSourceChanged += new System.EventHandler(this.dgv_DataSourceChanged);
            // 
            // contextMenuStrip_dgv
            // 
            this.contextMenuStrip_dgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择类型ToolStripMenuItem,
            this.添加到对账簿ToolStripMenuItem,
            this.从对账簿移除ToolStripMenuItem,
            this.输入工单号ToolStripMenuItem,
            this.金蝶入库ToolStripMenuItem,
            this.金蝶入库取消ToolStripMenuItem,
            this.提取工单ToolStripMenuItem,
            this.刷新ToolStripMenuItem1});
            this.contextMenuStrip_dgv.Name = "contextMenuStrip1";
            this.contextMenuStrip_dgv.Size = new System.Drawing.Size(170, 180);
            // 
            // 选择类型ToolStripMenuItem
            // 
            this.选择类型ToolStripMenuItem.Name = "选择类型ToolStripMenuItem";
            this.选择类型ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.选择类型ToolStripMenuItem.Text = "选择类型(F8)";
            this.选择类型ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 添加到对账簿ToolStripMenuItem
            // 
            this.添加到对账簿ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.添加到对账簿ToolStripMenuItem.Name = "添加到对账簿ToolStripMenuItem";
            this.添加到对账簿ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.添加到对账簿ToolStripMenuItem.Text = "添加到对账簿(F1)";
            this.添加到对账簿ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 从对账簿移除ToolStripMenuItem
            // 
            this.从对账簿移除ToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.从对账簿移除ToolStripMenuItem.Name = "从对账簿移除ToolStripMenuItem";
            this.从对账簿移除ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.从对账簿移除ToolStripMenuItem.Text = "从对账簿移除(F2)";
            this.从对账簿移除ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 输入工单号ToolStripMenuItem
            // 
            this.输入工单号ToolStripMenuItem.Name = "输入工单号ToolStripMenuItem";
            this.输入工单号ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.输入工单号ToolStripMenuItem.Text = "输入工单号";
            this.输入工单号ToolStripMenuItem.Click += new System.EventHandler(this.输入工单号ToolStripMenuItem_Click);
            // 
            // 金蝶入库ToolStripMenuItem
            // 
            this.金蝶入库ToolStripMenuItem.Enabled = false;
            this.金蝶入库ToolStripMenuItem.Name = "金蝶入库ToolStripMenuItem";
            this.金蝶入库ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.金蝶入库ToolStripMenuItem.Text = "金蝶入库-确认";
            this.金蝶入库ToolStripMenuItem.Click += new System.EventHandler(this.金蝶入库ToolStripMenuItem_Click);
            // 
            // 金蝶入库取消ToolStripMenuItem
            // 
            this.金蝶入库取消ToolStripMenuItem.Enabled = false;
            this.金蝶入库取消ToolStripMenuItem.Name = "金蝶入库取消ToolStripMenuItem";
            this.金蝶入库取消ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.金蝶入库取消ToolStripMenuItem.Text = "金蝶入库-取消";
            this.金蝶入库取消ToolStripMenuItem.Click += new System.EventHandler(this.金蝶入库取消ToolStripMenuItem_Click);
            // 
            // 提取工单ToolStripMenuItem
            // 
            this.提取工单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.彩盒工单ToolStripMenuItem});
            this.提取工单ToolStripMenuItem.Name = "提取工单ToolStripMenuItem";
            this.提取工单ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.提取工单ToolStripMenuItem.Text = "提取工单";
            // 
            // 彩盒工单ToolStripMenuItem
            // 
            this.彩盒工单ToolStripMenuItem.Name = "彩盒工单ToolStripMenuItem";
            this.彩盒工单ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.彩盒工单ToolStripMenuItem.Text = "彩盒工单";
            this.彩盒工单ToolStripMenuItem.Click += new System.EventHandler(this.彩盒工单ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem1
            // 
            this.刷新ToolStripMenuItem1.Name = "刷新ToolStripMenuItem1";
            this.刷新ToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.刷新ToolStripMenuItem1.Text = "刷新";
            this.刷新ToolStripMenuItem1.Click += new System.EventHandler(this.刷新ToolStripMenuItem1_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(83, 3);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(194, 21);
            this.textBoxSearch.TabIndex = 3;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(283, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "查  询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.tsmiSearch_Click);
            // 
            // checkBoxJingque
            // 
            this.checkBoxJingque.AutoSize = true;
            this.checkBoxJingque.Location = new System.Drawing.Point(5, 6);
            this.checkBoxJingque.Name = "checkBoxJingque";
            this.checkBoxJingque.Size = new System.Drawing.Size(72, 16);
            this.checkBoxJingque.TabIndex = 5;
            this.checkBoxJingque.Text = "精确查找";
            this.checkBoxJingque.UseVisualStyleBackColor = true;
            // 
            // comboBoxDuizhang
            // 
            this.comboBoxDuizhang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDuizhang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.comboBoxDuizhang.FormattingEnabled = true;
            this.comboBoxDuizhang.Location = new System.Drawing.Point(364, 5);
            this.comboBoxDuizhang.Name = "comboBoxDuizhang";
            this.comboBoxDuizhang.Size = new System.Drawing.Size(140, 20);
            this.comboBoxDuizhang.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 30);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_duizhang);
            this.splitContainer1.Size = new System.Drawing.Size(846, 461);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.TabIndex = 7;
            // 
            // dgv_duizhang
            // 
            this.dgv_duizhang.AllowUserToAddRows = false;
            this.dgv_duizhang.AllowUserToDeleteRows = false;
            this.dgv_duizhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_duizhang.ContextMenuStrip = this.contextMenuStrip_dgvDuizhang;
            this.dgv_duizhang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_duizhang.Location = new System.Drawing.Point(0, 0);
            this.dgv_duizhang.Name = "dgv_duizhang";
            this.dgv_duizhang.ReadOnly = true;
            this.dgv_duizhang.Size = new System.Drawing.Size(846, 106);
            this.dgv_duizhang.TabIndex = 0;
            // 
            // contextMenuStrip_dgvDuizhang
            // 
            this.contextMenuStrip_dgvDuizhang.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.输入工单号ToolStripMenuItem1,
            this.金蝶入库确认ToolStripMenuItem,
            this.金蝶入库取消ToolStripMenuItem1,
            this.toolStripMenuItem4,
            this.刷新ToolStripMenuItem});
            this.contextMenuStrip_dgvDuizhang.Name = "contextMenuStrip1";
            this.contextMenuStrip_dgvDuizhang.Size = new System.Drawing.Size(181, 202);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "选择类型(F8)";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Red;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "添加到对账簿(F1)";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.Blue;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "从对账簿移除(F2)";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // 输入工单号ToolStripMenuItem1
            // 
            this.输入工单号ToolStripMenuItem1.Name = "输入工单号ToolStripMenuItem1";
            this.输入工单号ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.输入工单号ToolStripMenuItem1.Text = "输入工单号";
            this.输入工单号ToolStripMenuItem1.Click += new System.EventHandler(this.输入工单号ToolStripMenuItem1_Click);
            // 
            // 金蝶入库确认ToolStripMenuItem
            // 
            this.金蝶入库确认ToolStripMenuItem.Name = "金蝶入库确认ToolStripMenuItem";
            this.金蝶入库确认ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.金蝶入库确认ToolStripMenuItem.Text = "金蝶入库-确认";
            this.金蝶入库确认ToolStripMenuItem.Click += new System.EventHandler(this.金蝶入库确认ToolStripMenuItem_Click);
            // 
            // 金蝶入库取消ToolStripMenuItem1
            // 
            this.金蝶入库取消ToolStripMenuItem1.Name = "金蝶入库取消ToolStripMenuItem1";
            this.金蝶入库取消ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.金蝶入库取消ToolStripMenuItem1.Text = "金蝶入库-取消";
            this.金蝶入库取消ToolStripMenuItem1.Click += new System.EventHandler(this.金蝶入库取消ToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "提取工单";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = "彩盒工单";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // labelgongji
            // 
            this.labelgongji.AutoSize = true;
            this.labelgongji.Location = new System.Drawing.Point(511, 10);
            this.labelgongji.Name = "labelgongji";
            this.labelgongji.Size = new System.Drawing.Size(0, 12);
            this.labelgongji.TabIndex = 8;
            // 
            // checkBoxShuaxin
            // 
            this.checkBoxShuaxin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShuaxin.AutoSize = true;
            this.checkBoxShuaxin.Checked = true;
            this.checkBoxShuaxin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShuaxin.Location = new System.Drawing.Point(765, 8);
            this.checkBoxShuaxin.Name = "checkBoxShuaxin";
            this.checkBoxShuaxin.Size = new System.Drawing.Size(72, 16);
            this.checkBoxShuaxin.TabIndex = 9;
            this.checkBoxShuaxin.Text = "自动更新";
            this.checkBoxShuaxin.UseVisualStyleBackColor = true;
            // 
            // FormDuizhangbiao
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 493);
            this.Controls.Add(this.checkBoxShuaxin);
            this.Controls.Add(this.labelgongji);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.comboBoxDuizhang);
            this.Controls.Add(this.checkBoxJingque);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Name = "FormDuizhangbiao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "对账表";
            this.Load += new System.EventHandler(this.FormDuizhangbiao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.contextMenuStrip_dgv.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_duizhang)).EndInit();
            this.contextMenuStrip_dgvDuizhang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_dgv;
        private System.Windows.Forms.ToolStripMenuItem 选择类型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加到对账簿ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.CheckBox checkBoxJingque;
        private System.Windows.Forms.ComboBox comboBoxDuizhang;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_duizhang;
        private System.Windows.Forms.ToolStripMenuItem 从对账簿移除ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_dgvDuizhang;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Label labelgongji;
        private System.Windows.Forms.ToolStripMenuItem 输入工单号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输入工单号ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 金蝶入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 金蝶入库取消ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 金蝶入库确认ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 金蝶入库取消ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 提取工单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 彩盒工单ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxShuaxin;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
    }
}