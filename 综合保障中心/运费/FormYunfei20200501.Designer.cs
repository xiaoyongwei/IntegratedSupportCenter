namespace 综合保障中心
{
    partial class FormYunfei20200501
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvYunfei = new System.Windows.Forms.DataGridView();
            this.ColumnBaodi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDqyf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSjmj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShyf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conMsSonghuo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPinche = new System.Windows.Forms.DataGridView();
            this.ColumnPcjl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPcyf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conMsPinche = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv2ci = new System.Windows.Forms.DataGridView();
            this.conMs2ci = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.textBoxHuizong = new System.Windows.Forms.TextBox();
            this.全部2次堆码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnDmpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDmf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYunfei)).BeginInit();
            this.conMsSonghuo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPinche)).BeginInit();
            this.conMsPinche.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2ci)).BeginInit();
            this.conMs2ci.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvYunfei);
            this.groupBox1.Location = new System.Drawing.Point(3, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "正常运费计算";
            // 
            // dgvYunfei
            // 
            this.dgvYunfei.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYunfei.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBaodi,
            this.ColumnDqyf,
            this.ColumnSjmj,
            this.ColumnShyf});
            this.dgvYunfei.ContextMenuStrip = this.conMsSonghuo;
            this.dgvYunfei.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvYunfei.Location = new System.Drawing.Point(3, 17);
            this.dgvYunfei.Name = "dgvYunfei";
            this.dgvYunfei.RowTemplate.Height = 23;
            this.dgvYunfei.Size = new System.Drawing.Size(536, 132);
            this.dgvYunfei.TabIndex = 1;
            this.dgvYunfei.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYunfei_CellEndEdit);
            this.dgvYunfei.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvYunfei_RowsRemoved);
            // 
            // ColumnBaodi
            // 
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = "0";
            this.ColumnBaodi.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnBaodi.HeaderText = "保底";
            this.ColumnBaodi.Name = "ColumnBaodi";
            // 
            // ColumnDqyf
            // 
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = "0";
            this.ColumnDqyf.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnDqyf.HeaderText = "地区运费";
            this.ColumnDqyf.Name = "ColumnDqyf";
            // 
            // ColumnSjmj
            // 
            dataGridViewCellStyle3.Format = "C3";
            dataGridViewCellStyle3.NullValue = "0";
            this.ColumnSjmj.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnSjmj.HeaderText = "实际面积";
            this.ColumnSjmj.Name = "ColumnSjmj";
            // 
            // ColumnShyf
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ColumnShyf.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnShyf.HeaderText = "送货运费";
            this.ColumnShyf.Name = "ColumnShyf";
            this.ColumnShyf.ReadOnly = true;
            // 
            // conMsSonghuo
            // 
            this.conMsSonghuo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除ToolStripMenuItem});
            this.conMsSonghuo.Name = "conMsSonghuo";
            this.conMsSonghuo.Size = new System.Drawing.Size(101, 26);
            // 
            // 清除ToolStripMenuItem
            // 
            this.清除ToolStripMenuItem.Name = "清除ToolStripMenuItem";
            this.清除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.清除ToolStripMenuItem.Text = "清除";
            this.清除ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemSonghuo_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "在最前";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPinche);
            this.groupBox2.Location = new System.Drawing.Point(6, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 136);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "拼车费计算";
            // 
            // dgvPinche
            // 
            this.dgvPinche.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPinche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPinche.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPcjl,
            this.ColumnPcyf});
            this.dgvPinche.ContextMenuStrip = this.conMsPinche;
            this.dgvPinche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPinche.Location = new System.Drawing.Point(3, 17);
            this.dgvPinche.Name = "dgvPinche";
            this.dgvPinche.RowTemplate.Height = 23;
            this.dgvPinche.Size = new System.Drawing.Size(254, 116);
            this.dgvPinche.TabIndex = 0;
            this.dgvPinche.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPinche_CellEndEdit);
            this.dgvPinche.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPinche_RowsRemoved);
            // 
            // ColumnPcjl
            // 
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.ColumnPcjl.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnPcjl.HeaderText = "拼车距离";
            this.ColumnPcjl.Name = "ColumnPcjl";
            // 
            // ColumnPcyf
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.ColumnPcyf.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnPcyf.HeaderText = "拼车运费";
            this.ColumnPcyf.Name = "ColumnPcyf";
            this.ColumnPcyf.ReadOnly = true;
            // 
            // conMsPinche
            // 
            this.conMsPinche.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.conMsPinche.Name = "conMsSonghuo";
            this.conMsPinche.Size = new System.Drawing.Size(101, 26);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem3.Text = "清除";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv2ci);
            this.groupBox3.Location = new System.Drawing.Point(279, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 136);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "二次堆码费计算";
            // 
            // dgv2ci
            // 
            this.dgv2ci.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv2ci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2ci.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDmpf,
            this.ColumnDmf});
            this.dgv2ci.ContextMenuStrip = this.conMs2ci;
            this.dgv2ci.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv2ci.Location = new System.Drawing.Point(3, 17);
            this.dgv2ci.Name = "dgv2ci";
            this.dgv2ci.RowTemplate.Height = 23;
            this.dgv2ci.Size = new System.Drawing.Size(254, 116);
            this.dgv2ci.TabIndex = 1;
            this.dgv2ci.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgc2ci_CellEndEdit);
            this.dgv2ci.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv2ci_RowsRemoved);
            // 
            // conMs2ci
            // 
            this.conMs2ci.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.全部2次堆码ToolStripMenuItem});
            this.conMs2ci.Name = "conMsSonghuo";
            this.conMs2ci.Size = new System.Drawing.Size(144, 48);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItem5.Text = "清除";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(73, 8);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(75, 23);
            this.buttonClearAll.TabIndex = 11;
            this.buttonClearAll.Text = "全部清零";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // textBoxHuizong
            // 
            this.textBoxHuizong.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxHuizong.Location = new System.Drawing.Point(177, 10);
            this.textBoxHuizong.Name = "textBoxHuizong";
            this.textBoxHuizong.ReadOnly = true;
            this.textBoxHuizong.Size = new System.Drawing.Size(362, 21);
            this.textBoxHuizong.TabIndex = 12;
            // 
            // 全部2次堆码ToolStripMenuItem
            // 
            this.全部2次堆码ToolStripMenuItem.Name = "全部2次堆码ToolStripMenuItem";
            this.全部2次堆码ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.全部2次堆码ToolStripMenuItem.Text = "全部2次堆码";
            this.全部2次堆码ToolStripMenuItem.Click += new System.EventHandler(this.全部2次堆码ToolStripMenuItem_Click);
            // 
            // ColumnDmpf
            // 
            dataGridViewCellStyle7.NullValue = "0";
            this.ColumnDmpf.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnDmpf.HeaderText = "堆码平方";
            this.ColumnDmpf.Name = "ColumnDmpf";
            // 
            // ColumnDmf
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0";
            this.ColumnDmf.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnDmf.HeaderText = "堆码费";
            this.ColumnDmf.Name = "ColumnDmf";
            this.ColumnDmf.ReadOnly = true;
            // 
            // FormYunfei20200501
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 352);
            this.Controls.Add(this.textBoxHuizong);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormYunfei20200501";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "运费计算";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormYunfei_FormClosing);
            this.Load += new System.EventHandler(this.FormYunfei_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYunfei)).EndInit();
            this.conMsSonghuo.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPinche)).EndInit();
            this.conMsPinche.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2ci)).EndInit();
            this.conMs2ci.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvYunfei;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPinche;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPcjl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPcyf;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv2ci;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.ContextMenuStrip conMsSonghuo;
        private System.Windows.Forms.ToolStripMenuItem 清除ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip conMsPinche;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ContextMenuStrip conMs2ci;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.TextBox textBoxHuizong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBaodi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDqyf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSjmj;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShyf;
        private System.Windows.Forms.ToolStripMenuItem 全部2次堆码ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDmpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDmf;
    }
}