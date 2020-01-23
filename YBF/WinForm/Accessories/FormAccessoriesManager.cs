using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;
using System.Data.SQLite;
using YBF.Class.Comm;

namespace YBF.WinForm.Accessories
{
    public partial class FormAccessoriesManager : Form
    {
        
        //true表示无效.false表示有效.
        //此函数为全局更改(慎用!!!)
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)//刷新
            {
                LoadAccessories();
            }
            //else if (keyData == (Keys.Control | Keys.S))
            //{
            //    Save();
            //}

            return false;

        }

        public FormAccessoriesManager()
        {
            InitializeComponent();
        }

        private void FormAccessoriesManager_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
            LoadAccessories();
        }

        private void LoadAccessories()
        {
            this.dgv.DataSource = SQLiteList.YBF.ExecuteDataTable("SELECT [辅料].[ID],[名称],[安全库存],[自定义代码],[单位],[启用],[辅料类型].[类型],[备注]FROM [辅料]join [辅料类型]on [辅料].[类型ID]=[辅料类型].[ID]");
            
        }

        private void tsmiReload_Click(object sender, EventArgs e)
        {
            LoadAccessories();
        }
        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            if (new FormAccessoriesInfo().ShowDialog()==DialogResult.OK)
            {
                LoadAccessories();
            }
            
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (this.dgv.SelectedRows.Count>0
                &&MessageBox.Show("确定要删除选择的记录吗？","删除？",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                List<string> sqlList = new List<string>();
                foreach (DataGridViewRow row in this.dgv.SelectedRows)
                {
                    string id = row.Cells["ID"].Value.ToString();
                    object obj = SQLiteList.YBF.ExecuteScalar("select count(*) from 辅料 where id=" + id);
                    if (obj==null||Convert.ToInt32(obj)<1)
                    {
                        Comm_Method.ShowErrorMessage("ID为：" + id + " 的数据不存在！");
                    }
                    else
                    {
                        sqlList.Add("DELETE FROM [辅料]WHERE ID=" + id+";");
                    }
                }
                if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
                {
                    MessageBox.Show("删除成功！");
                    LoadAccessories();
                }
                else
                {
                    Comm_Method.ShowErrorMessage("删除失败！");
                }
            }
        }

        private void tsmiChange_Click(object sender, EventArgs e)
        {
            if (this.dgv.SelectedRows.Count>0
                && new FormAccessoriesInfo(Convert.ToInt32(this.dgv.SelectedRows[0].Cells["ID"].Value)).ShowDialog() == DialogResult.OK)
            {
               // MessageBox.Show("修改成功！");
                LoadAccessories();
            }
            
            
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsmiChange_Click(this, new EventArgs());
        }

        
        
    }
}
