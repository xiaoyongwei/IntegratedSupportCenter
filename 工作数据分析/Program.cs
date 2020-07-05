using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using 工作数据分析.WinForm;
using 综合保障中心.Comm;
using 综合保障中心.其它;

namespace 甩纸数据
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //try
            //{
            //只运行一个
            Process[] processes = System.Diagnostics.Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (processes.Length > 1)
            {
                //MessageBox.Show("应用程序已经在运行中。。");
                //Thread.Sleep(1000);
                My.ShowErrorMessage("程序已经在运行!");
                System.Environment.Exit(1);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormYijie_自动获取());
            //Application.Run(new Form制版线实时());
            Application.Run(new Form回单管理());
        }
    }
}
