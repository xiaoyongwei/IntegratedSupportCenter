using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_ShowResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request.QueryString["sqlcode"].ToString().Trim();
        string sqlStr = "";
        string gridTitle = "";
        string sqlStr2 = "";
        string gridTitle2 = "";
        switch (code)
        {
            case "5":
                sqlStr = "SELECT*	FROM `slbz`.`未甩纸_原纸需求`";
                gridTitle = "未甩纸明细";
                sqlStr2 = "SELECT *FROM `slbz`.`未甩纸_原纸需求_纸类uv合并_汇总`";
                gridTitle2 = "未甩纸原纸需求";
                break;
            case "6":
                sqlStr = "SELECT*	FROM `slbz`.`未覆膜_门幅米数`";
                gridTitle = "未覆膜明细";
                sqlStr2 = "SELECT *FROM `slbz`.`未覆膜_预涂膜需求`";
                gridTitle2 = "未覆膜需求";
                break;
            case "17":
                sqlStr = "SELECT *FROM `slbz`.`甩纸确认近180天原纸需求汇总`;";
                gridTitle = "甩纸确认近180天白板纸需求汇总_月均白板纸需求"
                    +MySqlDbHelper.ExecuteScalar(
                    "select sum(每月卷数*原纸门幅*0.001)FROM `slbz`.`甩纸确认近180天原纸需求汇总`;").ToString();
                sqlStr2 = "SELECT *FROM `slbz`.`甩纸确认近180天原纸需求`";
                gridTitle2 = "甩纸确认近180天白板纸需求明细`";
                break;
            default:
                break;
        }
        this.GridView1.Caption = gridTitle;
        this.GridView2.Caption = gridTitle2;
        if (!string.IsNullOrWhiteSpace(sqlStr))
        {
            this.GridView1.DataSource = MySqlDbHelper.ExecuteDataTable(sqlStr);
            this.GridView1.DataBind(); 
            this.GridView2.DataSource = MySqlDbHelper.ExecuteDataTable(sqlStr2);
            this.GridView2.DataBind(); 
        }
    }



}