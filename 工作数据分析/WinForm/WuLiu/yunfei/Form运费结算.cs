using excelToTable_NPOI;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
                + (this.comboBoxYfjs.Text == "已结算" ? " and PAYSTS='Y' " : (this.comboBoxYfjs.Text == "未结算" ? " and ( PAYSTS != 'Y' OR PAYSTS IS null )  " : ""))
                + (string.IsNullOrEmpty(this.textBoxSearch.Text) ? "" : string.Format(" and (DRIVER like '%{0}%'  OR PLNCDE like '%{0}%' OR PONO like '%{0}%') ", this.textBoxSearch.Text.Trim()))
                + " ORDER BY PTDATE desc";

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

        /// <summary>
        /// 返回选中的ID的列表字符串      类似   1,2,3,4    没有引号
        /// 
        /// </summary>
        /// <param name="IDList"></param>
        /// <returns></returns>
        private string GetSelectedAllIDString(List<string> IDList)
        {
            string idIn = "";
            foreach (string id in IDList)
            {
                idIn += (id + ",");
            }
           return idIn = idIn.TrimEnd(',');
        }

        private void SetErCiDuiMa(string ID)
        {
            string erciduima = "SELECT round((select nvl(sum(i.ratios * i.acreage * i.ACCNUMR),0) from v_bcdx_ct i where i.clientid = t.clientid and i.orgcde = t.orgcde"
          + " and i.PONO = t.pono)*0.011,2)  FROM FERP.DLV_FARE t WHERE ID = " + ID;

            string sql = "UPDATE FERP.DLV_FARE SET ANNAMT2 = NVL(ANNAMT2,0)+("
                + erciduima + ") ,USMARK = USMARK||'二次堆码+'||(" + erciduima + ")||',' WHERE PAYSTS='N' and (USMARK not like '%二次堆码%' OR USMARK IS null)and ID =" + ID;

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
            if (new Form计算运费弹窗(GetSelectedAllID(), 1800, 0).ShowDialog() == DialogResult.OK)
            { InitDgv(); }
        }

        private void 清零补运费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清空[补运费]吗?\n此操作无法撤销!", "清空?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string SQL = "UPDATE EJSH.DLV_FARE SET ANNAMT = 0 WHERE PAYSTS = 'N' and ID in (" + GetIdIn() + ")";
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


        private string GetIdIn()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string id in GetSelectedAllID())
            {
                sb.Append(id + ",");
            }
            return sb.Remove(sb.Length - 1, 1).ToString();
        }
        private void 清零运费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清空[运费]吗?\n此操作无法撤销!", "清空?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string SQL = "UPDATE EJSH.DLV_FARE SET ACCAMT = 0 WHERE PAYSTS = 'N' and ID in (" + GetIdIn() + ")";

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

        private void 平方运费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string SQL = "SELECT SUM((select nvl(sum(i.ratios * i.acreage * i.ACCNUMR), 0) from v_bcdx_ct i where i.clientid = t.clientid	" +
            " and i.orgcde = t.orgcde and i.PONO = t.pono)) as 运费面积 ,nvl(sum(ACCAMT), 0) as 运费,nvl(sum(ANNAMT), 0)AS 补运费" +
            "  , nvl(sum(ACCAMT) + sum(ANNAMT), 0) AS 合计运费 FROM EJSH.DLV_FARE t WHERE ID in (" + GetIdIn() + ")";

            OracleDataReader reader = OracleHelper.ExecuteReader(SQL);
            reader.Read();
            string mess = string.Format("运费面积:{0},运费:{1},补运费:{2},合计运费:{3},平方价:{4}",
                reader["运费面积"], reader["运费"], reader["补运费"], reader["合计运费"],
                Math.Round(Convert.ToDouble(reader["合计运费"]) / Convert.ToDouble(reader["运费面积"]), 2));
            My.ShowMessage(mess);
        }

        private void 导出数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".xls";
            save.FileName = "运费结算-" + this.dtpS.Value.ToString("yyyy-MM-dd") + "-" + this.dtpE.Value.ToString("yyyy-MM-dd") + "-"
                + this.comboBoxYfjs.Text + (string.IsNullOrEmpty(this.textBoxSearch.Text) ? "" : ("-" + this.textBoxSearch.Text));
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            save.Filter = "Excel(.xls)|*.xls";
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (new ExcelHelper(save.FileName).DataTableToExcel((DataTable)dgv.DataSource, "运费结算" + DateTime.Now.ToString("yyyyMMdd"), true) > 0)
                {
                    if (MessageBox.Show("保存成功!\n是否直接打开?", "打开?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(save.FileName);
                    }
                }
                else
                {
                    My.ShowErrorMessage("导出失败!");
                }

            }
        }

        private string GetCustomer(string id)
        {
            return OracleHelper.ExecuteScalar(
                "SELECT CLNTNME FROM  EJSH.DLV_FARE  WHERE id=" + id).ToString();
        }

        private void 为此客户设置地区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form为客户设置地区(GetCustomer(GetSelectedID())).ShowDialog();
        }

        private void 查看客户区域对应表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormShowData("客户区域对应表", "SELECT * FROM `slbz`.`客户对应区域运费表`").ShowDialog();
        }

        private void 自动计算运费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断是不是同一个司机
            if (OracleHelper.ExecuteDataTable("SELECT DRIVER  FROM EJSH.DLV_FARE WHERE  id in (" + GetIdIn()
                                               + ") GROUP BY DRIVER").Rows.Count > 1)
            {
                My.ShowErrorMessage("选择的数据里面包含了2个不同的司机!");
                return;
            }
            ////输入运费,计算运费
            //if (new Form计算运费弹窗(GetSelectedAllID(), 1800,
            //       Convert.ToDouble(MySqlDbHelper.ExecuteScalar("SELECT 小车 FROM `slbz`.`客户对应区域运费表`where 客户 ='" + kehu + "'"))
            //       ).ShowDialog() == DialogResult.OK)
            //{ InitDgv(); }



            ////判断客户是否都存在于可以自动计算的表格里 
            //foreach (string item in GetSelectedAllID())
            //{
            //    if (!MySqlDbHelper.ExecuteReader("SELECT 客户 FROM  `slbz`.`物流_客户地区对应表` WHERE 客户='" + GetCustomer(item) + "'").Read())
            //    {
            //        My.ShowErrorMessage("客户不在可以自动计算运费的清单里面!");
            //        return;
            //    }
            //}


            ////获取面积最大的客户
            //string SQL = "select 客户 from (select 客户 from(SELECT 客户,sum(运费面积)面积 FROM (SELECT CLNTNME 客户 "
            //    + ",(select nvl(sum(i.ratios * i.acreage * i.ACCNUMR), 0) from v_bcdx_ct i where i.clientid = t.clientid and i.orgcde = t.orgcde "
            //    + "  and i.PONO = t.pono) as 运费面积 "
            //    + "FROM EJSH.DLV_FARE t "
            //    + "WHERE id IN(" + GetIdIn() + "))a GROUP BY 客户)b order by b.面积 desc)c where rownum = 1 ";
            //string kehu = OracleHelper.ExecuteScalar(SQL).ToString();
            ////获取司机(根据司机来判断大车和小车)
            //string siji = OracleHelper.ExecuteScalar("SELECT DRIVER  FROM EJSH.DLV_FARE WHERE  id =" + GetSelectedID()).ToString();
            //if (siji == "董美枝" || siji == "周晓军.")//大车
            //{
            //    if (new Form计算运费弹窗(GetSelectedAllID(), 3000,
            //        Convert.ToDouble(MySqlDbHelper.ExecuteScalar("SELECT 大车 FROM `slbz`.`客户对应区域运费表`where 客户 ='" + kehu + "'"))
            //        ).ShowDialog() == DialogResult.OK)
            //    { InitDgv(); }
            //}
            //else//小车
            //{
            //    if (new Form计算运费弹窗(GetSelectedAllID(), 1800,
            //       Convert.ToDouble(MySqlDbHelper.ExecuteScalar("SELECT 小车 FROM `slbz`.`客户对应区域运费表`where 客户 ='" + kehu + "'"))
            //       ).ShowDialog() == DialogResult.OK)
            //    { InitDgv(); }
            //}
        }

        private void 文信1区2区拼车ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SetPinCheWenXin())
            {
                InitDgv();
            }
            else
            {
                My.ShowErrorMessage("设置文信拼车费失败!");
            }
        }

        /// <summary>
        /// 设置文信拼车费
        /// </summary>
        private bool SetPinCheWenXin()
        {
            string SQL = "UPDATE FERP.DLV_FARE  SET ANNAMT2 = NVL(ANNAMT2, 0) + 20  ,USMARK = USMARK || '文信12区拼车+20,'  "
                +"WHERE PAYSTS = 'N' AND(usmark NOT like '%拼车%' OR USMARK IS null)   and ID = "+ GetSelectedID();

            return OracleHelper.ExecuteNonQuery(SQL) > 0;
        }

        private void 导出PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ids = "";
            List<string> rowList = new List<string>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                string id = dgv["ID", cell.RowIndex].Value.ToString();
                if (!rowList.Contains(id))
                {
                    rowList.Add(id);
                    ids += (id + ",");
                }
            }
            if (!string.IsNullOrWhiteSpace(ids))
            {
                ids += "0";
            }

            if (new Form运费编辑(ids).ShowDialog() == DialogResult.OK)
            {
                InitDgv();
            }
        }

       
    }
}
