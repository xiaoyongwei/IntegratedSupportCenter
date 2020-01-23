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

namespace YBF.WinForm.Abnormal
{
    public partial class FormAbnormalManager : Form
    {
        public FormAbnormalManager()
        {
            InitializeComponent();
        }

        private void FormAbnormalManager_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
            Reload();
        }

        private void tsmiShuaxin_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            dgv.DataSource = SQLiteList.YBF.ExecuteDataTable("select * from [异常]order by [发现时间]desc");
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            if (new FormAbnormalInfo().ShowDialog()==DialogResult.OK)
            {
                Reload();
            }            
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                if (new FormAbnormalInfo(cell.OwningRow.Cells["ID"].Value.ToString(),false).ShowDialog() == DialogResult.OK)
                {
                    Reload();
                }
                break;
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0 && MessageBox.Show("确定要删除选择的记录吗？", "删除？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> list = new List<string>();
                List<DataGridViewRow> rowList = new List<DataGridViewRow>();
                foreach (DataGridViewRow selectedRow in dgv.SelectedRows)
                {
                    string str = selectedRow.Cells["ID"].Value.ToString();
                    object obj = SQLiteList.YBF.ExecuteScalar("select count(*) from [异常] where id=" + str);
                    if (obj == null || Convert.ToInt32(obj) < 1)
                    {
                        Comm_Method.ShowErrorMessage("ID为：" + str + " 的数据不存在！");
                    }
                    else
                    {
                        list.Add("DELETE FROM [异常]WHERE ID=" + str + ";");
                        rowList.Add(selectedRow);
                    }
                }
                if (SQLiteList.YBF.ExecuteSqlTran(list))
                {
                    foreach (DataGridViewRow row in rowList)
                    {
                        dgv.Rows.Remove(row);
                    }
                    MessageBox.Show("删除成功！");

                }
                else
                {
                    Comm_Method.ShowErrorMessage("删除失败！");
                }
            }
            if (dgv.Rows.Count > 0 && dgv.SelectedRows.Count == 0)
            {
                Comm_Method.ShowErrorMessage("请选中行的标头再删除！");
            }
        }
    }
}
