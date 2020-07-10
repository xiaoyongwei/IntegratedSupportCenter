using excelToTable_NPOI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 工作数据分析.Properties;
using 工作数据分析.WinForm.huidan;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm
{
    public partial class Form回单管理 : Form
    {
        public Form回单管理()
        {
            InitializeComponent();
        }

        private void Form回单管理_Load(object sender, EventArgs e)
        {

            ////关闭多余的窗体
            //foreach (Form f in this.ParentForm.MdiChildren)
            //{
            //    if (f.Name == this.Name && f.Handle != this.Handle)
            //    {
            //        f.Dispose();
            //    }
            //}

            this.comboBoxHdzc.SelectedIndex = 0;
            this.comboBoxXsbqs.SelectedIndex = 0;
            this.dtpS.Value = DateTime.Now.AddDays(-3);
            InitDgv();
        }

        private void InitDgv()
        {
            if ((dtpE.Value - dtpS.Value).Days > 90)
            {
                My.ShowErrorMessage("间隔时间不能超过90天");
                return;
            }
            else if (dtpE.Value < dtpS.Value)
            {
                My.ShowErrorMessage("开始日期不能大于结束日期");
                return;
            }

            string sql = string.Format("SELECT * FROM `slbz`.`送货回单情况`where 送货日期 between '{0}' and '{1}' and (送货单号 like'%{2}%' or 客户简称 like'%{2}%' or 业务员 like '%{2}%' or 司机 like '%{2}%' or 操作人 like'%{2}%' )"
                , dtpS.Value.ToString("yyyy-MM-dd"), dtpE.Value.ToString("yyyy-MM-dd"), textBoxSearch.Text.Trim());
            switch (comboBoxHdzc.Text)
            {
                case "正常回单":
                    sql += " and 回单正常 ='Y'";
                    break;
                case "异常回单":
                    sql += " and 回单正常 !='Y'";
                    break;
                case "全部回单":
                default:
                    break;
            }
            switch (comboBoxXsbqs.Text)
            {
                case "销售部签收":
                    sql += " and 销售部签收='Y' ";
                    break;
                case "销售部未签收":
                    sql += " and 销售部签收!='Y' ";
                    break;
                default:
                    break;
            }

            sql += " ORDER BY `送货日期`DESC,送货单号 DESC";
            dgv.DataSource = MySqlDbHelper.ExecuteDataTable(sql);
            SetDgvRowBackColor();
        }

	

       
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            InitDgv();
        }
        /// <summary>
        /// 获取选择的送货单号
        /// </summary>
        private List<string> GetSelectedPonos()
        {
            List<string> ponoList = new List<string>();
            List<int> selectedRowIndexList = new List<int>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                if (selectedRowIndexList.Contains(cell.RowIndex))
                {
                    continue;
                }
                else
                {
                    selectedRowIndexList.Add(cell.RowIndex);
                    ponoList.Add(dgv["送货单号", cell.RowIndex].Value.ToString());
                }
            }
            return ponoList;
        }

        private void Set回单正常(bool bl)
        {
            List<string> ponoList = GetSelectedPonos();
            if (ponoList.Count > 0)
            {
                StringBuilder sb = new StringBuilder("UPDATE `slbz`.`送货回单情况`SET `回单正常` = '"+(bl?"Y":"")+"'WHERE `送货单号` in(");
                foreach (string item in ponoList)
                {
                    sb.AppendFormat("'{0}',", item);
                }
                sb.Append("'');");
                MySqlDbHelper.ExecuteNonQuery(sb.ToString());
                InitDgv();
            }
        }

        private void Set销售部签收(bool bl)
        {
            List<string> ponoList = GetSelectedPonos();
            if (ponoList.Count > 0)
            {
                StringBuilder sb = new StringBuilder("UPDATE `slbz`.`送货回单情况`SET `销售部签收` = '" + (bl ? "Y" : "") + "'WHERE `送货单号` in(");
                foreach (string item in ponoList)
                {
                    sb.AppendFormat("'{0}',", item);
                }
                sb.Append("'');");
                MySqlDbHelper.ExecuteNonQuery(sb.ToString());
                InitDgv();
            }
        }

        private void 标记为回单正常ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Set回单正常(true);
        }

        private void 标记为回单异常ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Set回单正常(false);
        }

        private void 编辑信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> ponoList = GetSelectedPonos();
            if (ponoList.Count>0
                &&new Form回单信息(ponoList[0]).ShowDialog()==DialogResult.OK)
            {
                InitDgv();
            }
        }


        private void SetDgvRowBackColor()
        {
            if (dgv.Columns.Contains("回单正常"))
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["回单正常"].Value.ToString() == "Y")
                    {
                        row.DefaultCellStyle.BackColor = dgv.DefaultCellStyle.BackColor;
                        row.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.SelectionBackColor;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.DefaultCellStyle.SelectionBackColor = Color.Red;
                    }
                }
            }
        }

        private void dgv_Sorted(object sender, EventArgs e)
        {
            SetDgvRowBackColor();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> ponoList = GetSelectedPonos();

            if (ponoList.Count > 0
                && MessageBox.Show("确定要删除吗?", "删除?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                && MySqlDbHelper.ExecuteSqlTran("DELETE FROM `slbz`.`送货回单情况`WHERE `送货单号`='" + ponoList[0] + "';")
                )
            {
                InitDgv();
            }
        }

        private void 导出数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".xls";
            save.FileName = this.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            save.Filter = "Excel(.xls)|*.xls";
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (new ExcelHelper(save.FileName).DataTableToExcel((DataTable)dgv.DataSource, "回单情况"+DateTime.Now.ToString("yyyyMMdd"), true) > 0)
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

        private void 导入数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form回单导入().ShowDialog();
            InitDgv();
        }

        private void 标记为销售部签收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Set销售部签收(true);
        }

        private void 取消销售部签收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Set销售部签收(false);
        }
    }
}
