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

namespace YBF.WinForm.Accessories
{
    public partial class FormBancaiSunhaoInformation : Form
    {
        private int ID = 0;
        public FormBancaiSunhaoInformation()
        {
            InitializeComponent();
            this.dgv.AllowUserToAddRows = true;
            this.dgv.AllowUserToDeleteRows = true;
            this.tsmiClear.Enabled = true;
        }
        public FormBancaiSunhaoInformation(int id)
        {
            ID = id;
            InitializeComponent();
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.tsmiClear.Enabled = false;
        }
        private void FormBancaiSunhaoInformation_Load(object sender, EventArgs e)
        {
            机台.DataSource = SQLiteList.YBF.ExecuteDataTable("SELECT *FROM [印刷机]");
            机台.ValueMember = "ID";
            机台.DisplayMember = "机台";

            InitDgv();
        }

        private void InitDgv()
        {
            foreach (DataRow row in SQLiteList.YBF.ExecuteDataTable("SELECT *FROM [版材损耗] WHERE ID=" + ID.ToString()).Rows)
            {
                DataGridViewRow dgvRow = dgv.Rows[dgv.Rows.Add()];
                dgvRow.Cells["时间"].Value = row["时间"];
                dgvRow.Cells["机台"].Value = row["机台ID"];
                dgvRow.Cells["数量"].Value = row["数量"];
                dgvRow.Cells["原因"].Value = row["原因"];
                dgvRow.Cells["备注"].Value = row["备注"];
            }
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
                string timeValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                object value = dgv["时间", row.Index].Value;
                if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                {
                    timeValue = Convert.ToDateTime(row.Cells["时间"].Value).ToString("yyyy-MM-dd HH:mm:ss");
                }

                if (ID < 1)//添加
                {
                    sqlList.Add("INSERT INTO [版材损耗]([时间],[机台ID],[数量],[原因],[备注])VALUES("
                    + "datetime('" + timeValue + "'),"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["机台"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["数量"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["原因"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["备注"]) + "'"
                    + ");");
                }

                else//修改
                {
                    sqlList.Add("UPDATE [版材损耗]SET"
                    + "[时间] =datetime('" + timeValue + "'),"
                    + "[机台ID] ='" + Comm_Method.GetCellDefault(row.Cells["机台"]) + "',"
                    + "[数量] ='" + Comm_Method.GetCellDefault(row.Cells["数量"]) + "',"
                    + "[原因] ='" + Comm_Method.GetCellDefault(row.Cells["原因"]) + "',"
                    + "[备注] ='" + Comm_Method.GetCellDefault(row.Cells["备注"]) + "'"
                    + " WHERE ID=" + ID.ToString() + ";");
                }

            }
            if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
                Comm_Method.ShowErrorMessage("保存失败！");
            }
        }

        //public string GetCellDefault(DataGridViewCell cell)
        //{
        //    string sssss = cell.OwningColumn.Name;
        //    string ss = cell.ValueType.Name;
        //    string value = "";
        //    switch (cell.ValueType.Name)
        //    {
        //        case "Boolean":
        //            bool bll = cell.Value == null;
        //            value = ((cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString())) ? "0" : (Convert.ToBoolean(cell.Value) ? "1" : "0"));
        //            break;
        //        case "String":
        //            value = cell.Value == null ? "" : cell.Value.ToString();
        //            break;
        //        case "Int32":
        //        case "Int16":
        //        case "Int64":
        //        case "Double":
        //            value = cell.Value == null ? "0" : cell.Value.ToString();
        //            break;
        //        default:
        //            value = cell.Value == null ? "" : cell.Value.ToString();
        //            break;
        //    }

        //    return value;
        //}

        private void tsmiSaveQuit_Click(object sender, EventArgs e)
        {
            Save();
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
                this.dgv.Rows.Clear();
            }
        }

        private void dgv_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (dgv.Columns.Contains("时间"))
            {
                e.Row.Cells["时间"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}
