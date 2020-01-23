using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using YBF.Properties;
using System.Threading;
using YBF.Class.Comm;

namespace YBF.WinForm.Ywj
{
    public partial class FormSavePdf : Form
    {

        private List<string> FileList = new List<string>();

        public FormSavePdf()
        {
            InitializeComponent();
        }

        private void FormSavePdf_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
        }

        private void FormSavePdf_DragDrop(object sender, DragEventArgs e)
        {
            //this.dgvFileNames.Rows.Clear();
            //string[] fileNames = ((string[])e.Data.GetData(DataFormats.FileDrop));
            //this.dgvFileNames.Rows.Add(fileNames.Length);
            //for(int i=0;i<fileNames.Length;i++)           
            //{
            //this.dgvFileNames["ColumnFileName", i].Value = fileNames[i];            
            //    this.dgvFileNames["ColumnFileName", i].Value = GradingPath.ReadFile(fileNames[i], 1, Direction.RTL, false);
            //    this.dgvFileNames["ColumnFileName", i].Tag = fileNames[i];
            //}


            string[] fileNames = ((string[])e.Data.GetData(DataFormats.FileDrop));
            FileNamesToDgv(fileNames);
        }

        private void FileNamesToDgv(string[] fileNames)
        {
            foreach (string item in fileNames)
            {
                int rowIndex = this.dgvSavePdf.Rows.Add();
                DataGridViewRow row = this.dgvSavePdf.Rows[rowIndex];
                row.Cells["ColumnFileName"].Value = item;
            }
        }

        private void FormSavePdf_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        ///// <summary>
        ///// 转存为PDF
        ///// </summary>
        //private void AutoSavePdf()
        //{
        //    if (this.FileList.Count == 0)
        //    {
        //        return;
        //    }
        //    //***开始自动转PDF
        //    //判断Adobe Illustrator CS6 (64 Bit)是否运行
        //    string aiexe = @"C:\Program Files\Adobe\AdobeIllustratorCS6_x64\Support Files\Contents\Windows\Illustrator.exe";
        //    if (File.Exists(aiexe))
        //    {
        //        Illustrator.ApplicationClass app = new Illustrator.ApplicationClass();
        //        foreach (string item in FileList)
        //        {
        //            app.DoJavaScript(Resources.AutoSavePdf.Replace
        //                ("*文件名*", item.Replace('\\', '/')));
        //        }
        //    }
        //}


        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in this.dgvSavePdf.Rows)
            {
                string aiFileName = item.Cells[0].Value.ToString();
                if (!Comm_Method.AiFileList.Contains(aiFileName))
                {
                    Comm_Method.AiFileList.Add(aiFileName);
                }
                
            }
           this.Dispose();
           
            ////FileList = new List<string>();
            ////foreach (DataGridViewRow item in this.dgvSavePdf.Rows)
            ////{
            ////    FileList.Add(item.Cells[0].Value.ToString());
            ////}
            ////AutoSavePdf();
            ////this.Dispose();
        }

        private void tsmiClearThisTable_Click(object sender, EventArgs e)
        {
            if (this.dgvSavePdf.Rows.Count>0
                &&MessageBox.Show("确定要清空'本列表数据'吗?", "确定?"
               , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.dgvSavePdf.Rows.Clear();
            }
        }

        private void tsmiClearSavePdfList_Click(object sender, EventArgs e)
        {
            if ( Comm_Method.AiFileList.Count>0
                &&MessageBox.Show("确定要清空'后台数据列表'吗?","确定?"
                ,MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                Comm_Method.AiFileList.Clear();
            }
        }
    }
}
