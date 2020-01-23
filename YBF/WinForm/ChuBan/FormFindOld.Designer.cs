namespace YBF.WinForm.ChuBan
{
    partial class FormFindOld
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvExcel = new System.Windows.Forms.DataGridView();
            this.listViewFile = new System.Windows.Forms.ListView();
            this.columnHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGoto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxKeyword = new System.Windows.Forms.ComboBox();
            this.checkBoxSize = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).BeginInit();
            this.contextMenuStripListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(513, 6);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "查  询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 37);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvExcel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewFile);
            this.splitContainer1.Size = new System.Drawing.Size(646, 434);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvExcel
            // 
            this.dgvExcel.AllowUserToAddRows = false;
            this.dgvExcel.AllowUserToDeleteRows = false;
            this.dgvExcel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvExcel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExcel.Location = new System.Drawing.Point(0, 0);
            this.dgvExcel.Name = "dgvExcel";
            this.dgvExcel.RowHeadersVisible = false;
            this.dgvExcel.RowTemplate.Height = 23;
            this.dgvExcel.Size = new System.Drawing.Size(646, 255);
            this.dgvExcel.TabIndex = 0;
            // 
            // listViewFile
            // 
            this.listViewFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFileName,
            this.columnHeaderLastTime,
            this.columnHeaderSize,
            this.columnHeaderPath});
            this.listViewFile.ContextMenuStrip = this.contextMenuStripListView;
            this.listViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFile.Location = new System.Drawing.Point(0, 0);
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Size = new System.Drawing.Size(646, 171);
            this.listViewFile.TabIndex = 0;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Details;
            this.listViewFile.ItemActivate += new System.EventHandler(this.listViewFile_ItemActivate);
            this.listViewFile.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewFile_ItemDrag);
            // 
            // columnHeaderFileName
            // 
            this.columnHeaderFileName.Text = "文件名";
            // 
            // columnHeaderLastTime
            // 
            this.columnHeaderLastTime.Text = "修改日期";
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "大小";
            // 
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "所在目录";
            // 
            // contextMenuStripListView
            // 
            this.contextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiGoto,
            this.tsmiTransfer});
            this.contextMenuStripListView.Name = "contextMenuStripListView";
            this.contextMenuStripListView.Size = new System.Drawing.Size(95, 70);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(94, 22);
            this.tsmiOpen.Text = "打开";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiGoto
            // 
            this.tsmiGoto.Name = "tsmiGoto";
            this.tsmiGoto.Size = new System.Drawing.Size(94, 22);
            this.tsmiGoto.Text = "定位";
            this.tsmiGoto.Click += new System.EventHandler(this.tsmiGoto_Click);
            // 
            // tsmiTransfer
            // 
            this.tsmiTransfer.Enabled = false;
            this.tsmiTransfer.Name = "tsmiTransfer";
            this.tsmiTransfer.Size = new System.Drawing.Size(94, 22);
            this.tsmiTransfer.Text = "调取";
            this.tsmiTransfer.Click += new System.EventHandler(this.tsmiTransfer_Click);
            // 
            // comboBoxKeyword
            // 
            this.comboBoxKeyword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxKeyword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxKeyword.FormattingEnabled = true;
            this.comboBoxKeyword.Location = new System.Drawing.Point(1, 9);
            this.comboBoxKeyword.MaxDropDownItems = 20;
            this.comboBoxKeyword.Name = "comboBoxKeyword";
            this.comboBoxKeyword.Size = new System.Drawing.Size(506, 20);
            this.comboBoxKeyword.TabIndex = 0;
            this.comboBoxKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxKeyword_KeyDown);
            // 
            // checkBoxSize
            // 
            this.checkBoxSize.AutoSize = true;
            this.checkBoxSize.Location = new System.Drawing.Point(594, 11);
            this.checkBoxSize.Name = "checkBoxSize";
            this.checkBoxSize.Size = new System.Drawing.Size(60, 16);
            this.checkBoxSize.TabIndex = 3;
            this.checkBoxSize.Text = "按尺寸";
            this.checkBoxSize.UseVisualStyleBackColor = true;
            // 
            // FormFindOld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 473);
            this.Controls.Add(this.checkBoxSize);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.comboBoxKeyword);
            this.Name = "FormFindOld";
            this.ShowIcon = false;
            this.Text = "找旧版";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFindOld_FormClosed);
            this.Load += new System.EventHandler(this.FormFindOld_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).EndInit();
            this.contextMenuStripListView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvExcel;
        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.ColumnHeader columnHeaderFileName;
        private System.Windows.Forms.ColumnHeader columnHeaderLastTime;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ComboBox comboBoxKeyword;
        private System.Windows.Forms.ColumnHeader columnHeaderPath;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListView;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiGoto;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransfer;
        private System.Windows.Forms.CheckBox checkBoxSize;

    }
}