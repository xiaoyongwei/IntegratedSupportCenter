using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm.物流
{
    public partial class Form发货通知单Add : Form
    {
        public Form发货通知单Add()
        {
            InitializeComponent();
        }

        private void Form发货通知单Add_Load(object sender, EventArgs e)
        {

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (DataGridViewRow dgvRow in dgv.Rows)
                {
                    if (dgvRow.IsNewRow)
                    {
                        continue;
                    }
                    //客户,工单号,数量,产品状态,需要发货时间,报货人,报货时间
                    //以上不能为空
                    if (string.IsNullOrWhiteSpace(My.GetCellDefault(dgvRow.Cells[ColumnKehu.Index]))
                        || string.IsNullOrWhiteSpace(My.GetCellDefault(dgvRow.Cells[ColumnGongdanhao.Index]))
                        || string.IsNullOrWhiteSpace(My.GetCellDefault(dgvRow.Cells[ColumnSonghuoshuliang.Index]))
                        || string.IsNullOrWhiteSpace(My.GetCellDefault(dgvRow.Cells[ColumnXuyaofahuoshijian.Index]))
                        || string.IsNullOrWhiteSpace(tstbBaohuoren.Text)
                        || string.IsNullOrWhiteSpace(tstbBaohuoshijian.Text))
                    {
                        throw new Exception("信息不能为空!");
                    }
                    //开始正式记录
                    
                }
            }
            catch (Exception ex)
            {
                My.ShowMessage(ex.Message);
            }
        }
    }
}
