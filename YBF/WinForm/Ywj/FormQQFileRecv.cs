using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using YBF.Class.Comm;
using Explorer;
using System.Diagnostics;

namespace YBF.WinForm.Ywj
{
    public partial class FormQQFileRecv : Form
    {
       private string path = @"D:\Users\Documents\Tencent Files\2774747853\FileRecv";
        public FormQQFileRecv()
        {
            InitializeComponent();
        }

        private void FormQQFileRecv_Load(object sender, EventArgs e)
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
            List<FileInfo> fileList = new List<FileInfo>();
            foreach (FileInfo file in new DirectoryInfo(path).GetFiles())
            {
                //符合要求的正则表达式
                Regex regex = new Regex(".+\\.pdf|.+\\.ai|.+\\.cdr", RegexOptions.IgnoreCase);
                if (file.LastWriteTime.AddDays(1)>DateTime.Now
                    &&regex.IsMatch(file.Name))
                {
                    fileList.Add(file);
                }
            }
            //按时间排序
            fileList.Sort(CompareByLastTime);
            foreach (FileInfo file in fileList)
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
            this.listViewYwj.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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
        private void tsmiAiToPdf_Click(object sender, EventArgs e)
        {
             ListView.SelectedListViewItemCollection coll = this.listViewYwj.SelectedItems;
             if (coll.Count > 0)
             {
                 if (!Directory.Exists(path + "\\ok"))
                 {
                     Directory.CreateDirectory(path + "\\ok");
                 }
                 foreach (ListViewItem item in coll)
                 {
                     string fileName = item.Tag.ToString();
                     if (Path.GetExtension(fileName).IndexOf(".ai",StringComparison.OrdinalIgnoreCase)==0)
                     {
                         Comm_Method.AiFileList.Add(fileName);
                     }
                 }
             }
             InitListView();
             
        }

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

        private void tsmiShuaXin_Click(object sender, EventArgs e)
        {
            InitListView();
        }

        private void listViewYwj_ItemActivate(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listViewYwj.SelectedItems)
            {
                string newPath = item.Tag.ToString();
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
