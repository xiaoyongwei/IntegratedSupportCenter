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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出当前排程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出彩盒排程隔行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出彩盒排程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出全部排程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从瓦片线载入数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage当前排程 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox1800F = new System.Windows.Forms.GroupBox();
            this.dgv1800F = new System.Windows.Forms.DataGridView();
            this.groupBox1800E = new System.Windows.Forms.GroupBox();
            this.dgv1800E = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox2200 = new System.Windows.Forms.GroupBox();
            this.dgv2200 = new System.Windows.Forms.DataGridView();
            this.groupBox2500 = new System.Windows.Forms.GroupBox();
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
            this.timerSQLiteToDgv = new System.Windows.Forms.Timer(this.components);
            this.timerBackupSQLiteToMySQL = new System.Windows.Forms.Timer(this.components);
            this.timerBackupZbxToSQLite = new System.Windows.Forms.Timer(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox1800F.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1800F)).BeginInit();
            this.groupBox1800E.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1800E)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox2200.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2200)).BeginInit();
            this.groupBox2500.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2500)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv24Hwangong)).BeginInit();
            this.tabPage完工查询.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_wg)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.导出当前排程ToolStripMenuItem,
            this.自动刷新ToolStripMenuItem,
            this.从瓦片线载入数据ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1656, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 导出当前排程ToolStripMenuItem
            // 
            this.导出当前排程ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出彩盒排程隔行ToolStripMenuItem,
            this.导出彩盒排程ToolStripMenuItem,
            this.导出全部排程ToolStripMenuItem});
            this.导出当前排程ToolStripMenuItem.Name = "导出当前排程ToolStripMenuItem";
            this.导出当前排程ToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.导出当前排程ToolStripMenuItem.Text = "导出当前排程";
            // 
            // 导出彩盒排程隔行ToolStripMenuItem
            // 
            this.导出彩盒排程隔行ToolStripMenuItem.Name = "导出彩盒排程隔行ToolStripMenuItem";
            this.导出彩盒排程隔行ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.导出彩盒排程隔行ToolStripMenuItem.Text = "导出彩盒排程(隔行)";
            this.导出彩盒排程隔行ToolStripMenuItem.Click += new System.EventHandler(this.导出彩盒排程隔行ToolStripMenuItem_Click);
            // 
            // 导出彩盒排程ToolStripMenuItem
            // 
            this.导出彩盒排程ToolStripMenuItem.Name = "导出彩盒排程ToolStripMenuItem";
            this.导出彩盒排程ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.导出彩盒排程ToolStripMenuItem.Text = "导出彩盒排程";
            this.导出彩盒排程ToolStripMenuItem.Click += new System.EventHandler(this.导出彩盒排程ToolStripMenuItem_Click);
            // 
            // 导出全部排程ToolStripMenuItem
            // 
            this.导出全部排程ToolStripMenuItem.Name = "导出全部排程ToolStripMenuItem";
            this.导出全部排程ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.导出全部排程ToolStripMenuItem.Text = "导出全部排程";
            this.导出全部排程ToolStripMenuItem.Click += new System.EventHandler(this.导出全部排程ToolStripMenuItem_Click);
            // 
            // 自动刷新ToolStripMenuItem
            // 
            this.自动刷新ToolStripMenuItem.CheckOnClick = true;
            this.自动刷新ToolStripMenuItem.Name = "自动刷新ToolStripMenuItem";
            this.自动刷新ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.自动刷新ToolStripMenuItem.Text = "自动刷新";
            this.自动刷新ToolStripMenuItem.ToolTipText = "没过1分钟自动刷新";
            this.自动刷新ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.自动刷新ToolStripMenuItem_CheckedChanged);
            // 
            // 从瓦片线载入数据ToolStripMenuItem
            // 
            this.从瓦片线载入数据ToolStripMenuItem.Enabled = false;
            this.从瓦片线载入数据ToolStripMenuItem.Name = "从瓦片线载入数据ToolStripMenuItem";
            this.从瓦片线载入数据ToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.从瓦片线载入数据ToolStripMenuItem.Text = "备份到数据库";
            this.从瓦片线载入数据ToolStripMenuItem.Visible = false;
            this.从瓦片线载入数据ToolStripMenuItem.Click += new System.EventHandler(this.从瓦片线载入数据ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage当前排程);
            this.tabControl1.Controls.Add(this.tabPage完工查询);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1656, 824);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage当前排程
            // 
            this.tabPage当前排程.Controls.Add(this.splitContainer2);
            this.tabPage当前排程.Location = new System.Drawing.Point(4, 25);
            this.tabPage当前排程.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage当前排程.Name = "tabPage当前排程";
            this.tabPage当前排程.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage当前排程.Size = new System.Drawing.Size(1648, 795);
            this.tabPage当前排程.TabIndex = 0;
            this.tabPage当前排程.Text = "当前排程";
            this.tabPage当前排程.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(4, 4);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
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
            this.splitContainer2.Size = new System.Drawing.Size(1640, 787);
            this.splitContainer2.SplitterDistance = 590;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1640, 590);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前队列";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 22);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1632, 564);
            this.splitContainer1.SplitterDistance = 811;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox1800F);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox1800E);
            this.splitContainer4.Size = new System.Drawing.Size(811, 564);
            this.splitContainer4.SplitterDistance = 421;
            this.splitContainer4.SplitterWidth = 5;
            this.splitContainer4.TabIndex = 5;
            // 
            // groupBox1800F
            // 
            this.groupBox1800F.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1800F.Controls.Add(this.dgv1800F);
            this.groupBox1800F.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1800F.Location = new System.Drawing.Point(0, 0);
            this.groupBox1800F.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1800F.Name = "groupBox1800F";
            this.groupBox1800F.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1800F.Size = new System.Drawing.Size(421, 564);
            this.groupBox1800F.TabIndex = 5;
            this.groupBox1800F.TabStop = false;
            this.groupBox1800F.Text = "1800F制版线";
            // 
            // dgv1800F
            // 
            this.dgv1800F.AllowUserToAddRows = false;
            this.dgv1800F.AllowUserToDeleteRows = false;
            this.dgv1800F.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv1800F.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv1800F.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1800F.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1800F.Location = new System.Drawing.Point(4, 22);
            this.dgv1800F.Margin = new System.Windows.Forms.Padding(4);
            this.dgv1800F.Name = "dgv1800F";
            this.dgv1800F.ReadOnly = true;
            this.dgv1800F.RowHeadersVisible = false;
            this.dgv1800F.RowHeadersWidth = 51;
            this.dgv1800F.RowTemplate.Height = 23;
            this.dgv1800F.Size = new System.Drawing.Size(413, 538);
            this.dgv1800F.TabIndex = 0;
            // 
            // groupBox1800E
            // 
            this.groupBox1800E.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1800E.Controls.Add(this.dgv1800E);
            this.groupBox1800E.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1800E.Location = new System.Drawing.Point(0, 0);
            this.groupBox1800E.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1800E.Name = "groupBox1800E";
            this.groupBox1800E.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1800E.Size = new System.Drawing.Size(385, 564);
            this.groupBox1800E.TabIndex = 4;
            this.groupBox1800E.TabStop = false;
            this.groupBox1800E.Text = "1800E制版线";
            // 
            // dgv1800E
            // 
            this.dgv1800E.AllowUserToAddRows = false;
            this.dgv1800E.AllowUserToDeleteRows = false;
            this.dgv1800E.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv1800E.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv1800E.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1800E.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1800E.Location = new System.Drawing.Point(4, 22);
            this.dgv1800E.Margin = new System.Windows.Forms.Padding(4);
            this.dgv1800E.Name = "dgv1800E";
            this.dgv1800E.ReadOnly = true;
            this.dgv1800E.RowHeadersVisible = false;
            this.dgv1800E.RowHeadersWidth = 51;
            this.dgv1800E.RowTemplate.Height = 23;
            this.dgv1800E.Size = new System.Drawing.Size(377, 538);
            this.dgv1800E.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox2200);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2500);
            this.splitContainer3.Size = new System.Drawing.Size(816, 564);
            this.splitContainer3.SplitterDistance = 450;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox2200
            // 
            this.groupBox2200.Controls.Add(this.dgv2200);
            this.groupBox2200.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2200.ForeColor = System.Drawing.Color.Black;
            this.groupBox2200.Location = new System.Drawing.Point(0, 0);
            this.groupBox2200.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2200.Name = "groupBox2200";
            this.groupBox2200.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2200.Size = new System.Drawing.Size(450, 564);
            this.groupBox2200.TabIndex = 3;
            this.groupBox2200.TabStop = false;
            this.groupBox2200.Text = "2200制版线";
            // 
            // dgv2200
            // 
            this.dgv2200.AllowUserToAddRows = false;
            this.dgv2200.AllowUserToDeleteRows = false;
            this.dgv2200.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv2200.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv2200.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2200.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv2200.Location = new System.Drawing.Point(4, 22);
            this.dgv2200.Margin = new System.Windows.Forms.Padding(4);
            this.dgv2200.Name = "dgv2200";
            this.dgv2200.ReadOnly = true;
            this.dgv2200.RowHeadersVisible = false;
            this.dgv2200.RowHeadersWidth = 51;
            this.dgv2200.RowTemplate.Height = 23;
            this.dgv2200.Size = new System.Drawing.Size(442, 538);
            this.dgv2200.TabIndex = 0;
            // 
            // groupBox2500
            // 
            this.groupBox2500.Controls.Add(this.dgv2500);
            this.groupBox2500.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2500.Location = new System.Drawing.Point(0, 0);
            this.groupBox2500.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2500.Name = "groupBox2500";
            this.groupBox2500.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2500.Size = new System.Drawing.Size(361, 564);
            this.groupBox2500.TabIndex = 3;
            this.groupBox2500.TabStop = false;
            this.groupBox2500.Text = "2500制版线";
            // 
            // dgv2500
            // 
            this.dgv2500.AllowUserToAddRows = false;
            this.dgv2500.AllowUserToDeleteRows = false;
            this.dgv2500.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv2500.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv2500.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2500.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv2500.Location = new System.Drawing.Point(4, 22);
            this.dgv2500.Margin = new System.Windows.Forms.Padding(4);
            this.dgv2500.Name = "dgv2500";
            this.dgv2500.ReadOnly = true;
            this.dgv2500.RowHeadersVisible = false;
            this.dgv2500.RowHeadersWidth = 51;
            this.dgv2500.RowTemplate.Height = 23;
            this.dgv2500.Size = new System.Drawing.Size(353, 538);
            this.dgv2500.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv24Hwangong);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1640, 192);
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
            this.dgv24Hwangong.Location = new System.Drawing.Point(4, 22);
            this.dgv24Hwangong.Margin = new System.Windows.Forms.Padding(4);
            this.dgv24Hwangong.Name = "dgv24Hwangong";
            this.dgv24Hwangong.ReadOnly = true;
            this.dgv24Hwangong.RowHeadersVisible = false;
            this.dgv24Hwangong.RowHeadersWidth = 51;
            this.dgv24Hwangong.RowTemplate.Height = 23;
            this.dgv24Hwangong.Size = new System.Drawing.Size(1632, 166);
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
            this.tabPage完工查询.Location = new System.Drawing.Point(4, 25);
            this.tabPage完工查询.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage完工查询.Name = "tabPage完工查询";
            this.tabPage完工查询.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage完工查询.Size = new System.Drawing.Size(1648, 795);
            this.tabPage完工查询.TabIndex = 1;
            this.tabPage完工查询.Text = "完工查询";
            this.tabPage完工查询.UseVisualStyleBackColor = true;
            // 
            // button查询
            // 
            this.button查询.Location = new System.Drawing.Point(1004, 8);
            this.button查询.Margin = new System.Windows.Forms.Padding(4);
            this.button查询.Name = "button查询";
            this.button查询.Size = new System.Drawing.Size(100, 29);
            this.button查询.TabIndex = 5;
            this.button查询.Text = "查  询";
            this.button查询.UseVisualStyleBackColor = true;
            this.button查询.Click += new System.EventHandler(this.button查询_Click);
            // 
            // textBox客户
            // 
            this.textBox客户.Location = new System.Drawing.Point(297, 8);
            this.textBox客户.Margin = new System.Windows.Forms.Padding(4);
            this.textBox客户.Name = "textBox客户";
            this.textBox客户.Size = new System.Drawing.Size(159, 25);
            this.textBox客户.TabIndex = 4;
            // 
            // textBox工单
            // 
            this.textBox工单.Location = new System.Drawing.Point(67, 8);
            this.textBox工单.Margin = new System.Windows.Forms.Padding(4);
            this.textBox工单.Name = "textBox工单";
            this.textBox工单.Size = new System.Drawing.Size(159, 25);
            this.textBox工单.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(737, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "结束时间:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(468, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "开始时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "客户:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "工单:";
            // 
            // dtPicker_e
            // 
            this.dtPicker_e.Location = new System.Drawing.Point(824, 8);
            this.dtPicker_e.Margin = new System.Windows.Forms.Padding(4);
            this.dtPicker_e.Name = "dtPicker_e";
            this.dtPicker_e.Size = new System.Drawing.Size(171, 25);
            this.dtPicker_e.TabIndex = 2;
            // 
            // dtPicker_s
            // 
            this.dtPicker_s.Location = new System.Drawing.Point(555, 8);
            this.dtPicker_s.Margin = new System.Windows.Forms.Padding(4);
            this.dtPicker_s.Name = "dtPicker_s";
            this.dtPicker_s.Size = new System.Drawing.Size(171, 25);
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
            this.dgv_wg.Location = new System.Drawing.Point(4, 41);
            this.dgv_wg.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_wg.Name = "dgv_wg";
            this.dgv_wg.ReadOnly = true;
            this.dgv_wg.RowHeadersWidth = 51;
            this.dgv_wg.RowTemplate.Height = 23;
            this.dgv_wg.Size = new System.Drawing.Size(1213, 744);
            this.dgv_wg.TabIndex = 0;
            // 
            // timerSQLiteToDgv
            // 
            this.timerSQLiteToDgv.Enabled = true;
            this.timerSQLiteToDgv.Interval = 60000;
            this.timerSQLiteToDgv.Tick += new System.EventHandler(this.timerLocal_Tick);
            // 
            // timerBackupSQLiteToMySQL
            // 
            this.timerBackupSQLiteToMySQL.Enabled = true;
            this.timerBackupSQLiteToMySQL.Interval = 600000;
            this.timerBackupSQLiteToMySQL.Tick += new System.EventHandler(this.timerMySQL_Tick);
            // 
            // timerBackupZbxToSQLite
            // 
            this.timerBackupZbxToSQLite.Enabled = true;
            this.timerBackupZbxToSQLite.Interval = 60000;
            this.timerBackupZbxToSQLite.Tick += new System.EventHandler(this.timerBackupZbxToSQLite_Tick);
            // 
            // Form制版线实时
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 852);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form制版线实时";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "制版线实时查询";
            this.Load += new System.EventHandler(this.Form制版线查询_Load);
            this.SizeChanged += new System.EventHandler(this.Form制版线实时_SizeChanged);
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
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox1800F.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1800F)).EndInit();
            this.groupBox1800E.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1800E)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2200.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2200)).EndInit();
            this.groupBox2500.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPage完工查询;
        private System.Windows.Forms.DataGridView dgv_wg;
        private System.Windows.Forms.DateTimePicker dtPicker_e;
        private System.Windows.Forms.TextBox textBox客户;
        private System.Windows.Forms.TextBox textBox工单;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPicker_s;
        private System.Windows.Forms.Button button查询;
        private System.Windows.Forms.Timer timerSQLiteToDgv;
        private System.Windows.Forms.Timer timerBackupZbxToSQLite;
        private System.Windows.Forms.ToolStripMenuItem 导出当前排程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动刷新ToolStripMenuItem;
        protected internal System.Windows.Forms.ToolStripMenuItem 从瓦片线载入数据ToolStripMenuItem;
        protected internal System.Windows.Forms.Timer timerBackupSQLiteToMySQL;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBox1800F;
        private System.Windows.Forms.DataGridView dgv1800F;
        private System.Windows.Forms.GroupBox groupBox1800E;
        private System.Windows.Forms.DataGridView dgv1800E;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox2200;
        private System.Windows.Forms.DataGridView dgv2200;
        private System.Windows.Forms.GroupBox groupBox2500;
        private System.Windows.Forms.DataGridView dgv2500;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv24Hwangong;
        private System.Windows.Forms.ToolStripMenuItem 导出彩盒排程隔行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出彩盒排程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出全部排程ToolStripMenuItem;
    }
}