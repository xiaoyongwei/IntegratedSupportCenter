namespace 综合保障中心.稿袋
{
    partial class FormGaodaiHebing
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
            this.textBoxCustomer = new System.Windows.Forms.TextBox();
            this.textBoxProduct = new System.Windows.Forms.TextBox();
            this.labelHebing = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGaodai = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "成品名称:";
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCustomer.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCustomer.Location = new System.Drawing.Point(77, 40);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.ReadOnly = true;
            this.textBoxCustomer.Size = new System.Drawing.Size(219, 21);
            this.textBoxCustomer.TabIndex = 2;
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProduct.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxProduct.Location = new System.Drawing.Point(77, 74);
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.ReadOnly = true;
            this.textBoxProduct.Size = new System.Drawing.Size(219, 21);
            this.textBoxProduct.TabIndex = 2;
            // 
            // labelHebing
            // 
            this.labelHebing.AutoSize = true;
            this.labelHebing.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.labelHebing.ForeColor = System.Drawing.Color.Red;
            this.labelHebing.Location = new System.Drawing.Point(9, 118);
            this.labelHebing.Name = "labelHebing";
            this.labelHebing.Size = new System.Drawing.Size(297, 108);
            this.labelHebing.TabIndex = 3;
            this.labelHebing.Text = "上面稿袋已经被使用,请问是否和\r\n客户:{0}\r\n产品名称:{1}\r\n共用同一稿袋?";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(135, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "是(合并)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(221, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "否(取消)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "稿袋:";
            // 
            // textBoxGaodai
            // 
            this.textBoxGaodai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGaodai.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxGaodai.Location = new System.Drawing.Point(77, 6);
            this.textBoxGaodai.Name = "textBoxGaodai";
            this.textBoxGaodai.ReadOnly = true;
            this.textBoxGaodai.Size = new System.Drawing.Size(219, 21);
            this.textBoxGaodai.TabIndex = 2;
            // 
            // FormGaodaiHebing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 279);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelHebing);
            this.Controls.Add(this.textBoxProduct);
            this.Controls.Add(this.textBoxGaodai);
            this.Controls.Add(this.textBoxCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "FormGaodaiHebing";
            this.ShowIcon = false;
            this.Text = "稿袋共用";
            this.Load += new System.EventHandler(this.FormGaodaiInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCustomer;
        private System.Windows.Forms.TextBox textBoxProduct;
        private System.Windows.Forms.Label labelHebing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGaodai;
    }
}