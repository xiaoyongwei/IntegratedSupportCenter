using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 工作数据分析.Data.DAL.Oracle;
using 工作数据分析.Properties;
using 工作数据分析.WinForm.WuLiu.yunfei;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm.WuLiu
{
    public partial class Form运费结算 : Form
    {
        public Form运费结算()
        {
            InitializeComponent();
        }

        private void Form运费结算_Load(object sender, EventArgs e)
        {

            ////关闭多余的窗体
            //foreach (Form f in this.ParentForm.MdiChildren)
            //{
            //    if (f.Name == this.Name && f.Handle != this.Handle)
            //    {
            //        f.Dispose();
            //    }
            //}

            this.comboBoxYfjs.SelectedIndex = 0;
            this.dtpS.Value = DateTime.Now.AddDays(-7);
            InitDgv();
        }

        private void InitDgv()
        {
            if ((dtpE.Value - dtpS.Value).Days > 90)
            {
                My.ShowErrorMessage("间隔时间不能超过90天");
                return;
            }
            else if (dtpE.Value < dtpS.Value)
            {
                My.ShowErrorMessage("开始日期不能大于结束日期");
                return;
            }

            string SQL = Resources.运费结算 + " and to_char(ptdate, 'yyyy-mm-dd') >='" + dtpS.Value.ToString("yyyy-MM-dd")
                + "' and to_char(ptdate, 'yyyy-mm-dd') <='" + dtpE.Value.ToString("yyyy-MM-dd") + "'"
                + (this.comboBoxYfjs.Text == "已结算" ? " and PAYSTS='Y' " : (this.comboBoxYfjs.Text == "未结算" ? " and PAYSTS = 'N' " : ""))
                + (string.IsNullOrEmpty(this.textBoxSearch.Text) ? "" : string.Format(" and (DRIVER like '%{0}%' OR CLNTNME like '%{0}%' OR PLNCDE like '%{0}%' OR PONO like '%{0}%') ", this.textBoxSearch.Text.Trim()))
                + " ORDER BY CREATED desc";

            dgv.DataSource = OracleHelper.ExecuteDataTable(SQL);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            InitDgv();
        }

        private void 二次堆码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetErCiDuiMa(GetSelectedID());
        }

        private string GetSelectedID()
        {
            return dgv.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
        }
        private List<string> GetSelectedAllID()
        {
            List<string> ponoList = new List<string>();
            foreach (DataGridViewCell item in dgv.SelectedCells)
            {
                ponoList.Add(item.OwningRow.Cells["ID"].Value.ToString());
            }
            return ponoList;
        }

        private void SetErCiDuiMa(string ID)
        {
            string erciduima = "SELECT round((select nvl(sum(i.ratios * i.acreage * i.ACCNUMR),0) from v_bcdx_ct i where i.clientid = t.clientid and i.orgcde = t.orgcde"
          + " and i.PONO = t.pono)*0.011,2)  FROM EJSH.DLV_FARE t WHERE ID = " + ID;

            string sql = "UPDATE \"EJSH\".\"DLV_FARE\" SET \"ANNAMT\" = NVL(\"ANNAMT\",0)+("
                + erciduima + ") ,\"USMARK\" = \"USMARK\"||'二次堆码+'||(" + erciduima + ")||',' WHERE PAYSTS='N' and (USMARK not like '%二次堆码%' OR USMARK IS null)and \"ID\" =" + ID;

            if (
            OracleHelper.ExecuteNonQuery(sql) > 0)
            {
                InitDgv();
            }
        }

        private void 拼车距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new Form拼车距离弹窗(GetSelectedID()).ShowDialog() == DialogResult.OK)
            { InitDgv(); }
        }

        private void 计算运费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new Form计算运费弹窗(GetSelectedAllID()).ShowDialog() == DialogResult.OK)
            { InitDgv(); }
        }

        private void 清零补运费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清空[补运费]吗?\n此操作无法撤销!", "清空?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string idIn = "";
                foreach (string id in GetSelectedAllID())
                {
                    idIn += (id + ",");
                }
                idIn = idIn.TrimEnd(',');

                string SQL = "UPDATE EJSH.DLV_FARE SET ANNAMT = 0 WHERE PAYSTS = 'N' and ID in (" + idIn + ")";
                if (OracleHelper.ExecuteNonQuery(SQL) == 0)
                {
                    My.ShowErrorMessage("修改失败!!!");
                }
                else
                {
                    InitDgv();
                }
            }

        }

        private void 清零运费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清空[运费]吗?\n此操作无法撤销!", "清空?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string idIn = "";
                foreach (string id in GetSelectedAllID())
                {
                    idIn += (id + ",");
                }
                idIn = idIn.TrimEnd(',');

                string SQL = "UPDATE EJSH.DLV_FARE SET ACCAMT = 0 WHERE PAYSTS = 'N' and ID in (" + idIn + ")";

                if (OracleHelper.ExecuteNonQuery(SQL) == 0)
                {
                    My.ShowErrorMessage("修改失败!!!");
                }
                else
                {
                    InitDgv();
                }
            }
        }
    }
}
