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
    public partial class FormFuliaoPandian : Form
    {
        public FormFuliaoPandian()
        {
            InitializeComponent();
        }

        private void FormFuliaoPandian_Load(object sender, EventArgs e)
        {
            InitDgv();
        }

        private void InitDgv()
        {
           DataTable dt_fuliao= SQLiteList.YBF.ExecuteDataTable("SELECT *FROM [辅料]");
           DataTable dt_dgv = new DataTable();
            int ii=1;
            dt_dgv.Columns.Add("时间", DateTime.Now.Date.GetType());
            foreach (DataRow row in dt_fuliao.Rows)
            {
                dt_dgv.Columns.Add(row["名称"].ToString(), ii.GetType());
            }
            dt_dgv.Columns.Add("备注");
            dt_dgv.Rows.Add()["时间"]=DateTime.Now.ToString("yyyy-MM-dd");
            dgv.DataSource = dt_dgv;
        }

        private void tsmiReload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("重载后数据会丢失,确定要重载吗?", "重载?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InitDgv();
            }
            
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗?","退出?",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Dispose();
            }
            
        }

        private void FormFuliaoPandian_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (DataGridViewCell cell in dgv.Rows[0].Cells)
            {
                if (cell.OwningColumn.Name != "时间" && cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString())
                    &&MessageBox.Show("数据表中已经存在输入的数据,请问还要退出吗?","退出",MessageBoxButtons.YesNo,MessageBoxIcon.Question)!=DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            this.dgv.EndEdit();
            DataGridViewRow row=dgv.Rows[0];
            foreach (DataGridViewCell cell in dgv.Rows[0].Cells)
            {
                if (cell.Value==null||string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    Comm_Method.ShowErrorMessage("有数据为空,请检查后再保存!");
                    return;
                }
            }
            List<string> sqlList = new List<string>();
            DateTime dTime = DateTime.Now;
            foreach (DataGridViewCell cell in dgv.Rows[0].Cells)
            {
                if (cell.OwningColumn.Name != "时间" && cell.OwningColumn.Name != "备注")
                {
                    StringBuilder sb = new StringBuilder("INSERT INTO [辅料库存]([日期],[辅料名称],[数量],[记录时间],[备注])VALUES(");
                    sb.AppendFormat("'{0}',", Convert.ToDateTime(row.Cells["时间"].Value).ToString("yyyy-MM-dd"));
                    sb.AppendFormat("'{0}',", cell.OwningColumn.Name);
                    sb.AppendFormat("'{0}',", cell.Value);
                    sb.AppendFormat("'{0}',", dTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.AppendFormat("'{0}');", row.Cells["备注"].Value);

                    sqlList.Add(sb.ToString());
                }
                
            }
            if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
            {
                //MessageBox.Show("保存成功!");
               this.Dispose();
            }
            else
            {
                Comm_Method.ShowErrorMessage("保存失败!");
            }
            
        }
    }
}
