namespace 综合保障中心
{
    partial class FormYunfei
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
            this.textBoxBottomSquare = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCustomerCount = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textBoxgongji = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ColumnKm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnYunfei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnZxf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnZyf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2ciCbc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2ciduima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxBottomSquare
            // 
            this.textBoxBottomSquare.Location = new System.Drawing.Point(78, 12);
            this.textBoxBottomSquare.Name = "textBoxBottomSquare";
            this.textBoxBottomSquare.Size = new System.Drawing.Size(62, 21);
            this.textBoxBottomSquare.TabIndex = 0;
            this.textBoxBottomSquare.Text = "2200";
            this.textBoxBottomSquare.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCustomerCount_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "保底平方:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgv);
            this.groupBox1.Location = new System.Drawing.Point(4, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 343);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "送货公里数和面积";
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnKm,
            this.ColumnArea,
            this.ColumnYunfei,
            this.ColumnZxf,
            this.ColumnZyf,
            this.Column2ciCbc,
            this.Column2ciduima});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(3, 17);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(481, 323);
            this.dgv.TabIndex = 0;
            this.dgv.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_DefaultValuesNeeded);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "客户数:";
            // 
            // textBoxCustomerCount
            // 
            this.textBoxCustomerCount.Location = new System.Drawing.Point(205, 12);
            this.textBoxCustomerCount.Name = "textBoxCustomerCount";
            this.textBoxCustomerCount.Size = new System.Drawing.Size(31, 21);
            this.textBoxCustomerCount.TabIndex = 0;
            this.textBoxCustomerCount.Text = "1";
            this.textBoxCustomerCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCustomerCount_KeyPress);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(242, 10);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 4;
            this.buttonSubmit.Text = "开始计算";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // textBoxgongji
            // 
            this.textBoxgongji.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxgongji.Location = new System.Drawing.Point(75, 39);
            this.textBoxgongji.Name = "textBoxgongji";
            this.textBoxgongji.ReadOnly = true;
            this.textBoxgongji.Size = new System.Drawing.Size(242, 21);
            this.textBoxgongji.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "在最前";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ColumnKm
            // 
            this.ColumnKm.HeaderText = "公里";
            this.ColumnKm.Name = "ColumnKm";
            this.ColumnKm.Width = 54;
            // 
            // ColumnArea
            // 
            this.ColumnArea.HeaderText = "面积";
            this.ColumnArea.Name = "ColumnArea";
            this.ColumnArea.Width = 54;
            // 
            // ColumnYunfei
            // 
            this.ColumnYunfei.HeaderText = "运费";
            this.ColumnYunfei.Name = "ColumnYunfei";
            this.ColumnYunfei.ReadOnly = true;
            this.ColumnYunfei.Width = 54;
            // 
            // ColumnZxf
            // 
            this.ColumnZxf.HeaderText = "装卸费";
            this.ColumnZxf.Name = "ColumnZxf";
            this.ColumnZxf.ReadOnly = true;
            this.ColumnZxf.Width = 66;
            // 
            // ColumnZyf
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ColumnZyf.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnZyf.HeaderText = "总运费";
            this.ColumnZyf.Name = "ColumnZyf";
            this.ColumnZyf.ReadOnly = true;
            this.ColumnZyf.Width = 66;
            // 
            // Column2ciCbc
            // 
            this.Column2ciCbc.HeaderText = "2次";
            this.Column2ciCbc.Name = "Column2ciCbc";
            this.Column2ciCbc.Width = 29;
            // 
            // Column2ciduima
            // 
            this.Column2ciduima.HeaderText = "2次费";
            this.Column2ciduima.Name = "Column2ciduima";
            this.Column2ciduima.ReadOnly = true;
            this.Column2ciduima.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2ciduima.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2ciduima.Width = 41;
            // 
            // FormYunfei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 414);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBoxgongji);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCustomerCount);
            this.Controls.Add(this.textBoxBottomSquare);
            this.Name = "FormYunfei";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "运费计算";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormYunfei_FormClosing);
            this.Load += new System.EventHandler(this.FormYunfei_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBottomSquare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCustomerCount;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textBoxgongji;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnYunfei;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnZxf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnZyf;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2ciCbc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2ciduima;
    }
}