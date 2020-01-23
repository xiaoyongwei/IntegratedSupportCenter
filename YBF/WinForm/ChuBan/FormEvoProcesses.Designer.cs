namespace YBF.WinForm.ChuBan
{
    partial class FormEvoProcesses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvEvoProcess = new System.Windows.Forms.DataGridView();
            this.cms_Evo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTongji = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvTifFile = new System.Windows.Forms.DataGridView();
            this.cmd_Tif = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTifTongji = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvoProcess)).BeginInit();
            this.cms_Evo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTifFile)).BeginInit();
            this.cmd_Tif.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvEvoProcess);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvTifFile);
            this.splitContainer1.Size = new System.Drawing.Size(688, 323);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgvEvoProcess
            // 
            this.dgvEvoProcess.AllowUserToAddRows = false;
            this.dgvEvoProcess.AllowUserToDeleteRows = false;
            this.dgvEvoProcess.AllowUserToResizeColumns = false;
            this.dgvEvoProcess.AllowUserToResizeRows = false;
            this.dgvEvoProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvoProcess.ContextMenuStrip = this.cms_Evo;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEvoProcess.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEvoProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvoProcess.Location = new System.Drawing.Point(0, 0);
            this.dgvEvoProcess.Name = "dgvEvoProcess";
            this.dgvEvoProcess.ReadOnly = true;
            this.dgvEvoProcess.RowHeadersVisible = false;
            this.dgvEvoProcess.RowTemplate.Height = 23;
            this.dgvEvoProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvoProcess.Size = new System.Drawing.Size(688, 202);
            this.dgvEvoProcess.TabIndex = 0;
            // 
            // cms_Evo
            // 
            this.cms_Evo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTongji});
            this.cms_Evo.Name = "contextMenuStrip1";
            this.cms_Evo.Size = new System.Drawing.Size(95, 26);
            // 
            // tsmiTongji
            // 
            this.tsmiTongji.Name = "tsmiTongji";
            this.tsmiTongji.Size = new System.Drawing.Size(94, 22);
            this.tsmiTongji.Text = "统计";
            this.tsmiTongji.Click += new System.EventHandler(this.tsmiTongji_Click);
            // 
            // dgvTifFile
            // 
            this.dgvTifFile.AllowUserToAddRows = false;
            this.dgvTifFile.AllowUserToDeleteRows = false;
            this.dgvTifFile.AllowUserToResizeColumns = false;
            this.dgvTifFile.AllowUserToResizeRows = false;
            this.dgvTifFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTifFile.ContextMenuStrip = this.cmd_Tif;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTifFile.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTifFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTifFile.Location = new System.Drawing.Point(0, 0);
            this.dgvTifFile.Name = "dgvTifFile";
            this.dgvTifFile.ReadOnly = true;
            this.dgvTifFile.RowHeadersVisible = false;
            this.dgvTifFile.RowTemplate.Height = 23;
            this.dgvTifFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTifFile.Size = new System.Drawing.Size(688, 117);
            this.dgvTifFile.TabIndex = 1;
            // 
            // cmd_Tif
            // 
            this.cmd_Tif.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTifTongji});
            this.cmd_Tif.Name = "contextMenuStrip1";
            this.cmd_Tif.Size = new System.Drawing.Size(95, 26);
            // 
            // tsmiTifTongji
            // 
            this.tsmiTifTongji.Name = "tsmiTifTongji";
            this.tsmiTifTongji.Size = new System.Drawing.Size(94, 22);
            this.tsmiTifTongji.Text = "统计";
            this.tsmiTifTongji.Click += new System.EventHandler(this.tsmiTifTongji_Click);
            // 
            // FormEvoProcesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 323);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.Name = "FormEvoProcesses";
            this.ShowIcon = false;
            this.Text = "印能捷出版记录";
            this.Load += new System.EventHandler(this.FormEvoProcesses_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvoProcess)).EndInit();
            this.cms_Evo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTifFile)).EndInit();
            this.cmd_Tif.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvEvoProcess;
        private System.Windows.Forms.DataGridView dgvTifFile;
        private System.Windows.Forms.ContextMenuStrip cms_Evo;
        private System.Windows.Forms.ToolStripMenuItem tsmiTongji;
        private System.Windows.Forms.ContextMenuStrip cmd_Tif;
        private System.Windows.Forms.ToolStripMenuItem tsmiTifTongji;
    }
}