using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WebPage_Kaidan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Search();
    }

    private void Search()
    {
        DataSet ds = MySqlDbHelper.ExecuteDataSet(string.Format(
           "CALL `slbz`.`开单情况`('{0}','{1}');"
           , this.Calendar1.SelectedDate.ToString("yy/MM/dd")
           , this.Calendar2.SelectedDate.ToString("yy/MM/dd")));
        GridView1.Caption = "开单数据汇总" 
            + this.Calendar1.SelectedDate.ToString("(yyyy-MM-dd到")
            + this.Calendar2.SelectedDate.ToString("yyyy-MM-dd)");
        GridView2.Caption = "开单数据明细";
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        GridView2.DataSource = ds.Tables[1];
        GridView2.DataBind();
    }
}