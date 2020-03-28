using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_RukuGaikuangAnRiqi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Search();
    }

    private void Search()
    {
        if (string.IsNullOrWhiteSpace(this.TextBoxDateS.Text))
        {
            this.TextBoxDateS.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.TextBoxDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        DataSet ds = MySqlDbHelper.ExecuteDataSet(string.Format("CALL `slbz`.`入库概况按日期`('{0}','{1}');"
            ,this.TextBoxDateS.Text.Trim(), this.TextBoxDateE.Text.Trim()));

        GridView1.DataSource = ds.Tables[0];
        GridView1.Caption = this.TextBoxDateS.Text.Trim() + "_入库概况";
        GridView1.DataBind();

        GridView2.DataSource = ds.Tables[1];
        GridView2.Caption = this.TextBoxDateS.Text.Trim() + "_入库明细";
        GridView2.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Search();
    }
}