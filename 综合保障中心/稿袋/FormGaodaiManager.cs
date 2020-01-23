using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;
using 综合保障中心.登录;
using 综合保障中心.Comm;

namespace 综合保障中心.稿袋
{
    public partial class FormGaodaiManager : Form
    {
        public FormGaodaiManager()
        {
            InitializeComponent();
        }

        private void FormGaodaiManager_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }

            this.menuStrip1.Visible = User.稿袋管理权限;


            Shuaxin();

        }

        private void Shuaxin()
        {
            Shuaxin("select  [稿袋号],[客户名称],[产品名称],[创建时间],[创建人],[最后修改时间],[最后修改人],[存放位置] from [稿袋]");
        }

        private void Shuaxin(string sql)
        {
            this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.dgv.DataSource = SQLiteList.GD.ExecuteDataTable(sql);
            this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void 稿袋自动生成系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAutoMake().ShowDialog();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBoxCustomer.Text) &&
                string.IsNullOrWhiteSpace(this.textBoxProduct.Text))
            {
                Shuaxin();
            }
            else
            {
                Shuaxin(string.Format(
             "select * from [稿袋] where [客户名称]like'%{0}%' and [产品名称]like'%{1}%'",
             this.textBoxCustomer.Text.Trim(), this.textBoxProduct.Text.Trim()));
            }

        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            Shuaxin();
        }

        private void 增加稿袋编号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAddGaodai().ShowDialog();
        }

        private void 报废ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedCells[0].OwningRow;
                string gdh = row.Cells["稿袋号"].Value.ToString();

                DataTable dt = SQLiteList.GD.ExecuteDataTable("select * from 稿袋 where[稿袋号]='" + gdh + "'");

                if (dt.Rows.Count > 0 &&
                    MessageBox.Show("确定要报废吗?此操作无法撤销!", "报废?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK &&
                    new FormBaoFei(gdh).ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("报废成功!");
                }
            }
        }

        private void 共用此稿袋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0)
            {
                string gdh = dgv.SelectedCells[0].OwningRow.Cells["稿袋号"].Value.ToString().Substring(0, 4);
                FormAutoMake make = new FormAutoMake(true, gdh);
                make.ShowDialog();
            }

        }

        private void 查看明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count>0)
            {
                new FormGaodaiInfo(dgv.SelectedCells[0].OwningRow.Cells["稿袋号"].Value.ToString()
                    ,false)
                    .ShowDialog();
            }
        }

        private void 查看历史ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0)
            {
                string gdh = dgv.SelectedCells[0].OwningRow.Cells["稿袋号"].Value.ToString().Substring(0, 4);
                new FormHistory(gdh).ShowDialog();
            }
        }

        private void 更改此稿袋的信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0)
            {
                new FormGaodaiInfo(dgv.SelectedCells[0].OwningRow.Cells["稿袋号"].Value.ToString()
                    , true)
                    .ShowDialog();
            }
        }

        private void 批量导入ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
