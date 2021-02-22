using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.WebPage.Chengpin
{
    public partial class ChengpinChurukuYiChang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            //DataTable dt1 = new DataTable();
            //DataTable dt2 = new DataTable();
            //DataSet ds = new DataSet();

            //ds = MySqlDbHelper.ExecuteDataSet("CALL `slbz`.`出入库异常记录`();");
            //dt1 = ds.Tables[0];
            //dt1.TableName = "异常入库明细";
            //dt2 = ds.Tables[1];
            //dt2.TableName = "异常出库明细";



            //this.GridView1.Caption = dt1.TableName;
            //this.GridView2.Caption = dt2.TableName;
            //this.GridView1.DataSource = dt1;
            //this.GridView1.DataBind();
            //this.GridView2.DataSource = dt2;
            //this.GridView2.DataBind();

            //ds.Dispose();
        }
    }
}