using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YBF.Class.Comm;
using HandeJobManager.DAL;

namespace YBF.WinForm.Maintain
{
    public partial class FormMaintainInfo : Form
    {

        private string ID;
        private bool IsAdd;

        public FormMaintainInfo()
        {
            ID = "0";
            IsAdd = true;
            InitializeComponent();
        }
        public FormMaintainInfo(string id, bool isAdd)
        {
            ID = id;
            IsAdd = isAdd;
            InitializeComponent();
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
                if (string.IsNullOrWhiteSpace(Comm_Method.GetCellDefault(row.Cells["设备"])))
                {
                    Comm_Method.ShowErrorMessage("设备不能为空！");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                string timeValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                object value = dgv["时间", row.Index].Value;
                if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                {
                    timeValue = Convert.ToDateTime(row.Cells["时间"].Value).ToString("yyyy-MM-dd HH:mm:ss");
                }

                if (IsAdd)//添加
                {
                    sqlList.Add("INSERT INTO [保养]([时间],[设备],[项目],[结果],[保养人])VALUES("
                    + "datetime('" + timeValue + "'),"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["设备"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["项目"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["结果"]) + "',"
                    + "'" + Comm_Method.GetCellDefault(row.Cells["保养人"]) + "'"
                    + ");");
                }

                else//修改
                {
                    sqlList.Add("UPDATE [保养]SET"
                    + "[时间] =datetime('" + timeValue + "'),"
                    + "[设备] ='" + Comm_Method.GetCellDefault(row.Cells["设备"]) + "',"
                    + "[项目] ='" + Comm_Method.GetCellDefault(row.Cells["项目"]) + "',"
                    + "[结果] ='" + Comm_Method.GetCellDefault(row.Cells["结果"]) + "',"
                    + "[保养人] ='" + Comm_Method.GetCellDefault(row.Cells["保养人"]) +"'"
                    +"where id="+ID+";");
                }

            }
            if (sqlList.Count > 0)
            {
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
            else
            {
                this.Dispose();
            }
        }

        private void FormMaintainInfo_Load(object sender, EventArgs e)
        {
            dgv.AllowUserToAddRows = IsAdd;
            dgv.AllowUserToDeleteRows = IsAdd;
            this.tsmiClear.Enabled = IsAdd;
            dgv.DataSource = SQLiteList.YBF.ExecuteDataTable("select [时间],[设备],[项目],[结果],[保养人]from[保养]where id=" + ID);
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
                for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                {
                    if (dgv.Rows[i].IsNewRow)
                    {
                        continue;
                    }
                    else
                    {
                        dgv.Rows.RemoveAt(i);
                    }
                }

            }
        }

        private void dgv_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["时间"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
