using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using excelToTable_NPOI;
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
            //if ((dtpE.Value - dtpS.Value).Days > 30)
            //{
            //    My.ShowErrorMessage("间隔时间不能超过30天");
            //    return;
            //}
            //else if (dtpE.Value < dtpS.Value)
            //{
            //    My.ShowErrorMessage("开始日期不能大于结束日期");
            //    return;
            //}
            //string sqlTxt = Resources.获取送货单回单信息
            //    .Replace("@starttime", dtpS.Value.ToString("yyyy-MM-dd"))
            //    .Replace("@endtime", dtpE.Value.ToString("yyyy-MM-dd"));

            //List<string> sqlList = new List<string>();
            //DataTable dt = OracleHelper.ExecuteDataTable(CommandType.Text, sqlTxt, null);

            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                DataTable dt = new ExcelHelper(openFile.FileName).ExcelToDataTable("",true,true);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("送货日期", typeof(string));
                dt1.Columns.Add("送货单号", typeof(string));
                dt1.Columns.Add("客户简称", typeof(string));
                dt1.Columns.Add("业务员", typeof(string));
                dt1.Columns.Add("司机", typeof(string));
                dt1.Columns.Add("操作人", typeof(string));
                dt1.Columns.Add("金额", typeof(System.Decimal));

                string[] caozuoren =  { "肖永卫","颜玲敏", "应燕华", "刘正利", "董小浩","叶耀红" };

                foreach (DataRow row1 in dt.Rows)
                {
                    if (caozuoren.Contains(row1["开单员"].ToString()))
                    {
                        DataRow dr = dt1.NewRow();
                        dr["送货日期"] = row1["送货时间"];
                        dr["送货单号"] = row1["送货单号"];
                        dr["客户简称"] = row1["客户"];
                        dr["业务员"] = row1["业务员"];
                        dr["司机"] = row1["司机"];
                        dr["操作人"] = row1["开单员"];
                        dr["金额"] = row1["金额"];
                        dt1.Rows.Add(dr);
                    }
                }

                if (dt1.Rows.Count>0)
                {
                    DataTable dtGroupBy = dt1.AsEnumerable().GroupBy(r => new
                    {
                        送货日期 = r["送货日期"],
                        送货单号 = r["送货单号"],
                        客户简称 = r["客户简称"],
                        业务员 = r["业务员"],
                        司机 = r["司机"],
                        操作人 = r["操作人"]


                    }
               ).Select(
                  g => {
                      var row = dt1.NewRow();

                      row["送货日期"] = g.Key.送货日期;
                      row["送货单号"] = g.Key.送货单号;
                      row["客户简称"] = g.Key.客户简称;
                      row["业务员"] = g.Key.业务员;
                      row["司机"] = g.Key.司机;
                      row["操作人"] = g.Key.操作人;
                      row["金额"] = g.Sum(r => (decimal)r["金额"]);
                      return row;
                  }).CopyToDataTable();





                    //****************************

                    List<string> sqlList = new List<string>();
                    
                    StringBuilder sb_Insert = new StringBuilder("INSERT IGNORE  INTO `slbz`.`送货回单情况`(");
                    foreach (DataColumn dc in dtGroupBy.Columns)//添加列
                    {
                        sb_Insert.AppendFormat("`{0}`,", dc.ColumnName);
                    }
                    sb_Insert.Remove(sb_Insert.Length - 1, 1);
                    sb_Insert.AppendLine(")VALUES");
                    StringBuilder sb_values = new StringBuilder("(");
                    foreach (DataRow dr in dtGroupBy.Rows)
                    {
                        sb_values = new StringBuilder("(");
                        foreach (DataColumn dc in dtGroupBy.Columns)
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

            }




        }

        //从易捷数据库Oracle中导入
        //private void buttonImport_Click(object sender, EventArgs e)
        //{
        //    if ((dtpE.Value - dtpS.Value).Days > 30)
        //    {
        //        My.ShowErrorMessage("间隔时间不能超过30天");
        //        return;
        //    }
        //    else if (dtpE.Value < dtpS.Value)
        //    {
        //        My.ShowErrorMessage("开始日期不能大于结束日期");
        //        return;
        //    }
        //    string sqlTxt = Resources.获取送货单回单信息
        //        .Replace("@starttime", dtpS.Value.ToString("yyyy-MM-dd"))
        //        .Replace("@endtime", dtpE.Value.ToString("yyyy-MM-dd"));

        //    List<string> sqlList = new List<string>();
        //    DataTable dt = OracleHelper.ExecuteDataTable(CommandType.Text, sqlTxt, null);


        //    StringBuilder sb_Insert = new StringBuilder("INSERT IGNORE  INTO `slbz`.`送货回单情况`(");
        //    foreach (DataColumn dc in dt.Columns)//添加列
        //    {
        //        sb_Insert.AppendFormat("`{0}`,", dc.ColumnName);
        //    }
        //    sb_Insert.Remove(sb_Insert.Length - 1, 1);
        //    sb_Insert.AppendLine(")VALUES");
        //    StringBuilder sb_values = new StringBuilder("(");
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        sb_values = new StringBuilder("(");
        //        foreach (DataColumn dc in dt.Columns)
        //        {
        //            sb_values.AppendFormat("'{0}',", dr[dc].ToString());
        //        }
        //        sb_values.Remove(sb_values.Length - 1, 1);
        //        sb_values.AppendLine(");");
        //        sqlList.Add(sb_Insert.ToString() + sb_values.ToString());
        //    }
        //    if (MySqlDbHelper.ExecuteSqlTran(sqlList))
        //    {
        //        this.textBoxShowResult.AppendText("导入成功" + Environment.NewLine);
        //        DialogResult = DialogResult.OK;
        //    }
        //    else
        //    {
        //        this.textBoxShowResult.AppendText("×××××导入成功×××××" + Environment.NewLine);
        //    }
        //}
        private void Form回单导入_Load(object sender, EventArgs e)
        {
            this.dtpS.Value = DateTime.Now.AddDays(-2);
        }
    }
}
