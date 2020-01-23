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
    public partial class FormFuliaoLingLiao : Form
    {
        private Dictionary<string, string> dic_id_fuliao = new Dictionary<string, string>();

        public FormFuliaoLingLiao()
        {
            InitializeComponent();
        }

        private void FormFuliaoLingLiao_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }

            DataTable dt_Fuliao = SQLiteList.YBF.ExecuteDataTable("SELECT [ID],[名称]FROM [辅料]");
            if (dt_Fuliao.Rows.Count < 1)
            {
                Comm_Method.ShowErrorMessage("辅料为空,请先添加辅料");
                this.Dispose();
            }
            else
            {
                ColumnFlmc.DataSource = dt_Fuliao;
                ColumnFlmc.ValueMember = "ID";
                ColumnFlmc.DisplayMember = "名称";
                foreach (DataRow row in dt_Fuliao.Rows)
                {
                    dic_id_fuliao.Add(row["名称"].ToString(), row["ID"].ToString());
                }
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
                string fuliaoID = row.Cells[ColumnFlmc.Name].Value.ToString();
                sqlList.Add("INSERT INTO [辅料使用记录]([时间],[辅料ID],[数量],[摘要],[备注])VALUES(" +
                    "datetime('now','localtime')"
                    + ",'" + fuliaoID + "'"
                    + ",'" + Comm_Method.GetCellDefault(row.Cells[ColumnShuliang.Name]) + "'"
                    + ",'" + Comm_Method.GetCellDefault(row.Cells[ColumnZhaiyao.Name]) + "'"
                    + ",'" + Comm_Method.GetCellDefault(row.Cells[ColumnNote.Name]) + "');");
            }
            if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
            {
                MessageBox.Show("保存成功!");
                this.Dispose();
            }
            else
            {
                Comm_Method.ShowErrorMessage("保存失败！");
            }
        }
    }
}
