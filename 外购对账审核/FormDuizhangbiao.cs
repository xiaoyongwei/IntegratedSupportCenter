using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;
using 纸箱纸板性能分析.WinForm;
using 综合保障中心.Comm;

namespace 外购对账审核
{
    public partial class FormDuizhangbiao : Form
    {
        private DataTable dt_dgv = new DataTable();

        public FormDuizhangbiao()
        {
            InitializeComponent();
        }

        private void FormDuizhangbiao_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxDuizhang.DataSource = SQLiteDbHelper.ExecuteDataTable("select * from 外购对账簿 where 完结=0");
                comboBoxDuizhang.ValueMember = "ID";
                comboBoxDuizhang.DisplayMember = "账簿名称";

                if (comboBoxDuizhang.Items.Count > 0)
                {
                    comboBoxDuizhang.SelectedIndex = 0;
                }
                else
                {
                    throw new Exception("没有可以活动的对账簿\n请联系管理员设置对账簿");
                }
                InitDgv();
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
                this.Dispose();
            }
        }

        private void InitDgv()
        {
            dgv.DataSource = dt_dgv = SQLiteDbHelper.ExecuteDataTable("select * from 外购记录_扩展 limit 1000");
            Search();
        }

        //true表示无效.false表示有效.
        //此函数为全局更改(慎用!!!)
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)//刷新
            {
                InitDgv();
            }
            if (keyData == Keys.F1)//转到对账簿
            {
                ToolStripMenuItem_Click(this.添加到对账簿ToolStripMenuItem, new EventArgs());
            }
            if (keyData == Keys.F2)//从对账簿移除
            {
                ToolStripMenuItem_Click(this.从对账簿移除ToolStripMenuItem, new EventArgs());
            }
            else if (keyData == (Keys.Control | Keys.S))//保存
            {

            }
            else if (keyData == Keys.Escape || keyData == Keys.F12 || keyData == (Keys.Control | Keys.F))//查询
            {
                this.textBoxSearch.Focus();
                this.textBoxSearch.SelectAll();
            }
            else if (keyData == Keys.F8)//选择类型
            {
                ToolStripMenuItem_Click(this.选择类型ToolStripMenuItem, new EventArgs());
                //if (dgv.SelectedCells.Count > 0)
                //{
                //    string chanpinmingcheng = My.GetCellDefault(dgv.SelectedCells[0].OwningRow.Cells["产品"]);
                //    FormWeihu leixingxuanze = new FormWeihu("select * from 外购类型 where id>0", "类型选择---" + chanpinmingcheng);
                //    if (leixingxuanze.ShowDialog() == DialogResult.OK
                //        && SQLiteDbHelper.ExecuteNonQuery("update 外购记录 set 类型=" + leixingxuanze.selectText.Trim() + " where 批次号='" + My.GetCellDefault(dgv.SelectedCells[0].OwningRow.Cells["批次号"]) + "'") > 0)
                //    {
                //        Search();
                //    }
                //}

            }
            return false;

        }

        private void tsmiSearch_Click(object sender, EventArgs e)
        {
            Search();

        }

        private void dgv_DataSourceChanged(object sender, EventArgs e)
        {
            dgv.AutoResizeColumns();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                switch (column.Name)
                {
                    //case "对账审核":
                    //    column.DefaultCellStyle.BackColor = Color.Red;
                    //    break;
                    case "价格":
                    case "金额":
                        column.DefaultCellStyle.ForeColor = Color.Red;
                        break;
                    //case "确认到货":
                    //    column.DefaultCellStyle.BackColor = Color.Blue;
                    //    break;
                    case "数量":
                    case "实发":
                        column.DefaultCellStyle.ForeColor = Color.Blue;
                        break;
                    default:
                        break;
                }
            }
        }

        private void tstbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search();
            }
        }

        private void Search()
        {
            string sqlStr = "";
            if (checkBoxJingque.Checked)//精确查找
            {
                sqlStr = "select * from 外购记录_扩展 where 产品='" + this.textBoxSearch.Text.Trim() + "'  order by 最后修改时间 DESC  limit 1000";
            }
            else
            {
                sqlStr = "select * from 外购记录_扩展 where 产品 like'%" + this.textBoxSearch.Text.Trim() + "%'OR 金额 like'%" + this.textBoxSearch.Text.Trim() + "%' OR [送货单] like'%" + this.textBoxSearch.Text.Trim() + "%' order by 最后修改时间 DESC  limit 1000";
            }
            dgv.DataSource = SQLiteDbHelper.ExecuteDataTable(sqlStr);
            this.labelgongji.Text = SQLiteDbHelper.ExecuteScalar("SELECT '计数'||count(金额)||',金额'||sum(金额) FROM (" + sqlStr + ");").ToString();
            dgv_duizhang.DataSource = SQLiteDbHelper.ExecuteDataTable("select * from 外购记录_扩展 where 对账簿='" + comboBoxDuizhang.Text + "'  order by 最后修改时间 DESC");
            dgv_duizhang.AutoResizeColumns();
            this.Text = SQLiteDbHelper.ExecuteScalar("select '计数'||count(金额)||',金额'||sum(金额) from 外购记录_扩展 where 对账簿='" + comboBoxDuizhang.Text + "'").ToString();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["对账簿"].Value.ToString() == comboBoxDuizhang.Text)
                {
                    row.Cells["产品"].Style.BackColor = Color.OrangeRed;
                }
            }
            if (dgv.Columns.Contains("温森工单号"))
            {
                dgv.Columns["温森工单号"].ReadOnly = false;
            }
            dgv.Focus();
        }

        //private void 选择类型ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    foreach (DataGridViewCell dgvCell in dgv.SelectedCells)
        //    {

        //    }


        //    if (dgv.SelectedCells.Count > 0)
        //    {

        //        string chanpinmingcheng = My.GetCellDefault(dgv.SelectedCells[0].OwningRow.Cells["产品"]);
        //        FormWeihu leixingxuanze = new FormWeihu("select * from 外购类型 where id>0", "类型选择---" + chanpinmingcheng);
        //        if (leixingxuanze.ShowDialog() == DialogResult.OK
        //            && SQLiteDbHelper.ExecuteNonQuery(string.Format("update 外购记录 set 类型={0} where 送货单='{1}' and 工单号='{2}'" ,
        //            leixingxuanze.selectText.Trim(),My.GetCellDefault(dgv["送货单", rowIndex]),My.GetCellDefault(dgv["工单号", rowIndex]))) > 0)
        //        {
        //            Search();
        //        }
        //    }
        //}

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string tsmiText = ((ToolStripMenuItem)sender).Text;
                string leixingxuanze = "";
                //判断选中的对账簿是否完结
                if (Convert.ToBoolean(SQLiteDbHelper.ExecuteScalar("select 完结 from 外购对账簿 where ID=" + comboBoxDuizhang.SelectedValue)))
                {
                    throw new Exception("对账簿[" + comboBoxDuizhang.Text + "]\n已经【完结】!");
                }


                List<int> rowIndexList = new List<int>();
                List<string> sqlList = new List<string>();
                foreach (DataGridViewCell cell in dgv.SelectedCells)
                {
                    if (!rowIndexList.Contains(cell.RowIndex))
                    {
                        rowIndexList.Add(cell.RowIndex);
                    }
                }

                if (tsmiText.Contains("选择类型"))
                {
                    string chanpinmingcheng = My.GetCellDefault(dgv.SelectedCells[0].OwningRow.Cells["产品"]);
                    FormWeihu weihu = new FormWeihu("select * from 外购类型 where id>0", "类型选择---" + My.GetCellDefault(dgv.SelectedCells[0].OwningRow.Cells["产品"]));
                    if (weihu.ShowDialog() == DialogResult.OK)
                    {
                        leixingxuanze = weihu.selectText;
                    }
                }



                foreach (int rowIndex in rowIndexList)
                {
                    string duizhangbu = My.GetCellDefault(dgv["对账簿", rowIndex]);
                    if (!string.IsNullOrWhiteSpace(duizhangbu))
                    {
                        //如果操作的记录有关联对账簿,则判断此记录关联的对账簿是否完结
                        if (Convert.ToBoolean(SQLiteDbHelper.ExecuteScalar("select 完结 from 外购对账簿 where 账簿名称='" + My.GetCellDefault(dgv["对账簿", rowIndex]) + "';")))
                        {
                            throw new Exception("记录:" + My.GetCellDefault(dgv["产品", rowIndex]) + "\n关联的对账簿[" + My.GetCellDefault(dgv["对账簿", rowIndex]) + "]\n已经【完结】!");
                        }
                    }



                    if (tsmiText.Contains("添加到对账簿"))
                    {
                        sqlList.Add(string.Format("update 外购记录 set 对账簿={0} where 送货单='{1}' and 工单号='{2}'",
                            comboBoxDuizhang.SelectedValue, My.GetCellDefault(dgv["送货单", rowIndex]), My.GetCellDefault(dgv["工单号", rowIndex])));
                    }
                    else if (tsmiText.Contains("从对账簿移除"))
                    {
                        sqlList.Add(string.Format("update 外购记录 set 对账簿=0 where 送货单='{0}' and 工单号='{1}'",
                            My.GetCellDefault(dgv["送货单", rowIndex]), My.GetCellDefault(dgv["工单号", rowIndex])));
                    }
                    else if (tsmiText.Contains("选择类型"))
                    {
                        sqlList.Add(string.Format("update 外购记录 set 类型={0} where 送货单='{1}' and 工单号='{2}'",
                    leixingxuanze, My.GetCellDefault(dgv["送货单", rowIndex]), My.GetCellDefault(dgv["工单号", rowIndex])));

                    }

                }
                if (SQLiteDbHelper.ExecuteSqlTran(sqlList))
                {
                    Search();
                }
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
            }
        }


        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string tsmiText = ((ToolStripMenuItem)sender).Text;
                string leixingxuanze = "";
                //判断选中的对账簿是否完结
                if (Convert.ToBoolean(SQLiteDbHelper.ExecuteScalar("select 完结 from 外购对账簿 where ID=" + comboBoxDuizhang.SelectedValue)))
                {
                    throw new Exception("对账簿[" + comboBoxDuizhang.Text + "]\n已经【完结】!");
                }


                List<int> rowIndexList = new List<int>();
                List<string> sqlList = new List<string>();
                foreach (DataGridViewCell cell in dgv_duizhang.SelectedCells)
                {
                    if (!rowIndexList.Contains(cell.RowIndex))
                    {
                        rowIndexList.Add(cell.RowIndex);
                    }
                }

                if (tsmiText.Contains("选择类型"))
                {
                    string chanpinmingcheng = My.GetCellDefault(dgv_duizhang.SelectedCells[0].OwningRow.Cells["产品"]);
                    FormWeihu weihu = new FormWeihu("select * from 外购类型 where id>0", "类型选择---" + My.GetCellDefault(dgv_duizhang.SelectedCells[0].OwningRow.Cells["产品"]));
                    if (weihu.ShowDialog() == DialogResult.OK)
                    {
                        leixingxuanze = weihu.selectText;
                    }
                }



                foreach (int rowIndex in rowIndexList)
                {
                    string duizhangbu = My.GetCellDefault(dgv_duizhang["对账簿", rowIndex]);
                    if (!string.IsNullOrWhiteSpace(duizhangbu))
                    {
                        //如果操作的记录有关联对账簿,则判断此记录关联的对账簿是否完结
                        if (Convert.ToBoolean(SQLiteDbHelper.ExecuteScalar("select 完结 from 外购对账簿 where 账簿名称='" + My.GetCellDefault(dgv_duizhang["对账簿", rowIndex]) + "';")))
                        {
                            throw new Exception("记录:" + My.GetCellDefault(dgv_duizhang["产品", rowIndex]) + "\n关联的对账簿[" + My.GetCellDefault(dgv_duizhang["对账簿", rowIndex]) + "]\n已经【完结】!");
                        }
                    }



                    if (tsmiText.Contains("添加到对账簿"))
                    {
                        sqlList.Add(string.Format("update 外购记录 set 对账簿={0} where 送货单='{1}' and 工单号='{2}'",
                            comboBoxDuizhang.SelectedValue, My.GetCellDefault(dgv_duizhang["送货单", rowIndex]), My.GetCellDefault(dgv_duizhang["工单号", rowIndex])));
                    }
                    else if (tsmiText.Contains("从对账簿移除"))
                    {
                        sqlList.Add(string.Format("update 外购记录 set 对账簿=0 where 送货单='{0}' and 工单号='{1}'",
                            My.GetCellDefault(dgv_duizhang["送货单", rowIndex]), My.GetCellDefault(dgv_duizhang["工单号", rowIndex])));
                    }
                    else if (tsmiText.Contains("选择类型"))
                    {
                        sqlList.Add(string.Format("update 外购记录 set 类型={0} where 送货单='{1}' and 工单号='{2}'",
                    leixingxuanze, My.GetCellDefault(dgv_duizhang["送货单", rowIndex]), My.GetCellDefault(dgv_duizhang["工单号", rowIndex])));

                    }

                }
                if (SQLiteDbHelper.ExecuteSqlTran(sqlList))
                {
                    Search();
                }
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
            }
        }

        private void 输入工单号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string tsmiText = ((ToolStripMenuItem)sender).Text;
                string leixingxuanze = "";
                //判断选中的对账簿是否完结
                if (Convert.ToBoolean(SQLiteDbHelper.ExecuteScalar("select 完结 from 外购对账簿 where ID=" + comboBoxDuizhang.SelectedValue)))
                {
                    throw new Exception("对账簿[" + comboBoxDuizhang.Text + "]\n已经【完结】!");
                }


                List<int> rowIndexList = new List<int>();
                List<string> sqlList = new List<string>();
                foreach (DataGridViewCell cell in dgv.SelectedCells)
                {
                    if (!rowIndexList.Contains(cell.RowIndex))
                    {
                        rowIndexList.Add(cell.RowIndex);
                    }
                }

                FormInputText formIT = new FormInputText();
                if (formIT.ShowDialog() == DialogResult.OK)
                {
                    foreach (int rowIndex in rowIndexList)
                    {
                        string duizhangbu = My.GetCellDefault(dgv["对账簿", rowIndex]);
                        if (!string.IsNullOrWhiteSpace(duizhangbu))
                        {
                            //如果操作的记录有关联对账簿,则判断此记录关联的对账簿是否完结
                            if (Convert.ToBoolean(SQLiteDbHelper.ExecuteScalar("select 完结 from 外购对账簿 where 账簿名称='" + My.GetCellDefault(dgv["对账簿", rowIndex]) + "';")))
                            {
                                throw new Exception("记录:" + My.GetCellDefault(dgv["产品", rowIndex]) + "\n关联的对账簿[" + My.GetCellDefault(dgv["对账簿", rowIndex]) + "]\n已经【完结】!");
                            }
                        }

                        sqlList.Add(string.Format("update 外购记录 set 温森工单号='{0}' where 送货单='{1}' and 工单号='{2}'",
                       formIT.wsgdh, My.GetCellDefault(dgv["送货单", rowIndex]), My.GetCellDefault(dgv["工单号", rowIndex])));

                    }
                }
                if (SQLiteDbHelper.ExecuteSqlTran(sqlList))
                {
                    Search();
                }
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
            }
        }

        private void 输入工单号ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string tsmiText = ((ToolStripMenuItem)sender).Text;
                string leixingxuanze = "";
                //判断选中的对账簿是否完结
                if (Convert.ToBoolean(SQLiteDbHelper.ExecuteScalar("select 完结 from 外购对账簿 where ID=" + comboBoxDuizhang.SelectedValue)))
                {
                    throw new Exception("对账簿[" + comboBoxDuizhang.Text + "]\n已经【完结】!");
                }


                List<int> rowIndexList = new List<int>();
                List<string> sqlList = new List<string>();
                foreach (DataGridViewCell cell in dgv_duizhang.SelectedCells)
                {
                    if (!rowIndexList.Contains(cell.RowIndex))
                    {
                        rowIndexList.Add(cell.RowIndex);
                    }
                }

                FormInputText formIT = new FormInputText();
                if (formIT.ShowDialog() == DialogResult.OK)
                {

                    foreach (int rowIndex in rowIndexList)
                    {
                        string duizhangbu = My.GetCellDefault(dgv_duizhang["对账簿", rowIndex]);
                        if (!string.IsNullOrWhiteSpace(duizhangbu))
                        {
                            //如果操作的记录有关联对账簿,则判断此记录关联的对账簿是否完结
                            if (Convert.ToBoolean(SQLiteDbHelper.ExecuteScalar("select 完结 from 外购对账簿 where 账簿名称='" + My.GetCellDefault(dgv_duizhang["对账簿", rowIndex]) + "';")))
                            {
                                throw new Exception("记录:" + My.GetCellDefault(dgv_duizhang["产品", rowIndex]) + "\n关联的对账簿[" + My.GetCellDefault(dgv_duizhang["对账簿", rowIndex]) + "]\n已经【完结】!");
                            }
                        }

                        sqlList.Add(string.Format("update 外购记录 set 温森工单号='{0}' where 送货单='{1}' and 工单号='{2}'",
                       formIT.wsgdh, My.GetCellDefault(dgv_duizhang["送货单", rowIndex]), My.GetCellDefault(dgv_duizhang["工单号", rowIndex])));

                    }
                }
                if (SQLiteDbHelper.ExecuteSqlTran(sqlList))
                {
                    Search();
                }
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
            }
        }

        private void 金蝶入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetJinDieRuKu(true);
        }

        private void SetJinDieRuKu(bool p)
        {
            try
            {
                //判断选中的对账簿是否完结
                if (Convert.ToBoolean(SQLiteDbHelper.ExecuteScalar("select 完结 from 外购对账簿 where ID=" + comboBoxDuizhang.SelectedValue)))
                {
                    throw new Exception("对账簿[" + comboBoxDuizhang.Text + "]\n已经【完结】!");
                }

                List<int> rowIndexList = new List<int>();
                List<string> sqlList = new List<string>();
                foreach (DataGridViewCell cell in dgv_duizhang.SelectedCells)
                {
                    if (!rowIndexList.Contains(cell.RowIndex))
                    {
                        rowIndexList.Add(cell.RowIndex);
                    }
                }


                foreach (int rowIndex in rowIndexList)
                {
                    sqlList.Add(string.Format("update 外购记录 set 金蝶入账='{0}' where 送货单='{1}' and 工单号='{2}'",
                        (p ? "1" : "0"), My.GetCellDefault(dgv_duizhang["送货单", rowIndex]), My.GetCellDefault(dgv_duizhang["工单号", rowIndex])));

                }

                if (SQLiteDbHelper.ExecuteSqlTran(sqlList))
                {
                    Search();
                }
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
            }
        }

        private void 金蝶入库取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetJinDieRuKu(false);
        }

        private void 金蝶入库确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetJinDieRuKu(true);
        }

        private void 金蝶入库取消ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetJinDieRuKu(false);
        }

        private void 彩盒工单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
