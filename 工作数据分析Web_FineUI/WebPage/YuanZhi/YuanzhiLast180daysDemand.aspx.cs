using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.YuanZhi
{
    public partial class yuanzhiLast180daysDemand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            this.GridView1.Caption = "近180天白板纸需求汇总，平均每月需求"+
                OracleHelper.ExecuteScalar(MySqlDbHelper.ExecuteScalar(
                "SELECT `SQL语句`FROM `slbz`.`系统_易捷oracle语句`where 名称='原纸需求每月吨数'").ToString())
                +"吨白板纸。"
                ;
            this.GridView1.DataSource = OracleHelper.ExecuteDataTable(MySqlDbHelper.ExecuteScalar(
                "SELECT `SQL语句`FROM `slbz`.`系统_易捷oracle语句`where 名称='涂布白板纸需求汇总'").ToString());
            this.GridView1.DataBind();
            this.GridView2.Caption= "近180天白板纸需求明细";
            this.GridView2.DataSource = OracleHelper.ExecuteDataTable(MySqlDbHelper.ExecuteScalar(
                "SELECT `SQL语句`FROM `slbz`.`系统_易捷oracle语句`where 名称='涂布白板纸需求明细'").ToString());
            this.GridView2.DataBind();

           
        }
    }
}