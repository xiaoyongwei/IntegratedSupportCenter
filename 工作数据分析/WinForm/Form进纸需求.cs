using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using excelToTable_NPOI;
using System.Diagnostics;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm
{
    public partial class Form进纸需求 : Form
    {
        private string SQLString1 = "SELECT *FROM `slbz`.`二期原纸进纸需求uv合并 (安全库存)` where 进纸!=0";

        public Form进纸需求()
        {
            InitializeComponent();
        }

        private void Form进纸需求_Load(object sender, EventArgs e)
        {
            dgv.DataSource = MySqlDbHelper.ExecuteDataTable(SQLString1);            
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgv.DataSource = MySqlDbHelper.ExecuteDataTable(SQLString1);
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt1 = MySqlDbHelper.ExecuteDataTable(SQLString1);
            dt1.TableName = ("需求表");

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel文件|*.xls";
            save.FileName = this.Text + "_" + DateTime.Now.ToString("yyyyMMdd");
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (new ExcelHelper(save.FileName).DataTableToExcel(dt1,dt1.TableName,true) > 1
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
    }
}
