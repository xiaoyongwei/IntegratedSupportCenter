using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HandeJobManager.DAL;
using 综合保障中心.其它;
using 综合保障中心.运费;

namespace 综合保障中心
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //SQLiteList.GD = new SQLiteDbHelper(@"Data Source=" + Application.StartupPath + "\\Data\\GaoDai.db;Version=3;Password=1234;");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormYijie());
        }
    }
}
