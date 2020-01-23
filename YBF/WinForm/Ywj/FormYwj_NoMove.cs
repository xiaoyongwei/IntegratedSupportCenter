using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using YBF.Class.Comm;
using HandeJobManager.DAL;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Reflection;
using YBF.Properties;


namespace YBF.WinForm.Ywj
{

    public partial class FormYwj_NoMove : Form
    {
        private List<FileInfo> PDFFileList = new List<FileInfo>();


        public FormYwj_NoMove()
        {
            InitializeComponent();
        }

        private void FormYwj_NoMove_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
            InitFileList();
            ShowListView();
        }

        private void InitFileList()
        {
            this.PDFFileList.Clear();
            DataTable dt = SQLiteList.YBF.ExecuteDataTable("SELECT*FROM [CopyFile]");

            string[] extens = { "ai", "cdr", "pdf" };
            foreach (string sourceFolder in AppConfig_Local.GetSjbYwjFolder())
            {
                if (!Comm_Method.IsConnectPath(sourceFolder))
                {
                    Comm_Method.ShowErrorMessage(sourceFolder + "\n路径不存在!");
                    return;
                }
                foreach (FileInfo sourceFile in new DirectoryInfo(sourceFolder)
                    .GetFiles(".", System.IO.SearchOption.AllDirectories))
                {
                    //if (!checkBoxPublished.Checked&&sourceFile.DirectoryName.Contains("已出版"))
                    //{
                    //    continue;
                    //}
                    bool isExetn = false;
                    foreach (string item in extens)
                    {
                        if (sourceFile.Extension.IndexOf(item, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            isExetn = true;
                            break;
                        }
                    }
                    if (!isExetn)
                    {
                        continue;
                    }
                    bool isSome = false;
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow row = dt.Rows[i];
                        DateTime dt1 = Convert.ToDateTime(row["LastTime"]);
                        DateTime dt2 = sourceFile.LastWriteTime;

                        if (row["FileName"].ToString().
                            Equals(sourceFile.Name, StringComparison.OrdinalIgnoreCase)
                            && CompareDateTime(Convert.ToDateTime(row["LastTime"]), sourceFile.LastWriteTime)
                            && Convert.ToInt64(row["Size"]) == sourceFile.Length)
                        {
                            dt.Rows.RemoveAt(i);
                            isSome = true;
                            break;
                        }
                    }
                    if (isSome)
                    {
                        continue;
                    }
                    else
                    {
                        PDFFileList.Add(sourceFile);
                    }
                }
            }
            //按从晚到早的时间排序
            for (int i = 0; i < PDFFileList.Count - 1; i++)
            {
                for (int j = i + 1; j <= PDFFileList.Count - 1; j++)
                {
                    if (PDFFileList[i].LastWriteTime < PDFFileList[j].LastWriteTime)
                    {
                        FileInfo tempExcel = PDFFileList[i];
                        PDFFileList[i] = PDFFileList[j];
                        PDFFileList[j] = tempExcel;
                    }
                }
            }
        }

        private void ShowListView()
        {
            string wordKey = this.textBoxSearch.Text.Trim();
            this.listViewFile.Items.Clear();
            this.listViewFile.BeginUpdate();
            if (string.IsNullOrWhiteSpace(wordKey))
            {
                foreach (FileInfo item in PDFFileList)
                {
                    ListView_Add(item);
                }
            }
            else
            {
                foreach (FileInfo item in PDFFileList)
                {
                    if (item.Name.IndexOf(wordKey, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        ListView_Add(item);
                    }
                }
            }
            this.listViewFile.EndUpdate();
            this.listViewFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        private void ListView_Add(FileInfo file)
        {
            if (!checkBoxPublished.Checked && file.DirectoryName.Contains("已出版"))
            {
                return;
            }
            //添加
            ListViewItem lvi = new ListViewItem
                (
               new string[]{
                       file.Name,
                               file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"),
                             Math.Round(file.Length/1024.0/1024.0,2).ToString()+" MB",
                             file.DirectoryName
                           }
                );
            lvi.Tag = file;
            if (file.DirectoryName.Contains("已出版"))
            {
                lvi.ForeColor = Color.Blue;
            }
            this.listViewFile.Items.Add(lvi);//添加到listview中
        }

        private bool CompareDateTime(DateTime dt1, DateTime dt2)
        {
            return dt1.Year == dt2.Year
                && dt1.Month == dt2.Month
            && dt1.Day == dt2.Day
                && dt1.Hour == dt2.Hour
                && dt1.Minute == dt2.Minute
                && dt1.Second == dt2.Second;
        }

        //true表示无效.false表示有效.
        //此函数为全局更改(慎用!!!)
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)//刷新
            {
                InitFileList();
                ShowListView();
            }
            else if (keyData == (Keys.Control | Keys.F))
            {
                this.textBoxSearch.Focus();
                this.textBoxSearch.SelectAll();
            }

            return false;

        }

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            CopyFile(true,false);
        }

        private void CopyFile(bool isCopy,bool isConvertToPDF)
        {
            DateTime dt = DateTime.Now;
            List<string> ctpYwjList = new List<string>();
            string localPath = AppConfig_Local.GetCTPYwjFolder();
            string AiToPdfTempFolder = AppConfig_Local.GetAiToPdfFolder();
            if (string.IsNullOrWhiteSpace(localPath) || string.IsNullOrWhiteSpace(AiToPdfTempFolder)
                 || !Comm_Method.IsConnectPath(AiToPdfTempFolder))
            {
                Comm_Method.ShowErrorMessage("原文件的本地路径没有设置或不存在\nAI文件导出PDF的路径没有设置或不存在");
                return;
            }
            else
            {
                ListView.SelectedListViewItemCollection coll = this.listViewFile.SelectedItems;
                if (coll.Count > 0)
                {
                    Directory.CreateDirectory(localPath);
                    List<string> sqlList = new List<string>();
                    foreach (ListViewItem item in coll)
                    {
                        FileInfo ywj = item.Tag as FileInfo;
                        string sourceFileName = ywj.FullName;
                        string destinationFileName = localPath + "\\" + item.Text;
                        if (isCopy)
                        {                            
                            if (Path.GetExtension(sourceFileName).LastIndexOf("pdf"
                               , StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                destinationFileName = AiToPdfTempFolder + "\\"
                                    + Path.GetFileName(destinationFileName);
                            }
                            FileSystem.CopyFile(sourceFileName, destinationFileName
                                , UIOption.AllDialogs, UICancelOption.DoNothing);

                            if (File.Exists(destinationFileName))
                            {
                                if (!sourceFileName.Contains("已出版"))
                                {
                                   // Directory.CreateDirectory(Path.GetDirectoryName(destinationFileName));
                                    FileSystem.MoveFile(sourceFileName,
                                        Path.GetDirectoryName(sourceFileName) + "\\已出版\\" + Path.GetFileName(sourceFileName)
                              , UIOption.AllDialogs, UICancelOption.DoNothing);
                                }
                                sqlList.Add(string.Format(
                  "INSERT INTO [CopyFile]([FileName],[LastTime],[Size])VALUES("
                  + "'{0}',datetime('{1}'),{2});"
                  , ywj.Name, ywj.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"), ywj.Length));
                            }
                            ctpYwjList.Add(destinationFileName);
                        }
                        else
                        {
                            sqlList.Add(string.Format(
                    "INSERT INTO [CopyFile]([FileName],[LastTime],[Size])VALUES("
                    + "'{0}',datetime('{1}'),{2});"
                    , ywj.Name, ywj.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"), ywj.Length));
                        }
                        
                    }
                    SQLiteList.YBF.ExecuteSqlTran(sqlList);
                    if (ctpYwjList.Count > 0)
                    {
                        InitFileList();
                        ShowListView();
                        if (!Directory.Exists(localPath + "\\ok"))
                        {
                            Directory.CreateDirectory(localPath + "\\ok");
                        }
                        Process.Start("Explorer.exe", localPath);
                    }
                    if (isConvertToPDF)
                    {
                        foreach (string file in ctpYwjList)
                        {
                            Comm_Method.AiToPDF(file);
                          
                        }
                    }
                }
            }

        }



        private void timsiMarkCopy_Click(object sender, EventArgs e)
        {
            CopyFile(false,false);
        }

        private void listViewYwj_ItemActivate(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listViewFile.SelectedItems)
            {
                string newPath = (item.Tag as FileInfo).FullName;
                //判断是目录还是文件
                if (File.Exists(newPath))
                    Process.Start(newPath); //打开文件
            }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ShowListView();
        }
        #region Drag and drop
        /// <summary>
        /// Called when we start dragging an item out of our listview
        /// </summary>
        private void listViewFile_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {

        }
        /// <summary>
        /// Routine to get the current selection from the listview
        /// </summary>
        /// <returns>Seletced items or null if no selection</returns>
        private string[] GetSelection()
        {
            if (listViewFile.SelectedItems.Count == 0)
                return null;

            string[] files = new string[listViewFile.SelectedItems.Count];
            int i = 0;
            foreach (ListViewItem item in listViewFile.SelectedItems)
            {
                files[i++] = (item.Tag as FileInfo).FullName;
            }
            return files;
        }
        #endregion

        private void checkBoxPublished_CheckedChanged(object sender, EventArgs e)
        {
            ShowListView();
        }

        private void tsmiCopyAndConvertToPDF_Click(object sender, EventArgs e)
        {
            CopyFile(true, true);
        }
    }
}
