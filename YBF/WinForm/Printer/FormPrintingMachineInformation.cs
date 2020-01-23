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

namespace YBF.WinForm.Printer
{
    public partial class FormPrintingMachineInformation : Form
    {
        /// <summary>
        /// 印刷机的ID
        /// </summary>
        private int PressID = 0;
        public FormPrintingMachineInformation()
        {
            InitializeComponent();
        }
        public FormPrintingMachineInformation(int id)
        {
            InitializeComponent();
            this.PressID = id;
        }

        private void FormPrintingMachineInformation_Load(object sender, EventArgs e)
        {
            this.dgv.ReadOnly = false;
            if (PressID > 0)
            {
                this.tsmiClear.Enabled = false;
                this.dgv.AllowUserToAddRows = false;
                this.dgv.AllowUserToDeleteRows = false;
            }
            else
            {
                this.dgv.AllowUserToAddRows = true;
                this.dgv.AllowUserToDeleteRows = true;
            }
            DataTable dt_bancai = SQLiteList.YBF.ExecuteDataTable("SELECT [ID],[名称]FROM [辅料]where 类型ID =(select id from 辅料类型 where 类型='CTP版材')");
            PS版材.DataSource = dt_bancai;
            PS版材.ValueMember = "ID";
            PS版材.DisplayMember = "名称";

            foreach (DataRow row in SQLiteList.YBF.ExecuteDataTable("SELECT [印刷机].[ID],[机台],[PS版材],[咬口外角线],[最大过纸],[最大印刷],[最小过纸],[最小印刷],[印刷机].[启用],[印刷机].[备注],[自动出版提交路径]FROM [印刷机]join [辅料]on[辅料].[ID]=[PS版材] WHERE  [印刷机].[ID]=" + PressID).Rows)
            {
                DataGridViewRow dgvRow = dgv.Rows[dgv.Rows.Add()];
                dgvRow.Cells["ID"].Value = row["ID"];
                dgvRow.Cells["机台"].Value = row["机台"];
                dgvRow.Cells["PS版材"].Value = row["PS版材"];
                dgvRow.Cells["咬口外角线"].Value = row["咬口外角线"];
                dgvRow.Cells["最大过纸"].Value = row["最大过纸"];
                dgvRow.Cells["最大印刷"].Value = row["最大印刷"];
                dgvRow.Cells["最小过纸"].Value = row["最小过纸"];
                dgvRow.Cells["最小印刷"].Value = row["最小印刷"];
                dgvRow.Cells["启用"].Value = row["启用"];
                dgvRow.Cells["备注"].Value = row["备注"];
                dgvRow.Cells["自动出版提交路径"].Value = row["自动出版提交路径"];
            } 
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            bool isExit = true;
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.IsNewRow)
                {
                    continue;
                }
                if (MessageBox.Show("列表中还有数据没有保存，确定要退出吗？", "退出？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    isExit = true;
                }
                else
                {
                    isExit = false;
                }
            }
            if (isExit)
            {
                this.Dispose();
            }
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            if (this.dgv.Rows.Count > 0
              && MessageBox.Show("清空后列表中都数据无法还原，确定要清空吗？", "清空？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgv.DataSource = new DataTable();
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            dgv.EndEdit();
            List<string> sqlList = new List<string>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                if (string.IsNullOrWhiteSpace(Comm_Method.GetCellDefault(row.Cells["机台"])))
                {
                    Comm_Method.ShowErrorMessage("机台不能为空!");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (PressID > 0)//修改
                {
                    sqlList.Add("UPDATE [印刷机]SET"
                   + "[机台]='" + Comm_Method.GetCellDefault(row.Cells["机台"]) + "'"
                   + ",[PS版材]='" + Comm_Method.GetCellDefault(row.Cells["PS版材"]) + "'"
                   + ",[咬口外角线]='" + Comm_Method.GetCellDefault(row.Cells["咬口外角线"]) + "'"
                   + ",[最大过纸]='" + Comm_Method.GetCellDefault(row.Cells["最大过纸"]) + "'"
                   + ",[最大印刷]='" + Comm_Method.GetCellDefault(row.Cells["最大印刷"]) + "'"
                   + ",[最小过纸]='" + Comm_Method.GetCellDefault(row.Cells["最小过纸"]) + "'"
                   + ",[最小印刷]='" + Comm_Method.GetCellDefault(row.Cells["最小印刷"]) + "'"
                   + ",[启用]='" + Comm_Method.GetCellDefault(row.Cells["启用"]) + "'"
                   + ",[备注]='" + Comm_Method.GetCellDefault(row.Cells["备注"]) + "'"
                   + ",[自动出版提交路径]='" + Comm_Method.GetCellDefault(row.Cells["自动出版提交路径"]) + "'"
                   +"WHERE ID="+PressID+";");
                }
                else//增加
                {
                    sqlList.Add("INSERT INTO [印刷机]([机台],[PS版材],[咬口外角线],[最大过纸],[最大印刷],[最小过纸],[最小印刷],[启用],[备注],[自动出版提交路径])VALUES("
                        + "'" + Comm_Method.GetCellDefault(row.Cells["机台"]) + "',"
                        + "'" + Comm_Method.GetCellDefault(row.Cells["PS版材"]) + "',"
                        + "'" + Comm_Method.GetCellDefault(row.Cells["咬口外角线"]) + "',"
                        + "'" + Comm_Method.GetCellDefault(row.Cells["最大过纸"]) + "',"
                        + "'" + Comm_Method.GetCellDefault(row.Cells["最大印刷"]) + "',"
                        + "'" + Comm_Method.GetCellDefault(row.Cells["最小过纸"]) + "',"
                        + "'" + Comm_Method.GetCellDefault(row.Cells["最小印刷"]) + "',"
                        + "'" + Comm_Method.GetCellDefault(row.Cells["启用"]) + "',"
                        + "'" + Comm_Method.GetCellDefault(row.Cells["备注"]) + "',"
                        + "'" + Comm_Method.GetCellDefault(row.Cells["自动出版提交路径"]) + "');");
                }

            }
            if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Comm_Method.ShowErrorMessage("保存失败!");
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
