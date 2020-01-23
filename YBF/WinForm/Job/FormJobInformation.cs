using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;
using YBF.Class.Comm;
using System.IO;
using System.Text.RegularExpressions;
using HanDe_ClassLibrary.PrepressFile.Adobe.Acrobat;
using HanDe_ClassLibrary.Common.SizeBox;
using excelToTable_NPOI;

namespace YBF.WinForm.Job
{
    public partial class FormJobInformation : Form
    {
        private List<string> idList = new List<string>();
        private List<SujiInfo> kehuList = new List<SujiInfo>();
        private List<SujiInfo> yanseList = new List<SujiInfo>();
        Dictionary<string, string> jitaiDic = new Dictionary<string, string>();
        private bool IsCopyAndAddJob = false;
        private bool IsAddNewJob = false;
        public FormJobInformation()
        {
            InitializeComponent();
            IsAddNewJob = true;

        }
        public FormJobInformation(bool isAddNewJob, List<string> idList, bool isCopyAndAddJob, string[] AddFiles)
        {
            IsAddNewJob = isAddNewJob;
            this.idList = idList;
            IsCopyAndAddJob = isCopyAndAddJob;
            InitializeComponent();
            if (AddFiles != null && AddFiles.Length > 0)
            {
                FileNameToRow(AddFiles);
            }
        }


        public FormJobInformation(bool isAddNewJob, List<string> idList)
        {
            IsAddNewJob = isAddNewJob;
            this.idList = idList;
            InitializeComponent();
        }


        private void FormJobInformation_Load(object sender, EventArgs e)
        {

            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }


            this.dgv.AllowUserToAddRows = IsAddNewJob;
            this.dgv.AllowUserToDeleteRows = IsAddNewJob;
            this.tsmiClear.Enabled = IsAddNewJob;
            this.tsmiImport.Visible = IsAddNewJob;
            this.dgv.ContextMenuStrip = (IsAddNewJob ? contextMenuStrip1 : null);
            this.listViewSelect.Visible = false;
            if (idList.Count > 0)
            {
                StringBuilder sb_id = new StringBuilder();
                foreach (string id in idList)
                {
                    sb_id.Append(id + ",");
                }
                sb_id.Append(0);
                foreach (DataRow row in
                SQLiteList.YBF.ExecuteDataTable("select*FROM[作业扩展] WHERE [ID] in (" + sb_id.ToString() + ");").Rows)
                {
                    DataGridViewRow dgvRow = dgv.Rows[dgv.Rows.Add()];
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        dgvRow.Cells[column.HeaderText].Value = row[column.HeaderText];
                    }                    
                }
            }

            //***速记***
            //客户
            foreach (DataRow row in SQLiteList.YBF.ExecuteDataTable("select[客户名]from[作业]group by [客户名]").Rows)
            {
                kehuList.Add(new SujiInfo(row[0].ToString()));
            }
            //颜色
            foreach (DataRow row in SQLiteList.YBF.ExecuteDataTable("select[颜色]from[作业]group by [颜色]").Rows)
            {
                yanseList.Add(new SujiInfo(row[0].ToString()));
            }
            //机台
            foreach (DataRow row in SQLiteList.YBF.ExecuteDataTable("select[ID],[机台]from[印刷机]").Rows)
            {
                jitaiDic.Add(row["机台"].ToString(), row["ID"].ToString());
            }
            if (IsCopyAndAddJob)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Cells["时间"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    row.Cells["暂停"].Value = false;
                    row.Cells["出版"].Value = false;
                    row.Cells["报废"].Value = false;
                    row.Cells["印版类型"].Value = "旧版";
                }
                
            }
            this.WindowState = FormWindowState.Maximized;
        }


        private void tsmiSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            this.dgv.EndEdit();
            List<string> sqlList = new List<string>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                if (string.IsNullOrWhiteSpace(Comm_Method.GetCellDefault(row.Cells["机台"])))
                {
                    Comm_Method.ShowErrorMessage("机台不能为空！");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (!jitaiDic.ContainsKey(Comm_Method.GetCellDefault(row.Cells["机台"])))
                {
                    Comm_Method.ShowErrorMessage("机台选择不正确！");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                string timeValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                object value = dgv["时间", row.Index].Value;
                if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                {
                    timeValue = Convert.ToDateTime(row.Cells["时间"].Value).ToString("yyyy-MM-dd HH:mm:ss");
                }

                if (IsAddNewJob)//添加
                {
                    sqlList.Add("INSERT INTO [作业]([时间],[暂停],[出版],[报废],[工单号],[稿袋号],[机台ID],[客户名],[文件名],[制造尺寸],[下料尺寸],[咬口印能捷],[颜色],[印版数量],[印版类型],[备注],[关联的文件])VALUES("
                    + "datetime('" + timeValue + "'),"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["暂停"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["出版"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["报废"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["工单号"]).ToUpper() + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["稿袋号"]).ToUpper() + "',"
                    + "'" + jitaiDic[Comm_Method.GetCellDefault(row.Cells["机台"])] + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["客户名"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["文件名"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["制造尺寸"]).ToLower() + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["下料尺寸"]).ToLower() + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["咬口印能捷"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["颜色"]).ToUpper() + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["印版数量"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["印版类型"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["备注"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["关联的文件"]) + "'"
                    + ");");
                }

                else//修改
                {
                    sqlList.Add("UPDATE [作业]SET"
                    + "[时间] =datetime('" + timeValue + "'),"
                    + "[暂停] ='" + Comm_Method.GetCellDefault(row.Cells["暂停"]) + "',"
                    + "[出版] ='" + Comm_Method.GetCellDefault(row.Cells["出版"]) + "',"
                    + "[报废] ='" + Comm_Method.GetCellDefault(row.Cells["报废"]) + "',"
                    + "[工单号] ='" + Comm_Method.GetCellDefault(row.Cells["工单号"]).ToUpper() + "',"
                    + "[稿袋号] ='" + Comm_Method.GetCellDefault(row.Cells["稿袋号"]).ToUpper() + "',"
                    + "[机台ID] ='" + jitaiDic[Comm_Method.GetCellDefault(row.Cells["机台"])] + "',"
                    + "[客户名] ='" + Comm_Method.GetCellDefault(row.Cells["客户名"]) + "',"
                    + "[文件名] ='" + Comm_Method.GetCellDefault(row.Cells["文件名"]) + "',"
                    + "[制造尺寸] ='" + Comm_Method.GetCellDefault(row.Cells["制造尺寸"]).ToLower() + "',"
                    + "[下料尺寸] ='" + Comm_Method.GetCellDefault(row.Cells["下料尺寸"]).ToLower() + "',"
                    + "[咬口印能捷] ='" + Comm_Method.GetCellDefault(row.Cells["咬口印能捷"]) + "',"
                    + "[颜色] ='" + Comm_Method.GetCellDefault(row.Cells["颜色"]).ToUpper() + "',"
                    + "[印版数量] ='" + Comm_Method.GetCellDefault(row.Cells["印版数量"]) + "',"
                    + "[印版类型] ='" + Comm_Method.GetCellDefault(row.Cells["印版类型"]) + "',"
                    + "[备注] ='" + Comm_Method.GetCellDefault(row.Cells["备注"]) + "',"
                    + "[关联的文件] ='" + Comm_Method.GetCellDefault(row.Cells["关联的文件"]) + "'"
                    + " WHERE ID=" + Comm_Method.GetCellDefault(row.Cells["ID"]) + ";");
                }

            }
            if (sqlList.Count > 0)
            {
                if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
                {
                    ShowJobManager();
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    Comm_Method.ShowErrorMessage("保存失败！");
                }
            }
            else
            {
                this.Dispose();
            }
        }

        private void ShowJobManager()
        {
            FormJobManager jobManager = null;

            foreach (Form item in this.MdiParent.MdiChildren)
            {
                if (item is FormJobManager)
                {
                    jobManager = (item as FormJobManager);
                }
            }

            if (jobManager == null)
            {
                jobManager = new FormJobManager();
            }

            if (IsAddNewJob)
            {
                jobManager.InitDgv();
            }
            else
            {
                jobManager.UpdateRow(idList);
            }

            jobManager.WindowState = FormWindowState.Maximized;
            jobManager.MdiParent = this.MdiParent;
            jobManager.Show();
            this.Dispose();
            return;
        }




        private void tsmiSaveQuit_Click(object sender, EventArgs e)
        {
            Save();
        }


        //true表示无效.false表示有效.
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {
            //拷贝的快捷键(ctrl+c)
            //if (keyData.GetHashCode() == 131139)
            //{
            //    PastingCells(Clipboard.GetText());
            //}

            //粘帖的快捷键(ctrl+v)
            //if (keyData.GetHashCode() == 131158)
            //{
            //    this.listViewSelect.Hide();
            //}

            ////按删除键时
            //if (keyData == Keys.Delete) //删除行
            //{
            //    int deletedNum = 0;
            //    foreach (DataGridViewRow row in this.dgvAddJob.SelectedRows)
            //    {
            //        if (!row.IsNewRow)
            //        {
            //            this.dgvAddJob.Rows.Remove(row);
            //            deletedNum++;
            //        }

            //    }
            //    //if (deletedNum>0)
            //    //{
            //    //    //ShowTishi();
            //    //}
            //}

            //保存的快捷键(ctrl+s)
            if (keyData.GetHashCode() == 131155)
            {
                Save();
            }


            ////如果listViewSelect处于焦点,则不会禁止键盘
            //if (this.listViewSelect.Focused)
            //{
            //    return false;
            //}

            //删除行
            if (keyData == Keys.Delete && IsAddNewJob)
            {
                foreach (DataGridViewRow row in this.dgv.SelectedRows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }
                    this.dgv.Rows.Remove(row);
                }
                return true;
            }

            //方向键
            if ((keyData == Keys.Up || keyData == Keys.Down)
                &&
                    (this.dgv.CurrentCell != null
                    && this.listViewSelect.Visible
                    && this.listViewSelect.Items.Count > 0 && this.listViewSelect.FocusedItem == null))
            {
                this.listViewSelect.Focus();
                this.listViewSelect.Select();
                this.listViewSelect.FocusedItem = this.listViewSelect.Items[0];
                this.listViewSelect.FocusedItem.Selected = true;
                return true;
            }


            return false;

        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            if (this.dgv.Rows.Count > 0
               && MessageBox.Show("列表中还有数据没有保存，确定要退出吗？", "退出？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            if (this.dgv.Rows.Count > 0
               && MessageBox.Show("清空后列表中都数据无法还原，确定要清空吗？", "清空？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                {
                    if (dgv.Rows[i].IsNewRow)
                    {
                        continue;
                    }
                    else
                    {
                        dgv.Rows.RemoveAt(i);
                    }
                }

            }
        }

        private void dgv_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[时间.Name].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }



        class SujiInfo
        {
            public string value;
            public string suji1;
            public string suji2;
            public string key;
            public SujiInfo(string v, string s1, string s2, string k)
            {
                value = v;
                suji1 = s1;
                suji2 = s2;
                key = k;
            }
            public SujiInfo()
            {
                value = "";
                suji1 = "";
                suji2 = "";
                key = "";
            }
            public SujiInfo(string v)
            {
                value = v;
                suji1 = PinYinConverter.GetFirst(v);
                suji2 = PinYinConverter.Get(v);
                key = "";
            }
            public SujiInfo(string v, string k)
            {
                value = v;
                suji1 = PinYinConverter.GetFirst(v);
                suji2 = PinYinConverter.Get(v);
                key = k;
            }
            public bool Continas(string str)
            {
                return value.IndexOf(str, StringComparison.OrdinalIgnoreCase) > -1
            || suji1.IndexOf(str, StringComparison.OrdinalIgnoreCase) > -1
                       || suji2.IndexOf(str, StringComparison.OrdinalIgnoreCase) > -1
                       || key.IndexOf(str, StringComparison.OrdinalIgnoreCase) > -1;
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            this.dgv.SelectedCells[0].Value = this.listViewSelect.FocusedItem.Text;
            this.listViewSelect.Hide();
        }

        private void listViewSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            //esc键，隐藏
            if (e.KeyChar == 27)
            {
                this.listViewSelect.Hide();
            }
        }
        TextBox tb = null;
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (this.dgv.CurrentCell == null)
            {
                return;
            }

            tb = e.Control as TextBox;

            if (tb == null)
            {
                return;
            }
            DataGridViewCell cell = this.dgv.CurrentCell;


            this.listViewSelect.Items.Clear();

            string colName = this.dgv.Columns[cell.ColumnIndex].HeaderText;

            switch (colName)
            {
                case "机台":
                case "颜色":
                case "印版类型":
                case "客户名":
                    {
                        tb.TextChanged += new EventHandler(tb_TextChanged);
                    }
                    break;

                default:
                    break;
            }
        }
        void tb_TextChanged(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null || tb == null)
            {
                return;
            }
            DataGridViewCell cell = this.dgv.CurrentCell;


            this.listViewSelect.Items.Clear();

            string colName = this.dgv.Columns[cell.ColumnIndex].HeaderText;

            string str = tb.Text.Trim();

            ////如果是系统的粘帖的话则不用执行这个方法            
            //if (Clipboard.GetText() == str)
            //{
            //    return;
            //}

            if (string.IsNullOrWhiteSpace(str))
            {
                this.listViewSelect.Visible = false;
                return;
            }
            switch (colName)
            {
                case "机台":
                    {
                        foreach (string suji in jitaiDic.Keys)
                        {
                            this.listViewSelect.Items.Add(suji);
                        }
                    }
                    break;
                case "印版类型":
                    {
                        this.listViewSelect.Items.Add("新版");
                        this.listViewSelect.Items.Add("旧版");
                        this.listViewSelect.Items.Add("改版");
                    }
                    break;
                case "颜色":
                    this.listViewSelect.Items.Add("CMYK");
                    this.listViewSelect.Items.Add("CMYK专");
                    this.listViewSelect.Items.Add("K专");
                    this.listViewSelect.Items.Add("K");
                    foreach (SujiInfo suji in yanseList)
                    {
                        if (suji.Continas(str))
                        {
                            this.listViewSelect.Items.Add(suji.value);
                        }
                    }
                    break;
                case "客户名":
                    foreach (SujiInfo suji in kehuList)
                    {
                        if (suji.Continas(str))
                        {
                            this.listViewSelect.Items.Add(suji.value);
                        }
                    }
                    break;
                default:
                    break;
            }
            if (this.listViewSelect.Items.Count > 0)
            {
                listViewSelect.Show();
            }
        }

        private void dgv_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && this.dgv.Rows[e.RowIndex].IsNewRow == false)
            {
                if (tb != null)
                {
                    tb.TextChanged -= new EventHandler(tb_TextChanged);
                }
            }
            dgv.EndEdit();
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            this.listViewSelect.Visible = false;
        }

        private void listViewSelect_VisibleChanged(object sender, EventArgs e)
        {
            if (this.listViewSelect.Visible == true && this.dgv.CurrentCell != null)
            {
                Rectangle rec = this.dgv.GetCellDisplayRectangle(this.dgv.CurrentCell.ColumnIndex, this.dgv.CurrentCell.RowIndex, false);
                int x = rec.X;
                int y = rec.Y + this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Height + 22;
                this.listViewSelect.Location = new Point(x, y);
            }
        }

        private void tsmiImport_Click(object sender, EventArgs e)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Excel文件|*.xls";
            if (open.ShowDialog() == DialogResult.OK)
            {
                DataTable table = Comm_Method.GetPublishDataTableFromExcelFile(open.FileName);
                DateTime time = File.GetLastWriteTime(open.FileName);
                foreach (DataRow row in table.Rows)
                {
                    DataGridViewRow dgvRow = dgv.Rows[dgv.Rows.Add()];


                    dgvRow.Cells["时间"].Value = time;
                    dgvRow.Cells["稿袋号"].Value = row["稿袋号"];
                    if (!string.IsNullOrWhiteSpace(row["上机机台"].ToString()))
                    {
                        string jitai_temp = row["上机机台"].ToString().Replace("（二期）", "");
                        if (jitaiDic.Keys.Contains(jitai_temp))
                        {
                            dgvRow.Cells["机台"].Value = jitai_temp;
                        }
                        else
                        {
                            dgvRow.Cells["机台"].Value = "";
                        }


                    }
                    dgvRow.Cells["客户名"].Value = row["客户简称"];
                    dgvRow.Cells["文件名"].Value = row["产品名称"];
                    dgvRow.Cells["制造尺寸"].Value = row["制造尺寸"];
                    dgvRow.Cells["下料尺寸"].Value = row["面纸尺寸"];
                    dgvRow.Cells["印版数量"].Value = row["晒版数"];
                    dgvRow.Cells["印版类型"].Value = row["备注"];
                }
            }
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgv.SelectedRows.Count < 1 || dgv.SelectedRows[0].IsNewRow)
            {
                e.Cancel = true;
            }
        }

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgv.SelectedRows[0];
            DataGridViewRow newRow = dgv.Rows[dgv.Rows.Add()];
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                newRow.Cells[column.Name].Value = row.Cells[column.Name].Value;
            }
        }

        private void FormJobAdd_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = ((string[])e.Data.GetData(DataFormats.FileDrop));//拖进来的文件集合
            FileNameToRow(fileNames);

        }

        public void FileNameToRow(string[] fileNames)
        {
            foreach (string file in fileNames)
            {
                //string regexTxt = @"\d+(\.\d+)?";//正则表达式的公式
                string fileNameEx = Path.GetFileNameWithoutExtension(file);//文件名
                string gaodaihao = "";
                string zzcc = "";
                double pdfSideLen1 = 0;
                double pdfSideLen2 = 0;
                string jitai = "";

                //稿袋号
                Regex regex = new Regex(@"^([a-z]|[A-Z]|[0-9]){4,5}", RegexOptions.IgnoreCase);
                if (regex.IsMatch(fileNameEx))
                {
                    gaodaihao = regex.Match(fileNameEx).Value;
                    fileNameEx = fileNameEx.Replace(gaodaihao, "").Trim('-');
                }
                //制造尺寸
                regex = new Regex(@"\d+(\.\d+)?x\d+(\.\d+)?x\d+(\.\d+)? *(mm|cm)? *", RegexOptions.IgnoreCase);
                if (regex.IsMatch(fileNameEx))
                {
                    zzcc = regex.Match(fileNameEx).Value;
                    ////如果制造尺寸后面直接跟着‘mm’或‘cm’则也去除
                    //string danwei = fileNameEx.Substring(fileNameEx.IndexOf(zzcc)+zzcc.Length,2);
                    int len = fileNameEx.IndexOf(zzcc);
                    if (len + zzcc.Length == fileNameEx.Length)
                    {
                        fileNameEx = fileNameEx.Replace(zzcc, "").Trim('-');
                    }
                    zzcc = zzcc.Replace(" ", "").Trim("cmCM".ToArray());
                }
                //PDF文件的尺寸
                Acrobat8 a8 = new Acrobat8(new FileInfo(file));
                CREO_TrimBox_MilliMetre trimBox = a8.GetCREO_TrimBox();
                pdfSideLen1 = trimBox.Width.Length;
                pdfSideLen2 = trimBox.High.Length;
                if (Math.Max(pdfSideLen1, pdfSideLen2) > 1030 || Math.Min(pdfSideLen1, pdfSideLen2) > 745)
                {
                    jitai = "高宝145";
                }
                else if (Math.Min(pdfSideLen1, pdfSideLen2) < 710)
                {
                    jitai = "罗兰700";
                }
                //开始填充数据
                DataGridViewRow dgvRow = dgv.Rows[dgv.Rows.Add()];
                dgvRow.Cells["时间"].Value = DateTime.Now;
                dgvRow.Cells["文件名"].Value = fileNameEx.Trim();
                dgvRow.Cells["稿袋号"].Value = gaodaihao;
                dgvRow.Cells["制造尺寸"].Value = zzcc;
                dgvRow.Cells["机台"].Value = jitai;
            }


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

        private void tsmiTimeNow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                row.Cells["时间"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            dgv.EndEdit();
        }

        private void 从易捷导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormYijie yijie = new FormYijie();
            if (yijie.ShowDialog()==DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string item in yijie.idsList)
                {
                    sb.Append(item + ",");
                }
                sb.Append(0);
                yijie.Dispose();
                foreach (DataRow row in SQLiteList.YBF.ExecuteDataTable("select * from[印版确认]where ids in("+sb.ToString()+")").Rows)
                {
                    //开始填充数据
                    DataGridViewRow dgvRow = dgv.Rows[dgv.Rows.Add()];
                    dgvRow.Cells["时间"].Value = DateTime.Now;
                    dgvRow.Cells["工单号"].Value = row["工单号"].ToString();
                    dgvRow.Cells["稿袋号"].Value = row["稿袋号"].ToString();
                    dgvRow.Cells["机台"].Value = row["机台"].ToString(); ;
                    dgvRow.Cells["客户名"].Value = row["客户名"].ToString(); ;
                    dgvRow.Cells["文件名"].Value = row["产品名称"].ToString(); ;
                    dgvRow.Cells["制造尺寸"].Value = row["制造尺寸"].ToString(); ;
                    dgvRow.Cells["下料尺寸"].Value = row["下料尺寸"].ToString(); ;
                    dgvRow.Cells["印版数量"].Value = row["印版数"].ToString(); ;
                    dgvRow.Cells["印版类型"].Value = row["新旧版"].ToString(); ;
                }
            }
        }

      
    }
}
