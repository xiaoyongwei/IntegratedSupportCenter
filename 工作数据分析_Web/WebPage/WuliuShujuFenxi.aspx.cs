using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WebPage_WuliuShujuFenxi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    private void Search()
    {
        DataSet ds = MySqlDbHelper.ExecuteDataSet(string.Format(
            "CALL `slbz`.`物流数据分析`('{0}','{1}');"
            ,this.Calendar1.SelectedDate.ToString("yyyy-MM-dd")
            ,this.Calendar2.SelectedDate.ToString("yyyy-MM-dd")));
        GridView1.Caption = "物流数据汇总";
        GridView2.Caption = "物流数据明细";
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        GridView2.DataSource = ds.Tables[1];
        GridView2.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Search();
    }
}