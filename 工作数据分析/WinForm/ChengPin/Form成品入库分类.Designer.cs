
namespace 工作数据分析.WinForm.ChengPin
{
    partial class Form成品入库分类
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvRukuMingxi = new System.Windows.Forms.DataGridView();
            this.contextMenuStripRukuMingxi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选择入库类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出明细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvGongdan = new System.Windows.Forms.DataGridView();
            this.dgvRukuJilu = new System.Windows.Forms.DataGridView();
            this.contextMenuStripRukuJilu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePickerS = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerE = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGongdan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxKehuChanpin = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRest = new System.Windows.Forms.Button();
            this.总入库数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRukuMingxi)).BeginInit();
            this.contextMenuStripRukuMingxi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGongdan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRukuJilu)).BeginInit();
            this.contextMenuStripRukuJilu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 29);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvRukuMingxi);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(772, 378);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvRukuMingxi
            // 
            this.dgvRukuMingxi.AllowUserToAddRows = false;
            this.dgvRukuMingxi.AllowUserToDeleteRows = false;
            this.dgvRukuMingxi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRukuMingxi.ContextMenuStrip = this.contextMenuStripRukuMingxi;
            this.dgvRukuMingxi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRukuMingxi.Location = new System.Drawing.Point(0, 0);
            this.dgvRukuMingxi.Name = "dgvRukuMingxi";
            this.dgvRukuMingxi.ReadOnly = true;
            this.dgvRukuMingxi.RowTemplate.Height = 23;
            this.dgvRukuMingxi.Size = new System.Drawing.Size(772, 266);
            this.dgvRukuMingxi.TabIndex = 0;
            this.dgvRukuMingxi.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRukuMingxi_CellContentDoubleClick);
            this.dgvRukuMingxi.SelectionChanged += new System.EventHandler(this.dgvRukuMingxi_SelectionChanged);
            // 
            // contextMenuStripRukuMingxi
            // 
            this.contextMenuStripRukuMingxi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择入库类型ToolStripMenuItem,
            this.导出明细ToolStripMenuItem});
            this.contextMenuStripRukuMingxi.Name = "contextMenuStrip1";
            this.contextMenuStripRukuMingxi.Size = new System.Drawing.Size(143, 48);
            // 
            // 选择入库类型ToolStripMenuItem
            // 
            this.选择入库类型ToolStripMenuItem.Name = "选择入库类型ToolStripMenuItem";
            this.选择入库类型ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.选择入库类型ToolStripMenuItem.Text = "选择入库类型";
            this.选择入库类型ToolStripMenuItem.Click += new System.EventHandler(this.选择入库类型ToolStripMenuItem_Click);
            // 
            // 导出明细ToolStripMenuItem
            // 
            this.导出明细ToolStripMenuItem.Name = "导出明细ToolStripMenuItem";
            this.导出明细ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.导出明细ToolStripMenuItem.Text = "导出明细";
            this.导出明细ToolStripMenuItem.Click += new System.EventHandler(this.导出明细ToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvGongdan);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvRukuJilu);
            this.splitContainer2.Size = new System.Drawing.Size(772, 108);
            this.splitContainer2.SplitterDistance = 394;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgvGongdan
            // 
            this.dgvGongdan.AllowUserToAddRows = false;
            this.dgvGongdan.AllowUserToDeleteRows = false;
            this.dgvGongdan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGongdan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGongdan.Location = new System.Drawing.Point(0, 0);
            this.dgvGongdan.Name = "dgvGongdan";
            this.dgvGongdan.ReadOnly = true;
            this.dgvGongdan.RowTemplate.Height = 23;
            this.dgvGongdan.Size = new System.Drawing.Size(394, 108);
            this.dgvGongdan.TabIndex = 0;
            // 
            // dgvRukuJilu
            // 
            this.dgvRukuJilu.AllowUserToAddRows = false;
            this.dgvRukuJilu.AllowUserToDeleteRows = false;
            this.dgvRukuJilu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRukuJilu.ContextMenuStrip = this.contextMenuStripRukuJilu;
            this.dgvRukuJilu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRukuJilu.Location = new System.Drawing.Point(0, 0);
            this.dgvRukuJilu.Name = "dgvRukuJilu";
            this.dgvRukuJilu.ReadOnly = true;
            this.dgvRukuJilu.RowTemplate.Height = 23;
            this.dgvRukuJilu.Size = new System.Drawing.Size(374, 108);
            this.dgvRukuJilu.TabIndex = 0;
            // 
            // contextMenuStripRukuJilu
            // 
            this.contextMenuStripRukuJilu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.总入库数ToolStripMenuItem});
            this.contextMenuStripRukuJilu.Name = "contextMenuStrip1";
            this.contextMenuStripRukuJilu.Size = new System.Drawing.Size(181, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "选择入库类型";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // dateTimePickerS
            // 
            this.dateTimePickerS.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerS.Location = new System.Drawing.Point(4, 3);
            this.dateTimePickerS.Name = "dateTimePickerS";
            this.dateTimePickerS.Size = new System.Drawing.Size(90, 21);
            this.dateTimePickerS.TabIndex = 1;
            // 
            // dateTimePickerE
            // 
            this.dateTimePickerE.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerE.Location = new System.Drawing.Point(123, 3);
            this.dateTimePickerE.Name = "dateTimePickerE";
            this.dateTimePickerE.Size = new System.Drawing.Size(90, 21);
            this.dateTimePickerE.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "工单:";
            // 
            // textBoxGongdan
            // 
            this.textBoxGongdan.Location = new System.Drawing.Point(257, 3);
            this.textBoxGongdan.Name = "textBoxGongdan";
            this.textBoxGongdan.Size = new System.Drawing.Size(102, 21);
            this.textBoxGongdan.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "客户/产品:";
            // 
            // textBoxKehuChanpin
            // 
            this.textBoxKehuChanpin.Location = new System.Drawing.Point(435, 3);
            this.textBoxKehuChanpin.Name = "textBoxKehuChanpin";
            this.textBoxKehuChanpin.Size = new System.Drawing.Size(153, 21);
            this.textBoxKehuChanpin.TabIndex = 3;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(594, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(59, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "查 询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "->";
            // 
            // buttonRest
            // 
            this.buttonRest.Location = new System.Drawing.Point(659, 3);
            this.buttonRest.Name = "buttonRest";
            this.buttonRest.Size = new System.Drawing.Size(59, 23);
            this.buttonRest.TabIndex = 6;
            this.buttonRest.Text = "重 置";
            this.buttonRest.UseVisualStyleBackColor = true;
            this.buttonRest.Click += new System.EventHandler(this.button1_Click);
            // 
            // 总入库数ToolStripMenuItem
            // 
            this.总入库数ToolStripMenuItem.Name = "总入库数ToolStripMenuItem";
            this.总入库数ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.总入库数ToolStripMenuItem.Text = "总入库数";
            this.总入库数ToolStripMenuItem.Click += new System.EventHandler(this.总入库数ToolStripMenuItem_Click);
            // 
            // Form成品入库分类
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 406);
            this.Controls.Add(this.buttonRest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxKehuChanpin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxGongdan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerE);
            this.Controls.Add(this.dateTimePickerS);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form成品入库分类";
            this.ShowIcon = false;
            this.Text = "成品分类";
            this.Load += new System.EventHandler(this.Form成品入库分类_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRukuMingxi)).EndInit();
            this.contextMenuStripRukuMingxi.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGongdan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRukuJilu)).EndInit();
            this.contextMenuStripRukuJilu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvRukuMingxi;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvGongdan;
        private System.Windows.Forms.DataGridView dgvRukuJilu;
        private System.Windows.Forms.DateTimePicker dateTimePickerS;
        private System.Windows.Forms.DateTimePicker dateTimePickerE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGongdan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxKehuChanpin;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRukuMingxi;
        private System.Windows.Forms.ToolStripMenuItem 选择入库类型ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRukuJilu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 导出明细ToolStripMenuItem;
        private System.Windows.Forms.Button buttonRest;
        private System.Windows.Forms.ToolStripMenuItem 总入库数ToolStripMenuItem;
    }
}