namespace 工作数据分析.WinForm
{
    partial class Form排程查询
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGongdan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxGongxu = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.此工序已经完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.此工序未完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.整单完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消整单完工ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxKuhu = new System.Windows.Forms.TextBox();
            this.textBoxChanpin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工单:";
            // 
            // textBoxGongdan
            // 
            this.textBoxGongdan.Location = new System.Drawing.Point(53, 6);
            this.textBoxGongdan.Name = "textBoxGongdan";
            this.textBoxGongdan.Size = new System.Drawing.Size(113, 21);
            this.textBoxGongdan.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "工序:";
            // 
            // comboBoxGongxu
            // 
            this.comboBoxGongxu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxGongxu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxGongxu.FormattingEnabled = true;
            this.comboBoxGongxu.Location = new System.Drawing.Point(217, 7);
            this.comboBoxGongxu.Name = "comboBoxGongxu";
            this.comboBoxGongxu.Size = new System.Drawing.Size(146, 20);
            this.comboBoxGongxu.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv.Location = new System.Drawing.Point(1, 32);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(1185, 651);
            this.dgv.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.此工序已经完成ToolStripMenuItem,
            this.此工序未完成ToolStripMenuItem,
            this.toolStripSeparator1,
            this.整单完成ToolStripMenuItem,
            this.取消整单完工ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 98);
            // 
            // 此工序已经完成ToolStripMenuItem
            // 
            this.此工序已经完成ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.此工序已经完成ToolStripMenuItem.Name = "此工序已经完成ToolStripMenuItem";
            this.此工序已经完成ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.此工序已经完成ToolStripMenuItem.Text = "此工序已经完成";
            this.此工序已经完成ToolStripMenuItem.Click += new System.EventHandler(this.此工序已经完成ToolStripMenuItem_Click);
            // 
            // 此工序未完成ToolStripMenuItem
            // 
            this.此工序未完成ToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.此工序未完成ToolStripMenuItem.Name = "此工序未完成ToolStripMenuItem";
            this.此工序未完成ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.此工序未完成ToolStripMenuItem.Text = "此工序未完成";
            this.此工序未完成ToolStripMenuItem.Click += new System.EventHandler(this.此工序未完成ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // 整单完成ToolStripMenuItem
            // 
            this.整单完成ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.整单完成ToolStripMenuItem.Name = "整单完成ToolStripMenuItem";
            this.整单完成ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.整单完成ToolStripMenuItem.Text = "整单完工";
            this.整单完成ToolStripMenuItem.Click += new System.EventHandler(this.整单完成ToolStripMenuItem_Click);
            // 
            // 取消整单完工ToolStripMenuItem
            // 
            this.取消整单完工ToolStripMenuItem.ForeColor = System.Drawing.Color.Fuchsia;
            this.取消整单完工ToolStripMenuItem.Name = "取消整单完工ToolStripMenuItem";
            this.取消整单完工ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.取消整单完工ToolStripMenuItem.Text = "取消整单完工";
            this.取消整单完工ToolStripMenuItem.Click += new System.EventHandler(this.取消整单完工ToolStripMenuItem_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(755, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(68, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "查  询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "客户:";
            // 
            // textBoxKuhu
            // 
            this.textBoxKuhu.Location = new System.Drawing.Point(416, 5);
            this.textBoxKuhu.Name = "textBoxKuhu";
            this.textBoxKuhu.Size = new System.Drawing.Size(129, 21);
            this.textBoxKuhu.TabIndex = 2;
            // 
            // textBoxChanpin
            // 
            this.textBoxChanpin.Location = new System.Drawing.Point(599, 5);
            this.textBoxChanpin.Name = "textBoxChanpin";
            this.textBoxChanpin.Size = new System.Drawing.Size(129, 21);
            this.textBoxChanpin.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "产品:";
            // 
            // Form排程查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 685);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.comboBoxGongxu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxChanpin);
            this.Controls.Add(this.textBoxKuhu);
            this.Controls.Add(this.textBoxGongdan);
            this.Controls.Add(this.label1);
            this.Name = "Form排程查询";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "排程查询";
            this.Load += new System.EventHandler(this.Form排程查询_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGongdan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxGongxu;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 此工序已经完成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 此工序未完成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 整单完成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 取消整单完工ToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxKuhu;
        private System.Windows.Forms.TextBox textBoxChanpin;
        private System.Windows.Forms.Label label4;
    }
}