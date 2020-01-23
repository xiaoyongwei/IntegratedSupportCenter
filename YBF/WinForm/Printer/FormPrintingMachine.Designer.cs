namespace YBF.WinForm.Printer
{
    partial class FormPrintingMachine
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReload = new System.Windows.Forms.ToolStripMenuItem();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.机台 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PS版材 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.咬口外角线 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最大过纸 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最大印刷 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最小过纸 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最小印刷 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.启用 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.自动出版提交路径 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.机台,
            this.PS版材,
            this.咬口外角线,
            this.最大过纸,
            this.最大印刷,
            this.最小过纸,
            this.最小印刷,
            this.启用,
            this.备注,
            this.自动出版提交路径});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 24);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(657, 283);
            this.dgv.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiUpdate,
            this.tsmiDelete,
            this.tsmiReload});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(657, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(41, 20);
            this.tsmiAdd.Text = "添加";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(41, 20);
            this.tsmiUpdate.Text = "修改";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(41, 20);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiReload
            // 
            this.tsmiReload.Name = "tsmiReload";
            this.tsmiReload.Size = new System.Drawing.Size(65, 20);
            this.tsmiReload.Text = "重新加载";
            this.tsmiReload.Click += new System.EventHandler(this.tsmiReload_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 42;
            // 
            // 机台
            // 
            this.机台.DataPropertyName = "机台";
            this.机台.HeaderText = "机台";
            this.机台.Name = "机台";
            this.机台.ReadOnly = true;
            this.机台.Width = 54;
            // 
            // PS版材
            // 
            this.PS版材.DataPropertyName = "PS版材";
            this.PS版材.HeaderText = "PS版材";
            this.PS版材.Name = "PS版材";
            this.PS版材.ReadOnly = true;
            this.PS版材.Width = 66;
            // 
            // 咬口外角线
            // 
            this.咬口外角线.DataPropertyName = "咬口外角线";
            this.咬口外角线.HeaderText = "咬口外角线";
            this.咬口外角线.Name = "咬口外角线";
            this.咬口外角线.ReadOnly = true;
            this.咬口外角线.Width = 90;
            // 
            // 最大过纸
            // 
            this.最大过纸.DataPropertyName = "最大过纸";
            this.最大过纸.HeaderText = "最大过纸";
            this.最大过纸.Name = "最大过纸";
            this.最大过纸.ReadOnly = true;
            this.最大过纸.Width = 78;
            // 
            // 最大印刷
            // 
            this.最大印刷.DataPropertyName = "最大印刷";
            this.最大印刷.HeaderText = "最大印刷";
            this.最大印刷.Name = "最大印刷";
            this.最大印刷.ReadOnly = true;
            this.最大印刷.Width = 78;
            // 
            // 最小过纸
            // 
            this.最小过纸.DataPropertyName = "最小过纸";
            this.最小过纸.HeaderText = "最小过纸";
            this.最小过纸.Name = "最小过纸";
            this.最小过纸.ReadOnly = true;
            this.最小过纸.Width = 78;
            // 
            // 最小印刷
            // 
            this.最小印刷.DataPropertyName = "最小印刷";
            this.最小印刷.HeaderText = "最小印刷";
            this.最小印刷.Name = "最小印刷";
            this.最小印刷.ReadOnly = true;
            this.最小印刷.Width = 78;
            // 
            // 启用
            // 
            this.启用.DataPropertyName = "启用";
            this.启用.FalseValue = "0";
            this.启用.HeaderText = "启用";
            this.启用.IndeterminateValue = "0";
            this.启用.Name = "启用";
            this.启用.ReadOnly = true;
            this.启用.TrueValue = "1";
            this.启用.Width = 35;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "备注";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.ReadOnly = true;
            this.备注.Width = 54;
            // 
            // 自动出版提交路径
            // 
            this.自动出版提交路径.DataPropertyName = "自动出版提交路径";
            this.自动出版提交路径.HeaderText = "自动出版提交路径";
            this.自动出版提交路径.Name = "自动出版提交路径";
            this.自动出版提交路径.ReadOnly = true;
            this.自动出版提交路径.Width = 83;
            // 
            // FormPrintingMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 307);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrintingMachine";
            this.ShowIcon = false;
            this.Text = "印刷机";
            this.Load += new System.EventHandler(this.FormPrintingMachine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiReload;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 机台;
        private System.Windows.Forms.DataGridViewTextBoxColumn PS版材;
        private System.Windows.Forms.DataGridViewTextBoxColumn 咬口外角线;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最大过纸;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最大印刷;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最小过纸;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最小印刷;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 启用;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.DataGridViewTextBoxColumn 自动出版提交路径;
    }
}