﻿namespace 工作数据分析.WinForm
{
    partial class Form制版线实时
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从瓦片线载入数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage当前排程 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv1800 = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgv2200 = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgv2500 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv24Hwangong = new System.Windows.Forms.DataGridView();
            this.tabPage完工查询 = new System.Windows.Forms.TabPage();
            this.button查询 = new System.Windows.Forms.Button();
            this.textBox客户 = new System.Windows.Forms.TextBox();
            this.textBox工单 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPicker_e = new System.Windows.Forms.DateTimePicker();
            this.dtPicker_s = new System.Windows.Forms.DateTimePicker();
            this.dgv_wg = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage当前排程.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1800)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2200)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2500)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv24Hwangong)).BeginInit();
            this.tabPage完工查询.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_wg)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.从瓦片线载入数据ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 从瓦片线载入数据ToolStripMenuItem
            // 
            this.从瓦片线载入数据ToolStripMenuItem.Name = "从瓦片线载入数据ToolStripMenuItem";
            this.从瓦片线载入数据ToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.从瓦片线载入数据ToolStripMenuItem.Text = "从瓦片线载入数据";
            this.从瓦片线载入数据ToolStripMenuItem.Click += new System.EventHandler(this.从瓦片线载入数据ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage当前排程);
            this.tabControl1.Controls.Add(this.tabPage完工查询);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(924, 657);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage当前排程
            // 
            this.tabPage当前排程.Controls.Add(this.splitContainer2);
            this.tabPage当前排程.Location = new System.Drawing.Point(4, 22);
            this.tabPage当前排程.Name = "tabPage当前排程";
            this.tabPage当前排程.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage当前排程.Size = new System.Drawing.Size(916, 631);
            this.tabPage当前排程.TabIndex = 0;
            this.tabPage当前排程.Text = "当前排程";
            this.tabPage当前排程.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(910, 625);
            this.splitContainer2.SplitterDistance = 469;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 469);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前队列";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(904, 449);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv1800);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 449);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "1800制版线";
            // 
            // dgv1800
            // 
            this.dgv1800.AllowUserToAddRows = false;
            this.dgv1800.AllowUserToDeleteRows = false;
            this.dgv1800.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv1800.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv1800.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1800.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1800.Location = new System.Drawing.Point(3, 17);
            this.dgv1800.Name = "dgv1800";
            this.dgv1800.ReadOnly = true;
            this.dgv1800.RowTemplate.Height = 23;
            this.dgv1800.Size = new System.Drawing.Size(258, 429);
            this.dgv1800.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer3.Size = new System.Drawing.Size(636, 449);
            this.splitContainer3.SplitterDistance = 306;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgv2200);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(306, 449);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "2200制版线";
            // 
            // dgv2200
            // 
            this.dgv2200.AllowUserToAddRows = false;
            this.dgv2200.AllowUserToDeleteRows = false;
            this.dgv2200.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv2200.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv2200.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2200.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv2200.Location = new System.Drawing.Point(3, 17);
            this.dgv2200.Name = "dgv2200";
            this.dgv2200.ReadOnly = true;
            this.dgv2200.RowTemplate.Height = 23;
            this.dgv2200.Size = new System.Drawing.Size(300, 429);
            this.dgv2200.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgv2500);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(326, 449);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "2500制版线";
            // 
            // dgv2500
            // 
            this.dgv2500.AllowUserToAddRows = false;
            this.dgv2500.AllowUserToDeleteRows = false;
            this.dgv2500.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv2500.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv2500.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2500.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv2500.Location = new System.Drawing.Point(3, 17);
            this.dgv2500.Name = "dgv2500";
            this.dgv2500.ReadOnly = true;
            this.dgv2500.RowTemplate.Height = 23;
            this.dgv2500.Size = new System.Drawing.Size(320, 429);
            this.dgv2500.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv24Hwangong);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(910, 152);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "24小时内完成记录";
            // 
            // dgv24Hwangong
            // 
            this.dgv24Hwangong.AllowUserToAddRows = false;
            this.dgv24Hwangong.AllowUserToDeleteRows = false;
            this.dgv24Hwangong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv24Hwangong.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv24Hwangong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv24Hwangong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv24Hwangong.Location = new System.Drawing.Point(3, 17);
            this.dgv24Hwangong.Name = "dgv24Hwangong";
            this.dgv24Hwangong.ReadOnly = true;
            this.dgv24Hwangong.RowTemplate.Height = 23;
            this.dgv24Hwangong.Size = new System.Drawing.Size(904, 132);
            this.dgv24Hwangong.TabIndex = 1;
            // 
            // tabPage完工查询
            // 
            this.tabPage完工查询.Controls.Add(this.button查询);
            this.tabPage完工查询.Controls.Add(this.textBox客户);
            this.tabPage完工查询.Controls.Add(this.textBox工单);
            this.tabPage完工查询.Controls.Add(this.label4);
            this.tabPage完工查询.Controls.Add(this.label3);
            this.tabPage完工查询.Controls.Add(this.label2);
            this.tabPage完工查询.Controls.Add(this.label1);
            this.tabPage完工查询.Controls.Add(this.dtPicker_e);
            this.tabPage完工查询.Controls.Add(this.dtPicker_s);
            this.tabPage完工查询.Controls.Add(this.dgv_wg);
            this.tabPage完工查询.Location = new System.Drawing.Point(4, 22);
            this.tabPage完工查询.Name = "tabPage完工查询";
            this.tabPage完工查询.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage完工查询.Size = new System.Drawing.Size(916, 631);
            this.tabPage完工查询.TabIndex = 1;
            this.tabPage完工查询.Text = "完工查询";
            this.tabPage完工查询.UseVisualStyleBackColor = true;
            // 
            // button查询
            // 
            this.button查询.Location = new System.Drawing.Point(753, 6);
            this.button查询.Name = "button查询";
            this.button查询.Size = new System.Drawing.Size(75, 23);
            this.button查询.TabIndex = 5;
            this.button查询.Text = "查  询";
            this.button查询.UseVisualStyleBackColor = true;
            this.button查询.Click += new System.EventHandler(this.button查询_Click);
            // 
            // textBox客户
            // 
            this.textBox客户.Location = new System.Drawing.Point(223, 6);
            this.textBox客户.Name = "textBox客户";
            this.textBox客户.Size = new System.Drawing.Size(120, 21);
            this.textBox客户.TabIndex = 4;
            // 
            // textBox工单
            // 
            this.textBox工单.Location = new System.Drawing.Point(50, 6);
            this.textBox工单.Name = "textBox工单";
            this.textBox工单.Size = new System.Drawing.Size(120, 21);
            this.textBox工单.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(553, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "结束时间:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "开始时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "客户:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "工单:";
            // 
            // dtPicker_e
            // 
            this.dtPicker_e.Location = new System.Drawing.Point(618, 6);
            this.dtPicker_e.Name = "dtPicker_e";
            this.dtPicker_e.Size = new System.Drawing.Size(129, 21);
            this.dtPicker_e.TabIndex = 2;
            // 
            // dtPicker_s
            // 
            this.dtPicker_s.Location = new System.Drawing.Point(416, 6);
            this.dtPicker_s.Name = "dtPicker_s";
            this.dtPicker_s.Size = new System.Drawing.Size(129, 21);
            this.dtPicker_s.TabIndex = 2;
            // 
            // dgv_wg
            // 
            this.dgv_wg.AllowUserToAddRows = false;
            this.dgv_wg.AllowUserToDeleteRows = false;
            this.dgv_wg.AllowUserToOrderColumns = true;
            this.dgv_wg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_wg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_wg.Location = new System.Drawing.Point(3, 33);
            this.dgv_wg.Name = "dgv_wg";
            this.dgv_wg.ReadOnly = true;
            this.dgv_wg.RowTemplate.Height = 23;
            this.dgv_wg.Size = new System.Drawing.Size(910, 595);
            this.dgv_wg.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form制版线实时
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 682);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form制版线实时";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "制版线实时查询";
            this.Load += new System.EventHandler(this.Form制版线查询_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage当前排程.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1800)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2200)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2500)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv24Hwangong)).EndInit();
            this.tabPage完工查询.ResumeLayout(false);
            this.tabPage完工查询.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_wg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage当前排程;
        private System.Windows.Forms.DataGridView dgv1800;
        private System.Windows.Forms.TabPage tabPage完工查询;
        private System.Windows.Forms.DataGridView dgv_wg;
        private System.Windows.Forms.ToolStripMenuItem 从瓦片线载入数据ToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtPicker_e;
        private System.Windows.Forms.TextBox textBox客户;
        private System.Windows.Forms.TextBox textBox工单;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPicker_s;
        private System.Windows.Forms.Button button查询;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgv24Hwangong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgv2200;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgv2500;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}