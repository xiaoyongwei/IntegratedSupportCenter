using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 综合保障中心.Comm;
using System.Diagnostics;
using excelToTable_NPOI;

namespace 工作数据分析.WinForm
{
    public partial class FormShowData : Form
    {
        private string SQLString = "";
        private DataGridViewColumn GongdanhaoColumn = null;
        public FormShowData(string title, string sqlString)
        {
            InitializeComponent();
            this.Text = title;
            SQLString = sqlString;
        }
        public FormShowData(string title, DataTable dt)
        {
            InitializeComponent();
            this.Text = title;
            dgv.DataSource = dt;
        }

        private void FormShowData_Load(object sender, EventArgs e)
        {
            this.toolStripComboBox1.Text = toolStripComboBox1.Items[0].ToString();
            ShuaXin();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShuaXin();
        }

        private void ShuaXin()
        {
            dgv.DataSource = MySqlDbHelper.ExecuteDataTable(SQLString);
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.HeaderText.Contains("工单") ||
                    col.HeaderText.Contains("生产单") ||
                    col.HeaderText.Contains("生产单号"))
                {
                    GongdanhaoColumn = col;
                    dgv.ContextMenuStrip = contextMenuStrip1;
                    break;
                }
            }
            dgv.AutoResizeColumns();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void 导出EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".xls";
            save.FileName = this.Text + "_" + DateTime.Now.ToString("yyyyMMdd");
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            save.Filter = "Excel(.xls)|*.xls";
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (this.Text == "排车日报表")
                {
                    if (new ExcelHelper(save.FileName).DataTableToExcel_排车(MySqlDbHelper.ExecuteDataTable(SQLString), DateTime.Now.ToString("yyyy-MM-dd"), true) > 0)
                    {
                        if (MessageBox.Show("保存成功!\n是否直接打开?", "打开?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Process.Start(save.FileName);
                        }
                    }
                    else
                    {
                        My.ShowErrorMessage("导出失败!");
                    }
                }
                else
                {
                    if (My.ExceptToExcel(save.FileName, MySqlDbHelper.ExecuteDataTable(SQLString)))
                    {
                        if (MessageBox.Show("保存成功!\n是否直接打开?", "打开?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Process.Start(save.FileName);
                        }
                    }
                    else
                    {
                        My.ShowErrorMessage("导出失败!");
                    }
                }


            }
        }

        private void 查看此订单工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GongdanhaoColumn != null && dgv.SelectedCells.Count > 0)
            {
                new Form排程查询(dgv[GongdanhaoColumn.Index, dgv.SelectedCells[0].RowIndex].Value.ToString(), "").ShowDialog();
            }
        }


        /// <summary>
        /// 设置整单完工
        /// </summary>
        /// <param name="isWangong">是否设置为完工</param>
        private void SetZhengdanWangong(bool isWangong)
        {
            List<int> rowIndexList = GetSelectedRowIndexs();
            if (rowIndexList.Count > 0)
            {
                List<string> sqlList = new List<string>();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                foreach (int rowindex in rowIndexList)
                {
                    sqlList.Add(
                        string.Format(
                        "UPDATE `slbz`.`订单_生产单` SET `完工`='{0}' WHERE `生产单号` ='{1}';"
                        , true ? '1' : '0', My.GetCellDefault(dgv[GongdanhaoColumn.Index, rowindex])));
                }
                if (MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    My.ShowMessage("更改成功!");
                    if (toolStripComboBox1.Text == "更改后立即更新")
                    {
                        ShuaXin();
                    }

                }
                else
                {
                    My.ShowErrorMessage("更改失败!");
                }
            }
        }
        /// <summary>
        /// 获取选中的行的索引集合
        /// </summary>
        /// <returns></returns>
        private List<int> GetSelectedRowIndexs()
        {
            List<int> rowIndexList = new List<int>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                int rowindex = cell.RowIndex;
                if (!rowIndexList.Contains(rowindex))
                {
                    rowIndexList.Add(rowindex);
                }
            }

            return rowIndexList;
        }

        private void 整单完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要执行[整单完成]操作吗?", "确定?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SetZhengdanWangong(true);
            }
        }

        private void 取消整单完工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要执行[取消整单完工]操作吗?", "确定?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SetZhengdanWangong(false);
            }
        }

        private void 更改交货日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            Form选择日期 selectDate = new Form选择日期(true);
            if (selectDate.ShowDialog() == DialogResult.OK)
            {
                dt = selectDate.GetDateTime_S();



                List<int> rowIndexList = GetSelectedRowIndexs();
                if (rowIndexList.Count > 0)
                {
                    List<string> sqlList = new List<string>();
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    foreach (int rowindex in rowIndexList)
                    {
                        sqlList.Add(
                            string.Format(
                            "UPDATE `slbz`.`订单_生产单` SET `计划交期`='{0}' WHERE `生产单号` ='{1}';"
                            , dt.ToString("yyyy-MM-dd"), My.GetCellDefault(dgv[GongdanhaoColumn.Name, rowindex])));
                    }
                    if (MySqlDbHelper.ExecuteSqlTran(sqlList))
                    {
                        My.ShowMessage("更改成功!");
                        if (toolStripComboBox1.Text == "更改后立即更新")
                        {
                            ShuaXin();
                        }
                    }
                    else
                    {
                        My.ShowErrorMessage("更改失败!");
                    }
                }
            }
        }

    }
}
