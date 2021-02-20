using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.Chengpin
{
    public partial class ChengpinFahuoAnRiqi : System.Web.UI.Page
    {
        private DataTable dt_huizong = new DataTable();
        private DataTable dt_mingxi = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

            }
            else
            {
                this.TextBoxDateS.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                this.TextBoxDateE.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            }

            Search();
        }

        private void Search()
        {
            string sqlTemplate = My.GetSqlTxt("发货明细");


            if (string.IsNullOrWhiteSpace(this.TextBoxDateS.Text))
            {
                this.TextBoxDateS.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.TextBoxDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            sqlTemplate = sqlTemplate.Replace("*开始时间*", TextBoxDateS.Text).Replace("*结束时间*", TextBoxDateE.Text);

            GridView1.Caption = this.TextBoxDateS.Text + "到" + this.TextBoxDateE.Text + "_" +
                "发货统计";
            dt_huizong =
             OracleHelper.ExecuteDataTable(
                "SELECT aa.业务归属,aa.送货类型,sum(箱片面积)送货面积,sum(金额)金额  from (" + sqlTemplate
                + ")aa  GROUP BY aa.业务归属,aa.送货类型 ORDER BY aa.业务归属,aa.送货类型");
            DataRow newRow = dt_huizong.NewRow();
            newRow["业务归属"] = "合计:";
            newRow["送货类型"] = "";
            newRow["送货面积"] = dt_huizong.Compute("Sum(送货面积)", "1=1");
            newRow["金额"] = dt_huizong.Compute("Sum(金额)", "1=1");
            dt_huizong.Rows.Add(newRow);
            GridView1.DataSource = dt_huizong;
            GridView1.DataBind();
            dt_huizong.TableName = "发货汇总";

            dt_mingxi = OracleHelper.ExecuteDataTable(sqlTemplate);
            GridView2.DataSource = dt_mingxi;
            GridView2.Caption = this.TextBoxDateS.Text + "到" + this.TextBoxDateE.Text + "_发货明细";
            GridView2.DataBind();
            dt_mingxi.TableName = "发货明细";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            My.DownloadExcel(Response, GridView1, "发货概况");
            My.DownloadExcel(Response, GridView2, "发货明细");
        }
    }
}