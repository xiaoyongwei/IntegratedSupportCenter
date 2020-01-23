namespace 工作数据分析.WinForm
{
    partial class Form成品仓库数据
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
            this.dateTimePicker开始 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker结束 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间:";
            // 
            // dateTimePicker开始
            // 
            this.dateTimePicker开始.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker开始.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker开始.Location = new System.Drawing.Point(80, 3);
            this.dateTimePicker开始.Name = "dateTimePicker开始";
            this.dateTimePicker开始.Size = new System.Drawing.Size(151, 21);
            this.dateTimePicker开始.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "结束时间:";
            // 
            // dateTimePicker结束
            // 
            this.dateTimePicker结束.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker结束.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker结束.Location = new System.Drawing.Point(308, 3);
            this.dateTimePicker结束.Name = "dateTimePicker结束";
            this.dateTimePicker结束.Size = new System.Drawing.Size(151, 21);
            this.dateTimePicker结束.TabIndex = 1;
            // 
            // Form成品仓库数据
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 566);
            this.Controls.Add(this.dateTimePicker结束);
            this.Controls.Add(this.dateTimePicker开始);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form成品仓库数据";
            this.Text = "Form成品仓库数据";
            this.Load += new System.EventHandler(this.Form成品仓库数据_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker开始;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker结束;
    }
}