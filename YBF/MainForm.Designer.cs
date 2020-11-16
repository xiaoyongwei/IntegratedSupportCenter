namespace YBF
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiJobManager = new System.Windows.Forms.ToolStripMenuItem();
            this.作业管理新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiYwj = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConversion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSunhao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbnormal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaintain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHuibao = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPublishedRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAppSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_AppSetting_Local = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_AppSetting_illustrator = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiZipDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.timerBuckupDbToDisk = new System.Windows.Forms.Timer(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiJobManager,
            this.作业管理新ToolStripMenuItem,
            this.tsmiYwj,
            this.tsmiConversion,
            this.tsmiManager,
            this.tsmiHuibao,
            this.tsmiPublishedRecord,
            this.tsmiAppSetting,
            this.tsmiWindows});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(745, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiJobManager
            // 
            this.tsmiJobManager.Name = "tsmiJobManager";
            this.tsmiJobManager.Size = new System.Drawing.Size(68, 21);
            this.tsmiJobManager.Text = "作业管理";
            this.tsmiJobManager.Click += new System.EventHandler(this.tsmiJobManager_Click);
            // 
            // 作业管理新ToolStripMenuItem
            // 
            this.作业管理新ToolStripMenuItem.Name = "作业管理新ToolStripMenuItem";
            this.作业管理新ToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.作业管理新ToolStripMenuItem.Text = "作业管理(新)";
            this.作业管理新ToolStripMenuItem.Click += new System.EventHandler(this.作业管理新ToolStripMenuItem_Click);
            // 
            // tsmiYwj
            // 
            this.tsmiYwj.Name = "tsmiYwj";
            this.tsmiYwj.Size = new System.Drawing.Size(56, 21);
            this.tsmiYwj.Text = "源文件";
            this.tsmiYwj.Click += new System.EventHandler(this.tsmiYwj_Click);
            // 
            // tsmiConversion
            // 
            this.tsmiConversion.Name = "tsmiConversion";
            this.tsmiConversion.Size = new System.Drawing.Size(78, 21);
            this.tsmiConversion.Text = "转好的PDF";
            this.tsmiConversion.Click += new System.EventHandler(this.tsmiConversion_Click);
            // 
            // tsmiManager
            // 
            this.tsmiManager.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSunhao,
            this.tsmiPrint,
            this.tsmiAbnormal,
            this.tsmiMaintain});
            this.tsmiManager.Name = "tsmiManager";
            this.tsmiManager.Size = new System.Drawing.Size(44, 21);
            this.tsmiManager.Text = "管理";
            // 
            // tsmiSunhao
            // 
            this.tsmiSunhao.Name = "tsmiSunhao";
            this.tsmiSunhao.Size = new System.Drawing.Size(160, 22);
            this.tsmiSunhao.Text = "版材非正常使用";
            this.tsmiSunhao.Click += new System.EventHandler(this.tsmiSunhao_Click);
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.Size = new System.Drawing.Size(160, 22);
            this.tsmiPrint.Text = "印刷机";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tsmiAbnormal
            // 
            this.tsmiAbnormal.Name = "tsmiAbnormal";
            this.tsmiAbnormal.Size = new System.Drawing.Size(160, 22);
            this.tsmiAbnormal.Text = "异常记录表";
            this.tsmiAbnormal.Click += new System.EventHandler(this.tsmiAbnormal_Click);
            // 
            // tsmiMaintain
            // 
            this.tsmiMaintain.Name = "tsmiMaintain";
            this.tsmiMaintain.Size = new System.Drawing.Size(160, 22);
            this.tsmiMaintain.Text = "保养记录表";
            this.tsmiMaintain.Click += new System.EventHandler(this.tsmiMaintain_Click);
            // 
            // tsmiHuibao
            // 
            this.tsmiHuibao.Name = "tsmiHuibao";
            this.tsmiHuibao.Size = new System.Drawing.Size(44, 21);
            this.tsmiHuibao.Text = "汇报";
            this.tsmiHuibao.Click += new System.EventHandler(this.tsmiHuibao_Click);
            // 
            // tsmiPublishedRecord
            // 
            this.tsmiPublishedRecord.Name = "tsmiPublishedRecord";
            this.tsmiPublishedRecord.Size = new System.Drawing.Size(68, 21);
            this.tsmiPublishedRecord.Text = "出版记录";
            this.tsmiPublishedRecord.Click += new System.EventHandler(this.tsmiPublishedRecord_Click);
            // 
            // tsmiAppSetting
            // 
            this.tsmiAppSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_AppSetting_Local,
            this.tsmi_AppSetting_illustrator,
            this.tsmiZipDataBase});
            this.tsmiAppSetting.Name = "tsmiAppSetting";
            this.tsmiAppSetting.Size = new System.Drawing.Size(44, 21);
            this.tsmiAppSetting.Text = "设置";
            // 
            // tsmi_AppSetting_Local
            // 
            this.tsmi_AppSetting_Local.Name = "tsmi_AppSetting_Local";
            this.tsmi_AppSetting_Local.Size = new System.Drawing.Size(156, 22);
            this.tsmi_AppSetting_Local.Text = "本地设置";
            this.tsmi_AppSetting_Local.Click += new System.EventHandler(this.tsmi_AppSetting_Local_Click);
            // 
            // tsmi_AppSetting_illustrator
            // 
            this.tsmi_AppSetting_illustrator.Name = "tsmi_AppSetting_illustrator";
            this.tsmi_AppSetting_illustrator.Size = new System.Drawing.Size(156, 22);
            this.tsmi_AppSetting_illustrator.Text = "Illustrator设置";
            this.tsmi_AppSetting_illustrator.Click += new System.EventHandler(this.tsmi_AppSetting_illustrator_Click);
            // 
            // tsmiZipDataBase
            // 
            this.tsmiZipDataBase.Name = "tsmiZipDataBase";
            this.tsmiZipDataBase.Size = new System.Drawing.Size(156, 22);
            this.tsmiZipDataBase.Text = "压缩数据库";
            this.tsmiZipDataBase.Click += new System.EventHandler(this.tsmiZipDataBase_Click);
            // 
            // tsmiWindows
            // 
            this.tsmiWindows.Name = "tsmiWindows";
            this.tsmiWindows.Size = new System.Drawing.Size(44, 21);
            this.tsmiWindows.Text = "窗口";
            this.tsmiWindows.DropDownOpening += new System.EventHandler(this.tsmiWindows_DropDownOpening);
            // 
            // timerBuckupDbToDisk
            // 
            this.timerBuckupDbToDisk.Enabled = true;
            this.timerBuckupDbToDisk.Interval = 600000;
            this.timerBuckupDbToDisk.Tick += new System.EventHandler(this.timerBuckupDbToDisk_Tick);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Filter = "*.pdf";
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.NotifyFilter = System.IO.NotifyFilters.FileName;
            this.fileSystemWatcher1.Path = "\\\\192.168.110.32\\JobData\\PDF";
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 487);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "森林包装印版房作业管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiYwj;
        private System.Windows.Forms.ToolStripMenuItem tsmiWindows;
        private System.Windows.Forms.ToolStripMenuItem tsmiConversion;
        private System.Windows.Forms.ToolStripMenuItem tsmiAppSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmiJobManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiHuibao;
        private System.Windows.Forms.ToolStripMenuItem tsmiManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.Timer timerBuckupDbToDisk;
        private System.Windows.Forms.ToolStripMenuItem tsmiPublishedRecord;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbnormal;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaintain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSunhao;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AppSetting_Local;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AppSetting_illustrator;
        private System.Windows.Forms.ToolStripMenuItem tsmiZipDataBase;
        private System.Windows.Forms.ToolStripMenuItem 作业管理新ToolStripMenuItem;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

