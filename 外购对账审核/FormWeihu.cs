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


namespace 纸箱纸板性能分析.WinForm
{
    public partial class FormWeihu : Form
    {
        public string selectText = "";

        private string Da_Sql = "";

        private bool IsReadOnly = false;
        private SQLiteDataAdapter Da;
        private DataSet Ds;
        private DataTable Dt;


        public FormWeihu(string da_sql,string title,bool isReadOnly=false)
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
            dgv.ReadOnly = IsReadOnly;
            dgv.AllowUserToAddRows = !IsReadOnly;
            SQLiteConnection myConn = new SQLiteConnection(SQLiteDbHelper.ConnectionString);
            Da = new SQLiteDataAdapter(Da_Sql, myConn);
            Ds = new DataSet();
            Da.Fill(Ds);
            myConn.Close();
            this.dgv.DataSource = Ds.Tables[0];
            Dt = Ds.Tables[0];
            //if (dgv.Columns.Contains("ID"))
            //{
            //    dgv.Columns["ID"].ReadOnly = true;
            //}
            dgv.AutoResizeColumns();
        }
        /// <summary>
        /// 保存
        /// </summary>
        private void Save()
        {
            try
            {
                ////剔除空行并将正在编辑的行标记为已完成
                //if (this.dgv.CurrentCell != null && this.dgv.CurrentCell.IsInEditMode)
                //{
                //    this.dgv.CurrentCell.Value = this.dgv.CurrentCell.EditedFormattedValue;
                //}

                SQLiteCommandBuilder ocb = new SQLiteCommandBuilder(Da);
                if (Da.Update(Ds) > 0) InitDgv();

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
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
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
            else if (keyData==(Keys.Control|Keys.S))
            {
                Save();
            }
            return false;

        }

        private void 导出ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".xls";
            save.FileName = this.Text+"_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            save.Filter = "Excel(.xls)|*.xls";
            if (save.ShowDialog()==DialogResult.OK)
            {
                My.ExceptToExcel(save.FileName, Dt);
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDgv();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Text.Contains("选择"))
            {
                selectText = My.GetCellDefault(dgv["ID", e.RowIndex]);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
