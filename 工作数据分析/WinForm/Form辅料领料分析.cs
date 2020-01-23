using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBUtility;
using 综合保障中心.Comm;
using excelToTable_NPOI;
using System.Diagnostics;
using 工作数据分析.Data.DAL;

namespace 工作数据分析.WinForm
{
    public partial class Form辅料领料分析 : Form
    {

        public Form辅料领料分析()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {

            DataTable dt1 = DataBaseList.sql财务.Querytable("SELECT v1.Fdate as '日期'"
                        + ",case "
                        + "when v1.FCheckerID > 0"
                        + "	then 'Y'"
                        + "	when v1.FCheckerID < 0"
                        + "		then 'Y'"
                        + "	else ''"
                        + "	end as '审核'"
                        + ",v1.FBillNo as '单据编号'"
                        + ",vw.FNumber '物料长代码'"
                        + ",vw.FItemID '物料名称'"
                        + ",vw.FUnitID '单位'"
                        + ",vw.Fauxqty '数量'"
                        + ",vw.Fauxprice '单价'"
                        + "	,ISNULL(case "
                        + "	when vw.Fauxprice = 0 "
                        + "	then isnull(( "
                        + "		SELECT TOP 1 Fauxprice * 1.13 "
                        + "		FROM [dbo].[vwICBill_11] "
                        + "		WHERE FNumber = vw.FNumber "
                        + "			AND Fauxprice != 0 "
                        + "		ORDER BY fdate DESC "
                        + "		), ( "
                        + "		SELECT TOP 1 Fauxprice * 1.13 AS '单价' "
                        + "		FROM [dbo].[vwICBill_1] "
                        + "		WHERE [Fauxprice] > 0 "
                        + "			and FNumber = vw.FNumber "
                        + "		ORDER by fdate desc "
                        + "		))"
                        + "else vw.Fauxprice"
                        + " end, 0) AS '估算单价'"
                        + "	,vw.Famount '金额'"
                        + "	,vw.FDeptID '领料部门'"
                        + "from ICStockBill v1 "
                        + "INNER JOIN ICStockBillEntry u1 ON v1.FInterID = u1.FInterID"
                        + "	AND u1.FInterID <> 0"
                        + "INNER JOIN t_Stock t8 ON u1.FSCStockID = t8.FItemID"
                        + "	AND t8.FItemID <> 0"
                        + "INNER JOIN t_ICItem t13 ON u1.FItemID = t13.FItemID"
                        + "	AND t13.FItemID <> 0"
                        + "INNER JOIN [dbo].[vwICBill_11] vw ON u1.FInterID = vw.FInterID"
                        + "	AND u1.FEntryID = vw.FEntryID"
                        + " where (ISNULL(t8.FName, '') = '二期辅料仓库')"
                        + "	AND (v1.FTranType = 24)"
                        + "	AND ("
                        + "		v1.FDate BETWEEN '" + dtp_start.Value.ToString("yyyy-MM-dd")+"'"
                        + "			AND '" + dtp_end.Value.AddDays(1).ToString("yyyy-MM-dd")+ "'"
                        + "		)"
                        + "order BY v1.fdate desc"
                        + "	,v1.FInterID desc");
                          
            dgv1.DataSource = dt1;

            foreach (DataGridViewColumn col in dgv1.Columns)
            {
                if (col.Name == "估算单价")
                {
                    col.ReadOnly = false;
                }
                else
                {
                    col.ReadOnly = true;
                }
            }
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                row.Cells["金额"].Value = Convert.ToDouble(row.Cells["数量"].Value) * Convert.ToDouble(row.Cells["估算单价"].Value);
            }
            dgv2.Rows.Clear();
        }

        private void Form辅料领料分析_Load(object sender, EventArgs e)
        {
            this.dtp_start.Value = DateTime.Now.AddDays(-10);
        }

        private void button生产各部门领料表_Click(object sender, EventArgs e)
        {
            dgv1.EndEdit();
            Dictionary<string, double> dic = new Dictionary<string, double>();

            foreach (DataGridViewRow row in dgv1.Rows)
            {
                string department = row.Cells["领料部门"].Value.ToString();//领料部门
                double amount = Convert.ToDouble(row.Cells["金额"].Value);//金额
                if (dic.Keys.Contains(department))
                {
                    dic[department]+=amount;
                }
                else
                {
                    dic.Add(department, amount);
                }
            }
            dgv2.Rows.Clear();
            double sum=0;
            foreach (string depart in dic.Keys)
            {
                dgv2.Rows.Add(new object[]{depart,dic[depart]});
                sum+=dic[depart];
            }
            dgv2.Rows.Add("总计:",sum);
            foreach (DataGridViewRow  row in dgv2.Rows)
            {
                row.Cells["ColumnRatio"].Value = Math.Round(Convert.ToDouble(row.Cells["ColumnAmount"].Value) / sum*100,2) + "%";
            }
        }

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.Columns[e.ColumnIndex].Name=="估算单价")
            {
                dgv1["金额", e.RowIndex].Value = Convert.ToDouble(dgv1["数量", e.RowIndex].Value) * Convert.ToDouble(dgv1["估算单价", e.RowIndex].Value);
            }
        }

        private void buttonOutputExcel_Click(object sender, EventArgs e)
        {
            DataTable dt1 = My.GetDgvToTable(dgv1);
            DataTable dt2 = My.GetDgvToTable(dgv2);
            dt1.TableName = ("领料明细");
            dt2.TableName = ("部门汇总");

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

        
    }
}
