using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 综合保障中心.Comm;
using excelToTable_NPOI;
using System.Diagnostics;

namespace 工作数据分析.WinForm
{
    public partial class Form甩纸覆膜所需原纸 : Form
    {
        private string SQLString1 = "";
        private string SQLString2 = "";

        public Form甩纸覆膜所需原纸(string title, string sql1, string sql2)
        {
            InitializeComponent();
            this.Text = title;
            SQLString1 = sql1;
            SQLString2 = sql2;
        }

        private void Form甩纸所需原纸_Load(object sender, EventArgs e)
        {
            ShowResult();
        }

        private void ShowResult()
        {
            try
            {
                dgv1.DataSource = MySqlDbHelper.ExecuteDataTable(SQLString1);
                dgv2.DataSource = MySqlDbHelper.ExecuteDataTable(SQLString2);
                if (dgv1.Rows.Count>0)
                {
                    this.toolStripTextBox1.Text = "总数量:" + MySqlDbHelper.ExecuteScalar("select sum(`数量`) from (" + SQLString1 + ")a")
                    + ",需求卷数:" + MySqlDbHelper.ExecuteScalar("select sum(`整卷数`) from (" + SQLString2 + ")a");

                    if (!dgv1.Columns.Contains("工序") || !dgv1["工序", 0].Value.ToString().Contains("光膜"))
                    {
                        dgv1.ContextMenuStrip = null;
                    }
                    else
                    {
                        dgv1.ContextMenuStrip = contextMenuStrip1;
                    }
                }
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowResult();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt1 = MySqlDbHelper.ExecuteDataTable(SQLString1);
            DataTable dt2 = MySqlDbHelper.ExecuteDataTable(SQLString2);
            dt1.TableName = ("明细表");
            dt2.TableName = ("需求表");

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel文件|*.xls";
            save.FileName = this.Text + "_" + DateTime.Now.ToString("yyyyMMdd");
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (new ExcelHelper(save.FileName).DataTableListToExcel(
                    new List<DataTable> { dt1, dt2 }) > 1
                && MessageBox.Show("导出完成\n是否打开?", "打开?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process.Start(save.FileName);
                }
                else
                {
                    My.ShowErrorMessage("导出失败!");
                }
            }
        }

        private void 覆膜完工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv1.SelectedCells.Count == 1)
            {
                if (MySqlDbHelper.ExecuteNonQuery(string.Format(
                    "UPDATE `slbz`.`排程查询`SET `完工`=1 WHERE `工单`='{0}' and `工序`='{1}'"
                    , dgv1.SelectedCells[0].OwningRow.Cells["工单"].Value.ToString()
                    , dgv1.SelectedCells[0].OwningRow.Cells["工序"].Value.ToString())) == 0)
                {
                    My.ShowErrorMessage("操作失败");
                    return;
                }
                else
                {
                    ShowResult();
                }
            }
            else
            {
                My.ShowErrorMessage("只能选择一个进行操作");
                return;
            }
        }
    }
}
