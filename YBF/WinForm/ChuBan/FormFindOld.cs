using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YBF.Class.Comm;
using excelToTable_NPOI;
using System.IO;
using System.Diagnostics;
using YBF.Class.Model;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;
using HanDe_ClassLibrary.LogCommon;



namespace YBF.WinForm.ChuBan
{
    public partial class FormFindOld : Form
    {
        private string keyWordColumnName = "文件名";
        private List<string> KeyWordList = new List<string>();
        private JobInfo Job = null;
        private string KeyWordTxt = "Data\\KeyWord.txt";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        public FormFindOld(JobInfo job)
        {
            this.Job = job;
            InitializeComponent();
        }

        private void FormFindOld_Load(object sender, EventArgs e)
        {


            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Close();
                }
            }

            //下拉框
            if (File.Exists(KeyWordTxt))
            {
                this.KeyWordList = File.ReadAllLines(KeyWordTxt).ToList<string>();
            }

            if (KeyWordList.Count > 1000)
            {
                for (int i = KeyWordList.Count - 1; i >= 1000; i--)
                {
                    KeyWordList.RemoveAt(i);
                }
            }

            if (Job != null)
            {
                KeyWordList_Add(GetString(Job.Cpmc));
            }
            if (KeyWordList.Count > 0)
            {
                this.comboBoxKeyword.Text = KeyWordList[0];
            }

            //**根据客户智能生产搜索关键字
            if (Job!=null)
            {
                //Regex regex = new Regex("\\d{8,}");
                
                //if ((Job.Khjc.Equals("浙江泵业")||Job.Khjc.Equals("中新"))&&regex.IsMatch(Job.Cpmc))
                //{
                //    this.comboBoxKeyword.Text = regex.Match(Job.Cpmc).Value;
                //}
                //else
                //{
                //    this.comboBoxKeyword.Text = Job.Cpmc.TrimEnd("-AB面".ToCharArray());
                //}
                this.comboBoxKeyword.Text = Job.Cpmc.TrimEnd("-AB面".ToCharArray());
                
            }
            comboBoxKeyword.Items.Clear();
            comboBoxKeyword.Items.AddRange(KeyWordList.ToArray());
            Comm_Method.Init_Tabel_Excel();
            Comm_Method.Init_PdfFileList();
            SearchOldFile();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchOldFile();
            
        }

        private void SearchOldFile()
        {

            try
            {
                Comm_Method.Init_Tabel_Excel();
                this.dgvExcel.DataSource = null;
                string kw = this.comboBoxKeyword.Text;
                if (string.IsNullOrWhiteSpace(kw))
                {
                    
                    return;
                }
                DataTable dt = Comm_Method.Table_Excel.Clone();
                //dt.Columns.RemoveAt(dt.Columns.Count - 1);
                //dt.Columns.RemoveAt(dt.Columns.Count - 1);
                //dt.Columns.RemoveAt(dt.Columns.Count - 1);
                if (checkBoxSize.Checked)
                {

                }
                else
                {
                    foreach (DataRow row in Comm_Method.Table_Excel.Rows)
                    {
                        string cpmc = row[keyWordColumnName].ToString();

                        if (IsEachContain(cpmc, kw))
                        {
                            DataRow newRow = dt.NewRow();
                            foreach (DataColumn dc in dt.Columns)
                            {
                                newRow[dc] = row[dc.ColumnName];
                            }
                            dt.Rows.Add(newRow);
                        }
                    }
                    

                    if (dt.Rows.Count > 0 && Job != null)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["印刷机台"] = Job.Sjjt;
                        newRow["文件名"] = Job.Khjc + Job.Cpmc;
                        newRow["制造尺寸"] = Job.Zzcc.Replace("x", "*");
                        newRow["下料尺寸"] = Job.Mzcc;
                        newRow["颜色"] = "普:" + Job.Ss1 + " 专:" + Job.Ss2;
                        dt.Rows.InsertAt(newRow, 0);
                    }
                    this.dgvExcel.DataSource = dt;

                    //ListView
                    this.listViewFile.Items.Clear();
                    foreach (string file in Comm_Method.PdfFileList.FindAll(f => IsEachContain(Path.GetFileNameWithoutExtension(f), kw)))
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        if (fileInfo.Exists)
                        {
                            ListViewItem item = this.listViewFile.Items.Add(fileInfo.Name);
                            item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                            item.SubItems.Add(Math.Round(1.0 * fileInfo.Length / 1024 / 1024, 2) + "MB");
                            item.SubItems.Add(fileInfo.DirectoryName);
                            item.Tag = file;
                        }

                    }
                   
                }


                KeyWordList_Add(kw);
                this.comboBoxKeyword.Items.Clear();
                this.comboBoxKeyword.Items.AddRange(this.KeyWordList.ToArray());
                this.listViewFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                

                //确定分割线的位置
                int dgvRowCount = dgvExcel.RowCount;
                int listViewCount = listViewFile.Items.Count;

                if (dgvRowCount == 0 || listViewCount == 0)
                {
                    dgvRowCount++;
                    listViewCount++;
                    this.splitContainer1.SplitterDistance =
                    Convert.ToInt32((1.0 * dgvRowCount / (dgvRowCount + listViewCount)
                    * this.splitContainer1.Height));
                }
                else
                {
                    this.splitContainer1.SplitterDistance =
                    Convert.ToInt32((1.0 * dgvRowCount / (dgvRowCount + listViewCount)
                    * this.splitContainer1.Height));
                }

                //文字对齐
                dgvExcel.Columns["文件名"].DefaultCellStyle.Alignment
                    = DataGridViewContentAlignment.MiddleRight;
               

            }
            catch (Exception ex)
            {
                 Log.WriteLog(ex.ToString());
            }
            
        }

        private void KeyWordList_Add(string kw)
        {
            for (int i = 0; i < KeyWordList.Count; i++)
            {
                string item = KeyWordList[i];
                if (GetStringRemoveSpace(item).Equals(GetStringRemoveSpace(kw)))
                {
                    this.KeyWordList.RemoveAt(i); 
                    break;
                }
            }
            this.KeyWordList.Insert(0, kw);
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

        private string GetString(string str)
        {
            return Comm_Method.ToDBC(str.Replace("\\", "-")
                .Replace("/", "-").Replace("*", "x").ToLower());
        }
        private string GetStringRemoveSpace(string str)
        {
            return GetString(str).Replace(" ", "");
        }


        private bool IsEachContain(string str1, string str2)
        {
            string str11 = GetStringRemoveSpace(str1);
            string str22 = GetStringRemoveSpace(str2);

            return (str11.IndexOf(str22) > -1 || str22.IndexOf(str11) > -1);
            
            
        }
        //private bool IsEachContain(string str1, string str2)
        //{
        //    string str11 = GetStringRemoveSpace(str1);
        //    string str22 = GetStringRemoveSpace(str2);

        //    if (str11.IndexOf(str22) > -1 || str22.IndexOf(str11) > -1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        str1 = GetString(str1);
        //        str2 = GetString(str2);

        //        return IsEachContain(str1.Split(' '), str2)
        //            || IsEachContain(str2.Split(' '), str1);
        //    }
        //}

        private bool IsEachContain(string[] kwArray, string str)
        {
            foreach (string kw in kwArray)
            {
                if (string.IsNullOrWhiteSpace(kw))
                {
                    continue;
                }
                if (!IsEachContain(kw,str))
                {
                    return false;
                }
            }
            return true;
        }

        private void FormFindOld_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.WriteAllLines(KeyWordTxt, KeyWordList);
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            Open();
        }
        public static void OpenFolderAndSelectFile(String fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/n,/select," + fileFullName;
            System.Diagnostics.Process.Start(psi);
        }

        public static void OpenFile(String fileFullName)
        {
            if (File.Exists(fileFullName))
            {
                System.Diagnostics.Process.Start(fileFullName);
            }
        }

        private void tsmiGoto_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFile.SelectedItems)
            {
                string newPath = item.Tag.ToString();
                //判断是目录还是文件
                if (File.Exists(newPath))
                {
                    OpenFolderAndSelectFile(newPath); 
                    break;
                }
            }
        }

       
        private void comboBoxKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Enter)
            {
                this.buttonSearch_Click(this.comboBoxKeyword, new EventArgs());
            }
        }

        private void tsmiTransfer_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFile.SelectedItems)
            {
                string newPath = item.Tag.ToString();
                //判断是目录还是文件
                if (File.Exists(newPath))
                {
                    FileSystem.CopyFile(newPath
                        , @"\\128.1.30.111\柯和山\" + Path.GetFileName(newPath)
                        ,UIOption.AllDialogs,UICancelOption.DoNothing);
                }
            }
        }

       

    }
}
