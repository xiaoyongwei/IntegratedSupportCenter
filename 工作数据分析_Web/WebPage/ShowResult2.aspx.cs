using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_ShowResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request.QueryString["sqlcode"].ToString().Trim();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataSet ds = new DataSet();
        switch (code)
        {
            case "5":
                dt1 = GetSqlTxt_Datatable("未甩纸明细");
                dt1.TableName = "未甩纸明细";
                dt2 = GetSqlTxt_Datatable("未甩纸总结");
                dt2.TableName = "未甩纸原纸需求";
                break;
            case "6":
                dt1 = GetSqlTxt_Datatable("未覆膜明细");
                dt1.TableName = "未覆膜明细";
                dt2 = GetSqlTxt_Datatable("未覆膜总结");
                dt2.TableName = "未覆膜需求";
                break;
            case "17":
                dt1 = MySqlDbHelper.ExecuteDataTable("SELECT *FROM `slbz`.`甩纸确认近180天原纸需求汇总`;");
                dt1.TableName = "甩纸确认近180天白板纸需求汇总_月均白板纸需求 "
                    + MySqlDbHelper.ExecuteScalar(
                    "select sum(每月卷数*原纸门幅*0.001)FROM `slbz`.`甩纸确认近180天原纸需求汇总`;").ToString() + "吨";
                dt2 = MySqlDbHelper.ExecuteDataTable("SELECT *FROM `slbz`.`甩纸确认近180天原纸需求`");
                dt2.TableName = "甩纸确认近180天白板纸需求明细";
                break;
            case "20":
                 ds = MySqlDbHelper.ExecuteDataSet("CALL `slbz`.`出入库异常记录`();");
                dt1 = ds.Tables[0];
                dt1.TableName = "异常入库明细";
                dt2 = ds.Tables[1];
                dt2.TableName = "异常出库明细";
                break;
            case "21":
                 ds = MySqlDbHelper.ExecuteDataSet(string.Format("CALL `slbz`.`二期业务员交货超期`('{0}')",DateTime.Now.ToString("yyyy-MM-dd")));
                dt1 = ds.Tables[0];
                dt1.TableName = "二期业务员交货超期明细";
                dt2 = ds.Tables[1];
                dt2.TableName = "二期业务员交货超期汇总";
                break;
            default:
                break;
        }
        this.GridView1.Caption = dt1.TableName;
        this.GridView2.Caption = dt2.TableName;
        this.GridView1.DataSource = dt1;
        this.GridView1.DataBind();
        this.GridView2.DataSource = dt2;
        this.GridView2.DataBind();
    }

    protected DataTable GetSqlTxt_Datatable(string txtFileName)
    {
        return OracleHelper.ExecuteDataTable(CommandType.Text,
        new StreamReader(
                new FileStream(
                  Server.MapPath("~\\sqltxt\\" + txtFileName + ".txt"),
                    FileMode.Open, FileAccess.Read, FileShare.Read)).ReadToEnd(), null);
    }


}