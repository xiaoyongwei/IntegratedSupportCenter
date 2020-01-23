using System;
namespace 工作数据
{
    partial class Form每日数据
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonShuaxin = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonQuite = new System.Windows.Forms.Button();
            this.buttonShenhe = new System.Windows.Forms.Button();
            this.buttonFanshenhe = new System.Windows.Forms.Button();
            this.labelOrtherInfo = new System.Windows.Forms.Label();
            this.buttonUpDay = new System.Windows.Forms.Button();
            this.buttonDownDay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv.Location = new System.Drawing.Point(1, 34);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(1074, 423);
            this.dgv.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy年MM月dd日";
            this.dateTimePicker1.Font = new System.Drawing.Font("华文细黑", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(45, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(140, 24);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "日期:";
            // 
            // buttonShuaxin
            // 
            this.buttonShuaxin.Location = new System.Drawing.Point(191, 5);
            this.buttonShuaxin.Name = "buttonShuaxin";
            this.buttonShuaxin.Size = new System.Drawing.Size(75, 23);
            this.buttonShuaxin.TabIndex = 3;
            this.buttonShuaxin.Text = "刷新(F5)";
            this.buttonShuaxin.UseVisualStyleBackColor = true;
            this.buttonShuaxin.Click += new System.EventHandler(this.buttonShuaxin_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(272, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(93, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "保存(Ctrl+S)";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonQuite
            // 
            this.buttonQuite.Location = new System.Drawing.Point(645, 6);
            this.buttonQuite.Name = "buttonQuite";
            this.buttonQuite.Size = new System.Drawing.Size(89, 23);
            this.buttonQuite.TabIndex = 3;
            this.buttonQuite.Text = "退出(Ctrl+Q)";
            this.buttonQuite.UseVisualStyleBackColor = true;
            this.buttonQuite.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonShenhe
            // 
            this.buttonShenhe.Location = new System.Drawing.Point(371, 5);
            this.buttonShenhe.Name = "buttonShenhe";
            this.buttonShenhe.Size = new System.Drawing.Size(66, 23);
            this.buttonShenhe.TabIndex = 3;
            this.buttonShenhe.Text = "审核(F4)";
            this.buttonShenhe.UseVisualStyleBackColor = true;
            this.buttonShenhe.Click += new System.EventHandler(this.buttonShenhe_Click);
            // 
            // buttonFanshenhe
            // 
            this.buttonFanshenhe.Location = new System.Drawing.Point(443, 5);
            this.buttonFanshenhe.Name = "buttonFanshenhe";
            this.buttonFanshenhe.Size = new System.Drawing.Size(66, 23);
            this.buttonFanshenhe.TabIndex = 3;
            this.buttonFanshenhe.Text = "反审核";
            this.buttonFanshenhe.UseVisualStyleBackColor = true;
            this.buttonFanshenhe.Click += new System.EventHandler(this.buttonFanshenhe_Click);
            // 
            // labelOrtherInfo
            // 
            this.labelOrtherInfo.AutoSize = true;
            this.labelOrtherInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelOrtherInfo.Location = new System.Drawing.Point(0, 473);
            this.labelOrtherInfo.Name = "labelOrtherInfo";
            this.labelOrtherInfo.Size = new System.Drawing.Size(161, 12);
            this.labelOrtherInfo.TabIndex = 4;
            this.labelOrtherInfo.Text = "最后修改时间：，修改人：。";
            // 
            // buttonUpDay
            // 
            this.buttonUpDay.Location = new System.Drawing.Point(515, 6);
            this.buttonUpDay.Name = "buttonUpDay";
            this.buttonUpDay.Size = new System.Drawing.Size(59, 23);
            this.buttonUpDay.TabIndex = 5;
            this.buttonUpDay.Text = "前一日";
            this.buttonUpDay.UseVisualStyleBackColor = true;
            this.buttonUpDay.Click += new System.EventHandler(this.buttonUpDay_Click);
            // 
            // buttonDownDay
            // 
            this.buttonDownDay.Location = new System.Drawing.Point(580, 7);
            this.buttonDownDay.Name = "buttonDownDay";
            this.buttonDownDay.Size = new System.Drawing.Size(59, 23);
            this.buttonDownDay.TabIndex = 5;
            this.buttonDownDay.Text = "后一日";
            this.buttonDownDay.UseVisualStyleBackColor = true;
            this.buttonDownDay.Click += new System.EventHandler(this.buttonUpDay_Click);
            // 
            // Form每日数据
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 485);
            this.Controls.Add(this.buttonDownDay);
            this.Controls.Add(this.buttonUpDay);
            this.Controls.Add(this.labelOrtherInfo);
            this.Controls.Add(this.buttonFanshenhe);
            this.Controls.Add(this.buttonShenhe);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonQuite);
            this.Controls.Add(this.buttonShuaxin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dgv);
            this.Name = "Form每日数据";
            this.ShowIcon = false;
            this.Text = "每日数据";
            this.Load += new System.EventHandler(this.Form每日数据_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonShuaxin;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonQuite;
        private System.Windows.Forms.Button buttonShenhe;
        private System.Windows.Forms.Button buttonFanshenhe;
        private System.Windows.Forms.Label labelOrtherInfo;
        private System.Windows.Forms.Button buttonUpDay;
        private System.Windows.Forms.Button buttonDownDay;
    }
}