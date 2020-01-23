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
    public partial class FormAccessoriesInfo : Form
    {
        Dictionary<string, string> dic_leixing = new Dictionary<string, string>();
        private int ID = 0;
        public FormAccessoriesInfo()
        {
            InitializeComponent();
            this.dgv.AllowUserToAddRows = true;
            this.dgv.AllowUserToDeleteRows = true;
            this.tsmiClear.Enabled = true;
        }
        public FormAccessoriesInfo(int id)
        {
            ID = id;
            InitializeComponent();
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.tsmiClear.Enabled = false;
        }

        private void FormAccessoriesInfo_Load(object sender, EventArgs e)
        {
            DataTable dt_leixing = SQLiteList.YBF.ExecuteDataTable("select*from[辅料类型]");
            if (dt_leixing.Rows.Count == 0)
            {
                Comm_Method.ShowErrorMessage("辅料类型为空\n请先添加辅料类型");
                this.Dispose();
            }
            dic_leixing.Clear();
            this.dgv.DataSource = SQLiteList.YBF.ExecuteDataTable("SELECT *FROM [辅料] WHERE ID=" + ID.ToString());
            dgv.Columns["类型ID"].Visible = false;
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();            
            if (!dgv.Columns.Contains("辅料类型"))
            {
                col.Name = "辅料类型";
                col.HeaderText = "辅料类型";
                dgv.Columns.Add(col);
                foreach (DataRow row in dt_leixing.Rows)
                {
                    dic_leixing.Add(row["ID"].ToString(), row["类型"].ToString());
                    col.Items.Add(row["类型"].ToString());
                } 
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                DataRow[] rows = dt_leixing.Select("ID=" + row.Cells["类型ID"].Value.ToString());
                if (rows == null || rows.Length == 0)
                {
                    continue;
                }
                else
                {
                    row.Cells[col.Name].Value = dic_leixing[rows[0]["ID"].ToString()];
                }
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
                string leixing = row.Cells["辅料类型"].Value == null ? "" : row.Cells["辅料类型"].Value.ToString();
                string leixingID = "1";
                foreach (string item in dic_leixing.Keys)
                {
                    if (leixing == dic_leixing[item])
                    {
                        leixingID = item;
                    }
                }
                if (ID < 1)//添加
                {                    
                    sqlList.Add("INSERT INTO [辅料]([名称],[安全库存],[自定义代码],[单位],[启用],[备注],[类型ID])VALUES("
                    + "'" + row.Cells["名称"].Value + "',"
                    + "'" + row.Cells["安全库存"].Value + "',"
                    + "'" + row.Cells["自定义代码"].Value + "',"
                    + "'" + row.Cells["单位"].Value + "',"
                    + (Convert.ToBoolean(row.Cells["启用"].Value) ? "1" : "0")+","
                    + "'" + row.Cells["备注"].Value + "',"
                    + "'" + leixingID + "'"
                    + ");");
                }

                else//修改
                {
                    sqlList.Add("UPDATE [辅料]SET"
                    + "[名称] ='" + row.Cells["名称"].Value + "'"
                    + ",[安全库存] ='" + row.Cells["安全库存"].Value + "'"
                    + ",[自定义代码] ='" + row.Cells["自定义代码"].Value + "'"
                    + ",[单位] ='" + row.Cells["单位"].Value + "'"
                    + ",[启用] =" + (Convert.ToBoolean(row.Cells["启用"].Value) ? "1" : "0")
                    + ",[备注] ='" + row.Cells["备注"].Value + "'"
                    + ",[类型ID] ='" + leixingID + "'"
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

        private void tsmiSaveQuit_Click(object sender, EventArgs e)
        {
            Save();
            this.Dispose();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            if (this.dgv.Rows.Count>0
                &&MessageBox.Show("列表中还有数据没有保存，确定要退出吗？","退出？",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            if (this.dgv.Rows.Count > 0
                && MessageBox.Show("清空后列表中都数据无法还原，确定要清空吗？", "清空？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormAccessoriesInfo_Load(this, new EventArgs());
            }
            
        }
    }
}
