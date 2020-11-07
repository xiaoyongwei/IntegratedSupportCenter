using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_FahuoGaikuangAnRiqi : System.Web.UI.Page
{
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
        string sqlTemplate = new StreamReader(
                new FileStream(
                  Server.MapPath("~\\sqltxt\\发货明细.txt"),
                    FileMode.Open, FileAccess.Read, FileShare.Read)).ReadToEnd();


        if (string.IsNullOrWhiteSpace(this.TextBoxDateS.Text))
        {
            this.TextBoxDateS.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.TextBoxDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        sqlTemplate=sqlTemplate.Replace("*开始时间*", TextBoxDateS.Text).Replace("*结束时间*", TextBoxDateE.Text);


        GridView1.DataSource = OracleHelper.ExecuteDataTable(
            "select aa.送货类型,sum(aa.箱片面积)送货面积 from(" + sqlTemplate
            + ")aa where aa.业务归属='二期' group by rollup(aa.送货类型)");
        GridView1.Caption = this.TextBoxDateS.Text+"到"+ this.TextBoxDateE.Text + "_" +
            "销售12部发货统计";
        GridView1.DataBind();

        GridView2.DataSource = OracleHelper.ExecuteDataTable(sqlTemplate);
        GridView2.Caption = this.TextBoxDateS.Text + "到" + this.TextBoxDateE.Text + "_发货明细";
        GridView2.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Search();
    }
}