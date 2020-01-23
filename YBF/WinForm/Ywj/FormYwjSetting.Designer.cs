namespace YBF.WinForm
{
    partial class FormYwjSetting
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
            this.dgv_ywj = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPathMove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaiChu = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ywj)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_ywj
            // 
            this.dgv_ywj.AllowUserToAddRows = false;
            this.dgv_ywj.AllowUserToDeleteRows = false;
            this.dgv_ywj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_ywj.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_ywj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ywj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnName,
            this.ColumnPath,
            this.ColumnPathMove});
            this.dgv_ywj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ywj.Location = new System.Drawing.Point(0, 24);
            this.dgv_ywj.Name = "dgv_ywj";
            this.dgv_ywj.ReadOnly = true;
            this.dgv_ywj.RowHeadersVisible = false;
            this.dgv_ywj.RowTemplate.Height = 23;
            this.dgv_ywj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ywj.Size = new System.Drawing.Size(544, 375);
            this.dgv_ywj.TabIndex = 0;
            this.dgv_ywj.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ywj_CellDoubleClick);
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Width = 42;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "名称";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 51;
            // 
            // ColumnPath
            // 
            this.ColumnPath.HeaderText = "源文件所在目录";
            this.ColumnPath.Name = "ColumnPath";
            this.ColumnPath.ReadOnly = true;
            this.ColumnPath.Width = 83;
            // 
            // ColumnPathMove
            // 
            this.ColumnPathMove.HeaderText = "完成后移动的目录";
            this.ColumnPathMove.Name = "ColumnPathMove";
            this.ColumnPathMove.ReadOnly = true;
            this.ColumnPathMove.Width = 83;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiUpdate,
            this.tsmiDel,
            this.tsmiPaiChu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(41, 20);
            this.tsmiAdd.Text = "增加";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(41, 20);
            this.tsmiUpdate.Text = "修改";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.Size = new System.Drawing.Size(41, 20);
            this.tsmiDel.Text = "删除";
            // 
            // tsmiPaiChu
            // 
            this.tsmiPaiChu.Name = "tsmiPaiChu";
            this.tsmiPaiChu.Size = new System.Drawing.Size(65, 20);
            this.tsmiPaiChu.Text = "排除名单";
            this.tsmiPaiChu.Click += new System.EventHandler(this.tsmiPaiChu_Click);
            // 
            // FormYwjSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 399);
            this.Controls.Add(this.dgv_ywj);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormYwjSetting";
            this.ShowIcon = false;
            this.Text = "源文件[设置]";
            this.Load += new System.EventHandler(this.FormYwj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ywj)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ywj;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPathMove;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaiChu;
    }
}