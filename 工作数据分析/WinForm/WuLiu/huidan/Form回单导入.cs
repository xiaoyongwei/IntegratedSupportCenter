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
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm
{
    public partial class Form回单导入 : Form
    {
        public Form回单导入()
        {
            InitializeComponent();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {           
            if ((dtpE.Value - dtpS.Value).Days > 30)
            {
                My.ShowErrorMessage("间隔时间不能超过30天");
                return;
            }
            else if (dtpE.Value < dtpS.Value)
            {
                My.ShowErrorMessage("开始日期不能大于结束日期");
                return;
            }
            string sqlTxt = Resources.获取送货单回单信息
                .Replace("@starttime", dtpS.Value.ToString("yyyy-MM-dd"))
                .Replace("@endtime", dtpE.Value.ToString("yyyy-MM-dd"));

            List<string> sqlList = new List<string>();
            DataTable dt = OracleHelper.ExecuteDataTable(CommandType.Text, sqlTxt, null);            


            StringBuilder sb_Insert = new StringBuilder("INSERT IGNORE  INTO `slbz`.`送货回单情况`(");
            foreach (DataColumn dc in dt.Columns)//添加列
            {
                sb_Insert.AppendFormat("`{0}`,", dc.ColumnName);
            }
            sb_Insert.Remove(sb_Insert.Length - 1, 1);
            sb_Insert.AppendLine(")VALUES");
            StringBuilder sb_values = new StringBuilder("(");
            foreach (DataRow dr in dt.Rows)
            {
                sb_values = new StringBuilder("(");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb_values.AppendFormat("'{0}',", dr[dc].ToString());
                }
                sb_values.Remove(sb_values.Length - 1, 1);
                sb_values.AppendLine(");");
                sqlList.Add(sb_Insert.ToString() + sb_values.ToString());
            }
            if (MySqlDbHelper.ExecuteSqlTran(sqlList))
            {
                this.textBoxShowResult.AppendText("导入成功" + Environment.NewLine);
                DialogResult = DialogResult.OK;
            }
            else
            {
                this.textBoxShowResult.AppendText("×××××导入成功×××××" + Environment.NewLine);
            }
        }

        private void Form回单导入_Load(object sender, EventArgs e)
        {
            this.dtpS.Value = DateTime.Now.AddDays(-2);
        }
    }
}
