using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm
{
    public partial class Form筛选弹窗 : Form
    {
        public string WhereStr { get; set; }
        private List<string> ZiduanList = new List<string>();
        public Form筛选弹窗(List<string> ziduanList)
        {
            ZiduanList = ziduanList;
            InitializeComponent();
        }

        public void SetZiduanList(List<string> ziduanList)
        {
            ZiduanList = ziduanList;
        }

        private void Form筛选弹窗_Load(object sender, EventArgs e)
        {
            foreach (string item in ZiduanList)
            {
                columnZiduan.Items.Add(item);
            }
        }

        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgv.EndEdit();
            //不能存在空值
            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                if (dgvRow.IsNewRow)
                {
                    continue;
                }
                foreach (DataGridViewColumn dgvCol in dgv.Columns)
                {
                    if (dgvRow.Index == 0 || dgvCol == ColumnLuoji)
                    {
                        continue;
                    }
                    if (dgvRow.Cells[dgvCol.Index].Value == null
                        || string.IsNullOrWhiteSpace(dgvRow.Cells[dgvCol.Index].Value.ToString()))
                    {
                        My.ShowErrorMessage(string.Format("第{0}行,{1}\n存在空值!"
                            , dgvRow.Index + 1, dgvCol.HeaderText));
                        return;
                    }
                }
            }



            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow dgvRow = dgv.Rows[i];
                if (dgvRow.IsNewRow)
                {
                    continue;
                }
                if (i == 0)
                {
                    dgvRow.Cells[ColumnLuoji.Index].Value = "";
                }
                string zhi = dgvRow.Cells[ColumnZhi.Index].Value.ToString();
                if (string.IsNullOrWhiteSpace(zhi))
                {
                    continue;
                }
                string tiaojian = "";
                switch (dgvRow.Cells[ColumnTiaojian.Index].Value.ToString())
                {
                    case "等于":
                        tiaojian = " ='" + zhi + "' ";
                        break;
                    case "不等于":
                        tiaojian = " !='" + zhi + "' ";
                        break;
                    case "包含":
                        tiaojian = " like'%" + zhi + "%' ";
                        break;
                    case "不包含":
                        tiaojian = " not like'%" + zhi + "%' ";
                        break;
                    case "开头是":
                        tiaojian = " like'" + zhi + "%' ";
                        break;
                    case "开头不是":
                        tiaojian = " not like'" + zhi + "%' ";
                        break;
                    case "结尾是":
                        tiaojian = " like'%" + zhi + "' ";
                        break;
                    case "结尾不是":
                        tiaojian = " not like'%" + zhi + "' ";
                        break;
                    case "大于":
                        tiaojian = " >'" + zhi + "' ";
                        break;
                    case "小于":
                        tiaojian = " <'" + zhi + "' ";
                        break;
                    case "大于等于":
                        tiaojian = " >='" + zhi + "' ";
                        break;
                    case "小于等于":
                        tiaojian = " <='" + zhi + "' ";
                        break;
                    default: break;
                }

                sb.Append(" " + dgvRow.Cells[ColumnLuoji.Index].Value.ToString() + " "
                    + "`" + dgvRow.Cells[columnZiduan.Index].Value.ToString() + "`"
                    + tiaojian + " ");
            }
            WhereStr = sb.ToString();

            this.DialogResult = DialogResult.OK;


        }


        private void dgv_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[ColumnLuoji.Index].Value = "AND";
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dgv.SelectedCells[0].OwningRow.IsNewRow)
            {
                dgv.Rows.Remove(this.dgv.SelectedCells[0].OwningRow);
            }
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("清空后无法恢复\n确定要清空吗?", "清空?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgv.Rows.Clear();
            }

        }



    }
}
