using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using 综合保障中心.Comm;
using HandeJobManager.DAL;
using excelToTable_NPOI;

namespace 纸箱纸板性能分析.WinForm
{
    public partial class FormWeihu : Form
    {
        public string selectText = "";

        private string Da_Sql = "";

        private bool IsReadOnly = false;



        public FormWeihu(string title, string da_sql, bool isReadOnly = false)
        {
            InitializeComponent();
            Da_Sql = da_sql;
            this.Text = title;
            this.IsReadOnly = isReadOnly;
        }

        private void FormPaper_Load(object sender, EventArgs e)
        {
            ////关闭多余的窗体
            //foreach (Form f in this.ParentForm.MdiChildren)
            //{
            //    if (f.Name == this.Name && f.Handle != this.Handle)
            //    {
            //        f.Dispose();
            //    }
            //}
            InitDgv();

        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitDgv()
        {

            this.dgv.DataSource = SQLiteDbHelper_ZBX.ExecuteDataTable(Da_Sql);

            if (dgv.Columns.Contains("Key"))
            {
                dgv.Columns["Key"].ReadOnly = true;
            }
            dgv.AutoResizeColumns();
        }
        /// <summary>
        /// 保存
        /// </summary>
        private void Save()
        {
            try
            {
                List<string> sqlList = new List<string>();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    sqlList.Add(string.Format("UPDATE [setting]SET [Value] ='{0}' WHERE [key]='{1}'"
                        , row.Cells["Value"].Value.ToString(), row.Cells["Key"].Value.ToString()));
                }
                if (SQLiteDbHelper_ZBX.ExecuteSqlTran(sqlList))
                { InitDgv(); }
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
            }
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgv.CommitEdit((DataGridViewDataErrorContexts)123);
            dgv.BindingContext[dgv.DataSource].EndCurrentEdit();
            Save();
        }

        //true表示无效.false表示有效.
        //此函数为全局更改(慎用!!!)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //this.Text = keyData.GetHashCode().ToString();

            ////打开拼版软件
            //if (keyData.GetHashCode()==262225)
            //{
            //    this.tsmiMakeupJob_Click(this, new EventArgs());
            //}
            if (keyData == Keys.F5)//刷新
            {
                InitDgv();
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                Save();
            }
            return false;

        }

        private void 导出ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".xls";
            save.FileName = this.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            save.Filter = "Excel(.xls)|*.xls";
            if (save.ShowDialog() == DialogResult.OK)
            {
                new ExcelHelper(save.FileName).DataGridViewToExcel(dgv, "sheet1");
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDgv();
        }



        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
