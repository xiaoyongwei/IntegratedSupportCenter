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
    public partial class FormBancaiSunhao : Form
    {
        public FormBancaiSunhao()
        {
            InitializeComponent();
        }

        private void FormBancaiSunhao_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
            dgv.DataSource = SQLiteList.YBF.ExecuteDataTable("SELECT * FROM [版材损耗扩展]ORDER BY [时间] DESC LIMIT 500");
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            if (new FormBancaiSunhaoInformation().ShowDialog() == DialogResult.OK)
            {
                FormBancaiSunhao_Load(this, new EventArgs());
            }
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgv.SelectedCells.Count > 0
               && new FormBancaiSunhaoInformation(Convert.ToInt32(this.dgv.SelectedCells[0].OwningRow.Cells["ID"].Value)).ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("修改成功！");
                FormBancaiSunhao_Load(this, new EventArgs());
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (this.dgv.SelectedRows.Count > 0
               && MessageBox.Show("确定要删除选择的记录吗？", "删除？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> sqlList = new List<string>();
                foreach (DataGridViewRow row in this.dgv.SelectedRows)
                {
                    string id = row.Cells["ID"].Value.ToString();
                    object obj = SQLiteList.YBF.ExecuteScalar("select count(*) from [版材损耗] where id=" + id);
                    if (obj == null || Convert.ToInt32(obj) < 1)
                    {
                        Comm_Method.ShowErrorMessage("ID为：" + id + " 的数据不存在！");
                    }
                    else
                    {
                        sqlList.Add("DELETE FROM [版材损耗]WHERE ID=" + id + ";");
                    }
                }
                if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
                {
                    MessageBox.Show("删除成功！");
                    FormBancaiSunhao_Load(this, new EventArgs());
                }
                else
                {
                    Comm_Method.ShowErrorMessage("删除失败！");
                }
            }
        }

        private void tsmiShuaxin_Click(object sender, EventArgs e)
        {
            dgv.DataSource = SQLiteList.YBF.ExecuteDataTable("SELECT * FROM [版材损耗扩展]ORDER BY [时间] DESC LIMIT 500");
        }

    }
}
