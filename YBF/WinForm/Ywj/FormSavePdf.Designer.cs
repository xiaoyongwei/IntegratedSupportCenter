namespace YBF.WinForm.Ywj
{
    partial class FormSavePdf
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
            this.dgvSavePdf = new System.Windows.Forms.DataGridView();
            this.ColumnFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearThisTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearAiFileList = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavePdf)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSavePdf
            // 
            this.dgvSavePdf.AllowUserToAddRows = false;
            this.dgvSavePdf.AllowUserToResizeColumns = false;
            this.dgvSavePdf.AllowUserToResizeRows = false;
            this.dgvSavePdf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSavePdf.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSavePdf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSavePdf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFileName});
            this.dgvSavePdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSavePdf.Location = new System.Drawing.Point(0, 24);
            this.dgvSavePdf.Name = "dgvSavePdf";
            this.dgvSavePdf.ReadOnly = true;
            this.dgvSavePdf.RowHeadersWidth = 20;
            this.dgvSavePdf.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSavePdf.RowTemplate.Height = 23;
            this.dgvSavePdf.Size = new System.Drawing.Size(669, 303);
            this.dgvSavePdf.TabIndex = 0;
            // 
            // ColumnFileName
            // 
            this.ColumnFileName.HeaderText = "文件名";
            this.ColumnFileName.Name = "ColumnFileName";
            this.ColumnFileName.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.tsmiClearThisTable,
            this.tsmiClearAiFileList});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(669, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.开始ToolStripMenuItem.Text = "开始转PDF";
            this.开始ToolStripMenuItem.Click += new System.EventHandler(this.开始ToolStripMenuItem_Click);
            // 
            // tsmiClearThisTable
            // 
            this.tsmiClearThisTable.Name = "tsmiClearThisTable";
            this.tsmiClearThisTable.Size = new System.Drawing.Size(77, 20);
            this.tsmiClearThisTable.Text = "清空本列表";
            this.tsmiClearThisTable.Click += new System.EventHandler(this.tsmiClearThisTable_Click);
            // 
            // tsmiClearAiFileList
            // 
            this.tsmiClearAiFileList.Name = "tsmiClearAiFileList";
            this.tsmiClearAiFileList.Size = new System.Drawing.Size(89, 20);
            this.tsmiClearAiFileList.Text = "清空后台列表";
            this.tsmiClearAiFileList.Click += new System.EventHandler(this.tsmiClearSavePdfList_Click);
            // 
            // FormSavePdf
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 327);
            this.Controls.Add(this.dgvSavePdf);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormSavePdf";
            this.ShowIcon = false;
            this.Text = "转PDF";
            this.Load += new System.EventHandler(this.FormSavePdf_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormSavePdf_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormSavePdf_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavePdf)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSavePdf;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileName;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearThisTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearAiFileList;
    }
}