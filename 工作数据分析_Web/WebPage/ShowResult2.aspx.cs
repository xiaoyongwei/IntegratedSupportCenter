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
                gridTitle2 = "甩纸确认近180天白板纸需求明细";
                break;
            case "20":
                sqlStr = "SELECT `仓库`,`日期`,`生产单号`	,`客户`,`名称`,`规格`,`坑型`,`入库数量`,`面积`,`单价`,`金额`,`操作人`"
	+",`审核人`,`入库单号`,`备注`FROM `slbz`.`成品_入库明细`"
+ "WHERE 日期 BETWEEN date_format(date_add(now(), interval -30 day), '%Y-%m-%d 00') and date_format(now(), '%Y-%m-%d 99')"
+ "and 入库单号 not like 'RA%' and 入库单号 not like 'RO%'AND 操作人 in (select 姓名 from slbz.二期入库名单)order by 日期 desc; ";
                gridTitle = "异常入库明细";
                sqlStr2 = "SELECT `仓库`,`生产单号`,`单据号`,`日期`,`客户`,`名称`,`规格`,`坑型`,`数量`,`单价`,`金额`,`操作`"
	+",`面积`,`交期`,`备注`FROM `slbz`.`成品_出库明细`"
+ "WHERE 日期 BETWEEN date_format(date_add(now(), interval -30 day), '%Y-%m-%d 00') and date_format(now(), '%Y-%m-%d 99')"
+ "and 单据号 not like 'XA%' AND 操作 in (select 姓名 from slbz.二期入库名单)order by 日期 desc; ";
                gridTitle2 = "异常出库明细";
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