using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_Weiwangong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT `生产单号`,`客户`,`产品`	FROM `slbz`.`订单_生产单` LIMIT 10");
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //string a = "<a href='addcolumn.aspx?deleteid=" + drone["id"].ToString() + "' onclick='return confirm(\"确定要删除『" + drone["name"].ToString() + "』栏目?\")' title='删除'>删除</a>";
        //Response.Write("<script> var r=confirm('是否确定删除？');</script>");

    }
}