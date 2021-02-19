using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.Chengpin
{
    public partial class ChengpinRukuAnRiqi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

            }
            else
            {
                this.TextBoxDateS.Text = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");
                this.TextBoxDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            Search();
        }

        private void Search()
        {
            string sqlTemplate = My.GetSqlTxt("入库明细2");


            if (string.IsNullOrWhiteSpace(this.TextBoxDateS.Text))
            {
                this.TextBoxDateS.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.TextBoxDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            sqlTemplate = sqlTemplate.Replace("*开始时间*", TextBoxDateS.Text).Replace("*结束时间*", TextBoxDateE.Text);


            GridView1.DataSource = OracleHelper.ExecuteDataTable(
                "select nvl(a.入库类型,'总计:')总计,sum(a.总面积)面积,sum(a.金额)金额 from(" + sqlTemplate
                + ")a group by rollup( a.入库类型)");
            GridView1.Caption = this.TextBoxDateS.Text + "到" + this.TextBoxDateE.Text + "_入库概况";
            GridView1.DataBind();

            GridView2.DataSource = OracleHelper.ExecuteDataTable(sqlTemplate);
            GridView2.Caption = this.TextBoxDateS.Text + "到" + this.TextBoxDateE.Text + "_入库明细";
            GridView2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}