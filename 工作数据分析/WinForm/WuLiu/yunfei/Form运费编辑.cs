using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 工作数据分析.Data.DAL.Oracle;
using 工作数据分析.Properties;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm.WuLiu.yunfei
{
    public partial class Form运费编辑 : Form
    {
        private string IDS = "";
        public Form运费编辑(string ids)
        {
            this.IDS = ids;
            InitializeComponent();
        }

        private void Form运费编辑_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IDS))
            {
                My.ShowErrorMessage("数据为空!");
                return;
            }
            if (dgv.Rows.Count>10)
            {
                My.ShowErrorMessage("数据太多了,不能超过10条!");
                return;
            }
            this.dgv.DataSource = OracleHelper.ExecuteDataTable(
                Resources.运费结算
                +" and id in("+IDS+")");
            dgv.AutoResizeColumns();
            this.WindowState = FormWindowState.Maximized;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgv.EndEdit();

            string updateString =
            "UPDATE FERP.DLV_FARE SET ACCAMT ={0},ANNAMT ={1},ANNAMT2 ={2}," +
            "ANNAMT3 ={3},CNTAMT={4},BASAMT={5},USMARK ='{6}'	WHERE ID={7} ";
            List<string> sqlList = new List<string>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                sqlList.Add(
                   string.Format(updateString
                  , GetCellValueYunfeiInt(row.Cells["运费"])
                  , GetCellValueYunfeiInt(row.Cells["ANNAMT"])
                  , GetCellValueYunfeiInt(row.Cells["补运费"])
                   , GetCellValueYunfeiInt(row.Cells["ANNAMT3"])
                   , GetCellValueYunfeiInt(row.Cells["CNTAMT"])
                   , GetCellValueYunfeiInt(row.Cells["保底运费"])
                   , GetCellValueYunfeiStr(row.Cells["备注"])
                   , row.Cells["ID"].Value.ToString()
                   
                    ));
            }
            if(OracleHelper.ExecuteSqlTran(sqlList))
            {
                My.ShowMessage("保存成功!");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                My.ShowErrorMessage("保存失败!!");
                this.DialogResult = DialogResult.None;
            }
        }


        private string GetCellValueYunfeiStr(DataGridViewCell cell)
        {
            return cell.Value == null
                   || string.IsNullOrWhiteSpace(cell.Value.ToString())
                   ? "" : cell.Value.ToString();
        }

        private string GetCellValueYunfeiInt(DataGridViewCell cell)
        {
            return cell.Value == null
                   || string.IsNullOrWhiteSpace(cell.Value.ToString())
                   ? "null" : cell.Value.ToString();
        }
    }
}
