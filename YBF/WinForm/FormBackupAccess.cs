using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HandeJobManager
{
    public partial class FormBackupAccess : Form
    {
        public FormBackupAccess()
        {
            InitializeComponent();
        }

        //private void FormBackupAccess_Load(object sender, EventArgs e)
        //{
        //    BackupAccess();
        //    this.Dispose();
        //}

        ///// <summary>
        ///// 备份数据库
        ///// </summary>
        //public void BackupAccess()
        //{
        //    try
        //    {
        //        string accessFile = Application.StartupPath + "\\Data\\JobList.accdb";
        //        string backupFile = "C:\\BackupJobList\\JobList" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".accdb";
        //        if (!Directory.Exists(Path.GetDirectoryName(backupFile)))
        //        {
        //            Directory.CreateDirectory(Path.GetDirectoryName(backupFile));
        //        }
        //        string[] files = Directory.GetFiles(Path.GetDirectoryName(backupFile), "*.accdb");
        //        //只保留最近的6个备份
        //        if (files.Length > 5)
        //        {
        //            List<DateTime> dtList = new List<DateTime>();
        //            foreach (string item in files)
        //            {
        //                dtList.Add(File.GetCreationTime(item));
        //            }
        //            dtList.Sort();
        //            DateTime dtDel = dtList[dtList.Count - 5];
        //            foreach (string item in files)
        //            {
        //                if (File.GetCreationTime(item) < dtDel)
        //                {
        //                    File.Delete(item);
        //                }
        //            }
        //        }
                 
        //        File.Copy(accessFile, backupFile);
        //    }
        //    catch (Exception ex)
        //    {
        //        HandeJobManager.Common.Log.WriteLog(ex.Message);
        //    }
        //}

        /// <summary>
        /// 备份数据库
        /// </summary>
        public string BackupAccess()
        {
            //****调试状态则不需要备份*****
            if (Environment.CommandLine.IndexOf("\\bin\\Debug") > 0)
            {
                return "";
            }
            try
            {
                //系统盘至少还要有3个G才行
                //获取当前系统磁盘符，返回：C:
                string systemdrive = Environment.GetEnvironmentVariable("systemdrive") + "\\";
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.Name == systemdrive)
                    {
                        if (drive.TotalFreeSpace < 3L * 1024 * 1024 * 1024)
                        {
                            throw new Exception("系统盘剩余容量少于3GB");
                        }
                        break;
                    }
                }

                string DbFile = Application.StartupPath + "\\Data\\ybf.db";
                if (new FileInfo(DbFile).Length>500*1024*1024)
                {
                    return "";
                }
                string backupFile = Path.GetPathRoot(Environment.SystemDirectory) + "BackupJobList\\ybf" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".db";
                if (!Directory.Exists(Path.GetDirectoryName(backupFile)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(backupFile));
                }
                //读取到以"HandeDb*.db"格式的文件,也就是数据库文件
                string[] files = Directory.GetFiles(Path.GetDirectoryName(backupFile), "ybf*.db");
                //需要备份的数量
                int backupFileNum = 10;
                //只保留最近的若干个备份
                if (files.Length > backupFileNum)
                {
                    //新建一个列表,用于统计每个备份的数据库文件的备份时间
                    //因为我们是只保留最后备份的若干个数据库文件的
                    List<DateTime> dtList = new List<DateTime>();
                    foreach (string item in files)
                    {
                        dtList.Add(File.GetCreationTime(item));
                    }
                    dtList.Sort();
                    DateTime dtDel = dtList[dtList.Count - backupFileNum];
                    foreach (string item in files)
                    {
                        if (File.GetCreationTime(item) < dtDel)
                        {
                            File.Delete(item);
                        }
                    }
                }

                File.Copy(DbFile, backupFile);
                if (File.Exists(backupFile))
                {
                    return backupFile;
                }
            }
            catch
            {
                              
            }
            return "";
        }

       
       
    }
}
