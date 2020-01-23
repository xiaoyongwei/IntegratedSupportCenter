namespace YBF.WinForm.Accessories
{
    partial class FormFuliaoLingLiao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.说明正数表示增加负数表示减少ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ColumnFlmc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnShuliang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnZhaiyao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.说明正数表示增加负数表示减少ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(41, 20);
            this.tsmiSave.Text = "保存";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // 说明正数表示增加负数表示减少ToolStripMenuItem
            // 
            this.说明正数表示增加负数表示减少ToolStripMenuItem.Enabled = false;
            this.说明正数表示增加负数表示减少ToolStripMenuItem.Font = new System.Drawing.Font("方正姚体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.说明正数表示增加负数表示减少ToolStripMenuItem.Name = "说明正数表示增加负数表示减少ToolStripMenuItem";
            this.说明正数表示增加负数表示减少ToolStripMenuItem.Size = new System.Drawing.Size(196, 20);
            this.说明正数表示增加负数表示减少ToolStripMenuItem.Text = "说明:正数表示增加;负数表示减少.";
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFlmc,
            this.ColumnShuliang,
            this.ColumnZhaiyao,
            this.ColumnNote});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv.Location = new System.Drawing.Point(0, 24);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(734, 393);
            this.dgv.TabIndex = 1;
            // 
            // ColumnFlmc
            // 
            this.ColumnFlmc.HeaderText = "辅料名称";
            this.ColumnFlmc.Name = "ColumnFlmc";
            this.ColumnFlmc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnFlmc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnShuliang
            // 
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.ColumnShuliang.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnShuliang.HeaderText = "数量";
            this.ColumnShuliang.Name = "ColumnShuliang";
            // 
            // ColumnZhaiyao
            // 
            this.ColumnZhaiyao.HeaderText = "摘要";
            this.ColumnZhaiyao.Name = "ColumnZhaiyao";
            // 
            // ColumnNote
            // 
            this.ColumnNote.HeaderText = "备注";
            this.ColumnNote.Name = "ColumnNote";
            // 
            // FormFuliaoLingLiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 417);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "FormFuliaoLingLiao";
            this.ShowIcon = false;
            this.Text = "辅料-领料和使用";
            this.Load += new System.EventHandler(this.FormFuliaoLingLiao_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnFlmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShuliang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnZhaiyao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNote;
        private System.Windows.Forms.ToolStripMenuItem 说明正数表示增加负数表示减少ToolStripMenuItem;
    }
}