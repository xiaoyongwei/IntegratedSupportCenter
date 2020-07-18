namespace 工作数据分析.WinForm
{
    partial class Form回单管理
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.标记为回单正常ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标记为回单异常ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标记为销售部签收ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消销售部签收ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpS = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpE = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxHdzc = new System.Windows.Forms.ComboBox();
            this.comboBoxXsbqs = new System.Windows.Forms.ComboBox();
            this.标记运费结算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消运费结算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgv.Location = new System.Drawing.Point(0, 33);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(685, 372);
            this.dgv.TabIndex = 1;
            this.dgv.Sorted += new System.EventHandler(this.dgv_Sorted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.标记为回单正常ToolStripMenuItem,
            this.标记为回单异常ToolStripMenuItem,
            this.标记为销售部签收ToolStripMenuItem,
            this.取消销售部签收ToolStripMenuItem,
            this.编辑信息ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.导入数据ToolStripMenuItem,
            this.导出数据ToolStripMenuItem,
            this.标记运费结算ToolStripMenuItem,
            this.取消运费结算ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 246);
            // 
            // 标记为回单正常ToolStripMenuItem
            // 
            this.标记为回单正常ToolStripMenuItem.Name = "标记为回单正常ToolStripMenuItem";
            this.标记为回单正常ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.标记为回单正常ToolStripMenuItem.Text = "标记\"回单正常\"";
            this.标记为回单正常ToolStripMenuItem.Click += new System.EventHandler(this.标记为回单正常ToolStripMenuItem_Click);
            // 
            // 标记为回单异常ToolStripMenuItem
            // 
            this.标记为回单异常ToolStripMenuItem.Name = "标记为回单异常ToolStripMenuItem";
            this.标记为回单异常ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.标记为回单异常ToolStripMenuItem.Text = "标记\"回单异常\"";
            this.标记为回单异常ToolStripMenuItem.Click += new System.EventHandler(this.标记为回单异常ToolStripMenuItem_Click);
            // 
            // 标记为销售部签收ToolStripMenuItem
            // 
            this.标记为销售部签收ToolStripMenuItem.Name = "标记为销售部签收ToolStripMenuItem";
            this.标记为销售部签收ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.标记为销售部签收ToolStripMenuItem.Text = "标记\"销售部签收\"";
            this.标记为销售部签收ToolStripMenuItem.Click += new System.EventHandler(this.标记为销售部签收ToolStripMenuItem_Click);
            // 
            // 取消销售部签收ToolStripMenuItem
            // 
            this.取消销售部签收ToolStripMenuItem.Name = "取消销售部签收ToolStripMenuItem";
            this.取消销售部签收ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.取消销售部签收ToolStripMenuItem.Text = "取消\"销售部签收\"";
            this.取消销售部签收ToolStripMenuItem.Click += new System.EventHandler(this.取消销售部签收ToolStripMenuItem_Click);
            // 
            // 编辑信息ToolStripMenuItem
            // 
            this.编辑信息ToolStripMenuItem.Name = "编辑信息ToolStripMenuItem";
            this.编辑信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.编辑信息ToolStripMenuItem.Text = "编辑信息";
            this.编辑信息ToolStripMenuItem.Click += new System.EventHandler(this.编辑信息ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 导入数据ToolStripMenuItem
            // 
            this.导入数据ToolStripMenuItem.Name = "导入数据ToolStripMenuItem";
            this.导入数据ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.导入数据ToolStripMenuItem.Text = "导入数据";
            this.导入数据ToolStripMenuItem.Click += new System.EventHandler(this.导入数据ToolStripMenuItem_Click);
            // 
            // 导出数据ToolStripMenuItem
            // 
            this.导出数据ToolStripMenuItem.Name = "导出数据ToolStripMenuItem";
            this.导出数据ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.导出数据ToolStripMenuItem.Text = "导出数据";
            this.导出数据ToolStripMenuItem.Click += new System.EventHandler(this.导出数据ToolStripMenuItem_Click);
            // 
            // dtpS
            // 
            this.dtpS.CustomFormat = "yyyy-MM-dd";
            this.dtpS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpS.Location = new System.Drawing.Point(12, 6);
            this.dtpS.Name = "dtpS";
            this.dtpS.Size = new System.Drawing.Size(93, 21);
            this.dtpS.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "->";
            // 
            // dtpE
            // 
            this.dtpE.CustomFormat = "yyyy-MM-dd";
            this.dtpE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpE.Location = new System.Drawing.Point(134, 6);
            this.dtpE.Name = "dtpE";
            this.dtpE.Size = new System.Drawing.Size(91, 21);
            this.dtpE.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "搜索:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(479, 6);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(143, 21);
            this.textBoxSearch.TabIndex = 5;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(628, 5);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(45, 23);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "搜索";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxHdzc
            // 
            this.comboBoxHdzc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHdzc.FormattingEnabled = true;
            this.comboBoxHdzc.Items.AddRange(new object[] {
            "全部回单",
            "正常回单",
            "异常回单"});
            this.comboBoxHdzc.Location = new System.Drawing.Point(231, 7);
            this.comboBoxHdzc.Name = "comboBoxHdzc";
            this.comboBoxHdzc.Size = new System.Drawing.Size(90, 20);
            this.comboBoxHdzc.TabIndex = 7;
            // 
            // comboBoxXsbqs
            // 
            this.comboBoxXsbqs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxXsbqs.FormattingEnabled = true;
            this.comboBoxXsbqs.Items.AddRange(new object[] {
            "全部",
            "销售部签收",
            "销售部未签收"});
            this.comboBoxXsbqs.Location = new System.Drawing.Point(327, 7);
            this.comboBoxXsbqs.Name = "comboBoxXsbqs";
            this.comboBoxXsbqs.Size = new System.Drawing.Size(105, 20);
            this.comboBoxXsbqs.TabIndex = 7;
            // 
            // 标记运费结算ToolStripMenuItem
            // 
            this.标记运费结算ToolStripMenuItem.Name = "标记运费结算ToolStripMenuItem";
            this.标记运费结算ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.标记运费结算ToolStripMenuItem.Text = "标记\"运费结算\"";
            this.标记运费结算ToolStripMenuItem.Click += new System.EventHandler(this.标记运费结算ToolStripMenuItem_Click);
            // 
            // 取消运费结算ToolStripMenuItem
            // 
            this.取消运费结算ToolStripMenuItem.Name = "取消运费结算ToolStripMenuItem";
            this.取消运费结算ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.取消运费结算ToolStripMenuItem.Text = "取消\"运费结算\"";
            this.取消运费结算ToolStripMenuItem.Click += new System.EventHandler(this.取消运费结算ToolStripMenuItem_Click);
            // 
            // Form回单管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 405);
            this.Controls.Add(this.comboBoxXsbqs);
            this.Controls.Add(this.comboBoxHdzc);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpE);
            this.Controls.Add(this.dtpS);
            this.Controls.Add(this.dgv);
            this.Name = "Form回单管理";
            this.ShowIcon = false;
            this.Text = "回单管理";
            this.Load += new System.EventHandler(this.Form回单管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DateTimePicker dtpS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxHdzc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 标记为回单正常ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标记为回单异常ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标记为销售部签收ToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxXsbqs;
        private System.Windows.Forms.ToolStripMenuItem 编辑信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消销售部签收ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标记运费结算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消运费结算ToolStripMenuItem;
    }
}