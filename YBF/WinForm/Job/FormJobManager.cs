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
        FormSearch search = new FormSearch();//��������
        private string SelectSql = "*";
        private string FromSql = "[��ҵ��չ] ";
        private string WhereTime = "";
        private string WhereField = "";
        private string OrderBy = "[ʱ��] DESC";
        private int Limit = 500;
        private int Offset = 0;
        private FileInfo[] pdfFiles;//����PDF
        public FormJobManager()
        {
            InitializeComponent();
        }

        private void FormJobManager_Load(object sender, EventArgs e)
        {
            //�رն���Ĵ���
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
            string pdfPath = @"\\EvoServer\JobData\PDF\���µ�PDF";
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
            dgv.Sort(ʱ��, ListSortDirection.Descending);
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
            if (dgv.SelectedRows.Count > 1)//�����޸ģ�ͳ��id
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
            else//�����޸ģ����һ��ID���˳�ѭ��
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

            //��ʼ�޸�           
            if (idList.Count == 1)//�����޸�
            {
                jobInfo = new FormJobInformation(false, idList, false, null);

            }

            else if (idList.Count > 0)//�����޸�
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
            if (dgv.SelectedRows.Count > 0 && MessageBox.Show("ȷ��Ҫɾ��ѡ��ļ�¼��", "ɾ����", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> list = new List<string>();
                List<DataGridViewRow> rowList = new List<DataGridViewRow>();
                foreach (DataGridViewRow selectedRow in dgv.SelectedRows)
                {
                    string str = selectedRow.Cells["ID"].Value.ToString();
                    object obj = SQLiteList.YBF.ExecuteScalar("select count(*) from [��ҵ] where id=" + str);
                    if (obj == null || Convert.ToInt32(obj) < 1)
                    {
                        Comm_Method.ShowErrorMessage("IDΪ��" + str + " �����ݲ����ڣ�");
                    }
                    else
                    {
                        list.Add("DELETE FROM [��ҵ]WHERE ID=" + str + ";");
                        rowList.Add(selectedRow);
                    }
                }
                if (SQLiteList.YBF.ExecuteSqlTran(list))
                {
                    foreach (DataGridViewRow row in rowList)
                    {
                        dgv.Rows.Remove(row);
                    }
                    MessageBox.Show("ɾ���ɹ���");

                }
                else
                {
                    Comm_Method.ShowErrorMessage("ɾ��ʧ�ܣ�");
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
                    SQLiteList.YBF.ExecuteNonQuery(string.Format("UPDATE [��ҵ]SET[�������ļ�] ='{0}'\tWHERE ID={1}", stringBuilder.ToString(), id));
                    Update_RowToDgv(SQLiteList.YBF.ExecuteDataTable("select * from [��ҵ��չ] where id=" + id).Rows[0], cell.OwningRow);
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

            OrderBy = "[ʱ��]DESC ";
            WhereField = "";
            bool shuaxin = true;
            switch (toolStripMenuItem.Text)
            {
                case "���500��":
                    WhereTime = "";
                    break;
                case "������ҵ":
                    WhereTime = "[ʱ��]BETWEEN datetime(date('now','localtime')) AND datetime('now','localtime')";
                    break;
                case "7������ҵ":
                    WhereTime = "[ʱ��]BETWEEN datetime('now','localtime','-7 day') AND datetime('now','localtime')";
                    break;
                case "30������ҵ":
                    WhereTime = "[ʱ��]BETWEEN datetime('now','localtime','-30 day') AND datetime('now','localtime')";
                    break;
                case "1������ҵ":
                    WhereTime = "[ʱ��]BETWEEN datetime('now','localtime','-365 day') AND datetime('now','localtime')";
                    break;
                case "�Զ���":
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
            if (Convert.ToBoolean(row.Cells["��ͣ"].Value))
            {
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                row.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
                row.DefaultCellStyle.Font = new Font("����", 9, FontStyle.Italic);
                row.ErrorText = "��ͣ";
            }
            else if (Convert.ToBoolean(row.Cells["����"].Value))
            {
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.OrangeRed;
                row.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.OrangeRed;
                row.DefaultCellStyle.Font = new Font("����", 9, FontStyle.Italic);
                row.ErrorText = "����";
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
                    sqlList.Add("UPDATE[��ҵ]SET[����]=([����]+1)%2 WHERE id=" + id + ";");
                }
                if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
                {
                    UpdateRow(idList);
                }
                else
                {
                    Comm_Method.ShowErrorMessage("���[����]ʧ�ܣ�");
                }
            }
        }

        private void tmsiAbolish_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0 && MessageBox.Show("ȷ��Ҫ��ѡ��ļ�¼���Ϊ[��ͣ]��", "��ͣ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    sqlList.Add("UPDATE[��ҵ]SET[��ͣ]= ([��ͣ]+1)%2 WHERE id=" + id + ";");
                }
                if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
                {
                    UpdateRow(idList);
                }
                else
                {
                    Comm_Method.ShowErrorMessage("���[��ͣ]ʧ�ܣ�");
                }
            }
        }

        private void tsmiShuaxin_Click(object sender, EventArgs e)
        {
            InitDgv();
        }


        //�����ҵ��DataGridView
        private bool Add_RowToDgv(DataRow dr)
        {
            return Update_RowToDgv(dr, null);
            //DataGridViewRow dgvRow = this.dgv.Rows[this.dgv.Rows.Add()];
            //dgvRow.Cells["ID"].Value = dr["ID"];
            //dgvRow.Cells["ʱ��"].Value = Convert.ToDateTime(dr["ʱ��"]).ToString("yyyy-MM-dd HH:mm:ss");
            //dgvRow.Cells["��ͣ"].Value = dr["��ͣ"];
            //dgvRow.Cells["����"].Value = dr["����"];
            //dgvRow.Cells["����"].Value = dr["����"];
            //dgvRow.Cells["������"].Value = dr["������"];
            //dgvRow.Cells["�����"].Value = dr["�����"];
            //dgvRow.Cells["��̨"].Value = dr["��̨"];
            //dgvRow.Cells["�ͻ���"].Value = dr["�ͻ���"];
            //dgvRow.Cells["�ļ���"].Value = dr["�ļ���"];
            //dgvRow.Cells["����ߴ�"].Value = dr["����ߴ�"];
            //dgvRow.Cells["���ϳߴ�"].Value = dr["���ϳߴ�"];
            //dgvRow.Cells["ҧ��ӡ�ܽ�"].Value = dr["ҧ��ӡ�ܽ�"];
            //dgvRow.Cells["��ɫ"].Value = dr["��ɫ"];
            //dgvRow.Cells["���ϳߴ�"].Value = dr["���ϳߴ�"];
            //dgvRow.Cells["ӡ������"].Value = dr["ӡ������"];
            //dgvRow.Cells["ӡ������"].Value = dr["ӡ������"];
            //dgvRow.Cells["��ע"].Value = dr["��ע"];
            //dgvRow.Cells["�������ļ�"].Value = dr["�������ļ�"];
            ////�е���ɫ
            //DataGridViewRowColor(dgvRow);
            //return true;
        }



        ////�޸���ҵ��,�����������޸ĳɹ��˵Ļ�,�Ǿ͸������Ӧ��DataGridView��.
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
        //        //�е���ɫ
        //        DataGridViewRowColor(row);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        /// <summary>
        /// �޸���ҵ��,�����������޸ĳɹ��˵Ļ�,�Ǿ͸������Ӧ��DataGridView��.
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
            dgvRow.Cells["ʱ��"].Value = Convert.ToDateTime(dr["ʱ��"]).ToString("yyyy-MM-dd HH:mm:ss");
            dgvRow.Cells["��ͣ"].Value = dr["��ͣ"];
            dgvRow.Cells["����"].Value = dr["����"];
            dgvRow.Cells["����"].Value = dr["����"];
            dgvRow.Cells["������"].Value = dr["������"];
            dgvRow.Cells["�����"].Value = dr["�����"];
            dgvRow.Cells["��̨"].Value = dr["��̨"];
            dgvRow.Cells["�ͻ���"].Value = dr["�ͻ���"];
            dgvRow.Cells["�ļ���"].Value = dr["�ļ���"];
            dgvRow.Cells["����ߴ�"].Value = dr["����ߴ�"];
            dgvRow.Cells["���ϳߴ�"].Value = dr["���ϳߴ�"];
            dgvRow.Cells["ҧ��ӡ�ܽ�"].Value = dr["ҧ��ӡ�ܽ�"];
            dgvRow.Cells["��ɫ"].Value = dr["��ɫ"];
            dgvRow.Cells["���ϳߴ�"].Value = dr["���ϳߴ�"];
            dgvRow.Cells["ӡ������"].Value = dr["ӡ������"];
            dgvRow.Cells["ӡ������"].Value = dr["ӡ������"];
            dgvRow.Cells["��ע"].Value = dr["��ע"];
            dgvRow.Cells["�������ļ�"].Value = dr["�������ļ�"];
            //�е���ɫ
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
        /// ���±�����Ҫ������Ҫ��ʾ��DataGridView�еı������
        /// </summary>
        /// <param name="dt">��Ҫ��ʾ������</param>
        /// <param name="isClearDgvIfNull">Ture��ʾ�������Ϊ�գ���DataGridViewҲ��ʾΪ��</param>
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
            {//***��������                
                //**��DataGridView�е�ID��ȡ���б���,ͨ��ID�ж������Ч��
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
                //****��ʼ
                foreach (string id in idDic_gridview.Keys)
                {
                    DataRow[] rows = dt.Select("ID=" + id);
                    //1.DataGridView�д���,���ݿ��в�����(�����ɾ��DataGridView�е�����)
                    //�����Ǳ���DataGridView,����ֻ���ж����ݿ�����û�д��ڼ���
                    if (rows.Length <= 0)
                    {
                        this.dgv.Rows.Remove(idDic_gridview[id]);
                    }
                    //2.���DataGridView�д���,�������ݿ���Ҳ����
                    //(����Ǹ���DataGridView�е�����) ������ݿ������޸�ʱ�����,�����
                    else if (rows.Length > 0)
                    {
                        DataGridViewRow dgvRow = idDic_gridview[id];
                        Update_RowToDgv(rows[0], dgvRow);
                        dt.Rows.Remove(rows[0]);
                    }
                    //3.DataGridView�в�����,�������ݿ��д���(�������ӵ�DataGridView��)
                    //�˲�����ѭ�������,

                    //4.DataGridView�в�����,�������ݿ���Ҳ������(�����κβ���)
                }
                //ִ�е���������
                //DataGridView�в�����,�������ݿ��д���(�������ӵ�DataGridView��)
                foreach (DataRow row in dt.Rows)
                {
                    Add_RowToDgv(row);
                }
            }//�������ݽ���


            //����
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
            //��ͣ.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //����.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //����.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
        /// ���ļ��л��ļ�
        /// </summary>
        private void Open()
        {

            foreach (ListViewItem item in listViewFile.SelectedItems)
            {
                string newPath = item.Tag.ToString();
                //�ж���Ŀ¼�����ļ�
                if (File.Exists(newPath))
                    Process.Start(newPath); //���ļ�
            }

            //if (listViewFile.SelectedItems.Count > 0)
            //{
            //    string newPath = listViewFile.SelectedItems[0].Tag.ToString();
            //    //�ж���Ŀ¼�����ļ�
            //    if (File.Exists(newPath))
            //        Process.Start(newPath); //���ļ�
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
            //�����-�ͻ���-�ļ���-����ߴ�

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
                if (MessageBox.Show("ȷ��ֱ���ύ��������", "ȷ���ύ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
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
                    string jitai = Comm_Method.GetCellDefault(cell.OwningRow.Cells["��̨"]);
                    string yaokou = Comm_Method.GetCellDefault(cell.OwningRow.Cells["ҧ��ӡ�ܽ�"]);
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

                            DataTable dTable = SQLiteList.YBF.ExecuteDataTable("SELECT [����].[����],[�Զ������ύ·��],[ҧ�������]FROM [ӡˢ��]join[����]on[PS���]=[����].[ID]where [��̨]='" + jitai + "'");
                            if (dTable.Rows.Count>0)
                            {
                                string sheetSizeStr = dTable.Rows[0]["����"].ToString();
                                outPath = dTable.Rows[0]["�Զ������ύ·��"].ToString();
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
                                        throw new Exception("��ĳߴ����,�ύʧ��!");
                                    }
                                }
                                else
                                {
                                    throw new Exception("���·��������,�ύʧ��!");
                                }
                            }
                            else
                            {
                                throw new Exception("��̨����Ϊ��,�ύʧ��!");
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
                                throw new Exception("��������,�ύʧ��!");

                            }


                            //�ж����ϳߴ�
                            string mianzi = Comm_Method.GetCellDefault(cell.OwningRow.Cells["���ϳߴ�"]);
                            double biaozhuanYaokou = Convert.ToDouble(dTable.Rows[0]["ҧ�������"].ToString());
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
                                        &&MessageBox.Show("���ϳߴ�ƫ�£���ȷ���Ƿ������\n\n�ǣ�����-�ύ������\n\nȡ����ȡ��-ֱ��ȡ������"
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
                list2.Add("UPDATE[��ҵ]SET[����]=1 WHERE id=" + id + ";");
                SQLiteList.YBF.ExecuteSqlTran(list2);
                UpdateRow(id);
                
            }
            catch (Exception ex)
            {
                Comm_Method.ShowErrorMessage(ex.Message);
                Log.WriteLog("����JDF�ļ�ʱ����:", ex);
            }
        }

        private void tsmiBaofei_Click(object sender, EventArgs e)
        {
            ////ɾ����¼��ͬʱ,��Ҫ��ʾ��Ҫɾ�����ļ�
            //if (dgv.SelectedRows.Count>1)
            //{
            //    Comm_Method.ShowErrorMessage("���ϲ���ֻ��һ���Բ���һ����¼\n������ѡ��");
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
            object obj = dgv["�ļ���", e.RowIndex].Value;
            if (obj == null || string.IsNullOrWhiteSpace(obj.ToString()))
            {
                return;
            }
            string fileName = dgv["�ļ���", e.RowIndex].Value.ToString();
            obj = dgv["�����", e.RowIndex].Value;
            string gaodaihao = "";
            if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
            {
                gaodaihao = obj.ToString();
            }
            obj = dgv["�������ļ�", e.RowIndex].Value;

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
                        this.listViewFile.Items.Add(lvi);//��ӵ�listview��
                    }
                    this.listViewFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
        }


        private void FormJobAdd_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = ((string[])e.Data.GetData(DataFormats.FileDrop));//�Ͻ������ļ�����
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

        private void �����ļ����淶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                DataGridViewRow row = cell.OwningRow;
                Clipboard.SetText((Comm_Method.GetCellDefault(row.Cells["�����"]) + "-" + Comm_Method.GetCellDefault(row.Cells["�ļ���"])).Trim('-'));
                break;
            }
        }


    }
}