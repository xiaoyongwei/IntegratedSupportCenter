
namespace 工作数据分析.WinForm.DataUpload
{
    partial class Form数据导入
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
            this.textBoxZhibanRuku = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "纸板入库Excel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "纸板库存Excel";
            // 
            // textBoxZhibanRuku
            // 
            this.textBoxZhibanRuku.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxZhibanRuku.Location = new System.Drawing.Point(12, 39);
            this.textBoxZhibanRuku.Name = "textBoxZhibanRuku";
            this.textBoxZhibanRuku.ReadOnly = true;
            this.textBoxZhibanRuku.Size = new System.Drawing.Size(776, 25);
            this.textBoxZhibanRuku.TabIndex = 1;
            this.textBoxZhibanRuku.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // Form数据导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxZhibanRuku);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form数据导入";
            this.ShowIcon = false;
            this.Text = "数据导入";
            this.Load += new System.EventHandler(this.Form数据导入_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxZhibanRuku;
    }
}