using System;
using System.Data;
using System.Windows.Forms;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm
{
    public partial class Form计划交期订单 : Form
    {
        public Form计划交期订单()
        {
            InitializeComponent();
        }

        private void Form计划交期订单_Load(object sender, EventArgs e)
        {
            foreach (DataRow item in MySqlDbHelper.ExecuteDataTable("SELECT `计划交期`FROM `slbz`.`订单_生产单`where `所属`='二期'group by `计划交期`ORDER BY `计划交期` DESC LIMIT 100").Rows)
            {
                treeViewDate.Nodes.Add(item[0].ToString());
            }

        }



        private void 查看报工情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                new FormShowData("报工查询", "CALL `slbz`.`获取单个工单报工情况`('" + cell.OwningRow.Cells["生产单号"].Value.ToString() + "');").ShowDialog();
                break;
            }
        }

        private void 查看工序情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                new FormShowData("工序查询", "CALL `slbz`.`获取单个工单工序情况`('" + cell.OwningRow.Cells["生产单号"].Value.ToString() + "');").ShowDialog();
                break;
            }
        }

        private void treeViewDate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string dateStr = e.Node.Text;
            DateTime dTime = new DateTime();
            if (DateTime.TryParse(dateStr, out dTime))
            {
                dgv.DataSource = MySqlDbHelper.ExecuteDataTable(string.Format("CALL `slbz`.`二期计划交期订单`('{0}','{0}')", dateStr));
                dgv.AutoResizeColumns();
            }
            else
            {
                My.ShowErrorMessage("字符串不是正确的日期格式");
            }
        }


    }
}
