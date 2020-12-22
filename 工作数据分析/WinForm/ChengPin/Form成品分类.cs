using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 工作数据分析.Data.DAL.Oracle;
using 工作数据分析.Properties;

namespace 工作数据分析.WinForm.ChengPin
{
    public partial class Form成品分类 : Form
    {
        public Form成品分类()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            dgvRukuMingxi.DataSource = OracleHelper.ExecuteDataTable(
                Resources.入库查询.Replace("*开始时间*", dateTimePickerS.Value.ToString("yyyy-MM-dd"))
                .Replace("*结束时间*", dateTimePickerS.Value.ToString("yyyy-MM-dd"))
                .Replace("like'%工单%'", "like'%" + textBoxGongdan.Text.ToUpper() + "%'")
                .Replace("like'%客户%'", "like'%" + textBoxKehuChanpin.Text.ToUpper() + "%'")
                .Replace("like'%产品%'", "like'%" + textBoxKehuChanpin.Text.ToUpper() + "%'"));
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
                    "(SELECT sum(v.ACCNUMT) from EJSH.V_HR_PIECE_DATA v WHERE v.SERIAL=t.serial AND " +
                    " v.PRCTYPNME=t.PRCTYPNME) as 报工数 FROM EJSH.V_ORD_SCH t WHERE " +
                    " t.SERIAL='" + gdh + "' ORDER  BY PID desc";
                dgvGongdan.DataSource = OracleHelper.ExecuteDataTable(SqlBaogong);
                dgvGongdan.AutoResizeColumns();

                string SqlRukuJilu = "select t.serial as 生产单号,to_char(t.ptdate, 'yyyy-mm-dd hh24:mi:ss') " +
                    " as 入库时间, t.pono as 入库单号, t.accnuml as 入库数, t.usrnme as 录入员 from " +
                    " v_pb_bcdr t where   t.orgcde = 'KS03' and t.SERIAL='" + gdh + "'";
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
            
        }
    }
}
