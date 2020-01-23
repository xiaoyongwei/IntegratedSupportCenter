using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using 工作数据.winForm.每日数据;

namespace 工作数据
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
