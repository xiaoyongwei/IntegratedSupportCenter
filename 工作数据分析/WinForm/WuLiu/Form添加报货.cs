using System;
using System.Collections.Generic;
using System.Windows.Forms;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm.WuLiu
{
    public partial class Form添加报货 : Form
    {
        public Form添加报货()
        {
            InitializeComponent();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgv.EndEdit();
            List<string> sqlList = new List<string>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                if (string.IsNullOrWhiteSpace(My.GetCellDefault(row.Cells[ColumnKehu.Index]))
                    || string.IsNullOrWhiteSpace(My.GetCellDefault(row.Cells[ColumnGongdanhao.Index]))
                    || string.IsNullOrWhiteSpace(My.GetCellDefault(row.Cells[ColumnSonghuoshuliang.Index])))
                {
                    My.ShowErrorMessage("客户,工单号,送货数量.--不能为空!!");
                    return;
                }


                sqlList.Add(string.Format("INSERT INTO `slbz`.`物流_发货通知单`(`客户`,`工单号`,`送货数量`,`送货地点`,`产品状态`,`需要发货时间`,`实际发货时间`,"
                    + "`备注`,`报货人`,`发货人`,`报货时间`,`创建时间`,`修改时间`)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');",
                    My.GetCellDefault(row.Cells[ColumnKehu.Index]),
                    My.GetCellDefault(row.Cells[ColumnGongdanhao.Index]),
                    My.GetCellDefault(row.Cells[ColumnSonghuoshuliang.Index]),
                    My.GetCellDefault(row.Cells[ColumnSonghuodidian.Index]),
                    My.GetCellDefault(row.Cells[ColumnChanpinzhuangtai.Index]),
                    My.GetCellDefault(row.Cells[ColumnXuyaofahuoshijian.Index]),
                    My.GetCellDefault(row.Cells[ColumnShijidaohuoshijian.Index]),
                    My.GetCellDefault(row.Cells[ColumnBeizhu.Index]),
                    My.GetCellDefault(row.Cells[ColumnBaohuoren.Index]),
                    My.GetCellDefault(row.Cells[ColumnFahuoren.Index]),
                    My.GetCellDefault(row.Cells[ColumnBaohuoshijian.Index]),
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            if (MySqlDbHelper.ExecuteSqlTran(sqlList))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                My.ShowErrorMessage("保存失败!");
                this.DialogResult = DialogResult.None;
            }
        }

        private void dgv_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[ColumnXuyaofahuoshijian.Index].Value = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
            e.Row.Cells[ColumnShijidaohuoshijian.Index].Value = "1990-01-01 00:00:00";
            for (DateTime i = DateTime.Now; i <= DateTime.Now.AddDays(5); i = i.AddHours(1))
            {
                ColumnXuyaofahuoshijian.Items.Add(i.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            e.Row.Cells[ColumnBaohuoshijian.Index].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
