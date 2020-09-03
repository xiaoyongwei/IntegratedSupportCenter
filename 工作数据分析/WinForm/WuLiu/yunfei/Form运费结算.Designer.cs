namespace 工作数据分析.WinForm.WuLiu
{
    partial class Form运费结算
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
            this.comboBoxYfjs = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpE = new System.Windows.Forms.DateTimePicker();
            this.dtpS = new System.Windows.Forms.DateTimePicker();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.自动计算运费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.手动计算运费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拼车距离ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文信1区2区拼车ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.二次堆码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.平方运费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更多ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清零运费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清零补运费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.为此客户设置地区ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看客户区域对应表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出PDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxYfjs
            // 
            this.comboBoxYfjs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYfjs.FormattingEnabled = true;
            this.comboBoxYfjs.Items.AddRange(new object[] {
            "全部",
            "已结算",
            "未结算"});
            this.comboBoxYfjs.Location = new System.Drawing.Point(228, 7);
            this.comboBoxYfjs.Name = "comboBoxYfjs";
            this.comboBoxYfjs.Size = new System.Drawing.Size(90, 20);
            this.comboBoxYfjs.TabIndex = 15;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(523, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(45, 23);
            this.buttonSearch.TabIndex = 13;
            this.buttonSearch.Text = "搜索";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(374, 4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(143, 21);
            this.textBoxSearch.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "搜索:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "->";
            // 
            // dtpE
            // 
            this.dtpE.CustomFormat = "yyyy-MM-dd";
            this.dtpE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpE.Location = new System.Drawing.Point(131, 6);
            this.dtpE.Name = "dtpE";
            this.dtpE.Size = new System.Drawing.Size(91, 21);
            this.dtpE.TabIndex = 8;
            // 
            // dtpS
            // 
            this.dtpS.CustomFormat = "yyyy-MM-dd";
            this.dtpS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpS.Location = new System.Drawing.Point(9, 6);
            this.dtpS.Name = "dtpS";
            this.dtpS.Size = new System.Drawing.Size(93, 21);
            this.dtpS.TabIndex = 9;
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
            this.dgv.Location = new System.Drawing.Point(0, 36);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(799, 414);
            this.dgv.TabIndex = 16;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自动计算运费ToolStripMenuItem,
            this.手动计算运费ToolStripMenuItem,
            this.拼车距离ToolStripMenuItem,
            this.文信1区2区拼车ToolStripMenuItem,
            this.二次堆码ToolStripMenuItem,
            this.平方运费ToolStripMenuItem,
            this.导出数据ToolStripMenuItem,
            this.导出PDFToolStripMenuItem,
            this.更多ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 224);
            // 
            // 自动计算运费ToolStripMenuItem
            // 
            this.自动计算运费ToolStripMenuItem.Name = "自动计算运费ToolStripMenuItem";
            this.自动计算运费ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.自动计算运费ToolStripMenuItem.Text = "自动计算运费";
            this.自动计算运费ToolStripMenuItem.Click += new System.EventHandler(this.自动计算运费ToolStripMenuItem_Click);
            // 
            // 手动计算运费ToolStripMenuItem
            // 
            this.手动计算运费ToolStripMenuItem.Name = "手动计算运费ToolStripMenuItem";
            this.手动计算运费ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.手动计算运费ToolStripMenuItem.Text = "手动计算运费";
            this.手动计算运费ToolStripMenuItem.Click += new System.EventHandler(this.计算运费ToolStripMenuItem_Click);
            // 
            // 拼车距离ToolStripMenuItem
            // 
            this.拼车距离ToolStripMenuItem.Name = "拼车距离ToolStripMenuItem";
            this.拼车距离ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.拼车距离ToolStripMenuItem.Text = "拼车距离";
            this.拼车距离ToolStripMenuItem.Click += new System.EventHandler(this.拼车距离ToolStripMenuItem_Click);
            // 
            // 文信1区2区拼车ToolStripMenuItem
            // 
            this.文信1区2区拼车ToolStripMenuItem.Name = "文信1区2区拼车ToolStripMenuItem";
            this.文信1区2区拼车ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.文信1区2区拼车ToolStripMenuItem.Text = "文信1区2区拼车";
            this.文信1区2区拼车ToolStripMenuItem.Click += new System.EventHandler(this.文信1区2区拼车ToolStripMenuItem_Click);
            // 
            // 二次堆码ToolStripMenuItem
            // 
            this.二次堆码ToolStripMenuItem.Name = "二次堆码ToolStripMenuItem";
            this.二次堆码ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.二次堆码ToolStripMenuItem.Text = "二次堆码";
            this.二次堆码ToolStripMenuItem.Click += new System.EventHandler(this.二次堆码ToolStripMenuItem_Click);
            // 
            // 平方运费ToolStripMenuItem
            // 
            this.平方运费ToolStripMenuItem.Name = "平方运费ToolStripMenuItem";
            this.平方运费ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.平方运费ToolStripMenuItem.Text = "平方/运费";
            this.平方运费ToolStripMenuItem.Click += new System.EventHandler(this.平方运费ToolStripMenuItem_Click);
            // 
            // 导出数据ToolStripMenuItem
            // 
            this.导出数据ToolStripMenuItem.Name = "导出数据ToolStripMenuItem";
            this.导出数据ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.导出数据ToolStripMenuItem.Text = "导出数据";
            this.导出数据ToolStripMenuItem.Click += new System.EventHandler(this.导出数据ToolStripMenuItem_Click);
            // 
            // 更多ToolStripMenuItem
            // 
            this.更多ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清零运费ToolStripMenuItem,
            this.清零补运费ToolStripMenuItem,
            this.为此客户设置地区ToolStripMenuItem,
            this.查看客户区域对应表ToolStripMenuItem});
            this.更多ToolStripMenuItem.Name = "更多ToolStripMenuItem";
            this.更多ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.更多ToolStripMenuItem.Text = "更多";
            // 
            // 清零运费ToolStripMenuItem
            // 
            this.清零运费ToolStripMenuItem.Name = "清零运费ToolStripMenuItem";
            this.清零运费ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.清零运费ToolStripMenuItem.Text = "清零运费";
            this.清零运费ToolStripMenuItem.Click += new System.EventHandler(this.清零运费ToolStripMenuItem_Click);
            // 
            // 清零补运费ToolStripMenuItem
            // 
            this.清零补运费ToolStripMenuItem.Name = "清零补运费ToolStripMenuItem";
            this.清零补运费ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.清零补运费ToolStripMenuItem.Text = "清零补运费";
            this.清零补运费ToolStripMenuItem.Click += new System.EventHandler(this.清零补运费ToolStripMenuItem_Click);
            // 
            // 为此客户设置地区ToolStripMenuItem
            // 
            this.为此客户设置地区ToolStripMenuItem.Name = "为此客户设置地区ToolStripMenuItem";
            this.为此客户设置地区ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.为此客户设置地区ToolStripMenuItem.Text = "为此客户设置地区";
            this.为此客户设置地区ToolStripMenuItem.Click += new System.EventHandler(this.为此客户设置地区ToolStripMenuItem_Click);
            // 
            // 查看客户区域对应表ToolStripMenuItem
            // 
            this.查看客户区域对应表ToolStripMenuItem.Name = "查看客户区域对应表ToolStripMenuItem";
            this.查看客户区域对应表ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.查看客户区域对应表ToolStripMenuItem.Text = "查看客户区域对应表";
            this.查看客户区域对应表ToolStripMenuItem.Click += new System.EventHandler(this.查看客户区域对应表ToolStripMenuItem_Click);
            // 
            // 导出PDFToolStripMenuItem
            // 
            this.导出PDFToolStripMenuItem.Name = "导出PDFToolStripMenuItem";
            this.导出PDFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.导出PDFToolStripMenuItem.Text = "导出PDF";
            this.导出PDFToolStripMenuItem.Click += new System.EventHandler(this.导出PDFToolStripMenuItem_Click);
            // 
            // Form运费结算
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.comboBoxYfjs);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpE);
            this.Controls.Add(this.dtpS);
            this.Name = "Form运费结算";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "运费结算";
            this.Load += new System.EventHandler(this.Form运费结算_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxYfjs;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpE;
        private System.Windows.Forms.DateTimePicker dtpS;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 二次堆码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拼车距离ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 手动计算运费ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 平方运费ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更多ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清零运费ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清零补运费ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 为此客户设置地区ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看客户区域对应表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动计算运费ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文信1区2区拼车ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出PDFToolStripMenuItem;
    }
}