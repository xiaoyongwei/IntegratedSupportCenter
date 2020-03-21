using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm
{
    public partial class Form筛选二期订单 : Form
    {
        /// <summary>
        /// 当前页
        /// </summary>
        private int PositionPage = 1;
        /// <summary>
        /// 总页数
        /// </summary>
        private int CountPage = 1;
        /// <summary>
        /// 每页数据
        /// </summary>
        private int PerPageItem = 15;
        /// <summary>
        /// 总数据量
        /// </summary>
        private int CountItem = 0;
        /// <summary>
        /// 筛选的Wher子句
        /// </summary>
        public string WhereString { get; set; }

        public Form筛选二期订单()
        {
            InitializeComponent();
        }

        private void Form筛选二期订单_Load(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Text = PositionPage.ToString();
            bindingNavigatorCountPage.Text = CountPage.ToString();
            tscbPerPage.SelectedItem = PerPageItem;
            //if (string.IsNullOrWhiteSpace(WhereString))
            //{
            //    dgv.DataSource=MySqlDbHelper.ExecuteDataTable("SELECT * from slbz.订单_生产单 where 1=0");
            //    this.筛选ToolStripMenuItem_Click(this, new EventArgs());
            //}
            //foreach (DataRow dr in MySqlDbHelper.ExecuteDataTable("SELECT 所属 from slbz.订单_生产单 group by 所属;").Rows)
            //{
            //    toolStripComboBox1.Items.Add(dr[0].ToString());
            //}
            //if (toolStripComboBox1.Items.Count>0)
            //{
            //    toolStripComboBox1.Text = toolStripComboBox1.Items[0].ToString();
            //}
            ShowData();
        }
        private void ShowData()
        {
            //1.通过没有多少获取一共有多少页
            PerPageItem = Convert.ToInt32(this.tscbPerPage.Text);
            if (string.IsNullOrWhiteSpace(WhereString))
            {
                WhereString = "1=1";
            }
            CountItem = Convert.ToInt32(MySqlDbHelper.ExecuteScalar("select count(*) from 订单_生产单 where "
                + WhereString));

            if (PositionPage > CountPage)
            {
                PositionPage = CountPage;
            }
            this.bindingNavigatorCountPage.Text = CountPage.ToString();
            if (PositionPage < 1)
            {
                PositionPage = 1;
            }
            dgv.DataSource = MySqlDbHelper.ExecuteDataTable(string.Format(
                "select * from 订单_生产单 where {0} limit {1} offset {2} "
                , WhereString, PerPageItem, PerPageItem * (PositionPage - 1)));

            CountPage = Convert.ToInt32(Math.Ceiling(1.0 * CountItem / PerPageItem));


            this.bindingNavigatorPositionItem.Text = PositionPage.ToString();


            dgv.AutoResizeColumns();
        }

        private void 二期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;

            List<int> listRowIndex = new List<int>();
            List<string> listGd = new List<string>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                int rowindex = cell.RowIndex;

                if (!listRowIndex.Contains(rowindex))
                {
                    listRowIndex.Add(rowindex);
                }
            }
            StringBuilder sb = new StringBuilder();
            if (listRowIndex.Count > 0)
            {
                sb = new StringBuilder();
                sb.Append("UPDATE `slbz`.`订单_生产单` SET `所属` ='" + tsmi.Text + "'	WHERE `生产单号` IN( ");
                foreach (int ri in listRowIndex)
                {
                    sb.Append("'" + dgv["生产单号", ri].Value.ToString() + "',");
                }
                sb.Append("'0');");
            }
            if (MySqlDbHelper.ExecuteNonQuery(sb.ToString()) == 0)
            {
                My.ShowErrorMessage("提交数据错误!");
            }
        }

        private void 筛选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> ziduanList = new List<string>();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                ziduanList.Add(col.DataPropertyName);
            }
            if (My.筛选弹窗 == null || My.筛选弹窗.IsDisposed)
            {
                My.筛选弹窗 = new Form筛选弹窗(ziduanList);
            }
            else
            {
                My.筛选弹窗.SetZiduanList(ziduanList);
            }

            if (My.筛选弹窗.ShowDialog() == DialogResult.OK)
            {
                WhereString = My.筛选弹窗.WhereStr;
                ShowData();
            }
        }

        private void 面纸加工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;

            List<int> listRowIndex = new List<int>();
            List<string> listGd = new List<string>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                int rowindex = cell.RowIndex;

                if (!listRowIndex.Contains(rowindex))
                {
                    listRowIndex.Add(rowindex);
                }
            }
            StringBuilder sb = new StringBuilder();
            if (listRowIndex.Count > 0)
            {

                sb = new StringBuilder();
                sb.Append("UPDATE `slbz`.`订单_生产单` SET `类型`='面纸加工' WHERE `生产单号` IN( ");
                foreach (int ri in listRowIndex)
                {
                    sb.Append("'" + dgv["生产单号", ri].Value.ToString() + "',");
                }
                sb.Append("'0');");
            }
            if (MySqlDbHelper.ExecuteNonQuery(sb.ToString()) == 0)
            {
                My.ShowErrorMessage("提交数据错误!");
            }
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            PositionPage = 1;
            bindingNavigatorPositionItem.Text = "1";
            ShowData();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Text = (--PositionPage).ToString();
            ShowData();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Text = (++PositionPage).ToString();
            ShowData();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            PositionPage = CountPage;
            bindingNavigatorPositionItem.Text = PositionPage.ToString();
            ShowData();
        }





        private void bindingNavigatorPositionItem_TextChanged(object sender, EventArgs e)
        {
            ShowData();
        }




        private void tscbPerPage_TextChanged(object sender, EventArgs e)
        {
            PerPageItem = Convert.ToInt32(tscbPerPage.Text);
            ShowData();
        }

        private void 已完工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;

            List<int> listRowIndex = new List<int>();
            List<string> listGd = new List<string>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                int rowindex = cell.RowIndex;

                if (!listRowIndex.Contains(rowindex))
                {
                    listRowIndex.Add(rowindex);
                }
            }
            StringBuilder sb = new StringBuilder();
            if (listRowIndex.Count > 0)
            {
                string updateStr = "";
                switch (tsmi.Text)
                {
                    case "已完工":
                        updateStr = "`完工`=1";
                        break;
                    case "取消已完工":
                        updateStr = "`完工`=0";
                        break;
                    case "已入库":
                        updateStr = "`入库`=1";
                        break;
                    case "取消已入库":
                        updateStr = "`入库`=0";
                        break;
                    default:
                        break;
                }
                sb = new StringBuilder();
                sb.Append("UPDATE `slbz`.`订单_生产单` SET " + updateStr + " WHERE `生产单号` IN( ");
                foreach (int ri in listRowIndex)
                {
                    sb.Append("'" + dgv["生产单号", ri].Value.ToString() + "',");
                }
                sb.Append("'0');");
            }
            if (MySqlDbHelper.ExecuteNonQuery(sb.ToString()) == 0)
            {
                My.ShowErrorMessage("提交数据错误!");
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowData();
        }





    }
}
