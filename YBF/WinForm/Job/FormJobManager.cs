using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using HandeJobManager.DAL;
using YBF.WinForm.Job;
using System.Collections.Generic;
using YBF.Class.Comm;
using YBF.WinForm.YBFFile;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using HanDe_ClassLibrary.PrinergyEvoFile.Preps;
using HanDe_ClassLibrary.PrepressFile.Adobe.Acrobat;
using HanDe_ClassLibrary.Common.SizeBox;
using Aspose.Pdf;
using HanDe_ClassLibrary.LogCommon;
using HanDe_ClassLibrary.Common.Unit;
using System.Text.RegularExpressions;
namespace YBF.WinForm
{
    partial class FormJobManager
    {
        FormSearch search = new FormSearch();//搜索窗口
        private string SelectSql = "*";
        private string FromSql = "[作业扩展] ";
        private string WhereTime = "";
        private string WhereField = "";
        private string OrderBy = "[时间] DESC";
        private int Limit = 500;
        private int Offset = 0;
        private FileInfo[] pdfFiles;//所有PDF
        public FormJobManager()
        {
            InitializeComponent();
        }

        private void FormJobManager_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }

            dgv.DefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            InitDgv();
        }

        private void InitPdfList()
        {
            string pdfPath = @"\\EvoServer\JobData\PDF\已下单PDF";
            if (Comm_Method.IsConnectPath(pdfPath))
            {
                pdfFiles = new DirectoryInfo(pdfPath).GetFiles("*.pdf", System.IO.SearchOption.AllDirectories);
            }

        }

        public void InitDgv()
        {
            string str = "select" + SelectSql + " FROM " + FromSql;
            string text = (WhereField + " AND " + WhereTime).Trim().Trim("AND".ToCharArray());
            str += (string.IsNullOrWhiteSpace(text) ? "" : ("where " + text + " "));
            object obj = str;
            str = obj + "Order By " + OrderBy + " Limit " + Limit + " Offset " + Offset + ";";
            DataTableTodgv(SQLiteList.YBF.ExecuteDataTable(str), true);
            dgv.Sort(时间, ListSortDirection.Descending);
            InitPdfList();
        }

        public void UpdateRow(List<string> idList)
        {
            if (idList == null || idList.Count == 0)
            {
                return;
            }
            foreach (string id in idList)
            {
                UpdateRow(id);
            }
        }

        public void UpdateRow(string id)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string idStr = row.Cells["ID"].Value.ToString();
                if (id == idStr)
                {
                    foreach (DataRow dr in SQLiteList.YBF.ExecuteDataTable("SELECT " + SelectSql + " from " + FromSql + " where [ID]=" + id).Rows)
                    {
                        Update_RowToDgv(dr, row);
                    }
                    break;
                }
            }
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            List<string> idList = new List<string>();
            if (dgv.SelectedRows.Count > 1)//批量修改，统计id
            {
                foreach (DataGridViewRow item in dgv.SelectedRows)
                {
                    string id = item.Cells["ID"].Value.ToString();
                    if (!idList.Contains(id))
                    {
                        idList.Add(id);
                    }
                }
            }
            else//单个修改，添加一个ID就退出循环
            {
                foreach (DataGridViewCell cell in dgv.SelectedCells)
                {
                    string id = cell.OwningRow.Cells["ID"].Value.ToString();
                    if (!idList.Contains(id))
                    {
                        idList.Add(id);
                        break;
                    }
                }
            }

            //开始修改           
            if (idList.Count == 1)//单个修改
            {
                jobInfo = new FormJobInformation(false, idList, false, null);

            }

            else if (idList.Count > 0)//批量修改
            {
                jobInfo = new FormJobInformation(false, idList);
            }

            if (jobInfo == null || jobInfo.IsDisposed)
            {
                jobInfo = new FormJobInformation();
            }
            jobInfo.MdiParent = this.MdiParent;
            jobInfo.WindowState = FormWindowState.Maximized;
            jobInfo.Show();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                tsmiUpdate_Click(this, new EventArgs());
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0 && MessageBox.Show("确定要删除选择的记录吗？", "删除？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> list = new List<string>();
                List<DataGridViewRow> rowList = new List<DataGridViewRow>();
                foreach (DataGridViewRow selectedRow in dgv.SelectedRows)
                {
                    string str = selectedRow.Cells["ID"].Value.ToString();
                    object obj = SQLiteList.YBF.ExecuteScalar("select count(*) from [作业] where id=" + str);
                    if (obj == null || Convert.ToInt32(obj) < 1)
                    {
                        Comm_Method.ShowErrorMessage("ID为：" + str + " 的数据不存在！");
                    }
                    else
                    {
                        list.Add("DELETE FROM [作业]WHERE ID=" + str + ";");
                        rowList.Add(selectedRow);
                    }
                }
                if (SQLiteList.YBF.ExecuteSqlTran(list))
                {
                    foreach (DataGridViewRow row in rowList)
                    {
                        dgv.Rows.Remove(row);
                    }
                    MessageBox.Show("删除成功！");

                }
                else
                {
                    Comm_Method.ShowErrorMessage("删除失败！");
                }
            }
        }


        FormJobInformation jobInfo = null;
        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            if (jobInfo == null || jobInfo.IsDisposed)
            {
                jobInfo = new FormJobInformation();
            }
            jobInfo.MdiParent = this.MdiParent;
            jobInfo.WindowState = FormWindowState.Maximized;
            jobInfo.Show();
            //if (new FormJobInformation().ShowDialog() == DialogResult.OK)
            //{
            //    InitDgv();
            //}
        }

        private void tsmiAddFile_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in this.dgv.SelectedCells)
            {
                string id = cell.OwningRow.Cells["ID"].Value.ToString();
                FormAllPdfFile formAllPdfFile = new FormAllPdfFile(id);
                if (formAllPdfFile.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (string selectPDFFile in formAllPdfFile.SelectPDFFileList)
                    {
                        stringBuilder.Append(selectPDFFile + "*");
                    }
                    SQLiteList.YBF.ExecuteNonQuery(string.Format("UPDATE [作业]SET[关联的文件] ='{0}'\tWHERE ID={1}", stringBuilder.ToString(), id));
                    Update_RowToDgv(SQLiteList.YBF.ExecuteDataTable("select * from [作业扩展] where id=" + id).Rows[0], cell.OwningRow);
                    dgv_CellClick(this, new DataGridViewCellEventArgs(cell.ColumnIndex, cell.RowIndex));
                }
                break;
            }
        }

        private void tsmiToday_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            foreach (ToolStripMenuItem dropDownItem in tsmiShow.DropDownItems)
            {
                dropDownItem.Checked = dropDownItem.Equals(toolStripMenuItem);
            }

            OrderBy = "[时间]DESC ";
            WhereField = "";
            bool shuaxin = true;
            switch (toolStripMenuItem.Text)
            {
                case "最近500项":
                    WhereTime = "";
                    break;
                case "当日作业":
                    WhereTime = "[时间]BETWEEN datetime(date('now','localtime')) AND datetime('now','localtime')";
                    break;
                case "7日内作业":
                    WhereTime = "[时间]BETWEEN datetime('now','localtime','-7 day') AND datetime('now','localtime')";
                    break;
                case "30日内作业":
                    WhereTime = "[时间]BETWEEN datetime('now','localtime','-30 day') AND datetime('now','localtime')";
                    break;
                case "1年内作业":
                    WhereTime = "[时间]BETWEEN datetime('now','localtime','-365 day') AND datetime('now','localtime')";
                    break;
                case "自定义":
                    if (search.ShowDialog() == DialogResult.OK)
                    {
                        WhereField = search.WhereField;
                        WhereTime = search.WhereTime;
                    }
                    else
                    {
                        shuaxin = false;
                    }
                    break;
                default:
                    shuaxin = false;
                    break;
            }
            if (shuaxin)
            {
                InitDgv();
            }

        }

        private void DataGridViewRowColor(DataGridViewRow row)
        {
            if (Convert.ToBoolean(row.Cells["暂停"].Value))
            {
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                row.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
                row.DefaultCellStyle.Font = new Font("宋体", 9, FontStyle.Italic);
                row.ErrorText = "暂停";
            }
            else if (Convert.ToBoolean(row.Cells["报废"].Value))
            {
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.OrangeRed;
                row.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.OrangeRed;
                row.DefaultCellStyle.Font = new Font("宋体", 9, FontStyle.Italic);
                row.ErrorText = "报废";
            }
            else
            {
                row.DefaultCellStyle = new DataGridViewCellStyle();
                row.ErrorText = "";
                //row.DefaultCellStyle.ForeColor = Color.Empty;
                //row.DefaultCellStyle.SelectionForeColor = Color.Empty;
            }
        }

        private void tsmiChange_Click(object sender, EventArgs e)
        {
            tsmiUpdate_Click(this, new EventArgs());
        }

        private void tsmiDelete_cms_Click(object sender, EventArgs e)
        {
            tsmiDelete_Click(this, new EventArgs());
        }

        private void tsmiPublished_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0)
            {
                List<string> idList = new List<string>();
                foreach (DataGridViewCell selectedCell in dgv.SelectedCells)
                {
                    string item = selectedCell.OwningRow.Cells["ID"].Value.ToString();
                    if (!idList.Contains(item))
                    {
                        idList.Add(item);
                    }
                }
                List<string> sqlList = new List<string>();
                foreach (string id in idList)
                {
                    sqlList.Add("UPDATE[作业]SET[出版]=([出版]+1)%2 WHERE id=" + id + ";");
                }
                if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
                {
                    UpdateRow(idList);
                }
                else
                {
                    Comm_Method.ShowErrorMessage("标记[出版]失败！");
                }
            }
        }

        private void tmsiAbolish_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0 && MessageBox.Show("确定要将选择的记录标记为[暂停]吗？", "暂停？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> idList = new List<string>();
                foreach (DataGridViewCell selectedCell in dgv.SelectedCells)
                {
                    string item = selectedCell.OwningRow.Cells["ID"].Value.ToString();
                    if (!idList.Contains(item))
                    {
                        idList.Add(item);
                    }
                }
                List<string> sqlList = new List<string>();
                foreach (string id in idList)
                {
                    sqlList.Add("UPDATE[作业]SET[暂停]= ([暂停]+1)%2 WHERE id=" + id + ";");
                }
                if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
                {
                    UpdateRow(idList);
                }
                else
                {
                    Comm_Method.ShowErrorMessage("标记[暂停]失败！");
                }
            }
        }

        private void tsmiShuaxin_Click(object sender, EventArgs e)
        {
            InitDgv();
        }


        //添加作业到DataGridView
        private bool Add_RowToDgv(DataRow dr)
        {
            return Update_RowToDgv(dr, null);
            //DataGridViewRow dgvRow = this.dgv.Rows[this.dgv.Rows.Add()];
            //dgvRow.Cells["ID"].Value = dr["ID"];
            //dgvRow.Cells["时间"].Value = Convert.ToDateTime(dr["时间"]).ToString("yyyy-MM-dd HH:mm:ss");
            //dgvRow.Cells["暂停"].Value = dr["暂停"];
            //dgvRow.Cells["出版"].Value = dr["出版"];
            //dgvRow.Cells["报废"].Value = dr["报废"];
            //dgvRow.Cells["工单号"].Value = dr["工单号"];
            //dgvRow.Cells["稿袋号"].Value = dr["稿袋号"];
            //dgvRow.Cells["机台"].Value = dr["机台"];
            //dgvRow.Cells["客户名"].Value = dr["客户名"];
            //dgvRow.Cells["文件名"].Value = dr["文件名"];
            //dgvRow.Cells["制造尺寸"].Value = dr["制造尺寸"];
            //dgvRow.Cells["下料尺寸"].Value = dr["下料尺寸"];
            //dgvRow.Cells["咬口印能捷"].Value = dr["咬口印能捷"];
            //dgvRow.Cells["颜色"].Value = dr["颜色"];
            //dgvRow.Cells["下料尺寸"].Value = dr["下料尺寸"];
            //dgvRow.Cells["印版数量"].Value = dr["印版数量"];
            //dgvRow.Cells["印版类型"].Value = dr["印版类型"];
            //dgvRow.Cells["备注"].Value = dr["备注"];
            //dgvRow.Cells["关联的文件"].Value = dr["关联的文件"];
            ////行的颜色
            //DataGridViewRowColor(dgvRow);
            //return true;
        }



        ////修改作业后,如果表格里面修改成功了的话,那就更新相对应的DataGridView行.
        //private bool Update_RowToDgv(JobInfo job, DataGridViewRow row)
        //{
        //    if (job.LastTime > Convert.ToDateTime(row.Tag))
        //    {
        //        row.Cells["Date"].Value = job.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
        //        row.Cells["Abolish"].Value = job.Abolish;
        //        row.Cells["Bill"].Value = job.Bill;
        //        row.Cells["Published"].Value = job.Published;
        //        row.Cells["CustomerName"].Value = job.CustomerName;
        //        row.Cells["FileName"].Value = job.FileName;
        //        row.Cells["plant"].Value = job.Plant;
        //        row.Cells["PublishColor"].Value = job.PublishColor;
        //        row.Cells["Paper"].Value = job.Paper;
        //        row.Cells["Bite"].Value = job.Bite;
        //        row.Cells["Line"].Value = job.Line;
        //        row.Cells["Delivery"].Value = job.Delivery;
        //        row.Cells["Note"].Value = job.Note;
        //        row.Tag = job.LastTime;
        //        //行的颜色
        //        DataGridViewRowColor(row);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        /// <summary>
        /// 修改作业后,如果表格里面修改成功了的话,那就更新相对应的DataGridView行.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="dgvRow"></param>
        /// <returns></returns>
        public bool Update_RowToDgv(DataRow dr, DataGridViewRow dgvRow)
        {
            //if (Convert.ToDateTime(dgvRow.Tag) < Convert.ToDateTime(dr["LastTime"]))
            //{
            if (dgvRow == null)
            {
                dgvRow = this.dgv.Rows[this.dgv.Rows.Add()];
                dgvRow.Cells["ID"].Value = dr["ID"];
            }
            dgvRow.Cells["时间"].Value = Convert.ToDateTime(dr["时间"]).ToString("yyyy-MM-dd HH:mm:ss");
            dgvRow.Cells["暂停"].Value = dr["暂停"];
            dgvRow.Cells["出版"].Value = dr["出版"];
            dgvRow.Cells["报废"].Value = dr["报废"];
            dgvRow.Cells["工单号"].Value = dr["工单号"];
            dgvRow.Cells["稿袋号"].Value = dr["稿袋号"];
            dgvRow.Cells["机台"].Value = dr["机台"];
            dgvRow.Cells["客户名"].Value = dr["客户名"];
            dgvRow.Cells["文件名"].Value = dr["文件名"];
            dgvRow.Cells["制造尺寸"].Value = dr["制造尺寸"];
            dgvRow.Cells["下料尺寸"].Value = dr["下料尺寸"];
            dgvRow.Cells["咬口印能捷"].Value = dr["咬口印能捷"];
            dgvRow.Cells["颜色"].Value = dr["颜色"];
            dgvRow.Cells["下料尺寸"].Value = dr["下料尺寸"];
            dgvRow.Cells["印版数量"].Value = dr["印版数量"];
            dgvRow.Cells["印版类型"].Value = dr["印版类型"];
            dgvRow.Cells["备注"].Value = dr["备注"];
            dgvRow.Cells["关联的文件"].Value = dr["关联的文件"];
            //行的颜色
            DataGridViewRowColor(dgvRow);
            return true;
            //}
            //else
            //{
            //    return false;
            //}
        }



        /// <summary>


        /// <summary>
        /// 更新表格的重要函数需要显示在DataGridView中的表格数据
        /// </summary>
        /// <param name="dt">需要显示的数据</param>
        /// <param name="isClearDgvIfNull">Ture表示如果数据为空，则DataGridView也显示为空</param>
        private bool DataTableTodgv(DataTable dt, bool isClearDgvIfNull)
        {
            bool returnBool = false;
            if (dt.Rows.Count <= 0)
            {
                if (isClearDgvIfNull)
                {
                    this.dgv.Rows.Clear();
                }
                return false;
            }
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            {//***更新数据                
                //**将DataGridView中的ID读取到列表中,通过ID判断来提高效率
                Dictionary<string, DataGridViewRow> idDic_gridview = new Dictionary<string, DataGridViewRow>();
                foreach (DataGridViewRow row in this.dgv.Rows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }
                    string key = row.Cells["ID"].Value.ToString();
                    idDic_gridview.Add(key, row);
                }
                //****开始
                foreach (string id in idDic_gridview.Keys)
                {
                    DataRow[] rows = dt.Select("ID=" + id);
                    //1.DataGridView中存在,数据库中不存在(结果是删除DataGridView中的数据)
                    //由于是遍历DataGridView,所以只需判断数据库中有没有存在即可
                    if (rows.Length <= 0)
                    {
                        this.dgv.Rows.Remove(idDic_gridview[id]);
                    }
                    //2.如果DataGridView中存在,并且数据库中也存在
                    //(结果是更新DataGridView中的数据) 如果数据库的最后修改时间较晚,则更新
                    else if (rows.Length > 0)
                    {
                        DataGridViewRow dgvRow = idDic_gridview[id];
                        Update_RowToDgv(rows[0], dgvRow);
                        dt.Rows.Remove(rows[0]);
                    }
                    //3.DataGridView中不存在,并且数据库中存在(结果是添加到DataGridView中)
                    //此操作在循环外进行,

                    //4.DataGridView中不存在,并且数据库中也不存在(无需任何操作)
                }
                //执行第三步操作
                //DataGridView中不存在,并且数据库中存在(结果是添加到DataGridView中)
                foreach (DataRow row in dt.Rows)
                {
                    Add_RowToDgv(row);
                }
            }//更新数据结束


            //排序
            //switch (this.dgv.SortOrder)
            //{
            //    case SortOrder.Ascending:
            //        this.dgv.Sort(this.dgv.SortedColumn, ListSortDirection.Ascending);
            //        break;
            //    case SortOrder.Descending:
            //        this.dgv.Sort(this.dgv.SortedColumn, ListSortDirection.Descending);
            //        break;
            //    case SortOrder.None:
            //    default:
            //        break;
            //}
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //暂停.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //出版.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //报废.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            returnBool = true;
            return returnBool;
        }


        private void dgv_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

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
                string fileFullName = item.Tag.ToString();
                if (Comm_Method.IsConnectPath(fileFullName))
                {
                    files[i++] = fileFullName;
                }
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

        private void tsmiDingwei_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFile.SelectedItems)
            {
                string fileFullName = item.Tag.ToString();
                if (Comm_Method.IsConnectPath(fileFullName))
                {
                    OpenFolderAndSelectFile(fileFullName);
                }
                break;
            }
        }

        public static void OpenFolderAndSelectFile(String fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/n,/select," + fileFullName;
            System.Diagnostics.Process.Start(psi);
        }

        private void tsmiCmm_Click(object sender, EventArgs e)
        {
            //稿袋号-客户名-文件名-制造尺寸

        }

        private void listViewFile_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {

        }

        private void tsmiCopyJob_Click(object sender, EventArgs e)
        {
            List<string> idList = new List<string>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                string id = cell.OwningRow.Cells["ID"].Value.ToString();
                if (!idList.Contains(id))
                {
                    idList.Add(id);
                }
            }

            if (idList.Count > 0)
            {
                jobInfo = new FormJobInformation(true,idList, true, null);
                jobInfo.MdiParent = this.MdiParent;
                jobInfo.WindowState = FormWindowState.Maximized;
                jobInfo.Show();
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            Open();
        }


        private void tsmiSubmitToPrinergyEvo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定直接提交到出版吗？", "确定提交？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }
                string id = "0";
                DataGridViewRow dgvRow = new DataGridViewRow();
                foreach (DataGridViewCell cell in dgv.SelectedCells)
                {
                    string outPath = "";
                    string JDFMarksFlatsPdf = @"\\EvoServer\baiiji\JDFMarksFlatsPdf.pdf";
                    dgvRow = cell.OwningRow;
                    id = Comm_Method.GetCellDefault(cell.OwningRow.Cells["ID"]);
                    string jitai = Comm_Method.GetCellDefault(cell.OwningRow.Cells["机台"]);
                    string yaokou = Comm_Method.GetCellDefault(cell.OwningRow.Cells["咬口印能捷"]);
                    foreach (ListViewItem item in listViewFile.SelectedItems)
                    {
                        string PdfFileFullName = item.Tag.ToString();
                        Document doc = new Document(PdfFileFullName);
                        foreach (Page pdfPage in doc.Pages)
                        {
                            double PageWidth = 0;
                            double PageHeight = 0;
                            switch (pdfPage.Rotate)
                            {
                                case Rotation.on270:
                                case Rotation.on90:
                                    PageWidth = pdfPage.MediaBox.Height;
                                    PageHeight = pdfPage.MediaBox.Width;
                                    break;
                                default:
                                    PageWidth = pdfPage.MediaBox.Width;
                                    PageHeight = pdfPage.MediaBox.Height;
                                    break;
                            }
                            
                            double SheetWidth = 0;
                            double SheetHeight = 0;

                            DataTable dTable = SQLiteList.YBF.ExecuteDataTable("SELECT [辅料].[名称],[自动出版提交路径],[咬口外角线]FROM [印刷机]join[辅料]on[PS版材]=[辅料].[ID]where [机台]='" + jitai + "'");
                            if (dTable.Rows.Count>0)
                            {
                                string sheetSizeStr = dTable.Rows[0]["名称"].ToString();
                                outPath = dTable.Rows[0]["自动出版提交路径"].ToString();
                                if (Comm_Method.IsConnectPath(outPath))
                                {
                                    MatchCollection matches = Regex.Matches(sheetSizeStr, "\\d+");
                                    if (matches.Count == 2)
                                    {
                                        SheetWidth = Convert.ToInt32(matches[0].Value);
                                        SheetHeight = Convert.ToInt32(matches[1].Value);
                                        SheetWidth = Math.Max(SheetWidth, SheetHeight);
                                        SheetHeight = Math.Min(SheetWidth, SheetHeight);
                                    }
                                    else
                                    {
                                        throw new Exception("版材尺寸错误,提交失败!");
                                    }
                                }
                                else
                                {
                                    throw new Exception("输出路径不存在,提交失败!");
                                }
                            }
                            else
                            {
                                throw new Exception("机台数据为空,提交失败!");
                            }
                           
                            if (string.IsNullOrWhiteSpace(jitai)
                                || string.IsNullOrWhiteSpace(yaokou)
                                || string.IsNullOrWhiteSpace(outPath)
                                || string.IsNullOrWhiteSpace(JDFMarksFlatsPdf)
                                || PageWidth == 0 || PageHeight == 0
                                || SheetWidth == 0 || SheetHeight == 0
                                || !Comm_Method.IsConnectPath(PdfFileFullName)
                                || !Comm_Method.IsConnectPath(outPath)
                                || !Comm_Method.IsConnectPath(JDFMarksFlatsPdf))
                            {
                                throw new Exception("参数错误,提交失败!");

                            }


                            //判断下料尺寸
                            string mianzi = Comm_Method.GetCellDefault(cell.OwningRow.Cells["下料尺寸"]);
                            double biaozhuanYaokou = Convert.ToDouble(dTable.Rows[0]["咬口外角线"].ToString());
                            if (!string.IsNullOrWhiteSpace(mianzi))
                            {
                                Regex regex = new Regex("\\d+");
                                MatchCollection mc = regex.Matches(mianzi);
                                if (mc.Count > 1)
                                {
                                    double mianzhigaodu = Convert.ToDouble(mc[0].Value);
                                    double mianzhikuandu = Convert.ToDouble(mc[1].Value) ;
                                    mianzhigaodu = Math.Min(mianzhigaodu, mianzhikuandu) ;
                                    if (biaozhuanYaokou - 5 - Convert.ToInt16(yaokou) + mianzhigaodu < PageHeight* ConversionConstant.MM_PER_PT
                                        &&MessageBox.Show("下料尺寸偏下，请确认是否继续？\n\n是：继续-提交到出版\n\n取消：取消-直接取消出版"
                                        ,"",MessageBoxButtons.OKCancel,MessageBoxIcon.Error)!=DialogResult.OK)
                                    {
                                        return;
                                    }
                                }
                            }



                            //outPath = "D:\\";                     
                            JobDefinitionFormat.MakeJDF(PdfFileFullName, JDFMarksFlatsPdf, 0,
                                Convert.ToInt16(yaokou)
                                , SheetWidth, SheetHeight
                                , PageWidth * ConversionConstant.MM_PER_PT
                                , PageHeight * ConversionConstant.MM_PER_PT
                                , outPath, pdfPage.Rotate);
                            break;
                        }
                        break;
                    }
                    break;
                }
                List<string> list2 = new List<string>();
                list2.Add("UPDATE[作业]SET[出版]=1 WHERE id=" + id + ";");
                SQLiteList.YBF.ExecuteSqlTran(list2);
                UpdateRow(id);
                
            }
            catch (Exception ex)
            {
                Comm_Method.ShowErrorMessage(ex.Message);
                Log.WriteLog("生成JDF文件时错误:", ex);
            }
        }

        private void tsmiBaofei_Click(object sender, EventArgs e)
        {
            ////删除记录的同时,还要提示需要删除的文件
            //if (dgv.SelectedRows.Count>1)
            //{
            //    Comm_Method.ShowErrorMessage("报废操作只能一次性操作一个记录\n请重新选择");
            //    return;
            //}
            //foreach (DataGridViewRow row in dgv.Rows)
            //{
            //    row.Cells["ID"].Value.ToString();
            //}
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            this.listViewFile.Items.Clear();
          

            List<FileInfo> fileList = new List<FileInfo>();
            object obj = dgv["文件名", e.RowIndex].Value;
            if (obj == null || string.IsNullOrWhiteSpace(obj.ToString()))
            {
                return;
            }
            string fileName = dgv["文件名", e.RowIndex].Value.ToString();
            obj = dgv["稿袋号", e.RowIndex].Value;
            string gaodaihao = "";
            if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
            {
                gaodaihao = obj.ToString();
            }
            obj = dgv["关联的文件", e.RowIndex].Value;

            List<string> guanlian = new List<string>();
            if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
            {
                guanlian.AddRange(obj.ToString().Split('*'));
            }
            if (pdfFiles != null && pdfFiles.Length > 0)
            {
                foreach (FileInfo file in pdfFiles)
                {
                    if (guanlian.Contains(Path.GetFileNameWithoutExtension(file.FullName)) ||
                        file.Name.IndexOf(fileName, StringComparison.OrdinalIgnoreCase) > -1
                        && file.Name.IndexOf(gaodaihao, StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        fileList.Add(file);
                    }
                }
                if (fileList.Count > 0)
                {
                    foreach (FileInfo file in fileList)
                    {
                        ListViewItem lvi = new ListViewItem
                        (
                         new string[]{
                                file.Name,
                               file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"),
                               Math.Round(file.Length/1024.0/1024.0,2).ToString()+" MB",
                               file.DirectoryName
                           }
                         );
                        lvi.Tag = file.FullName;
                        this.listViewFile.Items.Add(lvi);//添加到listview中
                    }
                    this.listViewFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
        }


        private void FormJobAdd_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = ((string[])e.Data.GetData(DataFormats.FileDrop));//拖进来的文件集合
            //if (new FormJobInformation(true, 0, false, fileNames).ShowDialog() == DialogResult.OK)
            //{

            //    InitDgv();
            //}

            if (jobInfo == null || jobInfo.IsDisposed)
            {
                jobInfo = new FormJobInformation(true, new List<string> { "0"}, false, fileNames);
            }
            else
            {
                jobInfo.FileNameToRow(fileNames);
            }
            jobInfo.MdiParent = this.MdiParent;
            jobInfo.WindowState = FormWindowState.Maximized;
            jobInfo.Show();
        }

        private void FormJobAdd_DragEnter(object sender, DragEventArgs e)
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

        private void tsmiChazhao_Click(object sender, EventArgs e)
        {
            tsmiToday_Click(this.tsmiCustom, new EventArgs());
        }

        private void 复制文件名规范ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                DataGridViewRow row = cell.OwningRow;
                Clipboard.SetText((Comm_Method.GetCellDefault(row.Cells["稿袋号"]) + "-" + Comm_Method.GetCellDefault(row.Cells["文件名"])).Trim('-'));
                break;
            }
        }


    }
}