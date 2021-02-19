using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.Chengpin
{
    public partial class ChengpinTuihuoBufu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Caption = "销售退货和退货入库不符";

            GridView1.DataSource = My.GetSqlTxt_Datatable("退货数与退库数不符");
            GridView1.DataBind();
        }
    }
}