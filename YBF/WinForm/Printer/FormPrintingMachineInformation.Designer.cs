namespace YBF.WinForm.Printer
{
    partial class FormPrintingMachineInformation
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
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.机台 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PS版材 = new System.Windows.Forms.DataGridViewComboBoxColumn();
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
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv.Location = new System.Drawing.Point(0, 24);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(833, 351);
            this.dgv.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.tsmiExit,
            this.tsmiClear});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(833, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(41, 20);
            this.tsmiSave.Text = "保存";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(65, 20);
            this.tsmiExit.Text = "直接退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiClear
            // 
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(41, 20);
            this.tsmiClear.Text = "清空";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 42;
            // 
            // 机台
            // 
            this.机台.DataPropertyName = "机台";
            this.机台.HeaderText = "机台";
            this.机台.Name = "机台";
            this.机台.Width = 54;
            // 
            // PS版材
            // 
            this.PS版材.DataPropertyName = "PS版材";
            this.PS版材.HeaderText = "PS版材";
            this.PS版材.Name = "PS版材";
            this.PS版材.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PS版材.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PS版材.Width = 66;
            // 
            // 咬口外角线
            // 
            this.咬口外角线.DataPropertyName = "咬口外角线";
            this.咬口外角线.HeaderText = "咬口外角线";
            this.咬口外角线.Name = "咬口外角线";
            this.咬口外角线.Width = 90;
            // 
            // 最大过纸
            // 
            this.最大过纸.DataPropertyName = "最大过纸";
            this.最大过纸.HeaderText = "最大过纸";
            this.最大过纸.Name = "最大过纸";
            this.最大过纸.Width = 78;
            // 
            // 最大印刷
            // 
            this.最大印刷.DataPropertyName = "最大印刷";
            this.最大印刷.HeaderText = "最大印刷";
            this.最大印刷.Name = "最大印刷";
            this.最大印刷.Width = 78;
            // 
            // 最小过纸
            // 
            this.最小过纸.DataPropertyName = "最小过纸";
            this.最小过纸.HeaderText = "最小过纸";
            this.最小过纸.Name = "最小过纸";
            this.最小过纸.Width = 78;
            // 
            // 最小印刷
            // 
            this.最小印刷.DataPropertyName = "最小印刷";
            this.最小印刷.HeaderText = "最小印刷";
            this.最小印刷.Name = "最小印刷";
            this.最小印刷.Width = 78;
            // 
            // 启用
            // 
            this.启用.DataPropertyName = "启用";
            this.启用.FalseValue = "false";
            this.启用.HeaderText = "启用";
            this.启用.IndeterminateValue = "false";
            this.启用.Name = "启用";
            this.启用.TrueValue = "true";
            this.启用.Width = 35;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "备注";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.Width = 54;
            // 
            // 自动出版提交路径
            // 
            this.自动出版提交路径.DataPropertyName = "自动出版提交路径";
            this.自动出版提交路径.HeaderText = "自动出版提交路径";
            this.自动出版提交路径.Name = "自动出版提交路径";
            this.自动出版提交路径.Width = 83;
            // 
            // FormPrintingMachineInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 375);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrintingMachineInformation";
            this.ShowIcon = false;
            this.Text = "印刷机信息";
            this.Load += new System.EventHandler(this.FormPrintingMachineInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 机台;
        private System.Windows.Forms.DataGridViewComboBoxColumn PS版材;
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