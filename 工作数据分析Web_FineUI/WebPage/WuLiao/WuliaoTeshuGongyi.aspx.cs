using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.WuLiao
{
    public partial class WuliaoTeshuGongyi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);


            GridView1.Caption = "特殊工艺订单";

            this.GridView1.DataSource = My.GetSqlTxt_Datatable("特殊工艺订单");
            this.GridView1.DataBind();
        }
    }
}