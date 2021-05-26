namespace 工作数据分析.WinForm
{
    partial class Form回单导入
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpS = new System.Windows.Forms.DateTimePicker();
            this.dtpE = new System.Windows.Forms.DateTimePicker();
            this.buttonImport = new System.Windows.Forms.Button();
            this.textBoxShowResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "结束时间:";
            // 
            // dtpS
            // 
            this.dtpS.CustomFormat = "yyyy-MM-dd";
            this.dtpS.Enabled = false;
            this.dtpS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpS.Location = new System.Drawing.Point(77, 3);
            this.dtpS.Name = "dtpS";
            this.dtpS.Size = new System.Drawing.Size(99, 21);
            this.dtpS.TabIndex = 2;
            // 
            // dtpE
            // 
            this.dtpE.CustomFormat = "yyyy-MM-dd";
            this.dtpE.Enabled = false;
            this.dtpE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpE.Location = new System.Drawing.Point(77, 37);
            this.dtpE.Name = "dtpE";
            this.dtpE.Size = new System.Drawing.Size(99, 21);
            this.dtpE.TabIndex = 2;
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(101, 64);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 3;
            this.buttonImport.Text = "开始导入";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // textBoxShowResult
            // 
            this.textBoxShowResult.Location = new System.Drawing.Point(-1, 93);
            this.textBoxShowResult.Multiline = true;
            this.textBoxShowResult.Name = "textBoxShowResult";
            this.textBoxShowResult.ReadOnly = true;
            this.textBoxShowResult.Size = new System.Drawing.Size(197, 245);
            this.textBoxShowResult.TabIndex = 4;
            // 
            // Form回单导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 339);
            this.Controls.Add(this.textBoxShowResult);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.dtpE);
            this.Controls.Add(this.dtpS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form回单导入";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "回单导入";
            this.Load += new System.EventHandler(this.Form回单导入_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpS;
        private System.Windows.Forms.DateTimePicker dtpE;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.TextBox textBoxShowResult;
    }
}