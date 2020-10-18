using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{



    protected void Page_Load(object sender, EventArgs e)
    {
            this.Label1.Text = "易捷:" + MySqlDbHelper.ExecuteScalar("SELECT `Value`	FROM `slbz`.`settingall`	where `Key`='LastGetTime'").ToString()
                + " , 金蝶:" + MySqlDbHelper.ExecuteScalar(
                "select max(日期) from(SELECT max(`日期`)'日期'FROM `slbz`.`金蝶_生产领料` union all SELECT max(`日期`)FROM `slbz`.`金蝶_外购入库` )aa").ToString()
                + " , 制版线:" + MySqlDbHelper.ExecuteScalar("SELECT max(`结束时间`)FROM `slbz`.`瓦片完成情况`").ToString();
            Response.Write("<script language=javascript>self.resizeTo(3000,300)</script>");        
    }


    protected void NavigationMenu_Init(object sender, EventArgs e)
    {
        if (Session["username"] == null || string.IsNullOrWhiteSpace(Session["username"].ToString()))

        {
            Response.Redirect("~/Login.aspx");
        }
    }
}
