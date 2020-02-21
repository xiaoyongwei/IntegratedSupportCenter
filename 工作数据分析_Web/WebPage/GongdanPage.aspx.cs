using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_GongdanPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //整单完工
    protected void Button1_Click(object sender, EventArgs e)
    {
        string gdh = Request.QueryString.Count > 0 ? Request.QueryString["gdh"].ToString().Trim() : "";
        if (MySqlDbHelper.ExecuteSqlTran(
            "UPDATE `slbz`.`订单_生产单`	SET `完工` = 1 	WHERE `生产单号`='"+gdh+"';"))
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
    //取消整单完工
    protected void Button2_Click(object sender, EventArgs e)
    {
        string gdh = Request.QueryString.Count > 0 ? Request.QueryString["gdh"].ToString().Trim() : "";
        if (MySqlDbHelper.ExecuteSqlTran(
            "UPDATE `slbz`.`订单_生产单`	SET `完工` = 0 	WHERE `生产单号`='" + gdh + "';"))
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
}