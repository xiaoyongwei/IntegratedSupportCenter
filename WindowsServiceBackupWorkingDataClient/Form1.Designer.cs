namespace WindowsServiceBackupWorkingDataClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonInstallService = new System.Windows.Forms.Button();
            this.buttonRunService = new System.Windows.Forms.Button();
            this.buttonStopService = new System.Windows.Forms.Button();
            this.buttonUninstallService = new System.Windows.Forms.Button();
            this.textBoxShow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonInstallService
            // 
            this.buttonInstallService.Location = new System.Drawing.Point(12, 12);
            this.buttonInstallService.Name = "buttonInstallService";
            this.buttonInstallService.Size = new System.Drawing.Size(75, 23);
            this.buttonInstallService.TabIndex = 0;
            this.buttonInstallService.Text = "安装服务";
            this.buttonInstallService.UseVisualStyleBackColor = true;
            this.buttonInstallService.Click += new System.EventHandler(this.buttonInstallService_Click);
            // 
            // buttonRunService
            // 
            this.buttonRunService.Location = new System.Drawing.Point(103, 12);
            this.buttonRunService.Name = "buttonRunService";
            this.buttonRunService.Size = new System.Drawing.Size(75, 23);
            this.buttonRunService.TabIndex = 0;
            this.buttonRunService.Text = "启动服务";
            this.buttonRunService.UseVisualStyleBackColor = true;
            this.buttonRunService.Click += new System.EventHandler(this.buttonRunService_Click);
            // 
            // buttonStopService
            // 
            this.buttonStopService.Location = new System.Drawing.Point(201, 12);
            this.buttonStopService.Name = "buttonStopService";
            this.buttonStopService.Size = new System.Drawing.Size(75, 23);
            this.buttonStopService.TabIndex = 0;
            this.buttonStopService.Text = "停止服务";
            this.buttonStopService.UseVisualStyleBackColor = true;
            this.buttonStopService.Click += new System.EventHandler(this.buttonStopService_Click);
            // 
            // buttonUninstallService
            // 
            this.buttonUninstallService.Location = new System.Drawing.Point(299, 12);
            this.buttonUninstallService.Name = "buttonUninstallService";
            this.buttonUninstallService.Size = new System.Drawing.Size(75, 23);
            this.buttonUninstallService.TabIndex = 0;
            this.buttonUninstallService.Text = "卸载服务";
            this.buttonUninstallService.UseVisualStyleBackColor = true;
            this.buttonUninstallService.Click += new System.EventHandler(this.buttonUninstallService_Click);
            // 
            // textBoxShow
            // 
            this.textBoxShow.Location = new System.Drawing.Point(8, 52);
            this.textBoxShow.Multiline = true;
            this.textBoxShow.Name = "textBoxShow";
            this.textBoxShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxShow.Size = new System.Drawing.Size(371, 412);
            this.textBoxShow.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 470);
            this.Controls.Add(this.textBoxShow);
            this.Controls.Add(this.buttonUninstallService);
            this.Controls.Add(this.buttonStopService);
            this.Controls.Add(this.buttonRunService);
            this.Controls.Add(this.buttonInstallService);
            this.Name = "Form1";
            this.Text = "服务安装";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInstallService;
        private System.Windows.Forms.Button buttonRunService;
        private System.Windows.Forms.Button buttonStopService;
        private System.Windows.Forms.Button buttonUninstallService;
        private System.Windows.Forms.TextBox textBoxShow;
    }
}

