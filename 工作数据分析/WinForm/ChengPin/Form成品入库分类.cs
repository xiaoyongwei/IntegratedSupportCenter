using excelToTable_NPOI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 工作数据分析.Data.DAL.Oracle;
using 工作数据分析.Properties;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm.ChengPin
{
    public partial class Form成品入库分类 : Form
    {
        public Form成品入库分类()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
            dgvGongdan.DataSource = null;
            dgvRukuJilu.DataSource = null;
        }

        private void Search()
        {
            DataGridViewColumn sortColumn = dgvRukuMingxi.SortedColumn;
            SortOrder orderSort = dgvRukuMingxi.SortOrder;

            if (dateTimePickerE.Value.AddDays(-40)>dateTimePickerS.Value)
            {
                My.ShowErrorMessage("查询时间不能超过40天");
                return;
            }

            //绑定数据
            dgvRukuMingxi.DataSource = OracleHelper.ExecuteDataTable(
                Resources.入库查询.Replace("*开始时间*", dateTimePickerS.Value.ToString("yyyy-MM-dd"))
                .Replace("*结束时间*", dateTimePickerE.Value.ToString("yyyy-MM-dd"))
                .Replace("like'%工单%'", "like'%" + textBoxGongdan.Text.ToUpper() + "%'")
                .Replace("like'%客户%'", "like'%" + textBoxKehuChanpin.Text.ToUpper() + "%'")
                .Replace("like'%产品%'", "like'%" + textBoxKehuChanpin.Text.ToUpper() + "%'"));
            //获取DataGridView中的入库单号集合
            StringBuilder sb = new StringBuilder("SELECT *FROM `slbz`.`成品_入库类型明细`where `入库单号`in(");            
            foreach (DataGridViewRow row in dgvRukuMingxi.Rows)
            {
                sb.Append("'"+row.Cells["入库单号"].Value.ToString() + "',");
            }
            sb.Append("'')");
            DataTable dt = MySqlDbHelper.ExecuteDataTable(sb.ToString());
            //显示入库类型
            foreach (DataGridViewRow row in dgvRukuMingxi.Rows)
            {
                DataRow[] rows= dt.Select(string.Format(
                    "入库单号='{0}' AND 生产单号='{1}'",
                    row.Cells["入库单号"].Value.ToString(),
                    row.Cells["生产单号"].Value.ToString()));
                if (rows.Length==0)
                {
                    continue;
                }
                row.Cells["入库类型"].Value = rows[0]["入库类型"].ToString();

                //row.Cells["入库类型"].Value =
                //    MySqlDbHelper.ExecuteScalar(string.Format("SELECT `入库类型`FROM `slbz`.`成品_入库类型明细` " +
                //    "WHERE`入库单号`='{0}' AND `生产单号`='{1}'",
                //    row.Cells["入库单号"].Value.ToString(),
                //    row.Cells["生产单号"].Value.ToString()));
            }

            if (sortColumn!=null)
            {
                foreach (DataGridViewColumn column in dgvRukuMingxi.Columns)
                {
                    if (column.Name==sortColumn.Name)
                    {
                        dgvRukuMingxi.Sort(column,
                (orderSort == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending));
                    }
                }
                
            }
            
            dgvRukuMingxi.AutoResizeColumns();
            
        }

        private void dgvRukuMingxi_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowRukuMingxi(dgvRukuMingxi["生产单号", e.RowIndex].Value.ToString());
        }

        private void ShowRukuMingxi(string gdh)
        {
            gdh = gdh.ToUpper();
            if (string.IsNullOrWhiteSpace(gdh))
            {
                //dgvGongdan.DataSource = null;
                //dgvRukuJilu.DataSource = null;
            }
            else
            {
                string SqlBaogong = "SELECT t.SERIAL 生产单号,t.PRCTYPNME 工序大类,t.PRCNME 工序,t.ACCNUM 数量," +
                    "(SELECT sum(v.ACCNUMT) from EJSH.V_HR_PIECE_DATA v WHERE v.orgcde = 'KS03' and v.SERIAL=t.serial " +
                    " AND  v.PRCTYPNME=t.PRCTYPNME) as 报工数," +
                    "(SELECT to_char(wm_concat(distinct vv.USRNME||' ')) from EJSH.V_HR_PIECE_DATA vv WHERE " +
                    "vv.orgcde = 'KS03' and vv.SERIAL=t.serial AND  vv.PRCTYPNME=t.PRCTYPNME) as 报工人, " +
                    "(select max(v1.PTDATE)  from EJSH.V_HR_PIECE_DATA v1 WHERE v1.orgcde = 'KS03'  " +
                    "and v1.SERIAL = t.serial  AND v1.PRCTYPNME = t.PRCTYPNME)  最后报工时间"+
                    " FROM EJSH.V_ORD_SCH t WHERE t.orgcde = 'KS03' and t.SERIAL='"
                    + gdh + "' ORDER  BY PID desc";
                dgvGongdan.DataSource = OracleHelper.ExecuteDataTable(SqlBaogong);
                dgvGongdan.AutoResizeColumns();

                string SqlRukuJilu = "select t.serial as 生产单号,to_char(t.ptdate, 'yyyy-mm-dd hh24:mi:ss') " +
                    " as 入库时间, t.pono as 入库单号, t.accnuml as 入库数, t.usrnme as 录入员 from " +
                    " v_pb_bcdr t where t.objtyp in ('CL','CB','CT','CD') and  t.orgcde = 'KS03' and t.SERIAL='" + 
                    gdh + "' order by t.ptdate";
                dgvRukuJilu.DataSource = OracleHelper.ExecuteDataTable(SqlRukuJilu);
                dgvRukuJilu.AutoResizeColumns();
            }
        }

        private void dgvRukuMingxi_SelectionChanged(object sender, EventArgs e)
        {
            ShowRukuMingxi("");
        }

        private void 选择入库类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetRukuLeixing(dgvRukuMingxi);
        }

        private string GetRukuLeixing()
        {
            Form选择入库类型 Rklx = new Form选择入库类型();
            if (Rklx.ShowDialog()==DialogResult.OK)
            {
                return Rklx.RukuLeixing;
            }
            else
            {
                return " ";
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetRukuLeixing(dgvRukuJilu);
        }

        private void SetRukuLeixing(DataGridView dgv)
        {
            string rukuleixing = GetRukuLeixing();
            if (string.IsNullOrWhiteSpace(rukuleixing))
            {
                return;
            }

            //insert into table (player_id,award_type,num)  values(20001,0,1) on  DUPLICATE key update num=num+values(num)

            List<string> SQList = new List<string>();
            List<int> RowIndexList = new List<int>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                if (RowIndexList.Contains(cell.RowIndex))
                {
                    continue;
                }
                else
                {
                    RowIndexList.Add(cell.RowIndex);
                }
            }

            foreach (int rowIndex in RowIndexList)
            {
                SQList.Add(string.Format(
                    "INSERT INTO `slbz`.`成品_入库类型明细`(`入库类型`,`入库单号`,`生产单号`,`修改时间`)" +
                    "VALUES('{0}','{1}','{2}','{3}') on  DUPLICATE key update `入库类型`='{0}';"
                    , rukuleixing, dgv["入库单号", rowIndex].Value.ToString(),
                    dgv["生产单号", rowIndex].Value.ToString(),
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            if (MySqlDbHelper.ExecuteSqlTran(SQList))
            {
                Search();
            }
            else
            {
                My.ShowErrorMessage("修改[入库类型]失败!");
            }
        }

        private void 导出明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".xls";
            save.FileName = "导出的入库明细" + "_" + this.dateTimePickerS.Text
                            + "to" + this.dateTimePickerE.Text;
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            save.Filter = "Excel(.xls)|*.xls";
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (new ExcelHelper(save.FileName).DataGridViewToExcel(dgvRukuMingxi, "入库明细") > 1)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.dateTimePickerE.Value = DateTime.Now;
            this.dateTimePickerS.Value = DateTime.Now;
            this.textBoxGongdan.Text = string.Empty;
            this.textBoxKehuChanpin.Text = string.Empty;
            Search();
        }

        private void Form成品入库分类_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
        }

        private void 总入库数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (DataGridViewRow item in dgvRukuJilu.Rows)
            {
                sum += (Convert.ToInt32(item.Cells["入库数"].Value));
            }
            MessageBox.Show("总入库数: " + sum, "总入库数");
        }
    }
}
