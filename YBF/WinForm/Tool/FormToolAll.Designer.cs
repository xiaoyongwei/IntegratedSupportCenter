namespace YBF.WinForm.Tool
{
    partial class FormToolAll
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
            this.buttonKillJPrinterJTP_daji = new System.Windows.Forms.Button();
            this.buttonKillJPrinterJTP_xiaoji = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonKillJPrinterJTP_daji
            // 
            this.buttonKillJPrinterJTP_daji.Font = new System.Drawing.Font("宋体", 12F);
            this.buttonKillJPrinterJTP_daji.Location = new System.Drawing.Point(12, 12);
            this.buttonKillJPrinterJTP_daji.Name = "buttonKillJPrinterJTP_daji";
            this.buttonKillJPrinterJTP_daji.Size = new System.Drawing.Size(139, 66);
            this.buttonKillJPrinterJTP_daji.TabIndex = 0;
            this.buttonKillJPrinterJTP_daji.Text = "停止大机的\r\n\r\n印能捷打印服务";
            this.buttonKillJPrinterJTP_daji.UseVisualStyleBackColor = true;
            this.buttonKillJPrinterJTP_daji.Click += new System.EventHandler(this.buttonKillJPrinterJTP_Click);
            // 
            // buttonKillJPrinterJTP_xiaoji
            // 
            this.buttonKillJPrinterJTP_xiaoji.Font = new System.Drawing.Font("宋体", 12F);
            this.buttonKillJPrinterJTP_xiaoji.Location = new System.Drawing.Point(166, 12);
            this.buttonKillJPrinterJTP_xiaoji.Name = "buttonKillJPrinterJTP_xiaoji";
            this.buttonKillJPrinterJTP_xiaoji.Size = new System.Drawing.Size(139, 66);
            this.buttonKillJPrinterJTP_xiaoji.TabIndex = 0;
            this.buttonKillJPrinterJTP_xiaoji.Text = "停止小机的\r\n\r\n印能捷打印服务";
            this.buttonKillJPrinterJTP_xiaoji.UseVisualStyleBackColor = true;
            this.buttonKillJPrinterJTP_xiaoji.Click += new System.EventHandler(this.buttonKillJPrinterJTP_xiaoji_Click);
            // 
            // FormToolAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 273);
            this.Controls.Add(this.buttonKillJPrinterJTP_xiaoji);
            this.Controls.Add(this.buttonKillJPrinterJTP_daji);
            this.Name = "FormToolAll";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "工具箱";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonKillJPrinterJTP_daji;
        private System.Windows.Forms.Button buttonKillJPrinterJTP_xiaoji;
    }
}