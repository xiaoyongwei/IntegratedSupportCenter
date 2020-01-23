using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HandeJobManager.DAL;
using System.Diagnostics;
using YBF.WinForm.Accessories;
using System.Data;
using YBF.WinForm.Job;
using YBF.Class.Comm;
using YBF.HanDe_ClassLibrary.PrinergyEvo;
using HanDe_ToolBox_Form.HanDe_ClassLibrary.PrinergyEvo;

namespace YBF
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //只运行一个
            //****调试状态则不检测*****
            if (Environment.CommandLine.IndexOf("\\bin\\Debug") == -1)
            {

                Process[] processes = System.Diagnostics.Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                if (processes.Length > 1)
                {

                    Comm_Method.ShowErrorMessage("程序已经在运行!");
                    System.Environment.Exit(1);
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
