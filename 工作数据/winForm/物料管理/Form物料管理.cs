using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using 综合保障中心.Comm;

namespace 工作数据.winForm
{
    public partial class Form物料管理 : Form
    {
        int showRowIndex = 0;
        int showColumnIndex = 0;
        private MySqlDataAdapter Da;
        private DataSet Ds;
        private DataTable Dt;



        public Form物料管理()
        {
            InitializeComponent();
        }

        private void Form物料管理_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
            InitDgv();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitDgv()
        {
            MySqlConnection myConn = new MySqlConnection(MySqlDbHelper.GetConnectionString());
            Da = new MySqlDataAdapter("SELECT * FROM  `slbz`.`物料_管理`", myConn);
            Ds = new DataSet();
            Da.Fill(Ds);
            myConn.Close();
            this.dgv.DataSource = Ds.Tables[0];
            Dt = Ds.Tables[0];
            dgv.FirstDisplayedScrollingRowIndex = showRowIndex;
            dgv[showColumnIndex, showRowIndex].Selected = true;
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

                MySqlCommandBuilder ocb = new MySqlCommandBuilder(Da);
                Da.Update(Ds);
                showRowIndex = dgv.SelectedCells[0].RowIndex;
                showColumnIndex = dgv.SelectedCells[0].ColumnIndex;
                InitDgv();
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
            }
        }

        private void 保存CtrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgv.CommitEdit((DataGridViewDataErrorContexts)123);
            dgv.BindingContext[dgv.DataSource].EndCurrentEdit();
            Save();
        }

        //true表示无效.false表示有效.
        //此函数为全局更改(慎用!!!)
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {
            
            if (keyData == Keys.F5)//刷新
            {
                InitDgv();
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                Save();
            }
            else if (keyData == (Keys.Control | Keys.F4))
            {
                this.Dispose();
            }
            return false;

        }

        private void 退出CtrlF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        //private void 导出ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog save = new SaveFileDialog();
        //    save.DefaultExt = ".xls";
        //    save.FileName = this.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
        //    save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    save.Filter = "Excel(.xls)|*.xls";
        //    if (save.ShowDialog() == DialogResult.OK)
        //    {
        //        My.ExceptToExcel(save.FileName, Dt);
        //    }
        //}
    }
}
