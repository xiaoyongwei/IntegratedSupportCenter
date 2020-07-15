namespace 工作数据分析.WinForm.WuLiu
{
    partial class Form计算运费弹窗
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
            this.textBoxBaodi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDiquYunfei = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxBaodi
            // 
            this.textBoxBaodi.Location = new System.Drawing.Point(77, 15);
            this.textBoxBaodi.Name = "textBoxBaodi";
            this.textBoxBaodi.Size = new System.Drawing.Size(100, 21);
            this.textBoxBaodi.TabIndex = 9;
            this.textBoxBaodi.Text = "1800";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "保底面积:";
            // 
            // textBoxDiquYunfei
            // 
            this.textBoxDiquYunfei.Location = new System.Drawing.Point(77, 58);
            this.textBoxDiquYunfei.Name = "textBoxDiquYunfei";
            this.textBoxDiquYunfei.Size = new System.Drawing.Size(100, 21);
            this.textBoxDiquYunfei.TabIndex = 0;
            this.textBoxDiquYunfei.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "地区运费:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(102, 108);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "计  算";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(12, 108);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "关  闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // Form计算运费弹窗
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(194, 153);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBaodi);
            this.Controls.Add(this.textBoxDiquYunfei);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form计算运费弹窗";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "计算运费";
            this.Load += new System.EventHandler(this.Form计算运费弹窗_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBaodi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDiquYunfei;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
    }
}