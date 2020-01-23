using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm
{
    public partial class Form排程查询 : Form
    {

        public Form排程查询(string gongdanhao, string gongxu)
        {
            InitializeComponent();
            this.textBoxGongdan.Text = gongdanhao;
            this.comboBoxGongxu.Text = gongxu;
        }

        private void Form排程查询_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in MySqlDbHelper.ExecuteDataTable("SELECT `名称`FROM `slbz`.`工序管理`;").Rows)
            {
                this.comboBoxGongxu.Items.Add(row[0].ToString());
                this.comboBoxGongxu.AutoCompleteCustomSource.Add(row[0].ToString());
            }
            Search();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void Search()
        {
            dgv.DataSource = MySqlDbHelper.ExecuteDataTable(string.Format("SELECT `完工`,`工序`,`排单`,`工单`,`客户`,`产品`,`规格`,`数量`,`设备`,`开单/交期/排期`,`备注`FROM `slbz`.`排程查询`"
                    + "where `工单` like'%{0}%' and `工序` like '%{1}%' and `客户`like '%{2}%' and `产品`like'%{3}%'"
                    + " limit 1000;", this.textBoxGongdan.Text.Trim(), this.comboBoxGongxu.Text.Trim()
                    ,this.textBoxKuhu.Text.Trim(),this.textBoxChanpin.Text.Trim()));
            dgv.AutoResizeColumns();
        }

        private void 此工序已经完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGongxuWangong(true);
        }
        private void 此工序未完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGongxuWangong(false);
        }
        /// <summary>
        /// 设置工序完工
        /// </summary>
        /// <param name="isWangong">是否设置为完工</param>
        private void SetGongxuWangong(bool isWangong)
        {
            List<int> rowIndexList = GetSelectedRowIndexs();
            if (rowIndexList.Count > 0)
            {
                List<string> sqlList = new List<string>();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                foreach (int rowindex in rowIndexList)
                {
                    sqlList.Add(
                        string.Format(
                        "UPDATE `slbz`.`排程查询` SET `完工`='{0}' WHERE `工单`='{1}' AND `工序` ='{2}';"
                        , true ? '1' : '0', My.GetCellDefault(dgv["工单", rowindex]), My.GetCellDefault(dgv["工序", rowindex])));
                }
                if (MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    My.ShowMessage("更改成功!");
                    Search();
                }
                else
                {
                    My.ShowErrorMessage("更改失败!");
                }
            }
        }

        private void 整单完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetZhengdanWangong(true);
        }

        private void 取消整单完工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetZhengdanWangong(false);
        }

        /// <summary>
        /// 设置整单完工
        /// </summary>
        /// <param name="isWangong">是否设置为完工</param>
        private void SetZhengdanWangong(bool isWangong)
        {
            List<int> rowIndexList = GetSelectedRowIndexs();
            if (rowIndexList.Count > 0)
            {
                List<string> sqlList = new List<string>();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                foreach (int rowindex in rowIndexList)
                {
                    sqlList.Add(
                        string.Format(
                        "UPDATE `slbz`.`订单_生产单` SET `完工`='{0}' WHERE `生产单号` ='{1}';"
                        , true ? '1' : '0', My.GetCellDefault(dgv["工单", rowindex])));
                }
                if (MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    My.ShowMessage("更改成功!");
                    Search();
                }
                else
                {
                    My.ShowErrorMessage("更改失败!");
                }
            }
        }
        /// <summary>
        /// 获取选中的行的索引集合
        /// </summary>
        /// <returns></returns>
        private List<int> GetSelectedRowIndexs()
        {
            List<int> rowIndexList = new List<int>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                int rowindex = cell.RowIndex;
                if (!rowIndexList.Contains(rowindex))
                {
                    rowIndexList.Add(rowindex);
                }
            }

            return rowIndexList;
        }

       
    }
}
