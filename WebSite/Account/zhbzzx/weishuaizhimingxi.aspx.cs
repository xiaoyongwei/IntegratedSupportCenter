using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Account_zhbzzx_weishuaizhimingxi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT*	FROM `slbz`.`未甩纸_原纸需求`");
        GridView1.DataBind();
        GridView2.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT *FROM `slbz`.`未甩纸_原纸需求_汇总`");
        GridView2.DataBind();
    }
}