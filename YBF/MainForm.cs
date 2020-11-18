using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YBF.WinForm.Ywj;
using YBF.WinForm.ChuBan;
using System.IO;
using HanDe_ToolBox_Form;
using System.Threading;
using YBF.Properties;
using YBF.Class.Comm;
using System.Management;
using System.Diagnostics;
using YBF.WinForm.Tool;
using Microsoft.VisualBasic.FileIO;
using HandeJobManager.DAL;
using System.Reflection;
using YBF.WinForm.Accessories;
using YBF.WinForm;
using YBF.WinForm.Job;
using HanDe_ClassLibrary.LogCommon;
using HandeJobManager;
using YBF.WinForm.Printer;
using YBF.WinForm.Abnormal;
using YBF.WinForm.Maintain;
using YBF.WinForm.Jdf;

namespace YBF
{
    public partial class MainForm : Form
    {
        // private bool IsClose;

        //private Thread thSavePdf;//进程
        private Thread thBuckupToDisk;//进程,定时备份数据库到硬盘


        public MainForm()
        {
            SQLiteList.YBF = new SQLiteDbHelper(
               @"Data Source=" + Application.StartupPath + "\\Data\\ybf.db;Version=3;");
            InitializeComponent();
        }

        FormYwj_NoMove ywj = null;
        private void tsmiYwj_Click(object sender, EventArgs e)
        {
            //if (ywj==null||ywj.IsDisposed)
            //{

            //}
            ywj = new FormYwj_NoMove();
            ywj.WindowState = FormWindowState.Maximized;
            ywj.MdiParent = this;
            ywj.Show();
        }

        FormChuBan chuban = null;
        private void tsmiChuban_Click(object sender, EventArgs e)
        {
            if (chuban == null
               || chuban.IsDisposed)
            {
                chuban = new FormChuBan();
                chuban.MdiParent = this;
            }
            chuban.Show();
            chuban.WindowState = FormWindowState.Maximized;
            chuban.Focus();
        }

        private void tsmiMovePublishedPdf_Click(object sender, EventArgs e)
        {
            string[] topPaths = { @"\\EvoServer\historical_data\processes" };

            foreach (string topPath in topPaths)
            {
                if (!Directory.Exists(topPath))
                {
                    continue;
                }
                foreach (string guidPath in Directory.EnumerateDirectories(topPath))
                {
                    //bool bl1 = Directory.GetCreationTime(guidPath).AddHours(24) > DateTime.Now;
                    //bool bl2 = File.Exists(topPath + "\\jt-trail\\1-3{printing-to-device}.out.jtk");
                    //bool bl3 = File.Exists(topPath + "\\ProcessCreationInfo.txt");
                    if (Directory.GetCreationTime(guidPath).AddHours(24) > DateTime.Now
                        && File.Exists(guidPath + "\\jt-trail\\1-3{printing-to-device}.out.jtk")
                        && File.Exists(guidPath + "\\ProcessCreationInfo.txt"))
                    {
                        string ProcessCreationInfo = guidPath + "\\ProcessCreationInfo.txt";
                        string[] allLines = File.ReadAllLines(ProcessCreationInfo);
                        for (int i = 12; i < allLines.Length; i++)
                        {
                            string fileFullName = allLines[i];
                            if (!string.IsNullOrWhiteSpace(fileFullName)
                                && Path.GetDirectoryName(fileFullName)
                                .Equals(@"\\ev08382-01\JobData\pdf\已下单PDF"
                                , StringComparison.CurrentCultureIgnoreCase)
                                && File.Exists(fileFullName))
                            {
                                string toPath = Path.GetDirectoryName(fileFullName)
                                    + "\\" +
                                    (DateTime.Now.Hour < 5 ? DateTime.Now.AddDays(-1).ToString("M-d") : DateTime.Now.ToString("M-d"));
                                if (!Directory.Exists(toPath))
                                {
                                    Directory.CreateDirectory(toPath);
                                }
                                File.Move(fileFullName,
                                    toPath + "\\" + Path.GetFileName(fileFullName));
                            }
                        }
                    }
                }
            }
        }

        private void tsmiWindows_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;
            t.DropDownItems.Clear();
            Form[] windows = this.MdiChildren;
            if (windows.Length > 0)
            {
                ToolStripMenuItem tool = new ToolStripMenuItem("全部关闭");
                tool.Click += new EventHandler(tool_Click);
                t.DropDownItems.Add(tool);
                tool = new ToolStripMenuItem("全部最小化");
                tool.Click += new EventHandler(tool_Click);
                t.DropDownItems.Add(tool);
                t.DropDownItems.Add(new ToolStripSeparator());
            }
            foreach (Form f in windows)
            {
                ToolStripMenuItem m = new ToolStripMenuItem(f.Text);
                m.Click += new EventHandler(tsmi_Click);
                t.DropDownItems.Add(m);
            }
        }
        private void tool_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            switch (tsmi.Text)
            {
                case "全部关闭":
                    foreach (Form f in this.MdiChildren)
                    {
                        f.Dispose();
                    }
                    break;
                case "全部最小化":
                    foreach (Form f in this.MdiChildren)
                    {
                        f.WindowState = FormWindowState.Minimized;
                    }
                    break;
                default:
                    break;
            }
        }
        private void tsmi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            foreach (Form f in this.MdiChildren)
            {
                if (tsmi.Text == f.Text)
                {
                    f.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    f.WindowState = FormWindowState.Minimized;
                }
            }
        }

        FormFindOld findOld = null;
        private void tsmiOldPlant_Click(object sender, EventArgs e)
        {
            if (findOld == null
                || findOld.IsDisposed)
            {
                findOld = new FormFindOld(null);
                findOld.MdiParent = this;
            }
            findOld.Show();
            findOld.WindowState = FormWindowState.Maximized;
            findOld.Focus();
        }

        


        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                //初始化软件设置参数
                AppConfig_Local.InitAppConfig();
                //备份数据库
                BuckupDateBaseToDisk();
                //清空临时文件
                DeleteTemp();
                //初始化PDF文件列表
                InitPdfList();
            }
            catch (Exception ex)
            {
                Comm_Method.ShowErrorMessage(ex.Message);
            }

            this.WindowState = FormWindowState.Maximized;
            //this.thSavePdf = new Thread(new ThreadStart(SavePdf_Illustrator));
            //thSavePdf.Start();

            // InitTimer();

           // this.作业管理新ToolStripMenuItem_Click(this, new EventArgs());
        }

        /// <summary>
        /// 初始化PDF文件列表
        /// </summary>
        private void InitPdfList()
        {
            fileSystemWatcher1.EnableRaisingEvents = false;
            //string pdfPath = @"\\EvoServer\JobData\PDF\已下单PDF";
            string pdfPath = @"\\192.168.110.32\JobData\PDF\已下单PDF";
            if (Comm_Method.IsConnectPath(pdfPath))
            {
                Comm_Method.PdfFileList =  Directory.EnumerateFiles(pdfPath,"*.pdf", System.IO.SearchOption.AllDirectories).ToList();
            }
            fileSystemWatcher1.EnableRaisingEvents = true;
        }

        /// <summary>
        /// 删除临时文件
        /// </summary>
        private void DeleteTemp()
        {
            try
            {
                string temp = "Temp";
                if (Directory.Exists("Temp"))
                {
                    //先删除一小时前的所有文件
                    foreach (FileInfo file in new DirectoryInfo(temp).GetFiles("*", System.IO.SearchOption.AllDirectories))
                    {
                        if (file.LastWriteTime.AddHours(1) < DateTime.Now)
                        {
                            file.Delete();
                        }
                    }
                    //然后删除所有空文件夹
                    foreach (DirectoryInfo dir in new DirectoryInfo(temp).GetDirectories("*", System.IO.SearchOption.AllDirectories))
                    {
                        dir.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("清空临时文件时出错：", ex);
            }
        }

        //private void InitTimer()
        //{
        //    this.timer1 = new System.Windows.Forms.Timer();
        //    this.timer1.Interval = 1000;
        //    this.timer1.Tick += new EventHandler(timer1_Tick);
        //    this.timer1.Enabled = false;
        //}



        //private FileSystemWatcher GetFileSystemWatcher(string path)
        //{
        //    FileSystemWatcher watcher = null;
        //    if (Directory.Exists(path))
        //    {
        //        watcher = new FileSystemWatcher(path, "*.pdf");
        //        watcher.EnableRaisingEvents = false;
        //        watcher.IncludeSubdirectories = true;
        //        watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
        //    }
        //    return watcher;
        //}

        //统计出版记录
        FormPublishProcess publishProcess = null;
        private void tsmiProcess_Click(object sender, EventArgs e)
        {
            if (publishProcess == null
                || publishProcess.IsDisposed)
            {
                publishProcess = new FormPublishProcess();
                publishProcess.MdiParent = this;
            }
            publishProcess.Show();
            publishProcess.WindowState = FormWindowState.Maximized;
            publishProcess.Focus();
        }

        FormSavePdf savePdf = null;
        private void tsmiSavePdf_Click(object sender, EventArgs e)
        {
            if (savePdf == null || savePdf.IsDisposed)
            {
                savePdf = new FormSavePdf();
            }
            savePdf.WindowState = FormWindowState.Maximized;
            savePdf.MdiParent = this;
            savePdf.Show();
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (Comm_Method.AiFileList.Count > 0)
        //    {
        //        this.timer1.Stop();
        //        this.thSavePdf = new Thread(new ThreadStart(SavePdf_Illustrator));
        //        thSavePdf.Start();
        //    }

        //}
        //private void SavePdf_Illustrator()
        //{

        //    while (true)
        //    {
        //        if (IsClose)
        //        {
        //            break;
        //        }
        //        try
        //        {
        //            while (Comm_Method.AiFileList.Count == 0 && !this.IsClose)
        //            {
        //                Thread.Sleep(5000);
        //            }

        //            // this.timer1.Stop();

        //            //判断Adobe Illustrator CS6 (64 Bit)是否运行
        //            string aiexe = @"C:\Program Files\Adobe\AdobeIllustratorCS6_x64\Support Files\Contents\Windows\Illustrator.exe";
        //            if (File.Exists(aiexe))
        //            {
        //                if (Process.GetProcessesByName("Illustrator").Length == 0
        //                    && !IsClose)
        //                {
        //                    System.Diagnostics.Process.Start(aiexe);
        //                }
        //                Illustrator.ApplicationClass app = new Illustrator.ApplicationClass();

        //                while (Comm_Method.AiFileList.Count > 0)
        //                {
        //                    while (app.Documents.Count > 0 && !this.IsClose)
        //                    {
        //                        Thread.Sleep(5000);
        //                    }
        //                    string aiFile = Comm_Method.AiFileList[0];
        //                    app.DoJavaScript(Resources.AutoSavePdf.Replace
        //                        ("*文件名*", aiFile.Replace('\\', '/'))
        //                        .Replace("*AI导出PDF目录*", pdfFolder.Replace('\\', '/')));
        //                    Comm_Method.AiFileList.RemoveAt(0);
        //                    if (File.Exists(pdfFolder + "\\"
        //                        + Path.GetFileNameWithoutExtension(aiFile) + ".pdf"))
        //                    {
        //                        string okDir = Path.GetDirectoryName(aiFile) + "\\ok\\";
        //                        if (!Directory.Exists(okDir))
        //                        {
        //                            Directory.CreateDirectory(okDir);
        //                        }
        //                        FileSystem.MoveFile(aiFile, okDir + Path.GetFileName(aiFile)
        //              , UIOption.AllDialogs, UICancelOption.DoNothing);
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //             Log.WriteLog(ex.ToString());
        //        }
        //        finally
        //        {
        //            Thread.Sleep(5000);
        //        }

        //    }
        //}

        //private void SavePdf_Illustrator()
        //{
        //    string dllFullPath = dllFullPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Interop.Illustrator.dll";

        //    while (true)
        //    {
        //        if (IsClose)
        //        {
        //            break;
        //        }
        //        try
        //        {
        //            //判断Adobe Illustrator CS6 (64 Bit)是否运行
        //            string aiexe = @"C:\Program Files\Adobe\AdobeIllustratorCS6_x64\Support Files\Contents\Windows\Illustrator.exe";
        //            if (File.Exists(aiexe))
        //            {                       
        //                while (Comm_Method.AiFileList.Count > 0)
        //                {
        //                    if (Process.GetProcessesByName("Illustrator").Length == 0
        //                   && !IsClose)
        //                    {
        //                        System.Diagnostics.Process.Start(aiexe);
        //                    }
        //                    string aiFile = Comm_Method.AiFileList[0];
        //                    //空间名+类名
        //                    string spaceName = Path.GetFileNameWithoutExtension(dllFullPath) + ".ApplicationClass";

        //                    //加载程序集(dll文件地址)，使用Assembly类   
        //                    Assembly assembly = Assembly.LoadFile(dllFullPath);

        //                    //获取类型，参数（名称空间+类）   
        //                    Type type = assembly.GetType(spaceName);

        //                    //创建该对象的实例，object类型，参数（名称空间+类）   
        //                    object instance = assembly.CreateInstance(spaceName);


        //                    ////设置Show_Str方法中的参数类型，Type[]类型；如有多个参数可以追加多个   
        //                    //Type[] params_type = new Type[1];
        //                    //params_type[0] = Type.GetType("System.String");
        //                    ////设置Show_Str方法中的参数值；如有多个参数可以追加多个   
        //                    //Object[] params_obj = new Object[1];
        //                    //params_obj[0] = "alert('测试');";

        //                    ////执行Show_Str方法   
        //                    // type.GetMethod("DoJavaScript", params_type).Invoke(instance, params_obj);


        //                    //方法名称
        //                    string strMethod = "DoJavaScript";
        //                    // 获取方法信息
        //                    // 注意获取重载方法，需要指定参数类型
        //                    MethodInfo method = type.GetMethod(strMethod);
        //                    object[] parameters = new object[] 
        //        { Resources.AutoSavePdf.Replace
        //                        ("*文件名*", aiFile.Replace('\\', '/'))
        //                        .Replace("*AI导出PDF目录*", hotFolder.Replace('\\', '/'))
        //            , null, null };
        //                    // 调用方法，有参数
        //                    method.Invoke(instance, parameters);


        //                    if (File.Exists(hotFolder + "\\"
        //                        + Path.GetFileNameWithoutExtension(aiFile) + ".pdf"))
        //                    {
        //                        string okDir = Path.GetDirectoryName(aiFile) + "\\ok\\";
        //                        if (!Directory.Exists(okDir))
        //                        {
        //                            Directory.CreateDirectory(okDir);
        //                        }
        //                        FileSystem.MoveFile(aiFile, okDir + Path.GetFileName(aiFile)
        //              , UIOption.AllDialogs, UICancelOption.DoNothing);
        //                    }
        //                    Comm_Method.AiFileList.RemoveAt(0);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //             Log.WriteLog(ex.ToString());
        //        }
        //        finally
        //        {
        //            Thread.Sleep(5000);
        //        }

        //    }
        //}

        private static double UsingProcess(Process pro)
        {
            try
            {
                //平局值
                double avg = 0;
                //统计的总次数
                int numAll = 3;
                double[] numArray = new double[numAll];
                //间隔时间（毫秒）
                int interval = 700;
                //上次记录的CPU时间
                var prevCpuTime = TimeSpan.Zero;
                //记录次数
                int numRec = 0;
                while (numRec < numAll)
                {
                    //当前时间
                    var curTime = pro.TotalProcessorTime;
                    //间隔时间内的CPU运行时间除以逻辑CPU数量
                    var value = (curTime - prevCpuTime).TotalMilliseconds / interval / Environment.ProcessorCount * 100;
                    numArray[numRec++] = value;
                    prevCpuTime = curTime;

                    Thread.Sleep(interval);
                }
                //总和
                double sum = 0;
                foreach (double item in numArray)
                {
                    sum += item;
                }
                avg = sum / numAll;
                return avg;
            }
            catch
            {
                return -1;
            }
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason != CloseReason.WindowsShutDown
                    && MessageBox.Show("确认要退出吗?", "退出吗?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (Application.StartupPath.ToLower()
                        .IndexOf("\\bin\\Debug".ToLower()) < 0)
                    {
                        FormBackupAccess backup = new FormBackupAccess();
                        backup.Show();
                        backup.BackupAccess();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("关闭程序,备份数据库时发生错误:" + ex.Message);
            }
        }

        private void tsmiToolBox_Click(object sender, EventArgs e)
        {
            new FormToolAll().ShowDialog();
        }

        FormQQFileRecv qqfr = null;
        private void tsmiQQFileRecv_Click(object sender, EventArgs e)
        {
            if (qqfr == null || qqfr.IsDisposed)
            {
                qqfr = new FormQQFileRecv();
            }
            qqfr.WindowState = FormWindowState.Maximized;
            qqfr.MdiParent = this;
            qqfr.Show();
        }

        FormConversionPdf ConversionPDF = null;
        private void tsmiConversion_Click(object sender, EventArgs e)
        {
            if (ConversionPDF == null || ConversionPDF.IsDisposed)
            {
                ConversionPDF = new FormConversionPdf();
            }
            ConversionPDF.WindowState = FormWindowState.Maximized;
            ConversionPDF.MdiParent = this;
            ConversionPDF.Show();
        }




        FormAccessoriesManager accManager = null;
        private void tsmiAccessoriesManager_Click(object sender, EventArgs e)
        {
            if (accManager == null || accManager.IsDisposed)
            {
                accManager = new FormAccessoriesManager();
            }
            accManager.WindowState = FormWindowState.Maximized;
            accManager.MdiParent = this;
            accManager.Show();
        }

        FormFuliaoPandian pandian = null;
        private void tsmiFuliaoPandian_Click(object sender, EventArgs e)
        {
            if (pandian == null || pandian.IsDisposed)
            {
                pandian = new FormFuliaoPandian();
            }
            pandian.WindowState = FormWindowState.Maximized;
            pandian.MdiParent = this;
            pandian.Show();
        }

        private void tsmiAllShowKucun_Click(object sender, EventArgs e)
        {
            Form AllShow = new Form();
            AllShow.Text = "查看库存余量";
            DataGridView dgvAllShow = new DataGridView();
            dgvAllShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAllShow.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAllShow.ReadOnly = true;
            dgvAllShow.Dock = DockStyle.Fill;
            dgvAllShow.AllowUserToAddRows = false;
            //dgvAllShow.RowHeadersVisible = false;
            dgvAllShow.ShowRowErrors = true;
            dgvAllShow.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvAllShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllShow.DataSource = SQLiteList.YBF.ExecuteDataTable("select [名称],sum([数量]) as 库存,[单位],[安全库存],[辅料].[备注] from [辅料使用记录] join [辅料] on [辅料].[ID]=[辅料使用记录].[辅料ID]group by[辅料ID];");
            AllShow.Controls.Add(dgvAllShow);
            AllShow.WindowState = FormWindowState.Maximized;
            AllShow.MdiParent = this;
            AllShow.Show();

            for (int i = 0; i < dgvAllShow.Columns.Count; i++)
            {
                dgvAllShow.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewRow row in dgvAllShow.Rows)
            {
                if (Convert.ToInt32(row.Cells["库存"].Value) < Convert.ToInt32(row.Cells["安全库存"].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.HeaderCell.Value = "!!!";
                }
            }

            //关闭多余的窗体
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == AllShow.Name && f.Handle != AllShow.Handle)
                {
                    f.Dispose();
                }
            }
        }

        FormFuliaoLeixing Fllx = null;
        private void tsmiFuliaoLeixing_Click(object sender, EventArgs e)
        {
            if (Fllx == null || Fllx.IsDisposed)
            {
                Fllx = new FormFuliaoLeixing();
            }
            Fllx.WindowState = FormWindowState.Maximized;
            Fllx.MdiParent = this;
            Fllx.Show();
        }

        private void tsmiJobManager_Click(object sender, EventArgs e)
        {
            FormJobManager jobManager = new FormJobManager();
            jobManager.WindowState = FormWindowState.Maximized;
            jobManager.MdiParent = this;
            jobManager.Show();
        }

        private void tsmiHuibao_Click(object sender, EventArgs e)
        {
            FormHuibao huibao = new FormHuibao();
            huibao.WindowState = FormWindowState.Maximized;
            huibao.MdiParent = this;
            huibao.Show();
        }

        FormBancaiSunhao sunhao = null;
        private void tsmiSunhao_Click(object sender, EventArgs e)
        {
            if (sunhao == null || sunhao.IsDisposed)
            {
                sunhao = new FormBancaiSunhao();
            }
            sunhao.WindowState = FormWindowState.Maximized;
            sunhao.MdiParent = this;
            sunhao.Show();
        }


        FormFuliaoLingLiao lingliao = null;
        private void tsmiFuliaoLingLiao_Click(object sender, EventArgs e)
        {
            if (lingliao == null || lingliao.IsDisposed)
            {
                lingliao = new FormFuliaoLingLiao();
            }
            lingliao.WindowState = FormWindowState.Maximized;
            lingliao.MdiParent = this;
            lingliao.Show();
        }

        FormFuliaoKucunJilu cukunJilu = null;
        

        private void tsmiFuliaoKucunJilu_Click(object sender, EventArgs e)
        {
            if (cukunJilu == null || cukunJilu.IsDisposed)
            {
                cukunJilu = new FormFuliaoKucunJilu();
            }
            cukunJilu.WindowState = FormWindowState.Maximized;
            cukunJilu.MdiParent = this;
            cukunJilu.Show();
        }

        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param customerName="sender"></param>
        /// <param customerName="e"></param>
        private void timerBuckupDbToDisk_Tick(object sender, EventArgs e)
        {
            try
            {
                this.thBuckupToDisk = new Thread(new ThreadStart(BuckupDateBaseToDisk));
                thBuckupToDisk.Start();
            }
            catch (Exception ex)
            {
                Log.WriteLog("备份数据库到本地硬盘时发生错误:" + ex.Message);
            }
        }
        private void BuckupDateBaseToDisk()
        {

            FormBackupAccess backup = new FormBackupAccess();
            backup.BackupAccess();//拷贝到C盘
        }

        private void tsmiZipDataBase_Click(object sender, EventArgs e)
        {
            SQLiteList.YBF.ExecuteZip();
        }

        private void tsmiPublishedRecord_Click(object sender, EventArgs e)
        {
            FormEvoProcesses evoProcesses = new FormEvoProcesses();         
            evoProcesses.WindowState = FormWindowState.Maximized;
            evoProcesses.MdiParent = this;
            evoProcesses.Show();
        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            FormPrintingMachine printing = new FormPrintingMachine();
            printing.WindowState = FormWindowState.Maximized;
            printing.MdiParent = this;
            printing.Show();
        }

        private void tsmiAbnormal_Click(object sender, EventArgs e)
        {
            FormAbnormalManager Abnormal = new FormAbnormalManager();
            Abnormal.WindowState = FormWindowState.Maximized;
            Abnormal.MdiParent = this;
            Abnormal.Show();
        }

        private void tsmiMaintain_Click(object sender, EventArgs e)
        {
            FormMaintainManager Maintain = new FormMaintainManager();
            Maintain.WindowState = FormWindowState.Maximized;
            Maintain.MdiParent = this;
            Maintain.Show();
        }

        
        private void tsmi_AppSetting_Local_Click(object sender, EventArgs e)
        {
            new FormAppSetting().ShowDialog();
        }

        private void tsmi_AppSetting_illustrator_Click(object sender, EventArgs e)
        {
            new FormSelectIllustrator().ShowDialog();
        }

        private void 作业管理新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJobManager1 jobManager = new FormJobManager1();
            jobManager.WindowState = FormWindowState.Maximized;
            jobManager.MdiParent = this;
            jobManager.Show();
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            Comm_Method.PdfFileList.Add(e.FullPath);
            Comm_Method.LogTxt(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t新建\t" + e.FullPath);
        }

        private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
            Comm_Method.PdfFileList.Remove(e.FullPath);
            Comm_Method.LogTxt(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t删除\t" + e.FullPath);
        }

        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            Comm_Method.PdfFileList[Comm_Method.PdfFileList.FindIndex(pdf => pdf.Equals(e.OldFullPath))]=e.FullPath;
            Comm_Method.LogTxt(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t重命名\t" + e.FullPath+"\t旧名称:"+e.OldFullPath);
        }
    }
}