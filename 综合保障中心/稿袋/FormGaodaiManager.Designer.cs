namespace 综合保障中心.稿袋
{
    partial class FormGaodaiManager
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
            this.稿袋自动生成系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加稿袋编号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量导入ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCustomer = new System.Windows.Forms.TextBox();
            this.textBoxProduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonShowAll = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.共用此稿袋ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.报废ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看明细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看历史ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更改此稿袋的信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.稿袋自动生成系统ToolStripMenuItem,
            this.增加稿袋编号ToolStripMenuItem,
            this.导出ExcelToolStripMenuItem,
            this.批量导入ExcelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 稿袋自动生成系统ToolStripMenuItem
            // 
            this.稿袋自动生成系统ToolStripMenuItem.Name = "稿袋自动生成系统ToolStripMenuItem";
            this.稿袋自动生成系统ToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.稿袋自动生成系统ToolStripMenuItem.Text = "稿袋自动生成系统";
            this.稿袋自动生成系统ToolStripMenuItem.Click += new System.EventHandler(this.稿袋自动生成系统ToolStripMenuItem_Click);
            // 
            // 增加稿袋编号ToolStripMenuItem
            // 
            this.增加稿袋编号ToolStripMenuItem.Name = "增加稿袋编号ToolStripMenuItem";
            this.增加稿袋编号ToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.增加稿袋编号ToolStripMenuItem.Text = "增加稿袋编号";
            this.增加稿袋编号ToolStripMenuItem.Click += new System.EventHandler(this.增加稿袋编号ToolStripMenuItem_Click);
            // 
            // 导出ExcelToolStripMenuItem
            // 
            this.导出ExcelToolStripMenuItem.Name = "导出ExcelToolStripMenuItem";
            this.导出ExcelToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.导出ExcelToolStripMenuItem.Text = "导出Excel";
            // 
            // 批量导入ExcelToolStripMenuItem
            // 
            this.批量导入ExcelToolStripMenuItem.Name = "批量导入ExcelToolStripMenuItem";
            this.批量导入ExcelToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.批量导入ExcelToolStripMenuItem.Text = "批量导入Excel";
            this.批量导入ExcelToolStripMenuItem.Click += new System.EventHandler(this.批量导入ExcelToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "客户:";
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.Location = new System.Drawing.Point(44, 32);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.Size = new System.Drawing.Size(199, 21);
            this.textBoxCustomer.TabIndex = 3;
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.Location = new System.Drawing.Point(313, 31);
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.Size = new System.Drawing.Size(199, 21);
            this.textBoxProduct.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "产品名称:";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(526, 29);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(70, 23);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "查询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonShowAll
            // 
            this.buttonShowAll.Location = new System.Drawing.Point(609, 30);
            this.buttonShowAll.Name = "buttonShowAll";
            this.buttonShowAll.Size = new System.Drawing.Size(70, 23);
            this.buttonShowAll.TabIndex = 6;
            this.buttonShowAll.Text = "显示全部";
            this.buttonShowAll.UseVisualStyleBackColor = true;
            this.buttonShowAll.Click += new System.EventHandler(this.buttonShowAll_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv.Location = new System.Drawing.Point(3, 59);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(681, 346);
            this.dgv.TabIndex = 8;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AllowMerge = false;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.共用此稿袋ToolStripMenuItem,
            this.报废ToolStripMenuItem,
            this.查看明细ToolStripMenuItem,
            this.查看历史ToolStripMenuItem,
            this.更改此稿袋的信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.ShowItemToolTips = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 114);
            // 
            // 共用此稿袋ToolStripMenuItem
            // 
            this.共用此稿袋ToolStripMenuItem.Name = "共用此稿袋ToolStripMenuItem";
            this.共用此稿袋ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.共用此稿袋ToolStripMenuItem.Text = "共用此稿袋";
            this.共用此稿袋ToolStripMenuItem.Click += new System.EventHandler(this.共用此稿袋ToolStripMenuItem_Click);
            // 
            // 报废ToolStripMenuItem
            // 
            this.报废ToolStripMenuItem.Name = "报废ToolStripMenuItem";
            this.报废ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.报废ToolStripMenuItem.Text = "报废";
            this.报废ToolStripMenuItem.Click += new System.EventHandler(this.报废ToolStripMenuItem_Click);
            // 
            // 查看明细ToolStripMenuItem
            // 
            this.查看明细ToolStripMenuItem.Name = "查看明细ToolStripMenuItem";
            this.查看明细ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.查看明细ToolStripMenuItem.Text = "查看明细";
            this.查看明细ToolStripMenuItem.Click += new System.EventHandler(this.查看明细ToolStripMenuItem_Click);
            // 
            // 查看历史ToolStripMenuItem
            // 
            this.查看历史ToolStripMenuItem.Name = "查看历史ToolStripMenuItem";
            this.查看历史ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.查看历史ToolStripMenuItem.Text = "查看历史";
            this.查看历史ToolStripMenuItem.Click += new System.EventHandler(this.查看历史ToolStripMenuItem_Click);
            // 
            // 更改此稿袋的信息ToolStripMenuItem
            // 
            this.更改此稿袋的信息ToolStripMenuItem.Name = "更改此稿袋的信息ToolStripMenuItem";
            this.更改此稿袋的信息ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.更改此稿袋的信息ToolStripMenuItem.Text = "更改此稿袋";
            this.更改此稿袋的信息ToolStripMenuItem.Click += new System.EventHandler(this.更改此稿袋的信息ToolStripMenuItem_Click);
            // 
            // FormGaodaiManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 411);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.buttonShowAll);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCustomer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGaodaiManager";
            this.ShowIcon = false;
            this.Text = "稿袋管理";
            this.Load += new System.EventHandler(this.FormGaodaiManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 稿袋自动生成系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加稿袋编号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批量导入ExcelToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCustomer;
        private System.Windows.Forms.TextBox textBoxProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonShowAll;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 共用此稿袋ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 报废ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看明细ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看历史ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更改此稿袋的信息ToolStripMenuItem;
    }
}