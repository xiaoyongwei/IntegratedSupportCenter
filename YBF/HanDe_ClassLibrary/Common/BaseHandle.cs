using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using HanDe_ClassLibrary.LogCommon;

namespace HandeJobManager.Common
{
    /// <summary>
    /// 基础操作的静态类
    /// </summary>
    public static class BaseHandle
    {
        /// <summary>
        /// 获取网卡ID代码 
        /// </summary>
        /// <returns></returns>
        public static string GetNetworkAdpaterID()
        {
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac += mo["MacAddress"].ToString() + " ";
                        break;
                    }
                moc = null;
                mc = null;
                return mac.Trim();
            }
            catch (Exception e)
            {
               Log.WriteLog("获取网卡ID代码时出错" + e.Message);
                return "uMnIk";
            }
        }

        /// <summary>
        /// 提供字节,返回文件的大小(以GB,MB,KB,B表示)
        /// </summary>
        /// <param customerName="size"></param>
        /// <returns></returns>
        public static string GetFileSizeString(double size)
        {

            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            while (size >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                size =Math.Round( size / 1024,2);
            }

            string filesize = String.Format("{0:0.##} {1}", size, sizes[order]);
            return filesize; 
        }

        /// <summary>
        /// 提供文件名,返回文件的大小(以GB,MB,KB,B表示)
        /// </summary>
        /// <param customerName="size"></param>
        /// <returns></returns>
        public static string GetFileSizeString(string sFileFullName)
        {
            FileInfo fiInput = new FileInfo(sFileFullName);
            double len = fiInput.Length;

            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            while (len >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                len = len / 1024;
            }

            string filesize = String.Format("{0:0.##} {1}", len, sizes[order]);
            return filesize;  
        }

        /// <summary>
        /// 显示关于日期格式的提示窗口
        /// </summary>
        public static void Show_AboutDateFormat_Form()
        {
            Form FormFormat = new Form();
            FormFormat.ShowIcon = false;
            FormFormat.Text = "格式说明";
            FormFormat.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            FormFormat.TopMost = true;
            FormFormat.Size = new Size(400, 300);
            FormFormat.MinimumSize = FormFormat.Size;
            FormFormat.MaximumSize = FormFormat.Size;

            TextBox tb = new TextBox();
            tb.Multiline = true;
            tb.Dock = DockStyle.Fill;
            tb.AppendText("格式如下:  (注意'*'的位置)" + Environment.NewLine);
            tb.AppendText("名称1*目标目录1" + Environment.NewLine);
            tb.AppendText("名称2*目标目录2" + Environment.NewLine);
            tb.AppendText(Environment.NewLine);
            tb.AppendText("占位符如下:" + Environment.NewLine);
            tb.AppendText("<年份>,表示当前年份,如:2017,2018;" + Environment.NewLine);
            tb.AppendText("<日期1>,表示单位数的日期,如:4-23,12-5;" + Environment.NewLine);
            tb.AppendText("<日期2>,表示双位数的日期,如:04-23,12-05;" + Environment.NewLine);
            tb.AppendText("<月份1>,表示单位数的月份,如:4,12;" + Environment.NewLine);
            tb.AppendText("<月份2>,表示双位数的月份,如:04,12;" + Environment.NewLine);
            tb.AppendText("<日子1>,表示单位数的日子,如:23,5;" + Environment.NewLine);
            tb.AppendText("<日子2>,表示双位数的日子,如:23,05;" + Environment.NewLine);
            tb.AppendText(Environment.NewLine);
            tb.AppendText("例如:" + Environment.NewLine);
            tb.AppendText(@"当天ps*\\Evo28204\JobData\客户文件\(88)\<月份1>月\<日期1>\ps" + Environment.NewLine);
            tb.AppendText(@"如果当时是11月2日,则表示" + Environment.NewLine);
            tb.AppendText(@"\\Evo28204\JobData\客户文件\(88)\11月\11-2\ps" + Environment.NewLine);
            tb.ReadOnly = true;
            FormFormat.Controls.Add(tb);
            FormFormat.TopMost = true;
            FormFormat.Show();
        }
        /// <summary>  
        /// 执行DOS命令，返回DOS命令的输出  
        /// </summary>  
        /// <param name="dosCommand">dos命令</param>  
        /// <returns>返回DOS命令的输出</returns>  
        public static string ExecuteCom(string command, bool isReturn)
        {
            Process p = new Process();
            string strOuput = "";
            try
            {
                //设置要启动的应用程序
                p.StartInfo.FileName = "cmd.exe";
                //是否使用操作系统shell启动
                p.StartInfo.UseShellExecute = false;
                // 接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardInput = true;
                //输出信息
                p.StartInfo.RedirectStandardOutput = true;
                // 输出错误
                p.StartInfo.RedirectStandardError = true;
                //不显示程序窗口
                p.StartInfo.CreateNoWindow = true;
                //启动程序
                p.Start();

                //向cmd窗口发送输入信息
                p.StandardInput.WriteLine(command + "&exit");

                //是否需要返回信息
                if (!isReturn)
                {
                    return "";
                }

                p.StandardInput.AutoFlush = true;

                //获取输出信息
                strOuput = p.StandardOutput.ReadToEnd();

                //等待程序执行完退出进程
                p.WaitForExit();
            }
            finally
            {
                p.Close();
            }

            return strOuput;
        }
    }
}
