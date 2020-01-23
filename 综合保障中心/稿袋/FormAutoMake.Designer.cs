namespace 综合保障中心
{
    partial class FormAutoMake
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxChanpin = new System.Windows.Forms.TextBox();
            this.buttonMake = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxGaodai = new System.Windows.Forms.TextBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ColumnCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChanpin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGaodai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选客户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选产品名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选稿袋ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制稿袋号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.和此客户产品共用一个稿袋ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxCustomer = new System.Windows.Forms.TextBox();
            this.radioButtonShunxu = new System.Windows.Forms.RadioButton();
            this.radioButtonKongbai = new System.Windows.Forms.RadioButton();
            this.radioButtonZhiding = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "成品名称：";
            // 
            // textBoxChanpin
            // 
            this.textBoxChanpin.Location = new System.Drawing.Point(73, 41);
            this.textBoxChanpin.Name = "textBoxChanpin";
            this.textBoxChanpin.Size = new System.Drawing.Size(347, 21);
            this.textBoxChanpin.TabIndex = 1;
            this.textBoxChanpin.TextChanged += new System.EventHandler(this.textBoxCustomer_TextChanged);
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(438, 89);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(87, 42);
            this.buttonMake.TabIndex = 5;
            this.buttonMake.Text = "生成稿袋";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "客  户：";
            // 
            // textBoxGaodai
            // 
            this.textBoxGaodai.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxGaodai.Font = new System.Drawing.Font("楷体", 60F);
            this.textBoxGaodai.ForeColor = System.Drawing.Color.Red;
            this.textBoxGaodai.Location = new System.Drawing.Point(2, 78);
            this.textBoxGaodai.MaxLength = 4;
            this.textBoxGaodai.Multiline = true;
            this.textBoxGaodai.Name = "textBoxGaodai";
            this.textBoxGaodai.ReadOnly = true;
            this.textBoxGaodai.Size = new System.Drawing.Size(418, 87);
            this.textBoxGaodai.TabIndex = 2;
            this.textBoxGaodai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(438, 137);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(87, 31);
            this.buttonCopy.TabIndex = 6;
            this.buttonCopy.Text = "复制稿袋号";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCustomer,
            this.ColumnChanpin,
            this.ColumnGaodai});
            this.dgv.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv.Location = new System.Drawing.Point(2, 175);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(532, 427);
            this.dgv.TabIndex = 3;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // ColumnCustomer
            // 
            this.ColumnCustomer.HeaderText = "客户";
            this.ColumnCustomer.Name = "ColumnCustomer";
            this.ColumnCustomer.ReadOnly = true;
            this.ColumnCustomer.Width = 54;
            // 
            // ColumnChanpin
            // 
            this.ColumnChanpin.HeaderText = "产品";
            this.ColumnChanpin.Name = "ColumnChanpin";
            this.ColumnChanpin.ReadOnly = true;
            this.ColumnChanpin.Width = 54;
            // 
            // ColumnGaodai
            // 
            this.ColumnGaodai.HeaderText = "稿袋";
            this.ColumnGaodai.Name = "ColumnGaodai";
            this.ColumnGaodai.ReadOnly = true;
            this.ColumnGaodai.Width = 54;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选客户ToolStripMenuItem,
            this.选产品名ToolStripMenuItem,
            this.选稿袋ToolStripMenuItem,
            this.复制稿袋号ToolStripMenuItem,
            this.和此客户产品共用一个稿袋ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 114);
            // 
            // 选客户ToolStripMenuItem
            // 
            this.选客户ToolStripMenuItem.Name = "选客户ToolStripMenuItem";
            this.选客户ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.选客户ToolStripMenuItem.Text = "选客户";
            this.选客户ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 选产品名ToolStripMenuItem
            // 
            this.选产品名ToolStripMenuItem.Name = "选产品名ToolStripMenuItem";
            this.选产品名ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.选产品名ToolStripMenuItem.Text = "选产品名称";
            this.选产品名ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 选稿袋ToolStripMenuItem
            // 
            this.选稿袋ToolStripMenuItem.Name = "选稿袋ToolStripMenuItem";
            this.选稿袋ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.选稿袋ToolStripMenuItem.Text = "选稿袋";
            this.选稿袋ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 复制稿袋号ToolStripMenuItem
            // 
            this.复制稿袋号ToolStripMenuItem.Name = "复制稿袋号ToolStripMenuItem";
            this.复制稿袋号ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.复制稿袋号ToolStripMenuItem.Text = "复制稿袋号";
            this.复制稿袋号ToolStripMenuItem.Click += new System.EventHandler(this.复制稿袋号ToolStripMenuItem_Click);
            // 
            // 和此客户产品共用一个稿袋ToolStripMenuItem
            // 
            this.和此客户产品共用一个稿袋ToolStripMenuItem.Name = "和此客户产品共用一个稿袋ToolStripMenuItem";
            this.和此客户产品共用一个稿袋ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.和此客户产品共用一个稿袋ToolStripMenuItem.Text = "共用一个稿袋";
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.Location = new System.Drawing.Point(73, 12);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.Size = new System.Drawing.Size(347, 21);
            this.textBoxCustomer.TabIndex = 0;
            this.textBoxCustomer.TextChanged += new System.EventHandler(this.textBoxCustomer_TextChanged);
            // 
            // radioButtonShunxu
            // 
            this.radioButtonShunxu.AutoSize = true;
            this.radioButtonShunxu.Checked = true;
            this.radioButtonShunxu.Location = new System.Drawing.Point(436, 13);
            this.radioButtonShunxu.Name = "radioButtonShunxu";
            this.radioButtonShunxu.Size = new System.Drawing.Size(83, 16);
            this.radioButtonShunxu.TabIndex = 7;
            this.radioButtonShunxu.TabStop = true;
            this.radioButtonShunxu.Text = "按稿袋顺序";
            this.radioButtonShunxu.UseVisualStyleBackColor = true;
            this.radioButtonShunxu.CheckedChanged += new System.EventHandler(this.radioButtonShunxu_CheckedChanged);
            // 
            // radioButtonKongbai
            // 
            this.radioButtonKongbai.AutoSize = true;
            this.radioButtonKongbai.Location = new System.Drawing.Point(436, 37);
            this.radioButtonKongbai.Name = "radioButtonKongbai";
            this.radioButtonKongbai.Size = new System.Drawing.Size(83, 16);
            this.radioButtonKongbai.TabIndex = 7;
            this.radioButtonKongbai.Text = "挑空白稿袋";
            this.radioButtonKongbai.UseVisualStyleBackColor = true;
            this.radioButtonKongbai.CheckedChanged += new System.EventHandler(this.radioButtonKongbai_CheckedChanged);
            // 
            // radioButtonZhiding
            // 
            this.radioButtonZhiding.AutoSize = true;
            this.radioButtonZhiding.Location = new System.Drawing.Point(436, 59);
            this.radioButtonZhiding.Name = "radioButtonZhiding";
            this.radioButtonZhiding.Size = new System.Drawing.Size(83, 16);
            this.radioButtonZhiding.TabIndex = 7;
            this.radioButtonZhiding.Text = "指定稿袋号";
            this.radioButtonZhiding.UseVisualStyleBackColor = true;
            this.radioButtonZhiding.CheckedChanged += new System.EventHandler(this.radioButtonZhiding_CheckedChanged);
            // 
            // FormAutoMake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 604);
            this.Controls.Add(this.radioButtonZhiding);
            this.Controls.Add(this.radioButtonKongbai);
            this.Controls.Add(this.radioButtonShunxu);
            this.Controls.Add(this.textBoxCustomer);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.textBoxGaodai);
            this.Controls.Add(this.buttonMake);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxChanpin);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FormAutoMake";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "稿袋自动生成系统";
            this.Load += new System.EventHandler(this.FormAutoMake_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxChanpin;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxGaodai;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox textBoxCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChanpin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGaodai;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选客户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选产品名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选稿袋ToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButtonShunxu;
        private System.Windows.Forms.RadioButton radioButtonKongbai;
        private System.Windows.Forms.ToolStripMenuItem 复制稿袋号ToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButtonZhiding;
        private System.Windows.Forms.ToolStripMenuItem 和此客户产品共用一个稿袋ToolStripMenuItem;
    }
}

