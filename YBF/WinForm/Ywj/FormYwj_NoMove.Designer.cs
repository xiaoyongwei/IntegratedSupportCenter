namespace YBF.WinForm.Ywj
{
    partial class FormYwj_NoMove
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
            this.listViewFile = new System.Windows.Forms.ListView();
            this.columnHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOrther = new System.Windows.Forms.ToolStripMenuItem();
            this.timsiMarkCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.checkBoxPublished = new System.Windows.Forms.CheckBox();
            this.tsmiCopyAndConvertToPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewFile
            // 
            this.listViewFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFileName,
            this.columnHeaderLastTime,
            this.columnHeaderSize,
            this.columnHeaderPath});
            this.listViewFile.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewFile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewFile.Location = new System.Drawing.Point(0, 27);
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Size = new System.Drawing.Size(667, 324);
            this.listViewFile.TabIndex = 1;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Details;
            this.listViewFile.ItemActivate += new System.EventHandler(this.listViewYwj_ItemActivate);
            // 
            // columnHeaderFileName
            // 
            this.columnHeaderFileName.Text = "文件名称";
            this.columnHeaderFileName.Width = 313;
            // 
            // columnHeaderLastTime
            // 
            this.columnHeaderLastTime.Text = "最后修改日期";
            this.columnHeaderLastTime.Width = 140;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "大小";
            // 
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "CTP";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopy,
            this.tsmiCopyAndConvertToPDF,
            this.tsmiOrther});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 92);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.BackColor = System.Drawing.Color.Cyan;
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(127, 22);
            this.tsmiCopy.Text = "拷贝";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // tsmiOrther
            // 
            this.tsmiOrther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timsiMarkCopy});
            this.tsmiOrther.Name = "tsmiOrther";
            this.tsmiOrther.Size = new System.Drawing.Size(127, 22);
            this.tsmiOrther.Text = "其他";
            // 
            // timsiMarkCopy
            // 
            this.timsiMarkCopy.Name = "timsiMarkCopy";
            this.timsiMarkCopy.Size = new System.Drawing.Size(154, 22);
            this.timsiMarkCopy.Text = "标记为\"已拷贝\"";
            this.timsiMarkCopy.Click += new System.EventHandler(this.timsiMarkCopy_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.Location = new System.Drawing.Point(2, 2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(587, 21);
            this.textBoxSearch.TabIndex = 2;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // checkBoxPublished
            // 
            this.checkBoxPublished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxPublished.AutoSize = true;
            this.checkBoxPublished.Location = new System.Drawing.Point(595, 7);
            this.checkBoxPublished.Name = "checkBoxPublished";
            this.checkBoxPublished.Size = new System.Drawing.Size(60, 16);
            this.checkBoxPublished.TabIndex = 3;
            this.checkBoxPublished.Text = "已出版";
            this.checkBoxPublished.UseVisualStyleBackColor = true;
            this.checkBoxPublished.CheckedChanged += new System.EventHandler(this.checkBoxPublished_CheckedChanged);
            // 
            // tsmiCopyAndConvertToPDF
            // 
            this.tsmiCopyAndConvertToPDF.Name = "tsmiCopyAndConvertToPDF";
            this.tsmiCopyAndConvertToPDF.Size = new System.Drawing.Size(127, 22);
            this.tsmiCopyAndConvertToPDF.Text = "拷贝并转存PDF";
            this.tsmiCopyAndConvertToPDF.Click += new System.EventHandler(this.tsmiCopyAndConvertToPDF_Click);
            // 
            // FormYwj_NoMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 351);
            this.Controls.Add(this.checkBoxPublished);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.listViewFile);
            this.Name = "FormYwj_NoMove";
            this.ShowIcon = false;
            this.Text = "原文件";
            this.Load += new System.EventHandler(this.FormYwj_NoMove_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.ColumnHeader columnHeaderFileName;
        private System.Windows.Forms.ColumnHeader columnHeaderLastTime;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ColumnHeader columnHeaderPath;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrther;
        private System.Windows.Forms.ToolStripMenuItem timsiMarkCopy;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.CheckBox checkBoxPublished;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyAndConvertToPDF;
    }
}