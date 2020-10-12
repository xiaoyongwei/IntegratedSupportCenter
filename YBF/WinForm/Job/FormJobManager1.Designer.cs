namespace YBF.WinForm.Job
{
    partial class FormJobManager1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonInit = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxChanpin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxKehu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxGdh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxShebei = new System.Windows.Forms.ComboBox();
            this.comboBoxShenhe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerE = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerS = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvYijie = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewFile = new System.Windows.Forms.ListView();
            this.columnHeaderPpd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWjm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRiqi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dgvPdf = new System.Windows.Forms.DataGridView();
            this.dgvCtp = new System.Windows.Forms.DataGridView();
            this.ColumnShuxing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCanshu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYijie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtp)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonInit);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSearch);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxChanpin);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxKehu);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxGdh);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxShebei);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxShenhe);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePickerE);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePickerS);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgvYijie);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(699, 450);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonInit
            // 
            this.buttonInit.Location = new System.Drawing.Point(622, 34);
            this.buttonInit.Name = "buttonInit";
            this.buttonInit.Size = new System.Drawing.Size(63, 23);
            this.buttonInit.TabIndex = 9;
            this.buttonInit.Text = "重  置";
            this.buttonInit.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(553, 34);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(63, 23);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "查  询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(504, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "设备:";
            // 
            // textBoxChanpin
            // 
            this.textBoxChanpin.Location = new System.Drawing.Point(302, 34);
            this.textBoxChanpin.Name = "textBoxChanpin";
            this.textBoxChanpin.Size = new System.Drawing.Size(245, 21);
            this.textBoxChanpin.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "产品:";
            // 
            // textBoxKehu
            // 
            this.textBoxKehu.Location = new System.Drawing.Point(64, 32);
            this.textBoxKehu.Name = "textBoxKehu";
            this.textBoxKehu.Size = new System.Drawing.Size(186, 21);
            this.textBoxKehu.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "客户:";
            // 
            // textBoxGdh
            // 
            this.textBoxGdh.Location = new System.Drawing.Point(408, 6);
            this.textBoxGdh.Name = "textBoxGdh";
            this.textBoxGdh.Size = new System.Drawing.Size(86, 21);
            this.textBoxGdh.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "稿袋号:";
            // 
            // comboBoxShebei
            // 
            this.comboBoxShebei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShebei.FormattingEnabled = true;
            this.comboBoxShebei.Location = new System.Drawing.Point(545, 6);
            this.comboBoxShebei.Name = "comboBoxShebei";
            this.comboBoxShebei.Size = new System.Drawing.Size(116, 20);
            this.comboBoxShebei.TabIndex = 5;
            // 
            // comboBoxShenhe
            // 
            this.comboBoxShenhe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShenhe.FormattingEnabled = true;
            this.comboBoxShenhe.Items.AddRange(new object[] {
            "N-否",
            "Y-是"});
            this.comboBoxShenhe.Location = new System.Drawing.Point(302, 6);
            this.comboBoxShenhe.Name = "comboBoxShenhe";
            this.comboBoxShenhe.Size = new System.Drawing.Size(52, 20);
            this.comboBoxShenhe.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "审核:";
            // 
            // dateTimePickerE
            // 
            this.dateTimePickerE.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerE.Location = new System.Drawing.Point(160, 5);
            this.dateTimePickerE.Name = "dateTimePickerE";
            this.dateTimePickerE.Size = new System.Drawing.Size(90, 21);
            this.dateTimePickerE.TabIndex = 3;
            // 
            // dateTimePickerS
            // 
            this.dateTimePickerS.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerS.Location = new System.Drawing.Point(66, 5);
            this.dateTimePickerS.Name = "dateTimePickerS";
            this.dateTimePickerS.Size = new System.Drawing.Size(90, 21);
            this.dateTimePickerS.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "工单日期:";
            // 
            // dgvYijie
            // 
            this.dgvYijie.AllowUserToAddRows = false;
            this.dgvYijie.AllowUserToDeleteRows = false;
            this.dgvYijie.AllowUserToResizeColumns = false;
            this.dgvYijie.AllowUserToResizeRows = false;
            this.dgvYijie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvYijie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvYijie.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvYijie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYijie.Location = new System.Drawing.Point(3, 63);
            this.dgvYijie.Name = "dgvYijie";
            this.dgvYijie.ReadOnly = true;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvYijie.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvYijie.RowTemplate.Height = 23;
            this.dgvYijie.Size = new System.Drawing.Size(693, 240);
            this.dgvYijie.TabIndex = 0;
            this.dgvYijie.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYijie_CellClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewFile);
            this.splitContainer2.Panel1.Controls.Add(this.dgvPdf);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvCtp);
            this.splitContainer2.Size = new System.Drawing.Size(699, 138);
            this.splitContainer2.SplitterDistance = 347;
            this.splitContainer2.TabIndex = 0;
            // 
            // listViewFile
            // 
            this.listViewFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPpd,
            this.columnHeaderWjm,
            this.columnHeaderRiqi,
            this.columnHeaderSize,
            this.columnHeaderPath});
            this.listViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFile.FullRowSelect = true;
            this.listViewFile.GridLines = true;
            this.listViewFile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewFile.HideSelection = false;
            this.listViewFile.Location = new System.Drawing.Point(0, 0);
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Size = new System.Drawing.Size(347, 138);
            this.listViewFile.TabIndex = 2;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Details;
            this.listViewFile.ItemActivate += new System.EventHandler(this.listViewFile_ItemActivate);
            this.listViewFile.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewFile_ItemDrag);
            // 
            // columnHeaderPpd
            // 
            this.columnHeaderPpd.Text = "匹配度";
            // 
            // columnHeaderWjm
            // 
            this.columnHeaderWjm.Text = "文件名称";
            this.columnHeaderWjm.Width = 313;
            // 
            // columnHeaderRiqi
            // 
            this.columnHeaderRiqi.Text = "最后修改日期";
            this.columnHeaderRiqi.Width = 140;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "大小";
            // 
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "所在目录";
            // 
            // dgvPdf
            // 
            this.dgvPdf.AllowUserToAddRows = false;
            this.dgvPdf.AllowUserToDeleteRows = false;
            this.dgvPdf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPdf.Location = new System.Drawing.Point(0, 0);
            this.dgvPdf.Name = "dgvPdf";
            this.dgvPdf.ReadOnly = true;
            this.dgvPdf.RowTemplate.Height = 23;
            this.dgvPdf.Size = new System.Drawing.Size(347, 138);
            this.dgvPdf.TabIndex = 1;
            // 
            // dgvCtp
            // 
            this.dgvCtp.AllowUserToAddRows = false;
            this.dgvCtp.AllowUserToDeleteRows = false;
            this.dgvCtp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCtp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCtp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnShuxing,
            this.ColumnCanshu});
            this.dgvCtp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtp.Location = new System.Drawing.Point(0, 0);
            this.dgvCtp.Name = "dgvCtp";
            this.dgvCtp.ReadOnly = true;
            this.dgvCtp.RowHeadersVisible = false;
            this.dgvCtp.RowTemplate.Height = 23;
            this.dgvCtp.Size = new System.Drawing.Size(348, 138);
            this.dgvCtp.TabIndex = 1;
            // 
            // ColumnShuxing
            // 
            this.ColumnShuxing.HeaderText = "属性";
            this.ColumnShuxing.Name = "ColumnShuxing";
            this.ColumnShuxing.ReadOnly = true;
            // 
            // ColumnCanshu
            // 
            this.ColumnCanshu.HeaderText = "参数";
            this.ColumnCanshu.Name = "ColumnCanshu";
            this.ColumnCanshu.ReadOnly = true;
            // 
            // FormJobManager1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormJobManager1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "出版作业管理";
            this.Load += new System.EventHandler(this.FormJobManager1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYijie)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonInit;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxChanpin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxKehu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxGdh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxShebei;
        private System.Windows.Forms.ComboBox comboBoxShenhe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerE;
        private System.Windows.Forms.DateTimePicker dateTimePickerS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvYijie;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvPdf;
        private System.Windows.Forms.DataGridView dgvCtp;
        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.ColumnHeader columnHeaderWjm;
        private System.Windows.Forms.ColumnHeader columnHeaderRiqi;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ColumnHeader columnHeaderPath;
        private System.Windows.Forms.ColumnHeader columnHeaderPpd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShuxing;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCanshu;
    }
}