namespace 工作数据分析.WinForm.huidan
{
    partial class Form回单信息
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
            this.textBoxshdh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxshrq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxkhjc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxshsj = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxycyy = new System.Windows.Forms.TextBox();
            this.textBoxyccl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "送货单号";
            // 
            // textBoxshdh
            // 
            this.textBoxshdh.Location = new System.Drawing.Point(71, 6);
            this.textBoxshdh.Name = "textBoxshdh";
            this.textBoxshdh.ReadOnly = true;
            this.textBoxshdh.Size = new System.Drawing.Size(147, 21);
            this.textBoxshdh.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "送货日期";
            // 
            // textBoxshrq
            // 
            this.textBoxshrq.Location = new System.Drawing.Point(71, 33);
            this.textBoxshrq.Name = "textBoxshrq";
            this.textBoxshrq.ReadOnly = true;
            this.textBoxshrq.Size = new System.Drawing.Size(147, 21);
            this.textBoxshrq.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "客户简称";
            // 
            // textBoxkhjc
            // 
            this.textBoxkhjc.Location = new System.Drawing.Point(71, 64);
            this.textBoxkhjc.Name = "textBoxkhjc";
            this.textBoxkhjc.ReadOnly = true;
            this.textBoxkhjc.Size = new System.Drawing.Size(147, 21);
            this.textBoxkhjc.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "送货司机";
            // 
            // textBoxshsj
            // 
            this.textBoxshsj.Location = new System.Drawing.Point(71, 91);
            this.textBoxshsj.Name = "textBoxshsj";
            this.textBoxshsj.ReadOnly = true;
            this.textBoxshsj.Size = new System.Drawing.Size(147, 21);
            this.textBoxshsj.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "异常原因";
            // 
            // textBoxycyy
            // 
            this.textBoxycyy.Location = new System.Drawing.Point(12, 144);
            this.textBoxycyy.Multiline = true;
            this.textBoxycyy.Name = "textBoxycyy";
            this.textBoxycyy.Size = new System.Drawing.Size(206, 97);
            this.textBoxycyy.TabIndex = 1;
            // 
            // textBoxyccl
            // 
            this.textBoxyccl.Location = new System.Drawing.Point(12, 265);
            this.textBoxyccl.Multiline = true;
            this.textBoxyccl.Name = "textBoxyccl";
            this.textBoxyccl.Size = new System.Drawing.Size(206, 85);
            this.textBoxyccl.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "异常处理";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(143, 360);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "保  存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Form回单信息
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 390);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxyccl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxycyy);
            this.Controls.Add(this.textBoxshsj);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxshrq);
            this.Controls.Add(this.textBoxkhjc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxshdh);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form回单信息";
            this.ShowIcon = false;
            this.Text = "回单信息";
            this.Load += new System.EventHandler(this.Form回单信息_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxshdh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxshrq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxkhjc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxshsj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxycyy;
        private System.Windows.Forms.TextBox textBoxyccl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSave;
    }
}