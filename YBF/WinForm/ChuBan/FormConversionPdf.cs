using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using YBF.Class.Comm;

namespace YBF.WinForm.ChuBan
{
    public partial class FormConversionPdf : Form
    {
        private List<FileInfo> PDFFileList = new List<FileInfo>();
        string path = AppConfig_Local.GetConversionPdfFolder();
        public FormConversionPdf()
        {
            InitializeComponent();
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (!IsHandleCreated)
            {
                this.Close();
            }
        }
        private void FormPublishPdf_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
            InitPDFFileList();
            ShowListView("");
           
        }

        private void InitPDFFileList()
        {
                if (Comm_Method.IsConnectPath(path))
                {
                    this.PDFFileList.Clear();
                    foreach (FileInfo PdfFile in new DirectoryInfo
                        (path).GetFiles("*.pdf"))
                    {
                        PDFFileList.Add(PdfFile);
                    }
                    //按时间排序
                    PDFFileList.Sort(CompareByLastTime);
                }
                else
                {
                    Comm_Method.ShowErrorMessage(path + "\n路径不存在!");
                }
        }

        private void ShowListView(string wordKey)
        {
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
            //添加
            ListViewItem lvi = new ListViewItem
                (
               new string[]{
                       file.Name,
                               file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"),
                             Math.Round(file.Length/1024.0/1024.0,2).ToString()+" MB"
                           }
                );
            lvi.Tag = file.FullName;
            this.listViewFile.Items.Add(lvi);//添加到listview中
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ShowListView(this.textBoxSearch.Text);
        }

        //true表示无效.false表示有效.
        //此函数为全局更改(慎用!!!)
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)//刷新
            {
                InitPDFFileList();
                ShowListView(this.textBoxSearch.Text);
            }
            else if (keyData==(Keys.Control|Keys.F))
            {
                this.textBoxSearch.Focus();
                this.textBoxSearch.SelectAll();
            }

            return false;

        }

        private void tsmiSelect_Click(object sender, EventArgs e)
        {
            bool isbbbb = false;
            List<ListViewItem> lviRemoveList = new List<ListViewItem>();
            foreach (ListViewItem lvi in this.listViewFile.SelectedItems)
            {
                string sourceFile = lvi.Tag.ToString();
                string destPath = @"\\EvoServer\JobData\PDF\已下单PDF";
                string destFile = destPath + "\\" + Path.GetFileName(sourceFile);
                if (File.Exists(sourceFile))
                {
                    FileSystem.MoveFile(sourceFile,destFile
                        ,UIOption.AllDialogs,UICancelOption.DoNothing);
                    isbbbb = true;                    
                }
            }
           
            if (isbbbb)
            {
                InitPDFFileList();
                ShowListView(this.textBoxSearch.Text);
            }
            
        }

        private void listViewFile_ItemActivate(object sender, EventArgs e)
        {
            Open();
        }

        /// <summary>
        /// 打开文件夹或文件
        /// </summary>
        private void Open()
        {

            foreach (ListViewItem item in listViewFile.SelectedItems)
            {
                string newPath = item.Tag.ToString();
                //判断是目录还是文件
                if (File.Exists(newPath))
                    Process.Start(newPath); //打开文件
            }

            //if (listViewFile.SelectedItems.Count > 0)
            //{
            //    string newPath = listViewFile.SelectedItems[0].Tag.ToString();
            //    //判断是目录还是文件
            //    if (File.Exists(newPath))
            //        Process.Start(newPath); //打开文件
            //}

        }
        #region Drag and drop
        /// <summary>
        /// Called when we start dragging an item out of our listview
        /// </summary>
        private void listViewFile_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            string[] files = GetSelection();
            if (files != null)
            {
                DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy /* | DragDropEffects.Move | DragDropEffects.Link */);
            }
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
                files[i++] = item.Tag.ToString();
            }
            return files;
        }
        #endregion


        private int CompareByLastTime(FileInfo y, FileInfo x)
        {
            if (x == null)
            {
                if (y == null)
                {
                    //如果x为空并且y也没空，则判断相等
                    return 0;
                }
                else
                {
                    //如果x为空并且y不为空，则判断y大
                    return -1;
                }
            }
            else
            {
                //如果x不为空
                if (y == null)
                // ...同时y为空，则判断x大
                {
                    return 1;
                }
                else
                {
                    // ...同时y也不为空，则判断两者的提交时间
                    int retval = x.LastWriteTime.CompareTo(y.LastWriteTime);

                    if (retval != 0)
                    {
                        //如果x和y的提交时间不一样，则时间晚的大
                        return retval;
                    }
                    else
                    {

                        return 0;
                    }
                }
            }
        }
    }
}
