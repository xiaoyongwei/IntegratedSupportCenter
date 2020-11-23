using System;
using System.Collections;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Configuration.Install;

namespace WindowsServiceBackupWorkingDataClient
{
    public partial class Form1 : Form
    {
        string serviceFilePath = $"{Application.StartupPath}\\WindowsServiceBackupWorkingData.exe";
        string serviceName = "BackupWorkingData";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonInstallService_Click(object sender, EventArgs e)
        {
            if (this.IsServiceExisted(serviceName))
            {
                TextBoxAppendText(string.Format("服务[{0}]已经存在,准备卸载!", serviceName));
                this.UninstallService(serviceFilePath);
                TextBoxAppendText(string.Format("服务[{0}]完成卸载!", serviceName));
            }
            TextBoxAppendText(string.Format("准备安装服务[{0}]!", serviceName));
            this.InstallService(serviceFilePath);
            if (this.IsServiceExisted(serviceName))
            {
                TextBoxAppendText(string.Format("服务[{0}]安装成功!", serviceName));
            }
            else
            {
                TextBoxAppendText(string.Format("服务[{0}]安装失败!", serviceName));
            }
            
        }

        private void buttonRunService_Click(object sender, EventArgs e)
        {
            if (this.IsServiceExisted(serviceName))
            {
                this.ServiceStart(serviceName);
                TextBoxAppendText(string.Format("服务[{0}]启动成功!", serviceName));
            }
            else
            {
                TextBoxAppendText(string.Format("服务[{0}]不存在!", serviceName));
            }
        }

        private void buttonStopService_Click(object sender, EventArgs e)
        {
            if (this.IsServiceExisted(serviceName))
            {
                TextBoxAppendText(string.Format("准备停止服务[{0}]!", serviceName));
                this.ServiceStop(serviceName);
                TextBoxAppendText(string.Format("服务[{0}]停止成功!", serviceName));
            }
            else
            {
                TextBoxAppendText(string.Format("服务[{0}]不存在!", serviceName));
            }
        }

        private void buttonUninstallService_Click(object sender, EventArgs e)
        {
            if (this.IsServiceExisted(serviceName))
            {
                TextBoxAppendText(string.Format("准备停止服务[{0}]!", serviceName));
                this.ServiceStop(serviceName);
                TextBoxAppendText(string.Format("服务[{0}]停止成功!", serviceName));


                TextBoxAppendText(string.Format("服务[{0}]准备卸载!", serviceName));
                this.UninstallService(serviceFilePath);
                TextBoxAppendText(string.Format("服务[{0}]完成卸载!", serviceName));
            }
            else
            {
                TextBoxAppendText(string.Format("服务[{0}]不存在!", serviceName));
            }
        }

        //判断服务是否存在
        private bool IsServiceExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController sc in services)
            {
                if (sc.ServiceName.ToLower() == serviceName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        //安装服务
        private void InstallService(string serviceFilePath)
        {
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                IDictionary savedState = new Hashtable();
                installer.Install(savedState);
                installer.Commit(savedState);
            }
        }

        //卸载服务
        private void UninstallService(string serviceFilePath)
        {
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                installer.Uninstall(null);
            }
        }
        //启动服务
        private void ServiceStart(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Stopped)
                {
                    control.Start();
                }
            }
        }

        //停止服务
        private void ServiceStop(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Running)
                {
                    control.Stop();
                }
            }
        }


        private void TextBoxAppendText(string txt)
        {
            this.textBoxShow.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")+" "+txt+Environment.NewLine);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
    }
}
