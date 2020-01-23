using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;
using YBF.Class.Model;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

using YBF.Properties;
using YBF.Class.Comm;
using Explorer;

namespace YBF.WinForm.Ywj
{
    public partial class FormYwj : Form
    {
        public FormYwj()
        {
            InitializeComponent();
        }

        private void FormYwj_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }

            InitListView();
        }

        private void InitListView()
        {
            this.listViewYwj.Items.Clear();
            DataTable dt = SQLiteList.YBF.ExecuteDataTable("select * from Ywj");
            if (dt.Rows.Count > 0)
            {
                //排除名单
                List<string> pcmdList = new List<string>();
                foreach (DataRow md in SQLiteList.YBF.ExecuteDataTable("select * from Ywj_PaiChu").Rows)
                {
                    pcmdList.Add(md["FileFullName"].ToString());
                }


                foreach (DataRow dr in dt.Rows)
                {
                    YwjInfo ywj = new YwjInfo();
                    ywj.ID = Convert.ToInt32(dr["ID"]);
                    ywj.Name = dr["Name"].ToString();
                    ywj.Path = dr["Path"].ToString();
                    ywj.PathMove = dr["PathMove"].ToString();
                    if (!Comm_Method.IsConnectPath(ywj.Path))
                    {
                        continue;
                    }
                    //if (!Directory.Exists(ywj.Path))
                    //{
                    //    continue;
                    //}
                    foreach (FileInfo file in new DirectoryInfo(ywj.Path).EnumerateFiles())
                    {
                        //排除名单
                        if (pcmdList.Contains(file.FullName))
                        {
                            continue;
                        }
                        ywj.FileFullName = file.FullName;
                        //符合要求的正则表达式
                        Regex regex = new Regex(".+\\.pdf|.+\\.ai|.+\\.cdr", RegexOptions.IgnoreCase);
                        if (regex.IsMatch(file.Name))
                        {
                            //添加
                            ListViewItem lvi = new ListViewItem
                                (
                               new string[]{
                       file.Name,
                               file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"),
                             Math.Round(file.Length/1024.0/1024.0,2).ToString()+" MB",
                               ywj.Name
                           }
                                );
                            lvi.Tag = ywj;
                            //确定图标
                            if (file.Extension == ".exe" || file.Extension == "")   //程序文件或无扩展名
                            {
                                Icon fileIcon = GetSystemIcon.GetIconByFileName(file.FullName);
                                this.imageListFileImage.Images.Add(file.Name, fileIcon);
                                lvi.ImageKey = file.Name;
                            }
                            else if (file.Extension.ToLower() == ".cdr")   //程序文件或无扩展名
                            {
                                lvi.ImageKey = "cdrx4";  //确定图标   
                            }
                            else    //其它文件
                            {
                                if (!this.imageListFileImage.Images.ContainsKey(file.Extension))  //ImageList中不存在此类图标
                                {
                                    Icon fileIcon = GetSystemIcon.GetIconByFileName(file.FullName);
                                    this.imageListFileImage.Images.Add(file.Extension, fileIcon);
                                }
                                lvi.ImageKey = file.Extension;
                            }
                            this.listViewYwj.Items.Add(lvi);
                        }
                    }
                }
            }
            this.listViewYwj.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void tsmiSetting_Click(object sender, EventArgs e)
        {
            new FormYwjSetting().ShowDialog();
        }

        //true表示无效.false表示有效.
        //此函数为全局更改(慎用!!!)
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)//刷新
            {
                InitListView();
            }


            return false;

        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            InitListView();
        }

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            DateTime dTime = DateTime.Now;
            DataTable dTable = SQLiteList.YBF.ExecuteDataTable("SELECT [YwjLocalPath],[YwjPdfFolder]FROM [AppSetting]WHERE [MacAddress]='0'");
            string localPath = "";
            string PdfFolder = "";
            if (dTable.Rows.Count == 0)
            {
                throw new Exception("原文件的本地路径没有设置或不存在\nAI文件到处PDF的路径没有设置或不存在");

            }
            else
            {
                localPath = dTable.Rows[0]["YwjLocalPath"].ToString().TrimEnd('\\');
                PdfFolder = dTable.Rows[0]["YwjPdfFolder"].ToString().TrimEnd('\\');
                if (!Directory.Exists(localPath) || !Directory.Exists(PdfFolder))
                {
                    throw new Exception("原文件的本地路径没有设置或不存在\nAI文件到处PDF的路径没有设置或不存在");
                }
                string Path_CopyTo = string.Format(localPath+@"\{0}年{1}月\{1}-{2}",
                    dt.ToString("yy"), dt.Month, dt.Day);
                ListView.SelectedListViewItemCollection coll = this.listViewYwj.SelectedItems;
                if (coll.Count > 0)
                {
                    foreach (ListViewItem item in coll)
                    {
                        YwjInfo ywj = item.Tag as YwjInfo;
                        string sourceFileName = ywj.Path + "\\" + item.Text;
                        string destinationFileName = Path_CopyTo + "\\" + item.Text;
                        if (Path.GetExtension(sourceFileName).LastIndexOf(".pdf"
                           , StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            destinationFileName = PdfFolder + "\\"
                                + Path.GetFileName(destinationFileName);
                        }
                        FileSystem.CopyFile(sourceFileName, destinationFileName
                            , UIOption.AllDialogs, UICancelOption.DoNothing);

                        if (File.Exists(destinationFileName))
                        {
                            FileSystem.MoveFile(sourceFileName, ywj.PathMove + "\\" + item.Text
                           , UIOption.AllDialogs, UICancelOption.DoNothing);
                            //if (Path.GetExtension(destinationFileName).LastIndexOf(".ai", StringComparison.OrdinalIgnoreCase) > -1)
                            //{
                            //    Comm_Method.AiFileList.Add(destinationFileName);
                            //}
                        }
                    }
                    InitListView();
                    if (!Directory.Exists(Path_CopyTo + "\\ok"))
                    {
                        Directory.CreateDirectory(Path_CopyTo + "\\ok");
                    }
                    Process.Start("Explorer.exe", Path_CopyTo);

                }
            }

        }
        ///// <summary>
        ///// 转存为PDF
        ///// </summary>
        ///// <param name="fileList"></param>
        //public  void AutoSavePdf(List<string> fileList)
        //{

        //    if (fileList.Count == 0)
        //    {
        //        return;
        //    }
        //    //***开始自动转PDF
        //    //判断Adobe Illustrator CS6 (64 Bit)是否运行
        //    string aiexe = @"C:\Program Files\Adobe\AdobeIllustratorCS6_x64\Support Files\Contents\Windows\Illustrator.exe";
        //    if (File.Exists(aiexe))
        //    {
        //        Illustrator.ApplicationClass app = new Illustrator.ApplicationClass();
        //        foreach (string item in fileList)
        //        {
        //            app.DoJavaScript(Resources.AutoSavePdf.Replace
        //                ("*文件名*", item.Replace('\\', '/')));
        //        }
        //    }
        //}


        private void tsmiPaiChu_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection coll = this.listViewYwj.SelectedItems;
            List<string> sqlList = new List<string>();
            if (coll.Count > 0)
            {
                foreach (ListViewItem item in coll)
                {
                    YwjInfo ywj = item.Tag as YwjInfo;
                    string fileFullName = ywj.Path + "\\" + item.Text;
                    sqlList.Add(
                        "INSERT INTO [Ywj_PaiChu]([FileFullName])VALUES('"
                        + fileFullName + "');");
                }
                if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
                {
                    InitListView();
                }

            }
        }

        private void listViewYwj_ItemActivate(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listViewYwj.SelectedItems)
            {
                string newPath = (item.Tag as YwjInfo).FileFullName;
                //判断是目录还是文件
                if (File.Exists(newPath))
                    Process.Start(newPath); //打开文件
            }
        }
        public static void OpenFile(String fileFullName)
        {
            if (File.Exists(fileFullName))
            {
                System.Diagnostics.Process.Start(fileFullName);
            }
        }
    }
}
